using System;
using System.Numerics;
using System.Windows.Media;

namespace Roberto_WPF.GameScripts
{
    public class StaticEntity : Entity
    {

        public StaticEntity(Vector2 position, ShapeEnum shape, int[] shapeDimensions, Color Color)
        {
            id = new Guid();

            PositionX = position.X;
            PositionY = position.Y;

            EntityColor = Color;

            Shape = shape;
            ShapeWidth = shapeDimensions[0];
            ShapeHeight = shapeDimensions[1];
        }
    }
}