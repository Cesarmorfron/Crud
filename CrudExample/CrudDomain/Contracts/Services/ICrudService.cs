using CrudDomain.Models;
using System.Threading.Tasks;

namespace CrudDomain.Contracts.Services
{
    public interface ICrudService
    {
        Task<IResult<ObjectModel>> Create(ObjectModel objectModel);
        Task<IResult<ObjectModel>> Read(string variableString);
        Task<IResult<ObjectModel>> Update(ObjectModel objectModel);
        Task<IResult<ObjectModel>> Delete(string variableString);
    }
}
