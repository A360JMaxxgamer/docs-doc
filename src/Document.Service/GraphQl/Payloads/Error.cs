using System;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public record Error(string Message, Exception? Exception);
}