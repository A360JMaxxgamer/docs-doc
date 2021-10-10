using DocsDoc.Core;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public class UpdateTextPayload
    {
        public Document? UpdatedDocument { get; }

        public UpdateTextPayload(Document updatedDocument)
        {
            UpdatedDocument = updatedDocument;
        }
    }
}