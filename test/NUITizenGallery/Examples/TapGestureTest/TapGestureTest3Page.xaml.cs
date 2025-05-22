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
    public partial class TapGestureTest3Page : ContentPage
    {
        private TapGestureDetector tapDetector;
        private int tapCount;
        private uint buttonClicked;

        public TapGestureTest3Page()
        {
            InitializeComponent();

            buttonClicked = 0;
            tapCount = 0;

            tapDetector = new TapGestureDetector();
            text2.Text = "Number of taps required : "+tapDetector.GetMaximumTapsRequired();

            button1.Clicked += (o, e) =>
            {
                ++buttonClicked;
                buttonClicked = buttonClicked % 2;

                if(buttonClicked == 0)
                {
                    tapDetector.SetMinimumTapsRequired(1);
                    tapDetector.SetMaximumTapsRequired(1);
                }
                else
                {
                    tapDetector.SetMaximumTapsRequired(2);
                    tapDetector.SetMinimumTapsRequired(2);
                }


                text2.Text = "Number of taps required : "+tapDetector.GetMaximumTapsRequired();
            };

            tapDetector.Attach(imageView);
            tapDetector.Detected += (obj, e) =>
            {
                tapCount++;
                text1.Text = tapCount + " taps so far!";

                if((tapCount%2) > 0)
                {
                    imageView.BorderlineWidth = 5f;
                    imageView.BorderlineColor = Color.Red;
                }
                else
                {
                    imageView.BorderlineWidth = 0f;
                }
            };
        }
    }
}
