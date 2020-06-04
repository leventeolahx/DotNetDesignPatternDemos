using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Singleton
{
    public class ChiefExecutiveOfficer
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    public class Monostate
    {
        public static void Start()
        {
            var ceo = new ChiefExecutiveOfficer();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;

            var ceo2 = new ChiefExecutiveOfficer();
            Console.WriteLine(ceo2);
        }
    }
}
