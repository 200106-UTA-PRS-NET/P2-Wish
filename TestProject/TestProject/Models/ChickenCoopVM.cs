using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class ChickenResult
    {
        public string title { get; set; }
        public string platform { get; set; }
    }

    public class ChickenCoopVM
    {
        public string query { get; set; }
        public double executionTime { get; set; }
        public List<ChickenResult> result { get; set; }
        public int countResult { get; set; }
    }
}
