using DocsDoc.DocsAnalyzer;
using Microsoft.Extensions.DependencyInjection;

namespace DocsDoc
{
    public static class AnalyzerServiceCollectionExtension
    {
        public static IServiceCollection AddImageAnalyzers(this IServiceCollection services) => services.AddTransient<IImageAnalyzer, ImageAnalyzer>();
    }
}
