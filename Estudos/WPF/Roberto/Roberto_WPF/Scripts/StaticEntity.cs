using System;
using System.Numerics;
using System.Windows.Media;

namespace Roberto_WPF.GameScripts
{
    public class StaticEntity : Entity
    {

        public StaticEntity(Vector2 position, ShapeEnum shape, Vector2 shapeDimensions, Color Color)
        {
            id = new Guid();

            Position = position;

            Rotation = MathF.PI / 4;

            EntityColor = Color;

            Shape = shape;

            if (shape == ShapeEnum.Custom)
            {

            }
            ShapeDimensions = shapeDimensions;

            Vertices = new PointCollection();

            Vertices = GetRotatedVertices(shape);
        }
    }
}