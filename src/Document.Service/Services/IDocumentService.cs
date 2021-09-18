using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Documents.Service.Services
{
    public interface IDocumentService
    {
        IQueryable<Core.Document> AddDocuments(IEnumerable<Core.Document> newDocuments);

        IEnumerable<Core.Document> GetDocuments(string query);

        void DeleteDocuments(IEnumerable<string> ids);
    }
}