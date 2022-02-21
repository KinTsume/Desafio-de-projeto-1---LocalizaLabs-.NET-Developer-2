using roberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roberto_WPF.GameScripts
{
    public class DynamicEntity : Entity
    {
        public void Move(Vector2 directionVector, float speed)
        {
            Position = directionVector * speed;
        }
    }
}
