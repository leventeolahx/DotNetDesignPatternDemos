using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Adapter
{

    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;

        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }

        public int Width => square.Side;
        public int Height => square.Side;
    }

    /// <summary>
    /// You are given an IRectangle interface and an extension method on it. Try to define a SquareToRectangleAdapter that adapts the Square to the IRectangle interface.
    /// </summary>
    public class AdapterCodingExercise
    {
        public static void Start()
        {

        }
    }
}
