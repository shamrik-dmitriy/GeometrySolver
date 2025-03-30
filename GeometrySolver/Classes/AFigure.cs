using System.Collections.Generic;
using Geometry.Models;

namespace GeometrySolver
{
    public abstract class AFigure
    {
        public abstract void Validate(IEnumerable<Point> points);
    }
}