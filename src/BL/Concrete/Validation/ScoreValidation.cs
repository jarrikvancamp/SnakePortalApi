using BL.Abstract.Validation;
using DTO.Score;
using Exceptions;
using System.Threading.Tasks;

namespace BL.Concrete.Validation
{
	public class ScoreValidation : IValidator<ScoreDto>, IAddValidator<ScoreDto>
	{
		public Task<bool> Validate(ScoreDto score)
		{
			return ValidateForAdd(score);
		}

		public Task<bool> ValidateForAdd(ScoreDto score)
		{
			if (score == null) throw new EntityValidationException();
			if (score.Id != 0) throw new EntityValidationException();

			return ValidateForWrite(score);
		}

		public Task<bool> ValidateForWrite(ScoreDto score)
		{
			if (score.UserId <= 0) throw new EntityValidationException();
			if (score.PlayerScore < 0) throw new EntityValidationException();

			return Task.FromResult(true);
		}
	}
}
