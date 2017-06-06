using BL.Abstract.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Portal.Api.Controllers
{
    public class MenuElementsController : Controller
    {
        private readonly IMenuElementLogic _menuElementLogic;

        public MenuElementsController(IMenuElementLogic menuElementLogic)
        {
            _menuElementLogic = menuElementLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _menuElementLogic.GetAll();
            return Ok(result);
        }
    }
}
