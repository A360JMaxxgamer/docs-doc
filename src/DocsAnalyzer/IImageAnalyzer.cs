using System.Threading.Tasks;
using DocsDoc.Core;

namespace DocsDoc.DocsAnalyzer
{
    public interface IImageAnalyzer
    {
        Task<string> Analyze(string imagePath);
    }
}