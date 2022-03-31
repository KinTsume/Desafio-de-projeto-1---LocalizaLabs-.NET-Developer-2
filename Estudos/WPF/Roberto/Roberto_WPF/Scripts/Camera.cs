using System.Collections.Generic;
using System;
using System.Numerics;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Roberto_WPF.GameScripts
{
    public class Camera : Entity
    {
        public DynamicEntity parent { get; set; }

        public Camera(Vector2 dimensions)
        {
            id = new Guid();
            Position = Vector2.Zero;
            ShapeDimensions = dimensions;
        }

        public Camera(Vector2 dimensions, DynamicEntity Parent)
        {
            id = new Guid();
            Position = Vector2.Zero;
            ShapeDimensions = dimensions;

            parent = Parent;
        }

        public void Render(Map map, Canvas c)
        {
            this.Position = parent.Position;
            renderStaticList(map, c);
            renderDynamicList(map, c);
        }

        private void renderStaticList(Map map, Canvas c)
        {
            var SEntityList = map.GetStaticList();

            foreach (StaticEntity item in SEntityList)
            {
                var distance = new Vector2(Math.Abs(item.Position.X - this.Position.X), Math.Abs(item.Position.Y - this.Position.Y));
                
                //***********MAKE CAMERA RENDER RELATIVE TO ITS POSITION*********************

                if (distance.X < (item.ShapeDimensions.X + this.ShapeDimensions.X) && distance.Y < (item.ShapeDimensions.Y + this.ShapeDimensions.Y))
                {
                    switch (item.Shape)
                    {
                        case ShapeEnum.Rectangle:
                            Polygon poly = new Polygon
                            {
                                Points = item.Vertices,
                                Fill = new SolidColorBrush(item.EntityColor),
                                FillRule = FillRule.Nonzero
                            };

                            //Render the item to the given canvas
                            c.Children.Add(poly);
                            break;

                        case ShapeEnum.Elipse:
                            Ellipse elli = new Ellipse
                            {
                                Width = item.ShapeDimensions.X,
                                Height = item.ShapeDimensions.Y,
                                Fill = new SolidColorBrush(item.EntityColor)
                            };
                            break;
                        case ShapeEnum.Triangle:
                            break;
                        case ShapeEnum.Custom:
                            break;
                        default:
                            break;
                    }
                }                              
            }
        }

        private void renderDynamicList(Map map, Canvas c)
        {
            var DEntityList = map.GetDynamicList();

            foreach (DynamicEntity item in DEntityList)
            {
                var distance = new Vector2(Math.Abs(item.Position.X - this.Position.X), Math.Abs(item.Position.Y - this.Position.Y));

                if (distance.X < (item.ShapeDimensions.X + this.ShapeDimensions.X) && distance.Y < (item.ShapeDimensions.Y + this.ShapeDimensions.Y))
                {

                    switch (item.Shape)
                    {
                        case ShapeEnum.Rectangle:
                            Polygon poly = new Polygon
                            {
                                Points = item.Vertices,
                                Fill = new SolidColorBrush(item.EntityColor)
                            };

                            //Render the item to the given canvas
                            c.Children.Add(poly);
                            break;

                        case ShapeEnum.Elipse:
                            break;
                        case ShapeEnum.Triangle:
                            break;
                        case ShapeEnum.Custom:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}