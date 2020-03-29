using System.Collections.Generic;

namespace CrudDomain.Contracts.Services
{
    public interface IResult<T>
    {
        ResultType ResultType { get; }
        List<string> Errors { get; }
        T Data { get; }
    }
}
