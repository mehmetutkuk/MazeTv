using MazteTv.Service.Test;
using MazteTv.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MazeTv.Service.Test
{
    public class FetchServiceTest : IClassFixture<ClassFixtureModule>
    {
        private readonly IFetchService fetchService;
        public FetchServiceTest(ClassFixtureModule fixtureModule)
        {
            fetchService = fixtureModule.ServiceProvider.GetService<IFetchService>();
        }

        [Fact]
        public async void Get_Shows()
        {
            await fetchService.FetchShows();
            Assert.True(true);
        }

        [Fact]
        public async void Get_Casts()
        {
            await fetchService.FetchCast();
            Assert.True(true);
        }
    }
}
