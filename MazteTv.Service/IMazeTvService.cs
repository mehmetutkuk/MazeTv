using MazteTv.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service
{
    public interface IMazeTvService
    {
        Task<GetShowsResponse[]?> GetShows(int page, CancellationToken cancellationToken = default);
        Task<GetShowsResponse?> GetEpisodes(int id, CancellationToken cancellationToken = default);
        Task<GetCastResponse[]?> GetCasts(int id, CancellationToken cancellationToken = default);
    }
}
