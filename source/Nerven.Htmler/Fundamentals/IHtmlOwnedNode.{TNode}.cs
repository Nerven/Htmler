using System.ComponentModel;

namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlOwnedNode<out TNode, TOwner> : IHtmlNode
        where TNode : IHtmlOwnedNode<TNode, TOwner>
        where TOwner : IHtmlNode
    {
        TOwner Parent { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void Attach(TOwner owner, object proof);

        [EditorBrowsable(EditorBrowsableState.Never)]
        void Detach(object proof);
    }
}
