using BL.Abstract.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Post;
using DAL.Abstract;
using Entities.Posts;
using Mappers;
using Entities.User;
using DTO.PortalUser;
using BL.Abstract.Validation;
using BL.Concrete.Validation;

namespace BL.Concrete.Logic
{
    public class BlogPostLogic : IBlogPostLogic
    {
        private readonly IObjectMapper _mapper;
        private readonly IRepository<BlogPost> _blogpostRepository;
        private readonly IRepository<PortalUser> _userRepository;
        private readonly IValidator<BlogPostDto> _blogpostValidator;

        public BlogPostLogic(IRepository<BlogPost> blogpostRepository, IRepository<PortalUser> userRepository, IObjectMapper mapper)
        {
            _blogpostRepository = blogpostRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _blogpostValidator = new BlogPostValidation();
        }

        public async Task<BlogPost> Add(BlogPostDto blogpost)
        {
            blogpost.CreatedOn = blogpost.ModifiedOn = DateTime.Now;
            _blogpostValidator.Validate(blogpost);
            var result = await _blogpostRepository.AddAsync(_mapper.Map(blogpost));
            return result;
        }

        public async Task<IList<BlogPostDto>> GetAll()
        {
            var result = await _blogpostRepository.GetAllAsync();
            return _mapper.Map(result);
        }

        public async Task<IList<BlogPostDto>> GetAllFromUser(int userID)
        {
            var result = await _blogpostRepository.FindAllAsync(x => x.UserId == userID);
            return _mapper.Map(result);
        }

        public async Task<BlogPostDto> GetById(int id)
        {
            var result = await _blogpostRepository.GetAsync(id);
            return _mapper.Map(result);
        }
    }
}
