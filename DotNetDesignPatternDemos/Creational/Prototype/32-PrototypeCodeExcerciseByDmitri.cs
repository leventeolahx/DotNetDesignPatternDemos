using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Prototype
{
    public class Point32
    {
        public int X, Y;
    }

    public class Line32
    {
        public Point32 Start, End;

        public Line32 DeepCopy()
        {
            var newStart = new Point32 { X = Start.X, Y = Start.Y };
            var newEnd = new Point32 { X = End.X, Y = End.Y };
            return new Line32 { Start = newStart, End = newEnd };
        }

        public override string ToString()
        {
            return $"Start: ({Start.X},{Start.Y}), End: ({End.X},{End.Y})";
        }
    }
    public static class PrototypeCodeExcerciseByDmitri
    {
        public static void Start()
        {
            var line1 = new Line32
            {
                Start = new Point32 { X = 3, Y = 3 },
                End = new Point32 { X = 10, Y = 10 }
            };

            var line2 = line1.DeepCopy();
            line1.Start.X = line1.End.X = line1.Start.Y = line1.End.Y = 0;

            Console.WriteLine(line1);
            Console.WriteLine(line2);
        }
    }
}
