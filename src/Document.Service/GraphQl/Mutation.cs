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
        /// <summary>
        /// Adds a new document for each send content
        /// </summary>
        /// <param name="documentService"></param>
        /// <param name="newDocuments">Each entry is a content of a single document</param>
        /// <returns></returns>
        public IQueryable<Document> AddDocuments([Service] IDocumentService documentService,
            IEnumerable<string> newDocuments)
        {
            return documentService.AddDocuments(newDocuments);
        }

        /// <summary>
        /// Deletes documents by their ids
        /// </summary>
        /// <param name="documentService"></param>
        /// <param name="documentIds"></param>
        /// <returns></returns>
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