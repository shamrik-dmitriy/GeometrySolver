using System;
using System.Collections.Generic;
using System.Linq;
using Geometry.Models;

namespace GeometrySolver.Extensions
{
    public static class SortExtensions
    {
        /// <summary>
        /// Сортирует точки по углу относительно центра с использованием <see cref="Math.Atan2"/>
        /// </summary>
        /// <param name="points">Набор точек</param>
        /// <returns>Набор  отсортированных по углу относительно центра точек</returns>
        public static IEnumerable<Point> SortToFormASquare(this IEnumerable<Point> points)
        {
            var center = (
                X: points.Average(p => p.X),
                Y: points.Average(p => p.Y)
            );

            return points.OrderBy(p =>
                Math.Atan2(p.Y - center.Y, p.X - center.X)).ToArray();
        }
    }
}