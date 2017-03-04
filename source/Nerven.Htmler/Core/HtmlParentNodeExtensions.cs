using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nerven.Assertion;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Core
{
    public static class HtmlParentNodeExtensions
    {
        private static readonly Encoding _DefaultEncoding = new UTF8Encoding(false);

        public static void WriteTo(this IHtmlParentNode node, HtmlTextWriter htmlWriter)
        {
            var _stack = new Stack<Tuple<IHtmlNode, bool>>();
            _stack.Push(Tuple.Create<IHtmlNode, bool>(node, false));

            do
            {
                var _record = _stack.Pop();
                var _node = _record.Item1;
                var _isNodeEnd = _record.Item2;

                var _element = _node as IHtmlElement;
                if (_element != null)
                {
                    if (!_isNodeEnd)
                    {
                        htmlWriter.WriteStartElement(_element.Name);

                        foreach (var _attribute in _element.Attributes)
                        {
                            htmlWriter.WriteAttribute(_attribute.Name, _attribute.Value);
                        }

                        var _containerElement = _node as IHtmlContainerElement;
                        if (_containerElement != null)
                        {
                            htmlWriter.WriteStartElementContent();
                            _stack.Push(Tuple.Create(_node, true));

                            foreach (var _child in _containerElement.Children.Reverse())
                            {
                                _stack.Push(Tuple.Create<IHtmlNode, bool>(_child, false));
                            }
                        }
                        else
                        {
                            htmlWriter.WriteEndElement();
                        }
                    }
                    else
                    {
                        htmlWriter.WriteEndElementContent(_element.Name);
                        htmlWriter.WriteEndElement();
                    }

                    continue;
                }
                
                var _text = _node as IHtmlText;
                if (_text != null)
                {
                    if (_text.Value != null)
                    {
                        htmlWriter.WriteText(_text.Value);
                    }

                    continue;
                }

                var _raw = _node as IHtmlRaw;
                if (_raw != null)
                {
                    if (_raw.Value != null)
                    {
                        htmlWriter.WriteRaw(_raw.Value);
                    }

                    continue;
                }

                var _comment = _node as IHtmlComment;
                if (_comment != null)
                {
                    if (_comment.Value != null)
                    {
                        htmlWriter.WriteComment(_comment.Value);
                    }

                    continue;
                }


                var _document = _node as IHtmlDocument;
                if (_document != null)
                {
                    if (!_isNodeEnd)
                    {
                        htmlWriter.WriteStartDocument();
                        _stack.Push(Tuple.Create(_node, true));

                        foreach (var _child in _document.Children.Reverse())
                        {
                            _stack.Push(Tuple.Create<IHtmlNode, bool>(_child, false));
                        }
                    }
                    else
                    {
                        htmlWriter.WriteEndDocument();
                    }

                    continue;
                }

                throw Must.Assertion
                    .AssertNever<NotSupportedException>();
            }
            while (_stack.Count != 0);
        }

        public static void WriteTo(this IHtmlParentNode node, TextWriter textWriter)
        {
            var _htmlWriter = new HtmlTextWriter(textWriter);
            WriteTo(node, _htmlWriter);
        }

        public static void WriteReadableTo(this IHtmlParentNode node, TextWriter textWriter)
        {
            var _htmlWriter = new HtmlTextWriter(textWriter, true);
            WriteTo(node, _htmlWriter);
        }

        public static void WriteToStream(this IHtmlParentNode node, Stream target, Encoding encoding)
        {
            var _streamWriter = new StreamWriter(target, encoding);
            WriteTo(node, _streamWriter);
            _streamWriter.Flush();
        }

        public static void WriteReadableToStream(this IHtmlParentNode node, Stream target, Encoding encoding)
        {
            var _streamWriter = new StreamWriter(target, encoding);
            WriteReadableTo(node, _streamWriter);
            _streamWriter.Flush();
        }

        public static void WriteToStream(this IHtmlParentNode node, Stream target)
        {
            WriteToStream(node, target, _DefaultEncoding);
        }
        
        public static void WriteReadableToStream(this IHtmlParentNode node, Stream target)
        {
            WriteReadableToStream(node, target, _DefaultEncoding);
        }

        public static string WriteToString(this IHtmlParentNode node)
        {
            using (var _stringWriter = new StringWriter())
            {
                WriteTo(node, _stringWriter);

                return _stringWriter.ToString();
            }
        }

        public static string WriteReadableToString(this IHtmlParentNode node)
        {
            using (var _stringWriter = new StringWriter())
            {
                WriteReadableTo(node, _stringWriter);

                return _stringWriter.ToString();
            }
        }
    }
}
