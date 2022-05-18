using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Person : Object
    {
        public Person()
        {

        }

        public Person(string name, string adress)
        {
            this.Name = name;
            this.Adress = adress;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string adress;
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
    }
}
