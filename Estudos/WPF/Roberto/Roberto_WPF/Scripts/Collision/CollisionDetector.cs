using Roberto_WPF.GameScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Roberto_WPF.Scripts.Collision
{
    public static class CollisionDetector
    {
        static public bool verifyCollision(PointCollection points, Point testPoint)
        {
            var point1 = points[0];
            var point2 = points[1];
            var point3 = points[2];

            //First comparation
            var coeficientsArray = calculateLine(point1, point2);

            //general equation: ax + by + c = 0
            var value1 = coeficientsArray[0] * point3.X + coeficientsArray[1] * point3.Y + coeficientsArray[2];
            var value2 = coeficientsArray[0] * testPoint.X + coeficientsArray[1] * testPoint.Y + coeficientsArray[2];

            value1 = value1 / Math.Abs(value1);
            value2 = value2 / Math.Abs(value2);

            if (value1 != value2 || value2 == 0)
            {
                return false;
            }

            //Second comparation
            coeficientsArray = calculateLine(point2, point3);
            value1 = coeficientsArray[0] * point1.X + coeficientsArray[1] * point1.Y + coeficientsArray[2];
            value2 = coeficientsArray[0] * testPoint.X + coeficientsArray[1] * testPoint.Y + coeficientsArray[2];

            value1 = value1 / Math.Abs(value1);
            value2 = value2 / Math.Abs(value2);

            if (value1 != value2 || value2 == 0)
            {
                return false;
            }

            //Third comparation
            coeficientsArray = calculateLine(point3, point1);
            value1 = coeficientsArray[0] * point2.X + coeficientsArray[1] * point2.Y + coeficientsArray[2];
            value2 = coeficientsArray[0] * testPoint.X + coeficientsArray[1] * testPoint.Y + coeficientsArray[2];

            value1 = value1 / Math.Abs(value1);
            value2 = value2 / Math.Abs(value2);

            if (value1 != value2)
            {
                return false;
            }

            return true;

        }

        static public double[] calculateLine(Point point1, Point point2)
        {
            //(y - y1) = m(x - x1)
            //Reorganing: mx - mx1 - y + y1 = 0 --> mx - y + (y1 - mx1) = 0
            //m = (y2 - y1) / (x2 - x1)
            //general equation: ax + by + c = 0
            //
            var coeficient = (point2.Y - point1.Y) / (point2.X - point1.X);

            //prevent divisor to be 0 which will result in errors
            if (point2.X == point1.X)
            {
                coeficient = 0;
            }

            var a = coeficient;
            var b = -1;
            var c = -point1.X * coeficient + point1.Y;

            var array = new double[3]
            {
                a,
                b,
                c
            };

            return array;
        }

        /// <summary>
        /// Check if 2 entities are colliding or not
        /// </summary>
        /// <param name="first">The object that is believed to being collided</param>
        /// <param name="second">The object that is believed to be colliding</param>
        public static CollisionInfo checkCollisionBetween(Entity first, DynamicEntity second)
        {
            //It will always have a dynamic entity because 2 static entities cannot collide (they do not move)
            for(int i = 0; i < first.Vertices.Count; i++)
            {
                PointCollection collection;
                if (i != first.Vertices.Count - 1) {
                    //Makes a triangle between 2 neighbour points and the center
                    collection = new PointCollection()
                    {
                        first.Vertices[i],
                        first.Vertices[i+1],
                        new Point(first.Position.X, first.Position.Y)
                    };
                } else
                {
                    collection = new PointCollection()
                    {
                        first.Vertices[i],
                        first.Vertices[0],
                        new Point(first.Position.X, first.Position.Y)
                    };
                }

                foreach (Point p in second.Vertices)
                {
                    if(verifyCollision(collection, p))
                    {
                        var details = new CollisionInfo()
                        {
                            collidingEntity = second,
                            CollidedEntity = first
                        };

                        return details;
                    } 
                }
            }

            return null;

        }
    }
}
