using CrudDomain.Contracts.Repositories;
using CrudDomain.Contracts.Services;
using CrudDomain.Models;
using CrudDomain.Services.ResultHandling;
using System;
using System.Threading.Tasks;

namespace CrudRepository
{
    public class MockCrudRepository : ICrudRepository
    {
        public async Task<IResult<ObjectModel>> Create(ObjectModel objectModel)
        {
            try
            {
                return new CreateResult<ObjectModel>(objectModel);
            }
            catch (ArgumentException ex)
            {
                return new ErrorResult<ObjectModel>();
            }
        }

        public async Task<IResult<ObjectModel>> Delete(string variableString)
        {
            return new DeleteResult<ObjectModel>();

        }

        public async Task<IResult<ObjectModel>> Read(string variableId)
        {
            try
            {
                var objectModel = new ObjectModel
                {
                    VariableString = "string",
                    VariableInt = 123,
                    VariableBool = true,
                    VariableId = variableId
                };

                return new SuccessResult<ObjectModel>(null);
            }
            catch (FormatException ex)
            {
                return new ErrorResult<ObjectModel>();
            }

        }

        public async Task<IResult<ObjectModel>> Update(ObjectModel objectModel)
        {
            var objectM = new ObjectModel
            {
                VariableString = "string",
                VariableInt = 123,
                VariableBool = true,
                VariableId = "string"
            };

            return new SuccessResult<ObjectModel>(objectM);
         
        }

    }
}
