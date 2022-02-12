using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roberto
{
    public class PlayerController
    {
        ConsoleKeyInfo keyinfo;
        private float[] direction { get; set; }

        public PlayerController()
        {
            direction = new float[2] { 0, 0 };
        }

        public void ChangeDirection(float[] directionVector)
        {
            direction = directionVector;
        }

        public float[] GetDirection()
        {
            return direction;
        }
    }
}
