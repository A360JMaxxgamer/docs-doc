using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DocsDoc.Core;
using Tesseract;

[assembly: InternalsVisibleTo("DocsAnalyzer.Test")]

namespace DocsDoc.DocsAnalyzer
{
    internal class ImageAnalyzer : IImageAnalyzer, IDisposable
    {
        private readonly TesseractEngine _tesseractEngine;

        public ImageAnalyzer()
        {
            _tesseractEngine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
        }

        public void Dispose()
        {
            _tesseractEngine.Dispose();
        }

        public async Task<string> Analyze(Stream fileStream)
        {
            await using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);

            using var img = Pix.LoadFromMemory(memoryStream.ToArray());
            using var page = _tesseractEngine.Process(img);
            var text = page.GetText();

            return text;
        }
    }
}