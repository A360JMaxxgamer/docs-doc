using System.Collections.Generic;
using System.Linq;
using DocsDoc.Core;

namespace DocsDoc.Documents.Service.Services
{
    public interface IDocumentService
    {
        IQueryable<Document> AddDocuments(IEnumerable<Document> newDocuments);

        IEnumerable<Document> GetDocumentsByText(string query);

        void DeleteDocuments(IEnumerable<string> ids);
    }
}