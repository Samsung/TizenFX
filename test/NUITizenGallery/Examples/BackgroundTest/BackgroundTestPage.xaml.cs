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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class BackgroundTestPage : ContentPage
    {
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        private int CurrentImage = 0;
        private string[] BackgroundsArray = { "bg_0.png", "bg_1.png" };

        public BackgroundTestPage()
        {
            InitializeComponent();

            BackgroundView.BackgroundImage = ResourcePath + BackgroundsArray[CurrentImage];
            ChangeBackgroundButton.Clicked += OnChangeBackgroundButtonClicked;
        }

        public void OnChangeBackgroundButtonClicked(object sender, ClickedEventArgs args)
        {
            int current = CurrentImage == 0 ? 1 : 0;
            BackgroundView.BackgroundImage = ResourcePath + BackgroundsArray[CurrentImage = current];
        }
    }
}
