using CrudDomain.Models;
using System.Threading.Tasks;

namespace CrudDomain.Contracts.Services
{
    public interface ICrudService
    {
        Task<IServiceResult<ObjectModel>> Create(ObjectModel objectModel);
        Task<IServiceResult<ObjectModel>> Read(string variableString);
        Task<IServiceResult<ObjectModel>> Update(ObjectModel objectModel);
        Task<IServiceResult<ObjectModel>> Delete(string variableString);
    }
}
