using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlResourceNodeCollection : _HtmlNodeCollectionBase<IHtmlResourceNode, IHtmlSite>, IHtmlResourceNodeCollection
    {
        public _HtmlResourceNodeCollection(object proof, IHtmlSite owner, _HtmlResourceNodeCollection cloneFrom)
            : base(proof, owner, cloneFrom)
        {
        }

        protected override IHtmlResourceNode CloneNode(IHtmlResourceNode node) => node.CloneResourceNode();
    }
}
