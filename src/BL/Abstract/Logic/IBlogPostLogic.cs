using DTO.Post;
using Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract.Logic
{
    public interface IBlogPostLogic
    {
        Task<IList<BlogPostDto>> GetAll();
        Task<BlogPostDto> GetById(int id);
        Task<BlogPost> Add(BlogPostDto blogpost);
        Task<IList<BlogPostDto>> GetAllFromUser(int userId);
    }
}
