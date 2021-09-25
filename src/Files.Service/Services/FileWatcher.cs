using System;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;
using DocsDoc.DocsAnalyzer;
using DocsDoc.Files.Service.Configuration;
using Microsoft.Extensions.Logging;

namespace DocsDoc.Files.Service.Services
{
    public class FileWatcher
    {
        private readonly Channel<string> _analyzeChannel;
        private readonly IFileDocumentService _fileDocumentService;
        private readonly IImageAnalyzer _imageAnalyzer;
        private readonly ILogger<FileWatcher> _logger;
        private readonly DirectoryInfo _storageDirectory;

        public FileWatcher(FolderConfiguration folderConfiguration, IImageAnalyzer imageAnalyzer,
            IFileDocumentService fileDocumentService, ILogger<FileWatcher> logger)
        {
            _storageDirectory = new DirectoryInfo(folderConfiguration.StorageFolder);

            var fileWatcher = new FileSystemWatcher(folderConfiguration.WorkFolder);
            fileWatcher.Created += OnFileCreated;
            fileWatcher.EnableRaisingEvents = true;
            _imageAnalyzer = imageAnalyzer;
            _fileDocumentService = fileDocumentService;
            _logger = logger;
            _analyzeChannel = Channel.CreateUnbounded<string>(new UnboundedChannelOptions
            {
                SingleWriter = true,
                SingleReader = true,
                AllowSynchronousContinuations = true
            });
            Task.Run(HandleNewFiles);
        }

        private async void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"New file found: {e.Name}");
            await _analyzeChannel.Writer.WriteAsync(e.FullPath);
        }

        private async Task HandleNewFiles()
        {
            while (await _analyzeChannel.Reader.WaitToReadAsync())
            while (_analyzeChannel.Reader.TryRead(out var path))
                try
                {
                    await Analyze(path);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"An error occured during the analysis of {path}");
                }
        }

        private async Task Analyze(string path)
        {
            var fileInfo = new FileInfo(path);
            _logger.LogInformation($"Start analysis of file: {fileInfo.Name}");
            var document = await _imageAnalyzer.Analyze(fileInfo.FullName);
            _logger.LogInformation($"Save document: {fileInfo.Name}");
            var savedDocument = await _fileDocumentService.SaveDocument(document);
            _logger.LogInformation($"Create file for document: {savedDocument.Id.Value}");
            var outputName = Path.Combine(_storageDirectory.FullName, $"{savedDocument.Id}");
            File.Copy(path, outputName);
            _logger.LogInformation($"Delete input file: {fileInfo.Name}");
            File.Delete(fileInfo.FullName);
        }
    }
}