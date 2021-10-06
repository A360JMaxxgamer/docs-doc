using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;

namespace DocsDoc.Webapp.Store.UploadDocumentUseCase
{
    public record UploadFilesAction(IEnumerable<IBrowserFile> Files);

    public record FilesQueuedAction(int Amount);

    public record FileUploadedAction;
}