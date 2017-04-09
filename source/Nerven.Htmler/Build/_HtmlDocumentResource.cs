using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Core;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlDocumentResource : _HtmlResourceNodeBase<IHtmlDocumentResource, HtmlDocumentResourceProperties>, IHtmlDocumentResource
    {
        private static readonly Encoding _DefaultEncoding = new UTF8Encoding(false);

        private IHtmlDocument _Document;

        private _HtmlDocumentResource(HtmlDocumentResourceProperties documentResourceProperties, _HtmlDocumentResource cloneFrom)
            : base(documentResourceProperties, cloneFrom)
        {
        }
        
        public IHtmlDocument Document
        {
            get { return _Document; }
            set
            {
                _Document?.Detach(ChildrensProof);
                _Document = null;

                value.Attach(this, ChildrensProof);
                _Document = value;
            }
        }

        public Encoding Encoding => null;

        public static IHtmlDocumentResource Create(HtmlDocumentResourceProperties documentResourceProperties) => new _HtmlDocumentResource(documentResourceProperties, null);

        public override IHtmlDocumentResource Clone() => new _HtmlDocumentResource(ResourceProperties, this);

        public IHtmlDocumentResource CloneDocumentResource() => Clone();

        public override XObject CreateXObject() => Document?.CreateXObject();

        public override Task WriteToStreamAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            Must.Assertion
                .AssertArgumentNotNull(stream, nameof(stream));

            _Document.WriteToStream(stream, Encoding ?? _DefaultEncoding);

            return Task.CompletedTask;
        }
    }
}
