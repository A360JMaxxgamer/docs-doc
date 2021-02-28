using System;

namespace DocsDoc
{
    public interface IDocument
    {
        string Id { get; set; }

        DateTime CreationDate { get; set; }

        DateTime ModifiedDate { get; set; }

        string Text { get; set; }
    }
}