namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlParentNode : IHtmlNode
    {
        IHtmlChildNodeCollection Children { get; }
    }
}
