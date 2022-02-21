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
using Roberto_WPF.GameScripts;

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
        private static Canvas gameArea;

        public MainWindow()
        {
            InitializeComponent();
            gameArea = this.GameArea;
            StackPanel myStackPanel = new StackPanel();
            Rectangle rect = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Aquamarine
            };

            //GameArea.Children.Add(rect);
            //Canvas.SetTop(rect, 300);
            //Canvas.SetLeft(rect, 300);

            rect.Fill = Brushes.Yellow;

            CameraReference = new Camera();
            MapReference = new Map();
            PlayerControllerReference = new PlayerController();

            var pos = new float[2] { 5, 5 };
            var shap = ShapeEnum.Triangle;
            var dim = new int[2] { 10, 10 };

            var entity = new StaticEntity(pos, shap, dim, Colors.Red);
            MapReference.AddToList(entity);

            pos = new float[2] { -5, -5 };
            shap = ShapeEnum.Rectangle;
            var entity2 = new StaticEntity(pos, shap, dim, Colors.Aquamarine);
            MapReference.AddToList(entity2);

            //cameraRender = new Timer(CallCameraRender, null, 0, 1000);
            var pixels = CameraReference.GetPixels(MapReference);
            drawPixels(pixels);
            //meArea.Text = Pixels;
        }

        public static void drawPixels(Camera.CameraPixel[,] pixelArray)
        {
            gameArea.Children.Clear();
            var arrayDimension = CameraReference.ShapeDimensions;
            var dimension = pixelArray[0, 0].Dimension;
            for (int i = 0; i < arrayDimension.Y; i++)
            {
                for (int j = 0; j < arrayDimension.X; j++)
                {
                    
                    Rectangle rect = new Rectangle { 
                                                    Width = dimension[0],
                                                    Height = dimension[1],
                                                    Fill = new SolidColorBrush { Color = pixelArray[i, j].color}
                                                    };
                    gameArea.Children.Add(rect);
                    Canvas.SetTop(rect, i * gameArea.Width / arrayDimension.X);
                    Canvas.SetLeft(rect, j * gameArea.Height / arrayDimension.Y);
                }
            }
        }

        public static double[] GetDimensions()
        {
            var dimensions = new double[2] { gameArea.Width, gameArea.Height };
            return dimensions;
        }

        public static void CallCameraRender(Object o)
        {
            var Pixels = CameraReference.GetPixels(MapReference);
            drawPixels(Pixels);
        }
    }
}
