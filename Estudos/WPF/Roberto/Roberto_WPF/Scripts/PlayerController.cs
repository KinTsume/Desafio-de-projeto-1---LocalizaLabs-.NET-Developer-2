using Roberto_WPF.GameScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roberto_WPF.GameScripts
{
    public class PlayerController
    {
        private DynamicEntity AttachedObject;
        private float[] direction { get; set; }

        public PlayerController()
        {
            direction = new float[2] { 0, 0 };
            ControllerManager.subscribeToAxis = MoveAndRotatePlayer;
        }

        public void AttachObject(DynamicEntity de)
        {
            AttachedObject = de;
        }

        public void MoveAndRotatePlayer(Vector2 dir)
        {
            AttachedObject.MoveAndRotate(dir);
            MainWindow.UpdateCameraView();
        }
    }
}
