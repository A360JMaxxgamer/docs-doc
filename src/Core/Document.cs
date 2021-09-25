using System;

namespace DocsDoc.Core
{
    public class Document
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
    }
}