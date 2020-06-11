using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoreLinq;
using NUnit.Framework;

namespace DotNetDesignPatternDemos.Structural.Adapter
{
    public class Point43
    {
        public int X;
        public int Y;

        public Point43(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected bool Equals(Point43 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point43)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Line43
    {
        public Point43 Start;
        public Point43 End;

        public Line43(Point43 start, Point43 end)
        {
            this.Start = start;
            this.End = end;
        }

        protected bool Equals(Line43 other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line43)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }

    public abstract class VectorObject43 : Collection<Line43>
    {
    }

    public class VectorRectangle43 : VectorObject43
    {
        public VectorRectangle43(int x, int y, int width, int height)
        {
            Add(new Line43(new Point43(x, y), new Point43(x + width, y)));
            Add(new Line43(new Point43(x + width, y), new Point43(x + width, y + height)));
            Add(new Line43(new Point43(x, y), new Point43(x, y + height)));
            Add(new Line43(new Point43(x, y + height), new Point43(x + width, y + height)));
        }
    }

    public class LineToPointAdapter43 : IEnumerable<Point43>
    {
        private static int count = 0;
        static Dictionary<int, List<Point43>> cache = new Dictionary<int, List<Point43>>();
        private int hash;

        public LineToPointAdapter43(Line43 line)
        {
            hash = line.GetHashCode();
            if (cache.ContainsKey(hash)) return; // we already have it

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}] (with caching)");
            //                                                 ^^^^

            List<Point43> points = new List<Point43>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point43(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point43(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point43> GetEnumerator()
        {
            return cache[hash].GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class AdapterCaching
    {
        private static readonly List<VectorObject43> vectorObjects = new List<VectorObject43>
    {
      new VectorRectangle43(1, 1, 10, 10),
      new VectorRectangle43(3, 3, 6, 6)
    };

        // the interface we have
        public static void DrawPoint(Point43 p)
        {
            Console.Write(".");
        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter43(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        public static void Start()
        {
            Draw();
            Draw();
        }
    }
}

