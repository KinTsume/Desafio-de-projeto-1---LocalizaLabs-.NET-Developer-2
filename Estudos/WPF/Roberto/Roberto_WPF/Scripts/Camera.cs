using System.Collections.Generic;
using System;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using Roberto_WPF.Utility;

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
            
            if (parent != null)
            {
                this.Position = parent.Position;
                this.Rotation = parent.Rotation - MathF.PI / 2;
            }
            
            renderStaticList(map, c);
            renderDynamicList(map, c);
        }

        private void renderStaticList(Map map, Canvas c)
        {
            var SEntityList = map.GetStaticList();
           

            foreach (StaticEntity item in SEntityList)
            {
                var distance = new Vector2(Math.Abs(item.Position.X - this.Position.X), Math.Abs(item.Position.Y - this.Position.Y));

                if (distance.X < (item.ShapeDimensions.X + this.ShapeDimensions.X) && distance.Y < (item.ShapeDimensions.Y + this.ShapeDimensions.Y))
                {
                    var rotationedVertices = getRotationVertices(item, this.Rotation, this.Position);

                    //calculate the vertices relative to the camera position
                    PointCollection relativeVertices = new PointCollection();

                    foreach (Point point in rotationedVertices)
                    {
                        var pos = new Point(point.X + this.ShapeDimensions.X / 2, -point.Y + this.ShapeDimensions.Y / 2);
                        relativeVertices.Add(pos);
                    }

                    switch (item.Shape)
                    {
                        case ShapeEnum.Rectangle:
                            Polygon poly = new Polygon
                            {
                                Points = relativeVertices,
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
                    var rotationedVertices = getRotationVertices(item, this.Rotation, this.Position);

                    //calculate the vertices relative to the camera position
                    PointCollection relativeVertices = new PointCollection();

                    foreach (Point point in rotationedVertices)
                    {
                        var pos = new Point(point.X + this.ShapeDimensions.X / 2, -point.Y + this.ShapeDimensions.Y / 2);
                        relativeVertices.Add(pos);
                    }

                    switch (item.Shape)
                    {
                        case ShapeEnum.Rectangle:
                            Polygon poly = new Polygon
                            {
                                Points = relativeVertices,
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

        /// <summary>
        /// Get the object position relative to this camera
        /// </summary>
        /// <param name="entity">The entity to get the relative position</param>
        /// <returns>A point representing the relative position</returns>
        private Point getRelativePosition(Entity entity)
        {
            var x1 = this.Position;
            var x2 = entity.Position;
            var radius = Math.Sqrt(Math.Pow(x1.X - x2.X, 2)+ Math.Pow(x1.Y - x2.Y, 2));

            //var distanceVector = new Point(Math.Abs(x1.X - x2.X), Math.Abs(x1.Y - x2.Y));

            //var angle = radius != 0 ? Math.Acos(distanceVector.X / radius) : 0;
            //var angleSignal = radius != 0 ? Math.Asin(distanceVector.Y / radius) : 1;
            //angleSignal = angleSignal != 0 ? angleSignal / Math.Abs(angleSignal) : 1;
            //angle *= angleSignal;

            var angle = MathFunctions.AngleOfVector(x2, x1);

            var angleBetween = angle - this.Rotation;

            var position = new Point(radius * Math.Cos(angleBetween), radius * Math.Sin(angleBetween));

            return position;
        }

        /// <summary>
        /// Get the vertices of the entity with its rotation relative to this cames
        /// </summary>
        /// <param name="entity">The entity to get the vertices from</param>
        /// <param name="rotation">The rotation of the camera</param>
        /// <param name="pos">The position of the camera</param>
        /// <returns>A collection with the vertices rotated and positioned relative to the camera</returns>
        private PointCollection getRotationVertices(Entity entity, float rotation, Vector2 pos)
        {
            var relativePos = getRelativePosition(entity);
            var angle = entity.Rotation - rotation;

            var newVertices = new PointCollection();

            foreach (Point p in entity.Vertices)
            {
                var radius = Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
                //var actualAngle = radius != 0 ? Math.Acos(p.X / radius) : 0;
                //var angleSignal = radius != 0 ? Math.Asin(p.Y / radius) : 0;
                //angleSignal = angleSignal != 0 ?  angleSignal / Math.Abs(angleSignal) : 1;
                var actualAngle = MathFunctions.AngleOfVector(p, new Point(0, 0));

                var rotatedVertex = new Point(radius * Math.Cos(angle + actualAngle), radius * Math.Sin(angle + actualAngle));
                var camRelativeVertex = new Point(rotatedVertex.X + relativePos.X, rotatedVertex.Y + relativePos.Y);
                newVertices.Add(camRelativeVertex);
                //newVertices.Add(new Point(p.X + entity.Position.X, p.Y + entity.Position.Y));
            }

            return newVertices;
        }
    }
}