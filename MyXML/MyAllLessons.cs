using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace App3.MyXML
{
    public class MyAllLessons
    {
        public static List<timetable> timetables { get; set; }
        public static void open_timetable()
        {
            timetables = new List<timetable>();
            XDocument xdoc = XDocument.Load(@"/storage/emulated/0/timetable");
            foreach (XElement e in xdoc.Element("timetable").Elements("day"))
            {
                timetables.Add(new timetable(e.Element("name").Value, e.Element("para1").Value,e.Element("para2").Value, e.Element("para3").Value, e.Element("para4").Value, e.Element("para5").Value, e.Element("para6").Value, e.Element("para7").Value, e.Element("para8").Value, e.Element("para9").Value));
            }
            xdoc.Save(@"/storage/emulated/0/timetable");
        }
    }

    public class timetable
    {
        public string name { get; set; }
        public string para_1 { get; set; }
        public string para_2 { get; set; }
        public string para_3 { get; set; }
        public string para_4 { get; set; }
        public string para_5 { get; set; }
        public string para_6 { get; set; }
        public string para_7 { get; set; }
        public string para_8 { get; set; }
        public string para_9 { get; set; }

        public timetable(string n, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9)
        {
            name = n;
            para_1 = p1;
            para_2 = p2;
            para_3 = p3;
            para_4 = p4;
            para_5 = p5;
            para_6 = p6;
            para_7 = p7;
            para_8 = p8;
            para_9 = p9;

        }
    }
}
