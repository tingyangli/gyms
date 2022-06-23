using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class IndustryModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Distribution_characteristics { get; set; }
        public string Position_characteristics { get; set; }
        public string Terrain_features { get; set; }
        public string Geospatial_relationships { get; set; }
        public string Age { get; set; }
        public string Era { get; set; }
        public string Footprint { get; set; }
        public string Status_quo { get; set; }
        public string Protective_measures { get; set; }
        public string Current_use { get; set; }
        public byte[] Picture { get; set; }
    }
}
