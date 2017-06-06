using BL.Abstract.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Identity;
using BL.Abstract.Validation;
using BL.Concrete.Validation;
using DAL.Abstract;
using SnakePortal.Shared.Models;

namespace BL.Concrete.Logic
{
	public class IdentityLogic : IIdentityLogic
	{
		private IValidator<IdentityDto> _identityValidation;
		private IPortalUserLogic _portalUserLogic;

		public IdentityLogic(IPortalUserLogic portalUserLogic)
		{
			_identityValidation = new IdentityValidation();
			_portalUserLogic = portalUserLogic;
		}

		public async Task<LoginModel> Login(IdentityDto loginDetails)
		{
			await _identityValidation.Validate(loginDetails);

			var model = await _portalUserLogic.FindPortalUser(loginDetails);

			if (model != null && model.IsCorrectLogin != false)
			{
				return new LoginModel
				{
					IsCorrectLogin = model.IsCorrectLogin,
					UserId = model.UserId
				};
			}

			return new LoginModel
			{
				IsCorrectLogin = false,
				Token = "Unauthorized",
				UserId = -1
			};
		}
	}
}
