using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_Bootstrap_5_Template_v2.Areas.Area.Models
{
    public class Barangay
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// In: Code (varhcar)
        /// Out: BarangayCode
        /// </summary>
        public string Code { get; set; }
        public byte Country { get; set; }
        public byte Region { get; set; }
        public byte Province { get; set; }
        public Int16 Municipality { get; set; }
    }
}