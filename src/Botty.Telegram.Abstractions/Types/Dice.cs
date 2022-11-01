namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an animated emoji that displays a random value
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Emoji on which the dice throw animation is based
        /// </summary>
        public string Emoji { get; }

        /// <summary>
        /// Value of the dice
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="emoji">Emoji</param>
        /// <param name="value">Value of the dice</param>
        public Dice(string emoji, int value)
        {
            Emoji = emoji;
            Value = value;
        }
    }
}
