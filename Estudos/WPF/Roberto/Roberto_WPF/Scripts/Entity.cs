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

                    ////Top-left
                    //angles[0] = Math.PI - angle;
                    //Vertices[0] = new Vector2(Position.X + (float) (radius * Math.Cos(angles[0] + Rotation)), Position.Y + (float) (radius * Math.Sin(angles[0] + Rotation)));

                    ////Top-right
                    //angles[1] = angle;
                    //Vertices[1] = new Vector2(Position.X + (float)(radius * Math.Cos(angles[1] + Rotation)), Position.Y + (float)(radius * Math.Sin(angles[1] + Rotation)));

                    ////Bottom-left
                    ////It's added pi because the cos() function cannot distinguish if the vertex is above or below the center Y
                    //angles[2] = angle + Math.PI; 
                    //Vertices[2] = new Vector2(Position.X + (float)(radius * Math.Sin(angles[2] + Rotation)), Position.Y + (float)(radius * Math.Sin(angles[2] + Rotation)));

                    ////Bottom-right
                    ////It can be just -angle but I decided to just allow positive angles for simplification
                    //angles[3] = 2*Math.PI - angle;
                    //Vertices[3] = new Vector2(Position.X + (float)(radius * Math.Sin(angles[3] + Rotation)), Position.Y + (float)(radius * Math.Sin(angles[3] + Rotation)));
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