using System.Threading.Tasks;
using BL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BL.Abstract.Logic;
using DTO.Score;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Snake.Portal.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ScoresController : Controller
    {
        private readonly IScoreLogic _scoreLogic;

        public ScoresController(IScoreLogic scorelogic)
        {
            _scoreLogic = scorelogic;
        }

        ////[Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAllScores()
        {
            var result = await _scoreLogic.GetAllScores();
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("latest/{amount}")]
        public async Task<IActionResult> GetLatest(int amount = 10)
        {
            var result = await _scoreLogic.GetLatestScoresOfTheMonth(amount);
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("latest/{mapId}/{amount}")]
        public async Task<IActionResult> GetLatest(int mapId, int amount = 10)
        {
            var result = await _scoreLogic.GetLatestScoresOfTheMonth(amount, mapId);
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("highscores/{amount}")]
        public async Task<IActionResult> GetTopscores(int amount = 10)
        {
            var result = await _scoreLogic.GetTopscoresOfTheMonth(amount);
            return Ok(result);
        }

        ////[Authorize("read:messages")]
        [HttpGet("highscores/{mapId}/{amount}")]
        public async Task<IActionResult> GetTopscores(int mapId, int amount = 10)
        {
            var result = await _scoreLogic.GetTopscoresOfTheMonth(amount, mapId);
            return Ok(result);
        }

        //[Authorize("create:messages")]
        [HttpPost]
        public async Task<IActionResult> AddScore([FromBody]ScoreDto scoreToAdd)
        {
            var result = await _scoreLogic.AddScore(scoreToAdd);
            return Created("", result);
        }
    }
}