using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using PossibleCombination.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PossibleCombination.API.Controllers
{
    public class BaseController : Controller
    {
        public async new Task<IActionResult> Response<T>(Task<T> result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    return Ok(new ResponseModel<T>(true, await result));
                }
                catch (Exception) {
                    List<Notification> ret = new() { new Notification("Interno", "Ocorreu um erro interno.") };
                    return BadRequest(new ResponseModel<List<Notification>>(false, ret));
                }
            }
            else
                return BadRequest(new ResponseModel<IEnumerable<Notification>>(false, notifications));
        }
    }
}
