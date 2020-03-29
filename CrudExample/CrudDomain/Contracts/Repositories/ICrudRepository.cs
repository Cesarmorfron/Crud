using CrudDomain.Models;
using System.Threading.Tasks;

namespace CrudDomain.Contracts.Repositories
{
    public interface ICrudRepository
    {
        Task Create(ObjectModel objectModel);
        Task<ObjectModel> Read(string variableString);
        Task Update(ObjectModel objectModel);
        Task Delete(string variableString);
    }
}
