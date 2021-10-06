using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DocsDoc.DocsAnalyzer.Test
{
    public class ImageAnalyzerTest
    {
        private readonly IImageAnalyzer _analyzer;
        private readonly FileInfo _exampleLetter = new(@"./Resources/example-letter.png");

        public ImageAnalyzerTest()
        {
            var services = new ServiceCollection();
            services.AddImageAnalyzers();
            _analyzer = services
                .BuildServiceProvider()
                .GetRequiredService<IImageAnalyzer>();
        }
        
        [Fact]
        public async Task Find_any_text()
        {
            var content = await _analyzer.Analyze(_exampleLetter.FullName);
            
            Assert.NotNull(content);
        }

        [Fact]
        public async Task Throws_FileNotFound_on_invalid_file_path()
        {
            await Assert.ThrowsAsync<FileNotFoundException>(async () => await _analyzer.Analyze("error"));
        }

        [Fact]
        public void Ensure_disposed()
        {
            var exception = Record.Exception(() => ((ImageAnalyzer) _analyzer).Dispose());
            Assert.Null(exception);
        }
    }
}