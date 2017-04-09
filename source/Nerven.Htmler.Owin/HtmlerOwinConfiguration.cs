using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Owin
{
    public sealed class HtmlerOwinConfiguration
    {
        private Func<IOwinContext, CancellationToken, Task<IHtmlResourceNode>> _GetResourceAsync;

        private HtmlerOwinConfiguration(Func<IOwinContext, CancellationToken, Task<IHtmlResourceNode>> getResourceAsync)
        {
            _GetResourceAsync = getResourceAsync;
        }
        
        public Task<IHtmlResourceNode> GetResourceAsync(IOwinContext owinContext, CancellationToken cancellationToken) => _GetResourceAsync(owinContext, cancellationToken);

        public static Builder CreateBuilder() => new Builder();

        public sealed class  Builder
        {
            private Func<IOwinContext, CancellationToken, Task<IHtmlResourceNode>> _GetResourceAsync;

            public Builder()
            {
            }

            public Builder WithResourceFunc(Func<IOwinContext, CancellationToken, Task<IHtmlResourceNode>> getResourceAsync)
            {
                _GetResourceAsync = getResourceAsync;

                return this;
            }

            public Builder WithSiteFunc(Func<IOwinContext, CancellationToken, Task<IHtmlSite>> getSiteAsync)
            {
                _GetResourceAsync = (_owinContext, _cancellationToken) => getSiteAsync(_owinContext, _cancellationToken)
                    .ContinueWith(_siteTask =>
                        {
                            var _site = _siteTask.Result;
                            return _ChooseResourceFromSite(_site, _owinContext.Request.Path);
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);

                return this;
            }

            public Builder WithSite(IHtmlSite site)
            {
                WithSiteFunc((_owinContext, _cancellationToken) => Task.FromResult(site));

                return this;
            }

            public HtmlerOwinConfiguration Build()
            {
                return new HtmlerOwinConfiguration(_GetResourceAsync);
            }

            private static IHtmlResourceNode _ChooseResourceFromSite(IHtmlSite site, PathString requestPath)
            {
                return site.Resources.SingleOrDefault(_resource => HtmlOwinDriver.IsMatch(_resource.Name, requestPath));
            }
        }
    }
}
