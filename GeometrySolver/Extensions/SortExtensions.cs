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

        /// <summary>
        /// Сортирует точки по X, затем по Y. Если сортировка по Х имеет одинаковые точки, то такие значения будут отсортированы по Y
        /// </summary>
        /// <param name="points">Набор точек</param>
        /// <returns>Отсортированный набор точек</returns>
        public static IEnumerable<Point> SortByXY(this IEnumerable<Point> points)
        {
            return points.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
        }
    }
}