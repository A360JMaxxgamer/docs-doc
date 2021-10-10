using System;
using System.Collections.Generic;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public record AddDocumentsInput(IEnumerable<AddDocumentInput> Documents);

    public record AddDocumentInput(string OriginalFileName, string Base64File);

    public record UpdateTextInput(Guid DocumentId, string Text);

    public record QueryDocumentsInput(
        List<Guid>? Ids,
        string? OriginaleFileName,
        string? Content);
}