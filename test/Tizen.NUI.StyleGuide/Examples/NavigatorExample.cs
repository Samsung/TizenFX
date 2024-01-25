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
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class NavigatorExample : ContentPage, IExample
    {
        private const int numberOfDifferentColor = 4;
        private const int colorOne = 0, colorTwo = 1, colorThree = 2;
        private Navigator navigator;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public NavigatorExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Navigator Default Style",
            };

            navigator = NUIApplication.GetDefaultWindow().GetDefaultNavigator();
            Content = generateContent(this);
        }

        protected override void OnBackNavigation(PageBackNavigationEventArgs eventArgs)
        {
            var noButton = new Button()
            {
                Text = "No"
            };
            noButton.Clicked += (o, e) =>
            {
                // Pops the dialog page.
                Navigator.Pop();
            };

            var yesButton = new Button()
            {
                Text = "Yes"
            };
            yesButton.Clicked += (o, e) =>
            {
                // Removes the dialog page.
                Navigator.RemoveAt(Navigator.PageCount - 1);

                // Pops the content page.
                Navigator.Pop();
            };

            DialogPage.ShowAlertDialog("", "Do you really want to pop?", new View[] { noButton, yesButton });
        }

        private ContentPage generatePage()
        {
            var page = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "NavigatorTestPage" + navigator.PageCount.ToString()
                }
            };
            page.Content = generateContent(page);

            return page;
        }

        private void updateBackNavigationButtonText(Button button, Navigator navigator)
        {
            if (navigator == null)
            {
                return;
            }

            if (navigator.EnableBackNavigation)
            {
                button.Text = "Navigator BackNavigation is enabled";
            }
            else
            {
                button.Text = "Navigator BackNavigation is disabled";
            }
        }

        private void updatePageBackNavigationButtonText(Button button, Page page)
        {
            if (page == null)
            {
                return;
            }

            if (page.EnableBackNavigation)
            {
                button.Text = "Page BackNavigation is enabled";
            }
            else
            {
                button.Text = "Page BackNavigation is disabled";
            }
        }

        private View generateContent(Page page)
        {
            if (page == null)
            {
                Tizen.Log.Error("NUITEST", "The page should not be null");
                return null;
            }

            var contentView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 10),
                },
            };

            var buttonPush = new Button()
            {
                Text = "Push",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonPush.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }
                var newPage = generatePage();
                navigator.Push(newPage);
            };
            contentView.Add(buttonPush);

            var buttonPop = new Button()
            {
                Text = "Pop",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonPop.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }
                navigator.Pop();
            };
            contentView.Add(buttonPop);

            var buttonBackNavigation = new Button()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            updateBackNavigationButtonText(buttonBackNavigation, navigator);

            buttonBackNavigation.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }

                navigator.EnableBackNavigation = !navigator.EnableBackNavigation;
                updateBackNavigationButtonText(buttonBackNavigation, navigator);
            };
            contentView.Add(buttonBackNavigation);

            var buttonPageBackNavigation = new Button()
            {
                Text = "Page BackNavigation is enabled",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            buttonPageBackNavigation.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }

                page.EnableBackNavigation = !page.EnableBackNavigation;
                updatePageBackNavigationButtonText(buttonPageBackNavigation, page);
            };
            contentView.Add(buttonPageBackNavigation);

            // Update back navigation button's text when the page is appearing.
            page.Appearing += (o, e) =>
            {
                updateBackNavigationButtonText(buttonBackNavigation, navigator);
                updatePageBackNavigationButtonText(buttonPageBackNavigation, page);
            };

            Color backgroundColor;
            switch (navigator.PageCount % numberOfDifferentColor)
            {
                case colorOne:
                    backgroundColor = Color.DarkGreen;
                    break;
                case colorTwo:
                    backgroundColor = Color.DarkRed;
                    break;
                case colorThree:
                    backgroundColor = Color.DarkBlue;
                    break;
                default:
                    backgroundColor = Color.SaddleBrown;
                    break;
            };
            buttonPush.BackgroundColor = backgroundColor;
            buttonPop.BackgroundColor = backgroundColor;
            buttonBackNavigation.BackgroundColor = backgroundColor;
            buttonPageBackNavigation.BackgroundColor = backgroundColor;
            return contentView;
        }
    }
}
