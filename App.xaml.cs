using System;
using Xamarin.Forms;
using App3.Views;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App3
{
  //  [XamlCompilation (XamlCompilationOptions.Compile)]    
	public partial class App : Application
	{

        public App ()
		{
			InitializeComponent();
            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
