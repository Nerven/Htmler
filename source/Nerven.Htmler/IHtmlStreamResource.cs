using System.IO;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlStreamResource : IHtmlResourceNode
    {
        Stream GetStream();

        IHtmlStreamResource CloneStreamResource();
    }
}
