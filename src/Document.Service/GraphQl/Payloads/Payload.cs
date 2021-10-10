using System.Collections.Generic;

namespace DocsDoc.Documents.Service.GraphQl.Payloads
{
    public abstract class Payload
    {
        public IReadOnlyList<UserError>? Errors { get; }

        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }
    }
}