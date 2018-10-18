using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARIS1_2
{
    public class Clinic
    {
        public int ID { get; set; }
        public string city { get; set; }
        public int year { get; set; }
        public string specialization { get; set; }
        public int cost { get; set; }
        public int doctors_count { get; set; }
        public bool ready { get; set; }
    }
}
