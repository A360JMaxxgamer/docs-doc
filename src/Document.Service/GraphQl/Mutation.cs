using System;
using System.Collections.Generic;
using System.Linq;
using DocsDoc.Core;
using DocsDoc.Documents.Service.Services;
using HotChocolate;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Mutation
    {
        public IQueryable<Document> AddDocuments([Service] IDocumentService documentService,
            IEnumerable<Document> newDocuments)
        {
            return documentService.AddDocuments(newDocuments);
        }

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