using DTO.PortalUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Post
{
    public class PostDtoBase : AuditDtoBase
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
    }
}
