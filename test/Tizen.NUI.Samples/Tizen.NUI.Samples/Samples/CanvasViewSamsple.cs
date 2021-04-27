using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.BaseComponents.VectorGraphics;

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

            roundedRectShape = new Shape()
            {
                FillColor = new Color(0.5f, 1.0f, 0.0f, 1.0f),
                StrokeColor = new Color(0.5f, 0.0f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
            };
            roundedRectShape.Translate(100.0f, 100.0f);
            roundedRectShape.Scale(1.2f);
            roundedRectShape.Rotate(45.0f);
            roundedRectShape.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 0.0f, 0.0f);

            canvasView.AddDrawable(roundedRectShape);

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

            canvasView.AddDrawable(circleShape);

            arcShape = new Shape()
            {
                StrokeColor = new Color(0.0f, 0.5f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
                StrokeJoin = Shape.StrokeJoinType.Round,
            };
            arcShape.AddArc(0.0f, 0.0f, 80.0f, 0.0f, 0.0f, true);
            arcShape.Translate(100.0f, 300.0f);

            canvasView.AddDrawable(arcShape);

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
            shape.AddMoveTo(0.0f, -160.0f);
            shape.AddLineTo(125.0f, 160.0f);
            shape.AddLineTo(-180.0f, -45.0f);
            shape.AddLineTo(180.0f, -45.0f);
            shape.AddLineTo(-125.0f, 160.0f);
            shape.Close();

            canvasView.AddDrawable(shape);

            starShape = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 1.0f, 1.0f, 1.0f),
                StrokeColor = new Color(0.5f, 1.0f, 0.5f, 1.0f),
                StrokeWidth = 30.0f,
                StrokeCap = Shape.StrokeCapType.Round,
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

            canvasView.AddDrawable(starShape);

            // Test Getter
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

            count++;

            return true;
        }
    }
}
