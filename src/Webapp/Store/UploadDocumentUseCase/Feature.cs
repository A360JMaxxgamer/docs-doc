using Fluxor;

namespace DocsDoc.Webapp.Store.UploadDocumentUseCase
{
    public class Feature : Feature<UploadDocumentState>
    {
        /// <inheritdoc />
        public override string GetName() => "Upload document";

        /// <inheritdoc />
        protected override UploadDocumentState GetInitialState() => new(false, 0);
    }
}