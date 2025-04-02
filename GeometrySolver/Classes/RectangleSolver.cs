using System.Collections.Generic;
using System.Linq;
using Geometry.Models;
using Geometry.Utils;

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

        public override void Validate()
        {
            base.Validate();
            //Противоположные стороны равны, диагонали равны
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Объект - прямоугольник";
        }
    }
}