using System.Collections.Generic;
using Geometry.Models;
using Geometry.Utils;

namespace GeometrySolver.Interfaces
{
    public interface IFigure
    {
        IEnumerable<Point> Points { get; }
        double GetArea();
        double GetPerimeter();
        
        void Validate();
    }
}