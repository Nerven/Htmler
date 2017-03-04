using System;
using System.Collections.Generic;
using Nerven.Assertion;
using Nerven.Htmler.Build;

namespace Nerven.Htmler.Core
{
    //// ReSharper disable InconsistentNaming
    public partial class HtmlBuilder
    {
        private static readonly HtmlElementProperties _AElement = _ContainerElementProperties("a");
        private static readonly HtmlElementProperties _AbbrElement = _ContainerElementProperties("abbr");
        private static readonly HtmlElementProperties _AddressElement = _ContainerElementProperties("address");
        private static readonly HtmlElementProperties _AreaElement = _EmptyElementProperties("area");
        private static readonly HtmlElementProperties _ArticleElement = _ContainerElementProperties("article");
        private static readonly HtmlElementProperties _AsideElement = _ContainerElementProperties("aside");
        private static readonly HtmlElementProperties _AudioElement = _ContainerElementProperties("audio");
        private static readonly HtmlElementProperties _BElement = _ContainerElementProperties("b");
        private static readonly HtmlElementProperties _BaseElement = _EmptyElementProperties("base");
        private static readonly HtmlElementProperties _BdiElement = _ContainerElementProperties("bdi");
        private static readonly HtmlElementProperties _BdoElement = _ContainerElementProperties("bdo");
        private static readonly HtmlElementProperties _BlockquoteElement = _ContainerElementProperties("blockquote");
        private static readonly HtmlElementProperties _BodyElement = _ContainerElementProperties("body");
        private static readonly HtmlElementProperties _BrElement = _EmptyElementProperties("br");
        private static readonly HtmlElementProperties _ButtonElement = _ContainerElementProperties("button");
        private static readonly HtmlElementProperties _CanvasElement = _ContainerElementProperties("canvas");
        private static readonly HtmlElementProperties _CaptionElement = _ContainerElementProperties("caption");
        private static readonly HtmlElementProperties _CiteElement = _ContainerElementProperties("cite");
        private static readonly HtmlElementProperties _CodeElement = _ContainerElementProperties("code");
        private static readonly HtmlElementProperties _ColElement = _EmptyElementProperties("col");
        private static readonly HtmlElementProperties _ColgroupElement = _ContainerElementProperties("colgroup");
        private static readonly HtmlElementProperties _DataElement = _ContainerElementProperties("data");
        private static readonly HtmlElementProperties _DatalistElement = _ContainerElementProperties("datalist");
        private static readonly HtmlElementProperties _DdElement = _ContainerElementProperties("dd");
        private static readonly HtmlElementProperties _DelElement = _ContainerElementProperties("del");
        private static readonly HtmlElementProperties _DfnElement = _ContainerElementProperties("dfn");
        private static readonly HtmlElementProperties _DivElement = _ContainerElementProperties("div");
        private static readonly HtmlElementProperties _DlElement = _ContainerElementProperties("dl");
        private static readonly HtmlElementProperties _DtElement = _ContainerElementProperties("dt");
        private static readonly HtmlElementProperties _EmElement = _ContainerElementProperties("em");
        private static readonly HtmlElementProperties _EmbedElement = _EmptyElementProperties("embed");
        private static readonly HtmlElementProperties _FieldsetElement = _ContainerElementProperties("fieldset");
        private static readonly HtmlElementProperties _FigureElement = _ContainerElementProperties("figure");
        private static readonly HtmlElementProperties _FooterElement = _ContainerElementProperties("footer");
        private static readonly HtmlElementProperties _FormElement = _ContainerElementProperties("form");
        private static readonly HtmlElementProperties _H1Element = _ContainerElementProperties("h1");
        private static readonly HtmlElementProperties _H2Element = _ContainerElementProperties("h2");
        private static readonly HtmlElementProperties _H3Element = _ContainerElementProperties("h3");
        private static readonly HtmlElementProperties _H4Element = _ContainerElementProperties("h4");
        private static readonly HtmlElementProperties _H5Element = _ContainerElementProperties("h5");
        private static readonly HtmlElementProperties _H6Element = _ContainerElementProperties("h6");
        private static readonly HtmlElementProperties _HeadElement = _ContainerElementProperties("head");
        private static readonly HtmlElementProperties _HeaderElement = _ContainerElementProperties("header");
        private static readonly HtmlElementProperties _HrElement = _EmptyElementProperties("hr");
        private static readonly HtmlElementProperties _HtmlElement = _ContainerElementProperties("html");
        private static readonly HtmlElementProperties _IElement = _ContainerElementProperties("i");
        private static readonly HtmlElementProperties _IframeElement = _ContainerElementProperties("iframe");
        private static readonly HtmlElementProperties _ImgElement = _EmptyElementProperties("img");
        private static readonly HtmlElementProperties _InputElement = _EmptyElementProperties("input");
        private static readonly HtmlElementProperties _InsElement = _ContainerElementProperties("ins");
        private static readonly HtmlElementProperties _KbdElement = _ContainerElementProperties("kbd");
        private static readonly HtmlElementProperties _LabelElement = _ContainerElementProperties("label");
        private static readonly HtmlElementProperties _LegendElement = _ContainerElementProperties("legend");
        private static readonly HtmlElementProperties _LiElement = _ContainerElementProperties("li");
        private static readonly HtmlElementProperties _LinkElement = _EmptyElementProperties("link");
        private static readonly HtmlElementProperties _MainElement = _ContainerElementProperties("main");
        private static readonly HtmlElementProperties _MapElement = _ContainerElementProperties("map");
        private static readonly HtmlElementProperties _MarkElement = _ContainerElementProperties("mark");
        private static readonly HtmlElementProperties _MetaElement = _EmptyElementProperties("meta");
        private static readonly HtmlElementProperties _MeterElement = _ContainerElementProperties("meter");
        private static readonly HtmlElementProperties _NavElement = _ContainerElementProperties("nav");
        private static readonly HtmlElementProperties _NoScriptElement = _ContainerElementProperties("noscript");
        private static readonly HtmlElementProperties _ObjectElement = _ContainerElementProperties("object");
        private static readonly HtmlElementProperties _OlElement = _ContainerElementProperties("ol");
        private static readonly HtmlElementProperties _OptGroupElement = _ContainerElementProperties("optgroup");
        private static readonly HtmlElementProperties _OptionElement = _ContainerElementProperties("option");
        private static readonly HtmlElementProperties _OutputElement = _ContainerElementProperties("output");
        private static readonly HtmlElementProperties _PElement = _ContainerElementProperties("p");
        private static readonly HtmlElementProperties _ParamElement = _EmptyElementProperties("param");
        private static readonly HtmlElementProperties _PreElement = _ContainerElementProperties("pre");
        private static readonly HtmlElementProperties _ProgressElement = _ContainerElementProperties("progress");
        private static readonly HtmlElementProperties _QElement = _ContainerElementProperties("q");
        private static readonly HtmlElementProperties _RbElement = _ContainerElementProperties("rb");
        private static readonly HtmlElementProperties _RpElement = _ContainerElementProperties("rp");
        private static readonly HtmlElementProperties _RtElement = _ContainerElementProperties("rt");
        private static readonly HtmlElementProperties _RtcElement = _ContainerElementProperties("rtc");
        private static readonly HtmlElementProperties _RubyElement = _ContainerElementProperties("ruby");
        private static readonly HtmlElementProperties _SElement = _ContainerElementProperties("s");
        private static readonly HtmlElementProperties _SampElement = _ContainerElementProperties("samp");
        private static readonly HtmlElementProperties _ScriptElement = _ContainerElementProperties("script");
        private static readonly HtmlElementProperties _SectionElement = _ContainerElementProperties("section");
        private static readonly HtmlElementProperties _SelectElement = _ContainerElementProperties("select");
        private static readonly HtmlElementProperties _SmallElement = _ContainerElementProperties("small");
        private static readonly HtmlElementProperties _SourceElement = _EmptyElementProperties("source");
        private static readonly HtmlElementProperties _SpanElement = _ContainerElementProperties("span");
        private static readonly HtmlElementProperties _StrongElement = _ContainerElementProperties("strong");
        private static readonly HtmlElementProperties _StyleElement = _ContainerElementProperties("style");
        private static readonly HtmlElementProperties _SubElement = _ContainerElementProperties("sub");
        private static readonly HtmlElementProperties _SupElement = _ContainerElementProperties("sup");
        private static readonly HtmlElementProperties _TableElement = _ContainerElementProperties("table");
        private static readonly HtmlElementProperties _TBodyElement = _ContainerElementProperties("tbody");
        private static readonly HtmlElementProperties _TdElement = _ContainerElementProperties("td");
        private static readonly HtmlElementProperties _TemplateElement = _ContainerElementProperties("template");
        private static readonly HtmlElementProperties _TextareaElement = _ContainerElementProperties("textarea");
        private static readonly HtmlElementProperties _TFootElement = _ContainerElementProperties("tfoot");
        private static readonly HtmlElementProperties _ThElement = _ContainerElementProperties("th");
        private static readonly HtmlElementProperties _THeadElement = _ContainerElementProperties("thead");
        private static readonly HtmlElementProperties _TimeElement = _ContainerElementProperties("time");
        private static readonly HtmlElementProperties _TitleElement = _ContainerElementProperties("title");
        private static readonly HtmlElementProperties _TrElement = _ContainerElementProperties("tr");
        private static readonly HtmlElementProperties _TrackElement = _EmptyElementProperties("track");
        private static readonly HtmlElementProperties _UElement = _ContainerElementProperties("u");
        private static readonly HtmlElementProperties _UlElement = _ContainerElementProperties("ul");
        private static readonly HtmlElementProperties _VarElement = _ContainerElementProperties("var");
        private static readonly HtmlElementProperties _WbrElement = _EmptyElementProperties("wbr");
        private static readonly HtmlElementProperties _VideoElement = _ContainerElementProperties("video");

