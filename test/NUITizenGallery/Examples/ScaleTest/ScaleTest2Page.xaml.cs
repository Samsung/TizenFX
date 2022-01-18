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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ScaleTest2Page : ContentPage
    {
        private Vector3[] Scales = {
                                    new Vector3(1.0f, 1.0f, 1.0f),
                                    new Vector3(1.1f, 1.1f, 1.0f),
                                    new Vector3(1.2f, 1.2f, 1.0f),
                                    new Vector3(1.3f, 1.3f, 1.0f),
                                    new Vector3(1.4f, 1.4f, 1.0f),
                                    new Vector3(1.5f, 1.5f, 1.0f),
                                    new Vector3(1.6f, 1.6f, 1.0f),
                                    new Vector3(1.7f, 1.7f, 1.0f),
                                    new Vector3(1.8f, 1.8f, 1.0f),
                                    new Vector3(1.9f, 1.9f, 1.0f)
                                   };
        private int i = 0;

        public ScaleTest2Page()
        {
            InitializeComponent();
            ScaleChangeButton.Clicked += OnButtonClicked;
            ScaleButton.Clicked += OnButtonClicked;
        }

        private void OnButtonClicked(object sender, ClickedEventArgs args)
        {
            ScaleButton.Scale = Scales[i++ % 4];
        }
    }
}
