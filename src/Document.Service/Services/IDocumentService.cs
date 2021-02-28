using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Docmuent.Service.Services
{
    public interface IDocumentService
    {
        IQueryable<Document> AddDocuments(IEnumerable<Document> newDocuments);

        IQueryable<Document> GetDocuments();

        void DeleteDocuments(IEnumerable<string> ids);
    }
}
