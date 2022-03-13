using roberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Roberto_WPF.GameScripts
{
    public class DynamicEntity : Entity
    {
        private float speed;

        public DynamicEntity(Vector2 position, ShapeEnum shape, int[] shapeDimensions, Color Color, float entitySpeed)
        {
            id = new Guid();

            PositionX = position.X;
            PositionY = position.Y;

            EntityColor = Color;

            Shape = shape;
            ShapeWidth = shapeDimensions[0];
            ShapeHeight = shapeDimensions[1];

            speed = entitySpeed;
        }

        public void Move(Vector2 directionVector, float speed)
        {
            Position = directionVector * speed;
        }
    }
}
