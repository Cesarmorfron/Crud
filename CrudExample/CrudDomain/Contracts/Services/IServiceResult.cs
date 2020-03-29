using System.Collections.Generic;

namespace CrudDomain.Contracts.Services
{
    public interface IServiceResult<T>
    {
        ResultType ResultType { get; }
        List<string> Errors { get; }
        T Data { get; }
    }
}
