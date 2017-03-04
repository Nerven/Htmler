using System.Collections.Generic;
using Nerven.Htmler.Build;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Core
{
    public static partial class HtmlBuilder
    {
        public static IHtmlSite Site(params IHtmlResourceNode[] resources)
        {
            var _site = new HtmlSiteProperties().CreateSite();
            _site.Resources.AddRange(resources);
            return _site;
        }

        public static IHtmlDocumentResource DocumentResource(IReadOnlyList<string> name, IHtmlDocument document)
        {
            var _resource = new HtmlDocumentResourceProperties().CreateDocumentResource();
            _resource.Name = name;
            _resource.Document = document;
            return _resource;
        }

        public static IHtmlDocument Document(params IHtmlChildNode[] children)
        {
            var _document = new HtmlDocumentProperties().CreateDocument();
            _document.Children.AddRange(children);
            return _document;
        }

        public static IHtmlAttribute Attribute(string name, string value)
        {
            var _attribute = new HtmlAttributeProperties(name).CreateAttribute();
            _attribute.Data.Final = value;
            return _attribute;
        }

        public static IHtmlText Text(string s)
        {
            var _text = new HtmlTextProperties().CreateText();
            _text.Value = s;
            return _text;
        }

        public static IHtmlComment Comment(string s)
        {
            var _comment = new HtmlCommentProperties().CreateComment();
            _comment.Value = s;
            return _comment;
        }

        public static IHtmlRaw Raw(string s)
        {
            var _raw = new HtmlRawProperties().CreateRaw();
            _raw.Value = s;
            return _raw;
        }

        private static HtmlElementProperties _EmptyElementProperties(string elementName)
        {
            return new HtmlElementProperties(elementName, true);
        }

        private static HtmlElementProperties _ContainerElementProperties(string elementName)
        {
            return new HtmlElementProperties(elementName, false);
        }
    }
}
