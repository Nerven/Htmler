using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal abstract class _HtmlNodeCollectionBase<TNode, TOwner> : IHtmlNodeCollection<TNode, TOwner>
        where TNode : class, IHtmlOwnedNode<TNode, TOwner>
        where TOwner : class, IHtmlNode
    {
        private readonly object _Proof;
        private readonly List<TNode> _Collection;

        protected _HtmlNodeCollectionBase(object proof, TOwner owner, _HtmlNodeCollectionBase<TNode, TOwner> cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(proof, nameof(proof))
                .AssertArgumentNotNull(owner, nameof(owner));

            _Proof = proof;
            Owner = owner;

            _Collection = new List<TNode>();

            if (cloneFrom != null)
            {
                _Collection.AddRange(cloneFrom._Collection.Select(CloneNode));
            }
        }

        protected abstract TNode CloneNode(TNode node);

        public TOwner Owner { get; }

        public int Count => _Collection.Count;

        bool ICollection<TNode>.IsReadOnly => false;

        public TNode this[int index] => _Collection[index];

        public void Add(TNode item)
        {
            Must.Assertion
                .AssertArgumentNotNull(item, nameof(item));

            item.Attach(Owner, _Proof);

            _Collection.Add(item);
        }

        public void Clear()
        {
            foreach (var _node in _Collection)
            {
                _node.Detach(_Proof);
            }

            _Collection.Clear();
        }

        public bool Contains(TNode item)
        {
            Must.Assertion
                .AssertArgumentNotNull(item, nameof(item));

            return _Collection.Contains(item);
        }

        public void CopyTo(TNode[] array, int arrayIndex)
        {
            Must.Assertion
                .AssertArgumentNotNull(array, nameof(array));

            _Collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(TNode item)
        {
            Must.Assertion
                .AssertArgumentNotNull(item, nameof(item));

            if (_Collection.Remove(item))
            {
                item.Detach(_Proof);

                return true;
            }

            return false;
        }

        public int IndexOf(TNode item)
        {
            Must.Assertion
                .AssertArgumentNotNull(item, nameof(item));

            return _Collection.IndexOf(item);
        }

        public void Insert(int index, TNode item)
        {
            Must.Assertion
                .AssertArgumentNotNull(item, nameof(item));

            item.Attach(Owner, _Proof);

            _Collection.Insert(index, item);
        }

        public void AddRange(IReadOnlyList<TNode> items)
        {
            Must.Assertion
                .AssertArgumentNotNull(items, nameof(items));

            var _items = new TNode[items.Count];
            var _index = 0;
            foreach (var _item in items)
            {
                _item.Attach(Owner, _Proof);

                _items[_index++] = _item;
            }

            _Collection.AddRange(_items);
        }

        public IEnumerator<TNode> GetEnumerator() => _Collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_Collection).GetEnumerator();
    }
}
