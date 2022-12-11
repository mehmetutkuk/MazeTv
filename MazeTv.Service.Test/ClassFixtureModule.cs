using MazeTV.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;


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

            services.AddDbContext<AppDbContext>(opt =>
            {
                var path = Path.Combine("D:\\MazeTv\\MazeTv\\mv.db");
                opt.UseSqlite($"Data Source = {path}");

            }, ServiceLifetime.Transient);
            
            
            services.AddScoped<IFetchService,FetchService>();
            services.AddHttpClient<IMazeTvService, MazeTvService>((provider, client) =>
            {
                var config = provider.GetService<MazeTvConfiguration>();
                client.BaseAddress = new Uri(config.BaseUrl);
            });

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
