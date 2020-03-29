using CrudDomain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudDomain.Services.ResultHandling
{
    public class CreateResult<T> : IResult<T>
    {
        public CreateResult(T data)
        {
            Data = data;
        }
        public ResultType ResultType => ResultType.Create;

        public List<string> Errors => new List<string>();

        public T Data { get; }

    }
}
