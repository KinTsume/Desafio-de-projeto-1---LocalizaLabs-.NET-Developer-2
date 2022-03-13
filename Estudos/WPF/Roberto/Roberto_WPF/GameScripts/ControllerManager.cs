using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Roberto_WPF.GameScripts
{
    public static class ControllerManager
    {
        public static void HorizontalAxis()
        {
            var direction = new Vector2();
            if (Keyboard.IsKeyDown(Key.D))
                direction = new Vector2();
        }
    }
}
