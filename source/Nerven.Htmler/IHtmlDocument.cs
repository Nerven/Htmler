using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlDocument : IHtmlOwnedNode<IHtmlDocument, IHtmlDocumentResource>, IHtmlAnnotableNode, IHtmlParentNode
    {
        IHtmlDocument CloneDocument();
    }
}
