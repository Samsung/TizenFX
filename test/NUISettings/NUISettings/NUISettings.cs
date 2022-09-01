/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.Applications;

namespace WidgetApplicationTemplate
{
    class Program : NUIApplication
    {
        string widgetAppId = "NUISettingsReset";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        void Initialize()
        {
            Window window = GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;
            window.TouchEvent += OnTouchEvent;

            int widgetWidth = window.Size.Width;
            int widgetHeight = window.Size.Height;

            Navigator navigator = window.GetDefaultNavigator();

            Bundle bundle = new Bundle();
            bundle.AddItem(" ", " ");
            String encodedBundle = bundle.Encode();

            // Add Widget of "secondPage@NUISettingsReset" in advance to avoid loading pending.
            AddWidget(out secondPageWidgetView, "secondPage@NUISettingsReset", encodedBundle, widgetWidth, widgetHeight, 0.0f);

            // Add Widget of "thirdPage@NUISettingsReset" in advance to avoid loading pending.
            AddWidget(out thirdPageWidgetView, "thirdPage@NUISettingsReset", encodedBundle, widgetWidth, widgetHeight, 0.0f);

            // Add Widget of "fourthPage@NUISettingsReset" in advance to avoid loading pending.
            AddWidget(out fourthPageWidgetView, "fourthPage@NUISettingsReset", encodedBundle, widgetWidth, widgetHeight, 0.0f);

            var content = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var secondPageButton = new Button()
            {
                Text = "Click to Second Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            secondPageButton.Clicked += (o, e) =>
            {
                var page = new ContentPage()
                {
                    Content = secondPageWidgetView,
                };
                navigator.Push(page);
            };
            content.Add(secondPageButton);

            var thirdPageButton = new Button()
            {
                Text = "Click to Third Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            thirdPageButton.Clicked += (o, e) =>
            {
                var page = new ContentPage()
                {
                    Content = thirdPageWidgetView,
                };
                navigator.Push(page);
            };
            content.Add(thirdPageButton);

            var fourthPageButton = new Button()
            {
                Text = "Click to Fourth Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            fourthPageButton.Clicked += (o, e) =>
            {
                var page = new DialogPage()
                {
                    Content = fourthPageWidgetView,
                    EnableScrim = false, // fourthPageWidgetView's DialogPage.Scrim is used, so this DialogPage.Scrim should not be used.
                };
                navigator.Push(page);
            };
            content.Add(fourthPageButton);

            // Push the first page.
            PushContentPage("First Page", content);
        }

        void AddWidget(out WidgetView widgetView, string widgetID, string contentInfo, int width, int height, float updatePeriod)
        {
            widgetView = WidgetViewManager.Instance.AddWidget(widgetID, contentInfo, width, height, updatePeriod);
            widgetView.WidgetContentUpdated += OnWidgetContentUpdatedCB;
        }

        void PushContentPage(string title, View content)
        {
            Window window = GetDefaultWindow();
            Navigator navigator = window.GetDefaultNavigator();

            var page = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = title,
                },
            };

            page.Content = content;
            navigator.Push(page);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
        }

        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
        }

        private void OnWidgetContentUpdatedCB(object sender, WidgetView.WidgetViewEventArgs e)
        {
            String encodedBundle = e.WidgetView.ContentInfo;
            Bundle bundle = Bundle.Decode(encodedBundle);

            string widgetID;
            if (bundle.TryGetItem("WIDGET_ID", out widgetID))
            {
            }

            string widgetWidth;
            if (bundle.TryGetItem("WIDGET_WIDTH", out widgetWidth))
            {
            }

            string widgetHeight;
            if (bundle.TryGetItem("WIDGET_HEIGHT", out widgetHeight))
            {
            }

            string widgetPage;
            if (bundle.TryGetItem("WIDGET_PAGE", out widgetPage))
            {
            }

            string widgetAction;
            if (bundle.TryGetItem("WIDGET_ACTION", out widgetAction))
            {
                if (widgetAction.Equals("ADD"))
                {
                    if (Int32.TryParse(widgetWidth, out int width) && Int32.TryParse(widgetHeight, out int height))
                    {
                        Bundle bundle2 = new Bundle();
                        bundle2.AddItem(" ", " ");
                        String encodedBundle2 = bundle2.Encode();

                        if (widgetID.Equals("secondPage@NUISettingsReset"))
                        {
                            secondPageWidgetView = WidgetViewManager.Instance.AddWidget(widgetID, encodedBundle2, width, height, 0.0f);
                            secondPageWidgetView.WidgetContentUpdated += OnWidgetContentUpdatedCB;
                        }
                        else if (widgetID.Equals("thirdPage@NUISettingsReset"))
                        {
                            thirdPageWidgetView = WidgetViewManager.Instance.AddWidget(widgetID, encodedBundle2, width, height, 0.0f);
                            thirdPageWidgetView.WidgetContentUpdated += OnWidgetContentUpdatedCB;
                        }
                        else if (widgetID.Equals("fourthPage@NUISettingsReset"))
                        {
                            fourthPageWidgetView = WidgetViewManager.Instance.AddWidget(widgetID, encodedBundle2, width, height, 0.0f);
                            fourthPageWidgetView.WidgetContentUpdated += OnWidgetContentUpdatedCB;
                        }
                    }
                }
                else if (widgetAction.Equals("PUSH"))
                {
                    if (widgetPage.Equals("CONTENT_PAGE"))
                    {
                        if (widgetID.Equals("secondPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new ContentPage() { Content = secondPageWidgetView });
                        }
                        else if (widgetID.Equals("thirdPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new ContentPage() { Content = thirdPageWidgetView });
                        }
                        else if (widgetID.Equals("fourthPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new ContentPage() { Content = fourthPageWidgetView });
                        }
                    }
                    else if (widgetPage.Equals("DIALOG_PAGE"))
                    {
                        if (widgetID.Equals("secondPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new DialogPage() { Content = secondPageWidgetView });
                        }
                        else if (widgetID.Equals("thirdPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new DialogPage() { Content = thirdPageWidgetView });
                        }
                        else if (widgetID.Equals("fourthPage@NUISettingsReset"))
                        {
                            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(new DialogPage() { Content = fourthPageWidgetView });
                        }
                    }
                }
                else if (widgetAction.Equals("POP"))
                {
                    NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
                }
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        WidgetView secondPageWidgetView;
        WidgetView thirdPageWidgetView;
        WidgetView fourthPageWidgetView;
    }
}