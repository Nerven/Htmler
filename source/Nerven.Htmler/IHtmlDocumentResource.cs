using System.Text;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlDocumentResource : IHtmlResourceNode
    {
        IHtmlDocument Document { get; set; }

        Encoding Encoding { get; }

        IHtmlDocumentResource CloneDocumentResource();
    }
}
