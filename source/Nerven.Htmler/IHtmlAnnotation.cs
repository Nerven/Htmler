using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    //// ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IHtmlAnnotation : IHtmlOwnedNode<IHtmlAnnotation, IHtmlAnnotableNode>, IHtmlNamedNode
    {
        IHtmlAnnotation CloneAnnotation();
    }
}
