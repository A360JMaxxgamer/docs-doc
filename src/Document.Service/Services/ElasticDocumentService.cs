using System;
using System.Collections.Generic;
using System.Linq;
using DocsDoc.Core;
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

        public IQueryable<Document> AddDocuments(IEnumerable<string> newDocuments)
        {
            var response = _elastic.Bulk(desc => desc.CreateMany(newDocuments.Select(text => new Document
            {
                Id = Guid.NewGuid(),
                Text = text,
                CreationDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            })));
            return response.Items
                .AsQueryable()
                .Select(item => item.GetResponse<Document>().Source);
        }

        public void DeleteDocuments(IEnumerable<string> ids)
        {
            _elastic.DeleteByQuery<Document>(search => search
                .Query(query => query
                    .Ids(i => i.Values(ids))));
        }

        public IEnumerable<Document> GetDocumentsByText(string queryText)
        {
            return _elastic
                .Search<Document>(search => search
                    .Query(query => query
                        .Match(match => match
                            .Field(field => field.Text)
                            .Query(queryText))))
                .Documents;
        }
    }
}