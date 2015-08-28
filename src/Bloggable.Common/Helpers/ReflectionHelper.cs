namespace Bloggable.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetSubClasses<T>(params Assembly[] assemblies) => 
            assemblies
                .SelectMany(a => a.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(T)) && !type.IsAbstract);
    }
}
