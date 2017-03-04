using System.Collections.Generic;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlElement : IHtmlAnnotableNode, IHtmlChildNode, IHtmlNamedNode
    {
        IReadOnlyList<IHtmlChildNode> Children { get; }
            
        IHtmlAttributeCollection Attributes { get; }

        IHtmlElement CloneElement();
    }
}
