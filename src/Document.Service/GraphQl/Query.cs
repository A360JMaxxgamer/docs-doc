using DocsDoc.Docmuent.Service.Services;
using HotChocolate;
using System.Linq;

namespace DocsDoc.Docmuent.Service.GraphQl
{
    public class Query
    {
        public IQueryable<Document> GetDocuments([Service] IDocumentService documentService) => documentService.GetDocuments();
    }
}
