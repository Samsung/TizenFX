using System.Collections.Generic;

namespace ElmSharp.Test
{
    class GestureLayerTest2 : TestCaseBase
    {
        public override string TestName => "GestureLayerTest2";
        public override string TestDescription => "GestureLayer feature : Momentum & Rotate Test.";

        private GestureLayer _glayer;
        private Label _log;
        private List<string> _logEntries;
        private Background _background;
        private Rectangle _box1;

        int _angle = 0;
        int _prevAngle = 0;
        int _totalX = 0;
        int _totalY = 0;

        public override void Run(Window window)
        {
            _background = new Background(window);
            var windowSize = window.ScreenSize;
            _background.Color = Color.White;
            _background.Resize(windowSize.Width, windowSize.Height);
            _background.Show();

            _box1 = new Rectangle(window)
            {
                Color = Color.Yellow
            };
            _box1.Resize(400, 600);
            _box1.Move(160, 160);
            _box1.Show();

            _log = new Label(window);
            _log.Resize(700, 1280 - 780);
            _log.Move(10, 770);
            _log.Show();
            _logEntries = new List<string>();
            Log("Momentum & Roate Gesture Test.");

            _glayer = new GestureLayer(_box1);
            _glayer.Attach(_box1);

            _glayer.RotateStep = 3;
            _glayer.SetRotateCallback(GestureLayer.GestureState.Start, (rotate) =>
            {
                _prevAngle = (int)rotate.BaseAngle;
            });

            _glayer.SetRotateCallback(GestureLayer.GestureState.Move, (rotate) =>
            {
                if (_box1.IsMapEnabled)
                {
                    _angle += (int)rotate.Angle - _prevAngle;
                    _prevAngle = (int)rotate.Angle;
                    Log($"@@ Rotation XY:({rotate.X},{rotate.Y}) a:{rotate.Angle:F2} ba:{rotate.BaseAngle:F2} total:{_angle}");
                    ApplyTransformation();
                }
            });

            int prevX = 0, prevY = 0;
            _glayer.SetMomentumCallback(GestureLayer.GestureState.Start, (data) =>
            {
                if (data.FingersCount == 1)
                {
                    prevX = _glayer.EvasCanvas.Pointer.X;
                    prevY = _glayer.EvasCanvas.Pointer.Y;
                }
            });
            _glayer.SetMomentumCallback(GestureLayer.GestureState.Move, (data) =>
            {
                if (data.FingersCount == 1)
                {
                    data.X2 = _glayer.EvasCanvas.Pointer.X;
                    data.Y2 = _glayer.EvasCanvas.Pointer.Y;
                    _totalX += (data.X2 - prevX);
                    _totalY += (data.Y2 - prevY);
                    prevX = data.X2;
                    prevY = data.Y2;
                    Log($"@@ Momentum X:({prevX},{data.X2}), Y({prevY},{data.Y2}) = Total:({(data.X2 - prevX)}, {(data.Y2 - prevY)})");
                    ApplyTransformation();
                }
            });
            _glayer.SetMomentumCallback(GestureLayer.GestureState.Abort, (data) =>
            {
                Log($"@@ Momentum Abort");
            });
            _glayer.SetMomentumCallback(GestureLayer.GestureState.End, (data) =>
            {
                Log($"@@ Momentum End");
            });
        }

        void ApplyTransformation()
        {
            EvasMap map = new EvasMap(4);
            Rect geometry = _box1.Geometry;
            map.PopulatePoints(geometry, 0);

            map.Rotate3D(0, 0, _angle, (int)(geometry.X + geometry.Width * 0.5), (int)(geometry.Y + geometry.Height * 0.5), 0);

            Point3D p;
            for (int i = 0; i < 4; i++)
            {
                p = map.GetPointCoordinate(i);
                p.X += _totalX;
                p.Y += _totalY;
                map.SetPointCoordinate(i, p);
            }
            _box1.EvasMap = map;
            _box1.IsMapEnabled = true;
        }

        private void Log(string format, params object[] args)
        {
            var entry = string.Format(format, args);
            if (_logEntries.Count > 15)
                _logEntries.RemoveRange(0, _logEntries.Count - 15);
            _logEntries.Add(entry);
            _log.Text = string.Join("<br>", _logEntries);
        }
    }
}