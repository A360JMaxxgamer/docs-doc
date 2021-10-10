using System;
using System.Linq;
using DocsDoc.Core;
using DocsDoc.Documents.Service.GraphQl.Payloads;
using Nest;

namespace DocsDoc.Documents.Service.GraphQl
{
    public class Mutation
    {
        /// <summary>
        /// Adds a new document for each send content
        /// </summary>
        /// <param name="elasticClient"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public AddDocumentsPayload AddDocuments(IElasticClient elasticClient, AddDocumentsInput input)
        {
            var response = elasticClient.Bulk(desc => desc.CreateMany(input
                .Documents
                .Select(doc => new Document
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    Base64File = doc.Base64File,
                    OriginalFileName = doc.OriginalFileName
                })));
            return new AddDocumentsPayload(response
                .Items
                .Select(entry => entry.GetResponse<Document>().Source)
                .ToList());
        }

        /// <summary>
        /// Updates the text of the specific document
        /// </summary>
        /// <param name="elasticClient"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public UpdateTextPayload UpdateText(IElasticClient elasticClient, UpdateTextInput input)
        {
            var updateResponse = elasticClient.Update<Document, Document>(input.DocumentId, u => u.Doc(new Document
            {
                Text = input.Text
            }));
            return new UpdateTextPayload(updateResponse.Get.Source);
        }
    }
}