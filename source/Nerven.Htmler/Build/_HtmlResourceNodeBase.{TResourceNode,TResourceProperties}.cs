using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Build
{
    internal abstract class _HtmlResourceNodeBase<TResourceNode, TResourceProperties> : _HtmlOwnedNodeBase<TResourceNode, IHtmlResourceNode, IHtmlSite>, IHtmlResourceNode
        where TResourceNode : IHtmlResourceNode
        where TResourceProperties : class
    {
        private readonly _HtmlAnnotationCollection _Annotations;
        private IReadOnlyList<string> _Name;

        protected _HtmlResourceNodeBase(TResourceProperties resourceProperties, _HtmlResourceNodeBase<TResourceNode, TResourceProperties> cloneFrom)
        {
            Must.Assertion
                .AssertArgumentNotNull(resourceProperties, nameof(resourceProperties));

            ResourceProperties = resourceProperties;

            _Annotations = new _HtmlAnnotationCollection(ChildrensProof, this, cloneFrom?._Annotations);
        }

        public IReadOnlyList<string> Name
        {
            get { return _Name; }
            set { _Name = value == null ? null : new ReadOnlyCollection<string>(new List<string>(value)); }
        }

        string IHtmlNamedNode.Name => _Name == null ? null : string.Join("/", _Name);
        
        public override IHtmlAnnotationCollection Annotations => _Annotations;

        protected TResourceProperties ResourceProperties { get; }

        public abstract Task WriteToStreamAsync(Stream target, CancellationToken cancellationToken = new CancellationToken());

        public IHtmlResourceNode CloneResourceNode() => Clone();

        public override XObject CreateXObject() => null;
    }
}
