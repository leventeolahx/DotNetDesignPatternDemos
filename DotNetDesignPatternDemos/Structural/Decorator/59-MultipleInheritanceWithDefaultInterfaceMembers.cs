using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Decorator
{
    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface IBird59: ICreature
    {
        void Fly()
        {
            if (Age >= 10)
            {
                Console.WriteLine("I am flying");
            }
        }
    }

    public interface ILizard59 : ICreature
    {
        void Crawl()
        {
            if (Age >= 10)
            {
                Console.WriteLine("I am crawling");
            }
        }
    }

    public class Organism { }

    public class Dragon59 : Organism, IBird59, ILizard59
    {
        public int Age { get; set; }
    }

    // inharitance
    // SmallDragon(Dragon)
    // extension method
    // C#8 default interface methods

    public class MultipleInheritanceWithDefaultInterfaceMembers
    {
        public static void Start()
        {
            Dragon59 d = new Dragon59 { Age = 5 };
            if (d is IBird59 bird)
                bird.Fly();

            if (d is ILizard59 lizard)
                lizard.Crawl();
        }
    }
}
