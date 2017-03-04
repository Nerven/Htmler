using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlRaw : IHtmlAnnotableNode, IHtmlChildNode, IHtmlValueNode
    {
        new string Value { get; set; }

        IHtmlRaw CloneRaw();
    }
}
