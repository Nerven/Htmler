using System;

namespace Nerven.Htmler.Fundamentals
{
    public interface IHtmlDeferredData<TFinal>
    {
        TFinal Final { get; set; }

        IHtmlDeferredData<TFinal, TIntermediate> UseIntermediate<TIntermediate>(
            Func<TIntermediate, TFinal> convertToFinal,
            Func<TFinal, TIntermediate> convertToIntermediate);
    }
}
