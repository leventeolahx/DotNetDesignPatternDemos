using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.Factory
{
    public class Point
    {
        private double x, y;

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // constructor without factory
        public Point(double a,
          double b, // names do not communicate intent
          CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }

        // factory property
        public static Point Origin => new Point(0, 0);

        // singleton field
        public static Point Origin2 = new Point(0, 0);

        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            //...
            return null;
        }

        // enum for constructor, to differenciate it in the constructort (without factory)
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        // make it lazy
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }
    }

    // the point factory is moved out from Point class
    class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }
    }

    public static class PointExample
    {
        public static void Start() 
        {
            // this is the old way to do it, without factory
            var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);

            // access the factory property
            var origin = Point.Origin;

            // with factory
            var p2 = Point.Factory.NewCartesianPoint(1, 2);
        }
    }
}
