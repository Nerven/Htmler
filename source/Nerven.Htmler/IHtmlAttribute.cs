using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlAttribute : IHtmlOwnedNode<IHtmlAttribute, IHtmlElement>, IHtmlAnnotableNode, IHtmlNamedNode, IHtmlValueNode
    {
        IHtmlDeferredData<string> Data { get; }

        IHtmlAttribute CloneAttribute();
    }
}
