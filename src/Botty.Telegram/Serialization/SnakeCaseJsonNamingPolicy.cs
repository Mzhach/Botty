using Botty.Telegram.Extensions;
using System.Text.Json;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Snake case naming policy
    /// </summary>
    internal class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
    {
        /// <inheritdoc />
        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}