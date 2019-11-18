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
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper();
        }

        private static HttpClient httpClient;

        public Function()
        {
            httpClient = new HttpClient();
        }

        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {
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
                    
                    if(WeekRequested == null)
                    {
                        return BodyResponse("I did not understand that, please try again", false);
                    }
                }
            }
            else if (intent.Intent.Name.Equals("AMAZON.stopIntent"))
            {
                return BodyResponse("You have now existed the Jalen Hurts Statistics Library", true);
            }
            else
            {
                return BodyResponse("I do not know this, please try again", false);
            }

        }

        private SkillResponse BodyResponse(string outputSpeech,
                bool ShouldEndSession,
                string repromptText = "Just say, tell me week one to hear his statistics against Houston, and so on. To exit, say exit.")
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

        


    }


}
