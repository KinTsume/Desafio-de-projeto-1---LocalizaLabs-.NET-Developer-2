using System;
using System.Windows.Media;

namespace roberto
{
    public class StaticEntity : Entity
    {

        public StaticEntity(float[] position, ShapeEnum shape, int[] shapeDimensions, Color Color)
        {
            if ((position.Length != 2) || (shapeDimensions.Length != 2))
            {
                throw new ArgumentException("Array length must be 2");
            }
            id = new Guid();

            PositionX = position[0];
            PositionY = position[1];

            EntityColor = Color;

            Shape = shape;
            ShapeWidth = shapeDimensions[0];
            ShapeHeight = shapeDimensions[1];
        }

        public ShapeEnum GetShape()
        {
            return Shape;
        }

    }
}