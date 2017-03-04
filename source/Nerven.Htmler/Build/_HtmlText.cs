using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
   internal sealed class _HtmlText : _HtmlOwnedNodeBase<IHtmlText, IHtmlChildNode, IHtmlParentNode>, IHtmlText
    {
        private readonly HtmlTextProperties _TextProperties;
        private readonly _HtmlAnnotationCollection _Annotations;

        private _HtmlText(HtmlTextProperties textProperties, _HtmlText cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(textProperties, nameof(textProperties));

            _TextProperties = textProperties;
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
        }

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public string Value { get; set; }

        public static IHtmlText Create(HtmlTextProperties textProperties) => new _HtmlText(textProperties, null);

        public override IHtmlText Clone() => new _HtmlText(_TextProperties, this);

        public IHtmlChildNode CloneChildNode() => Clone();

        public IHtmlText CloneText() => Clone();

        public override XObject CreateXObject() => Value == null ? null : new XText(Value);
    }
}
