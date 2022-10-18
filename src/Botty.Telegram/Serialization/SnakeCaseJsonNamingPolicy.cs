using System;
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
        public override string ConvertName(string name) => ToSnakeCase(name);

        /// <summary>
        /// Convert to snake case notation
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static string ToSnakeCase(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            var convertedName = new StringBuilder();
            convertedName.Append(char.ToLower(value[0]));

            for (var i = 1; i < value.Length; i++)
            {
                if (char.IsUpper(value[i])) convertedName.Append($"_{char.ToLower(value[i])}");
                else convertedName.Append(value[i]);
            }

            return convertedName.ToString();
        }
    }
}