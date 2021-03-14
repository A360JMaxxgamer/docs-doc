using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocsDoc.Documents.Service.Services
{
    internal class ElasticDocumentService : IDocumentService
    {
        private readonly IElasticClient _elastic;

        public ElasticDocumentService(IElasticClient elasticClient)
        {
            _elastic = elasticClient;
        }

        public IQueryable<Document> AddDocuments(IEnumerable<Document> newDocuments)
        {
            var response = _elastic.Bulk(desc => desc.CreateMany(newDocuments));
            return response.Items
                .AsQueryable()
                .Select(item => item.GetResponse<Document>().Source);
        }

        public void DeleteDocuments(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetDocuments(string query)
        {
            throw new NotImplementedException();
        }
    }
}
