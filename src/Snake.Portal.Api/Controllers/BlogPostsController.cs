using BL.Abstract.Logic;
using DTO.Post;
using Entities.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Portal.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostLogic _blogpostLogic;
        public BlogPostsController(IBlogPostLogic blogpostLogic)
        {
            _blogpostLogic = blogpostLogic;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var result = await _blogpostLogic.GetAll();
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("fromuser/{userId}")]
        public async Task<IActionResult> GetAllBlogPostsFromUser(int userId)
        {
            var result = await _blogpostLogic.GetAllFromUser(userId);
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllScores(int id)
        {
            var result = await _blogpostLogic.GetById(id);
            return Ok(result);
        }

        //[Authorize("create:messages")]
        [HttpPost]
        public async Task<IActionResult> CreatePortalUser([FromBody] BlogPostDto blogpost)
        {
            var result = await _blogpostLogic.Add(blogpost);

            return Created("", result);
        }
    }
}
