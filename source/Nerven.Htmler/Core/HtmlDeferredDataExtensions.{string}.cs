using System;
using System.Collections.Generic;
using System.Linq;
using Nerven.Htmler.Fundamentals;

namespace Nerven.Htmler.Core
{
    public static class HtmlDeferredDataExtensions
    {
        public static void UpdateAsUri(
            this IHtmlDeferredData<string> deferredData,
            Func<Uri, Uri> update)
        {
            var _data = deferredData.UseIntermediate(_ConvertToFinal, _ConvertToUri);
            _data.Intermediate = update(_data.Intermediate);
        }

        public static void UpdateAsSpaceSeparatedStringList(
            this IHtmlDeferredData<string> deferredData,
            Func<IReadOnlyList<string>, IEnumerable<string>> update)
        {
            var _data = deferredData.UseIntermediate(_ConvertToFinal, _ConvertToSpaceSeparatedStringList);
            _data.Intermediate = update(_data.Intermediate ?? new List<string>())?.ToList();
        }

        private static string _ConvertToFinal(Uri uri)
        {
            return uri?.ToString();
        }

        private static Uri _ConvertToUri(string s)
        {
            return s == null ? null : new Uri(s, UriKind.RelativeOrAbsolute);
        }

        private static string _ConvertToFinal(IReadOnlyList<string> strings)
        {
            return string.Join(" ", strings);
        }

        private static IReadOnlyList<string> _ConvertToSpaceSeparatedStringList(string s)
        {
            return s?.Split(' ').ToList() ?? new List<string>();
        }
    }
}
