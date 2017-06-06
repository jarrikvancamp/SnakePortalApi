using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Posts
{
    public class FeedEntry : Post
    {
        public bool IsRead { get; set; }
    }
}