        private static readonly IDictionary<string, HtmlElementProperties> _ElementFactories = new Dictionary<string, HtmlElementProperties>(StringComparer.OrdinalIgnoreCase)
            {
				{ "a", _AElement },
				{ "abbr", _AbbrElement },
				{ "address", _AddressElement },
				{ "area", _AreaElement },
				{ "article", _ArticleElement },
				{ "aside", _AsideElement },
				{ "audio", _AudioElement },
				{ "b", _BElement },
				{ "base", _BaseElement },
				{ "bdi", _BdiElement },
				{ "bdo", _BdoElement },
				{ "blockquote", _BlockquoteElement },
				{ "body", _BodyElement },
				{ "br", _BrElement },
				{ "button", _ButtonElement },
				{ "canvas", _CanvasElement },
				{ "caption", _CaptionElement },
				{ "cite", _CiteElement },
				{ "code", _CodeElement },
				{ "col", _ColElement },
				{ "colgroup", _ColgroupElement },
				{ "data", _DataElement },
				{ "datalist", _DatalistElement },
				{ "dd", _DdElement },
				{ "del", _DelElement },
				{ "dfn", _DfnElement },
				{ "div", _DivElement },
				{ "dl", _DlElement },
				{ "dt", _DtElement },
				{ "em", _EmElement },
				{ "embed", _EmbedElement },
				{ "fieldset", _FieldsetElement },
				{ "figure", _FigureElement },
				{ "footer", _FooterElement },
				{ "form", _FormElement },
				{ "h1", _H1Element },
				{ "h2", _H2Element },
				{ "h3", _H3Element },
				{ "h4", _H4Element },
				{ "h5", _H5Element },
				{ "h6", _H6Element },
				{ "head", _HeadElement },
				{ "header", _HeaderElement },
				{ "hr", _HrElement },
				{ "html", _HtmlElement },
				{ "i", _IElement },
				{ "iframe", _IframeElement },
				{ "img", _ImgElement },
				{ "input", _InputElement },
				{ "ins", _InsElement },
				{ "kbd", _KbdElement },
				{ "label", _LabelElement },
				{ "legend", _LegendElement },
				{ "li", _LiElement },
				{ "link", _LinkElement },
				{ "main", _MainElement },
				{ "map", _MapElement },
				{ "mark", _MarkElement },
				{ "meta", _MetaElement },
				{ "meter", _MeterElement },
				{ "nav", _NavElement },
				{ "noscript", _NoScriptElement },
				{ "object", _ObjectElement },
				{ "ol", _OlElement },
				{ "optgroup", _OptGroupElement },
				{ "option", _OptionElement },
				{ "output", _OutputElement },
				{ "p", _PElement },
				{ "param", _ParamElement },
				{ "pre", _PreElement },
				{ "progress", _ProgressElement },
				{ "q", _QElement },
				{ "rb", _RbElement },
				{ "rp", _RpElement },
				{ "rt", _RtElement },
				{ "rtc", _RtcElement },
				{ "ruby", _RubyElement },
				{ "s", _SElement },
				{ "samp", _SampElement },
				{ "script", _ScriptElement },
				{ "section", _SectionElement },
				{ "select", _SelectElement },
				{ "small", _SmallElement },
				{ "source", _SourceElement },
				{ "span", _SpanElement },
				{ "strong", _StrongElement },
				{ "style", _StyleElement },
				{ "sub", _SubElement },
				{ "sup", _SupElement },
				{ "table", _TableElement },
				{ "tbody", _TBodyElement },
				{ "td", _TdElement },
				{ "template", _TemplateElement },
				{ "textarea", _TextareaElement },
				{ "tfoot", _TFootElement },
				{ "th", _ThElement },
				{ "thead", _THeadElement },
				{ "time", _TimeElement },
				{ "title", _TitleElement },
				{ "tr", _TrElement },
				{ "track", _TrackElement },
				{ "u", _UElement },
				{ "ul", _UlElement },
				{ "var", _VarElement },
				{ "wbr", _WbrElement },
				{ "video", _VideoElement },
            };
			
