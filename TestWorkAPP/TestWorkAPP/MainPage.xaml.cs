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
using TestWorkAPP.Services;

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

    private void btnChamada_Clicked(object sender, EventArgs e)
    {
        try
        {
            SuporteChamada.CriaChamada("5521981724932", "5521969364042");
        }
        catch (Exception)
        {
            DisplayAlert("Aviso", "Não foi possível fazer a chamada. Tente mais tarde.", "Ok", " ");
        }
        
    }
}

