using DTO.Post;
using Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract.Logic
{
    public interface IFeedEntryLogic
    {
        Task<IList<FeedEntryDto>> GetAll();
        Task<FeedEntryDto> GetById(int id);
        Task<FeedEntryDto> ReadEntry(int id);
        Task<FeedEntry> Add(FeedEntryDto entry);
    }
}
