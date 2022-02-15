using System;
using System.Windows.Media;
using System.Windows.Shapes;
using static roberto.Camera;

namespace roberto
{
    public abstract class Entity
    {
        public Guid id { get; set; }
        protected float PositionX { get; set; }
        protected float PositionY { get; set; }
        protected ShapeEnum Shape { get; set; }
        protected int ShapeWidth { get; set; }
        protected int ShapeHeight { get; set; }
        protected Color EntityColor;

        public Guid GetId()
        {
            return id;
        }

        public float[] GetPosition()
        {
            var Pos = new float[2] { PositionX, PositionY };
            return Pos;
        }

        public void SetPosition(float[] position)
        {
            if (position.Length != 2)
            {
                throw new ArgumentException("Array length must be 2");
            }

            PositionX = position[0];
            PositionY = position[1];
        }

        public int[] GetShapeDimensions()
        {
            var dim = new int[2] { ShapeWidth, ShapeHeight };
            return dim;
        }

        public void SetShapeDimensions(int[] dimensions)
        {
            if (dimensions.Length != 2)
            {
                throw new ArgumentException("Array length must be 2");
            }

            ShapeWidth = dimensions[0];
            ShapeHeight = dimensions[1];
        }

        public CameraPixel[,] GetShapeArray(double[] pixelDimension)
        {
            var shapeArray = new CameraPixel[ShapeHeight, ShapeWidth];

            switch (Shape)
            {
                case ShapeEnum.Rectangle:
                    for (int i = 0; i < ShapeHeight; i++)
                    {
                        for (int j = 0; j < ShapeWidth; j++)
                        {
                            shapeArray[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], EntityColor);
                        }
                    }
                    break;

                case ShapeEnum.Elipse:
                    for (int i = 0; i < ShapeHeight; i++)
                    {
                        for (int j = 0; j < ShapeWidth; j++)
                        {
                            var pos = GetPosition();
                            var shapeDim = GetShapeDimensions();
                            var UpLeftVertex = new float[2] { pos[0] - shapeDim[0] / 2, pos[1] - shapeDim[1] / 2 };
                            var testPoint = new float[2] { UpLeftVertex[0] + j, UpLeftVertex[1] + i };

                            if (GeometryCalculation.IsInsideElipse(pos, shapeDim, testPoint))
                                shapeArray[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], EntityColor);
                            else
                                shapeArray[i, j] = null;
                        }
                    }
                    break;

                case ShapeEnum.Triangle:
                    for (int i = 0; i < ShapeHeight; i++)
                    {
                        for (int j = 0; j < ShapeWidth; j++)
                        {
                            var pos = GetPosition();
                            var shapeDim = GetShapeDimensions();
                            var UpLeftVertex = new float[2] { pos[0] - shapeDim[0] / 2, pos[1] + shapeDim[1] / 2 };
                            var testPoint = new float[2] { UpLeftVertex[0] + j, UpLeftVertex[1] - i };

                            var testA = testPoint[0];
                            var testB = testPoint[1];

                            //Make the triangle direction editable
                            if (GeometryCalculation.IsInsideTriangle(pos, shapeDim, testPoint, 1))
                                shapeArray[i, j] = new CameraPixel(pixelDimension[0], pixelDimension[1], EntityColor);
                            else
                                shapeArray[i, j] = null;
                        }
                    }
                    break;
                case ShapeEnum.Custom:
                    break;
                default:
                    break;
            }
            return shapeArray;
        }

        public float[] GetVertices(int VerticeIndex)
        {
            float[] vertex = new float[2];

            switch (VerticeIndex)
            {
                //Up - left vertex
                case 0:
                    vertex = new float[2] { PositionX - ShapeWidth / 2, PositionY + ShapeHeight / 2 };
                    break;

                //down - right vertex
                case 1:
                    vertex = new float[2] { PositionX + ShapeWidth / 2, PositionY - ShapeHeight / 2 };
                    break;

                //Up - right vertex
                case 2:
                    vertex = new float[2] { PositionX + ShapeWidth / 2, PositionY + ShapeHeight / 2 };
                    break;

                //Down - left vertex
                case 3:
                    vertex = new float[2] { PositionX - ShapeWidth / 2, PositionY - ShapeHeight / 2 };
                    break;

                default:
                    break;
            }

            return vertex;
        }
    }
}