namespace Nerven.Htmler.Build
{
    public sealed class HtmlCommentProperties
    {
        public IHtmlComment CreateComment() => _HtmlComment.Create(this);
    }
}
