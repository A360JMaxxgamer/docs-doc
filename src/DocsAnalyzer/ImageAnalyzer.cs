using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tesseract;

[assembly: InternalsVisibleTo("DocsDoc.DocsAnayzer.Test")]
namespace DocsDoc.DocsAnalyzer
{
    internal class ImageAnalyzer : IImageAnalyzer, IDisposable
    {
        private readonly TesseractEngine _tesseractEngine;

        public ImageAnalyzer()
        {
            _tesseractEngine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
        }

        public Task<IDocument> Analyze(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"Image {imagePath} cannot be found.");
            }

            using var img = Pix.LoadFromFile(imagePath);
            using var page = _tesseractEngine.Process(img);
            var text = page.GetText();

            var doc = new Document
            {
                Text = text
            };
            return Task.FromResult<IDocument>(doc);
        }

        public void Dispose()
        {
            _tesseractEngine.Dispose();
        }
    }
}
