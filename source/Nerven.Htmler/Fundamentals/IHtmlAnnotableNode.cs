namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlAnnotableNode : IHtmlNode
    {
        IHtmlAnnotationCollection Annotations { get; }
    }
}
