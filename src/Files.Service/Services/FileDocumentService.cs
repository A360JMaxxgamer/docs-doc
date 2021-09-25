using System;
using System.Threading.Tasks;
using DocsDoc.Files.Service.GraphQl;
using StrawberryShake;

namespace DocsDoc.Files.Service.Services
{
    internal class FileDocumentService : IFileDocumentService
    {
        private readonly IDocumentServiceClient _documentServiceClient;

        public FileDocumentService(IDocumentServiceClient documentServiceClient)
        {
            _documentServiceClient = documentServiceClient ?? throw new ArgumentNullException(nameof(documentServiceClient));
        }

        public async Task<IDocumentBase> SaveDocument(string documentContent)
        {
            var operationResult = await _documentServiceClient.AddDoc.ExecuteAsync(new string[] {documentContent});
            operationResult.EnsureNoErrors();
            return operationResult.Data.AddDocuments[0];
        }
    }
}