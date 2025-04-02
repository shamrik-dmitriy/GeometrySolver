using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Models;
using GeometrySolver.Interfaces;

namespace GeometrySolver
{
    public abstract class ParallelogramSolver : AFigure, IFigure
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
        public override void Validate()
        {
            if (!Points.Any())
                throw new ArgumentException("Количество точек должно быть больше 0");

            if (Points.Count() != 4)
                throw new InvalidOperationException("Параллелограмм должен иметь 4 точки");
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return "Объект - параллелограмм";
        }
    }
}