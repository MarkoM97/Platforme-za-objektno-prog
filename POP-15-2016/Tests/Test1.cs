using POP_15_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_15_2016.Tests
{
    class Test1
    {
        public Test1()
        {
            Person p1 = new Person("marko", "martonosi");
            p1.Name = "New name";
            Console.WriteLine(String.Format("my name {0},  prezsime mi je{1}", p1.Name, p1.Surname));
            Console.WriteLine($"Hello asa: {p1.Name}");



            int[] a = { 1, 2, 3 };
            List<string> strings = new List<string>();
            List<Person> osobe = new List<Person>();

            for (var i = 0; i < a.Count(); i++)
            {
                Console.WriteLine(a[i]);
                Person p2 = new Person(a[i].ToString() + "ime", a[i].ToString() + "prezime");
                Console.WriteLine(p2.Name + p2.Surname);
                osobe.Add(p2);
            }

            var salon = new Salon()
            {
                Id = 1
            }

            strings.Add("rucno");

            foreach (var osoba in osobe)

            {
                Console.WriteLine(osoba);
                Console.ReadLine();
            }
        }
    }
}
