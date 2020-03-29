using CrudDomain.Contracts.Services;
using System.Collections.Generic;

namespace CrudDomain.Services.ResultHandling
{
    public class InvalidResult<T> : IServiceResult<T>
    {
        private readonly string Error;
        public InvalidResult(string error)
        {
            Error = error;
        }
        public ResultType ResultType => ResultType.Invalid;

        public List<string> Errors => new List<string> { "Error " + Error };

        public T Data => default;
    }
}
