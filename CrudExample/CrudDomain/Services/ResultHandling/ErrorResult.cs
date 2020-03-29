using CrudDomain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudDomain.Services.ResultHandling
{
    public class ErrorResult<T> : IResult<T>
    {
        public ResultType ResultType => ResultType.Error;

        public List<string> Errors => new List<string>();

        public T Data => default;
    }
}
