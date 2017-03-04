using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlSite : _HtmlNodeBase<IHtmlSite>, IHtmlSite
    {
        private readonly HtmlSiteProperties _SiteProperties;
        private readonly _HtmlAnnotationCollection _Annotations;
        private readonly _HtmlResourceNodeCollection _Resources;
        
        private _HtmlSite(HtmlSiteProperties siteProperties, _HtmlSite cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(siteProperties, nameof(siteProperties));

            _SiteProperties = siteProperties;
            
            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
            _Resources = new _HtmlResourceNodeCollection(ChildrensProof, this, cloneFrom?._Resources);
        }
        
        public override IHtmlAnnotationCollection Annotations => _Annotations;

        public IHtmlResourceNodeCollection Resources => _Resources;

        public static IHtmlSite Create(HtmlSiteProperties siteProperties) => new _HtmlSite(siteProperties, null);
        
        public override IHtmlSite Clone() => new _HtmlSite(_SiteProperties, this);

        public IHtmlSite CloneSite() => Clone();

        public override XObject CreateXObject() => null;
    }
}
