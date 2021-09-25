using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DocsDoc.DocsAnalyzer.Test
{
    public class ImageAnalyzerTest
    {
        private readonly IImageAnalyzer _analyzer = new ImageAnalyzer();
        private readonly FileInfo _exampleLetter = new(@"./Resources/example-letter.png");

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
    }
}