using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Menu
{
    public class MenuElement : EntityBase 
    {
        public string Label { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
}
