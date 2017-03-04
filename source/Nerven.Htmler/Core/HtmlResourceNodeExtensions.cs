using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Core
{
    public static class HtmlResourceNodeExtensions
    {
        private static readonly Encoding _DefaultEncoding = new UTF8Encoding(false);

        public static async Task WriteToStreamAsync(this IHtmlResourceNode resourceNode, Stream stream)
        {
            Must.Assertion
                .AssertArgumentNotNull(resourceNode, nameof(resourceNode))
                .AssertArgumentNotNull(stream, nameof(stream));

            var _documentResource = resourceNode as IHtmlDocumentResource;
            if (_documentResource != null)
            {
                _documentResource.Document.WriteToStream(stream, _documentResource.Encoding ?? _DefaultEncoding);
                return;
            }

            var _streamResource = resourceNode as IHtmlStreamResource;
            if (_streamResource != null)
            {
                await _streamResource.GetStream().CopyToAsync(stream).ConfigureAwait(false);
                return;
            }

            var _textResource = resourceNode as IHtmlTextResource;
            if (_textResource != null)
            {
                var _streamWriter = new StreamWriter(stream, _textResource.Encoding ?? _DefaultEncoding);
                await _streamWriter.WriteAsync(_textResource.Value).ConfigureAwait(false);
                return;
            }

            Must.Assertion.AssertNever<NotSupportedException>();
        }
    }
}
