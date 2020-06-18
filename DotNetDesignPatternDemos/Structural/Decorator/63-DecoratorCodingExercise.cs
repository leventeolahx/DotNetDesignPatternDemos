using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Decorator
{
    public class Bird63
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard63
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon63 // no need for interfaces
    {
        private int age;
        private Bird63 bird = new Bird63();
        private Lizard63 lizard = new Lizard63();

        public int Age
        {
            set { age = bird.Age = lizard.Age = value; }
            get { return age; }
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }

    /// <summary>
    /// The following code scenario shows a Dragon which is both a Bird and a Lizard. 
    /// Complete the Dragon's interface (there's no need to extract IBird or ILizard). Take special care when implementing the Age property!
    /// </summary>
    public class DecoratorCodingExercise
    {
        public static void Start()
        {
            var d = new Dragon63 { Age = 11 };
            Console.WriteLine(d.Fly());
            Console.WriteLine(d.Crawl());
        }
    }
}
