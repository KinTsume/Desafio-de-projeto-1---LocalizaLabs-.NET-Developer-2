using System.Collections.Generic;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Numerics;

namespace Roberto_WPF.GameScripts
{
    public class Camera : Entity
    {
        private CameraPixel[,] camera;
        private double[] pixelDimension;
        private DynamicEntity parent;

        public Camera()
        {
            ShapeWidth = 40;
            ShapeHeight = 40;
            camera = new CameraPixel[ShapeWidth, ShapeHeight];

            pixelDimension = new double[2] { MainWindow.GetDimensions()[0] / ShapeWidth, MainWindow.GetDimensions()[1] / ShapeHeight };

            for (int i = 0; i < ShapeHeight; i++)
            {
                for (int j = 0; j < ShapeWidth; j++)
                {
                    camera[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], Colors.White);
                }
            }

            PositionX = 0;
            PositionY = 0;
        }

        public Camera(DynamicEntity Parent)
        {
            ShapeWidth = 40;
            ShapeHeight = 40;
            camera = new CameraPixel[ShapeWidth, ShapeHeight];

            pixelDimension = new double[2] { MainWindow.GetDimensions()[0] / ShapeWidth, MainWindow.GetDimensions()[1] / ShapeHeight };

            for (int i = 0; i < ShapeHeight; i++)
            {
                for (int j = 0; j < ShapeWidth; j++)
                {
                    camera[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], Colors.White);
                }
            }

            parent = Parent;
        }

        public CameraPixel[,] GetPixels(Map mapObject)
        {
            //Empty the camera before rendering
            for (int i = 0; i < ShapeHeight; i++)
            {
                for (int j = 0; j < ShapeWidth; j++)
                {
                    camera[i, j] = camera[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], Colors.White);
                }
            }

            //Move the camera to the parent's position
            if(parent != null)
                Position = parent.Position;

            //render the static objects from the map
            var SEntityList = mapObject.GetEntityList();

            foreach (StaticEntity item in SEntityList)
            {
                bool DrawItem = false;

                var itemCenter = item.Position;
                var itemDimension = item.ShapeDimensions;

                var cameraCenter = Position;
                var cameraDimension = ShapeDimensions;

                var centerDistance = new float[] {Math.Abs(itemCenter.X - cameraCenter.X), Math.Abs(itemCenter.Y - cameraCenter.Y)};

                if ((centerDistance[0] <= (itemDimension.X/2 + cameraDimension.X/2)) && (centerDistance[1] <= (itemDimension.Y / 2 + cameraDimension.Y / 2)))
                {
                    DrawItem = true;
                }
                
                //The info about the index of the vertices is at Entity.GetVertices()
                var itemVertex1 = item.GetVertices(0);
                var cameraVertex1 = this.GetVertices(0);

                if (DrawItem)
                {
                    var shape = item.GetShapeArray(pixelDimension);
                    var indexToStartDrawing = new Vector2( (int)(itemVertex1.X - cameraVertex1.X), (int)(itemVertex1.Y - cameraVertex1.Y) );
                    indexToStartDrawing.Y *= -1;

                    var itemDimensions = item.ShapeDimensions;

                    var itemOffsetIndex = new Vector2( 0, 0 );

                    //This if is to prevent the camera to try render objects out of the camera X view
                    if (indexToStartDrawing.X < 0)
                    {
                        itemDimensions.X += indexToStartDrawing.X;
                        itemOffsetIndex.X -= indexToStartDrawing.X;
                        indexToStartDrawing.X = 0;
                    }

                    //This if is to prevent the camera to try render objects out of the camera Y view
                    if (indexToStartDrawing.Y < 0)
                    {
                        itemDimensions.Y += indexToStartDrawing.Y;
                        itemOffsetIndex.Y -= indexToStartDrawing.Y;
                        indexToStartDrawing.Y = 0;
                    }

                    for (int i = 0; i < itemDimensions.Y; i++)
                    {
                        if (indexToStartDrawing.Y + i >= this.ShapeHeight)
                            break;

                        for (int j = 0; j < itemDimensions.X; j++)
                        {
                            if (indexToStartDrawing.X + j >= this.ShapeWidth)
                                break;

                            if (shape[i, j] == null)
                                continue;

                            camera[(int)indexToStartDrawing.Y + i, (int)indexToStartDrawing.X + j] = shape[(int)itemOffsetIndex.Y + i, (int)itemOffsetIndex.X + j];
                        }
                    }

                }
            }

            return camera;
        }

        public class CameraPixel
        {
            private double width;
            private double height;
            private Color _color;

            public double[] Dimension 
            {
                get 
                {
                    var dimensionArray = new double[2] {width, height };
                    return dimensionArray;
                }
            }

            public Color color
            {
                get
                {
                    return _color;
                }

                set 
                {
                    _color = value;
                } 
            }

            public CameraPixel(double pixelWidth, double pixelHeight, Color color)
            {
                width = pixelWidth;
                height = pixelHeight;
                _color = color;
            }
        }
    }
}