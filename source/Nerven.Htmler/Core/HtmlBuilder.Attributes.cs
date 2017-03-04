using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Nerven.Htmler.Build;

namespace Nerven.Htmler.Core
{
    //// ReSharper disable InconsistentNaming
    public static partial class HtmlBuilder
    {
        public static IHtmlAttribute altAttr(string alt)
        {
            var _attribute = new HtmlAttributeProperties(nameof(alt)).CreateAttribute();
            _attribute.Data.Final = alt;
            return _attribute;
        }

        public static IHtmlAttribute classAttr(params string[] @class)
        {
            var _attribute = new HtmlAttributeProperties(nameof(@class)).CreateAttribute();
            _attribute.Data.UpdateAsSpaceSeparatedStringList(_value => _value.Concat(@class).Distinct(StringComparer.Ordinal));
            return _attribute;
        }

        public static IHtmlAttribute charsetAttr(Encoding charset)
        {
            var _attribute = new HtmlAttributeProperties(nameof(charset)).CreateAttribute();
            _attribute.Data.Final = charset?.WebName;
            return _attribute;
        }

        public static IHtmlAttribute charsetAttr(string charset)
        {
            var _attribute = new HtmlAttributeProperties(nameof(charset)).CreateAttribute();
            _attribute.Data.Final = charset;
            return _attribute;
        }

        public static IHtmlAttribute contentAttr(string content)
        {
            var _attribute = new HtmlAttributeProperties(nameof(content)).CreateAttribute();
            _attribute.Data.Final = content;
            return _attribute;
        }

        public static IHtmlAttribute hrefAttr(Uri href)
        {
            var _attribute = new HtmlAttributeProperties(nameof(href)).CreateAttribute();
            _attribute.Data.UpdateAsUri(_value => href);
            return _attribute;
        }

        public static IHtmlAttribute hrefAttr(string href)
        {
            var _attribute = new HtmlAttributeProperties(nameof(href)).CreateAttribute();
            _attribute.Data.Final = href;
            return _attribute;
        }

        public static IHtmlAttribute idAttr(string id)
        {
            var _attribute = new HtmlAttributeProperties(nameof(id)).CreateAttribute();
            _attribute.Data.Final = id;
            return _attribute;
        }

        public static IHtmlAttribute langAttr(string lang)
        {
            var _attribute = new HtmlAttributeProperties(nameof(lang)).CreateAttribute();
            _attribute.Data.Final = lang;
            return _attribute;
        }

        public static IHtmlAttribute langAttr(CultureInfo lang)
        {
            var _attribute = new HtmlAttributeProperties(nameof(lang)).CreateAttribute();
            _attribute.Data.Final = lang?.Name;
            return _attribute;
        }

        public static IHtmlAttribute nameAttr(string name)
        {
            var _attribute = new HtmlAttributeProperties(nameof(name)).CreateAttribute();
            _attribute.Data.Final = name;
            return _attribute;
        }

        public static IHtmlAttribute relAttr(string rel)
        {
            var _attribute = new HtmlAttributeProperties(nameof(rel)).CreateAttribute();
            _attribute.Data.Final = rel;
            return _attribute;
        }

        public static IHtmlAttribute srcAttr(Uri src)
        {
            var _attribute = new HtmlAttributeProperties(nameof(src)).CreateAttribute();
            _attribute.Data.UpdateAsUri(_value => src);
            return _attribute;
        }

        public static IHtmlAttribute titleAttr(string title)
        {
            var _attribute = new HtmlAttributeProperties(nameof(title)).CreateAttribute();
            _attribute.Data.Final = title;
            return _attribute;
        }

        public static IHtmlAttribute typeAttr(string type)
        {
            var _attribute = new HtmlAttributeProperties(nameof(type)).CreateAttribute();
            _attribute.Data.Final = type;
            return _attribute;
        }
    }
}
