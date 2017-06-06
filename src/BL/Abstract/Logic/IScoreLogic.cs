using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Score;
using Entities.PlayerScore;

namespace BL.Abstract.Logic
{
    public interface IScoreLogic
    {
        Task<List<ScoreDto>> GetAllScores();
        Task<Score> AddScore(ScoreDto score);
        Task<List<ScoreDto>> GetTopScoresOfMap(int mapId);
        Task<List<ScoreDto>> GetTopscoresOfTheMonth(int amount, int mapId);
        Task<List<ScoreDto>> GetLatestScoresOfTheMonth(int amount, int mapId);
        Task<List<ScoreDto>> GetTopscoresOfTheMonth(int amount);
        Task<List<ScoreDto>> GetLatestScoresOfTheMonth(int amount);
    }
}