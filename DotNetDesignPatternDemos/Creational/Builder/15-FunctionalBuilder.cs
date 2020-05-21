using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Builder
{
    public class Person
    {
        public string Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject: new ()
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public Person Build() =>
            actions.Aggregate(new Person(), (p, f) => f(p));
        
        public TSelf Do(Action<Person> action) => AddAction(action);

        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    // without FunctionalBuilder
    //public sealed class PersonBuilder
    //{
    //private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

    //public Person Build() =>
    //    actions.Aggregate(new Person(), (p, f) => f(p));

    //public PersonBuilder Called(string name) => Do(p => p.Name = name);

    //public PersonBuilder Do(Action<Person> action) => AddAction(action);

    //private PersonBuilder AddAction(Action<Person> action)
    //{
    //    actions.Add(p =>
    //    {
    //        action(p);
    //        return p;
    //    });
    //    return this;
    //}
    //}

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position)
            => builder.Do(x => x.Position = position);
    }

    public static class FunctionalBuilder
    {
        public static void Start()
        {
            var person = new PersonBuilder()
                .Called("Sarah")
                .WorksAs("Developer")
                .Build();
            Console.WriteLine($"person: {person.Name} works as {person.Position}" );
        }
    }
}
