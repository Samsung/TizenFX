/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public class FrameUpdate : FrameUpdateCallbackInterface
    {
        private static float frameCnt = 0;
        private static float avgElapsedTime = 0;
        private static float avgFPS = 0;

        public void Reset()
        {
            frameCnt = 0;
            avgElapsedTime = 0;
            avgFPS = 0;
        }
        
        public float GetFPS()
        {
            return avgFPS;
        }

        public override void OnUpdate(float elapsedSeconds)
        {
            frameCnt++;
            var oldWeight = (frameCnt - 1) / frameCnt;
            var newWeight = 1 / frameCnt;
            avgElapsedTime = avgElapsedTime * oldWeight + elapsedSeconds * newWeight;
            avgFPS = avgElapsedTime == 0 ? 0 : 1 / avgElapsedTime;
        }
    }

    public partial class PerformanceTest1Page : ContentPage
    {
        private int TestItems = 1000;
        private int ScrollTime = 5000;
        private Window AppWindow;
        private FrameUpdate FPSCounter;
        private bool MeasurementStarted;

        public PerformanceTest1Page()
        {
            InitializeComponent();

            FPSCounter = new FrameUpdate();

            AppWindow = NUIApplication.GetDefaultWindow();
            StartButton.Clicked += OnButtonScrollClicked;
            Scroller.ScrollDuration = ScrollTime;

            var items = new ListItemTitle[TestItems];
            for (int i = 0; i < TestItems; i++) {
                items[i] = new ListItemTitle("item: " + i.ToString());
                Scroller.Add(items[i]);
            }
        }

        private void OnButtonScrollClicked(object sender, ClickedEventArgs args)
        {
            if (MeasurementStarted == true) return; 

            MeasurementStarted = true;

            Scroller.ScrollToIndex(999);

            FPSCounter.Reset();
            AppWindow.RemoveFrameUpdateCallback(FPSCounter);
            AppWindow.AddFrameUpdateCallback(FPSCounter);

            FPSLabel.Text = "Measuring scrolling FPS...";
            Scroller.ScrollAnimationEnded += OnScrollAnimaionEnded;
        }

        private void OnScrollAnimaionEnded(object sender, ScrollEventArgs args)
        {
            FPSLabel.Text = "Average FPS: " + FPSCounter.GetFPS();
        }

        protected override void Dispose(DisposeTypes type)
        {
            AppWindow.RemoveFrameUpdateCallback(FPSCounter);

            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }

                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }
}
