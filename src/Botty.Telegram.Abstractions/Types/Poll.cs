using Botty.Telegram.Abstractions.Enums;
using System;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object contains information about a poll
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// Unique poll identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Poll question, 1-300 characters
        /// </summary>
        public string Question { get; }

        /// <summary>
        /// Array of poll options
        /// </summary>
        public PollOption[] Options { get; }

        /// <summary>
        /// Total number of users that voted in the poll
        /// </summary>
        public int TotalVoterCount { get; }

        /// <summary>
        /// True, if the poll is closed
        /// </summary>
        public bool IsClosed { get; }

        /// <summary>
        /// True, if the poll is anonymous
        /// </summary>
        public bool IsAnonymous { get; }

        /// <summary>
        /// Poll type
        /// </summary>
        public PollType Type { get; }

        /// <summary>
        /// True, if the poll allows multiple answers
        /// </summary>
        public bool AllowsMultipleAnswers { get; }

        /// <summary>
        /// Optional. 0-based identifier of the correct answer option. Available only for polls in the quiz mode, which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot
        /// </summary>
        public int? CorrectOptionId { get; }

        /// <summary>
        /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters
        /// </summary>
        public string? Explanation { get; }

        /// <summary>
        /// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the explanation
        /// </summary>
        public MessageEntity[]? ExplanationEntities { get; }

        /// <summary>
        /// Optional. Amount of time in seconds the poll will be active after creation
        /// </summary>
        public int? OpenPeriod { get; }

        /// <summary>
        /// Optional. Point in time when the poll will be automatically closed
        /// </summary>
        public DateTime? CloseDate { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Poll identifier</param>
        /// <param name="question">Question</param>
        /// <param name="options">Poll options</param>
        /// <param name="totalVoterCount">Total voter count</param>
        /// <param name="isClosed">Is closed</param>
        /// <param name="isAnonymous">Is anonymous</param>
        /// <param name="type">Poll type</param>
        /// <param name="allowsMultipleAnswers">Allows multiple answers</param>
        /// <param name="correctOptionId">Correct option id</param>
        /// <param name="explanation">Explanation</param>
        /// <param name="explanationEntities">Explanation entities</param>
        /// <param name="openPeriod">Open period</param>
        /// <param name="closeDate">Close date</param>
        public Poll(
            string id,
            string question,
            PollOption[] options,
            int totalVoterCount,
            bool isClosed,
            bool isAnonymous,
            PollType type,
            bool allowsMultipleAnswers,
            int? correctOptionId = default,
            string? explanation = default,
            MessageEntity[]? explanationEntities = default,
            int? openPeriod = default,
            DateTime? closeDate = default)
        {
            Id = id;
            Question = question;
            Options = options;
            TotalVoterCount = totalVoterCount;
            IsClosed = isClosed;
            IsAnonymous = isAnonymous;
            Type = type;
            AllowsMultipleAnswers = allowsMultipleAnswers;
            CorrectOptionId = correctOptionId;
            Explanation = explanation;
            ExplanationEntities = explanationEntities;
            OpenPeriod = openPeriod;
            CloseDate = closeDate;
        }
    }
}
