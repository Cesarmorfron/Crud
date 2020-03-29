using CrudDomain.Contracts.Services;
using System.Collections.Generic;

namespace CrudDomain.Services.ResultHandling
{
    public class SuccessResult<T> : IResult<T>
    {
        public SuccessResult(T data) {
            Data = data;
        }

        public ResultType ResultType => ResultType.Ok;

        public List<string> Errors => new List<string>();

        public T Data { get; }
    }
}
