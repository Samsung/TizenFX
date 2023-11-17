/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using System.Collections.Generic; // for Dictionary
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.Applications;

namespace WidgetTemplate
{
    class RedWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Tizen.Log.Info("NUI", "OnCreate(RedWidget) \n");
            Bundle bundle = Bundle.Decode(contentInfo);
            mRootView = new View();
            mRootView.BackgroundColor = Color.Red;
            mRootView.Size2D = window.Size;
            window.GetDefaultLayer().Add(mRootView);

            TextLabel sampleLabel = new TextLabel("Red Widget ");
            sampleLabel.FontFamily = "SamsungOneUI 500";
            sampleLabel.PointSize = 8;
            sampleLabel.TextColor = Color.Black;
            sampleLabel.SizeWidth = 300;
            sampleLabel.PivotPoint = PivotPoint.Center;
            mRootView.Add(sampleLabel);

            mAnimation = new Animation(1000);
            mAnimation.AnimateTo(sampleLabel, "PositionX", 300.0f);
            mAnimation.Looping = true;
            mAnimation.Play();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResize(Window window)
        {
            mRootView.Size2D = window.Size;
            base.OnResize(window);
        }

        protected override void OnTerminate(string contentInfo, TerminationType type)
        {
            base.OnTerminate(contentInfo, type);
        }

        protected override void OnUpdate(string contentInfo, int force)
        {
            base.OnUpdate(contentInfo, force);
        }

        private View mRootView;
        private Animation mAnimation;
    }

    class BlueWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Tizen.Log.Info("NUI", "OnCreate(BlueWidget) \n");
            Bundle bundle = Bundle.Decode(contentInfo);
            mRootView = new View();
            mRootView.BackgroundColor = Color.Blue;
            mRootView.Size2D = window.Size;
            window.GetDefaultLayer().Add(mRootView);

            TextLabel sampleLabel = new TextLabel("Blue Widget ");
            sampleLabel.FontFamily = "SamsungOneUI 500";
            sampleLabel.PointSize = 8;
            sampleLabel.TextColor = Color.Black;
            sampleLabel.SizeWidth = 300;
            sampleLabel.PivotPoint = PivotPoint.Center;
            mRootView.Add(sampleLabel);

            mAnimation = new Animation(1000);
            mAnimation.AnimateTo(sampleLabel, "PositionX", 400.0f);
            mAnimation.Looping = true;
            mAnimation.Play();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResize(Window window)
        {
            base.OnResize(window);
        }

        protected override void OnTerminate(string contentInfo, TerminationType type)
        {
            Tizen.Log.Info("NUI", "OnTerminate(BlueWidget) \n");
            mAnimation.Stop();
            mAnimation = null;
            mRootView.Dispose();
            mRootView = null;
            base.OnTerminate(contentInfo, type);

            // Call GC for deleting window directly
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        protected override void OnUpdate(string contentInfo, int force)
        {
            base.OnUpdate(contentInfo, force);
        }

        private View mRootView;
        private Animation mAnimation;
    }

    class Program : NUIWidgetApplication
    {
        public Program(Dictionary<System.Type, string> widgetSet) : base(widgetSet)
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            Dictionary<System.Type, string> widgetSet = new Dictionary<Type, string>();
            widgetSet.Add(typeof(RedWidget), "class1@Tizen.NUI.WidgetTest");
            widgetSet.Add(typeof(BlueWidget), "class2@Tizen.NUI.WidgetTest");
            var app = new Program(widgetSet);
            app.Run(args);
        }
    }
}

