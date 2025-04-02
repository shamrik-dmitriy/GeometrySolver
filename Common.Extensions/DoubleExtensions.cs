using System;

namespace Common.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Сравнивает два числа вещественного типа с заданной точностью
        /// </summary>
        /// <param name="a">Первый параметр</param>
        /// <param name="b">Второй параметр</param>
        /// <param name="precision">Точность. По умолчанию 1e-6</param>
        /// <returns>True - значения равны, False - значения не равны</returns>
        public static bool CompareToPrecision(this double a, double b, double precision = 1e-6)
        {
            return Math.Abs(a - b) < precision;
        }
    }
}