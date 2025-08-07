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
    public class DialogPageContentPage : ContentPage
    {
        private Window window = null;
        private int oldPageCount = 0;

        public DialogPageContentPage(Window win)
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            AppBar = new AppBar()
            {
                Title = "Dialog page Sample",
            };

            window = win;
            oldPageCount = window.GetDefaultNavigator().PageCount;

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
                var textLabel = new TextLabel("Message")
                {
                    BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                    Size = new Size(180, 180),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                DialogPage.ShowDialog(textLabel);
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
            var newPageCount = window.GetDefaultNavigator().PageCount;

            for (int i = 0; i < (newPageCount - oldPageCount); i++)
            {
                window.GetDefaultNavigator().Pop();
            }
        }
    }

    class DialogPageTest : IExample
    {
        private Window window;

        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new DialogPageContentPage(window));
        }

        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
