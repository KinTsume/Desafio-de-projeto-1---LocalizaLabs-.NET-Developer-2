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
        public string ImageSrc { get; set; }
        public int Position { get; set; }
        public string Type { get; set; }
        public string Gravity { get; set; }
        public string Inhabitants { get; set; }
        public string Location { get; set; }
        public string About { get; set; }

    }
}
