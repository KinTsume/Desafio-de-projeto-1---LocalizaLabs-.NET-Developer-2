using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end
{
    public class Planet
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Position { get; set; }
    }
}
