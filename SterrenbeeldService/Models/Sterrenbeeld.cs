using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterrenbeeldService.Models
{
    public class Sterrenbeeld
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int StartDag { get; set; }
        public int StartMaand { get; set; }
        public int EindDag { get; set; }
        public int EindMaand { get; set; }
    }
}
