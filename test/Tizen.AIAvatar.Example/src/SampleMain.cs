/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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


namespace AIAvatar
{
    partial class Program : NUIApplication
    {
        private Window window;
        private AvatarScene avatarScene;

        private UIControlPanel uiControlPanel;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {         
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1.0f); ;

            window.AddAvailableOrientation(Window.WindowOrientation.Landscape);
            window.AddAvailableOrientation(Window.WindowOrientation.Portrait);
            window.AddAvailableOrientation(Window.WindowOrientation.LandscapeInverse);
            window.AddAvailableOrientation(Window.WindowOrientation.PortraitInverse);

            window.Resized += OnResizedEvent;
            window.KeyEvent += OnKeyEvent;

            MakeBackground();
            MakeAvatarScene();
            MakeUIPanel();

            RecalculatePositionSizeFromWindowSize();
        }

        private void OnResizedEvent(object sender, Window.ResizedEventArgs e)
        {
            RecalculatePositionSizeFromWindowSize();
        }

        private void MakeBackground()
        {
            var backgroundView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Images/UI_BG.png",
            };
            backgroundView.TouchEvent += (o, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    Tizen.Log.Error("NUI", $"Background touched.\n");
                }
                return true;
            };
            window.Add(backgroundView);
        }

        private void MakeAvatarScene()
        {
            avatarScene = new AvatarScene();           
            window.Add(avatarScene);
            
        }

        private void MakeUIPanel()
        {
            uiControlPanel = new UIControlPanel();
            uiControlPanel.OnExitButtonClicked += OnExitButtonClicked;
            uiControlPanel.MakeControlPannel(window, avatarScene);
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void RecalculatePositionSizeFromWindowSize()
        {
            uiControlPanel.ReizeUIPanel(avatarScene);
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            
            if (e.Key.State != Key.StateType.Down)
            {
                return;
            }

            if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "BackSapce")
            {
                ExitApplication();
            }
        }

        private void ExitApplication()
        {
            Utils.FullGC();
            Exit();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
