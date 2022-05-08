using System;
using System.Windows.Media;
using System.Numerics;
using System.Windows;
using System.Diagnostics;

namespace Roberto_WPF.GameScripts
{
    public abstract class Entity
    {
        public Guid id { get; protected set; }
        public Vector2 Position { get; set; }

        /// <summary>
        /// The angle of rotation in radians
        /// </summary>
        public float Rotation { get; set; }
        public ShapeEnum Shape { get; protected set; }

        //X -> Width || Y -> Height
        public Vector2 ShapeDimensions { get; protected set; }
        public Color EntityColor { get; protected set; }

        //This is to use if the shape is custom
        private PointCollection _vertices;

        public PointCollection Vertices 
        {
            get
            {
                return _vertices;
            }

            protected set{ _vertices = value; }
        }

        protected PointCollection GetRotatedVertices(ShapeEnum s)
        {
            switch (s)
            {
                case ShapeEnum.Rectangle:
                    var angles = new float[4];
                    var vertices = new PointCollection();

                    //Add points
                    while (vertices.Count < 4)
                    {
                        vertices.Add(new Point(0, 0));
                    }

                    
                    //Calculates the distance of the first vertex to the center
                    //r = V(width^2 + height^2)
                    var radius = MathF.Sqrt(MathF.Pow(ShapeDimensions.X/2, 2) + MathF.Pow(ShapeDimensions.Y/2, 2));

                    //This calculates the angle of the vertex when Rotation = 0
                    //r * cos(o) = width/2 -> o = arccos((width/2)/r)
                    var angle = MathF.Acos((ShapeDimensions.X / 2) / radius);

                    //Top-left
                    angles[0] = MathF.PI - angle;

                    //Top-right
                    angles[1] = angle;

                    //Bottom-right
                    //It can be just -angle but I decided to just allow positive angles for simplification
                    angles[2] = 2 * MathF.PI - angle;

                    //Bottom-left                    
                    angles[3] = angle + MathF.PI;

                    for (int i = 0; i < 4; i++)
                    {
                        vertices[i] = (new Point(radius * MathF.Cos(angles[i] + Rotation), radius * MathF.Sin(angles[i] + Rotation)));
                    }

                    return vertices;

                case ShapeEnum.Triangle:
                    throw new NotImplementedException("Not available yet");

                case ShapeEnum.Custom:
                    throw new NotImplementedException("Not available yet"); 

                default:
                    throw new NotImplementedException("Not available yet");
            }
        }
    }
}