using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Address30 : IPrototype<Address30>
    {
        public string StreetAddress, City, Country;

        public Address30(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(paramName: nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(paramName: nameof(city));
            Country = country ?? throw new ArgumentNullException(paramName: nameof(country));
        }

        public Address30(Address30 other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }

        public Address30 DeepCopy()
        {
            return new Address30(StreetAddress, City, Country);
        }
    }

    public class Employee30 : IPrototype<Employee30>
    {
        public string Name;
        public Address30 Address;

        public Employee30(string name, Address30 address)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        public Employee30(Employee30 other)
        {
            Name = other.Name;
            Address = new Address30(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }

        public Employee30 DeepCopy()
        {
            return new Employee30(Name, Address.DeepCopy());
        }
    }
    public static class DeepCopyInterface
    {
        public static void Start()
        {
            var john = new Employee30("John", new Address30("123 London Road", "London", "UK"));

            var chris = john.DeepCopy();

            chris.Name = "Chris";
            Console.WriteLine(john);
            Console.WriteLine(chris);
        }
    }
}
