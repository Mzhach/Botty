using System;
using System.IO;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents the contents of a file to be uploaded
    /// </summary>
    public class InputFile
    {
        /// <summary>
        /// Indentifier of file which has already loaded to Telegram 
        /// </summary>
        public string? FileId { get; }

        /// <summary>
        /// HTTP URL for the file to be sent. Telegram will download and send the file.
        /// 5 MB max size for photos and 20 MB max for other types of content
        /// </summary>
        public Uri? Url { get; }

        /// <summary>
        /// File name
        /// </summary>
        public string? Filename { get; }

        /// <summary>
        /// File content
        /// </summary>
        public Stream? FileContent { get; }

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        public InputFile(string fileId)
        {
            FileId = fileId;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">URL</param>
        public InputFile(Uri url)
        {
            Url = url;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="fileContent">File content</param>
        public InputFile(string filename, Stream fileContent)
        {
            Filename = filename;
            FileContent = fileContent;
        }
    }
}
