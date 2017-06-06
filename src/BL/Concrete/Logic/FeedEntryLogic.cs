using BL.Abstract.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Post;
using DAL.Abstract;
using Mappers;
using Entities.Posts;
using BL.Abstract.Validation;
using BL.Concrete.Validation;

namespace BL.Concrete.Logic
{
    public class FeedEntryLogic : IFeedEntryLogic
    {
        private IRepository<FeedEntry> _feedEntryRepository;
        private readonly IObjectMapper _mapper;
        private readonly IValidator<FeedEntryDto> _feedEntryValidation;
        public FeedEntryLogic(IRepository<FeedEntry> feedEntryRepository, IObjectMapper mapper)
        {
            _feedEntryRepository = feedEntryRepository;
            _mapper = mapper;
            _feedEntryValidation = new FeedEntryValidation();
        }

        public async Task<FeedEntry> Add(FeedEntryDto entry)
        {
            entry.CreatedOn = entry.ModifiedOn = DateTime.Now;
            entry.IsRead = false;
            _feedEntryValidation.Validate(entry);
            var result = await _feedEntryRepository.AddAsync(_mapper.Map(entry));
            return result;
        }

        public async Task<IList<FeedEntryDto>> GetAll()
        {
            var result = await _feedEntryRepository.GetAllAsync();
            return _mapper.Map(result);
        }

        public async Task<FeedEntryDto> GetById(int id)
        {
            var result = await _feedEntryRepository.GetAsync(id);
            return _mapper.Map(result);
        }

        public async Task<FeedEntryDto> ReadEntry(int id)
        {
            var entry = await _feedEntryRepository.GetAsync(id);
            entry.IsRead = true;
            Task.WaitAll();
            var result = await _feedEntryRepository.UpdateAsync(entry, id);

            return _mapper.Map(result);
        }
    }
}
