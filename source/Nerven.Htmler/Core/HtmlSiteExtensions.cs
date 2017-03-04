using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nerven.Assertion;
using Nerven.Assertion.Extensions;

namespace Nerven.Htmler.Core
{
    public static class HtmlSiteExtensions
    {
        public static async Task WriteToDirectory(this IHtmlSite site, string directoryPath, CancellationToken cancellationToken = default(CancellationToken))
        {
            Must.Assertion
                .AssertArgumentNotNull(site, nameof(site))
                .Assert(Directory.Exists(directoryPath));

            foreach (var _resource in site.Resources)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var _filePath = Path.Combine(directoryPath, Path.Combine(_resource.Name.Select(_SanitizePathPart).ToArray()));
                if (!Path.HasExtension(_filePath) && _resource is IHtmlDocumentResource)
                {
                    _filePath = Path.Combine(_filePath, "index.html");
                }

                var _fileDirectoryPath = Path.GetDirectoryName(_filePath);
                if (!Directory.Exists(_fileDirectoryPath))
                {
                    Directory.CreateDirectory(_fileDirectoryPath);
                }

                using (var _fileStream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await _resource.WriteToStreamAsync(_fileStream).ConfigureAwait(false);
                    await _fileStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private static string _SanitizePathPart(string pathPart)
        {
            Must.Assertion
                .AssertArgumentNotNull(pathPart, nameof(pathPart))
                .Assert<ArgumentException>(pathPart.Length != 0);

            var _buffer = new char[pathPart.Length];
            var _index = 0;
            foreach (var _c in pathPart)
            {
                if (char.IsLetterOrDigit(_c) || _c == '-' || _c == '_' || _c == ' ')
                {
                    _buffer[_index++] = _c;
                }
            }

            Must.Assertion
                .Assert<ArgumentException>(_index != 0);

            return _index == pathPart.Length
                ? pathPart
                : new string(_buffer, 0, _index);
        }
    }
}
