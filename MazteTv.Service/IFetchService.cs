using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service
{
    public interface IFetchService
    {
        Task FetchShows(CancellationToken cancellationToken = default);
        Task FetchCast(CancellationToken cancellationToken = default);
    }
}
