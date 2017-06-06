using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Abstract;
using DAL.Abstract;
using DTO.Score;
using Entities.PlayerScore;
using Mappers;
using BL.Abstract.Logic;
using BL.Concrete.Validation;
using BL.Abstract.Validation;
using System.Linq;
using Entities.User;

namespace BL.Concrete
{
    public class ScoreLogic : IScoreLogic
    {
        private readonly IObjectMapper _mapper;
        private readonly IRepository<Score> _repository;
        private readonly IRepository<PortalUser> _portalUserRepository;
        private IValidator<ScoreDto> _scoreValidation;

        public ScoreLogic(IObjectMapper mapper, IRepository<Score> repository, IRepository<PortalUser> portaluserRepository)
        {
            _repository = repository;
            _portalUserRepository = portaluserRepository;
            _mapper = mapper;
            _scoreValidation = new ScoreValidation();
        }

        public async Task<Score> AddScore(ScoreDto score)
        { 
            score.CreatedOn = DateTime.Now;
            score.ModifiedOn = DateTime.Now;
            _scoreValidation.Validate(score);
            var map = _mapper.Map(score);
            Score result = await _repository.AddAsync(_mapper.Map(score));
            return result;
        }

        public async Task<List<ScoreDto>> GetAllScores()
        {
            var result = _mapper.Map(await _repository.GetAllAsync());
            return result;
        }

        public async Task<List<ScoreDto>> GetTopScoresOfMap(int mapId)
        {
            var result = _mapper.Map(await _repository.GetAllAsync());

            var list = result.Where(x => x.MapId == mapId).OrderByDescending(x => x.PlayerScore).Take(3).ToList();
            return list.ToList();
        }

        public async Task<List<ScoreDto>> GetTopscoresOfTheMonth(int amount)
        {
            var result = _mapper.Map(await _repository.FindAllAsync(x => x.CreatedOn.Month == DateTime.Now.Month));

            var list = result.OrderByDescending(x => x.PlayerScore).Take(amount);

            return list.ToList();
        }
        public async Task<List<ScoreDto>> GetLatestScoresOfTheMonth(int amount)
        {
            var result = _mapper.Map(await _repository.FindAllAsync(x => x.ModifiedOn.Month == DateTime.Now.Month));

            var list = result.OrderByDescending(x => x.ModifiedOn).Take(amount);

            return list.ToList();
        }
        public async Task<List<ScoreDto>> GetLatestScoresOfTheMonth(int amount, int mapId)
        {
            var result = _mapper.Map(await _repository.FindAllAsync(x => x.MapId == mapId && x.ModifiedOn.Month == DateTime.Now.Month));

            var list = result.OrderByDescending(x => x.ModifiedOn).Take(amount);

            return list.ToList();
        }

        public async Task<List<ScoreDto>> GetTopscoresOfTheMonth(int amount, int mapId)
        {
            var result = _mapper.Map(await _repository.FindAllAsync(x => x.MapId == mapId && x.ModifiedOn.Month == DateTime.Now.Month));

            var list = result.OrderByDescending(x => x.PlayerScore).Take(amount);

            return list.ToList();
        }
    }
}