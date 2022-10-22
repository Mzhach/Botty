using System;
using System.Text;

namespace Botty.Telegram.Extensions
{
    /// <summary>
    /// Extensions for string
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Convert string to snake case notation
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>string in snake case notation</returns>
        public static string ToSnakeCase(this string value)
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
