using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Prototype
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point DeepCopy()
        {
            return new Point(X, Y);
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }

        public override string ToString()
        {
            return $"Start: ({Start.X},{Start.Y}), End: ({End.X},{End.Y})";
        }
    }

    public static class PrototypeCodeExcercise
    {
        public static void Start()
        {
            var line = new Line(new Point(1, 1), new Point(6, 6));
            var lineCopy = line.DeepCopy();
            lineCopy.End.Y = 9;

            Console.WriteLine(line);
            Console.WriteLine(lineCopy);
        }
    }
}
