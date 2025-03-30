using System;
using Geometry.Models;

namespace GeometrySolver
{
    static class Program
    {
        static void Main(string[] args)
        {
            var square = new SquareSolver(new[] { new Point(0, 1), new Point(1, 0), new Point(0, 0), new Point(1, 1) });
            Console.WriteLine($"Площадь квадрата: {square.GetArea()}, Периметр квадрата {square.GetPerimeter()}");
        }
    }
}