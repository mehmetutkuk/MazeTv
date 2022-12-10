using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service.Infrastructure
{
    public class CustomException : Exception
    {
        public CustomProblemDetails ProblemDetails { get; set; }
        public CustomException(CustomProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }
        public CustomException(string type, string message, string title, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message)
        {
            ProblemDetails = new CustomProblemDetails
            {
                Type = type,
                Detail = message,
                Message = message,
                Title = title,
                Status = (int?)httpStatusCode
            };
        }

        public CustomException(string type, string message, string title, string instance, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message)
        {
            var model = new CustomProblemDetails
            {
                Type = type,
                Detail = message,
                Message = message,
                Title = title,
                Status = (int?)httpStatusCode,
                Instance = instance
            };

            ProblemDetails = model;
        }
    }
}
