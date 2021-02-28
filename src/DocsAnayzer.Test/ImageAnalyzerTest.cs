using DocsDoc.DocsAnalyzer;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DocsDoc.DocsAnayzer.Test
{
    public class ImageAnalyzerTest
    {
        private readonly FileInfo _exampleLetter = new FileInfo(@"./Resources/example-letter.png");
        private readonly IImageAnalyzer _anaylyzer = new ImageAnalyzer();

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
