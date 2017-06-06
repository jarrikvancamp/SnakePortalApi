using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Menu
{
    public class MenuElementDto : DtoBase
    {
        public string Label { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
}
