using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App3.Models;
using System.Xml.Linq;
using App3.MyXML;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTimeTable : ContentPage
    {
        Color c2 = Color.FromRgb(13, 174, 142);
        Color c = Color.Teal;
        int flag = 0;
        TimePage tp;
        public NewTimeTable(TimePage t)
        {
            InitializeComponent();
            this.BindingContext = this;
            tp = t;
            b_mon.FontSize *= 1.7;
            b_tues.FontSize *= 1.7;
            b_wed.FontSize *= 1.7;
            b_thurs.FontSize *= 1.7;
            b_fri.FontSize *= 1.7;
            b_sat.FontSize *= 1.7;
            find_dayofweek();
        }
        void ch(ref XElement el)
        {
            el.Element("para1").Value = p1.Text;
            el.Element("para2").Value = p2.Text;
            el.Element("para3").Value = p3.Text;
            el.Element("para4").Value = p4.Text;
            el.Element("para5").Value = p5.Text;
            el.Element("para6").Value = p6.Text;
            el.Element("para7").Value = p7.Text;
            el.Element("para8").Value = p8.Text;
            el.Element("para9").Value = p9.Text;
        }
        private void Button_Save(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"/storage/emulated/0/timetable");
            XElement root = xdoc.Element("timetable");

            foreach (XElement el in root.Elements("day"))
            {
                if (el.Element("name").Value == "Понедельник" && flag == 1)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
                if (el.Element("name").Value == "Вторник" && flag == 2)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
                if (el.Element("name").Value == "Среда" && flag == 3)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
                if (el.Element("name").Value == "Четверг" && flag == 4)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
                if (el.Element("name").Value == "Пятница" && flag == 5)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
                if (el.Element("name").Value == "Суббота" && flag == 6)
                {
                    el.Element("para1").Value = p1.Text;
                    el.Element("para2").Value = p2.Text;
                    el.Element("para3").Value = p3.Text;
                    el.Element("para4").Value = p4.Text;
                    el.Element("para5").Value = p5.Text;
                    el.Element("para6").Value = p6.Text;
                    el.Element("para7").Value = p7.Text;
                    el.Element("para8").Value = p8.Text;
                    el.Element("para9").Value = p9.Text;
                    break;
                }
            }
                
            xdoc.Save(@"/storage/emulated/0/timetable");
            MyAllLessons.open_timetable();
            tp.refresh();
            DisplayAlert("Успешно", "Сохранено", "ОK");

        }
        private void find_dayofweek()
        {
            int day = (int)DateTime.Now.DayOfWeek;
            flag = day;
            if (day == 1)
            {
                b_mon.BackgroundColor = c2;
                mon();
            }
            if (day == 2)
            {
                b_tues.BackgroundColor = c2;
                tues();
            }
            if (day == 3)
            {
                b_wed.BackgroundColor = c2;
                wed();
            }
            if (day == 4)
            {
                b_thurs.BackgroundColor = c2;
                thurs();
            }
            if (day == 5)
            {
                b_fri.BackgroundColor = c2;
                fri();
            }
            if (day == 6)
            {
                b_sat.BackgroundColor = c2;
                sat();
            }

        }
        void mon()
        {
            b_mon.BackgroundColor = c2;
            b_tues.BackgroundColor = c;
            b_wed.BackgroundColor = c;
            b_thurs.BackgroundColor = c;
            b_fri.BackgroundColor = c;
            b_sat.BackgroundColor = c;
            p1.Text = MyAllLessons.timetables[0].para_1;
            p2.Text = MyAllLessons.timetables[0].para_2;
            p3.Text = MyAllLessons.timetables[0].para_3;
            p4.Text = MyAllLessons.timetables[0].para_4;
            p5.Text = MyAllLessons.timetables[0].para_5;
            p6.Text = MyAllLessons.timetables[0].para_6;
            p7.Text = MyAllLessons.timetables[0].para_7;
            p8.Text = MyAllLessons.timetables[0].para_8;
            p9.Text = MyAllLessons.timetables[0].para_9;
        }
        void tues()
        {
            b_mon.BackgroundColor = c;
            b_tues.BackgroundColor = c2;
            b_wed.BackgroundColor = c;
            b_thurs.BackgroundColor = c;
            b_fri.BackgroundColor = c;
            b_sat.BackgroundColor = c;

            p1.Text = MyAllLessons.timetables[1].para_1;
            p2.Text = MyAllLessons.timetables[1].para_2;
            p3.Text = MyAllLessons.timetables[1].para_3;
            p4.Text = MyAllLessons.timetables[1].para_4;
            p5.Text = MyAllLessons.timetables[1].para_5;
            p6.Text = MyAllLessons.timetables[1].para_6;
            p7.Text = MyAllLessons.timetables[1].para_7;
            p8.Text = MyAllLessons.timetables[1].para_8;
            p9.Text = MyAllLessons.timetables[1].para_9;
        }
        void wed()
        {
            b_mon.BackgroundColor = c;
            b_tues.BackgroundColor = c;
            b_wed.BackgroundColor = c2;
            b_thurs.BackgroundColor = c;
            b_fri.BackgroundColor = c;
            b_sat.BackgroundColor = c;
            p1.Text = MyAllLessons.timetables[2].para_1;
            p2.Text = MyAllLessons.timetables[2].para_2;
            p3.Text = MyAllLessons.timetables[2].para_3;
            p4.Text = MyAllLessons.timetables[2].para_4;
            p5.Text = MyAllLessons.timetables[2].para_5;
            p6.Text = MyAllLessons.timetables[2].para_6;
            p7.Text = MyAllLessons.timetables[2].para_7;
            p8.Text = MyAllLessons.timetables[2].para_8;
            p9.Text = MyAllLessons.timetables[2].para_9;
        }
        void thurs()
        {

            b_mon.BackgroundColor = c;
            b_tues.BackgroundColor = c;
            b_wed.BackgroundColor = c;
            b_thurs.BackgroundColor = c2;
            b_fri.BackgroundColor = c;
            b_sat.BackgroundColor = c;

            p1.Text = MyAllLessons.timetables[3].para_1;
            p2.Text = MyAllLessons.timetables[3].para_2;
            p3.Text = MyAllLessons.timetables[3].para_3;
            p4.Text = MyAllLessons.timetables[3].para_4;
            p5.Text = MyAllLessons.timetables[3].para_5;
            p6.Text = MyAllLessons.timetables[3].para_6;
            p7.Text = MyAllLessons.timetables[3].para_7;
            p8.Text = MyAllLessons.timetables[3].para_8;
            p9.Text = MyAllLessons.timetables[3].para_9;
        }
        void fri()
        {
            b_mon.BackgroundColor = c;
            b_tues.BackgroundColor = c;
            b_wed.BackgroundColor = c;
            b_thurs.BackgroundColor = c;
            b_fri.BackgroundColor = c2;
            b_sat.BackgroundColor = c;
            p1.Text = MyAllLessons.timetables[4].para_1;
            p2.Text = MyAllLessons.timetables[4].para_2;
            p3.Text = MyAllLessons.timetables[4].para_3;
            p4.Text = MyAllLessons.timetables[4].para_4;
            p5.Text = MyAllLessons.timetables[4].para_5;
            p6.Text = MyAllLessons.timetables[4].para_6;
            p7.Text = MyAllLessons.timetables[4].para_7;
            p8.Text = MyAllLessons.timetables[4].para_8;
            p9.Text = MyAllLessons.timetables[4].para_9;
        }
        void sat()
        {
            b_mon.BackgroundColor = c;
            b_tues.BackgroundColor = c;
            b_wed.BackgroundColor = c;
            b_thurs.BackgroundColor = c;
            b_fri.BackgroundColor = c;
            b_sat.BackgroundColor = c2;

            p1.Text = MyAllLessons.timetables[5].para_1;
            p2.Text = MyAllLessons.timetables[5].para_2;
            p3.Text = MyAllLessons.timetables[5].para_3;
            p4.Text = MyAllLessons.timetables[5].para_4;
            p5.Text = MyAllLessons.timetables[5].para_5;
            p6.Text = MyAllLessons.timetables[5].para_6;
            p7.Text = MyAllLessons.timetables[5].para_7;
            p8.Text = MyAllLessons.timetables[5].para_8;
            p9.Text = MyAllLessons.timetables[5].para_9;
        }
        private void Button_Mon(object sender, EventArgs e)
        {
            mon();
            flag = 1;
        }
        private void Button_Tues(object sender, EventArgs e)
        {
            flag = 2;
            tues();
        }
        private void Button_Wed(object sender, EventArgs e)
        {
            flag = 3;
            wed();
        }
        private void Button_Thurs(object sender, EventArgs e)
        {
            thurs();
            flag = 4;
        }
        private void Button_Fri(object sender, EventArgs e)
        {
            fri();
            flag = 5;
        }
        private void Button_Sat(object sender, EventArgs e)
        {
            sat();
            flag = 6;
        }
    }
}
