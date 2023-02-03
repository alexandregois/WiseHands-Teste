namespace TestWorkAPP;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        AppCenter.Start("android=e503aaff-c61a-4dd7-b819-c9b50a81eae5;" +
                  "uwp=;" +
                  "ios=a25d4f20-aea5-431b-8672-02c087cd1895;" +
                  "macos=;",
                  typeof(Analytics), typeof(Crashes));
    }
}
