using System;
using System.Collections.Generic;
using System.Text;

namespace JalenHurtsAlexaStatistics
{
    class Class1
    {
        public int RushingYards { get; set; }
        public int PassingYards { get; set; }
        public int TDs { get; set; }
        public string opponent { get; set; }
        public int weeknumber { get; set; }
        public int Passingyards { get; internal set; }
        public int Rushingyards { get; internal set; }
        public string Opponent { get; internal set; }


        public Class1(int rushing, int passing, int TD, string Opponent, int WkNum)
        {
            RushingYards = rushing;
            PassingYards = passing;
            TDs = TD;
            Opponent = opponent;
            WkNum = weeknumber;
        }


        
    }
}
