using System.Collections.Generic;
using System.Linq;

namespace Botty.Telegram.Extensions
{
    /// <summary>
    /// Extensions for IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks enumerable to be empty
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T>? value)
            => value == null || !value.Any();

        /// <summary>
        /// Checks enumerable not to be empty
        /// </summary>
        public static bool IsNotEmpty<T>(this IEnumerable<T>? value)
            => value != null && value.Any();
    }
}
