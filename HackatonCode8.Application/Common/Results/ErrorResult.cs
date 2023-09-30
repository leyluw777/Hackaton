using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.Common.Results
{
    public record ErrorResult : Result
    {
        public ErrorResult(string message)
            : base(false, message)
        {
        }

        public ErrorResult()
            : base(false)
        {
        }
    }
}
