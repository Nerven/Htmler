using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
   internal sealed class _HtmlRaw : _HtmlOwnedNodeBase<IHtmlRaw, IHtmlChildNode, IHtmlParentNode>, IHtmlRaw
    {
        private readonly HtmlRawProperties _RawProperties;
        private readonly _HtmlAnnotationCollection _Annotations;

        private _HtmlRaw(HtmlRawProperties rawProperties, _HtmlRaw cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(rawProperties, nameof(rawProperties));

            _RawProperties = rawProperties;
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
        }

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public string Value { get; set; }

        public static IHtmlRaw Create(HtmlRawProperties rawProperties) => new _HtmlRaw(rawProperties, null);

        public override IHtmlRaw Clone() => new _HtmlRaw(_RawProperties, this);

        public IHtmlChildNode CloneChildNode() => Clone();

        public IHtmlRaw CloneRaw() => Clone();

        public override XObject CreateXObject() => Value == null ? null : new XCData(Value);
    }
}
