using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Nerven.Htmler.Build
{
    public sealed class HtmlStreamResourceProperties
    {
        private readonly Func<CancellationToken, Task<Stream>> _GetStreamAsync;

        private HtmlStreamResourceProperties(string mimeType, Func<CancellationToken, Task<Stream>> getStreamAsync)
        {
            MimeType = mimeType;
            _GetStreamAsync = getStreamAsync;
        }

        public string MimeType { get; }

        public Task<Stream> GetStreamAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _GetStreamAsync(cancellationToken);
        }

        public static IHtmlStreamResource CreateStreamResource(string mimeType, Func<CancellationToken, Task<Stream>> getStreamAsync)
        {
            return _HtmlStreamResource.Create(new HtmlStreamResourceProperties(mimeType, getStreamAsync));
        }

        public static IHtmlStreamResource CreateStreamResource(string mimeType, Func<Task<Stream>> getStreamAsync)
        {
            return _HtmlStreamResource.Create(new HtmlStreamResourceProperties(mimeType, _ => getStreamAsync()));
        }

        public static IHtmlStreamResource CreateStreamResource(string mimeType, Func<CancellationToken, Stream> getStream)
        {
            return _HtmlStreamResource.Create(new HtmlStreamResourceProperties(mimeType, _cancellationToken => Task.FromResult(getStream(_cancellationToken))));
        }

        public static IHtmlStreamResource CreateStreamResource(string mimeType, Func<Stream> getStream)
        {
            return _HtmlStreamResource.Create(new HtmlStreamResourceProperties(mimeType, _ => Task.FromResult(getStream())));
        }

        public static IHtmlStreamResource CreateStreamResource(string mimeType, byte[] data)
        {
            return _HtmlStreamResource.Create(new HtmlStreamResourceProperties(mimeType, _ => Task.FromResult<Stream>(new MemoryStream(data) { Position = 0 })));
        }
    }
}
