using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class FootballResults
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<ResultGoals> Data { get; set; } 
    }

    public class ResultGoals
    {
        public string Competition { get; set; }
        public string Year { get; set; }
        public string round { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string team1goals { get; set; }
        public string team2goals { get; set; }
    }
}
