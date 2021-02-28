using DocsDoc.Documents.Service.Services;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Query
    {
        public IEnumerable<Document> GetDocuments([Service] IDocumentService documentService, string query) => documentService.GetDocuments(query);
    }
}
