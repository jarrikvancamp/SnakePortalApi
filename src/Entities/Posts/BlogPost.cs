using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Posts
{
    public class BlogPost : Post
    {
        public bool IsAllowedToEdit { get; set; }
    }
}
