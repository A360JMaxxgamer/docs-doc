using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Docmuent.Service.Services
{
    public interface IDocumentService
    {
        IQueryable<Document> AddDocuments(IEnumerable<Document> newDocuments);

        IEnumerable<Document> GetDocuments(string query);

        void DeleteDocuments(IEnumerable<string> ids);
    }
}
