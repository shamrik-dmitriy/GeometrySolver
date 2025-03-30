using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Models;
using Geometry.Utils;
using GeometrySolver.Exceptions;
using GeometrySolver.Interfaces;

namespace GeometrySolver
{
    public class SquareSolver : AFigure, IFigure
    {
        private readonly IEnumerable<Point> _points;
        public IEnumerable<Point> Points { get; }

        public double GetArea()
        {
            return Math.Pow(GeometryUtils.GetDistance(_points.First(), _points.Skip(1).First()), 2);
        }

        public double GetPerimeter()
        {
            return 4 * GeometryUtils.GetDistance(_points.First(), _points.Skip(1).First());
        }

        public SquareSolver(IEnumerable<Point> points)
        {
            Validate(points);

            _points = points;
        }

        public override void Validate(IEnumerable<Point> points)
        {
            if (!points.Any())
                throw new ArgumentException("Количество точек должно быть больше 0");

            if (points.Count() != 4)
                throw new InvalidOperationException("Квадрат должен иметь 4 точки");

            // Сортируем в порядке возрастания квадратов расстояний. 
            // Растояние между точками сторон для квадрата одинаково, а для диагоналей в два раза больше стороны,
            // следовательно первые 4 значения должны быть одинаковы, а последние два в два раза больше стороны. 
            var distances =
                points.SelectMany((p1, index) =>
                        points.Skip(index + 1).Select(p2 => GeometryUtils.GetDistanceSquared(p1, p2))).OrderBy(x => x)
                    .ToArray();

            var isValid =
                // Если в точках есть несколько одинаковых, то расстояние между точками будет 0
                distances[0] > 0 &&
                distances[0] == distances[1] &&
                distances[1] == distances[2] &&
                distances[2] == distances[3] &&
                distances[4] == distances[5] &&
                // Проверка диагонали
                distances[4] == 2 * distances[0];

            if (!isValid)
                throw new GeometryTypeException("Фигура не является квадратом");
        }
    }
}