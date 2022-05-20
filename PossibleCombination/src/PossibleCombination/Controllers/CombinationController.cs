using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using PossibleCombination.API.Controllers;
using PossibleCombination.Domain.IRepositories;
using PossibleCombination.Domain.Models;
using PossibleCombination.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CombinationController : BaseController
    {
        private readonly ICombinationService _combinationService;
        private readonly ICombinationRepository _combinationRepository;

        public CombinationController(ICombinationService combinationService, ICombinationRepository combinationRepository)
        {
            _combinationService = combinationService;
            _combinationRepository = combinationRepository;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] Combination requestModel) 
            => Response(_combinationService.Generate(requestModel), _combinationService.Notifications);

        [HttpGet]
        public Task<IActionResult> GetByRangeDate([FromQuery] DateTime inicialDate, [FromQuery] DateTime finalDane) 
            => Response(_combinationRepository.GetByRangeDate(inicialDate, finalDane), new List<Notification>());
    }
}
