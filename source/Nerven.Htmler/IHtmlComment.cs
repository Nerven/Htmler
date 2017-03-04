using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlComment : IHtmlAnnotableNode, IHtmlChildNode, IHtmlValueNode
    {
        new string Value { get; set; }

        IHtmlComment CloneComment();
    }
}
