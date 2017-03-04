using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
   internal sealed class _HtmlComment : _HtmlOwnedNodeBase<IHtmlComment, IHtmlChildNode, IHtmlParentNode>, IHtmlComment
    {
        private readonly HtmlCommentProperties _CommentProperties;
        private readonly _HtmlAnnotationCollection _Annotations;

        private _HtmlComment(HtmlCommentProperties commentProperties, _HtmlComment cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(commentProperties, nameof(commentProperties));

            _CommentProperties = commentProperties;
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
        }

        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public string Value { get; set; }

        public static IHtmlComment Create(HtmlCommentProperties commentProperties) => new _HtmlComment(commentProperties, null);

        public override IHtmlComment Clone() => new _HtmlComment(_CommentProperties, this);

        public IHtmlChildNode CloneChildNode() => Clone();

        public IHtmlComment CloneComment() => Clone();

        public override XObject CreateXObject() => Value == null ? null : new XComment(Value);
    }
}
