using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetDesignPatternDemos.Structural.Facade
{

    public class Generator
    {
        private static readonly Random random = new Random();

        public List<int> Generate(int count)
        {
            return Enumerable.Range(0, count)
              .Select(_ => random.Next(1, 6))
              .ToList();
        }
    }

    public class Splitter
    {
        public List<List<int>> Split(List<List<int>> array)
        {
            var result = new List<List<int>>();

            var rowCount = array.Count;
            var colCount = array[0].Count;

            // get the rows
            for (int r = 0; r < rowCount; ++r)
            {
                var theRow = new List<int>();
                for (int c = 0; c < colCount; ++c)
                    theRow.Add(array[r][c]);
                result.Add(theRow);
            }

            // get the columns
            for (int c = 0; c < colCount; ++c)
            {
                var theCol = new List<int>();
                for (int r = 0; r < rowCount; ++r)
                    theCol.Add(array[r][c]);
                result.Add(theCol);
            }

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            for (int c = 0; c < colCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (c == r)
                        diag1.Add(array[r][c]);
                    var r2 = rowCount - r - 1;
                    if (c == r2)
                        diag2.Add(array[r][c]);
                }
            }

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }
    }

    public class Verifier
    {
        public bool Verify(List<List<int>> array)
        {
            if (!array.Any()) return false;

            var expected = array.First().Sum();

            return array.All(t => t.Sum() == expected);
        }
    }

    public class MagicSquareGenerator
    {
        public List<List<int>> Generate(int size)
        {
            var g = new Generator();
            var s = new Splitter();
            var v = new Verifier();

            var square = new List<List<int>>();

            do
            {
                square = new List<List<int>>();
                for (int i = 0; i < size; ++i)
                    square.Add(g.Generate(size));
            } while (!v.Verify(s.Split(square)));

            return square;
        }
    }

    /// <summary>
    /// Facade Coding ExerciseA magic square is a square matrix whose rows, 
    /// columns and diagonals add up to the same value. 
    /// I have built a system that helps us construct magic squares, 
    /// but it's a little bit complicated. At the moment, 
    /// it is composed of three classes:Generator makes an array of random digits (suitably constrained)of a particular length. 
    /// You can use this generator several times to build a square matrix of required size.
    /// Splitter splits a 2Dsquare matrix into several lists containing all rows, 
    /// all columns and all diagonals.Verifier ensures that, given a list of lists, 
    /// every single list adds up to the same value.Using all of the above, 
    /// please implement a MagicSquareGenerator facade that uses all these three components to generate a valid magic square of the required size.
    /// </summary>
    public class FacadeCodingExercise
    {
        public class MyVerifier
        {
            public bool Verify(List<List<int>> array)
            {
                if (!array.Any()) return false;

                var rowCount = array.Count;
                var colCount = array[0].Count;

                var expected = array.First().Sum();

                for (var row = 0; row < rowCount; ++row)
                    if (array[row].Sum() != expected)
                        return false;

                for (var col = 0; col < colCount; ++col)
                    if (array.Select(a => a[col]).Sum() != expected)
                        return false;

                var diag1 = new List<int>();
                var diag2 = new List<int>();
                for (var r = 0; r < rowCount; ++r)
                    for (var c = 0; c < colCount; ++c)
                    {
                        if (r == c)
                            diag1.Add(array[r][c]);
                        var r2 = rowCount - r - 1;
                        if (r2 == c)
                            diag2.Add(array[r][c]);
                    }

                return diag1.Sum() == expected && diag2.Sum() == expected;
            }
        }

        private static string SquareToString(List<List<int>> square)
        {
            var sb = new StringBuilder();
            foreach (var row in square)
            {
                sb.AppendLine(string.Join(" ",
                  row.Select(x => x.ToString())));
            }

            return sb.ToString();
        }

        public static void Start()
        {
            var gen = new MagicSquareGenerator();
            var square = gen.Generate(3);

            Console.WriteLine(SquareToString(square));

            var v = new MyVerifier();
            Console.WriteLine(v.Verify(square));
        }
    }
}
