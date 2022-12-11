using MazeTV.Persistence;
using MazeTV.Persistence.Entities;
using MazteTv.Service.Infrastructure;
using MazteTv.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service
{
    public class FetchService : IFetchService
    {
        private readonly IMazeTvService _mazeTvService;
        private readonly AppDbContext _context;
        public FetchService(AppDbContext context, IMazeTvService mazeTvService)
        {
            _context = context;
            _mazeTvService = mazeTvService;
        }

        public async Task FetchShows(CancellationToken cancellationToken = default)
        {
            int maxId = GetMaxId();
            int lastPage = (int)Math.Floor(maxId / 250.0);
            // It should be run on background job. But I'm trying to simplfy the solution. 
            bool state = true;
            while (state)
            {
                try
                {
                    var showresponse = await _mazeTvService.GetShows(lastPage, cancellationToken);
                    if (showresponse != null || !showresponse.Any())
                    {
                        var ids = showresponse.Select(s => s.id).ToList();

                        var exists = _context.Shows.Where(s => ids.Any(x => x.Equals(s.Id))).ToList();

                        var shows = showresponse.Where(s => !exists.Any(x => x.Id.Equals(s.id))).Select(s => new Show { Id = s.id, Name = s.name }).ToList();

                        if (shows.Any())
                        {
                            await _context.Shows.AddRangeAsync(shows, cancellationToken);
                            await _context.SaveChangesAsync(cancellationToken);
                        }

                        lastPage++;
                    }
                    else
                        state = false;
                }
                catch (CustomException ex)
                {

                    state = false;

                }

            }
        }
        private int GetMaxId()
        {
            try
            {
                return _context.Shows.Max(s => s.Id);
            }
            catch
            {
                return 0;
            }


        }

        public async Task FetchCast(CancellationToken cancellationToken = default)
        {
            var showIds = await _context.Shows.Include(s=> s.Cast).Where(s=> !s.Cast.Any()).Select(x => x.Id).ToArrayAsync(cancellationToken);

            var bag = new ConcurrentBag<GetCastResponse[]?>();
            var tasks = showIds.Select(async id =>
            {
                var response = await _mazeTvService.GetCasts(id, cancellationToken);

                response.ToList().ForEach(v => v.ShowId = id);

                bag.Add(response);
            });
            await Task.WhenAll(tasks);

            var map = bag.Select(s => s.Select(x =>
            new ShowPerson
            {
                ShowId = x.ShowId,
                Person = new MazeTV.Persistence.Entities.Person
                {
                    BirthDate = Convert.ToDateTime(x.person.birthday),
                    Name = x.person.name
                }
            })).SelectMany(x => x).ToList();

            await _context.ShowPeople.AddRangeAsync(map, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


            // It should be run on background job. But I'm trying to simplfy the solution. 
        }

    }
}
