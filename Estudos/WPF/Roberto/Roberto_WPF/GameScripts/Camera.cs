using System.Collections.Generic;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using Roberto_WPF;

namespace roberto
{
    public class Camera : Entity
    {
        private CameraPixel[,] camera;
        private double[] pixelDimension;

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

            //render the static objects from the map
            var SEntityList = mapObject.GetEntityList();

            foreach (StaticEntity item in SEntityList)
            {
                bool DrawItem = false;

                var itemCenter = item.GetPosition();
                var itemDimension = item.GetShapeDimensions();

                var cameraCenter = this.GetPosition();
                var cameraDimension = this.GetShapeDimensions();

                var centerDistance = new float[] {Math.Abs(itemCenter[0] - cameraCenter[0]), Math.Abs(itemCenter[1] - cameraCenter[1])};

                if ((centerDistance[0] <= (itemDimension[0]/2 + cameraDimension[0]/2)) && (centerDistance[1] <= (itemDimension[1] / 2 + cameraDimension[1] / 2)))
                {
                    DrawItem = true;
                }
                
                //The info about the index of the vertices is at Entity.GetVertices()
                var itemVertex1 = item.GetVertices(0);
                var cameraVertex1 = this.GetVertices(0);

                if (DrawItem)
                {
                    var shape = item.GetShapeArray(pixelDimension);
                    var indexToStartDrawing = new int[2] { (int)(itemVertex1[0] - cameraVertex1[0]), (int)(itemVertex1[1] - cameraVertex1[1]) };
                    indexToStartDrawing[1] *= -1;

                    var itemDimensions = item.GetShapeDimensions();

                    var itemOffsetIndex = new int[2] { 0, 0 };

                    //This if is to prevent the camera to try render objects out of the camera X view
                    if (indexToStartDrawing[0] < 0)
                    {
                        itemDimensions[0] += indexToStartDrawing[0];
                        itemOffsetIndex[0] -= indexToStartDrawing[0];
                        indexToStartDrawing[0] = 0;
                    }

                    //This if is to prevent the camera to try render objects out of the camera Y view
                    if (indexToStartDrawing[1] < 0)
                    {
                        itemDimensions[1] += indexToStartDrawing[1];
                        itemOffsetIndex[1] -= indexToStartDrawing[1];
                        indexToStartDrawing[1] = 0;
                    }

                    for (int i = 0; i < itemDimensions[1]; i++)
                    {
                        if (indexToStartDrawing[1] + i >= this.ShapeHeight)
                            break;

                        for (int j = 0; j < itemDimensions[0]; j++)
                        {
                            if (indexToStartDrawing[0] + j >= this.ShapeWidth)
                                break;

                            if (shape[i, j] == null)
                                continue;

                            camera[indexToStartDrawing[1] + i, indexToStartDrawing[0] + j] = shape[itemOffsetIndex[1] + i, itemOffsetIndex[0] + j];
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