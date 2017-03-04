namespace Nerven.Htmler.Build
{
    public sealed class HtmlSiteProperties
    {
        public IHtmlSite CreateSite() => _HtmlSite.Create(this);
    }
}
