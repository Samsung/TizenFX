using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.BaseComponents.VectorGraphics;

using System.Collections.ObjectModel;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;

    public class CanvasViewSample : IExample
    {
        const string tag = "NUITEST";

        private View root;
        private CanvasView canvasView;
        private Shape roundedRectShape;
        private Shape circleShape;
        private Shape arcShape;
        private Shape starShape;
        private DrawableGroup group1;
        private DrawableGroup group2;
        private Timer timer;
        private int count = 0;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = window.Size,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            canvasView = new CanvasView(window.Size)
            {
                Size = window.Size,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            RadialGradient roundedRectFillRadialGradient = new RadialGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, new Color(1.0f,0.0f,0.0f,1.0f)),
                    new ColorStop(0.5f, new Color(0.0f,1.0f,0.0f,1.0f)),
                    new ColorStop(1.0f, new Color(0.0f,0.0f,1.0f,1.0f))
                }.AsReadOnly(),
                Spread = SpreadType.Reflect,
            };
            roundedRectFillRadialGradient.SetBounds(new Position2D(0, 0), 30);

            roundedRectShape = new Shape()
            {
                FillColor = new Color(0.5f, 1.0f, 0.0f, 1.0f),
                StrokeColor = new Color(0.5f, 0.0f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
                FillGradient = roundedRectFillRadialGradient,
            };
            roundedRectShape.Translate(100.0f, 100.0f);
            roundedRectShape.Scale(1.2f);
            roundedRectShape.Rotate(45.0f);
            roundedRectShape.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 0.0f, 0.0f);

            Shape circleMask = new Shape()
            {
                FillColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
            };
            circleMask.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 0.0f, 0.0f);
            circleMask.Translate(350.0f, 100.0f);

            circleShape = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 0.0f, 1.0f, 1.0f),
                StrokeColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
                StrokeWidth = 10.0f,
                StrokeDash = new List<float>() { 15.0f, 30.0f }.AsReadOnly(),
            };
            circleShape.AddCircle(0.0f, 0.0f, 150.0f, 100.0f);
            circleShape.Transform(new float[] { 0.6f, 0.0f, 350.0f, 0.0f, 0.6f, 100.0f, 0.0f, 0.0f, 1.0f });

            circleShape.Mask(circleMask, MaskType.Alpha);

            arcShape = new Shape()
            {
                StrokeColor = new Color(0.0f, 0.5f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
                StrokeJoin = Shape.StrokeJoinType.Round,
            };
            arcShape.AddArc(0.0f, 0.0f, 80.0f, 0.0f, 0.0f, true);
            arcShape.Translate(100.0f, 300.0f);

            Shape shape = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 0.5f, 0.0f, 0.5f),
                StrokeColor = new Color(0.5f, 0.0f, 0.5f, 0.5f),
                StrokeWidth = 30.0f,
                FillRule = Shape.FillRuleType.EvenOdd,
                StrokeJoin = Shape.StrokeJoinType.Round,
            };

            shape.Scale(0.5f);
            shape.Translate(350.0f, 300.0f);

            shape.AddPath(new PathCommands(new PathCommands.PathCommandType[] { PathCommands.PathCommandType.MoveTo,
                                                                                PathCommands.PathCommandType.LineTo,
                                                                                PathCommands.PathCommandType.LineTo,
                                                                                PathCommands.PathCommandType.LineTo,
                                                                                PathCommands.PathCommandType.LineTo,
                                                                                PathCommands.PathCommandType.Close },
                                            6,
                                            new float[] {0.0f, -160.0f,
                                                        125.0f, 160.0f,
                                                        -180.0f, -45.0f,
                                                        180.0f, -45.0f,
                                                        -125.0f, 160.0f },
                                            10));

            canvasView.AddDrawable(shape);

            Shape starClipper = new Shape()
            {
                FillColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
            };
            starClipper.AddCircle(0.0f, 0.0f, 160.0f, 160.0f);
            starClipper.Translate(250.0f, 550.0f);

            LinearGradient starFillLinearGradient = new LinearGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, new Color(1.0f,0.0f,0.0f,1.0f)),
                    new ColorStop(0.5f, new Color(0.0f,1.0f,0.0f,1.0f)),
                    new ColorStop(1.0f, new Color(0.0f,0.0f,1.0f,1.0f))
                }.AsReadOnly()
            };
            starFillLinearGradient.SetBounds(new Position2D(-50, -50), new Position2D(50, 50));

            LinearGradient starStrokeLinearGradient = new LinearGradient()
            {
                ColorStops = new List<ColorStop>()
                {
                    new ColorStop(0.0f, new Color(1.0f,0.0f,1.0f,1.0f)),
                    new ColorStop(1.0f, new Color(0.0f,1.0f,1.0f,1.0f))
                }.AsReadOnly()
            };
            starStrokeLinearGradient.SetBounds(new Position2D(0, -50), new Position2D(50, 50));

            starShape = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 1.0f, 1.0f, 1.0f),
                StrokeColor = new Color(0.5f, 1.0f, 0.5f, 1.0f),
                StrokeWidth = 30.0f,
                StrokeCap = Shape.StrokeCapType.Round,
                FillGradient = starFillLinearGradient,
                StrokeGradient = starStrokeLinearGradient,
            };

            starShape.Translate(250.0f, 550.0f);
            starShape.Scale(0.5f);
            starShape.AddMoveTo(-1.0f, -165.0f);
            starShape.AddLineTo(53.0f, -56.0f);
            starShape.AddLineTo(174.0f, -39.0f);
            starShape.AddLineTo(87.0f, 45.0f);
            starShape.AddLineTo(107.0f, 166.0f);
            starShape.AddLineTo(-1.0f, 110.0f);
            starShape.AddLineTo(-103.0f, 166.0f);
            starShape.AddLineTo(-88.0f, 46.0f);
            starShape.AddLineTo(-174.0f, -38.0f);
            starShape.AddLineTo(-54.0f, -56.0f);
            starShape.Close();

            starShape.ClipPath(starClipper);

            canvasView.AddDrawable(starShape);

            group1 = new DrawableGroup();
            group1.AddDrawable(roundedRectShape);
            group1.AddDrawable(arcShape);

            group2 = new DrawableGroup();
            group2.AddDrawable(group1);
            group2.AddDrawable(circleShape);
            canvasView.AddDrawable(group2);

            Picture picture = new Picture();
            picture.Load(CommonResource.GetDaliResourcePath() + "DaliDemo/Kid1.svg");
            picture.SetSize(new Size2D(150, 150));
            picture.Translate(300.0f, 550.0f);
            canvasView.AddDrawable(picture);

            // Test Getter
            Position2D p1 = new Position2D(9, 9), p2 = new Position2D(8, 8);
            starFillLinearGradient.GetBounds(ref p1, ref p2);
            log.Debug(tag, "Gradient Bounds : P1 :" + p1.X + " " + p1.Y + " / P2 :" + p2.X + " " + p2.Y + "\n");

            ReadOnlyCollection<ColorStop> stops = starShape.FillGradient.ColorStops;
            for (int i = 0; i < stops.Count; i++)
            {
                log.Debug(tag, "Gradient Stops :" + i + " " + stops[i].Offset + " " + stops[i].Color.R + " " + stops[i].Color.G + " " + stops[i].Color.B + " " + stops[i].Color.A + "\n");
            }

            log.Debug(tag, "picture size : " + picture.GetSize().Width + " " + picture.GetSize().Height + "\n");

            log.Debug(tag, "circleShape Color : " + circleShape.FillColor.R + " " + circleShape.FillColor.G + " " + circleShape.FillColor.B + " " + circleShape.FillColor.A + "\n");
            log.Debug(tag, "circleShape StrokeColor : " + circleShape.StrokeColor.R + " " + circleShape.StrokeColor.G + " " + circleShape.StrokeColor.B + " " + circleShape.StrokeColor.A + "\n");

            log.Debug(tag, "arcShape StrokeCap : " + arcShape.StrokeCap + "\n");

            log.Debug(tag, "shape2 FillRule : " + shape.FillRule + "\n");
            log.Debug(tag, "shape2 StrokeWidth : " + shape.StrokeWidth + "\n");
            log.Debug(tag, "shape2 StrokeJoin : " + shape.StrokeJoin + "\n");
            log.Debug(tag, "shape2 Opacity : " + shape.Opacity + "\n");

            for (int i = 0; i < circleShape.StrokeDash.Count; i++)
            {
                log.Debug(tag, "shape2 StrokeDash : " + circleShape.StrokeDash[i] + "\n");
            }

            // Exception test.
            try
            {
                circleShape.Transform(new float[] { 0.6f, 0.0f });
            }
            catch (ArgumentException e)
            {
                log.Debug(tag, "Transform : " + e.Message + "\n");
            }
            try
            {
                circleShape.Transform(null);
            }
            catch (ArgumentException e)
            {
                log.Debug(tag, "Transform : " + e.Message + "\n");
            }
            try
            {
                circleShape.StrokeDash = null;
            }
            catch (ArgumentException e)
            {
                log.Debug(tag, "StrokeDash setter : " + e.Message + "\n");
            }

            root.Add(canvasView);

            timer = new Timer(1000 / 32);
            timer.Tick += onTick;
            timer.Start();
        }

        public void Deactivate()
        {
            if (root != null)
            {
                timer.Stop();
                NUIApplication.GetDefaultWindow().Remove(root);
                canvasView.Dispose();
                root.Dispose();
            }
        }

        private bool onTick(object o, Timer.TickEventArgs e)
        {
            roundedRectShape.ResetPath();
            roundedRectShape.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, (float)((count / 3.0f) % 30.0f), (float)((count / 3.0f) % 30.0f));

            circleShape.ResetPath();
            circleShape.AddCircle(0.0f, 0.0f, (float)(count % 100.0f) + 20.0f, (float)(count % 100.0f) + 40.0f);

            arcShape.ResetPath();
            arcShape.AddArc(0.0f, 0.0f, 80.0f, 0.0f, (float)(count % 180.0f), true);
            arcShape.AddArc(0.0f, 0.0f, 80.0f, (float)(count % 180.0f), (float)(count % 180.0f) / 2.0f, true);

            starShape.Rotate((count * 2.0f) % 360);
            starShape.Scale((float)(count % 50) * 0.01f + 0.6f);

            group1.Scale((float)(count % 100) * 0.002f + 0.8f);
            group2.Opacity = 1.0f - (float)(count % 80) * 0.01f;

            count++;

            return true;
        }
    }
}
