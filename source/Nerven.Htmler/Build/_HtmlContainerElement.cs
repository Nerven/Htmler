using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlContainerElement : _HtmlOwnedNodeBase<IHtmlContainerElement, IHtmlChildNode, IHtmlParentNode>, IHtmlContainerElement
    {
        private readonly HtmlElementProperties _ElementProperties;
        private readonly _HtmlAnnotationCollection _Annotations;
        private readonly _HtmlAttributeCollection _Attributes;
        private readonly _HtmlChildNodeCollection _Children;

        private _HtmlContainerElement(HtmlElementProperties elementProperties, _HtmlContainerElement cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(elementProperties, nameof(elementProperties));

            _ElementProperties = elementProperties;

            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
            _Children = new _HtmlChildNodeCollection(ChildrensProof, this, cloneFrom?._Children);
            _Attributes = new _HtmlAttributeCollection(ChildrensProof, this, cloneFrom?._Attributes);
        }

        public string Name => _ElementProperties.ElementName;

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public IHtmlAttributeCollection Attributes => _Attributes;

        public IHtmlChildNodeCollection Children => _Children;

        IReadOnlyList<IHtmlChildNode> IHtmlElement.Children => Children;

        public static IHtmlContainerElement Create(HtmlElementProperties elementProperties) => new _HtmlContainerElement(elementProperties, null);

        public override IHtmlContainerElement Clone() => new _HtmlContainerElement(_ElementProperties, this);

        public IHtmlChildNode CloneChildNode() => Clone();

        public IHtmlElement CloneElement() => Clone();

        public IHtmlContainerElement CloneContainerElement() => Clone();

        public override XObject CreateXObject()
        {
            var _xAttributes = Attributes.Select(_attribute => _attribute.CreateXObject());
            var _xNodes = Children.Count == 0 
                ? new XObject[] { new XText(string.Empty) } 
                : Children.Select(_child => _child.CreateXObject());

            return new XElement(
                Name,
                _xAttributes.Concat(_xNodes));
        }
    }
}
