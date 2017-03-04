using System.Text;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler
{
    public interface IHtmlTextResource : IHtmlResourceNode, IHtmlValueNode
    {
        Encoding Encoding { get; }

        IHtmlTextResource CloneTextResource();
    }
}
