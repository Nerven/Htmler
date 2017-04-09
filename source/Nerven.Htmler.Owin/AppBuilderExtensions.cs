using System;
using Microsoft.Owin;
using Owin;

namespace Nerven.Htmler.Owin
{
    public static class AppBuilderExtensions
    {
        public static void UseHtmler(this IAppBuilder app, HtmlerOwinConfiguration configuration)
        {
            app.Run(_context => HtmlOwinDriver.ExecuteAsync(configuration, _context));
        }

        public static void UseHtmler(this IAppBuilder app, PathString path, HtmlerOwinConfiguration configuration)
        {
            app.Map(path, _htmlerApp => UseHtmler(_htmlerApp, configuration));
        }

        public static void UseHtmler(this IAppBuilder app, string path, HtmlerOwinConfiguration configuration)
        {
            app.Map(path, _htmlerApp => UseHtmler(_htmlerApp, configuration));
        }

        public static void UseHtmler(this IAppBuilder app, Action<HtmlerOwinConfiguration.Builder> configure)
        {
            var _builder = new HtmlerOwinConfiguration.Builder();
            configure(_builder);
            var _configuration = _builder.Build();

            app.Run(_context => HtmlOwinDriver.ExecuteAsync(_configuration, _context));
        }

        public static void UseHtmler(this IAppBuilder app, PathString path, Action<HtmlerOwinConfiguration.Builder> configure)
        {
            app.Map(path, _htmlerApp => UseHtmler(_htmlerApp, configure));
        }

        public static void UseHtmler(this IAppBuilder app, string path, Action<HtmlerOwinConfiguration.Builder> configure)
        {
            app.Map(path, _htmlerApp => UseHtmler(_htmlerApp, configure));
        }
    }
}
