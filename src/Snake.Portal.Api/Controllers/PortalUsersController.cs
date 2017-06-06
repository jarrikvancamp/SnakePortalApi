using System.Threading.Tasks;
using BL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Exceptions;
using BL.Abstract.Logic;
using DTO.PortalUserWithScores;
using DTO.PortalUser;
using Microsoft.AspNetCore.Authorization;

namespace Snake.Portal.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class PortalUsersController : Controller
	{
		private readonly IPortalUserLogic _portalUserWithScoresLogic;

		public PortalUsersController(IPortalUserLogic portalUserWithScoresLogic)
		{
			_portalUserWithScoresLogic = portalUserWithScoresLogic;
		}

		////[Authorize("read:messages")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSpecificPortalUser(int id, bool detailscores = false)
		{
			var result = await _portalUserWithScoresLogic.GetSpecificPortalUserWithScores(id, detailscores);
			if (result == null) return NotFound();
			return Ok(result);
		}

		////[Authorize("read:messages")]
		[HttpGet]
		public async Task<IActionResult> GetPortalUsers(bool detailscores = true)
		{
			var result = await _portalUserWithScoresLogic.GetPortalUsersWithScores(detailscores);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePortalUser([FromBody] PortalUserDto user)
		{

				var result = await _portalUserWithScoresLogic.AddPortalUser(user);

				return Created("", result);
		}
	}
}