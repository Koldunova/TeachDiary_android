using App3.MyXML;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{

        Color c2 = Color.FromRgb(13, 174, 142);
        Color c = Color.Teal;
        int flag = 0;
        public TimePage ()
		{
			InitializeComponent ();
            MyAllLessons.open_timetable();
            find_dayofweek();
            b_mon.FontSize *= 1.5;
            b_tues.FontSize *= 1.5;
            b_wed.FontSize *= 1.5;
            b_thurs.FontSize *= 1.5;
            b_fri.FontSize *= 1.5;
            b_sat.FontSize *= 1.5;
        }
        //определение дня недели
        private void find_dayofweek()
        {
            int day =(int)DateTime.Now.DayOfWeek;
            flag = day;
            if (day == 1) 
            {
                b_mon.BackgroundColor = c2;
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
            if (day == 2)
            {
                b_tues.BackgroundColor = c2;
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
            if (day == 3)
            {
                b_wed.BackgroundColor = c2;
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
            if (day == 4)
            {
                b_thurs.BackgroundColor = c2;
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
            if (day == 5)
            {
                b_fri.BackgroundColor = c2;
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
            if (day == 6)
            {
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
            if (day == 7)
            {
                string li = "";
                p1.Text = li;
                p2.Text = li;
                p3.Text = li;
                p4.Text = li;
                p5.Text = li;
                p6.Text = li;
                p7.Text = li;
                p8.Text = li;
                p9.Text = li;

            }

        }
        public void refresh()
        {
            if (flag == 1)
            {
                mon();
            }
            if (flag == 2)
            {
                tues();
            }
            if (flag == 3)
            {
                wed();
            }
            if (flag == 4)
            {
                thurs();
            }
            if (flag == 5)
            {
                fri();
            }
            if (flag == 6)
            {
                sat();
            }
        }
        public void mon()
        {
            flag = 1;
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
        public void tues()
        {
            flag = 2;
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
        public void wed()
        {
            flag = 3;
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
        public void thurs()
        {
            flag = 4;
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
        public void fri()
        {
            flag = 5;
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
        public void sat()
        {
            flag = 6;
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
        }
        private void Button_Tues(object sender, EventArgs e)
        {
            tues();
        }
        private void Button_Wed(object sender, EventArgs e)
        {
            wed();
        }
        private void Button_Thurs(object sender, EventArgs e)
        {
            thurs();
        }
        private void Button_Fri(object sender, EventArgs e)
        {
            fri();
        }
        private void Button_Sat(object sender, EventArgs e)
        {
            sat();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewTimeTable(this));
        }
    }
}