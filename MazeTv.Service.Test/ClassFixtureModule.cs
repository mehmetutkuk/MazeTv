using Microsoft.Extensions.DependencyInjection;


namespace MazteTv.Service.Test
{
    public class ClassFixtureModule
    {
        public ServiceProvider ServiceProvider { get; }
        public ClassFixtureModule()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MazeTvConfiguration>(config =>
            {
                return new MazeTvConfiguration("https://api.tvmaze.com");
            });

    
            services.AddHttpClient<IMazeTvService, MazeTvService>((provider, client) =>
            {
                var config = provider.GetService<MazeTvConfiguration>();
                client.BaseAddress = new Uri(config.BaseUrl);
            });

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
