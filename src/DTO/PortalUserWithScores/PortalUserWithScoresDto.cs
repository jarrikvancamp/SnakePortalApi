using System;
using System.Collections.Generic;
using DTO.Score;

namespace DTO.PortalUserWithScores
{
    public class PortalUserWithScoresDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalScore { get; set; }
        public List<ScoreDto> Scores { get; set; }
    }
}