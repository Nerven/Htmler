using System;
using System.Xml;
using System.Xml.Linq;
using Nerven.Assertion;

namespace Nerven.Htmler.Core
{
    public static class XObjectExtensions
    {
        public static IHtmlNode ToHtmlNode(this XObject xObject)
        {
            switch (xObject.NodeType)
            {
                case XmlNodeType.Attribute:
                    var _xAttribute = (XAttribute)xObject;
                    return _xAttribute.ToHtmlNode();
                case XmlNodeType.Comment:
                case XmlNodeType.Document:
                case XmlNodeType.CDATA:
                case XmlNodeType.Element:
                case XmlNodeType.Text:
                case XmlNodeType.Whitespace:
                    return ((XNode)xObject).ToHtmlNode();
                default:
                    throw Must.Assertion.AssertNever<NotSupportedException>();
            }
        }
    }
}
