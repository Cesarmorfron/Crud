using CrudDomain.Contracts.Services;
using CrudDomain.Models;
using CrudExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CrudExample.Controllers
{
    [ApiController]
    public class CrudController : Controller
    {
        private readonly ICrudService crudService;

        public CrudController(ICrudService crudService)
        {
            this.crudService = crudService;
        }

        [ResponseType(typeof(ObjectModel))]
        [HttpGet]
        [Route("api/CrudController/{variableId}")]
        public async Task<IActionResult> GetAsync(string variableId)
        {
            var objectModel = await crudService.Read(variableId);

            return FromResult(objectModel);
        }

        [HttpPost]
        [Route("api/CrudController/{variableId}")]
        public async Task<IActionResult> PostAsync([FromBody] ObjectModelPostDTO objectModelDto, string variableId)
        {
            var objectModel = new ObjectModel
            {
                VariableId = variableId,
                VariableBool = objectModelDto.VariableBool,
                VariableInt = objectModelDto.VariableInt,
                VariableString = objectModelDto.VariableString
            };

            var objectService = await crudService.Create(objectModel);

            return FromResult(objectService);
        }

        [HttpPut]
        [Route("api/CrudController/{variableId}")]
        public async Task<IActionResult> PutAsync([FromBody] ObjectModelPostDTO objectModelDto, string variableId)
        {
            var objectModel = new ObjectModel
            {
                VariableId = variableId,
                VariableBool = objectModelDto.VariableBool,
                VariableInt = objectModelDto.VariableInt,
                VariableString = objectModelDto.VariableString
            };

            var objectService = await crudService.Update(objectModel);

            return FromResult(objectService);
        }

        [HttpDelete]
        [Route("api/CrudController")]
        public async Task<IActionResult> DeleteAsync(string variableId)
        {
            var objectService = await crudService.Delete(variableId);
            return FromResult(objectService);
        }

        public ActionResult FromResult<T>(IResult<T> result)
        {
            return result.ResultType switch
            {
                ResultType.Ok => Ok(result.Data),
                ResultType.Create => CreatedAtAction(nameof(GetAsync), new { variableId = (result.Data as ObjectModel).VariableId }, result.Data),
                ResultType.Invalid => BadRequest(result.Errors),
                ResultType.NotFound => NotFound(),
                ResultType.Delete => NoContent(),
                ResultType.Error => throw new ArgumentOutOfRangeException("result", result, "An unhandled result has occurred as a result of a service call."),
                _ => throw new ArgumentOutOfRangeException("result", result, "An unhandled result has occurred as a result of a service call."),
            };
        }
    }
}
