namespace Nerven.Htmler.Build
{
    public sealed class HtmlDocumentProperties
    {
        public IHtmlDocument CreateDocument() => _HtmlDocument.Create(this);
    }
}
