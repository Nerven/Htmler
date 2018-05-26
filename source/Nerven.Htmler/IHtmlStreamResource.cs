using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlStreamResource : IHtmlResourceNode
    {
        string MimeType { get; }

        Task<Stream> GetStreamAsync(CancellationToken cancellationToken = default(CancellationToken));

        IHtmlStreamResource CloneStreamResource();
    }
}
