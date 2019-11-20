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

        public Stat()
        {
            RushingYards = 0;
            PassingYards = 0;
            TDs = 0;
            opponent = String.Empty;
            weeknumber = 0;
        }
        public

    }
}