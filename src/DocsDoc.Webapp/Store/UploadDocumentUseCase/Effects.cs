using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.Exceptions;

namespace DocsDoc.Webapp.Store.UploadDocumentUseCase
{
    public class Effects
    {
        private readonly MinioClient _minioClient;

        public Effects(MinioClient minioClient)
        {
            _minioClient = minioClient ?? throw new ArgumentNullException(nameof(minioClient));
        }

        [EffectMethod]
        public async Task HandleUploadFilesAction(UploadFilesAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new FilesQueuedAction(action.Files.Count()));

            foreach (var browserFile in action.Files)
            {
                var bucketName = "upload";
                var location   = "local";
                var objectName = Guid.NewGuid().ToString();

                try
                {
                    await using var stream = browserFile.OpenReadStream();
                    // Make a bucket on the server, if not already present.
                    var found = await _minioClient.BucketExistsAsync(bucketName);
                    if (!found)
                    {
                        await _minioClient.MakeBucketAsync(bucketName, location);
                    }
                    // Upload a file to bucket.
                    await _minioClient.PutObjectAsync(bucketName, objectName, stream, browserFile.Size);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                dispatcher.Dispatch(new FileUploadedAction());
            }
        }
    }
}