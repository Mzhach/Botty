using System.Text;
using System.Text.Json;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Snake case naming policy
    /// </summary>
    internal class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
    {
        /// <inheritdoc />
        public override string ConvertName(string name)
        {
            var convertedName = new StringBuilder();
            convertedName.Append(char.ToLower(name[0]));

            for (var i = 1; i < name.Length; i++)
            {
                if (char.IsUpper(name[i])) convertedName.Append($"_{char.ToLower(name[i])}");
                else convertedName.Append(name[i]);
            }

            return convertedName.ToString();
        }
    }
}