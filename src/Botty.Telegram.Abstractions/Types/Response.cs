namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Response for the Telegram bot API request
    /// </summary>
    /// <typeparam name="TResult">Request result</typeparam>
    public class Response<TResult>
        where TResult : class
    {
        /// <summary>
        /// Is success
        /// </summary>
        public bool Ok { get; }

        /// <summary>
        /// Error description
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Error code
        /// </summary>
        public int? ErrorCode { get; }

        /// <summary>
        /// Result
        /// </summary>
        public TResult? Result { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ok">Is success</param>
        /// <param name="description">Error description</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="result">Result</param>
        public Response(bool ok, string? description = default, int? errorCode = default, TResult? result = default)
        {
            Ok = ok;
            Description = description;
            ErrorCode = errorCode;
            Result = result;
        }
    }
}
