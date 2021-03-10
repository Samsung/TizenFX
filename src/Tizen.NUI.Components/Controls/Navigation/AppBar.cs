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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The AppBar class is a class which shows title text and provides navigation
    /// and action functions on Page.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AppBar : Control
    {
        private bool autoNavigationContent = true;

        private View defaultNavigationContent = null;
        private View defaultTitleContent = null;
        private View defaultActionContent = null;

        private View appBarNavigation = null;
        private View appBarTitle = null;
        private View appBarAction = null;

        private AppBarStyle appBarStyle => ViewStyle as AppBarStyle;

        private bool styleApplied = false;

        /// <summary>
        /// Creates a new instance of AppBar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of AppBar.
        /// </summary>
        /// <param name="style">Creates AppBar by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of AppBar.
        /// </summary>
        /// <param name="appBarStyle">Creates AppBar by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppBar(AppBarStyle appBarStyle) : base(appBarStyle)
        {
            Initialize();
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
                if (appBarNavigation == defaultNavigationContent)
                {
                    if (appBarNavigation != null)
                    {
                        Utility.Dispose(appBarNavigation);
                    }
                }
                else
                {
                    if (appBarNavigation != null)
                    {
                        Utility.Dispose(appBarNavigation);
                    }

                    if (defaultNavigationContent != null)
                    {
                        Utility.Dispose(defaultNavigationContent);
                    }
                }

                if (appBarTitle == defaultTitleContent)
                {
                    if (appBarTitle != null)
                    {
                        Utility.Dispose(appBarTitle);
                    }
                }
                else
                {
                    if (appBarTitle != null)
                    {
                        Utility.Dispose(appBarTitle);
                    }

                    if (defaultTitleContent != null)
                    {
                        Utility.Dispose(defaultTitleContent);
                    }
                }

                if (appBarAction == defaultActionContent)
                {
                    if (appBarAction != null)
                    {
                        Utility.Dispose(appBarAction);
                    }
                }
                else
                {
                    if (appBarAction != null)
                    {
                        Utility.Dispose(appBarAction);
                    }

                    if (defaultActionContent != null)
                    {
                        Utility.Dispose(defaultActionContent);
                    }
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
        /// If TitleContent is set by user, then SetText does not set title text of the replaced TitleContent.
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
        /// Action content can contain action views and action buttons by AddActions.
        /// If ActionContent is set by user, then AddActions does not add actions to the replaced ActionContent.
        /// The Action and ActionButton styles of AppBarStyle are applied to actions only by AddActions.
        /// If ActionContent is set by user, then RemoveActions does not remove actions from the replaced ActionContent.
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

                if (autoNavigationContent == true)
                {
                    NavigationContent = DefaultNavigationContent;
                }
                else if (NavigationContent == DefaultNavigationContent)
                {
                    NavigationContent = null;
                }
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
                if (defaultNavigationContent == null)
                {
                    defaultNavigationContent = CreateDefaultNavigationContent();
                }

                return defaultNavigationContent;
            }
        }

        /// <summary>
        /// Default title content of AppBar set automatically by default.
        /// If TitleContent is not set by user, then default title content is
        /// automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultTitleContent
        {
            get
            {
                if (defaultTitleContent == null)
                {
                    defaultTitleContent = CreateDefaultTitleContent();
                }

                return defaultTitleContent;
            }
        }

        /// <summary>
        /// Default action content of AppBar set automatically by default.
        /// If ActionContent is not set by user, then default action content is
        /// automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultActionContent
        {
            get
            {
                if (defaultActionContent == null)
                {
                    defaultActionContent = CreateDefaultActionContent();
                }

                return defaultActionContent;
            }
        }

        /// <summary>
        /// Applies style to AppBar.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);

            //Apply Back Button style.
            if ((appBarStyle?.BackButton != null) && (DefaultNavigationContent is Button))
            {
                ((Button)DefaultNavigationContent)?.ApplyStyle(appBarStyle.BackButton);
            }

            //Apply Title style.
            if ((appBarStyle?.TitleTextLabel != null) && (DefaultTitleContent is TextLabel))
            {
                ((TextLabel)DefaultTitleContent)?.ApplyStyle(appBarStyle.TitleTextLabel);
            }

            //Apply ActionCellPadding style.
            if (DefaultActionContent?.Layout is LinearLayout)
            {
                ((LinearLayout)DefaultActionContent?.Layout).CellPadding = new Size2D(appBarStyle?.ActionCellPadding?.Width ?? 0, appBarStyle?.ActionCellPadding?.Height ?? 0);
            }

            //Apply Action and ActionButton styles.
            if (DefaultActionContent?.ChildCount > 0)
            {
                foreach (var action in DefaultActionContent?.Children)
                {
                    if ((action is Button) && (appBarStyle?.ActionButton != null))
                    {
                        ((Button)action)?.ApplyStyle(appBarStyle.ActionButton);
                    }
                    else if (appBarStyle?.ActionView != null)
                    {
                        action?.ApplyStyle(appBarStyle.ActionView);
                    }
                }
            }

            styleApplied = true;

            //Calculate children's positions based on padding sizes.
            CalculatePosition();
        }

        /// <summary>
        /// Sets title text of AppBar.
        /// SetTitle sets title text to the default title content.
        /// Therefore, if TitleContent is set by user, then SetTitle does not set title text of the replaced TitleContent.
        /// </summary>
        /// <param name="title">Title text of AppBar.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTitle(string title)
        {
            if (DefaultTitleContent is TextLabel)
            {
                ((TextLabel)DefaultTitleContent).Text = title;
            }
        }

        /// <summary>
        /// Adds actions to ActionContent of AppBar.
        /// The Action and ActionButton styles of AppBarStyle are applied to the added actions.
        /// AddActions adds action views to the default action content.
        /// Therefore, if ActionContent is set by user, then AddActions does not add actions to the replaced ActionContent.
        /// </summary>
        /// <param name="actions">Actions to be added to ActionContent of AppBar.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument actions is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddActions(params View[] actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions), "actions should not be null.");
            }

            foreach (var action in actions)
            {
                //Apply Action and ActionButton styles.
                if ((action is Button) && (appBarStyle?.ActionButton != null))
                {
                    ((Button)action)?.ApplyStyle(appBarStyle.ActionButton);
                }
                else if (appBarStyle?.ActionView != null)
                {
                    action?.ApplyStyle(appBarStyle.ActionView);
                }

                DefaultActionContent.Add(action);
            }
        }

        /// <summary>
        /// Removes actions from ActionContent of AppBar.
        /// RemoveActions removes action views from the default action content.
        /// Therefore, if ActionContent is set by user, then RemoveActions does not remove actions from the replaced ActionContent.
        /// </summary>
        /// <param name="actions">Actions to be removed from ActionContent of AppBar.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument actions is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveActions(params View[] actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions), "actions should not be null.");
            }

            foreach (var action in actions)
            {
                DefaultActionContent.Remove(action);
            }
        }

        private void Initialize()
        {
            //Navigation, Title and Action are located horizontally.
            var linearLayout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.CenterVertical,
            };

            Layout = linearLayout;

            WidthSpecification = LayoutParamPolicies.MatchParent;

            if (AutoNavigationContent == true)
            {
                NavigationContent = DefaultNavigationContent;
            }

            TitleContent = DefaultTitleContent;

            ActionContent = DefaultActionContent;
        }

        private View CreateDefaultNavigationContent()
        {
            var backButton = new Button(appBarStyle?.BackButton ?? null);

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

        private View CreateDefaultTitleContent()
        {
            return new TextLabel(appBarStyle?.TitleTextLabel ?? null)
            {
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Weight = 1.0f,
            };
        }

        private View CreateDefaultActionContent()
        {
            return new Control()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,

                    //Apply ActionCellPadding style.
                    CellPadding = new Size2D(appBarStyle?.ActionCellPadding?.Width ?? 0, appBarStyle?.ActionCellPadding?.Height ?? 0),
                },
                Weight = 0.0f,
            };
        }

        private void ResetContent()
        {
            //To keep the order of NavigationContent, TitleContent and ActionContent,
            //the existing contents are removed and added again.
            if ((appBarNavigation != null) && Children.Contains(appBarNavigation))
            {
                Remove(appBarNavigation);
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

            if (appBarTitle != null)
            {
                Add(appBarTitle);
            }

            if (appBarAction != null)
            {
                Add(appBarAction);
            }

            //Calculate children's positions based on padding sizes.
            CalculatePosition();
        }

        private void CalculatePosition()
        {
            if (styleApplied == false)
            {
                return;
            }

            //Apply NavigationPadding style.
            if ((NavigationContent != null) && (appBarStyle?.NavigationPadding != null))
            {
                if (NavigationContent.Margin.NotEqualTo(appBarStyle.NavigationPadding))
                {
                    NavigationContent.Margin.CopyFrom(appBarStyle.NavigationPadding);
                }
            }

            //Apply ActionPadding style.
            if ((ActionContent != null) && (appBarStyle?.ActionPadding != null))
            {
                if (ActionContent.Margin.NotEqualTo(appBarStyle.ActionPadding))
                {
                    ActionContent.Margin.CopyFrom(appBarStyle.ActionPadding);
                }
            }
        }

        /// <summary>
        /// Gets AppBar style.
        /// </summary>
        /// <returns>The default AppBar style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new AppBarStyle();
        }
    }
}
