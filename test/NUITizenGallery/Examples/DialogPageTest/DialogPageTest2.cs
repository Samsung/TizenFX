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

using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public class DialogPageContentPage2 : ContentPage
    {
        private Window window = null;
        private DialogPage testDialogPage = null;

        public DialogPageContentPage2(Window win)
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            AppBar = new AppBar()
            {
                Title = "Dialog page Sample",
            };

            window = win;

            var button = new Button()
            {
                Text = "Click to show Dialog",
                WidthSpecification = 400,
                HeightSpecification = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            button.Clicked += (object sender, ClickedEventArgs e) =>
            {
                var dialogPage = new DialogPage()
                {
                    //WidthSpecification = 600,
                    //HeightSpecification = 600,
                    EnableScrim = true,
                    EnableDismissOnScrim = false,
                    ScrimColor = Color.Green,
                };

                testDialogPage = dialogPage;

                var textLabel = new TextLabel("Message")
                {
                    BackgroundColor = Color.White,
                    Size = new Size(180, 180),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                var positiveButton = new Button()
                {
                    Text = "Yes",
                };
                positiveButton.Clicked += (object s1, ClickedEventArgs e1) =>
                {
                    window.GetDefaultNavigator().Pop();
                    testDialogPage.Dispose();
                    testDialogPage = null;
                };

                var content = new View()
                {
                    WidthSpecification = 600,
                    HeightSpecification = 600,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    },
                    BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                };

                content.Add(textLabel);
                content.Add(positiveButton);

                dialogPage.Content = content;

                NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
            };

            Content = button;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Deactivate();
            }

            base.Dispose(type);
        }

        private void Deactivate()
        {
            if (testDialogPage != null)
            {
                window.GetDefaultNavigator().Pop();
                testDialogPage.Dispose();
                testDialogPage = null;
            }
        }
    }

    class DialogPageTest2 : IExample
    {
        private Window window;

        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new DialogPageContentPage2(window));
        }

        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
