using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App3.Models;
using App3.ViewModels;
using App3.MyXML;
using System.Collections.Generic;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        StackLayout stackLayout;
        MyGroup mg;
        GroupPage gp;
        public ItemDetailPage(GroupPage gp, MyGroup mg)
        {
            InitializeComponent();
            this.gp = gp;
            this.mg = mg;
            //создание таблицы учащихся

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
                grid.Children.Add(new Label { Text = mg.lessons[j - 1].Substring(0, 5),TextColor = Color.Black }, j, 0);
            }
            int k = 1;
            foreach (Student st in mg.students)
            {
                //заполнение фио учащихся
                grid.Children.Add(new Label { Text = st.full_name,  TextColor = Color.Black }, 0, i);

                //заполнение оценок
                for (int u = 1; u < st.marks.Count; u++)
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
            //  stackLayout он главный

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
            add_colum.Text = "Добавить занятие";
            update.BackgroundColor = Color.Teal;
            add_colum.FontSize = (int)fontSizeConverter.ConvertFromInvariantString("Large");
           // add_colum.FontSize *= 1.2;
            add_colum.TextColor = Color.White;
            add_colum.Clicked += Button_Add;


            RowDefinitionCollection row_but = new RowDefinitionCollection();
            ColumnDefinitionCollection col_but = new ColumnDefinitionCollection();
            RowDefinition r_but = new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };
            row_but.Add(r_but);
            ColumnDefinition c_but = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
            col_but.Add(c_but);
            col_but.Add(c_but);
            buts.RowDefinitions = row_but;
            buts.ColumnDefinitions = col_but;
            buts.Children.Add(update, 0, 0);
            buts.Children.Add(add_colum, 1, 0);

            stackLayout.Children.Add(scrollView);
            stackLayout.Children.Add(buts);


            Content = stackLayout;

        }

        private void Button_Add(object sender, EventArgs e)
        {
            ColumnDefinition cd = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
            grid.ColumnDefinitions.Add(cd);
            grid.Children.Add(new Label { Text = "дата", VerticalTextAlignment = TextAlignment.Center, TextColor = Color.Black },grid.ColumnDefinitions.Count-1,0 );
            //добавление entry соответственно 
            Entry entry = new Entry { Text = "", HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false };
            grid.Children.Add(new Entry { Text = "", HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false }, grid.ColumnDefinitions.Count - 1, 1);
            grid.Children.Add(new Entry { Text = "", HorizontalTextAlignment = TextAlignment.Center, IsEnabled = false }, grid.ColumnDefinitions.Count - 1, 2);
            for (int i = 1; i < grid.RowDefinitions.Count; i++)
            {
                grid.Children.Add(entry, grid.ColumnDefinitions.Count - 1, 1);
            }
        }


        Grid grid;
        private void Button_Update(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Изменить")
            {
                b.Text = "Сохранить ";
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
                    //if (grid.Children[i] is Label)
                    //{ Label l = (Label)grid.Children[i];
                    //    b.Text += l.Text;
                    //    l.VerticalTextAlignment = TextAlignment.Center;
                    //    grid.Children[i] = l;
                    //}
                }
               
                //пописать сохранение

            }
            
        }

    }
}