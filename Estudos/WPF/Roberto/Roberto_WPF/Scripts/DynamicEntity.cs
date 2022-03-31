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

        public DynamicEntity(Vector2 position, ShapeEnum shape, Vector2 shapeDimensions, Color Color, float entitySpeed, float rot)
        {
            id = new Guid();

            Position = position;

            Rotation = 0;

            EntityColor = Color;

            Shape = shape;
            ShapeDimensions = shapeDimensions;

            speed = entitySpeed;

            Vertices = new PointCollection();

            Rotation = rot;
            SetShape(shape);
        }

        /// <summary>
        /// The function to move the object
        /// </summary>
        /// <param name="directionVector"></param>
        public void Move(Vector2 directionVector)
        {
            Position += directionVector * speed;
        }

        public void MoveAndRotate(Vector2 dir)
        {

            var multiplier = 0;
            if (dir.Y < 0)
            {
                multiplier = -1;
            }
            else if (dir.Y > 0)
            {
                multiplier = 1;
            }

            var rotateValue = 0;
            if (dir.X < 0)
            {
                rotateValue = -1;
            }
            else if (dir.X > 0)
            {
                rotateValue = 1;
            }

            MoveForwardAndBack(multiplier);
            Rotate(rotateValue * MathF.PI/40);
        }

        /// <summary>
        /// Moves the object on the direction it's facing
        /// </summary>
        /// <param name="multiplier">1 for forward and -1 for backwards</param>
        public void MoveForwardAndBack(int multiplier)
        {
            Position += multiplier * speed * new Vector2(MathF.Cos(Rotation), MathF.Sin(Rotation));
        }

        public void Rotate(float rot)
        {
            Rotation += rot;
            SetShape(Shape);
        }

    }
}
