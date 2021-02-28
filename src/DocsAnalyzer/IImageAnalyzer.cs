using System.Threading.Tasks;

namespace DocsDoc.DocsAnalyzer
{
    public interface IImageAnalyzer
    {
        Task<IDocument> Analyze(string imagePath);
    }
}