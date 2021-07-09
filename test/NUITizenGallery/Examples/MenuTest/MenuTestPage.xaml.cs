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
    public partial class MenuTestPage : ContentPage
    {
        private MenuTestMenu menu;

        public MenuTestPage()
        {
            InitializeComponent();

            // FIXME: Need to write the following positioning in .xaml file.
            RelativeLayout.SetLeftRelativeOffset(buttonCenterEnd, 0.5f);
            RelativeLayout.SetRightRelativeOffset(buttonCenterEnd, 0.5f);
            RelativeLayout.SetHorizontalAlignment(buttonCenterEnd, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillHorizontal(buttonCenterEnd, false);
            RelativeLayout.SetTopRelativeOffset(buttonCenterEnd, 0.0f);
            RelativeLayout.SetBottomRelativeOffset(buttonCenterEnd, 0.0f);
            RelativeLayout.SetVerticalAlignment(buttonCenterEnd, RelativeLayout.Alignment.Start);
            RelativeLayout.SetFillVertical(buttonCenterEnd, false);

            RelativeLayout.SetLeftRelativeOffset(buttonCenterStart, 0.5f);
            RelativeLayout.SetRightRelativeOffset(buttonCenterStart, 0.5f);
            RelativeLayout.SetHorizontalAlignment(buttonCenterStart, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillHorizontal(buttonCenterStart, false);
            RelativeLayout.SetTopRelativeOffset(buttonCenterStart, 1.0f);
            RelativeLayout.SetBottomRelativeOffset(buttonCenterStart, 1.0f);
            RelativeLayout.SetVerticalAlignment(buttonCenterStart, RelativeLayout.Alignment.End);
            RelativeLayout.SetFillVertical(buttonCenterStart, false);

            RelativeLayout.SetLeftRelativeOffset(buttonEndCenter, 0.0f);
            RelativeLayout.SetRightRelativeOffset(buttonEndCenter, 0.0f);
            RelativeLayout.SetHorizontalAlignment(buttonEndCenter, RelativeLayout.Alignment.Start);
            RelativeLayout.SetFillHorizontal(buttonEndCenter, false);
            RelativeLayout.SetTopRelativeOffset(buttonEndCenter, 0.5f);
            RelativeLayout.SetBottomRelativeOffset(buttonEndCenter, 0.5f);
            RelativeLayout.SetVerticalAlignment(buttonEndCenter, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillVertical(buttonEndCenter, false);

            RelativeLayout.SetLeftRelativeOffset(buttonStartCenter, 1.0f);
            RelativeLayout.SetRightRelativeOffset(buttonStartCenter, 1.0f);
            RelativeLayout.SetHorizontalAlignment(buttonStartCenter, RelativeLayout.Alignment.End);
            RelativeLayout.SetFillHorizontal(buttonStartCenter, false);
            RelativeLayout.SetTopRelativeOffset(buttonStartCenter, 0.5f);
            RelativeLayout.SetBottomRelativeOffset(buttonStartCenter, 0.5f);
            RelativeLayout.SetVerticalAlignment(buttonStartCenter, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillVertical(buttonStartCenter, false);

            RelativeLayout.SetLeftRelativeOffset(buttonCenterCenter, 0.5f);
            RelativeLayout.SetRightRelativeOffset(buttonCenterCenter, 0.5f);
            RelativeLayout.SetHorizontalAlignment(buttonCenterCenter, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillHorizontal(buttonCenterCenter, false);
            RelativeLayout.SetTopRelativeOffset(buttonCenterCenter, 0.5f);
            RelativeLayout.SetBottomRelativeOffset(buttonCenterCenter, 0.5f);
            RelativeLayout.SetVerticalAlignment(buttonCenterCenter, RelativeLayout.Alignment.Center);
            RelativeLayout.SetFillVertical(buttonCenterCenter, false);

            buttonCenterEnd.Clicked += ButtonCenterEndClicked;
            buttonCenterStart.Clicked += ButtonCenterStartClicked;
            buttonEndCenter.Clicked += ButtonEndCenterClicked;
            buttonStartCenter.Clicked += ButtonStartCenterClicked;
            buttonCenterCenter.Clicked += ButtonCenterCenterClicked;
        }

        private void ButtonCenterEndClicked(object sender, ClickedEventArgs args)
        {
            Button button = sender as Button;

            menu = new MenuTestMenu();
            menu.Anchor = button;
            menu.HorizontalPositionToAnchor = Menu.RelativePosition.Center;
            menu.VerticalPositionToAnchor = Menu.RelativePosition.End;
            menu.Post();
        }

        private void ButtonCenterStartClicked(object sender, ClickedEventArgs args)
        {
            Button button = sender as Button;

            menu = new MenuTestMenu();
            menu.Anchor = button;
            menu.HorizontalPositionToAnchor = Menu.RelativePosition.Center;
            menu.VerticalPositionToAnchor = Menu.RelativePosition.Start;
            menu.Post();
        }

        private void ButtonEndCenterClicked(object sender, ClickedEventArgs args)
        {
            Button button = sender as Button;

            menu = new MenuTestMenu();
            menu.Anchor = button;
            menu.HorizontalPositionToAnchor = Menu.RelativePosition.End;
            menu.VerticalPositionToAnchor = Menu.RelativePosition.Center;
            menu.Post();
        }

        private void ButtonStartCenterClicked(object sender, ClickedEventArgs args)
        {
            Button button = sender as Button;

            menu = new MenuTestMenu();
            menu.Anchor = button;
            menu.HorizontalPositionToAnchor = Menu.RelativePosition.Start;
            menu.VerticalPositionToAnchor = Menu.RelativePosition.Center;
            menu.Post();
        }

        private void ButtonCenterCenterClicked(object sender, ClickedEventArgs args)
        {
            Button button = sender as Button;

            menu = new MenuTestMenu();
            menu.Anchor = button;
            menu.HorizontalPositionToAnchor = Menu.RelativePosition.Center;
            menu.VerticalPositionToAnchor = Menu.RelativePosition.Center;
            menu.Post();
        }
    }
}
