using System.Xml.Linq;
using static Nerven.Htmler.Core.HtmlBuilder;

namespace Nerven.Htmler.Core
{
    public static class XAttributeExtensions
    {
        public static IHtmlAttribute ToHtmlNode(this XAttribute xAttribute)
        {
            return Attribute(xAttribute.Name.LocalName, xAttribute.Value);
        }
    }
}
