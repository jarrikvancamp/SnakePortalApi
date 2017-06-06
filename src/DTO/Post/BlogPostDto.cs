using DTO.PortalUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Post
{
    public class BlogPostDto : PostDtoBase
    {
       
        public bool IsAllowedToEdit { get; set; }
    }
}
