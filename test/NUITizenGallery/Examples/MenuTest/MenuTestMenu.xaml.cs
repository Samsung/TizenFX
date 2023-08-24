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
    public partial class MenuTestMenu : Menu
    {
        public MenuTestMenu()
        {
            InitializeComponent();

            // FIXME: For now, menuItem1, 2, 3, 4 handles are not found by FindByName.
            /*
            menuItem1.Clicked += MenuItem1Clicked;
            menuItem2.Clicked += MenuItem2Clicked;
            menuItem3.Clicked += MenuItem3Clicked;
            menuItem4.Clicked += MenuItem4Clicked;
            */
        }

        private void MenuItem1Clicked(object sender, ClickedEventArgs args)
        {
            this.Dismiss();
        }

        private void MenuItem2Clicked(object sender, ClickedEventArgs args)
        {
            this.Dismiss();
        }

        private void MenuItem3Clicked(object sender, ClickedEventArgs args)
        {
            this.Dismiss();
        }

        private void MenuItem4Clicked(object sender, ClickedEventArgs args)
        {
            this.Dismiss();
        }
    }
}
