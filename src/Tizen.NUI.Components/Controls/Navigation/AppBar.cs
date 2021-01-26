/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Windows.Input;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The AppBar class is a class which shows title text and provides navigation
    /// and action functions on Page.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AppBar : Control
    {
        //TODO: This app bar height should be implemented in AppBar style.
        private float appBarHeight = 72.0f;

        private bool autoNavigationContent = true;
        private View defaultNavigationContent = null;

        private View appBarNavigation = null;
        private View appBarTitle = null;
        private View appBarAction = null;

        /// <summary>
        /// Creates a new instance of a AppBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar() : base()
        {
            defaultNavigationContent = CreateDefaultNavigationContent();

            //Navigation, Title and Action are located horizontally.
            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            Layout = linearLayout;

            WidthSpecification = LayoutParamPolicies.MatchParent;

            //TODO: This app bar height should be implemented in AppBar style.
            SizeHeight = appBarHeight;

            if ((AutoNavigationContent == true) && (DefaultNavigationContent != null))
            {
                Add(DefaultNavigationContent);
            }
        }

        /// <summary>
        /// Creates a new instance of a AppBar.
        /// </summary>
        /// <param name="navigationContent">The content to set to NavigationContent of AppBar.</param>
        /// <param name="titleContent">The content to set to TitleContent of AppBar.</param>
        /// <param name="actionContent">The content to set to ActionContent of AppBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar(View navigationContent, View titleContent, View actionContent) : base()
        {
            defaultNavigationContent = CreateDefaultNavigationContent();

            //Navigation, Title and Action are located horizontally.
            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            Layout = linearLayout;

            WidthSpecification = LayoutParamPolicies.MatchParent;

            //TODO: This app bar height should be implemented in AppBar style.
            SizeHeight = appBarHeight;

            if (navigationContent != null)
            {
                NavigationContent = navigationContent;
            }
            else if ((AutoNavigationContent == true) && (DefaultNavigationContent != null))
            {
                Add(DefaultNavigationContent);
            }

            if (titleContent != null)
            {
                TitleContent = titleContent;
            }

            if (actionContent != null)
            {
                ActionContent = actionContent;
            }
        }

        /// <summary>
        /// Creates a new instance of a AppBar.
        /// </summary>
        /// <param name="title">The text string to set to TitleContent of AppBar.</param>
        /// <param name="actionContents">The contents to add to ActionContent of AppBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar(string title, params View[] actionContents) : this(null, title, actionContents)
        {
        }

        /// <summary>
        /// Creates a new instance of a AppBar.
        /// </summary>
        /// <param name="navigationContent">The content to set to NavigationContent of AppBar.</param>
        /// <param name="title">The text string to set to TitleContent of AppBar.</param>
        /// <param name="actionContents">The contents to add to ActionContent of AppBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar(View navigationContent, string title, params View[] actionContents) : base()
        {
            defaultNavigationContent = CreateDefaultNavigationContent();

            //Navigation, Title and Action are located horizontally.
            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            Layout = linearLayout;

            WidthSpecification = LayoutParamPolicies.MatchParent;

            //TODO: This app bar height should be implemented in AppBar style.
            SizeHeight = appBarHeight;

            if (navigationContent != null)
            {
                navigationContent.HeightSpecification = LayoutParamPolicies.MatchParent;
                navigationContent.Weight = 0.0f;

                NavigationContent = navigationContent;
            }
            else if ((AutoNavigationContent == true) && (DefaultNavigationContent != null))
            {
                Add(DefaultNavigationContent);
            }

            if (title != null)
            {
                var titleContent = new TextLabel()
                {
                    Text = title,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    VerticalAlignment = VerticalAlignment.Center,
                    Weight = 1.0f,
                    BackgroundColor = new Color(0.88f, 0.88f, 0.88f, 1.0f)
                };

                TitleContent = titleContent;
            }

            if (actionContents != null)
            {
                var actionContent = new Control()
                {
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Horizontal
                    },
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    Weight = 0.0f
                };

                foreach (var actionView in actionContents)
                {
                    actionView.HeightSpecification = LayoutParamPolicies.MatchParent;

                    actionContent.Add(actionView);
                }

                ActionContent = actionContent;
            }
        }

        /// <summary>
        /// Disposes AppBar and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (appBarNavigation != null)
                {
                    Utility.Dispose(appBarNavigation);
                }

                if (appBarTitle != null)
                {
                    Utility.Dispose(appBarTitle);
                }

                if (appBarAction != null)
                {
                    Utility.Dispose(appBarAction);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Navigation content of AppBar. NavigationContent is added to Children automatically.
        /// If AutoNavigationContent is set to be true and NavigationContent is not set,
        /// then default navigation content is automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View NavigationContent
        {
            get
            {
                return appBarNavigation;
            }
            set
            {
                if (appBarNavigation == value)
                {
                    return;
                }

                if (appBarNavigation != null)
                {
                    Remove(appBarNavigation);
                }

                appBarNavigation = value;
                if (appBarNavigation == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// Title content of AppBar. TitleContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View TitleContent
        {
            get
            {
                return appBarTitle;
            }
            set
            {
                if (appBarTitle == value)
                {
                    return;
                }

                if (appBarTitle != null)
                {
                    Remove(appBarTitle);
                }

                appBarTitle = value;
                if (appBarTitle == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// Action content of AppBar. ActionContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ActionContent
        {
            get
            {
                return appBarAction;
            }
            set
            {
                if (appBarAction == value)
                {
                    return;
                }

                if (appBarAction != null)
                {
                    Remove(appBarAction);
                }

                appBarAction = value;
                if (appBarAction == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// Flag to indicate if default navigation content is automatically set or not.
        /// The default value is true.
        /// If AutoNavigationContent is set to be true and NavigationContent is not set,
        /// then default navigation content is automatically displayed.
        /// If default navigation content is clicked, it calls navigator pop operation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutoNavigationContent
        {
            get
            {
                return autoNavigationContent;
            }

            set
            {
                if (autoNavigationContent == value)
                {
                    return;
                }

                autoNavigationContent = value;

                ResetContent();
            }
        }

        /// <summary>
        /// Default navigation content of AppBar set automatically by default.
        /// If AutoNavigationContent is set to be true and NavigationContent is not set,
        /// then default navigation content is automatically displayed.
        /// If default navigation content is clicked, it calls navigator pop operation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultNavigationContent
        {
            get
            {
                //TODO: Do not set default navigation content if there is no previous page.
                return defaultNavigationContent;
            }
        }

        private View CreateDefaultNavigationContent()
        {
            var backButton = new Button()
            {
                //FIXME: When back icon resource is added, replace this text to the icon resource.
                Text = "<",
                //TODO: This app bar height should be implemented in Appbar style.
                Size = new Size(72.0f, 72.0f),
            };

            backButton.Clicked += (object sender, ClickedEventArgs args) =>
            {
                //The page of app bar is popped when default back button is clicked.
                var page = GetParent() as Page;
                if (page != null)
                {
                    var navigator = page.GetParent() as Navigator;
                    if (navigator != null)
                    {
                        navigator.Pop();
                    }
                }
            };

            return backButton;
        }

        private void ResetContent()
        {
            //To keep the order of NavigationContent, TitleContent and ActionContent,
            //the existing contents are removed and added again.
            if ((appBarNavigation != null) && Children.Contains(appBarNavigation))
            {
                Remove(appBarNavigation);
            }
            else if ((DefaultNavigationContent != null) && Children.Contains(DefaultNavigationContent))
            {
                Remove(DefaultNavigationContent);
            }

            if ((appBarTitle != null) && Children.Contains(appBarTitle))
            {
                Remove(appBarTitle);
            }

            if ((appBarAction != null) && Children.Contains(appBarAction))
            {
                Remove(appBarAction);
            }

            if (appBarNavigation != null)
            {
                Add(appBarNavigation);
            }
            else if ((AutoNavigationContent == true) && (DefaultNavigationContent != null))
            {
                Add(DefaultNavigationContent);
            }

            if (appBarTitle != null)
            {
                Add(appBarTitle);
            }

            if (appBarAction != null)
            {
                Add(appBarAction);
            }
        }
    }
}
