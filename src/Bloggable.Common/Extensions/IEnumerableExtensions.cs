namespace Bloggable.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => 
            source == null || !source.Any();
    }
}
