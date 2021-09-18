using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace DocsDoc.Documents.Service.Services
{
    internal class ElasticDocumentService : IDocumentService
    {
        private readonly IElasticClient _elastic;

        public ElasticDocumentService(IElasticClient elasticClient)
        {
            _elastic = elasticClient;
        }

        public IQueryable<Core.Document> AddDocuments(IEnumerable<Core.Document> newDocuments)
        {
            var response = _elastic.Bulk(desc => desc.CreateMany(newDocuments));
            return response.Items
                .AsQueryable()
                .Select(item => item.GetResponse<Core.Document>().Source);
        }

        public void DeleteDocuments(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Document> GetDocuments(string query)
        {
            throw new NotImplementedException();
        }
    }
}