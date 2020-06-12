using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DotNetDesignPatternDemos.Structural.Composite
{
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods53
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

    /// <summary>
    /// Consider the code presented below.The Sum() extension method 
    /// adds up all the values in a list of IValueContainer elements it gets passed. 
    /// We can have a single value or a set of values. 
    /// Complete the implementation of the interfaces so that Sum()begins to work correctly.
    /// </summary>
    public class CompositeCodeExcercise
    {
        public static void Start()
        {
            var singleValue = new SingleValue { Value = 11 };
            var otherValues = new ManyValues();
            otherValues.Add(22);
            otherValues.Add(33);
            Console.WriteLine(new List<IValueContainer> { singleValue, otherValues }.Sum());

            Console.WriteLine(ExtensionMethods53.Sum(new List<IValueContainer> { singleValue, otherValues }));            
        }
    }
}
