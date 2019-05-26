using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;
using App3.Models;
using App3.Views; 
using App3.ViewModels;
using App3.MyXML;

namespace App3.Views
{
    public class Eventt
    {
        public string Name { get; set; }
        public string Day { get; set; }
        public string Inf { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public  List<Eventt> ActualEvent { get; set; }
        ItemsViewModel viewModel;

        public static void fresh_list()
        {

        }


        public string split_date()
        {
            string act = DateTime.Now.Date.ToString().Substring(0, 10);
            string ch = now.ToString().Substring(0, 10);
            
            string res = "  Текущая дата " + act + "  Выбранная дата " + ch;
            return res;
        }

        public ItemsPage()
        {

            InitializeComponent();
            ActualEvent = new List<Eventt>();
            MyAllEvents.del_unactual();
            update_events();
            Days.Text = split_date();
            
            this.BindingContext = this;
        }

        DateTime now = DateTime.Now.Date;
        public void update_events()
        {
            MyAllEvents.update();
            ActualEvent.Clear();
            foreach (Eventt e in MyAllEvents.Events)
            {
                if (e.Day == now.ToString().Substring(0, 10))
                {
                    ActualEvent.Add(e);
                }
            }

            InitializeComponent();
            Days.Text = split_date();
            Days.FontSize *= 1.356;
            this.BindingContext = this;
        }
  
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            Eventt selEvent = e.Item as Eventt;
            if (selEvent != null)
            {
                await DisplayAlert($"{selEvent.Name}", $"{selEvent.Inf}", "OK");   
            }
        }

        private async Task Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewItemPage(this));

        }
        
        private void Button_Previous(object sender, EventArgs e)
        {
            MyAllEvents.find_actual(now.AddDays(-1));
            ActualEvent = MyAllEvents.ActualEv;
            eventsList.ItemsSource = ActualEvent;
            now = now.AddDays(-1);
            Days.Text = split_date();
        }

        private void Button_Next(object sender, EventArgs e)
        {
            MyAllEvents.find_actual(now.AddDays(+1));
            ActualEvent = MyAllEvents.ActualEv;
            eventsList.ItemsSource = ActualEvent;

            now = now.AddDays(+1);
            Days.Text = split_date();
        }
    }
}