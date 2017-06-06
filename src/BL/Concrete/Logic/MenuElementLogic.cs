using BL.Abstract.Logic;
using DAL.Abstract;
using DTO.Menu;
using Entities.Menu;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete.Logic
{
    public class MenuElementLogic : IMenuElementLogic
    {
        private IRepository<MenuElement> _feedEntryRepository;
        private readonly IObjectMapper _mapper;

        public MenuElementLogic(IRepository<MenuElement> feedEntryRepository, IObjectMapper mapper)
        {
            _feedEntryRepository = feedEntryRepository;
            _mapper = mapper;
        }

        public async Task<IList<MenuElementDto>> GetAll()
        {
            var result = await _feedEntryRepository.GetAllAsync();

            return _mapper.Map(result);
        }
    }
}
