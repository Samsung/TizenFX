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

using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ProviderSample
{
    class Program : NUIApplication
    {
        private View layoutView;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Tizen.Log.Error("NUI", "OnAppControlReceived - Provider");
            string message;
            ReceivedAppControl receivedAppControl = e.ReceivedAppControl;

            /// Get ExtraData coming from caller application
            message = receivedAppControl.ExtraData.Get<string>("Color");

            Color[] colors = { Color.Red, Color.Blue, Color.Cyan, Color.Yellow };
            layoutView.BackgroundColor = colors[int.Parse(message)];

            if (receivedAppControl.IsReplyRequest)
            {
                AppControl replyRequest = new AppControl();

                /// Send reply to the caller application
                receivedAppControl.ReplyToLaunchRequest(replyRequest, AppControlReplyResult.Succeeded);
            }


            base.OnAppControlReceived(e);
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            CreateUI();

            ApplicationTransitionManager.Instance.ApplicationFrameType = FrameType.FrameProvider;
        }

        private void CreateUI()
        {
            layoutView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
                Layout = new AbsoluteLayout(),
            };
            layoutView.TouchEvent += ContentPage_TouchEvent;
            Window.Instance.Add(layoutView);
        }

        private bool ContentPage_TouchEvent(object source, View.TouchEventArgs e)
        {
            //앱 런칭
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Window.Instance.Lower();
            }
            return false;
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
            var app = new Program();
            app.Run(args);
        }
    }
}
