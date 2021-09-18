using System.IO;
using System.Threading.Tasks;
using DocsDoc.DocsAnalyzer;
using Xunit;

namespace DocsDoc.DocsAnayzer.Test
{
    public class ImageAnalyzerTest
    {
        private readonly IImageAnalyzer _anaylyzer = new ImageAnalyzer();
        private readonly FileInfo _exampleLetter = new(@"./Resources/example-letter.png");

        [Fact]
        public async Task Find_any_text()
        {
            var doc = await _anaylyzer.Analyze(_exampleLetter.FullName);

            Assert.NotNull(doc);
            Assert.NotNull(doc.Text);
        }

        [Fact]
        public async Task Throws_FileNotFound_on_invalid_file_path()
        {
            await Assert.ThrowsAsync<FileNotFoundException>(async () => await _anaylyzer.Analyze("error"));
        }
    }
}