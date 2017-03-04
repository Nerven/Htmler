namespace Nerven.Htmler.Build
{
    public sealed class HtmlTextProperties
    {
        public IHtmlText CreateText() => _HtmlText.Create(this);
    }
}
