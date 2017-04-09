using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Nerven.Htmler.Owin
{
    [PublicAPI]
    public sealed class HtmlOwinDriver
    {
        public static AppFunc Create(HtmlerOwinConfiguration configuration) => _environment => ExecuteAsync(configuration, _environment);

        public static Task ExecuteAsync(HtmlerOwinConfiguration configuration, IOwinContext owinContext)
        {
            return Task.Run(async () =>
                {
                    var _isGetRequest = owinContext.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase);
                    var _isHeadRequest = owinContext.Request.Method.Equals("HEAD", StringComparison.OrdinalIgnoreCase);
                    if (!_isGetRequest && !_isHeadRequest)
                    {
                        owinContext.Response.StatusCode = 405;
                        return;
                    }

                    var _resouce = await configuration.GetResourceAsync(owinContext, owinContext.Request.CallCancelled).ConfigureAwait(false);

                    if (_resouce == null)
                    {
                        owinContext.Response.StatusCode = 404;
                        return;
                    }

                    if (_isHeadRequest)
                    {
                        // TODO
                    }

                    owinContext.Response.StatusCode = 200;
                    await _resouce.WriteToStreamAsync(owinContext.Response.Body).ConfigureAwait(false);
                }, owinContext.Request.CallCancelled);
        }

        public static Task ExecuteAsync(HtmlerOwinConfiguration configuration, IDictionary<string, object> environment)
        {
            var _cancellationToken = _GetCancellationTokenFromEnvironment(environment);
            return Task.Run(() => ExecuteAsync(configuration, new OwinContext(environment)), _cancellationToken);
        }

        public static bool IsMatch(IReadOnlyList<string> resourcePath, PathString requestPath)
        {
            PathString _remainingPath;
            // TODO: Make this properly (escaping/unescaping and stuff)
            return requestPath.StartsWithSegments(new PathString("/" + string.Join("/", resourcePath)), out _remainingPath) && (!_remainingPath.HasValue || _remainingPath.Value == "/");
        }

        private static CancellationToken _GetCancellationTokenFromEnvironment(IDictionary<string, object> environment)
        {
            (environment ?? new Dictionary<string, object>()).TryGetValue("owin.CallCancelled", out object _cancellationTokenObject);
            return _cancellationTokenObject as CancellationToken? ?? default(CancellationToken);
        }
    }
}
