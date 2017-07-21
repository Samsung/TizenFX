/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test.Wearable
{
    class GestureLayerTest1 : WearableTestCase
    {
        public override string TestName => "GestureLayerTest1";
        public override string TestDescription => "Demonstrate GestureLayer features: Tap, DoubleTap, Rotate, Zoom detection.";

        private GestureLayer _glayer;
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
            _box1.Geometry = window.GetInnerSquare();
            _box1.Show();

            Msg("Double tap to register additional gestures. Tripple tap to unregister them.");

            _glayer = new GestureLayer(_box1);
            _glayer.Attach(_box1);

            _glayer.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) => {
                Msg("Tap {0},{1}", info.X, info.Y);
            });

            _glayer.SetTapCallback(GestureLayer.GestureType.DoubleTap, GestureLayer.GestureState.End, (info) => {
                Msg("DoubleTap {0},{1} {2}", info.X, info.Y, info.FingersCount);
                _glayer.SetLineCallback(GestureLayer.GestureState.End, (line) => {
                    Msg("Line {0},{1}-{2},{3}, M:{4},{5}", line.X1, line.Y1, line.X2, line.Y2, line.HorizontalMomentum, line.VerticalMomentum);
                });
                _glayer.SetFlickCallback(GestureLayer.GestureState.End, (flick) => {
                    Msg("Flick {0},{1}-{2},{3}, M:{4},{5}", flick.X1, flick.Y1, flick.X2, flick.Y2, flick.HorizontalMomentum, flick.VerticalMomentum);
                });
                _glayer.RotateStep = 3;
                _glayer.SetRotateCallback(GestureLayer.GestureState.Move, (rotate) => {
                    Msg("Rotation {0},{1} a:{2:F3} ba:{3:F3}", rotate.X, rotate.Y, rotate.Angle, rotate.BaseAngle);
                });
                _glayer.SetZoomCallback(GestureLayer.GestureState.End, (zoom) => {
                    Msg("Zoom {0},{1} r:{2} z:{3:F3}", zoom.X, zoom.Y, zoom.Radius, zoom.Zoom);
                });
                Msg("Line, Flick, Rotate, and Zoom callbacks enabled.");
            });

            _glayer.SetTapCallback(GestureLayer.GestureType.TripleTap, GestureLayer.GestureState.End, (info) => {
                Msg("TrippleTap {0},{1} {2}", info.X, info.Y, info.FingersCount);
                _glayer.SetLineCallback(GestureLayer.GestureState.End, null);
                _glayer.SetFlickCallback(GestureLayer.GestureState.End, null);
                _glayer.SetRotateCallback(GestureLayer.GestureState.Move, null);
                _glayer.SetZoomCallback(GestureLayer.GestureState.End, null);
                Msg("Cleared Line, Flick, Rotate, and Zoom callbacks.");
            });
            // Momentum is not used, it seems that it conflicts with Rotate and Zoom
        }

        private void Msg(string format, params object[] args)
        {
            var entry = string.Format(format, args);
            Log.Debug(entry);
        }
    }
}
