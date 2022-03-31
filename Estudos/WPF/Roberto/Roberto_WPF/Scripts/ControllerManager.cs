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
        public delegate void subDelegate(Vector2 value);

        private static List<subDelegate> AxisInput = new List<subDelegate>();

        public static subDelegate subscribeToAxis 
        {
            set { AxisInput.Add(value); }
        }

        public static void OnKeyDown()
        {
            var dir = new Vector2();
            if (Keyboard.IsKeyDown(Key.W))
            {
                dir.Y = 1;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                dir.X = -1;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                dir.Y = -1;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                dir.X = 1;
            }

            if (dir != Vector2.Zero)
            {
                foreach (subDelegate func in AxisInput)
                {
                    func(dir);
                }
            }
        }

    }
}
