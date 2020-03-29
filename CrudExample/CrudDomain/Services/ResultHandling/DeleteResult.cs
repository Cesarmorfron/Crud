using CrudDomain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudDomain.Services.ResultHandling
{
    public class DeleteResult<T> : IResult<T>
    {
        public ResultType ResultType => ResultType.Delete;

        public List<string> Errors => new List<string>();

        public T Data => default;

    }
}
