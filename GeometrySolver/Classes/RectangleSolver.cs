using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Geometry.Models;
using Geometry.Utils;
using GeometrySolver.Exceptions;

namespace GeometrySolver
{
    public class RectangleSolver : ParallelogramSolver
    {
        private readonly IEnumerable<Point> _points;
        public IEnumerable<Point> Points { get; }

        public RectangleSolver(IEnumerable<Point> points) : base(points)
        {
            _points = points;
        }

        public override double GetArea()
        {
            return GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1)) *
                   GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(2));
        }

        public override double GetPerimeter()
        {
            return 2 * (GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1)) +
                        GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(2)));
        }

        /// <summary>
        /// Валидирует набор точек на предмет образования ими прямоугольника
        /// - высчитываем длины сторон
        /// - проверяем скалярное произведение
        /// - проверяем что противополжные стороны равны 
        /// <exception cref="GeometryTypeException">Выбрасывает исключение, если точки не образуют прямоугольник</exception>
        /// </summary>
        public override void Validate()
        {
            base.Validate();

            if (
                !GeometryUtils.IsPerpendicularVectors(_points.ElementAt(0), _points.ElementAt(1), _points.ElementAt(1),
                    _points.ElementAt(2)) ||
                !GeometryUtils.IsPerpendicularVectors(_points.ElementAt(1), _points.ElementAt(2), _points.ElementAt(2),
                    _points.ElementAt(3)) ||
                !GeometryUtils.IsPerpendicularVectors(_points.ElementAt(2), _points.ElementAt(3), _points.ElementAt(3),
                    _points.ElementAt(0)))
                throw new GeometryTypeException("Точки не образуют прямоугольник. Углы не прямые");

            var sideFirst = GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(1));
            var sideSecond = GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(2));
            var sideThird = GeometryUtils.GetDistance(_points.ElementAt(2), _points.ElementAt(3));
            var sideFourth = GeometryUtils.GetDistance(_points.ElementAt(3), _points.ElementAt(0));

            var diagonal1 = GeometryUtils.GetDistance(_points.ElementAt(0), _points.ElementAt(2));
            var diagonal2 = GeometryUtils.GetDistance(_points.ElementAt(1), _points.ElementAt(3));

            if (!sideFirst.CompareToPrecision(sideSecond) || !sideThird.CompareToPrecision(sideFourth))
                throw new GeometryTypeException("Точки не образуют прямоугольник. Противоположные стороны не равны");

            if (!diagonal1.CompareToPrecision(diagonal2))
                throw new GeometryTypeException("Точки не образуют прямоугольник. Диагонали не равны");
        }

        public override string ToString()
        {
            return "Объект - прямоугольник";
        }
    }
}