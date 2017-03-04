using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlSite : IHtmlAnnotableNode
    {
        IHtmlResourceNodeCollection Resources { get; }

        IHtmlSite CloneSite();
    }
}
