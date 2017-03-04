namespace Nerven.Htmler.Build
{
    public sealed class HtmlDocumentResourceProperties
    {
        public IHtmlDocumentResource CreateDocumentResource() => _HtmlDocumentResource.Create(this);
    }
}
