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
	public class BlogPostValidation : IValidator<BlogPostDto>, IAddValidator<BlogPostDto>
	{
		public Task<bool> Validate(BlogPostDto item)
		{
			return ValidateForAdd(item);
		}

		public Task<bool> ValidateForAdd(BlogPostDto item)
		{
			if (item == null) throw new EntityValidationException();
			if (item.Id != 0) throw new EntityValidationException();

			return ValidateForWrite(item);
		}

		public Task<bool> ValidateForWrite(BlogPostDto item)
		{
			if (string.IsNullOrWhiteSpace(item.Message)) throw new EntityValidationException();
			if (string.IsNullOrWhiteSpace(item.Title)) throw new EntityValidationException();
			if (item.UserId == 0) throw new EntityValidationException();
			if (item.CreatedOn.Date != DateTime.Now.Date) throw new EntityValidationException();

			return Task.FromResult(true);
		}
	}
}
