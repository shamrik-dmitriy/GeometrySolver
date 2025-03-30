using System;
using Geometry.Models;

namespace Geometry.Utils
{
    public static class GeometryUtils
    {
        /// <summary>
        ///     Получает квадрат расстояния между двумя точками
        /// </summary>
        /// <param name="p1">Первая точка</param>
        /// <param name="p2">Вторая точка</param>
        /// <returns>Квадрат расстояния между двумя точками</returns>
        public static double GetDistanceSquared(Point p1, Point p2)
        {
            return Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2);
        }

        /// <summary>
        ///     Получает расстояние между двумя точками на основании вычисления корня из квадрата расстояния между двумя точками
        /// </summary>
        /// <param name="p1">Первая точка</param>
        /// <param name="p2">Вторая точка</param>
        /// <returns>Расстояние между двумя точками</returns>
        public static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(GetDistanceSquared(p1, p2));
        }
    }
}