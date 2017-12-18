using System.Text;
using System.Xml.Linq;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlDocumentResource : _HtmlResourceNodeBase<IHtmlDocumentResource, HtmlDocumentResourceProperties>, IHtmlDocumentResource
    {
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
    }
}
