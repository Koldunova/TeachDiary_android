using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
            InitializeComponent();
        }
	}

    class Event
    {
        public string name { get; set; }
        public string day { get; set; }
    }
}