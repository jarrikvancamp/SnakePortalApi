using BL.Abstract.Logic;
using DTO.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Snake.Portal.Api.Contracts;
using Snake.Portal.Api.Helpers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Snake.Portal.Api.Controllers
{
	[Route("api/[controller]")]
	public class IdentitiesController : Controller
	{
		private readonly IIdentityService _identityService;
		public IdentitiesController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody]IdentityDto loginDetails)
		{
			var result = await _identityService.Login(loginDetails);

			return Ok(result);
		}

		/// <summary>
		/// in front use
		/// httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
		/// </summary>
		/// <returns></returns>
		[HttpPost("token")]
		public async Task<IActionResult> GetToken()
		{
			var token = _identityService.GenerateToken();
			return Ok(token);
		}
	}
}

