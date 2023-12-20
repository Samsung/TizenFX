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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;
namespace WidgetApplicationTemplate
{
    class Program : NUIApplication
    {
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
            mWidgetView.CornerRadius = 40;
            mWidgetView.Position = new Position(100,100);
            window.GetDefaultLayer().Add(mWidgetView);

            mWidgetView2 = WidgetViewManager.Instance.AddWidget("class2@Tizen.NUI.WidgetTest", encodedBundle, widgetWidth, widgetHeight, 0.0f);
            mWidgetView2.Position = new Position(100, widgetHeight + 110);
            mWidgetView2.CornerRadius = 22;
            window.GetDefaultLayer().Add(mWidgetView2);

            mTimer = new Timer(4000);
            mTimer.Tick += onTick;
            mTimer.Start();

            created = true;
        }

        private bool onTick(object o, Timer.TickEventArgs e)
        {
            Window window = GetDefaultWindow();
            if(created)
            {
                WidgetViewManager.Instance.RemoveWidget(mWidgetView2);
                mWidgetView2.Dispose();
                mWidgetView2 = null;
                created = false;
            }
            else
            {
                Bundle bundle = new Bundle();
                bundle.AddItem("COUNT", "1");
                String encodedBundle = bundle.Encode();

                mWidgetView2 = WidgetViewManager.Instance.AddWidget("class2@Tizen.NUI.WidgetTest", encodedBundle, widgetWidth, widgetHeight, 0.0f);
                mWidgetView2.Position = new Position(100, widgetHeight + 110);
                mWidgetView2.CornerRadius = 22;
                window.GetDefaultLayer().Add(mWidgetView2);

                bundle.Dispose();
                bundle = null;
                created = true;
            }
            return true;
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
                }

            }
        }
        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
        }
        private void OnWidgetContentUpdatedCB(object sender, WidgetView.WidgetViewEventArgs e)
        {
            String encodedBundle = e.WidgetView.ContentInfo;
            Bundle bundle = Bundle.Decode(encodedBundle);
            string outString;
            if (bundle.TryGetItem("WidgetKey", out outString))
            {
                Tizen.Log.Info("NUI", "OnWidgetContentUpdatedCB : " + outString + "\n");
            }

        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private View rootView;
        WidgetView mWidgetView;
        WidgetView mWidgetView2;
        int widgetWidth;
        int widgetHeight;

        Timer mTimer;
        bool created;

        Window mWindow;
    }
}


