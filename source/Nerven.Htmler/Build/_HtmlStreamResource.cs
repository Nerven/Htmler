using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nerven.Htmler.Build
{
    internal sealed class _HtmlStreamResource : _HtmlResourceNodeBase<IHtmlStreamResource, HtmlStreamResourceProperties>, IHtmlStreamResource
    {
        private _HtmlStreamResource(HtmlStreamResourceProperties streamResourceProperties, _HtmlStreamResource cloneFrom)
            : base(streamResourceProperties, cloneFrom)
        {
            MimeType = streamResourceProperties.MimeType;
        }
        
        public Encoding Encoding => null;

        public string MimeType { get; set; }

        public static IHtmlStreamResource Create(HtmlStreamResourceProperties streamResourceProperties) => new _HtmlStreamResource(streamResourceProperties, null);

        public override IHtmlStreamResource Clone() => new _HtmlStreamResource(ResourceProperties, this);

        public IHtmlStreamResource CloneStreamResource() => Clone();

        public override XObject CreateXObject() => throw new NotSupportedException();

        public Task<Stream> GetStreamAsync(CancellationToken cancellationToken)
        {
            return ResourceProperties.GetStreamAsync(cancellationToken);
        }
    }
}
