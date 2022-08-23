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
    class SecondPage : ContentPage
    {
        public SecondPage(Window window) : base()
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            var appBar = new AppBar()
            {
                Title = "Second Page",
            };

            AppBar = appBar;

            var button = new Button()
            {
                Text = "Click to Third Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            button.Clicked += (o, e) =>
            {
                window.GetDefaultNavigator().Push(new ThirdPage(window));
            };

            Content = button;
        }
    }

    class SecondPageWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            var secondPage = new SecondPage(window);

            var appBar = new AppBar()
            {
                Title = secondPage.AppBar.Title,
                AutoNavigationContent = false,
            };

            // Since this is Widget, bundle with "POP" message should be sent to make the main app pops this.
            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");

            var navigationContent = new Button(((AppBarStyle)appBarStyle).BackButton);
            navigationContent.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the current page.
                Bundle nextBundle = new Bundle();
                nextBundle.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle = nextBundle.Encode();
                SetContentInfo(encodedBundle);
            };

            appBar.AutoNavigationContent = false;
            appBar.NavigationContent = navigationContent;

            secondPage.AppBar = appBar;

            window.GetDefaultNavigator().Push(secondPage);
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

    class ThirdPage : ContentPage
    {
        public ThirdPage(Window window) : base()
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            var appBar = new AppBar()
            {
                Title = "Third Page",
            };
            AppBar = appBar;

            var button = new Button()
            {
                Text = "Click to Fourth Page",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            button.Clicked += (o, e) =>
            {
                window.GetDefaultNavigator().Push(new FourthPage(window));
            };

            Content = button;
        }
    }

    class ThirdPageWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            var thirdPage = new ThirdPage(window);

            var appBar = new AppBar()
            {
                Title = thirdPage.AppBar.Title,
                AutoNavigationContent = false,
            };

            // Since this is Widget, bundle with "POP" message should be sent to make the main app pops this.
            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");

            var navigationContent = new Button(((AppBarStyle)appBarStyle).BackButton);
            navigationContent.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the current page.
                Bundle nextBundle = new Bundle();
                nextBundle.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle = nextBundle.Encode();
                SetContentInfo(encodedBundle);
            };

            appBar.AutoNavigationContent = false;
            appBar.NavigationContent = navigationContent;

            thirdPage.AppBar = appBar;

            window.GetDefaultNavigator().Push(thirdPage);
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

    class FourthPage : DialogPage
    {
        public FourthPage(Window window) : base()
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            var button = new Button()
            {
                Text = "OK",
            };
            button.Clicked += (o, e) =>
            {
                window.GetDefaultNavigator().Pop();
            };

            var dialog = new AlertDialog()
            {
                Title = "Fourth Page",
                Message = "Message",
                Actions = new View[] { button },
            };

            Content = dialog;
        }
    }

    class WidgetDialogPage : DialogPage
    {
        public WidgetDialogPage(Window window) : base()
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            // Default Scrim calls navigator.Pop() when the Scrim is touched.
            // To pop widget page when the Scrim is touched, bundle with "POP" message should be sent to make the main app pops this.
            Scrim = CreateScrim(window);
        }

        public EventHandler<TouchEventArgs> ScrimTouchEvent;

        private View CreateScrim(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            var scrimStyle = ThemeManager.GetStyle("Tizen.NUI.Components.DialogPage.Scrim");
            var scrim = new VisualView(scrimStyle);
            scrim.Size = window.Size;
            scrim.TouchEvent += (object source, TouchEventArgs e) =>
            {
                if ((EnableDismissOnScrim == true) && (e.Touch.GetState(0) == PointStateType.Up))
                {
                    // Default Scrim calls navigator.Pop() when the Scrim is touched.
                    // To pop widget page when the Scrim is touched, bundle with "POP" message should be sent to make the main app pops this.
                    ScrimTouchEvent?.Invoke(source, e);
                }
                return true;
            };

            return scrim;
        }
    }

    class FourthPageWidget : Widget
    {
        protected override void OnCreate(string contentInfo, Window window)
        {
            Bundle bundle = Bundle.Decode(contentInfo);

            window.BackgroundColor = Color.Transparent;

            var fourthPage = new WidgetDialogPage(window);

            var button = new Button()
            {
                Text = "OK",
            };
            button.Clicked += (o, e) =>
            {
                // Update Widget Content by sending message to pop the current page.
                Bundle nextBundle = new Bundle();
                nextBundle.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle = nextBundle.Encode();
                SetContentInfo(encodedBundle);
            };

            var dialog = new AlertDialog()
            {
                Title = "Fourth Page",
                Message = "Message",
                Actions = new View[] { button },
            };

            fourthPage.Content = dialog;

            // Default Scrim calls navigator.Pop() when the Scrim is touched.
            // To pop widget page when the Scrim is touched, bundle with "POP" message should be sent to make the main app pops this.
            fourthPage.ScrimTouchEvent += (o, e) =>
            {
                // Update Widget Content by sending message to pop the current page.
                Bundle nextBundle = new Bundle();
                nextBundle.AddItem("WIDGET_ACTION", "POP");
                String encodedBundle = nextBundle.Encode();
                SetContentInfo(encodedBundle);
            };

            window.GetDefaultNavigator().Push(fourthPage);
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
            widgetSet.Add(typeof(SecondPageWidget), "secondPage@NUISettingsReset");
            widgetSet.Add(typeof(ThirdPageWidget), "thirdPage@NUISettingsReset");
            widgetSet.Add(typeof(FourthPageWidget), "fourthPage@NUISettingsReset");
            var app = new Program(widgetSet);
            app.Run(args);
        }
    }
}