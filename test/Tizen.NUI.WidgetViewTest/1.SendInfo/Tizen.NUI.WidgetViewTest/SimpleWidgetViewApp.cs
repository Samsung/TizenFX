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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;
using Tizen.Applications.Messages;

namespace WidgetApplicationTemplate
{
    class Program : NUIApplication
    {
        string widgetAppId = "Tizen.NUI.WidgetTest";
        string rcvPort = "my_widget_port";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        void Initialize()
        {
            Window window = GetDefaultWindow();

            window.KeyEvent += OnKeyEvent;
            window.TouchEvent += OnTouchEvent;
            
            rootView = new View();
            rootView.BackgroundColor = Color.White;
            rootView.Size = Window.Instance.Size;
            rootView.PivotPoint = PivotPoint.Center;
            window.GetDefaultLayer().Add(rootView);

            TextLabel sampleLabel = new TextLabel("Widget Viewer ");
            sampleLabel.FontFamily = "SamsungOneUI 500";
            sampleLabel.PointSize = 8;
            sampleLabel.TextColor = Color.Black;
            sampleLabel.SizeWidth = 300;
            sampleLabel.PivotPoint = PivotPoint.Center;
            rootView.Add(sampleLabel);

            Bundle bundle = new Bundle();
            bundle.AddItem("COUNT", "1");
            String encodedBundle = bundle.Encode();

            widgetWidth = 500;
            widgetHeight = 500;
            mWidgetView = WidgetViewManager.Instance.AddWidget("class1@Tizen.NUI.WidgetTest", encodedBundle, widgetWidth, widgetHeight, 0.0f);
            mWidgetView.Position = new Position(100,100);
            window.GetDefaultLayer().Add(mWidgetView);

            //mWidgetView.WidgetContentUpdated += OnWidgetContentUpdatedCB;

            mWidgetView2 = WidgetViewManager.Instance.AddWidget("class2@Tizen.NUI.WidgetTest", encodedBundle, widgetWidth, widgetHeight, 0.0f);
            mWidgetView2.Position = new Position(100, widgetHeight + 110);
            window.GetDefaultLayer().Add(mWidgetView2);

            // Send message using port
            _msgPort = new MessagePort(rcvPort, false);
            Tizen.Log.Info("NUI", "MessagePort Create: " + _msgPort.PortName + "Trusted: " + _msgPort.Trusted);
            _msgPort.Listen();
        }
        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down )
            {
                Tizen.Log.Info("NUI", "OnKeyEvent(View-Window) : " + e.Key.KeyPressedName + "\n");
                if (e.Key.KeyPressedName == "1")
                {
                    widgetWidth += 200;
                    widgetHeight += 200;
                    if(widgetWidth > 1000 || widgetHeight > 1000)
                    {
                        widgetWidth = 200;
                        widgetHeight = 200;
                    }
                    mWidgetView.Size2D = new Size2D(widgetWidth, widgetHeight);

                    // Send the WidgetView's width to Widget
                    var msg = new Bundle();
                    msg.AddItem("message", "WidgetView's message >> width:" + widgetWidth);
                    _msgPort.Send(msg, widgetAppId, rcvPort);
                }

            }
        }
        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
        }

/*
        private void OnWidgetContentUpdatedCB(object sender, WidgetView.WidgetViewEventArgs e)
        {
            String encodedBundle = e.WidgetView.ContentInfo;
            Tizen.Log.Info("NUI", "tscholb : OnWidgetContentUpdatedCB : " + encodedBundle + "\n");
            Bundle bundle = Bundle.Decode(encodedBundle);
            string outString;
            if (bundle.TryGetItem("COUNT", out outString))
            {
                Tizen.Log.Info("NUI", "OnWidgetContentUpdatedCB(2) : " + outString + "\n");
            }

        }
*/

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private static MessagePort _msgPort;
        private View rootView;
        WidgetView mWidgetView;
        WidgetView mWidgetView2;
        int widgetWidth;
        int widgetHeight;
    }
}


