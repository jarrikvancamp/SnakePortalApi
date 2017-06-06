using Snake.Portal.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Abstract.Logic;
using DTO.Identity;
using RestSharp;
using Newtonsoft.Json;
using Snake.Portal.Api.Helpers;
using SnakePortal.Shared.Models;

namespace Snake.Portal.Api.Services
{
	public class IdentityService : IIdentityService
	{
		private readonly IIdentityLogic _identityLogic;
		public IdentityService(IIdentityLogic identityLogic)
		{
			_identityLogic = identityLogic;
		}
		public Task<string> GenerateToken()
		{
			var client = new RestClient("https://jvcordina.eu.auth0.com/oauth/token");
			var request = new RestRequest(Method.POST);
			request.AddHeader("content-type", "application/json");
			request.AddParameter("application/json", "{\"client_id\":\"e2Rzq6a2lbWg9qlDTJQm8YVAvi75ep3F\",\"client_secret\":\"-YUaShcnjaVFjYeiK0hHmCIkQuSXKQmzeu-c6YCHrT--F9Qt5dP2lUxoBzSv8M8v\",\"audience\":\"http://localhost:5000/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
			var tokenObject = JsonConvert.DeserializeObject<BearerToken>(response.Content);
			return Task.FromResult("bearer " + tokenObject.access_token);
		}

		public async Task<LoginModel> Login(IdentityDto identity)
		{
			var model = await _identityLogic.Login(identity);

			if (model.IsCorrectLogin == true)
				model.Token = await GenerateToken();

			return model;
		}
	}
}