using CrudDomain.Contracts.Services;
using System.Collections.Generic;

namespace CrudDomain.Services.ResultHandling
{
    public class NotFoundResult<T> : IResult<T>
    {
        public ResultType ResultType => ResultType.NotFound;

        public List<string> Errors => new List<string>();

        public T Data => default;
    }
}
