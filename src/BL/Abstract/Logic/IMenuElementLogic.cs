using DTO.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract.Logic
{
    public interface IMenuElementLogic
    {
        Task<IList<MenuElementDto>> GetAll();
    }
}
