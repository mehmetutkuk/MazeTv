using MazeTv.DTOs;
using MazeTV.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MazeTv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly AppDbContext context;

        public ShowsController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public Task<QueryResponse<ShowsDto[]>> Get([FromQuery] RequestModel requestModel)
        {
            var data = context.Shows.Include(x => x.Cast.OrderByDescending(s=> s.Person.BirthDate)).ThenInclude(x => x.Person).Skip(requestModel.Skip).Take(requestModel.Take).Select(s => ShowsDto.Map(s)).ToArray();
            var count = context.Shows.Count();

            return Task.FromResult(new QueryResponse<ShowsDto[]> { Data = data, TotalCount = count });
             
        }
    }
}
