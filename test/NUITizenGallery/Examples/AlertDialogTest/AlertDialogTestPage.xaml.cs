/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
    public partial class AlertDialogTestPage : ContentPage
    {
        public AlertDialogTestPage()
        {
            InitializeComponent();

            buttonWithXaml.Clicked += ButtonWithXamlClicked;
            buttonOneAction.Clicked += ButtonOneActionClicked;
            buttonTwoActions.Clicked += ButtonTwoActionsClicked;
            buttonNoTitle.Clicked += ButtonNoTitleClicked;
            buttonNoMessage.Clicked += ButtonNoMessageClicked;
            buttonTwoAlertDialog.Clicked += ButtonTwoAlertDialogClicked;
            buttonNewAlertDialog.Clicked += ButtonNewAlertDialogClicked;
            count = 0;
        }

        private int count;

        private void ButtonWithXamlClicked(object sender, ClickedEventArgs args)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new AlertDialogTestDialogPage());
        }

        private void ButtonOneActionClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "OK",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog("Title", "Message", button);
        }

        private void ButtonTwoActionsClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "Cancel",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            var button2 = new Button()
            {
                Text = "OK",
            };

            button2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog("Title", "Message", button, button2);
        }

        private void ButtonNoTitleClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "Cancel",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            var button2 = new Button()
            {
                Text = "OK",
            };

            button2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog(null, "Message", button, button2);
        }

        private void ButtonNoMessageClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "Cancel",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            var button2 = new Button()
            {
                Text = "OK",
            };

            button2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog("Title", null, button, button2);
        }

        private void ButtonTwoAlertDialogClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "OK",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog("Title", "Message", button);

            var button2 = new Button()
            {
                Text = "OK2",
            };

            button2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            DialogPage.ShowAlertDialog("Title2", "Message2", button2);
        }

        private void ButtonNewAlertDialogClicked(object sender, ClickedEventArgs args)
        {
            var button = new Button()
            {
                Text = "Cancel",
            };

            button.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            var button2 = new Button()
            {
                Text = $"New AlertDialog {++count}",
            };

            button2.Clicked += (object s, ClickedEventArgs a) =>
            {
                ButtonNewAlertDialogClicked(s, a);
            };

            DialogPage.ShowAlertDialog("Title", "Message", button, button2);
        }
    }
}
