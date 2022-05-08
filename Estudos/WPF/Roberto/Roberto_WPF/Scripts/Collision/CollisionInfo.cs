using Roberto_WPF.GameScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Roberto_WPF.Scripts.Collision
{
    public class CollisionInfo
    {
        public DynamicEntity collidingEntity { get; set; }
        public Entity CollidedEntity { get; set; }

        //A point on the border of the collided entity
        //It's calculated following the (colliding point - collided center) vector to the border
        Point collisionPoint; 

        //Implement physics stuff
        //Like: impact, linear moment transfer, rotational moment transfer 
    }
}
