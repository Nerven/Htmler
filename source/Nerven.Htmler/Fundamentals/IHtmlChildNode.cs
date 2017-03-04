namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlChildNode : IHtmlOwnedNode<IHtmlChildNode, IHtmlParentNode>
    {
        IHtmlChildNode CloneChildNode();
    }
}
