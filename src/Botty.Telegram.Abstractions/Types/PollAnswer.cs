namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an answer of a user in a non-anonymous poll
    /// </summary>
    public class PollAnswer
    {
        /// <summary>
        /// Unique poll identifier
        /// </summary>
        public string PollId { get; }

        /// <summary>
        /// The user, who changed the answer to the poll
        /// </summary>
        public User User { get; }

        /// <summary>
        /// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote
        /// </summary>
        public int[] OptionIds { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pollId">Poll identifier</param>
        /// <param name="user">User</param>
        /// <param name="optionIds">Identifiers of answer options</param>
        public PollAnswer(string pollId, User user, int[] optionIds)
        {
            PollId = pollId;
            User = user;
            OptionIds = optionIds;
        }
    }
}
