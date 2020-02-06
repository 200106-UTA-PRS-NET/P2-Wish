using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Game
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public int added { get; set; }
    }

    public class RawgResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int games_count { get; set; }
        public string image_background { get; set; }
        public List<Game> games { get; set; }
    }

    public class RawgVM
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<RawgResult> results { get; set; }
    }
}
