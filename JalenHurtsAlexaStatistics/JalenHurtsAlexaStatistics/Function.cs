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

            Dictionary<string, Stats> WeeklyStats = new Dictionary<string, Stats>();
            
            string one = string.Empty;
            string two = string.Empty;
            string three = string.Empty;
            string four = string.Empty;
            string five = string.Empty;
            string six = string.Empty;
            string seven = string.Empty;
            string eight = string.Empty;
            string nine = string.Empty;
            string ten = string.Empty;
            string eleven = string.Empty;
            string twelve = string.Empty;
            string thirteen = string.Empty;

            WeeklyStats.Add(one, new Stats()
            {
                Opponent = "Houston",
                Rushingyards = 176,
                Passingyards = 332,
                TDs = 6
            });
            WeeklyStats.Add(two, new Stats()
            {
                Opponent = "South Dakota",
                Rushingyards = 47,
                Passingyards = 259,
                TDs = 3
            });

            WeeklyStats.Add(three, new Stats()
            {
                Opponent = "UCLA",
                Rushingyards = 150,
                Passingyards = 289,
                TDs = 4
            });

            WeeklyStats.Add(four, new Stats()
            {

            });

            WeeklyStats.Add(five, new Stats()
            {
                Opponent = "Texas Tech",
                Rushingyards = 70,
                Passingyards = 415,
                TDs = 4

            });
            WeeklyStats.Add(six, new Stats()
            {
                Opponent = "Kansas",
                Rushingyards = 56,
                Passingyards = 228,
                TDs = 4
            });
            WeeklyStats.Add(seven, new Stats()
            {
                Opponent = "Texas",
                Rushingyards = 131,
                Passingyards = 235,
                TDs = 4
            });
            WeeklyStats.Add(eight, new Stats()
            {
                Opponent = "West Virginia",
                Rushingyards = 75,
                Passingyards = 316,
                TDs = 5
            });
            WeeklyStats.Add(nine, new Stats()
            {
                Opponent = "Kansas State",
                Rushingyards = 96,
                Passingyards = 395,
                TDs = 4
            });
            WeeklyStats.Add(ten, new Stats()
            {

            });
            WeeklyStats.Add(eleven, new Stats()
            {
                Opponent = "Iowa State",
                Rushingyards = 68,
                Passingyards = 273,
                TDs = 5
            });
            WeeklyStats.Add(twelve, new Stats()
            {
                Opponent = "Baylor",
                Rushingyards = 114,
                Passingyards = 297,
                TDs = 4
            });
            WeeklyStats.Add(thirteen, new Stats()
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
                return BodyResponse("Welcome to the Jalen Hurts Stats Library, please say which week you would like to hear his stats! To exit, say exit.", false);
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

        }



        private SkillResponse BodyResponse(string outputSpeech,
                bool ShouldEndSession,
                string repromptText = "I didn't understand that. Just say, tell me week one to hear his statistics against for his week one game against Houston, and so on.")
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

        public static WeekResponse(SkillRequest input, ILambdaContext context)
        {
            var intent = input.Request as IntentRequest;
            string response;
            var WeekRequested = intent.Intent.Slots["weekNumber"].Value;
            

            if (WeekRequested == "one" || WeekRequested == "two" || WeekRequested == "three" || WeekRequested == "five" || WeekRequested == "six" || WeekRequested == "seven" || WeekRequested == "eight" || WeekRequested == "nine" || WeekRequested == "eleven" || WeekRequested == "twelve" || WeekRequested == "thirteen")
            {
                response = $"In week {WeekRequested}, against {WeeklyStats.Opponent}, Jalen had {WeeklyStats.Passingyards} passing yards, {WeeklyStats.Rushingyards} rushing yards and {WeeklyStats.TDs} Touchdowns.";
            }
            else if ( WeekRequested == "four" || WeekRequested == "ten")
            {
                response = "Jalen did not play this week, Oklahoma had a bye.";
            }

            return response;
        }


    }
    public class Stats
    {

        public int RushingYards { get; set; }
        public int PassingYards { get; set; }
        public int TDs { get; set; }
        public string Opponent { get; set; }
        public int weeknumber { get; set; }
        public int Passingyards { get; internal set; }
        public int Rushingyards { get; internal set; }



    }


}
