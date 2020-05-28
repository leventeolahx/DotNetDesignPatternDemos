using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class PersonFactory
    {
        int id = 0;
        
        public Person CreatePerson(string name) 
        {
            return new Person { Id = id++, Name = name };
        }
    }

    //Factory Coding Exercise 
    //You are given a class calledPerson. The person has two fields: Id, and Name. 
    //Please implement anon-static PersonFactory that has a CreatePerson() method that takes a person's name. 
    //The Id of the person should be set as a 0-based index of the object created. 
    //So, the first person the factory makes should have Id=0, second Id=1 and so on.
    public static class FactoryCodeExcecise
    {
        public static void Start()
        {
            var pf = new PersonFactory();

            var p1 = pf.CreatePerson("Chris");
            Console.WriteLine(p1);

            var p2 = pf.CreatePerson("Sarah");
            Console.WriteLine(p2);
        }
    }
}
