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
        public static TheoryData<IEnumerable<Point>, Type, string> InvalidSquarePointsData =>
            new TheoryData<IEnumerable<Point>, Type, string>
            {
                { new List<Point>() { }, typeof(ArgumentException), "Количество точек должно быть больше 0" },
                { new List<Point>() { new Point(1,1), new Point(1,1) }, typeof(InvalidOperationException), "Квадрат должен иметь 4 точки" },
                { new List<Point>() { new Point(1,1), new Point(1,1), new Point(1,1), new Point(1,1), new Point(1,1) }, typeof(InvalidOperationException), "Квадрат должен иметь 4 точки" },
                { new List<Point>() { new Point(11.2, 0), new Point(-90.21, 21), new Point(0, 0), new Point(10.212, 123) }, typeof(GeometryTypeException), "Фигура не является квадратом" },
            };

        [Theory]
        [MemberData(nameof(InvalidSquarePointsData))]
        public void Constructor_Should_ThrowException_When_Points_Not_Length_4_Test(IEnumerable<Point> points, Type exceptionType, string exceptionMessage)
        {
            Action act = () => new SquareSolver(points);

            if (exceptionType == typeof(ArgumentException))
            {
                act.Should().Throw<ArgumentException>().WithMessage(exceptionMessage);
            }
            else if (exceptionType == typeof(InvalidOperationException ))
            {
                act.Should().Throw<InvalidOperationException>().WithMessage(exceptionMessage);
            }         
            else if (exceptionType == typeof(GeometryTypeException ))
            {
                act.Should().Throw<GeometryTypeException>().WithMessage(exceptionMessage);
            }
        }

        public static TheoryData<IEnumerable<Point>, double> ValidSquarePointsDataForPerimeter =>
            new TheoryData<IEnumerable<Point>, double>
            {
                { new List<Point>() { new(0, 1), new(1, 0), new(0, 0), new(1, 1) }, 4 },
                { new List<Point>() { new(0, -1), new(-1, 0), new(0, 0), new(-1, -1) }, 4 },
                { new List<Point>() { new(-2.4, -1.3), new(1.3, -1.3), new(1.3, 2.4), new(-2.4, 2.4) }, 14.8 },
                { new List<Point>() { new(-3.7, -4.5), new(3.1, -4.5), new(3.1, 2.3), new(-3.7, 2.3) }, 27.2 },
            };

        [Theory]
        [MemberData(nameof(ValidSquarePointsDataForPerimeter))]
        public void TestPerimeters(IEnumerable<Point> points, double expected)
        {
            var squareSolver = new SquareSolver(points);
            var perimeter = squareSolver.GetPerimeter();
            Assert.True(perimeter.CompareToPrecision(expected));
        }

        public void TestAreas(IEnumerable<Point> points, double expected)
        {
        }
    }
}