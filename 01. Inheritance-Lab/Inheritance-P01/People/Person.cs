using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Person
    {
        public string name;
        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }

        public string adress;
        public string Adress 
        {
            get { return adress; }
            set { adress = value; }
        }
    }
}
