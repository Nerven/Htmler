namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlAttributeCollection : _HtmlNodeCollectionBase<IHtmlAttribute, IHtmlElement>, IHtmlAttributeCollection
    {
        public _HtmlAttributeCollection(object proof, IHtmlElement owner, _HtmlAttributeCollection cloneFrom)
            : base(proof, owner, cloneFrom)
        {
        }

        protected override IHtmlAttribute CloneNode(IHtmlAttribute node) => node.CloneAttribute();
    }
}
