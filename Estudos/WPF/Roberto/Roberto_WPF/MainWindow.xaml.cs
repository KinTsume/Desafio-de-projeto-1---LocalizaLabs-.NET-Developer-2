using roberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roberto_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Timer cameraRender;
        public static Camera CameraReference;
        public static Map MapReference;
        public static PlayerController PlayerControllerReference;

        public MainWindow()
        {
            InitializeComponent();
            /*StackPanel myStackPanel = new StackPanel();
            Rectangle rect = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Aquamarine
            };

            GameArea.Children.Add(rect);
            Canvas.SetTop(rect, 300);
            Canvas.SetLeft(rect, 300);*/

            CameraReference = new Camera();
            MapReference = new Map();
            PlayerControllerReference = new PlayerController();

            var pos = new float[2] { 5, 5 };
            var shap = ShapeEnum.Triangle;
            var dim = new int[2] { 10, 10 };

            var entity = new StaticEntity(pos, shap, dim);
            MapReference.AddToList(entity);

            pos = new float[2] { -5, -5 };
            shap = ShapeEnum.Rectangle;
            var entity2 = new StaticEntity(pos, shap, dim);
            MapReference.AddToList(entity2);

            //cameraRender = new Timer(CallCameraRender, null, 0, 1000);
            string Pixels = CameraReference.GetPixels(MapReference);
            GameArea.Text = Pixels;
        }

        public static void CallCameraRender(Object o)
        {
            string Pixels = CameraReference.GetPixels(MapReference);

            TextBlock gameArea = new TextBlock();
            gameArea.Text = Pixels;

            /*var cameraPos = camera.GetPosition();
            var cameraNewPos = new float[2] { cameraPos[0] + 1, cameraPos[1] };
            camera.SetPosition(cameraNewPos);*/

            float[] direction = PlayerControllerReference.GetDirection();
            var cameraPos = CameraReference.GetPosition();
            var cameraNewPos = new float[2] { cameraPos[0] + direction[0], cameraPos[1] + direction[1] };
            CameraReference.SetPosition(cameraNewPos);
        }
    }
}
