using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Builder
{

    // We already have a person class so FI means Fluent inheritence
    public class PersonFI
    {
        public string Name;

        public string Position;

        public DateTime DateOfBirth;

        public class Builder : PersonFIBirthDateBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }

    public abstract class PersonFIBuilder
    {
        protected PersonFI person = new PersonFI();

        public PersonFI Build()
        {
            return person;
        }
    }

    public class PersonFIInfoBuilder<SELF> : PersonFIBuilder
      where SELF : PersonFIInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonFIJobBuilder<SELF>
      : PersonFIInfoBuilder<PersonFIJobBuilder<SELF>>
      where SELF : PersonFIJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    // here's another inheritance level
    // note there's no PersonInfoBuilder<PersonJobBuilder<PersonBirthDateBuilder<SELF>>>!

    public class PersonFIBirthDateBuilder<SELF>
      : PersonFIJobBuilder<PersonFIBirthDateBuilder<SELF>>
      where SELF : PersonFIBirthDateBuilder<SELF>
    {
        public SELF Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (SELF)this;
        }
    }

    // Fluent Builder Inheritance with Recursive Generics
    public static class FluentBuilderInhWithRecGenerics
    {
        public static void Start()
        {
            var me = PersonFI.New
              .Called("Dmitri")
              .WorksAsA("Quant")
              .Born(DateTime.UtcNow)
              .Build();
            Console.WriteLine(me);
        }
    }
}
