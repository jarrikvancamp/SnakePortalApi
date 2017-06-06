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
    public class FeedEntriesController : Controller
    {
        private readonly IFeedEntryLogic _feedEntryLogic;
        public FeedEntriesController(IFeedEntryLogic feedEntryLogic)
        {
            _feedEntryLogic = feedEntryLogic;
        }

        ////[Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var result = await _feedEntryLogic.GetAll();
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllScores(int id)
        {
            var result = await _feedEntryLogic.GetById(id);
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpPut("read/{id}")]
        public async Task<IActionResult> ReadFeedEntry(int id)
        {
            var result = await _feedEntryLogic.ReadEntry(id);
            return Ok(result);
        }

        //[Authorize("create:messages")]
        [HttpPost]
        public async Task<IActionResult> CreatePortalUser([FromBody] FeedEntryDto entry)
        {
            var result = await _feedEntryLogic.Add(entry);

            return Created("", result);
        }
    }
}
