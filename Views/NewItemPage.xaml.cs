using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App3.Models;
using System.Xml.Linq;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        ItemsPage page;

        public NewItemPage(ItemsPage ipg)
        {
            InitializeComponent();
            page = ipg;
            Item = new Item
            {
                Text = "",
                Description = "",
                Day = DateTime.Now.Date.ToString()
            };

            BindingContext = this;
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
           
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (EnName.Text.Length > 0)
            {
                XDocument xdoc = XDocument.Load(@"/storage/emulated/0/events");
                XElement root = xdoc.Element("Events");
                XElement el = new XElement("Event");
                el.Add(new XElement("Title", EnName.Text));
                string day = EnDay.Date.ToString();
                day = day.Substring(0, 10);
                el.Add(new XElement("Day", day));
                el.Add(new XElement("Inf", EnInf.Text));
                root.Add(el);
                xdoc.Save(@"/storage/emulated/0/events");
                EnName.Text = "";
                EnInf.Text = "";
                page.update_events();
                DisplayAlert("Успешно", "Событие сохранено", "ОK");
            }
            else
            {
                DisplayAlert("Внимание", "Запоните все поля", "ОK");
            }
        }
    }
}