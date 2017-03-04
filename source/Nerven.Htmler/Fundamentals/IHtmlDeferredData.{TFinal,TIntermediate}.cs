namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlDeferredData<TFinal, TIntermediate> : IHtmlDeferredData<TFinal>
    {
        TIntermediate Intermediate { get; set; }
    }
}
