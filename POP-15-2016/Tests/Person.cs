﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016
{
    public class Person
    {
        private string name = "";
        private string surname = "";

        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        
    }
}
