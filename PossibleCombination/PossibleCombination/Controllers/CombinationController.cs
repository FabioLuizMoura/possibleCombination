using Microsoft.AspNetCore.Mvc;
using PossibleCombination.Domain.Models;
using PossibleCombination.Domain.Services.Interfaces;

namespace PossibleCombination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CombinationController : ControllerBase
    {
        private readonly ICombinationService _combinationService;

        public CombinationController(ICombinationService combinationService) 
            => _combinationService = combinationService;

        [HttpPost]
        public IActionResult Post([FromBody] Combination requestModel)
        {
            var result = _combinationService.Generate(requestModel);
            return Ok(result);
        }
    }
}
