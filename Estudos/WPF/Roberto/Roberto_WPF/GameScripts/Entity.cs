using System;
using System.Numerics;
using System.Windows.Media;
using static Roberto_WPF.GameScripts.Camera;

namespace Roberto_WPF.GameScripts
{
    public abstract class Entity
    {
        public Guid id { get; set; }
        protected float PositionX;
        protected float PositionY;
        protected ShapeEnum shape { get; set; }
        protected int ShapeWidth { get; set; }
        protected int ShapeHeight { get; set; }
        protected Color EntityColor;

        public Guid GetId()
        {
            return id;
        }

        public Vector2 Position
        {
            get 
            {
                return new Vector2(PositionX, PositionY);
            }

            set
            {
                PositionX = value.X;
                PositionY = value.Y;
            }
        }

        public ShapeEnum Shape
        {
            get
            {
                return shape;
            }

            set
            {
                shape = value;
            }
        }

        public Vector2 ShapeDimensions 
        {
            get
            {
                return new Vector2(ShapeWidth, ShapeHeight);
            }

            set
            {
                ShapeWidth = (int)value.X;
                ShapeHeight = (int)value.Y;
            }
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
                            var pos = Position;
                            var shapeDim = ShapeDimensions;
                            var UpLeftVertex = new Vector2(pos.X - shapeDim.X / 2, pos.Y + shapeDim.Y / 2 );
                            var testPoint = new Vector2(UpLeftVertex.X + j, UpLeftVertex.Y - i );

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
                            var pos = Position;
                            var shapeDim = ShapeDimensions;
                            var UpLeftVertex = new Vector2( pos.X - shapeDim.X / 2, pos.Y + shapeDim.Y / 2 );
                            var testPoint = new Vector2(UpLeftVertex.X + j, UpLeftVertex.Y - i );


                            //This is temporary. Is the shape is a triangle it should have the vertices defined 
                            var vertex1 = new Vector2(pos.X, pos.Y + shapeDim.Y / 2);
                            var vertex2 = new Vector2(pos.X - shapeDim.X / 2, pos.Y - shapeDim.Y / 2);
                            var vertex3 = new Vector2(pos.X + shapeDim.X / 2, pos.Y - shapeDim.Y / 2); 
                            var triangleVertices = new Vector2[] {vertex1, vertex2, vertex3 };

                            var testA = testPoint.X;
                            var testB = testPoint.Y;

                            if (GeometryCalculation.IsInsideTriangle(pos, shapeDim, testPoint, triangleVertices))
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

        public Vector2 GetVertices(int VerticeIndex)
        {
            Vector2 vertex = new Vector2();

            switch (VerticeIndex)
            {
                //Up - left vertex
                case 0:
                    vertex = new Vector2(PositionX - ShapeWidth / 2, PositionY + ShapeHeight / 2 );
                    break;

                //down - right vertex
                case 1:
                    vertex = new Vector2( PositionX + ShapeWidth / 2, PositionY - ShapeHeight / 2 );
                    break;

                //Up - right vertex
                case 2:
                    vertex = new Vector2( PositionX + ShapeWidth / 2, PositionY + ShapeHeight / 2 );
                    break;

                //Down - left vertex
                case 3:
                    vertex = new Vector2( PositionX - ShapeWidth / 2, PositionY - ShapeHeight / 2 );
                    break;

                default:
                    break;
            }

            return vertex;
        }
    }
}