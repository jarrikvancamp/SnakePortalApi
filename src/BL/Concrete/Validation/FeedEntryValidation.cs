using BL.Abstract.Validation;
using DTO.Post;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete.Validation
{
	public class FeedEntryValidation : IValidator<FeedEntryDto>, IAddValidator<FeedEntryDto>
	{
		public Task<bool> Validate(FeedEntryDto item)
		{
			return ValidateForAdd(item);
		}

		public Task<bool> ValidateForAdd(FeedEntryDto item)
		{
			if (item == null) throw new EntityValidationException();
			if (item.Id != 0) throw new EntityValidationException();

			return ValidateForWrite(item);
		}

		public Task<bool> ValidateForWrite(FeedEntryDto item)
		{
			if (string.IsNullOrWhiteSpace(item.Message)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(item.Title)) throw new EntityValidationException();
			if (item.UserId == 0) throw new EntityValidationException();
			if (item.CreatedOn.Date != DateTime.Now.Date) throw new EntityValidationException();
			if (item.IsRead == true) throw new EntityValidationException();

			return Task.FromResult(true);
		}
	}
}
