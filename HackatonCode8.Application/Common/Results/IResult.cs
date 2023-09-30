using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.Common.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
