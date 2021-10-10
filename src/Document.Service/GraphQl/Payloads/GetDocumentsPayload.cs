using System;
using System.Collections.Generic;
using DocsDoc.Core;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public class GetDocumentsPayload : Payload
    {
        public List<Document> Documents { get; }

        public GetDocumentsPayload(List<Document> documents)
        {
            Documents = documents ?? throw new ArgumentNullException(nameof(documents));
        }
    }
}