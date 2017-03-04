using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlElement : _HtmlOwnedNodeBase<IHtmlElement, IHtmlChildNode, IHtmlParentNode>, IHtmlElement
    {
        private static readonly IReadOnlyList<IHtmlChildNode> _EmptyChildren = new ReadOnlyCollection<IHtmlChildNode>(new List<IHtmlChildNode>());
        private readonly HtmlElementProperties _ElementProperties;
        private readonly _HtmlAnnotationCollection _Annotations;
        private readonly _HtmlAttributeCollection _Attributes;
        
        private _HtmlElement(HtmlElementProperties elementProperties, _HtmlElement cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(elementProperties, nameof(elementProperties));

            _ElementProperties = elementProperties;
            
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
            _Attributes = new _HtmlAttributeCollection(ChildrensProof, this, cloneFrom?._Attributes);
        }

        public string Name => _ElementProperties.ElementName;

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public IHtmlAttributeCollection Attributes => _Attributes;

        public IReadOnlyList<IHtmlChildNode> Children => _EmptyChildren;

        public static IHtmlElement Create(HtmlElementProperties elementProperties) => new _HtmlElement(elementProperties, null);

        public override IHtmlElement Clone() => new _HtmlElement(_ElementProperties, this);

        public IHtmlChildNode CloneChildNode() => Clone();

        public IHtmlElement CloneElement() => Clone();

        public override XObject CreateXObject() => new XElement(
            Name,
            Attributes.Select(_attribute => _attribute.CreateXObject()));
    }
}
