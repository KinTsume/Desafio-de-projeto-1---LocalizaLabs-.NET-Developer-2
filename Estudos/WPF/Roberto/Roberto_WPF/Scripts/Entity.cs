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
        public float Rotation { get; set; }
        public ShapeEnum Shape { get; protected set; }

        //X -> Width || Y -> Height
        public Vector2 ShapeDimensions { get; protected set; }
        public Color EntityColor { get; protected set; }

        //This is to use if the shape is custom
        private PointCollection _vertices;

        public PointCollection Vertices 
        {
            //This is needed because the vertices position are defined relative to the center of the object
            //but canvas use absolute values to draw, so this get the relative values and change to absolute values
            get
            {
                var verticesAux = new PointCollection();
                for (int i = 0; i < _vertices.Count; i++)
                {
                    verticesAux.Add(new Point(_vertices[i].X + Position.X, _vertices[i].Y + Position.Y));
                }

                return verticesAux;
            }

            protected set{ _vertices = value; }
        }

        protected void SetShape(ShapeEnum s)
        {
            switch (s)
            {
                case ShapeEnum.Rectangle:
                    var angles = new float[4];

                    //Since it's a rectangle it'll have 4 vertices
                    //Removes exceeding points
                    while (_vertices.Count > 4)
                    {
                        _vertices.RemoveAt(_vertices.Count - 1);
                    }

                    //Adds missing points
                    while (_vertices.Count < 4)
                    {
                        _vertices.Add(new Point(0, 0));
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
                        _vertices[i] = (new Point(radius * MathF.Cos(angles[i] + Rotation), radius * MathF.Sin(angles[i] + Rotation)));
                    }

                    break;

                case ShapeEnum.Triangle:
                    break;

                case ShapeEnum.Custom:
                    break;

                default:
                    break;
            }
        }
    }
}