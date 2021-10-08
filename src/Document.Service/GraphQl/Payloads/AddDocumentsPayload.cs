using System;
using System.Collections.Generic;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public record AddDocumentsInput(IEnumerable<AddDocumentInput> Documents);

    public record AddDocumentInput(string OriginalFileName, string Base64File);

    public record UpdateText(Guid DocumentId, string Text);
}