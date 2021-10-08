using System;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public record UpdateTextInput(Guid DocumentId, string Text);
}