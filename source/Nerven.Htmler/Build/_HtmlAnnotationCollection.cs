using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlAnnotationCollection : _HtmlNodeCollectionBase<IHtmlAnnotation, IHtmlAnnotableNode>, IHtmlAnnotationCollection
    {
        public _HtmlAnnotationCollection(object proof, IHtmlAnnotableNode owner, _HtmlAnnotationCollection cloneFrom)
            : base(proof, owner, cloneFrom)
        {
        }

        protected override IHtmlAnnotation CloneNode(IHtmlAnnotation node) => node.CloneAnnotation();
    }
}
