using System.Threading.Tasks;
using DocsDoc.Core;

namespace DocsDoc.DocsAnalyzer
{
    public interface IImageAnalyzer
    {
        Task<Document> Analyze(string imagePath);
    }
}