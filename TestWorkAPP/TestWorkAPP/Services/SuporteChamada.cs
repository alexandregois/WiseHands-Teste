using Android.Telecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vonage.Request;
using Vonage;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;
using Vonage.Common;
using Microsoft.AppCenter.Crashes;
using Android.App;

namespace TestWorkAPP.Services
{
    public class SuporteChamada
    {
        public static void CriaChamada(string TelDestino, string TelRemetente)
        {
            try
            {

                var VONAGE_API_KEY = "a473038e";
                var VONAGE_API_SECRET = "E40HYPmRY4mYEcpD";

                var client = new VonageClient(new Credentials
                {
                    ApiKey = VONAGE_API_KEY,
                    ApiSecret = VONAGE_API_SECRET
                });

                var toEndpoint = new PhoneEndpoint() { Number = TelDestino };
                var fromEndpoint = new PhoneEndpoint() { Number = TelRemetente };
                var extraText = "";
                for (var i = 0; i < 50; i++)
                    extraText += $"{i} ";
                var talkAction = new TalkAction() { Text = "This is a text to speech call from Vonage " + extraText };
                var ncco = new Ncco(talkAction);

                var call = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco, EventUrl = new[] { "http://www.google.com.br" } };

                var response = client.VoiceClient.CreateCall(call);

                Console.WriteLine(response.Uuid);

            }
            catch (Exception  ex)
            {
               
                //AppCenter
                Crashes.TrackError(ex);

                throw new Exception(ex.Message);
            }
            
        }
    }
}
