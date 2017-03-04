using System.Collections.Generic;

namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlNodeCollection<TNode, out TOwner> : IReadOnlyList<TNode>, ICollection<TNode>
        where TNode : IHtmlOwnedNode<TNode, TOwner>
        where TOwner : IHtmlNode
    {
        TOwner Owner { get; }

        new int Count { get; }

        void Insert(int index, TNode item);

        void AddRange(IReadOnlyList<TNode> items);
    }
}
