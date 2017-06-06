using Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Posts
{
    public class Post : AuditEntityBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }

        public int UserId { get; set; }
        public virtual PortalUser User { get; set; }
    }
}