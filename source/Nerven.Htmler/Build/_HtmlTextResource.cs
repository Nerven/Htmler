using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlTextResource : _HtmlResourceNodeBase<IHtmlTextResource, HtmlTextResourceProperties>, IHtmlTextResource
    {
        private static readonly Encoding _DefaultEncoding = new UTF8Encoding(false);
        
        private _HtmlTextResource(HtmlTextResourceProperties textResourceProperties, _HtmlTextResource cloneFrom)
            : base(textResourceProperties, cloneFrom)
        {
        }
        
        public Encoding Encoding => null;

        public string Value { get; set; }

        public static IHtmlTextResource Create(HtmlTextResourceProperties textResourceProperties) => new _HtmlTextResource(textResourceProperties, null);

        public override IHtmlTextResource Clone() => new _HtmlTextResource(ResourceProperties, this);

        public IHtmlTextResource CloneTextResource() => Clone();

        public override XObject CreateXObject() => throw new NotSupportedException();

        public override async Task WriteToStreamAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            Must.Assertion
                .AssertArgumentNotNull(stream, nameof(stream));

            var _streamWriter = new StreamWriter(stream, Encoding ?? _DefaultEncoding) { AutoFlush = false };
            await _streamWriter.WriteAsync(Value).ConfigureAwait(false);
            await _streamWriter.FlushAsync().ConfigureAwait(false);
        }
    }
}
