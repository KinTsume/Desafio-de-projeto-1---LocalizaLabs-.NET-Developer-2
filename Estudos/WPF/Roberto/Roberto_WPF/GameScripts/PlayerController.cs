using Roberto_WPF.GameScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roberto_WPF
{
    public class PlayerController
    {
        private DynamicEntity AttachedObject;
        private float[] direction { get; set; }

        public PlayerController()
        {
            direction = new float[2] { 0, 0 };
        }

        public void Translate(Vector2 direction)
        {
            AttachedObject.Position += direction;
        }
    }
}
