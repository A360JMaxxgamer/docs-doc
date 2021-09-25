using System.Threading.Tasks;
using DocsDoc.Files.Service.GraphQl;

namespace DocsDoc.Files.Service.Services
{
    public interface IFileDocumentService
    {
        Task<IDocumentBase> SaveDocument(string documentContent);
    }
}