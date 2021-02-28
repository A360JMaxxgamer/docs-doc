using DocsDoc.Docmuent.Service.Services;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Docmuent.Service.GraphQl
{
    public class Query
    {
        public IEnumerable<Document> GetDocuments([Service] IDocumentService documentService, string query) => documentService.GetDocuments(query);
    }
}
