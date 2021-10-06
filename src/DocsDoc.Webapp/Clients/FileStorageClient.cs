using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace DocsDoc.Webapp.Clients
{
    internal class FileStorageClient : IFileStorageClient
    {
        /// <inheritdoc />
        public Task<bool> UploadFileAsync(IStream stream, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}