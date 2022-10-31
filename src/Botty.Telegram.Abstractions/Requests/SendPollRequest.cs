using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;
using System;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending poll
    /// </summary>
    public class SendPollRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Poll question, 1-300 characters
        /// </summary>
        public string Question { get; }

        /// <summary>
        /// A JSON-serialized list of answer options, 2-10 strings 1-100 characters each
        /// </summary>
        public string[] Options { get; }

        /// <summary>
        /// Optional. True, if the poll needs to be anonymous, defaults to True
        /// </summary>
        public bool? IsAnonymous { get; set; }

        /// <summary>
        /// Optional. Poll type, defaults to “regular”
        /// </summary>
        public PollType? Type { get; set; }

        /// <summary>
        /// Optional. True, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to False
        /// </summary>
        public bool? AllowsMultipleAnswers { get; set; }

        /// <summary>
        /// Optional. 0-based identifier of the correct answer option, required for polls in quiz mode
        /// </summary>
        public int? CorrectOptionId { get; set; }

        /// <summary>
        /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters with at most 2 line feeds after entities parsing
        /// </summary>
        public string? Explanation { get; set; }

        /// <summary>
        /// Optional. Mode for parsing entities in the explanation
        /// </summary>
        public ParseMode? ExplanationParseMode { get; set; }

        /// <summary>
        /// Optional. A JSON-serialized list of special entities that appear in the poll explanation
        /// </summary>
        public MessageEntity[]? ExplanationEntities { get; set; }

        /// <summary>
        /// Optional. Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with close_date
        /// </summary>
        public int? OpenPeriod { get; set; }

        /// <summary>
        /// Optional. Point in time when the poll will be automatically closed. Must be at least 5 and no more than 600 seconds in the future. Can't be used together with open_period
        /// </summary>
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// Optional. Pass True if the poll needs to be immediately closed. This can be useful for poll preview
        /// </summary>
        public bool? IsClosed { get; set; }

        /// <summary>
        /// Optional. Sends the message silently. Users will receive a notification with no sound
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional. Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional. Pass True if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Optional. Additional interface options
        /// </summary>
        public IReplyMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="question">Question</param>
        /// <param name="options">Answer options</param>
        public SendPollRequest(string chatId, string question, string[] options)
        {
            ChatId = chatId;
            Question = question;
            Options = options;
        }
    }
}
