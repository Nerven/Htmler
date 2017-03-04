using System.Collections.Generic;

namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlResourceNode : IHtmlOwnedNode<IHtmlResourceNode, IHtmlSite>, IHtmlAnnotableNode, IHtmlNamedNode
    {
        new IReadOnlyList<string> Name { get; set; }

        IHtmlResourceNode CloneResourceNode();
    }
}
