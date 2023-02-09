namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for getting File
    /// </summary>
    public class GetFileRequest
    {
        /// <summary>
        /// File identifier to get information about
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier to get information about</param>
        public GetFileRequest(string fileId)
        {
            FileId = fileId;
        }
    }
}
