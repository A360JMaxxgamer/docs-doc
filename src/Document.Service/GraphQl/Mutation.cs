using DocsDoc.Documents.Service.Services;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Mutation
    {
        public IQueryable<Document> AddDocuments([Service] IDocumentService documentService, IEnumerable<Document> newDocuments) =>
            documentService.AddDocuments(newDocuments);

        public bool DeleteDocuments([Service] IDocumentService documentService, IEnumerable<string> documentIds)
        {
            try
            {
                documentService.DeleteDocuments(documentIds);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
