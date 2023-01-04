using System;

namespace OutlandSpace.Universe.Geometry
{
    [Serializable]
    public class Point
    {
        public Point(float x, float y) => (X, Y) = (x, y);

        public float X { get; set; }
        public float Y { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Point otherPoint && this == otherPoint;
        }

        public static bool operator == (Point left, Point right) => (left.X, left.Y) == (right.X, right.Y);

        public static bool operator !=(Point left, Point right) => !(left == right);
    }
}
