using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Abstract;
using DAL.Abstract;
using DTO.PortalUserWithScores;
using Entities.PlayerScore;
using Entities.User;
using Mappers;
using BL.Abstract.Logic;
using DTO.PortalUser;
using System;
using BL.Abstract.Validation;
using BL.Concrete.Validation;
using DTO.Identity;
using System.Linq;
using Snake.Portal.Api.Helpers;
using BL.Enums;
using System.Text;
using SnakePortal.Shared.Models;

namespace BL.Concrete
{
	public class PortalUserLogic : IPortalUserLogic
	{
		private readonly IObjectMapper _mapper;
		private readonly IRepository<PortalUser> _repositoryPortalUser;
		private readonly IRepository<Score> _repositoryScore;
		private readonly IValidator<PortalUserDto> _userValidation;
		private static readonly Random _random = new Random();

		public PortalUserLogic(IObjectMapper mapper,
			IRepository<PortalUser> repositoryPortalUser,
			IRepository<Score> repositoryScore)
		{
			_repositoryScore = repositoryScore;
			_mapper = mapper;
			_repositoryPortalUser = repositoryPortalUser;
			_userValidation = new PortalUserValidation(repositoryPortalUser);
		}

		/// <summary>
		///     This methods retrieves one specific user and converts it to PortalUserDto using the mapper interface
		/// </summary>
		/// <param name="portalUserId"></param>
		/// <param name="detailscores"></param>
		/// <returns>PortalUserWithScoresDto</returns>
		public async Task<PortalUserWithScoresDto> GetSpecificPortalUserWithScores(int portalUserId, bool detailscores)
		{
			var resultUser = await _repositoryPortalUser.GetAsync(portalUserId);

			if (resultUser != null)
				return _mapper.Map(resultUser, detailscores);
			return null;
		}

		/// <summary>
		///     This method produces a list of portal users with their scores in the dto-format.
		///     It uses the method to retrieve one user.
		/// </summary>
		/// <param name="detailscores"></param>
		/// <returns>IList of PortalUserWithScoresDto </returns>
		public async Task<IList<PortalUserWithScoresDto>> GetPortalUsersWithScores(bool detailscores)
		{
			var allUsers = await _repositoryPortalUser.GetAllAsync();
			IList<PortalUserWithScoresDto> resultUsers = new List<PortalUserWithScoresDto>();
			foreach (var portalUser in allUsers)
			{
				var specificPortalUserWithScores = GetSpecificPortalUserWithScores(portalUser.Id, detailscores);
				resultUsers.Add(await specificPortalUserWithScores);
			}
			return resultUsers;
		}

		public async Task<PortalUser> AddPortalUser(PortalUserDto user)
		{
			user.CreatedOn = user.ModifiedOn = DateTime.Now;
			await _userValidation.Validate(user);

			user.Salt = ((List<PortalUserWithScoresDto>)GetPortalUsersWithScores(false).Result).Last().Id + 1;
			var hash = SimpleHash.ComputeHash(user.Password, HashAlgoritms.SHA512, Encoding.ASCII.GetBytes(user.Salt));
			user.Password = hash;

			var portalUser = await _repositoryPortalUser.AddAsync(_mapper.Map(user));
			return portalUser;
		}

		public Task<LoginModel> FindPortalUser(IdentityDto loginDetails)
		{
			var user = _repositoryPortalUser.Find(x => x.UserName == loginDetails.Username);
			if (user != null)
			{
				bool isCorrect = false;
				if (SimpleHash.VerifyHash(loginDetails.Password, HashAlgoritms.SHA512, user.Password))
					isCorrect = true;

				if (isCorrect == true)
				{
					return Task.FromResult(new LoginModel
					{
						IsCorrectLogin = isCorrect,
						UserId = user.Id
					});
				}
			}

			return Task.FromResult(new LoginModel
			{
				IsCorrectLogin = false,
				Token = "Unauthorized",
				UserId = -1
			});
		}
	}
}