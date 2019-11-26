using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace JalenHurtsAlexaStatistics
{
    public class Function
    {

        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {

            Dictionary<int, Stats> WeeklyStats = new Dictionary<int, Stats>();

            WeeklyStats.Add(1, new Stats()
            {
                Opponent = "Houston",
                Rushingyards = 176,
                Passingyards = 332,
                TDs = 6
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
                Passingyards = 235,
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


            var requestType = input.GetRequestType();
            string outputText = "";

            if (requestType == typeof(LaunchRequest))
            {
                return BodyResponse("Welcome to the Jalen Hurts Stats Library, please say which week you would like to hear his stats!", false);
            }
            else if (requestType == typeof(IntentRequest))
            {
                var intent = input.Request as IntentRequest;
                

                if (intent.Intent.Name.Equals("JalenIntent"))
                {
                    var WeekRequested = intent.Intent.Slots["weekNumber"].Value;

                    if (WeekRequested == null)
                    {
                        return BodyResponse("I did not understand that, please try again", false);
                    }
                }
                else if (intent.Intent.Name.Equals("AMAZON.stopIntent"))
                {
                    return BodyResponse("You have now exited the Jalen Hurts Statistics Library", true);
                }

                
            }

            
            var weeklyStats = await GetStats(WeekRequested)
            

            return BodyResponse("I do not know this, please try again", false);

            

            //NEED TO CONVERT USER RESPONSE INTO INTEGER
            //NEED TO DEVELOP IF STATEMENTS ABOUT USER RESPONSES AND WHAT ALEXA WILL RESPOND BACK

        }



        private SkillResponse BodyResponse(string outputSpeech,
                bool ShouldEndSession,
                string repromptText = "Just say, tell me week one to hear his statistics against for his week one game against Houston, and so on. To exit, say exit.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = ShouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };

            if (repromptText != null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptText } };
            }

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResponse;
        }





        private static HttpClient httpClient;
    }
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



    }


}
