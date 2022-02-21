using System;
using System.Numerics;

namespace Roberto_WPF
{
    public static class GeometryCalculation
    {
        public static bool IsInsideElipse(Vector2 centerPosition, Vector2 dimensions, Vector2 pointToTest)
        {
            //Elipse equation: (x + c)^2 / a^2 + (y + d)^2 / b ^2 = 1
            var x = pointToTest.X;
            var y = pointToTest.Y;
            var a = dimensions.X / 2;
            var b = dimensions.Y / 2;
            var c = centerPosition.X;
            var d = centerPosition.Y;

            //If the result of the elipse equation is: 
            //result < 1 --> the point is inside the elipse
            //result = 1 --> the point is part of the elipse
            //result > 1 --> the point is outside the elipse
            var result = Math.Pow(x - c, 2) / Math.Pow(a, 2) + Math.Pow(y - d, 2) / Math.Pow(b, 2);
            if (result <= 1)
                return true;
            else
                return false;
        }

        public static bool IsInsideTriangle(Vector2 centerPosition, Vector2 dimensions, Vector2 pointToTest, Vector2[] vertices)
        {
            var x = pointToTest.X;
            var y = pointToTest.Y;
            var a = dimensions.X / 2;
            var b = dimensions.Y / 2;
            var c = centerPosition.X;
            var d = centerPosition.Y;

            Vector2 point1 = vertices[0];
            Vector2 point2 = vertices[1];
            Vector2 point3 = vertices[2];
            
            //switch (side)
            //{
            //    //Triangle is pointing up
            //    case 0:
            //        point1 = new Vector2( c, d + b );
            //        point2 = new Vector2( c - a, d - b );
            //        point3 = new Vector2( c + a, d - b );
            //        break;

            //    //Triangle is pointing right
            //    case 1:
            //        point1 = new Vector2( c + a, d );
            //        point2 = new Vector2( c - a, d + b );
            //        point3 = new Vector2( c - a, d - b );
            //        break;

            //    //Triangle is pointing down
            //    case 2:
            //        point1 = new Vector2( c, d - b );
            //        point2 = new Vector2( c - a, d + b );
            //        point3 = new Vector2( c + a, d + b );
            //        break;

            //    //Triangle is pointing left
            //    case 3:
            //        point1 = new Vector2( c - a, d );
            //        point2 = new Vector2( c + a, d + b );
            //        point3 = new Vector2( c + a, d - b );
            //        break;

            //    default:
            //        break;
            //}

            var line12 = new Vector2( point1.X - point2.X, point1.Y - point2.Y );
            //Line equation: ax + by + c = 0
            //To get the equation from 2 points:
            //a = (y1 - y2)
            //b = (x2 - x1)
            //c = x1 * y2 - x2 * y1
            var linea = point1.Y - point2.Y;
            var lineb = point2.X - point1.X;
            var linec = point1.X * point2.Y - point1.Y * point2.X;

            var result1 = linea * point3.X + lineb * point3.Y + linec;
            var result2 = linea * x + lineb * y + linec;

            //Here I care only about the signal of the results so I'm making they 2 have a value 1 but preserving the signal
            //if one result is -10 it'll be -1; if 24 --> 1; if -387 --> -1
            var result1Abs = 0f;
            var result2Abs = 0f;

            if (Math.Abs(result1) != 0)
            {
                result1Abs = result1 / (Math.Abs(result1));
            }

            if (Math.Abs(result2) != 0)
            {
                result2Abs = result2 / (Math.Abs(result2));
            }

            if (result2 == 0)
                return true;

            if (result1Abs != result2Abs)
                return false;

            //Calculation for point1 and point3
            var line13 = new Vector2( point1.X - point3.X, point1.Y - point3.Y );

            linea = point1.Y - point3.Y;
            lineb = point3.X - point1.X;
            linec = point1.X * point3.Y - point1.Y * point3.X;

            result1 = linea * point2.X + lineb * point2.Y + linec;
            result2 = linea * x + lineb * y + linec;

            result1Abs = result1 / (Math.Abs(result1));
            result2Abs = result2 / (Math.Abs(result2));


            if (result2 == 0)
                return true;

            if (result1Abs != result2Abs)
                return false;

            //Calculation for point2 and point3
            var line23 = new Vector2( point2.X - point3.X, point2.Y - point3.Y);

            linea = point2.Y - point3.Y;
            lineb = point3.X - point2.X;
            linec = point2.X * point3.Y - point2.Y * point3.X;

            result1 = linea * point1.X + lineb * point1.Y + linec;
            result2 = linea * x + lineb * y + linec;

            result1Abs = result1 / (Math.Abs(result1));
            result2Abs = result2 / (Math.Abs(result2));

            if (result2 == 0)
                return true;

            if (result1Abs != result2Abs)
                return false;

            return true;

        }
    }
}