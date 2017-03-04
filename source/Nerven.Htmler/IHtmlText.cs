using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlText : IHtmlAnnotableNode, IHtmlChildNode, IHtmlValueNode
    {
        new string Value { get; set; }

        IHtmlText CloneText();
    }
}
