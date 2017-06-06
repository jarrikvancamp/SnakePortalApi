using BL.Abstract.Validation;
using DTO.Identity;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete.Validation
{
	public class IdentityValidation : IValidator<IdentityDto>, IAddValidator<IdentityDto>
	{
		public Task<bool> Validate(IdentityDto item)
		{
			return ValidateForAdd(item);
		}

		public Task<bool> ValidateForAdd(IdentityDto item)
		{
			if (item == null) throw new EntityValidationException();

			return ValidateForWrite(item);
		}

		public Task<bool> ValidateForWrite(IdentityDto item)
		{
			if (string.IsNullOrWhiteSpace(item.Username)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(item.Password)) throw new EntityValidationException();

			return Task.FromResult(true);
		}
	}
}
