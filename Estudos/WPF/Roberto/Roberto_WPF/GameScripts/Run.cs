using System;
using System.Threading;

namespace roberto // Note: actual namespace depends on the project name.
{
    public static class Run
    {
        //public static Timer cameraRender;
        //public static Camera CameraReference;
        //public static Map MapReference;
        //public static PlayerController PlayerControllerReference;
        //static void Func()
        //{
        //    CameraReference = new Camera();
        //    MapReference = new Map();
        //    var PlayerControllerReference = new PlayerController();

        //    //Creates a new thread to get inputs
        //    //Thread InputThread = new Thread(InputManager.InputFuctions);
        //    //InputThread.Start();

        //    var pos = new float[2] { 5, 5 };
        //    var shap = ShapeEnum.Triangle;
        //    var dim = new int[2] { 10, 10 };

        //    var entity = new StaticEntity(pos, shap, dim);
        //    MapReference.AddToList(entity);

        //    pos = new float[2] { -5, -5 };
        //    shap = ShapeEnum.Rectangle;
        //    var entity2 = new StaticEntity(pos, shap, dim);
        //    MapReference.AddToList(entity2);

        //    cameraRender = new Timer(CallCameraRender, null, 0, 1000);
        //}

        //public static void CallCameraRender(Object o)
        //{
        //    Console.Clear();
        //    string Pixels = CameraReference.GetPixels(MapReference);
        //    Console.Write(Pixels);
        //    var vector = PlayerControllerReference.GetDirection();
        //    Console.WriteLine(vector[0]);
        //    if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) )
        //    {
        //        Console.WriteLine("bugged");
        //    }

        //    /*var cameraPos = camera.GetPosition();
        //    var cameraNewPos = new float[2] { cameraPos[0] + 1, cameraPos[1] };
        //    camera.SetPosition(cameraNewPos);*/

        //    float[] direction = PlayerControllerReference.GetDirection();
        //    var cameraPos = CameraReference.GetPosition();
        //    var cameraNewPos = new float[2] { cameraPos[0] + direction[0], cameraPos[1] + direction[1] };
        //    CameraReference.SetPosition(cameraNewPos);
        //}
    }
}