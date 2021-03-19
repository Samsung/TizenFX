using Tizen.NUI.BaseComponents;
using Tizen.NUI.BaseComponents.VectorGraphics;
using System.Collections.Generic;

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

            Shape shape1 = new Shape();
            shape1.AddRect(-50.0f, -50.0f, 100.0f, 100.0f, 10.0f, 10.0f);
            shape1.SetFillColor(new Color(0.5f, 1.0f, 0.0f, 1.0f));
            shape1.SetStrokeColor(new Color(0.5f, 0.0f, 0.0f, 0.5f));
            shape1.SetStrokeWidth(10.0f);
            
            shape1.Translate(100.0f, 100.0f);
            shape1.Scale(1.2f);
            shape1.Rotate(45.0f);
           
            canvasView.AddDrawable(shape1);

            Shape shape2 = new Shape();
            shape2.AddCircle(0.0f, 0.0f, 150.0f, 100.0f);
            shape2.SetOpacity(0.5f);
            shape2.SetFillColor(new Color(0.0f, 0.0f, 1.0f, 1.0f));
            shape2.SetStrokeColor(new Color(1.0f, 1.0f, 0.0f, 1.0f));
            shape2.SetStrokeWidth(10.0f);
            shape2.SetStrokeDash(new float[] {15.0f, 30.0f}, 2);

            shape2.Transform(new float[] {0.6f, 0.0f, 350.0f, 0.0f, 0.6f, 100.0f, 0.0f, 0.0f, 1.0f});

            canvasView.AddDrawable(shape2);

            Shape shape3 = new Shape();
            shape3.AddArc(0.0f, 0.0f, 80.0f, 10.0f, 120.0f, true);
            shape3.SetStrokeColor(new Color(0.0f, 0.5f, 0.0f, 0.5f));
            shape3.SetStrokeWidth(10.0f);
            shape3.Translate(100.0f, 300.0f);
            shape3.SetStrokeJoin(Shape.StrokeJoin.Miter);
            canvasView.AddDrawable(shape3);

            Shape shape4 = new Shape();
            shape4.AddMoveTo(0.0f, -160.0f);
            shape4.AddLineTo(125.0f, 160.0f);
            shape4.AddLineTo(-180.0f, -45.0f);
            shape4.AddLineTo(180.0f, -45.0f);    
            shape4.AddLineTo(-125.0f, 160.0f);
            shape4.Close();
            shape4.SetFillColor(new Color(0.0f, 0.5f, 0.0f, 0.5f));
            shape4.SetStrokeColor(new Color(0.5f, 0.0f, 0.5f, 0.5f));
            shape4.SetStrokeWidth(30.0f);
            shape4.Translate(350.0f, 300.0f);
            shape4.Scale(0.5f);
            shape4.SetFillRule(Shape.FillRule.EvenOdd);
            shape4.SetStrokeJoin(Shape.StrokeJoin.Round);
            shape4.SetOpacity(0.5f);
            
            canvasView.AddDrawable(shape4);

            shape = new Shape();
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

            shape.SetFillColor(new Color(0.0f, 1.0f, 1.0f, 1.0f));
            shape.SetStrokeColor(new Color(0.5f, 1.0f, 0.5f, 1.0f));
            shape.SetStrokeWidth(30.0f);
            shape.SetStrokeCap(Shape.StrokeCap.Round);
            shape.Scale(0.6f);
            shape.Translate(250.0f, 550.0f);
            shape.SetOpacity(0.5f);

            canvasView.AddDrawable(shape);

            timer = new Timer(1000 / 32);
            timer.Tick += onTick;
            timer.Start();


            // Test Get APIs
            Color shape2Color = shape2.GetFillColor();
            log.Debug(tag, "Shape2 Color : " + shape2Color.R + " " + shape2Color.G + " " + shape2Color.B + " " + shape2Color.A + "\n");

            Color shape2StrockeColor = shape2.GetStrokeColor();
            log.Debug(tag, "Shape2 StrokeColor : " + shape2StrockeColor.R + " " + shape2StrockeColor.G + " " + shape2StrockeColor.B + " " + shape2StrockeColor.A + "\n");

            log.Debug(tag, "Shape3 StrokeCap : " + shape3.GetStrokeCap() + "\n");

            log.Debug(tag, "Shape4 FillRule : " + shape4.GetFillRule() + "\n");
            log.Debug(tag, "Shape4 StrokeWidth : " + shape4.GetStrokeWidth() + "\n");
            log.Debug(tag, "Shape4 StrokeJoin : " + shape4.GetStrokeJoin() + "\n");
            log.Debug(tag, "Shape4 Opacity : " + shape4.GetOpacity() + "\n");

            List<float> pattern = shape2.GetStrokeDash();
            for (int i = 0; i < pattern.Count; i++)
            {
                log.Debug(tag, "Shape4 StrokeDash : " + pattern[i] + "\n");
            }
            
            root.Add(canvasView);
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
