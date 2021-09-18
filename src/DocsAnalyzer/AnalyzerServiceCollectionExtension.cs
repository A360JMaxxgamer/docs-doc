using Microsoft.Extensions.DependencyInjection;

namespace DocsDoc.DocsAnalyzer
{
    public static class AnalyzerServiceCollectionExtension
    {
        public static IServiceCollection AddImageAnalyzers(this IServiceCollection services)
        {
            return services.AddTransient<IImageAnalyzer, ImageAnalyzer>();
        }
    }
}