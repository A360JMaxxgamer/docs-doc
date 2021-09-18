using System.Threading.Tasks;
using DocsDoc.Core;

namespace DocsDoc.Files.Service.Services
{
    public interface IFileDocumentService
    {
        Task<Document> SaveDocument(Document document);
    }
}