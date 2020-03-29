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

        public async Task<IServiceResult<ObjectModel>> Create(ObjectModel objectModel)
        {
            await crudRepository.Create(objectModel);

            return new CreateResult<ObjectModel>(objectModel);
        }

        public async Task<IServiceResult<ObjectModel>> Delete(string variableString)
        {
            await this.crudRepository.Delete(variableString);

            return new DeleteResult<ObjectModel>();
        }

        public async Task<IServiceResult<ObjectModel>> Read(string variableString)
        {
            var objectModel = await crudRepository.Read(variableString);
            if (objectModel == null)
                return new NotFoundResult<ObjectModel>();
            
            return new SuccessResult<ObjectModel>(objectModel);
        }

        public async Task<IServiceResult<ObjectModel>> Update(ObjectModel objectModel)
        {
            var readObject = await crudRepository.Read(objectModel.VariableId);

            if(readObject != null)
                return new InvalidResult<ObjectModel>("objecto update does not exist");

            await this.crudRepository.Update(objectModel);

            return new SuccessResult<ObjectModel>(objectModel);
        }
    }
}
