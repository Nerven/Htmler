using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    public sealed class HtmlElementProperties
    {
        public HtmlElementProperties(
            string elementName,
            bool empty)
        {
            ElementName = elementName;
            Empty = empty;
        }

        public string ElementName { get; }

        public bool Empty { get; }

        public IHtmlElement CreateElement(params IHtmlAttribute[] attributes)
        {
            var _element = Empty ? _HtmlElement.Create(this) : _HtmlContainerElement.Create(this);
            _element.Attributes.AddRange(attributes);
            return _element;
        }

        public IHtmlContainerElement CreateContainerElement(params IHtmlNode[] nodes)
        {
            Must.Assertion
                .AssertArgumentNotNull(nodes, nameof(nodes))
                .Assert(!Empty);

            var _element = _HtmlContainerElement.Create(this);
            foreach (var _node in nodes)
            {
                if (_node == null)
                {
                    continue;
                }

                var _attribute = _node as IHtmlAttribute;
                if (_attribute != null)
                {
                    _element.Attributes.Add(_attribute);
                    continue;
                }

                var _childNode = _node as IHtmlChildNode;
                if (_childNode != null)
                {
                    _element.Children.Add(_childNode);
                    continue;
                }

                Must.Assertion
                    .AssertNever();
            }

            return _element;
        }
    }
}
