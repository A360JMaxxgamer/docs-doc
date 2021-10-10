﻿using System;
using System.Collections.Generic;
using DocsDoc.Core;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public class AddDocumentsPayload : Payload
    {
        public List<Document> Documents { get; }

        public AddDocumentsPayload(List<Document> documents)
        {
            Documents = documents ?? throw new ArgumentNullException(nameof(documents));
        }
    }
}