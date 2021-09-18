using System;

namespace DocsDoc.Core
{
    public class Document
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public string Text { get; set; }
    }
}