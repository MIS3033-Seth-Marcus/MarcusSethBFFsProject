using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalenRealAPI.Models
{
    public class Stats
    {
        public int RushingYards { get; set; }
        public int PassingYards { get; set; }
        public int TDs { get; set; }
        public string opponent { get; set; }
        public int weeknumber { get; set; }
        public int Passingyards { get; internal set; }
        public int Rushingyards { get; internal set; }
        public string Opponent { get; internal set; }

        public Stats()
        {
            RushingYards = 0;
            PassingYards = 0;
            TDs = 0;
            opponent = String.Empty;
            weeknumber = 0;
        }
        public Stats(int rushing, int passing, int TD, string Opponent, int WkNum)
        {
            RushingYards = rushing;
            PassingYards = passing;
            TDs = TD;
            Opponent = opponent;
            WkNum = weeknumber;
        }

    }
}