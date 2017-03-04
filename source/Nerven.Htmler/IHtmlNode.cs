using System.ComponentModel;
using System.Xml.Linq;

namespace Nerven.Htmler
{
    public interface IHtmlNode
    {
        IHtmlNode Clone();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Verify(object proof);

        XObject CreateXObject();
    }
}
