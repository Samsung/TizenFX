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
using Tizen.Applications.Messages;

namespace WidgetTemplate
{
    class RedWidget : Widget
    {
        string rcvPort = "my_widget_port";

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

            // Create receive port
             _rcvPort = new MessagePort(rcvPort, false);
             Tizen.Log.Info("NUI", "ReceivePort Create: " + _rcvPort.PortName + "Trusted: " + _rcvPort.Trusted);
             _rcvPort.MessageReceived += MessageReceived_Callback;
             _rcvPort.Listen();

            // For testing send to bundle data from widget to widgetViewer, pleaes enable this code.
            //timer = new Timer(5000);
            //timer.Tick += TimerTick;
            //timer.Start();
        }

        private void MessageReceived_Callback(object sender, MessageReceivedEventArgs e)
        {
            Tizen.Log.Info("NUI", "Message Received");
            Tizen.Log.Info("NUI", "App ID: " + e.Remote.AppId);
            Tizen.Log.Info("NUI", "PortName: " + e.Remote.PortName);
            Tizen.Log.Info("NUI", "Trusted: " + e.Remote.Trusted);
            Tizen.Log.Info("NUI", "message: " + e.Message.GetItem <string> ("message"));
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

/*
        private bool TimerTick(object source, Timer.TickEventArgs e)
        {
            Bundle bundle = new Bundle();
            bundle.AddItem("COUNT", "1");
            String encodedBundle = bundle.Encode();
            SetContentInfo(encodedBundle);
            return false;
        }
*/

        private static MessagePort _rcvPort;

        private View mRootView;
        private Animation mAnimation;
        private Timer timer;
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
            base.OnTerminate(contentInfo, type);
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

