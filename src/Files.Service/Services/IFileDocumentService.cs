using System.Threading.Tasks;

namespace DocsDoc.Files.Service.Services
{
    public interface IFileDocumentService
    {
        Task<Document> SaveDocument(Document document);
    }
}
