using JalenRealAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JalenRealAPI.Controllers
{
    public class JalenHurtsController : ApiController
    {
        private Dictionary<int, Stats> WeeklyStats;

        public Stats Get(int id)
        {
            Stats s = new Stats();
            return s;
        }

        public JalenHurtsController()
        {
            WeeklyStats = new Dictionary<int, Stats>();

            WeeklyStats.Add(1, new Stats()
            {
                Opponent = "Houston",
                Rushingyards = 176,
                Passingyards = 332,
                TDs=6
            });
            WeeklyStats.Add(2, new Stats()
            {
                Opponent = "South Dakota",
                Rushingyards = 47,
                Passingyards = 259,
                TDs = 3
            });
            WeeklyStats.Add(3, new Stats()
            {
                Opponent = "UCLA",
                Rushingyards = 150,
                Passingyards = 289,
                TDs = 4
            });
            WeeklyStats.Add(4, new Stats()
            {
               
            });
            WeeklyStats.Add(5, new Stats()
            {
                Opponent = "Texas Tech",
                Rushingyards = 70,
                Passingyards = 415,
                TDs = 4
              
            });
            WeeklyStats.Add(6, new Stats()
            {
                Opponent = "Kansas",
                Rushingyards = 56,
                Passingyards = 228,
                TDs = 4
            });
            WeeklyStats.Add(7, new Stats()
            {
                Opponent = "Texas",
                Rushingyards = 131,
                Passingyards =235,
                TDs = 4
            });
            WeeklyStats.Add(8, new Stats()
            {
                Opponent = "West Virginia",
                Rushingyards = 75,
                Passingyards = 316,
                TDs = 5
            });
            WeeklyStats.Add(9, new Stats()
            {
                Opponent = "Kansas State",
                Rushingyards = 96,
                Passingyards = 395,
                TDs = 4
            });
            WeeklyStats.Add(10, new Stats()
            {
                
            });
            WeeklyStats.Add(11, new Stats()
            {
                Opponent = "Iowa State",
                Rushingyards = 68,
                Passingyards = 273,
                TDs = 5
            });
            WeeklyStats.Add(12, new Stats()
            {
                Opponent = "Baylor",
                Rushingyards = 114,
                Passingyards = 297,
                TDs = 4
            });
            WeeklyStats.Add(13, new Stats()
            {
                Opponent = "TCU",
                Rushingyards = 173,
                Passingyards = 145,
                TDs = 4
            });


















        }
    }
}
