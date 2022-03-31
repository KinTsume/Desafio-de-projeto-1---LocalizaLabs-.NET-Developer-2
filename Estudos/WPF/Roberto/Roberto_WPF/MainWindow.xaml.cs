using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Numerics;
using System.Windows.Threading;

namespace Roberto_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static DispatcherTimer gameTimer;
        public static Camera CameraReference;
        public static Map MapReference;
        public static PlayerController PlayerControllerReference;
        private static Canvas gameArea;

        public MainWindow()
        {
            InitializeComponent();
            gameArea = this.GameArea;
            gameArea.Focus();
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

            CameraReference = new Camera(new Vector2((float)gameArea.Width, (float)gameArea.Height));
            MapReference = new Map();
            PlayerControllerReference = new PlayerController();

            var pos = new Vector2( 50, 50 );
            var shap = ShapeEnum.Rectangle;
            var dim = new Vector2(50);

            var entity = new DynamicEntity(pos, shap, dim, Colors.Red, 10, 0/*MathF.PI/4*/);
            MapReference.AddDynamic(entity);
            PlayerControllerReference.AttachObject(entity);
            CameraReference.parent = entity;

            pos = new Vector2(0, 0);
            shap = ShapeEnum.Rectangle;
            var entity2 = new StaticEntity(pos, shap, dim, Colors.Aquamarine);
            MapReference.AddStatic(entity2);

            gameTimer = new DispatcherTimer(DispatcherPriority.Normal, Application.Current.Dispatcher);
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            gameTimer.Tick += GameTick;
            gameTimer.Start();
            //meArea.Text = Pixels;
            
        }

        public static void UpdateCameraView()
        {
            gameArea.Children.Clear();
            CameraReference.Render(MapReference, gameArea);
        }

        public static double[] GetDimensions()
        {
            var dimensions = new double[2] { gameArea.Width, gameArea.Height };
            return dimensions;
        }

        public static void GameTick(object sender, EventArgs e)
        {
            UpdateCameraView();
            ControllerManager.OnKeyDown();
        }
    }
}
