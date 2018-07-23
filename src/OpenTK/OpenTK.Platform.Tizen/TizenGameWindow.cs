/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using OpenTK.Graphics;

namespace OpenTK.Platform.Tizen
{
    internal class TizenGameWindow : GameWindow
    {
        public TizenGameWindow()
            : this(GraphicsMode.Default, DisplayDevice.Default, 2, 0)
        {
        }

        public TizenGameWindow(GraphicsMode mode, DisplayDevice device, int major, int minor)
            : base(device.Width, device.Height, mode, "", GameWindowFlags.FixedWindow, device, major, minor, GraphicsContextFlags.Embedded)
        {
            SDL2.SDL.SetHint("SDL_IOS_ORIENTATIONS", "Portrait LandscapeLeft LandscapeRight PortraitUpsideDown");
            Paused = false;
        }

        public bool Paused { get; set; }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (!Paused)
            {
                base.OnUpdateFrame(e);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (!Paused)
            {
                base.OnRenderFrame(e);
            }
        }

        public new void Run()
        {
            throw new NotSupportedException();
        }

        public new void Run(double updateRate)
        {
            throw new NotSupportedException();
        }

        public new void Run(double updates_per_second, double frames_per_second)
        {
            throw new NotSupportedException();
        }

        internal void RunInternal(double updates_per_second, double frames_per_second)
        {
            base.Run(updates_per_second, frames_per_second);
        }
    }
}
