using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Bridge
{
    // code to refactor

    //public abstract class Shape
    //{
    //  public string Name { get; set; }
    //}

    //public class Triangle : Shape
    //{
    //  public Triangle() => Name = "Circle";
    //}

    //public class Square : Shape
    //{
    //  public Square() => Name = "Square";
    //}

    //public class VectorSquare
    //{
    //  public override string ToString() => "Drawing {Name} as lines";
    //}

    //public class RasterSquare
    //{
    //  public override string ToString() => "Drawing {Name} as pixels";
    //}

    //// imagine VectorTriangle and RasterTriangle are here too



    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        private IRenderer rendering;

        protected Shape(IRenderer rendering)
        {
            this.rendering = rendering;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Drawing {Name} as {rendering.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer strategy) : base(strategy)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer rendering) : base(rendering)
        {
            Name = "Square";
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs
        {
            get { return "pixels"; }
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs
        {
            get { return "lines"; }
        }
    }
              

    /// <summary>
    /// You are given an example of an inheritance hierarchy which results in Cartesian-product duplication. 
    /// Please refactor this hierarchy, giving the base class Shape a constructor that takes an interface IRenderer defined as 
    /// interface IRenderer{ string WhatToRenderAs { get; }} 
    /// as well as VectorRenderer and RasterRenderer classes.Each implementer of the Shape abstract class should have a constructor that 
    /// takes an IRenderer such that, subsequently, each constructed object's ToString() operates correctly, for example, 
    /// new Triangle(new RasterRenderer()).ToString() // returns "Drawing Triangle as pixels"
    /// </summary>
    public class BridgeCodingExercise
    {
        public static void Start()
        {
            var vectorRenderer = new VectorRenderer();
            var square = new Square(vectorRenderer);
            Console.WriteLine(square);
        }
    }
}
