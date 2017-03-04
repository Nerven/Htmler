namespace Nerven.Htmler.Build
{
    public sealed class HtmlRawProperties
    {
        public IHtmlRaw CreateRaw() => _HtmlRaw.Create(this);
    }
}
