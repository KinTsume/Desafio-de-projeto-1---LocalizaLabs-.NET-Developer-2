using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Roberto_WPF.Utility
{
    static class MathFunctions
    {
        /// <summary>
        /// Calculate the angle between a vector and the x axis
        /// </summary>
        /// <param name="vectorEnd">The point where the vector is pointing</param>
        /// <param name="vectorOrigin">The origin point where the vector start</param>
        /// <returns>The angle (in radians) of the given vector relative to the x axis</returns>
        public static double AngleOfVector(Point vectorEnd, Point vectorOrigin)
        {
            var differenceVector = new Point(vectorEnd.X - vectorOrigin.X, vectorEnd.Y - vectorOrigin.Y);
            var radius = Math.Sqrt(Math.Pow(differenceVector.X, 2) + Math.Pow(differenceVector.Y, 2));
            var angle    = radius != 0 ? Math.Acos(differenceVector.X / radius) : 0;
            var angleSignal = radius != 0 ? Math.Asin(differenceVector.Y / radius) : 0;

            angleSignal = angleSignal != 0 ? angleSignal / Math.Abs(angleSignal) : 1;
            angle *= angleSignal;

            return angle;
        }

        /// <summary>
        /// Calculate the angle between a vector and the x axis
        /// </summary>
        /// <param name="vectorEnd">The point where the vector is pointing</param>
        /// <param name="vectorOrigin">The origin point where the vector start</param>
        /// <returns>The angle (in radians) of the given vector relative to the x axis</returns>
        public static float AngleOfVector(Vector2 vectorEnd, Vector2 vectorOrigin)
        {
            var differenceVector = new Vector2(vectorEnd.X - vectorOrigin.X, vectorEnd.Y - vectorOrigin.Y);
            var radius = MathF.Sqrt(MathF.Pow(differenceVector.X, 2) + MathF.Pow(differenceVector.Y, 2));
            var angle = radius != 0 ? MathF.Acos(differenceVector.X / radius) : 0;
            var angleSignal = radius != 0 ? MathF.Asin(differenceVector.Y / radius) : 0;

            angleSignal = angleSignal != 0 ? angleSignal / MathF.Abs(angleSignal) : 1;
            angle *= angleSignal;

            return angle;
        }

        /// <summary>
        /// Calculate the angle between two vectors.
        /// </summary>
        /// <param name="vector1">The first vector</param>
        /// <param name="vector2">The second vector</param>
        /// <returns>The angle (in radians) between the two vectors. The angle is calculated from the first vector to the second.</returns>
        public static float AngleBetweenVectors(Vector2 vector1, Vector2 vector2)
        {
            var origin = Vector2.Zero;
            var angle1 = AngleOfVector(vector1, origin);
            var angle2 = AngleOfVector(vector2, origin);

            var angleBetween = angle2 - angle1;
            return angleBetween;
        }
    }
}
