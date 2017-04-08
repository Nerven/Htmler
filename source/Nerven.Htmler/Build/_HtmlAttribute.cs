using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
   internal sealed class _HtmlAttribute : _HtmlOwnedNodeBase<IHtmlAttribute, IHtmlAttribute, IHtmlElement>, IHtmlAttribute
    {
        private readonly HtmlAttributeProperties _AttributeProperties;
        private readonly _HtmlAnnotationCollection _Annotations;

        private _HtmlAttribute(HtmlAttributeProperties attributeProperties, _HtmlAttribute cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(attributeProperties, nameof(attributeProperties));

            _AttributeProperties = attributeProperties;

            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);

            _HtmlDeferredData<string>.Create(_ref => Data = _ref);

            Data.Final = cloneFrom?.Data.Final;
        }

        public string Name => _AttributeProperties.AttributeName;

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public string Value => Data.Final;

        public IHtmlDeferredData<string> Data { get; private set; }

        public static IHtmlAttribute Create(HtmlAttributeProperties attributeProperties) => new _HtmlAttribute(attributeProperties, null);

        public override IHtmlAttribute Clone() => new _HtmlAttribute(_AttributeProperties, this);

        public IHtmlAttribute CloneAttribute() => Clone();

        public override XObject CreateXObject() => new XAttribute(Name, Value ?? string.Empty);
    }
}
