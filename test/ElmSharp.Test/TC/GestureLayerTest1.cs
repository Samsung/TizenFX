using System;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    class GestureLayerTest1 : TestCaseBase
    {
        public override string TestName => "GestureLayerTest1";
        public override string TestDescription => "Demonstrate GestureLayer features: Tap, DoubleTap, Rotate, Zoom detection.";

        private GestureLayer _glayer;
        private Label _log;
        private List<string> _logEntries;
        private Background _background;
        private Rectangle _box1;

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
            Log("Double tap to register additional gestures. Tripple tap to unregister them.");

            _glayer = new GestureLayer(_box1);
            _glayer.Attach(_box1);

            _glayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) => {
                Log("Tap {0},{1}", info.X, info.Y);
            });

            _glayer.SetTapCallback(GestureLayer.GestureType.DoubleTap, GestureLayer.GestureState.End, (info) => {
                Log("DoubleTap {0},{1} {2}", info.X, info.Y, info.FingersCount);
                _glayer.SetLineCallback(GestureLayer.GestureState.End, (line) => {
                    Log("Line {0},{1}-{2},{3}, M:{4},{5}", line.X1, line.Y1, line.X2, line.Y2, line.HorizontalMomentum, line.VerticalMomentum);
                });
                _glayer.SetFlickCallback(GestureLayer.GestureState.End, (flick) => {
                    Log("Flick {0},{1}-{2},{3}, M:{4},{5}", flick.X1, flick.Y1, flick.X2, flick.Y2, flick.HorizontalMomentum, flick.VerticalMomentum);
                });
                _glayer.RotateStep = 3;
                _glayer.SetRotateCallback(GestureLayer.GestureState.Move, (rotate) => {
                    Log("Rotation {0},{1} a:{2:F3} ba:{3:F3}", rotate.X, rotate.Y, rotate.Angle, rotate.BaseAngle);
                });
                _glayer.SetZoomCallback(GestureLayer.GestureState.End, (zoom) => {
                    Log("Zoom {0},{1} r:{2} z:{3:F3}", zoom.X, zoom.Y, zoom.Radius, zoom.Zoom);
                });
                Log("Line, Flick, Rotate, and Zoom callbacks enabled.");
            });

            _glayer.SetTapCallback(GestureLayer.GestureType.TripleTap, GestureLayer.GestureState.End, (info) => {
                Log("TrippleTap {0},{1} {2}", info.X, info.Y, info.FingersCount);
                _glayer.SetLineCallback(GestureLayer.GestureState.End, null);
                _glayer.SetFlickCallback(GestureLayer.GestureState.End, null);
                _glayer.SetRotateCallback(GestureLayer.GestureState.Move, null);
                _glayer.SetZoomCallback(GestureLayer.GestureState.End, null);
                Log("Cleared Line, Flick, Rotate, and Zoom callbacks.");
            });
            // Momentum is not used, it seems that it conflicts with Rotate and Zoom
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
