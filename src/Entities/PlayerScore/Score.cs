using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.User;

namespace Entities.PlayerScore
{
    public class Score : AuditEntityBase
    {
        [ForeignKey("UserId")]
        public virtual PortalUser Player { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public int MapId { get; set; }

        public int PlayerScore { get; set; }
        public int UserId { get; set; }
    }
}