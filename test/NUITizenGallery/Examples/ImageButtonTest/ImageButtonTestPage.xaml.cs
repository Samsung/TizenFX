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

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ImageButtonTestPage : ContentPage
    {
        string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        public ImageButtonTestPage()
        {
            InitializeComponent();
            button1.Icon.ResourceUrl = ImageURL + "NUITizenGallery.png";
            button1.Icon.Size2D = new Tizen.NUI.Size2D(300, 300);

            button1.ControlStateChangedEvent += (o, e) =>
            {
                if (e.CurrentState == ControlState.Normal) {
                    text1.Text = "Normal";
                }
                if (e.CurrentState == ControlState.Pressed) {
                    text1.Text = "Pressed";
                }
            };
        }
    }
}
