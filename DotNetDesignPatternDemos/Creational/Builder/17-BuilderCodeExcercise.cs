using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Builder
{

    public class CodeBuilder
    {
        private string ClassName { get; set; }       

        private List<Tuple<string, string>> Fields { get; set; } = new List<Tuple<string, string>>();
        private readonly int Indent = 1;

        public CodeBuilder(string className)
        {
            ClassName = className;
        }

        public CodeBuilder AddField(string name, string typeName)
        {
            Fields.Add(new Tuple<string, string>(name, typeName));
            return this;
        }

        public override string ToString()
        {
            var stringB = new StringBuilder();
            stringB.Append($"public class {ClassName}\n");            
            stringB.Append("{\n");
            foreach(var field in Fields)
            {
                stringB.Append(' ', 2 * Indent);
                stringB.Append($"public {field.Item2} {field.Item1};\n");                
            }
            stringB.Append("}\n");

            return stringB.ToString();
        }
    }

    //You are asked to implement the Builder design pattern for rendering simple chunks of code.
    //Sample use of the builder you are asked to create: 
    //var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int"); Console.WriteLine(cb); 
    //The expected output of the above code is: 
    //
    //public class Person
    //{ 
    //    public string Name; 
    //    public int Age;
    //} 
    //Please observe the same placement of curly braces and use two-space indentation.
    public static class BuilderCodeExcercise
    {
        public static void Start()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int"); Console.WriteLine(cb);
        }
    }
}
