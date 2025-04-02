using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Models;
using Geometry.Utils;
using GeometrySolver.Exceptions;
using GeometrySolver.Extensions;

namespace GeometrySolver
{
    public class SquareSolver : RectangleSolver
    {
        private readonly IEnumerable<Point> _points;
        public IEnumerable<Point> Points { get; }

        public override double GetArea()
        {
            return Math.Pow(GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1)), 2);
        }

        public override double GetPerimeter()
        {
            return 4 * GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1));
        }

        public SquareSolver(IEnumerable<Point> points) : base(points)
        {
            base.Validate();

            points = points.SortToFormASquare();

            _points = points;

            Validate();
        }

        public override void Validate()
        {
            var sideFirst = GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1));
            var sideSecond = GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(2));
            var sideThird = GeometryUtils.GetDistance(_points.ElementAt(2), _points.ElementAt(3));
            var sideFourth = GeometryUtils.GetDistance(_points.ElementAt(3), _points.ElementAt(0));

            var diagonal1 = GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(2));
            var diagonal2 = GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(3));

            var isSquare = false;

            if (sideFirst.CompareToPrecision(sideSecond))
            {
                if (sideSecond.CompareToPrecision(sideThird))
                {
                    if (sideThird.CompareToPrecision(sideFourth))
                    {
                        if (diagonal1.CompareToPrecision(diagonal2))
                        {
                            if (diagonal1.CompareToPrecision(Math.Sqrt(2) * sideFirst))
                            {
                                isSquare = true;
                            }
                        }
                    }
                }
            }

            if (!isSquare)
                throw new GeometryTypeException("Точки не образуют квадрат");
        }

        public override string ToString()
        {
            return "Объект - квадрат";
        }
    }
}