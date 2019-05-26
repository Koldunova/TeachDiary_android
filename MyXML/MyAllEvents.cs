using App3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace App3.MyXML
{
    class MyAllEvents
    {
        public static List<Eventt> Events { get; set; }
        static DateTime now = DateTime.Now.Date;
        public static List<Eventt> ActualEv { get; set; }

        public static void update()
        {
            Events = new List<Eventt>();
            XDocument xdoc = XDocument.Load(@"/storage/emulated/0/events");
            foreach (XElement e in xdoc.Element("Events").Elements("Event"))
            {
                XElement t = e.Element("Title");
                XElement d = e.Element("Day");
                XElement i = e.Element("Inf");
                Events.Add(new Eventt { Name = t.Value, Day = d.Value, Inf = i.Value });

            }
            xdoc.Save(@"/storage/emulated/0/events");
        }

        public static void find_actual(DateTime need)
        {
            ActualEv = new List<Eventt>();
            XDocument xdoc = XDocument.Load(@"/storage/emulated/0/events");
            foreach (XElement e in xdoc.Element("Events").Elements("Event"))
            {
                if (e.Element("Day").Value.ToString() == need.ToString().Substring(0, 10))
                {
                    ActualEv.Add(new Eventt { Name = e.Element("Title").Value, Day = e.Element("Day").Value, Inf = e.Element("Inf").Value });
                }
            }
            //xdoc.Save(@"/storage/emulated/0/events");
        }

        public static void del_unactual()
        {
            XDocument xdoc = XDocument.Load(@"/storage/emulated/0/events");
            foreach (XElement e in xdoc.Element("Events").Elements("Event"))
            {
                XElement d = e.Element("Day");
                 if (d.Value.Length>=10 && DateTime.Parse(d.Value.Trim().Substring(0, 10)) < DateTime.Now.Date.AddDays(-184))
                 {
                     e.Remove();
                 };
            } 
            xdoc.Save(@"/storage/emulated/0/events");
        }
    }
}
