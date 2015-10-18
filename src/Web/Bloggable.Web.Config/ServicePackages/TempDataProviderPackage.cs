namespace Bloggable.Web.Config.ServicePackages
{
    using System.Configuration;
    using System.Web.Mvc;

    using BrockAllen.CookieTempData;

    using Harbour.RedisTempData;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    using StackExchange.Redis;

    public class TempDataProviderPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            bool disableCookieTempData;
            if (bool.TryParse(ConfigurationManager.AppSettings["cookieTempData:disable"], out disableCookieTempData) && disableCookieTempData)
            {
                try
                {
                    this.RegisterRedisTempDataProvider(container);
                    return;
                }
                catch (RedisConnectionException)
                {
                    // Failed to connect to Redis DB (it may not be installed)
                    // => fallback to another TempDataProvider
                }
            }

            this.RegisterCookiesTempDataProvider(container);
        }

        private void RegisterRedisTempDataProvider(Container container)
        {
            // You could also use ConfigurationOptions object for Redis connection configuration
            const string ServerName = "localhost";
            const int DatabaseIndex = 0;

            var redisConnectionMultiplexer = ConnectionMultiplexer.Connect(ServerName);
            container.RegisterSingleton(() => redisConnectionMultiplexer);
            container.RegisterPerWebRequest(() => container.GetInstance<ConnectionMultiplexer>().GetDatabase(DatabaseIndex));
            container.RegisterPerWebRequest<ITempDataProvider>(() =>
            {
                var options = new RedisTempDataProviderOptions
                {
                    KeyPrefix = "__TempData",
                    KeySeparator = "/"
                };

                return new RedisTempDataProvider(options, container.GetInstance<IDatabase>());
            });
        }

        private void RegisterCookiesTempDataProvider(Container container)
        {
            container.RegisterPerWebRequest<ITempDataProvider, CookieTempDataProvider>();
        }
    }
}
