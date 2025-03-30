using System;

namespace GeometrySolver.Exceptions
{
    [Serializable]
    public class GeometryTypeException : Exception
    {
        public GeometryTypeException() : base()
        {
        }

        public GeometryTypeException(string message) : base(message)
        {
        }

        public GeometryTypeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}