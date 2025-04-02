using System;
using Common.Extensions;
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

        /// <summary>
        /// Проверяет перпендикулярны ли два вектора между собой
        /// </summary>
        /// <param name="p1">Начальная точка первого вектора</param>
        /// <param name="p2">Конечная точка первого вектора</param>
        /// <param name="p3">Начальная точка второго вектора</param>
        /// <param name="p4">Конечная точка второго вектора</param>
        /// <returns>True - векторы перпендикулярны, False - векторы не перпендикулярны</returns>
        public static bool IsPerpendicularVectors(Point p1, Point p2, Point p3, Point p4)
        {
            var firstVector = new Point(p2.X - p1.X, p2.Y - p1.Y);
            var secondVector = new Point(p4.X - p3.X, p4.Y - p3.Y);

            var isPerpendicular = firstVector.X * secondVector.X + firstVector.Y * secondVector.Y;
            return isPerpendicular.CompareToPrecision(0);
        }
    }
}