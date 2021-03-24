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
        private CanvasView canvasView ;
        private Shape shape;
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

            Shape shape1 = new Shape()
            {
                FillColor = new Color(0.5f, 1.0f, 0.0f, 1.0f),
                StrokeColor = new Color(0.5f, 0.0f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
            };
            shape1.Translate(100.0f, 100.0f);
            shape1.Scale(1.2f);
            shape1.Rotate(45.0f);
            shape1.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 10.0f, 10.0f);

            canvasView.AddDrawable(shape1);

            Shape shape2 = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 0.0f, 1.0f, 1.0f),
                StrokeColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
                StrokeWidth = 10.0f,
                StrokeDash = new List<float>(){15.0f, 30.0f}.AsReadOnly(),
            };
            shape2.AddCircle(0.0f, 0.0f, 150.0f, 100.0f);
            shape2.Transform(new float[] {0.6f, 0.0f, 350.0f, 0.0f, 0.6f, 100.0f, 0.0f, 0.0f, 1.0f});        

            canvasView.AddDrawable(shape2);

            Shape shape3 = new Shape()
            {
                StrokeColor = new Color(0.0f, 0.5f, 0.0f, 0.5f),
                StrokeWidth = 10.0f,
                StrokeJoin = Shape.StrokeJoinType.Miter,
            };
            shape3.Translate(100.0f, 300.0f);
            shape3.AddArc(0.0f, 0.0f, 80.0f, 10.0f, 120.0f, true);

            canvasView.AddDrawable(shape3);

            Shape shape4 = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 0.5f, 0.0f, 0.5f),
                StrokeColor = new Color(0.5f, 0.0f, 0.5f, 0.5f),
                StrokeWidth = 30.0f,
                FillRule = Shape.FillRuleType.EvenOdd,
                StrokeJoin = Shape.StrokeJoinType.Round,
            };
            shape4.Scale(0.5f);
            shape4.Translate(350.0f, 300.0f);
            shape4.AddMoveTo(0.0f, -160.0f);
            shape4.AddLineTo(125.0f, 160.0f);
            shape4.AddLineTo(-180.0f, -45.0f);
            shape4.AddLineTo(180.0f, -45.0f);    
            shape4.AddLineTo(-125.0f, 160.0f);
            shape4.Close();
            
            canvasView.AddDrawable(shape4);

            shape = new Shape()
            {
                Opacity = 0.5f,
                FillColor = new Color(0.0f, 1.0f, 1.0f, 1.0f),
                StrokeColor = new Color(0.5f, 1.0f, 0.5f, 1.0f),
                StrokeWidth = 30.0f,
                StrokeCap = Shape.StrokeCapType.Round,
            };
            shape.Translate(250.0f, 550.0f);
            shape.Scale(0.5f);
            shape.AddMoveTo(-1.0f, -165.0f);
            shape.AddLineTo(53.0f, -56.0f);
            shape.AddLineTo(174.0f, -39.0f);
            shape.AddLineTo(87.0f, 45.0f);
            shape.AddLineTo(107.0f, 166.0f);
            shape.AddLineTo(-1.0f, 110.0f);
            shape.AddLineTo(-103.0f, 166.0f);
            shape.AddLineTo(-88.0f, 46.0f);
            shape.AddLineTo(-174.0f, -38.0f);
            shape.AddLineTo(-54.0f, -56.0f);
            shape.Close();

            canvasView.AddDrawable(shape);

            // Test Getter
            log.Debug(tag, "Shape2 Color : " + shape2.FillColor.R + " " + shape2.FillColor.G + " " + shape2.FillColor.B + " " + shape2.FillColor.A + "\n");
            log.Debug(tag, "Shape2 StrokeColor : " + shape2.StrokeColor.R + " " + shape2.StrokeColor.G + " " + shape2.StrokeColor.B + " " + shape2.StrokeColor.A + "\n");

            log.Debug(tag, "Shape3 StrokeCap : " + shape3.StrokeCap + "\n");

            log.Debug(tag, "Shape4 FillRule : " + shape4.FillRule + "\n");
            log.Debug(tag, "Shape4 StrokeWidth : " + shape4.StrokeWidth + "\n");
            log.Debug(tag, "Shape4 StrokeJoin : " + shape4.StrokeJoin + "\n");
            log.Debug(tag, "Shape4 Opacity : " + shape4.Opacity + "\n");

            for (int i = 0; i < shape2.StrokeDash.Count; i++)
            {
                log.Debug(tag, "Shape4 StrokeDash : " + shape2.StrokeDash[i] + "\n");
            }

            // Exception test.
            try
            {
                shape2.Transform(new float[] {0.6f, 0.0f});
            }
            catch (ArgumentException e)
            {
                log.Debug(tag, "Transform : " + e.Message + "\n");
            }
            try
            {
                shape2.Transform(null);
            }
            catch (ArgumentException e)
            {
                log.Debug(tag, "Transform : " + e.Message + "\n");
            }
            try
            {
                shape2.StrokeDash = null;
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
                NUIApplication.GetDefaultWindow().Remove(root);
                canvasView.Dispose();
                root.Dispose();
            }
        }

        private bool onTick(object o, Timer.TickEventArgs e)
        {
            shape.Rotate((float)(count * 2.0f));
            shape.Scale((float)(count % 100) * 0.01f + 0.6f);
            count++;

            return true;
        }
    }
}
