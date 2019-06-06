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
        public static AllGroups Groups; //объекты всех групп со всеми данными

        //Сохранение в XML 
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
        private async void name_groups_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            ListGroup listGroupev = e.Item as ListGroup;
            if (listGroupev != null)
            {
                foreach (MyGroup mg in Groups.groups)
                {
                    if (mg.group == listGroupev.Group_name)
                    {
                        await Navigation.PushModalAsync(new ItemDetailPage(this, mg));
                    }
                }
            }
        }
        //добавить группу
        private  async void Button_Add(object sender, EventArgs e)
        {
            //todo 
            await Navigation.PushModalAsync(new ItemDetailPage(this));
        }
        //удалить группу
        private async void Button_Remove(object sender, EventArgs e)
        {


            List<string> per = new List<string>();
            foreach (MyGroup mg in Groups.groups)
            {
                per.Add(mg.group);
            }
            var action = await DisplayActionSheet("Группа для удаления", "Отмена", null, per.ToArray());

            if (action.ToString() != "Отмена")
            {
                var pod = await DisplayAlert("Внимание", "Вы действительно хотите удалить группу " + action.ToString() + "?\nЭто действие нельзя будет отменить и данные невозможно будет восстановить!", "Продолжить", "Отмена");
                if (pod.ToString() == "True")
                {
                    XDocument xdoc = XDocument.Load(@"/storage/emulated/0/students");
                    XElement my_root = xdoc.Root;
                    foreach (XElement g in my_root.Elements("group"))
                    {
                        if (g.Element("title").Value == action.ToString())
                        {
                            g.Remove();

                        }
                        xdoc.Save(@"/storage/emulated/0/students");
                    }
                    //удалили из файла
                    //надо удалить из массива
                    //обновить список
                    int i = 0;
                    foreach (MyGroup mg in Groups.groups)
                    {
                        i++;
                        if (mg.group == action.ToString())
                        {
                            break;
                        }
                    }
                    Groups.groups.RemoveAt(i - 1);
                    update_list();
                   
                }
            }
            
        }
        public void update_list()
        {
            n_groups = new List<ListGroup>();
            foreach (MyGroup mg in Groups.groups)
            {
                n_groups.Add(new ListGroup(mg.group));
            }
            groupsList.ItemsSource = n_groups;
            groupsList.ItemsSource = n_groups;
        }
    }
}