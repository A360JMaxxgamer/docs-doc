using System.Linq;
using DocsDoc.Core;
using DocsDoc.Documents.Service.GraphQl.Payloads;
using Nest;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Query
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elasticClient"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public GetDocumentsPayload GetDocuments(IElasticClient elasticClient, QueryDocumentsInput input)
        {
            var searchDescriptor = new SearchDescriptor<Document>();

            if (input.Ids is not null)
                searchDescriptor
                    .Query(q => q.Ids(desc => desc.Values(input.Ids)));

            if (input.OriginaleFileName is not null)
                searchDescriptor
                    .Query(q => q
                        .Match(desc => desc
                            .Field(f => f.OriginalFileName)
                            .Query(input.OriginaleFileName)));

            if (input.Content is not null)
                searchDescriptor
                    .Query(q => q
                        .Match(desc => desc
                            .Field(f => f.OriginalFileName)
                            .Query(input.Content)));

            var searchResult = elasticClient
                .Search<Document>(searchDescriptor)
                .Documents
                .ToList();

            return new GetDocumentsPayload(searchResult);
        }
    }
}