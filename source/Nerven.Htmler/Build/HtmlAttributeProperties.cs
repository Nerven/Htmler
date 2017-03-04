namespace Nerven.Htmler.Build
{
    public sealed class HtmlAttributeProperties
    {
        public HtmlAttributeProperties(
            string attributeName)
        {
            AttributeName = attributeName;
        }

        public string AttributeName { get; }

        public IHtmlAttribute CreateAttribute() => _HtmlAttribute.Create(this);
    }
}
