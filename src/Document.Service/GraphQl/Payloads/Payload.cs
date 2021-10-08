using System;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public class Payload<T>
    {
        public Error[] Errors { get; set; } = Array.Empty<Error>();

        public T? Content { get; set; }
    }
}