using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Htmler.Fundamentals;
using static Nerven.Htmler.Core.HtmlBuilder;

namespace Nerven.Htmler.Core
{
    public static class XNodeExtensions
    {
        public static IHtmlChildNode ToHtmlNode(this XNode xNode)
        {
            switch (xNode.NodeType)
            {
                case XmlNodeType.Comment:
                    var _xComment = (XComment)xNode;
                    return Comment(_xComment.Value);
                case XmlNodeType.Document:
                    var _xDocument = (XDocument)xNode;
                    return ToHtmlNode(_xDocument.Root);
                case XmlNodeType.CDATA:
                    var _xCData = (XCData)xNode;
                    return Raw(_xCData.Value);
                case XmlNodeType.Element:
                    var _xElement = (XElement)xNode;
                    var _htmlElement = Element(_xElement.Name.LocalName, _xElement.IsEmpty);
                    _htmlElement.Attributes.AddRange(_xElement.Attributes().Select(_xAttribute => _xAttribute.ToHtmlNode()).ToList());

                    if (!_xElement.IsEmpty)
                    {
                        var _htmlContainerElement = (IHtmlContainerElement)_htmlElement;
                        _htmlContainerElement.Children.AddRange(_xElement.Nodes().Select(ToHtmlNode).ToList());
                    }
                    
                    return _htmlElement;
                case XmlNodeType.Text:
                    var _xText = (XText)xNode;
                    return Text(_xText.Value);
                case XmlNodeType.Whitespace:
                    var _xWhitespace = (XText)xNode;
                    return Text(string.IsNullOrEmpty(_xWhitespace.Value) ? " " : _xWhitespace.Value);
                default:
                    throw Must.Assertion.AssertNever<NotSupportedException>();
            }
        }
    }
}
