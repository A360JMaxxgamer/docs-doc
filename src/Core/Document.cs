using System;

namespace DocsDoc
{
    public class Document
    {
        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Text { get; set; }
    }
}