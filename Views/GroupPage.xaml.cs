using App3.MyXML;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GroupPage : ContentPage
	{
        AllGroups Groups; //объекты всех групп со всеми данными
        GroupViewModel groupViewModel;  
        public void open_groups()
        {
             List<MyGroup> myGroups = new List<MyGroup>();
             XDocument xdoc = XDocument.Load(@"/storage/emulated/0/students");
             foreach (XElement e in xdoc.Element("students").Elements("group"))
             {
                 string group_name = e.Element("title").Value;
                 string[] mas = e.Element("lessons").Value.Split(new char[] { ',' });
                 List<string> les = new List<string>();

                 foreach (string el in mas)
                 {
                     les.Add(el);
                 }
                 List<Student> st = new List<Student>();
                 foreach (XElement el in e.Element("people").Elements("student"))
                 {
                     string st_name = el.Element("name").Value;
                     string[] marks = el.Element("marks").Value.Split(new char[] { ',' });
                     List<string> mark = new List<string>();
                       foreach (string m in marks)
                       {
                           mark.Add(m);
                       }
                       st.Add(new Student(st_name, mark));
                 }
                 myGroups.Add(new MyGroup(group_name, les, st));
             }
             Groups = new AllGroups(myGroups);
             xdoc.Save(@"/storage/emulated/0/students");
             n_groups = new List<ListGroup>();
             List<ListGroup> n_group = new List<ListGroup>();
             foreach (MyGroup el in Groups.groups)
             {
                 n_group.Add(new ListGroup(el.group));
             }
             n_groups = n_group;
        }
        
        public List<ListGroup> n_groups { get; set; }//список имен групп

        public GroupPage()
        {
            InitializeComponent();
            open_groups();
            this.BindingContext = this;
            //создали список имен групп

        }

        private async System.Threading.Tasks.Task name_groups_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            ListGroup listGroupev = e.Item as ListGroup;
            if (listGroupev != null)
            {
                foreach (MyGroup mg in Groups.groups)
                {
                    if (mg.group ==listGroupev.Group_name)
                    {
                      
                       // await DisplayAlert($"{listGroupev.Group_name}", $"{listGroupev.Group_name}", "OK");
                        await Navigation.PushModalAsync(new ItemDetailPage(this, mg));
                    }
                }
            }
            /*
             Eventt selEvent = e.Item as Eventt;
            if (selEvent != null)
            {
                await DisplayAlert($"{selEvent.Name}", $"{selEvent.Inf}", "OK");   
            }
             */
        }
    }
}