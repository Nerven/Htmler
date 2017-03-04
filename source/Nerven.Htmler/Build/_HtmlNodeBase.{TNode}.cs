using System.Xml.Linq;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal abstract class _HtmlNodeBase<TNode> : IHtmlNode
        where TNode : IHtmlNode, IHtmlAnnotableNode
    {
        protected _HtmlNodeBase()
        {
            ChildrensProof = new object();
        }

        public abstract IHtmlAnnotationCollection Annotations { get; }

        protected object ChildrensProof { get; }

        public abstract TNode Clone();

        IHtmlNode IHtmlNode.Clone() => Clone();

        public bool Verify(object proof) => ReferenceEquals(ChildrensProof, proof);

        public abstract XObject CreateXObject();
    }
}
