using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Application.Common.Results
{
    public record SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message)
            : base(data, true, message)
        {
        }

        public SuccessDataResult(T data)
            : base(data, true)
        {
        }

        public SuccessDataResult(string message)
            : base(default, true, message)
        {
        }

        public SuccessDataResult(string request, string V)
            : base(default, true)
        {
        }

        public static implicit operator SuccessDataResult<T>(string v)
        {
            throw new NotImplementedException();
        }
    }

}
