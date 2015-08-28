namespace Bloggable.Common.Extensions
{
    using System;

    public static class IServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
            where T : class => serviceProvider.GetService(typeof(T)) as T;
    }
}
