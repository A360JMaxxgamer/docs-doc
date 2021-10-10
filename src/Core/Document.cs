using System;

namespace DocsDoc.Core
{
    public record Document
    {
        /// <summary>
        /// The identifier of the document
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// The creation date within the system
        /// </summary>
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Last time the document was modified
        /// </summary>

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// The content of the document
        /// </summary>
        public string Text { get; set; } = string.Empty;
        
        /// <summary>
        /// The original filename with type e.g. test.png
        /// </summary>
        public string OriginalFileName { get; set; } = string.Empty;

        /// <summary>
        /// Base 64 encoded content of the file
        /// </summary>
        public string Base64File { get; set; } = string.Empty;
    }
}