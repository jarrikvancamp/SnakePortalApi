using DTO.Identity;
using SnakePortal.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract.Logic
{
    public interface IIdentityLogic
    {
        Task<LoginModel> Login(IdentityDto loginDetails);
    }
}
