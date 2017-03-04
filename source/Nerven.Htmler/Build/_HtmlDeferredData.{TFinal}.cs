using System;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlDeferredData<TFinal> : IHtmlDeferredData<TFinal, TFinal>
    {
        private readonly Action<IHtmlDeferredData<TFinal>> _SetRef;
        
        private _HtmlDeferredData(Action<IHtmlDeferredData<TFinal>> setRef)
        {
            _SetRef = setRef;
        }

        public static void Create(Action<IHtmlDeferredData<TFinal>> setRef)
        {
            var _deferredData = new _HtmlDeferredData<TFinal>(setRef);
            setRef(_deferredData);
        }

        public TFinal Final { get; set; }

        public TFinal Intermediate
        {
            get { return Final; }
            set { Final = value; }
        }

        public IHtmlDeferredData<TFinal, TIntermediate> UseIntermediate<TIntermediate>(
            Func<TIntermediate, TFinal> convertToFinal,
            Func<TFinal, TIntermediate> convertToIntermediate)
        {
            return new _HtmlDeferredData<TFinal, TIntermediate>(Final, _SetRef, convertToFinal, convertToIntermediate);
        }
    }
}
