using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsDoc.Docmuent.Service.Services
{
    internal class DocumentService : IDocumentService
    {
        public IQueryable<Document> AddDocuments(IEnumerable<Document> newDocuments)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocuments(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }
    }
}
