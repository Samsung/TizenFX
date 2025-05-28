/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class Test1 : IExample
    {
        private Window window;
        private Animation animation;
        private Test1Page page;
        private Navigator navigator;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            navigator = window.GetDefaultNavigator();
            page = new Test1Page();
            navigator.Push(page);
            navigator.Popped += PoppedEvent;

            animation = new Animation(2000);
            animation.AnimateTo(page.test1PageText, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            animation.AnimateTo(page.test1PageText, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            animation.Looping = true;
            animation.Play();
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }

        void PoppedEvent(object obj, PoppedEventArgs ev)
        {
            if (ev.Page == page)
            {
                animation.Clear();
                animation = null;
                window = null;
                page.Dispose();
                page = null;
                navigator.Popped -= PoppedEvent;
                navigator = null;
            }
        }
    }
}
