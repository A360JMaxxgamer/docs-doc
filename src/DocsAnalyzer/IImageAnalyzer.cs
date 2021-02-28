using System.Threading.Tasks;

namespace DocsDoc.DocsAnalyzer
{
    public interface IImageAnalyzer
    {
        Task<Document> Analyze(string imagePath);
    }
}