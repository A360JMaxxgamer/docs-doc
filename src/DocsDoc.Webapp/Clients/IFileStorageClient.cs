using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace DocsDoc.Webapp.Clients
{
    internal interface IFileStorageClient
    {
        Task<bool> UploadFileAsync(IStream stream, CancellationToken cancellationToken);
    }
}