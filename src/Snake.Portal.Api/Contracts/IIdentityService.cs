using DTO.Identity;
using SnakePortal.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Portal.Api.Contracts
{
    public interface IIdentityService
    {
		Task<string> GenerateToken();
		Task<LoginModel> Login(IdentityDto identity);
    }
}
