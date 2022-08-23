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
using System.Collections.Generic; // for Dictionary
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.Applications;

namespace WidgetTemplate
{
    class SecondPage : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            // Update Widget Content by sending message to add the third page in advance.
            Bundle nextBundle = new Bundle();
            nextBundle.AddItem("WIDGET_ID", "thirdPage@NUISettingsReset");
            nextBundle.AddItem("WIDGET_ACTION", "ADD");
            nextBundle.AddItem("WIDGET_WIDTH", window.Size.Width.ToString());
            nextBundle.AddItem("WIDGET_HEIGHT", window.Size.Height.ToString());
            String encodedBundle = nextBundle.Encode();
            SetContentInfo(encodedBundle);

            var appBar = new AppBar()
            {
                Title = "Second Page",
                AutoNavigationContent = false,
            };

            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");

            var navigationContent = new Button(((AppBarStyle)appBarStyle).BackButton);
            navigationContent.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the second page.
                Bundle nextBundle2 = new Bundle();
                nextBundle2.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle2 = nextBundle2.Encode();
                SetContentInfo(encodedBundle2);
            };

            appBar.NavigationContent = navigationContent;

            var page = new ContentPage()
            {
                AppBar = appBar,
            };

            var button = new Button()
            {
                Text = "Click to Third Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            button.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to push the third page.
                Bundle nextBundle2 = new Bundle();
                nextBundle2.AddItem("WIDGET_ID", "thirdPage@NUISettingsReset");
                nextBundle2.AddItem("WIDGET_PAGE", "CONTENT_PAGE");
                nextBundle2.AddItem("WIDGET_ACTION", "PUSH");
                String encodedBundle2 = nextBundle2.Encode();
                SetContentInfo(encodedBundle2);
            };

            page.Content = button;
            window.Add(page);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResize(Window window)
        {
            base.OnResize(window);
        }

        protected override void OnTerminate(string contentInfo, TerminationType type)
        {
            base.OnTerminate(contentInfo, type);
        }

        protected override void OnUpdate(string contentInfo, int force)
        {
            base.OnUpdate(contentInfo, force);
        }
    }

    class ThirdPage : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            // Update Widget Content by sending message to add the fourth page in advance.
            Bundle nextBundle = new Bundle();
            nextBundle.AddItem("WIDGET_ID", "fourthPage@NUISettingsReset");
            nextBundle.AddItem("WIDGET_WIDTH", window.Size.Width.ToString());
            nextBundle.AddItem("WIDGET_HEIGHT", window.Size.Height.ToString());
            nextBundle.AddItem("WIDGET_ACTION", "ADD");
            String encodedBundle = nextBundle.Encode();
            SetContentInfo(encodedBundle);

            var appBar = new AppBar()
            {
                Title = "Third Page",
                AutoNavigationContent = false,
            };

            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");

            var navigationContent = new Button(((AppBarStyle)appBarStyle).BackButton);
            navigationContent.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the third page.
                Bundle nextBundle2 = new Bundle();
                nextBundle2.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle2 = nextBundle2.Encode();
                SetContentInfo(encodedBundle2);
            };

            appBar.NavigationContent = navigationContent;

            var page = new ContentPage()
            {
                AppBar = appBar,
            };

            var button = new Button()
            {
                Text = "Click to Fourth Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            button.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to push the fourth page.
                Bundle nextBundle2 = new Bundle();
                nextBundle2.AddItem("WIDGET_ID", "fourthPage@NUISettingsReset");
                nextBundle2.AddItem("WIDGET_PAGE", "DIALOG_PAGE");
                nextBundle2.AddItem("WIDGET_ACTION", "PUSH");
                String encodedBundle2 = nextBundle2.Encode();
                SetContentInfo(encodedBundle2);
            };

            page.Content = button;
            window.Add(page);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResize(Window window)
        {
            base.OnResize(window);
        }

        protected override void OnTerminate(string contentInfo, TerminationType type)
        {
            base.OnTerminate(contentInfo, type);
        }

        protected override void OnUpdate(string contentInfo, int force)
        {
            base.OnUpdate(contentInfo, force);
        }
    }

    class FourthPage : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            var button = new Button()
            {
                Text = "OK",
            };
            button.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the fourth page.
                Bundle nextBundle2 = new Bundle();
                nextBundle2.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle2 = nextBundle2.Encode();
                SetContentInfo(encodedBundle2);
            };

            var dialog = new AlertDialog()
            {
                Title = "Fourth Page",
                Message = "Message",
                Actions = new View[] { button },
            };

            window.Add(dialog);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResize(Window window)
        {
            base.OnResize(window);
        }

        protected override void OnTerminate(string contentInfo, TerminationType type)
        {
            base.OnTerminate(contentInfo, type);
        }

        protected override void OnUpdate(string contentInfo, int force)
        {
            base.OnUpdate(contentInfo, force);
        }
    }

    class Program : NUIWidgetApplication
    {
        public Program(Dictionary<System.Type, string> widgetSet) : base(widgetSet)
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            Dictionary<System.Type, string> widgetSet = new Dictionary<Type, string>();
            widgetSet.Add(typeof(SecondPage), "secondPage@NUISettingsReset");
            widgetSet.Add(typeof(ThirdPage), "thirdPage@NUISettingsReset");
            widgetSet.Add(typeof(FourthPage), "fourthPage@NUISettingsReset");
            var app = new Program(widgetSet);
            app.Run(args);
        }
    }
}