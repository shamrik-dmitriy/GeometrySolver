using System;
using System.Collections.Generic;
using FluentAssertions;
using Geometry.Models;
using GeometrySolver.Exceptions;
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

        public static TheoryData<IEnumerable<Point>, double> ValidSquarePointsData =>
            new TheoryData<IEnumerable<Point>, double>
            {
                { new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(0, 0), new Point(1, 1) }, 4 },
            };

        [Theory]
        [MemberData(nameof(ValidSquarePointsData))]
        public void TestPerimeters(IEnumerable<Point> points, double expected)
        {

        }

        public void TestAreas(IEnumerable<Point> points, double expected)
        {
        }
    }
}