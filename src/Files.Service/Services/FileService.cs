using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DocsDoc.Files.Grpc;
using DocsDoc.Files.Service.Configuration;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace DocsDoc.Files.Service.Services
{
    internal class FileService : UploadService.UploadServiceBase
    {
        private readonly FolderConfiguration _folderConfiguration;
        private readonly ILogger<FileService> _logger;

        public FileService(FolderConfiguration folderConfiguration, ILogger<FileService> logger)
        {
            _folderConfiguration = folderConfiguration ?? throw new ArgumentNullException(nameof(folderConfiguration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public override async Task<UploadComplete> Upload(IAsyncStreamReader<UploadRequest> requestStream,
            ServerCallContext context)
        {
            try
            {
                var fileName = Path.Combine(_folderConfiguration.WorkFolder, $"{Guid.NewGuid()}.tmp");
                await using var file = File.Create(fileName);
                while (await requestStream.MoveNext())
                {
                    var bytes = requestStream
                        .Current
                        .Data
                        .SelectMany(b => b.ToByteArray())
                        .ToArray();
                    file.Write(bytes);
                }

                file.Close();
                return new UploadComplete
                {
                    Success = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Upload failed");
                return new UploadComplete
                {
                    Success = false
                };
            }
        }
    }
}