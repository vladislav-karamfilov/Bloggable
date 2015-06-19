﻿namespace Bloggable.Common.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}