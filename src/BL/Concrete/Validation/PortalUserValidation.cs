using BL.Abstract.Validation;
using DAL.Abstract;
using DTO.PortalUser;
using Entities.User;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete.Validation
{
	public class PortalUserValidation : IValidator<PortalUserDto>, IAddValidator<PortalUserDto>
	{
		private readonly IRepository<PortalUser> _portalUserRepository;

		public PortalUserValidation(IRepository<PortalUser> portalUserRepository)
		{
			_portalUserRepository = portalUserRepository;
		}

		public Task<bool> Validate(PortalUserDto user)
		{
			return ValidateForAdd(user);
		}

		public Task<bool> ValidateForAdd(PortalUserDto user)
		{
			if (user == null) throw new EntityValidationException();
			if (user.Id != 0) throw new EntityValidationException();

			return ValidateForWrite(user);
		}

		public async Task<bool> ValidateForWrite(PortalUserDto user)
		{
			if (string.IsNullOrWhiteSpace(user.LastName)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(user.FirstName)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(user.Email)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(user.UserName)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(user.Password)) throw new EntityValidationException();

			var list = await _portalUserRepository.GetAllAsync();
			if (list.Any(x => x.UserName == user.UserName)) throw new EntityValidationException();

			return true;
		}
	}
}
