namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object contains information about one answer option in a poll
    /// </summary>
    public class PollOption
    {
        /// <summary>
        /// Option text, 1-100 characters
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Number of users that voted for this option
        /// </summary>
        public int VoterCount { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Option text</param>
        /// <param name="voterCount">Voter count</param>
        public PollOption(string text, int voterCount)
        {
            Text = text;
            VoterCount = voterCount;
        }
    }
}
