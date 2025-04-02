using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Models;
using GeometrySolver.Interfaces;

namespace GeometrySolver
{
    public abstract class ParallelogramSolver : IFigure
    {
        public IEnumerable<Point> Points { get; }

        public ParallelogramSolver(IEnumerable<Point> points)
        {
            Points = points;
        }

        /// <summary>
        /// Выполняет базовую валидацию параллелограмма:
        /// - имеет точки
        /// - точек не больше и не меньше 4-х
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывает исключение, если точек 0</exception>
        /// <exception cref="InvalidOperationException">Выбрасывает исключение, если точек не 4</exception>
        public void Validate()
        {
            BaseParallelogramValidate();
        }

        protected void BaseParallelogramValidate()
        {
            if (!Points.Any() || Points.Count() != 4)
                throw new ArgumentException("Параллелограмм должен иметь 4 точки");
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return "Объект - параллелограмм";
        }
    }
}