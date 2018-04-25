/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Examples
{
    public class ButtonTestPage : ContentPage
    {

        public ButtonTestPage(Window win) : base (win)
        {
        }

        public override void SetFocus()
        {
            // PushButton button1 = Content.FindChildByName("Button1") as PushButton;
            // PushButton button2 = Content.FindChildByName("Button2") as PushButton;
            // button1.DownFocusableView = button2;
            // button2.UpFocusableView = button1;
            // FocusManager.Instance.SetCurrentFocusView(button1);
        }

        private bool OnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                button.LabelText = "Click Me";
            }
            return true;
        }

        private bool OnPressed(object sender, EventArgs e)
        {
            return true;
        }

        private bool OnReleased(object sender, EventArgs e)
        {
            return true;
        }

        private bool OnStateChanged(object sender, EventArgs e)
        {
            return true;
        }
    }
}