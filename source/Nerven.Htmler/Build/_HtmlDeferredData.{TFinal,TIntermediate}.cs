using System;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlDeferredData<TFinal, TIntermediate> : IHtmlDeferredData<TFinal, TIntermediate>
    {
        private readonly Action<IHtmlDeferredData<TFinal>> _SetRef;
        private readonly Func<TIntermediate, TFinal> _ConvertToFinal;
        private readonly Func<TFinal, TIntermediate> _ConvertToIntermediate;

        private _Side _ValidSide;
        private TFinal _Final;
        private TIntermediate _Intermediate;

        public _HtmlDeferredData(TFinal final, Action<IHtmlDeferredData<TFinal>> setRef, Func<TIntermediate, TFinal> convertToFinal, Func<TFinal, TIntermediate> convertToIntermediate)
        {
            _Final = final;
            _SetRef = setRef;
            _ConvertToFinal = convertToFinal;
            _ConvertToIntermediate = convertToIntermediate;

            _ValidSide = _Side.Final;

            setRef(this);
        }

        private _HtmlDeferredData(TIntermediate intermediate, Action<IHtmlDeferredData<TFinal>> setRef, Func<TIntermediate, TFinal> convertToFinal, Func<TFinal, TIntermediate> convertToIntermediate)
        {
            _Intermediate = intermediate;
            _SetRef = setRef;
            _ConvertToFinal = convertToFinal;
            _ConvertToIntermediate = convertToIntermediate;

            _ValidSide = _Side.Intermediate;

            setRef(this);
        }

        private enum _Side
        {
            Final,
            Intermediate
        }

        public TFinal Final
        {
            get
            {
                if (_ValidSide != _Side.Final)
                {
                    _Final = _ConvertToFinal(_Intermediate);
                    _Intermediate = default(TIntermediate);
                    _ValidSide = _Side.Final;
                }

                return _Final;
            }
            set
            {
                _ValidSide = _Side.Final;
                _Final = value;
            }
        }

        public TIntermediate Intermediate
        {
            get
            {
                if (_ValidSide != _Side.Intermediate)
                {
                    _Intermediate = _ConvertToIntermediate(_Final);
                    _Final = default(TFinal);
                    _ValidSide = _Side.Intermediate;
                }

                return _Intermediate;
            }
            set
            {
                _ValidSide = _Side.Intermediate;
                _Intermediate = value;
            }
        }

        public IHtmlDeferredData<TFinal, TNewIntermediate> UseIntermediate<TNewIntermediate>(
            Func<TNewIntermediate, TFinal> convertToFinal,
            Func<TFinal, TNewIntermediate> convertToIntermediate)
        {
            if (_ValidSide == _Side.Intermediate)
            {
                if (typeof(TNewIntermediate) != typeof(TIntermediate))
                {
                    return new _HtmlDeferredData<TFinal, TNewIntermediate>(Final, _SetRef, convertToFinal, convertToIntermediate);
                }

                if (ReferenceEquals(_ConvertToFinal, convertToFinal) && ReferenceEquals(_ConvertToIntermediate, convertToIntermediate))
                {
                    return (IHtmlDeferredData<TFinal, TNewIntermediate>)(IHtmlDeferredData<TFinal>)this;
                }

                return new _HtmlDeferredData<TFinal, TNewIntermediate>((TNewIntermediate)(object)_Intermediate, _SetRef, convertToFinal, convertToIntermediate);
            }

            return new _HtmlDeferredData<TFinal, TNewIntermediate>(_Final, _SetRef, convertToFinal, convertToIntermediate);
        }
    }
}
