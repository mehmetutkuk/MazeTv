using MazeTV.Persistence;
using MazteTv.Service;
using Microsoft.EntityFrameworkCore;

namespace MazeTv.Extensions
{
    public static class AppExtensions
    {

        public static async Task Fetch(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope == null)
                return;

            var fetchService = serviceScope.ServiceProvider.GetRequiredService<IFetchService>();

            await fetchService.FetchShows();

            fetchService.FetchCast();


        }

        public static async Task Migration(this IApplicationBuilder app)
        {

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope == null)
                return;

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
