using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;

namespace Nerven.Htmler.Core
{
    public sealed class HtmlTextWriter : IDisposable
    {
        private readonly TextWriter _TextWriter;
        private readonly bool _ReadableMode;
        private bool _IsReadabilityLineOpportunity;

        public HtmlTextWriter(TextWriter textWriter, bool readableMode)
        {
            Must.Assertion
                .AssertArgumentNotNull(textWriter, nameof(textWriter));

            _TextWriter = textWriter;
            _ReadableMode = readableMode;
        }

        public HtmlTextWriter(TextWriter textWriter)
            : this(textWriter, false)
        {
        }

        public void WriteStartDocument()
        {
            _WriteSyntax("<!doctype html>");
            _WriteReadabilityLine();
        }

        public void WriteStartElement(string elementName)
        {
            Must.Assertion
                .AssertArgumentNotNull(elementName, nameof(elementName));

            _WriteReadabilityLineIfTheMomentIsRight();
            _WriteSyntax('<');
            _WriteName(elementName);
        }

        public void WriteAttribute(string attributeName, string value)
        {
            Must.Assertion
                .AssertArgumentNotNull(attributeName, nameof(attributeName));

            _WriteSyntax(' ');

            if (value == null)
            {
                _WriteName(attributeName);
            }
            else
            {
                _TextWriter.Write(new XAttribute(attributeName, value).ToString());
            }
        }

        public void WriteStartElementContent()
        {
            _WriteSyntax('>');
            _MarkReadabilityLineOpportunity();
        }

        public void WriteEndElementContent(string elementName)
        {
            Must.Assertion
                .AssertArgumentNotNull(elementName, nameof(elementName));
            
            _WriteSyntax("</");
            _WriteName(elementName);
        }

        public void WriteEndElement()
        {
            _WriteSyntax('>');
            _WriteReadabilityLine();
        }

        public void WriteEndDocument()
        {
            _TextWriter.WriteLine();
        }

        public void WriteText(string text)
        {
            Must.Assertion
                .AssertArgumentNotNull(text, nameof(text));

            _TextWriter.Write(new XText(text).ToString(SaveOptions.DisableFormatting));
        }

        public void WriteRaw(string raw)
        {
            Must.Assertion
                .AssertArgumentNotNull(raw, nameof(raw));

            _TextWriter.Write(raw);
        }

        public void WriteComment(string comment)
        {
            Must.Assertion
                .AssertArgumentNotNull(comment, nameof(comment));

            _WriteReadabilityLineIfTheMomentIsRight();
            _TextWriter.Write(new XComment(comment).ToString(SaveOptions.DisableFormatting));
            _MarkReadabilityLineOpportunity();
        }

        public void Dispose()
        {
            _TextWriter.Dispose();
        }

        private void _WriteReadabilityLineIfTheMomentIsRight()
        {
            if (_ReadableMode && _IsReadabilityLineOpportunity)
            {
                _TextWriter.WriteLine();
            }
        }

        private void _WriteReadabilityLine()
        {
            if (_ReadableMode)
            {
                _TextWriter.WriteLine();
            }
        }

        private void _MarkReadabilityLineOpportunity()
        {
            _IsReadabilityLineOpportunity = true;
        }

        private void _WriteName(string name)
        {
            _TextWriter.Write(XmlConvert.EncodeLocalName(name));
        }

        private void _WriteSyntax(char syntax)
        {
            _IsReadabilityLineOpportunity = false;
            _TextWriter.Write(syntax);
        }

        private void _WriteSyntax(string syntax)
        {
            _TextWriter.Write(syntax);
        }
    }
}
