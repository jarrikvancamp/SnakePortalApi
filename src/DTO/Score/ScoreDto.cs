using DTO.PortalUser;
using System;

namespace DTO.Score
{
    public class ScoreDto : AuditDtoBase
    {
        public int PlayerScore { get; set; }
        public int UserId { get; set; }
        public int MapId { get; set; }
    }
}