using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlChildNodeCollection : _HtmlNodeCollectionBase<IHtmlChildNode, IHtmlParentNode>, IHtmlChildNodeCollection
    {
        public _HtmlChildNodeCollection(object proof, IHtmlParentNode owner, _HtmlChildNodeCollection cloneFrom)
            : base(proof, owner, cloneFrom)
        {
        }

        protected override IHtmlChildNode CloneNode(IHtmlChildNode node) => node.CloneChildNode();
    }
}
