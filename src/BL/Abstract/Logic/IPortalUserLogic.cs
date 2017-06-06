using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PortalUserWithScores;
using DTO.PortalUser;
using Entities.User;
using DTO.Identity;
using SnakePortal.Shared.Models;

namespace BL.Abstract.Logic
{
	public interface IPortalUserLogic
	{
		Task<PortalUserWithScoresDto> GetSpecificPortalUserWithScores(int portalUserId, bool detailscores);
		Task<IList<PortalUserWithScoresDto>> GetPortalUsersWithScores(bool detailscores);
		Task<PortalUser> AddPortalUser(PortalUserDto user);
		Task<LoginModel> FindPortalUser(IdentityDto loginDetails);
	}
}