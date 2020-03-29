using CrudDomain.Contracts.Repositories;
using CrudDomain.Contracts.Services;
using CrudDomain.Models;
using CrudDomain.Services.ResultHandling;
using System.Threading.Tasks;

namespace CrudDomain.Services
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository crudRepository;

        public CrudService(ICrudRepository crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        public async Task<IResult<ObjectModel>> Create(ObjectModel objectModel)
        {
            var result = await crudRepository.Create(objectModel);

            return result;
        }

        public async Task<IResult<ObjectModel>> Delete(string variableString)
        {
            var result = await this.crudRepository.Delete(variableString);

            return result;
        }

        public async Task<IResult<ObjectModel>> Read(string variableString)
        {
            var objectModelResult = await crudRepository.Read(variableString);
            
            return objectModelResult;
        }

        public async Task<IResult<ObjectModel>> Update(ObjectModel objectModel)
        {
            var readObject = await crudRepository.Read(objectModel.VariableId);

            if (readObject.ResultType == ResultType.Error)
                return readObject;

            if(readObject.Data != null)
                return new InvalidResult<ObjectModel>("objecto update does not exist");

            var result = await this.crudRepository.Update(objectModel);

            return result;
        }
    }
}
