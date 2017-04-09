using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlResourceNode : IHtmlOwnedNode<IHtmlResourceNode, IHtmlSite>, IHtmlAnnotableNode, IHtmlNamedNode
    {
        new IReadOnlyList<string> Name { get; set; }

        IHtmlResourceNode CloneResourceNode();

        Task WriteToStreamAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken));
    }
}
