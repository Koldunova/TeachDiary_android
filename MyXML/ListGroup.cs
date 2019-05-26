using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace App3.MyXML
{
    public class ListGroup
    {
        public string Group_name { get; set; }

        public ListGroup(string gn)
        {
            Group_name = gn;
        }
    }
}
