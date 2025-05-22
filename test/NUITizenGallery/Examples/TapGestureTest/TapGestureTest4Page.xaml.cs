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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class TapGestureTest4Page : ContentPage
    {
        private TapGestureDetector imageTapDetector;
        private TapGestureDetector boxviewTapDetector;
        private TapGestureDetector labelTapDetector;

        public TapGestureTest4Page()
        {
            InitializeComponent();

            text1.Text = "  Please tap the following widgets. \n : Image / BoxView / Button / Label";

            imageTapDetector = new TapGestureDetector();
            boxviewTapDetector = new TapGestureDetector();
            labelTapDetector = new TapGestureDetector();

            imageTapDetector.Attach(imageView);
            imageTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "An image is tapped";
            };

            boxviewTapDetector.Attach(boxView);
            boxviewTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "A boxview is tapped";
            };

            button1.Clicked += (obj, e) =>
            {
                text2.Text = "A button is tapped";
            };

            labelTapDetector.Attach(label1);
            labelTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "A label is tapped";
            };

        }
    }
}
