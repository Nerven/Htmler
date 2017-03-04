using System.Linq;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlDocument : _HtmlOwnedNodeBase<IHtmlDocument, IHtmlDocument, IHtmlDocumentResource>, IHtmlDocument
    {
        private readonly HtmlDocumentProperties _DocumentProperties;
        private readonly _HtmlAnnotationCollection _Annotations;
        private readonly _HtmlChildNodeCollection _Children;
        
        private _HtmlDocument(HtmlDocumentProperties documentProperties, _HtmlDocument cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(documentProperties, nameof(documentProperties));

            _DocumentProperties = documentProperties;
            
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
            _Children = new _HtmlChildNodeCollection(ChildrensProof, this, cloneFrom?._Children);
        }
        
        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public IHtmlChildNodeCollection Children => _Children;

        public static IHtmlDocument Create(HtmlDocumentProperties documentProperties) => new _HtmlDocument(documentProperties, null);
        
        public override IHtmlDocument Clone() => new _HtmlDocument(_DocumentProperties, this);

        public IHtmlDocument CloneDocument() => Clone();

        public override XObject CreateXObject() => new XDocument(Children.Select(_attribute => _attribute.CreateXObject()));
    }
}
