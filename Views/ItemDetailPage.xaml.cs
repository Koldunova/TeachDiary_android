using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App3.Models;
using App3.ViewModels;
using App3.MyXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {

        StackLayout stackLayout;
        MyGroup mg;
        GroupPage gp;

        public ItemDetailPage(GroupPage gp, MyGroup mg)
        {
            InitializeComponent();
            this.gp = gp;
            this.mg = mg;
            //создание таблицы учащихся

            update_page();

        }
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        int flag = 0;
        private void Button_Add(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                ColumnDefinition cd = new ColumnDefinition { Width = new GridLength(50) };
                grid.ColumnDefinitions.Add(cd);
                string day_now = DateTime.Now.ToString().Substring(0, 5);
                grid.Children.Add(new Label { Text = day_now, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.Black }, grid.ColumnDefinitions.Count - 1, 0);
                //добавление entry соответственно 
                Entry entry = new Entry { Text = "", HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false };
                for (int i = 1; i < grid.RowDefinitions.Count; i++)
                {
                    grid.Children.Add(new Entry { Text = "", HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false }, grid.ColumnDefinitions.Count - 1, i);
                }
                flag = 1;
            }


        }
        void update_page()
        {
            //заголовок
            Grid g = new Grid()
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(30) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };
            g.Children.Add(new BoxView { Color = Color.Teal }, 0, 0);
            Label label = new Label();
            label.Text = mg.group;
            FontSizeConverter fontSizeConverter = new FontSizeConverter();

            label.FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large");
            label.FontSize *= 1.3;
            label.TextColor = Color.White;
            label.FontAttributes = FontAttributes.Bold;
            g.Children.Add(label, 0, 0);

            stackLayout = new StackLayout();
            stackLayout.Children.Add(g);

            RowDefinitionCollection rw = new RowDefinitionCollection();
            // линия
            RowDefinition row_date = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };
            rw.Add(row_date);
            RowDefinition row = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
            foreach (Student st in mg.students)
            {
                rw.Add(row);
            }


            ColumnDefinitionCollection cd = new ColumnDefinitionCollection();
            //учащиеся
            ColumnDefinition col = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
            cd.Add(col);
            //оценки
            col = new ColumnDefinition { Width = new GridLength(50) };
            foreach (string les in mg.lessons)
            {
                cd.Add(col);
            }


            grid = new Grid();
            grid.RowDefinitions = rw;
            grid.ColumnDefinitions = cd;


            int i = 1;

            for (int j = 1; j < mg.lessons.Count + 1; j++)
            {
                //заполнение дат
                grid.Children.Add(new Label { Text = mg.lessons[j - 1].Substring(0, 5), TextColor = Color.Black }, j, 0);
            }


            foreach (Student st in mg.students)
            {
                //заполнение фио учащихся
                grid.Children.Add(new Label { Text = st.full_name, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.Black }, 0, i);

                //заполнение оценок
                for (int u = 1; u < st.marks.Count + 1; u++)
                {
                    grid.Children.Add((new Entry { Text = st.marks[u - 1], HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false }), u, i);
                }//, IsEnabled = false

                i++;
            }
            grid.RowDefinitions = rw;
            grid.ColumnDefinitions = cd;
            grid.RowSpacing = 2;
            grid.ColumnSpacing = 2;

            ScrollView scrollView = new ScrollView();
            scrollView.Orientation = ScrollOrientation.Both;
            StackLayout layout = new StackLayout();
            layout.Children.Add(grid);
            scrollView.Content = layout;
            // stackLayout он главный

            Grid buts = new Grid();
            //надо кнопки изменить оценки (активация entry), добавить занятие, расчет оценок
            Button update = new Button();
            update.BackgroundColor = Color.Teal;
            update.Text = "Изменить";
            update.FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large");
            // update.FontSize *= 1.2;
            update.TextColor = Color.White;
            update.Clicked += Button_Update;

            Button add_colum = new Button();
            add_colum.Text = "Добавить";
            add_colum.BackgroundColor = Color.Teal;
            add_colum.FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large");
            // add_colum.FontSize *= 1.2;
            add_colum.TextColor = Color.White;
            add_colum.Clicked += Button_Add;

            //подсчет отметок
            Button result = new Button();
            result.Text = "Итог";
            result.FontSize = add_colum.FontSize;
            result.BackgroundColor = Color.Teal;
            result.TextColor = Color.White;
            result.Clicked += Button_Res;

            RowDefinitionCollection row_but = new RowDefinitionCollection();
            ColumnDefinitionCollection col_but = new ColumnDefinitionCollection();
            RowDefinition r_but = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };
            row_but.Add(r_but);
            ColumnDefinition c_but = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
            col_but.Add(c_but);
            col_but.Add(c_but);
            col_but.Add(c_but);

            buts.RowDefinitions = row_but;
            buts.ColumnDefinitions = col_but;
            buts.Children.Add(update, 0, 0);
            buts.Children.Add(add_colum, 1, 0);
            buts.Children.Add(result, 2, 0);

            stackLayout.Children.Add(scrollView);
            //  stackLayout.Children.Add(dp);
            stackLayout.Children.Add(buts);
            Content = stackLayout;
        }
        private void Button_Res(object sender, EventArgs e)
        {
            List<int> end_marks = new List<int>();
            string m = "";
            foreach (Student s in mg.students)
            {
                string line = s.full_name + "   ";
                double sum = 0;
                double count = 0;
                foreach (string mar in s.marks)
                {
                    int z = 0;
                    if (Int32.TryParse(mar, out z))
                    {
                        sum += z;
                        count++;
                    }

                }
                double res = Math.Round(sum / count);
                line += res.ToString();
                m += line.ToString() + "\n";
            }

            DisplayAlert("Расчет итоговых отметок", m, "ОK");
        }
        Grid grid;
        private void Button_Update(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Изменить")
            {

                b.Text = "Сохранить";
                for (int i = 0; i < (grid.RowDefinitions.Count * grid.ColumnDefinitions.Count) - 1; i++)
                {
                    grid.Children[i].IsEnabled = true;
                }

            }
            else
            {
                b.Text = "Изменить";
                for (int i = 0; i < grid.Children.Count; i++)
                {
                    grid.Children[i].IsEnabled = false;

                }

                //прописать сохранение
                //mg-текущая группа
                if (flag == 0)
                {
                    //столбец не добавляли

                    int peop = -1;

                    for (int i = grid.ColumnDefinitions.Count - 1; i < grid.Children.Count; i++)
                    {
                        if (grid.Children[i] is Label)
                        {
                            peop++;
                            mg.students[peop].marks = new List<string>();
                        }
                        if (grid.Children[i] is Entry)
                        {
                            mg.students[peop].marks.Add(((Entry)grid.Children[i]).Text);
                        }
                    }
                    for (int i = 0; i < GroupPage.Groups.groups.Count; i++)
                    {
                        if (GroupPage.Groups.groups[i].group == mg.group)
                        {
                            GroupPage.Groups.groups[i] = mg;
                        }
                    }
                }
                else
                {
                    //столбец добавляли

                    int peop = -1;

                    for (int i = grid.ColumnDefinitions.Count - 2; i < grid.Children.Count - grid.RowDefinitions.Count; i++)
                    {
                        if (grid.Children[i] is Label)
                        {
                            peop++;
                            mg.students[peop].marks = new List<string>();
                        }
                        if (grid.Children[i] is Entry)
                        {
                            mg.students[peop].marks.Add(((Entry)grid.Children[i]).Text);
                        }
                    }

                    mg.lessons.Add(((Label)grid.Children[grid.Children.Count - 1 - (grid.RowDefinitions.Count - 1)]).Text);
                    flag = 0;
                    peop = 0;
                    for (int i = grid.Children.Count - 1 - (grid.RowDefinitions.Count - 1) + 1; i < grid.Children.Count; i++)
                    {
                        mg.students[peop].marks.Add(((Entry)grid.Children[i]).Text);
                        peop++;
                    }

                    for (int i = 0; i < GroupPage.Groups.groups.Count; i++)
                    {
                        if (GroupPage.Groups.groups[i].group == mg.group)
                        {
                            GroupPage.Groups.groups[i] = mg;
                        }
                    }
                    update_page();
                }

                XDocument xdoc = XDocument.Load(@"/storage/emulated/0/students");
                XElement my_root = xdoc.Root;
                string s_lessons = "";
                foreach (XElement g in my_root.Elements("group"))
                {
                    if (g.Element("title").Value == mg.group)
                    {
                        //string 
                        s_lessons = "";
                        foreach (string l in mg.lessons)
                        {
                            s_lessons += l + ",";
                        }
                        s_lessons = s_lessons.Substring(0, s_lessons.Length - 1);
                        g.Element("lessons").Value = s_lessons;
                        int i = 0;
                        foreach (XElement el in g.Element("people").Elements("student"))
                        {
                            if (el.Element("name").Value == mg.students[i].full_name)
                            {
                                string mar = "";
                                foreach (string my_mark in mg.students[i].marks)
                                {
                                    mar += my_mark + ",";
                                }
                                mar = mar.Substring(0, mar.Length - 1);
                                el.Element("marks").Value = mar;

                            }
                            i++;
                        }
                    }
                    xdoc.Save(@"/storage/emulated/0/students");

                }

            }

        }
        //конструктор для создания группы
        //кто то ленивый для создания новой формы
        public ItemDetailPage(GroupPage gp)
        {
            InitializeComponent();
            this.gp = gp;
            create_group_design();
            //тут все будет происходить

        }
        StackLayout main_stackLayout;
        void create_group_design()
        {

            FontSizeConverter fontSizeConverter = new FontSizeConverter();

            main_stackLayout = new StackLayout();
            grid = new Grid()
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }

            };
            grid.Children.Add(new Label() { Text = "Создание группы", FontSize= (int)fontSizeConverter.ConvertFromInvariantString("Large"), TextColor=Color.Black}, 0, 0);
            grid.Children.Add(new Entry() { Placeholder = "Введите название группы" },0,1);
            grid.Children.Add(new Label() { Text = "Учащиеся", FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large"), TextColor = Color.Black }, 0, 2);
            grid.Children.Add(new Entry() { Placeholder = "Введите имя учащегося" }, 0, 3);

            ScrollView scrollView = new ScrollView();
            StackLayout layout = new StackLayout();
            layout.Children.Add(grid);
            scrollView.Content = layout;
            main_stackLayout.Children.Add(scrollView);

            Grid grid_b = new Grid()
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }

            };

            Button add_p = new Button();
            add_p.Text = "Добавить";
            add_p.BackgroundColor = Color.Teal;
            add_p.FontSize= (int)fontSizeConverter.ConvertFromInvariantString("Large");
            add_p.TextColor = Color.White;
            add_p.Clicked+=add_new_line;
           
            Button save_g = new Button();
            save_g.Text = "Сохранить";
            save_g.BackgroundColor = Color.Teal;
            save_g.FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large");
            save_g.TextColor = Color.White;
            save_g.Clicked += save_new_group;

            grid_b.Children.Add(add_p, 0, 0);
            grid_b.Children.Add(save_g, 1, 0);
            main_stackLayout.Children.Add(grid_b);
            Content = main_stackLayout;
           
        }
        private async void save_new_group(object sender, EventArgs e)
        {
            int check = 0;
            if (!(((Entry)grid.Children[1]).Text is null))
            { 
                string l = "";
                for (int i = 0; i< ((Entry)grid.Children[1]).Text.Length;i++)
                { l += " "; }
                if (l!= ((Entry)grid.Children[1]).Text)
                { check++; }
            }
            for (int i = 3; i < grid.Children.Count; i++)
            {
                if (!(((Entry)grid.Children[i]).Text is null))
                {
                    check++;
                }
            }
            if (check >= 2)
            {
                XElement group = new XElement("group");
                XElement title = new XElement("title", ((Entry)grid.Children[1]).Text);
                XElement lessons = new XElement("lessons", "");
                XElement people = new XElement("people");
                List<Student> st = new List<Student>();
                for (int i = 3; i < grid.Children.Count; i++)
                {
                    if (!(((Entry)grid.Children[i]).Text is null))
                    {
                        XElement student = new XElement("student");
                        XElement name = new XElement("name", ((Entry)grid.Children[i]).Text);
                        XElement marks = new XElement("marks", "");
                        student.Add(name);
                        student.Add(marks);
                        people.Add(student);
                        st.Add(new Student(((Entry)grid.Children[i]).Text, new List<string>()));
                    }
                }
                group.Add(title);
                group.Add(lessons);
                group.Add(people);

                XDocument xdoc = XDocument.Load(@"/storage/emulated/0/students");
                XElement my_root = xdoc.Root;
                my_root.Add(group);
                xdoc.Save(@"/storage/emulated/0/students");
                GroupPage.Groups.groups.Add(new MyGroup(((Entry)grid.Children[1]).Text, new List<string>(), st));
                gp.update_list();
                await DisplayAlert("Успешно", "Группа сохранена", "ОK");
                create_group_design();
            }
            else
            {
                await DisplayAlert("Внимание", "Заполните поля корректно.\n*Необходимо ввести название группы и минумум 1 учащегося!", "ОK");
            }
        }
        private void add_new_line(object sender, EventArgs e)
        {
            RowDefinition rd = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)};
            grid.RowDefinitions.Add(rd);
            grid.Children.Add(new Entry() { Placeholder = "Введите имя учащегося" }, 0, grid.RowDefinitions.Count-1);
           
        }
    }
}
 