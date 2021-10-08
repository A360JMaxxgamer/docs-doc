using System.IO;
using System.Threading.Tasks;

namespace DocsDoc.DocsAnalyzer
{
    public interface IImageAnalyzer
    {
        Task<string> Analyze(Stream fileStream);
    }
}