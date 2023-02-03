using Refit;
using TestWorkAPP.Interface;
using TestWorkAPP.Model;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Vonage.Request;
using Vonage;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;
using Vonage.Common;

namespace TestWorkAPP;

public partial class MainPage : ContentPage
{
    public string[] EVENT_URL { get; private set; }

    public MainPage()
	{
      
        InitializeComponent();

        try
		{
            var produtosHttp = RestService.For<IProdutos>(VarGlobal.stringApi);
            var produtosResult = produtosHttp.GetProdutos();

            ListaProdutos.ItemsSource = produtosResult.Result;
        }
		catch (Exception ex)
		{
            //AppCenter
            Crashes.TrackError(ex);
        }
        
    }

    private void SolicitarContato()
    {
        try
        {
            var creds = Credentials.FromAppIdAndPrivateKeyPath("5ccbb9ca-714c-49fd-a2ec-3797237b47fb", "a473038e");
            var client = new VonageClient(creds);

            var toEndpoint = new PhoneEndpoint() { Number = "5521969364042" };
            var fromEndpoint = new PhoneEndpoint() { Number = "5521969364042" };
            var extraText = "";
            for (var i = 0; i < 50; i++)
                extraText += $"{i} ";
            var talkAction = new TalkAction() { Text = "This is a text to speech call from Vonage " + extraText };
            var ncco = new Ncco(talkAction);

            var command = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco, EventUrl = EVENT_URL };
            var response = client.VoiceClient.CreateCall(command);

        }
        catch (Exception ex)
        {
            //AppCenter
            Crashes.TrackError(ex);
            DisplayAlert("Aviso", "Não foi possível fazer a chamada. Tente mais tarde.", "Ok", " ");
        }

    }

    private void btnChamada_Clicked(object sender, EventArgs e)
    {
        SolicitarContato();
    }
}

