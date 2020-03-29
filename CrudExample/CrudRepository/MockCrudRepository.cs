using CrudDomain.Contracts.Repositories;
using CrudDomain.Models;
using System;

namespace CrudRepository
{
    public class MockCrudRepository : ICrudRepository
    {
        public void Create(ObjectModel objectModel)
        {
            // Create Object 
        }

        public void Delete(string variableString)
        {
            // Delete Object
        }

        public ObjectModel Read(string variableString)
        {
            var objectModel = new ObjectModel
            {
                VariableString = variableString,
                VariableInt = 123,
                VariableBool = true
            };

            return objectModel;
        }

        public void Update(ObjectModel objectModel)
        {
            // Update Object
        }
    }
}
