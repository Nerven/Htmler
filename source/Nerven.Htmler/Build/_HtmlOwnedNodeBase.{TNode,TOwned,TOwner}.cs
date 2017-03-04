using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal abstract class _HtmlOwnedNodeBase<TNode, TOwned, TOwner> : _HtmlNodeBase<TNode>, IHtmlOwnedNode<TOwned, TOwner>
        where TNode : TOwned, IHtmlAnnotableNode
        where TOwned : IHtmlOwnedNode<TOwned, TOwner>
        where TOwner : class, IHtmlNode
    {
        private object _OwnersProof;

        public TOwner Parent { get; private set; }

        public void Attach(TOwner owner, object proof)
        {
            Must.Assertion
                .AssertArgumentNotNull(owner, nameof(owner))
                .AssertArgumentNotNull(proof, nameof(proof))
                .Assert(Parent == null)
                .Assume(() => _OwnersProof == null)
                .Assert(owner.Verify(proof));

            Parent = owner;
            _OwnersProof = proof;
        }

        public void Detach(object proof)
        {
            Must.Assertion
                .AssertArgumentNotNull(proof, nameof(proof))
                .Assert(Parent != null)
                .Assume(() => _OwnersProof != null)
                .Assert(ReferenceEquals(_OwnersProof, proof));

            Parent = null;
            _OwnersProof = null;
        }
    }
}
