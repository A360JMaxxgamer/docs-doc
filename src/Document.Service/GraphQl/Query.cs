using System.Collections.Generic;
using DocsDoc.Core;
using DocsDoc.Documents.Service.Services;
using HotChocolate;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Query
    {
        public IEnumerable<Document> GetDocuments([Service] IDocumentService documentService, string query)
        {
            return documentService.GetDocumentsByText(query);
        }
    }
}