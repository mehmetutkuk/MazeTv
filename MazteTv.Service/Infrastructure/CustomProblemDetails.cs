using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service.Infrastructure
{
    public class CustomProblemDetails : ProblemDetails
    {
        public string Message { get; set; }
    }

}
