using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Decorator
{
    public interface IBird
    {
        int Weight { get; set; }

        void Fly();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Soaring in the air with weight {Weight}");
        }
    }

    public interface ILizard
    {
        int Weight { get; set; }

        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard  
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public Dragon()
        {

        }

        public Dragon(Bird bird, Lizard lizard)
        {
            this.bird = bird ?? throw new ArgumentNullException(paramName: nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(paramName: nameof(lizard));
        }

        public int Weight {
            get { return weight; }
            set 
            { 
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }


    public class MultipleInheritanceWithInterfaces
    {
        public static void Start()
        {
            var d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();            
        }
    }
}
