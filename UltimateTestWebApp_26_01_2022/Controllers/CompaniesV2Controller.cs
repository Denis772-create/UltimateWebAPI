using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiVersion("2.0")]
    //[Route("api/{v:apiversion}/companies")]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public CompaniesV2Controller(IRepositoryManager repository)=>
            _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges:
                false);
            return Ok(companies);
        }
    }

}