        public static IHtmlElement Element(string elementName)
        {
            HtmlElementProperties _elementProperties;
            if (_ElementFactories.TryGetValue(elementName, out _elementProperties))
            {
                return _elementProperties.CreateElement();
            }

            throw Must.Assertion.AssertNever<NotSupportedException>();
        }

        public static IHtmlElement Element(string elementName, bool preferEmpty)
        {
            HtmlElementProperties _elementProperties;
            if (!_ElementFactories.TryGetValue(elementName, out _elementProperties))
            {
                _elementProperties = new HtmlElementProperties(elementName, preferEmpty);
            }

            return _elementProperties.CreateElement();
        }

        public static IHtmlContainerElement aTag(params IHtmlNode[] nodes) => _AElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement abbrTag(params IHtmlNode[] nodes) => _AbbrElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement addressTag(params IHtmlNode[] nodes) => _AddressElement.CreateContainerElement(nodes);
        public static IHtmlElement areaTag(params IHtmlAttribute[] attributes) => _AreaElement.CreateElement(attributes);
        public static IHtmlContainerElement articleTag(params IHtmlNode[] nodes) => _ArticleElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement asideTag(params IHtmlNode[] nodes) => _AsideElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement audioTag(params IHtmlNode[] nodes) => _AudioElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement bTag(params IHtmlNode[] nodes) => _BElement.CreateContainerElement(nodes);
        public static IHtmlElement baseTag(params IHtmlAttribute[] attributes) => _BaseElement.CreateElement(attributes);
        public static IHtmlContainerElement bdiTag(params IHtmlNode[] nodes) => _BdiElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement bdoTag(params IHtmlNode[] nodes) => _BdoElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement blockquoteTag(params IHtmlNode[] nodes) => _BlockquoteElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement bodyTag(params IHtmlNode[] nodes) => _BodyElement.CreateContainerElement(nodes);
        public static IHtmlElement brTag(params IHtmlAttribute[] attributes) => _BrElement.CreateElement(attributes);
        public static IHtmlContainerElement buttonTag(params IHtmlNode[] nodes) => _ButtonElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement canvasTag(params IHtmlNode[] nodes) => _CanvasElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement captionTag(params IHtmlNode[] nodes) => _CaptionElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement citeTag(params IHtmlNode[] nodes) => _CiteElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement codeTag(params IHtmlNode[] nodes) => _CodeElement.CreateContainerElement(nodes);
        public static IHtmlElement colTag(params IHtmlAttribute[] attributes) => _ColElement.CreateElement(attributes);
        public static IHtmlContainerElement colgroupTag(params IHtmlNode[] nodes) => _ColgroupElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement dataTag(params IHtmlNode[] nodes) => _DataElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement datalistTag(params IHtmlNode[] nodes) => _DatalistElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement ddTag(params IHtmlNode[] nodes) => _DdElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement delTag(params IHtmlNode[] nodes) => _DelElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement dfnTag(params IHtmlNode[] nodes) => _DfnElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement divTag(params IHtmlNode[] nodes) => _DivElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement dlTag(params IHtmlNode[] nodes) => _DlElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement dtTag(params IHtmlNode[] nodes) => _DtElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement emTag(params IHtmlNode[] nodes) => _EmElement.CreateContainerElement(nodes);
        public static IHtmlElement embedTag(params IHtmlAttribute[] attributes) => _EmbedElement.CreateElement(attributes);
        public static IHtmlContainerElement fieldsetTag(params IHtmlNode[] nodes) => _FieldsetElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement figureTag(params IHtmlNode[] nodes) => _FigureElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement footerTag(params IHtmlNode[] nodes) => _FooterElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement formTag(params IHtmlNode[] nodes) => _FormElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement h1Tag(params IHtmlNode[] nodes) => _H1Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement h2Tag(params IHtmlNode[] nodes) => _H2Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement h3Tag(params IHtmlNode[] nodes) => _H3Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement h4Tag(params IHtmlNode[] nodes) => _H4Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement h5Tag(params IHtmlNode[] nodes) => _H5Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement h6Tag(params IHtmlNode[] nodes) => _H6Element.CreateContainerElement(nodes);
        public static IHtmlContainerElement headTag(params IHtmlNode[] nodes) => _HeadElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement headerTag(params IHtmlNode[] nodes) => _HeaderElement.CreateContainerElement(nodes);
        public static IHtmlElement hrTag(params IHtmlAttribute[] attributes) => _HrElement.CreateElement(attributes);
        public static IHtmlContainerElement htmlTag(params IHtmlNode[] nodes) => _HtmlElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement iTag(params IHtmlNode[] nodes) => _IElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement iframeTag(params IHtmlNode[] nodes) => _IframeElement.CreateContainerElement(nodes);
        public static IHtmlElement imgTag(params IHtmlAttribute[] attributes) => _ImgElement.CreateElement(attributes);
        public static IHtmlElement inputTag(params IHtmlAttribute[] attributes) => _InputElement.CreateElement(attributes);
        public static IHtmlContainerElement insTag(params IHtmlNode[] nodes) => _InsElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement kbdTag(params IHtmlNode[] nodes) => _KbdElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement labelTag(params IHtmlNode[] nodes) => _LabelElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement legendTag(params IHtmlNode[] nodes) => _LegendElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement liTag(params IHtmlNode[] nodes) => _LiElement.CreateContainerElement(nodes);
        public static IHtmlElement linkTag(params IHtmlAttribute[] attributes) => _LinkElement.CreateElement(attributes);
        public static IHtmlContainerElement mainTag(params IHtmlNode[] nodes) => _MainElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement mapTag(params IHtmlNode[] nodes) => _MapElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement markTag(params IHtmlNode[] nodes) => _MarkElement.CreateContainerElement(nodes);
        public static IHtmlElement metaTag(params IHtmlAttribute[] attributes) => _MetaElement.CreateElement(attributes);
        public static IHtmlContainerElement meterTag(params IHtmlNode[] nodes) => _MeterElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement navTag(params IHtmlNode[] nodes) => _NavElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement noscriptTag(params IHtmlNode[] nodes) => _NoScriptElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement objectTag(params IHtmlNode[] nodes) => _ObjectElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement olTag(params IHtmlNode[] nodes) => _OlElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement optgroupTag(params IHtmlNode[] nodes) => _OptGroupElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement optionTag(params IHtmlNode[] nodes) => _OptionElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement outputTag(params IHtmlNode[] nodes) => _OutputElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement pTag(params IHtmlNode[] nodes) => _PElement.CreateContainerElement(nodes);
        public static IHtmlElement paramTag(params IHtmlAttribute[] attributes) => _ParamElement.CreateElement(attributes);
        public static IHtmlContainerElement preTag(params IHtmlNode[] nodes) => _PreElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement progressTag(params IHtmlNode[] nodes) => _ProgressElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement qTag(params IHtmlNode[] nodes) => _QElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement rbTag(params IHtmlNode[] nodes) => _RbElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement rpTag(params IHtmlNode[] nodes) => _RpElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement rtTag(params IHtmlNode[] nodes) => _RtElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement rtcTag(params IHtmlNode[] nodes) => _RtcElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement rubyTag(params IHtmlNode[] nodes) => _RubyElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement sTag(params IHtmlNode[] nodes) => _SElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement sampTag(params IHtmlNode[] nodes) => _SampElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement scriptTag(params IHtmlNode[] nodes) => _ScriptElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement sectionTag(params IHtmlNode[] nodes) => _SectionElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement selectTag(params IHtmlNode[] nodes) => _SelectElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement smallTag(params IHtmlNode[] nodes) => _SmallElement.CreateContainerElement(nodes);
        public static IHtmlElement sourceTag(params IHtmlAttribute[] attributes) => _SourceElement.CreateElement(attributes);
        public static IHtmlContainerElement spanTag(params IHtmlNode[] nodes) => _SpanElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement strongTag(params IHtmlNode[] nodes) => _StrongElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement styleTag(params IHtmlNode[] nodes) => _StyleElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement subTag(params IHtmlNode[] nodes) => _SubElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement supTag(params IHtmlNode[] nodes) => _SupElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement tableTag(params IHtmlNode[] nodes) => _TableElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement tbodyTag(params IHtmlNode[] nodes) => _TBodyElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement tdTag(params IHtmlNode[] nodes) => _TdElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement templateTag(params IHtmlNode[] nodes) => _TemplateElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement textareaTag(params IHtmlNode[] nodes) => _TextareaElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement tfootTag(params IHtmlNode[] nodes) => _TFootElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement thTag(params IHtmlNode[] nodes) => _ThElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement theadTag(params IHtmlNode[] nodes) => _THeadElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement timeTag(params IHtmlNode[] nodes) => _TimeElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement titleTag(params IHtmlNode[] nodes) => _TitleElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement trTag(params IHtmlNode[] nodes) => _TrElement.CreateContainerElement(nodes);
        public static IHtmlElement trackTag(params IHtmlAttribute[] attributes) => _TrackElement.CreateElement(attributes);
        public static IHtmlContainerElement uTag(params IHtmlNode[] nodes) => _UElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement ulTag(params IHtmlNode[] nodes) => _UlElement.CreateContainerElement(nodes);
        public static IHtmlContainerElement varTag(params IHtmlNode[] nodes) => _VarElement.CreateContainerElement(nodes);
        public static IHtmlElement wbrTag(params IHtmlAttribute[] attributes) => _WbrElement.CreateElement(attributes);
        public static IHtmlContainerElement videoTag(params IHtmlNode[] nodes) => _VideoElement.CreateContainerElement(nodes);
	}
}
