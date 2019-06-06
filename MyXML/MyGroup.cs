using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace App3.MyXML
{
    public class MyGroup
    {
        public string group { get; set; }
        public List<string> lessons { get; set; }
        public List<Student> students { get; set; }

        public MyGroup(string g, List<string> l, List<Student> s)
        {
            group = g;
            lessons = l;
            students = s;
        }
    }

    public  class Student
    {
        public string full_name { get; set; }
        public List<string> marks { get; set; }

        public Student(string n, List<string> l)
        {
            full_name = n;
            marks = l;
        }
    }

    public class AllGroups
    {
        public List<MyGroup> groups {get;set;}

        public AllGroups(List<MyGroup> group)
        {
            groups = group;
        }

        public List<ListGroup> create_list_group()
        {
            List<ListGroup> names_groupp = new List<ListGroup>();

            foreach (MyGroup el in groups)
            {
                names_groupp.Add( new ListGroup (el.group));
            }
            return names_groupp;
        }
        
    }
}
