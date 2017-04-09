namespace Nerven.Htmler.Build
{
    public sealed class HtmlTextResourceProperties
    {
        public IHtmlTextResource CreateDocumentResource() => _HtmlTextResource.Create(this);
    }
}
