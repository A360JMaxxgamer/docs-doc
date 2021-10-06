using Fluxor;

namespace DocsDoc.Webapp.Store.UploadDocumentUseCase
{
    public static class Reducer
    {
        [ReducerMethod]
        public static UploadDocumentState ReduceFilesQueuedAction(UploadDocumentState state, FilesQueuedAction action)
        {
            var files = state.FilesToUpload + action.Amount;
            return state with
            {
                FilesToUpload = files,
                Uploading = files > 0
            };
        }

        [ReducerMethod]
        public static UploadDocumentState ReduceFileUploadedAction(UploadDocumentState state, FileUploadedAction _)
        {
            var files = state.FilesToUpload - 1;
            return state with
            {
                FilesToUpload = files,
                Uploading = files > 0
            };
        }
    }
}