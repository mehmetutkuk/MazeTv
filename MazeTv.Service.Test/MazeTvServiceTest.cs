using MazteTv.Service;
using MazteTv.Service.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTv.Service.Test
{
    public class MazeTvServiceTest : IClassFixture<ClassFixtureModule>
    {
        private readonly IMazeTvService tvmazeService;
        public MazeTvServiceTest(ClassFixtureModule fixtureModule)
        {
            tvmazeService = fixtureModule.ServiceProvider.GetService<IMazeTvService>();
        }

        [Fact]
        public async void Get_Shows()
        {
            var result = await tvmazeService.GetShows(1, CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Get_Episodes()
        {
            var result = await tvmazeService.GetEpisodes(1, CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Get_Casts()
        {
            var result = await tvmazeService.GetCasts(1, CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
