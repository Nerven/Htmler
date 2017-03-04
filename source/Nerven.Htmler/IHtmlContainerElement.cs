using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlContainerElement : IHtmlElement, IHtmlParentNode
    {
        new IHtmlChildNodeCollection Children { get; }

        IHtmlContainerElement CloneContainerElement();
    }
}
