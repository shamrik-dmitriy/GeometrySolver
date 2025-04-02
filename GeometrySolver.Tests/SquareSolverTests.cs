using System;
using System.Collections.Generic;
using FluentAssertions;
using Geometry.Models;
using GeometrySolver.Exceptions;
using GeometrySolver.Extensions;
using Xunit;

namespace GeometrySolver.Tests
{
    public class SquareSolverTests
    {
        #region Data

        public static TheoryData<IEnumerable<Point>, Type, string> InvalidSquarePointsData =>
            new()
            {
                { new List<Point>() { }, typeof(ArgumentException), "Количество точек должно быть больше 0" },
                {
                    new List<Point>() { new Point(1, 1), new Point(1, 1) }, typeof(InvalidOperationException),
                    "Параллелограмм должен иметь 4 точки"
                },
                {
                    new List<Point>()
                        { new Point(1, 1), new Point(1, 1), new Point(1, 1), new Point(1, 1), new Point(1, 1) },
                    typeof(InvalidOperationException), "Параллелограмм должен иметь 4 точки"
                },
                {
                    new List<Point>()
                        { new Point(11.2, 0), new Point(-90.21, 21), new Point(0, 0), new Point(10.212, 123) },
                    typeof(GeometryTypeException), "Точки не образуют квадрат"
                },
                {
                    new List<Point>()
                        { new(0.2, 0.4), new(4.3, 0.4), new(4.3, 2.7), new(0.2, 2.7) },
                    typeof(GeometryTypeException), "Фигура не является квадратом"
                }
            };

        public static TheoryData<IEnumerable<Point>, double> ValidSquarePointsDataForPerimeter =>
            new()
            {
                { new List<Point>() { new(0, 1), new(1, 0), new(0, 0), new(1, 1) }, 4 },
                { new List<Point>() { new(0, -1), new(-1, 0), new(0, 0), new(-1, -1) }, 4 },
                { new List<Point>() { new(-2.4, -1.3), new(1.3, -1.3), new(1.3, 2.4), new(-2.4, 2.4) }, 14.8 },
                { new List<Point>() { new(-3.7, -4.5), new(3.1, -4.5), new(3.1, 2.3), new(-3.7, 2.3) }, 27.2 },
            };

        public static TheoryData<IEnumerable<Point>, double> ValidSquarePointsDataForArea =>
            new()
            {
                { new List<Point>() { new(0, 1), new(1, 0), new(0, 0), new(1, 1) }, 1 },
                { new List<Point>() { new(0, -1), new(-1, 0), new(0, 0), new(-1, -1) }, 1 },
                { new List<Point>() { new(-2.4, -1.3), new(1.3, -1.3), new(1.3, 2.4), new(-2.4, 2.4) }, 13.69 },
                { new List<Point>() { new(-3.7, -4.5), new(3.1, -4.5), new(3.1, 2.3), new(-3.7, 2.3) }, 46.24 },
            };

        #endregion

        #region Tests

        [Theory]
        [MemberData(nameof(InvalidSquarePointsData))]
        public void Constructor_Should_ThrowException_When_Points_Not_Length_4_Test(IEnumerable<Point> points,
            Type exceptionType, string exceptionMessage)
        {
            Action act = () => new SquareSolver(points);

            if (exceptionType == typeof(ArgumentException))
            {
                act.Should().Throw<ArgumentException>().WithMessage(exceptionMessage);
            }
            else if (exceptionType == typeof(InvalidOperationException))
            {
                act.Should().Throw<InvalidOperationException>().WithMessage(exceptionMessage);
            }
            else if (exceptionType == typeof(GeometryTypeException))
            {
                act.Should().Throw<GeometryTypeException>().WithMessage(exceptionMessage);
            }
        }

        [Theory]
        [MemberData(nameof(ValidSquarePointsDataForPerimeter))]
        public void Perimeter_Square_Is_Normal_Data_Test(IEnumerable<Point> points, double expected)
        {
            var squareSolver = new SquareSolver(points);
            var perimeter = squareSolver.GetPerimeter();
            Assert.True(perimeter.CompareToPrecision(expected));
        }

        [Theory]
        [MemberData(nameof(ValidSquarePointsDataForArea))]
        public void Area_Square_Is_Normal_Data_Test(IEnumerable<Point> points, double expected)
        {
            var squareSolver = new SquareSolver(points);
            var area = squareSolver.GetArea();
            Assert.True(area.CompareToPrecision(expected));
        }

        #endregion
    }
}