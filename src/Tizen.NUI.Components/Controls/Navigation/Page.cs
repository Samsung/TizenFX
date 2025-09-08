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
using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PageAppearingEventArgs is a class to record <see cref="Page.Appearing"/> event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PageAppearingEventArgs : EventArgs
    {
    }

    /// <summary>
    /// PageDisappearingEventArgs is a class to record <see cref="Page.Disappearing"/> event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PageDisappearingEventArgs : EventArgs
    {
    }

    /// <summary>
    /// PageAppearedEventArgs is a class to record <see cref="Page.Appeared"/> event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PageAppearedEventArgs : EventArgs
    {
    }

    /// <summary>
    /// PageDisappearedEventArgs is a class to record <see cref="Page.Disappeared"/> event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PageDisappearedEventArgs : EventArgs
    {
    }

    /// <summary>
    /// The Page class is a class which is an element of navigation.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class Page : Control
    {
        /// <summary>
        /// AppearingTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AppearingTransitionProperty = null;
        internal static void SetInternalAppearingTransitionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Page)bindable;
                instance.InternalAppearingTransition = newValue as TransitionBase;
            }
        }
        internal static object GetInternalAppearingTransitionProperty(BindableObject bindable)
        {
            var instance = (Page)bindable;
            return instance.InternalAppearingTransition;
        }

        /// <summary>
        /// DisappearingTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisappearingTransitionProperty = null;
        internal static void SetInternalDisappearingTransitionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Page)bindable;
                instance.InternalDisappearingTransition = newValue as TransitionBase;
            }
        }
        internal static object GetInternalDisappearingTransitionProperty(BindableObject bindable)
        {
            var instance = (Page)bindable;
            return instance.InternalDisappearingTransition;
        }

        /// <summary>
        /// EnableBackNavigationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableBackNavigationProperty = null;
        internal static void SetInternalEnableBackNavigationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Page)bindable;
                instance.InternalEnableBackNavigation = (bool)newValue;
            }
        }
        internal static object GetInternalEnableBackNavigationProperty(BindableObject bindable)
        {
            var instance = (Page)bindable;
            return instance.InternalEnableBackNavigation;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal BaseComponents.View LastFocusedView = null;

        private Navigator navigator = null;

        // Default transition is Fade.
        private TransitionBase appearingTransition = null;

        private TransitionBase disappearingTransition = null;

        private bool enableBackNavigation = true;

        static Page()
        {
            if (NUIApplication.IsUsingXaml)
            {
                AppearingTransitionProperty = BindableProperty.Create(nameof(AppearingTransition), typeof(TransitionBase), typeof(Page), null,
                    propertyChanged: SetInternalAppearingTransitionProperty, defaultValueCreator: GetInternalAppearingTransitionProperty);
                DisappearingTransitionProperty = BindableProperty.Create(nameof(DisappearingTransition), typeof(TransitionBase), typeof(Page), null,
                    propertyChanged: SetInternalDisappearingTransitionProperty, defaultValueCreator: GetInternalDisappearingTransitionProperty);
                EnableBackNavigationProperty = BindableProperty.Create(nameof(EnableBackNavigation), typeof(bool), typeof(Page), default(bool),
                    propertyChanged: SetInternalEnableBackNavigationProperty, defaultValueCreator: GetInternalEnableBackNavigationProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a Page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Page() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of Page with style.
        /// </summary>
        /// <param name="style">Creates Page by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a Page with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created Page.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page(ControlStyle style) : base(style)
        {
        }

        /// <summary>
        /// Navigator which has pushed the Page into its stack.
        /// If this Page has not been pushed into any Navigator, then Navigator is null.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Navigator Navigator
        {
            get
            {
                return navigator;
            }
            internal set
            {
                if (navigator == value)
                {
                    return;
                }

                navigator = value;
            }
        }

        /// <summary>
        /// Transition properties for the transition of Views in this page during this page is pushed to Navigator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionBase AppearingTransition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(AppearingTransitionProperty) as TransitionBase;
                }
                else
                {
                    return InternalAppearingTransition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AppearingTransitionProperty, value);
                }
                else
                {
                    InternalAppearingTransition = value;
                }
                NotifyPropertyChanged();
            }
        }
        private TransitionBase InternalAppearingTransition
        {
            set
            {
                appearingTransition = value;
            }
            get
            {
                return appearingTransition;
            }
        }

        /// <summary>
        /// Transition properties for the transition of Views in this page during this page is popped from Navigator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionBase DisappearingTransition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(DisappearingTransitionProperty) as TransitionBase;
                }
                else
                {
                    return InternalDisappearingTransition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DisappearingTransitionProperty, value);
                }
                else
                {
                    InternalDisappearingTransition =  value;
                }
                NotifyPropertyChanged();
            }
        }
        private TransitionBase InternalDisappearingTransition
        {
            set
            {
                disappearingTransition = value;
            }
            get
            {
                return disappearingTransition;
            }
        }

        /// <summary>
        /// Appearing event is invoked right before the page appears.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<PageAppearingEventArgs> Appearing;

        /// <summary>
        /// Disappearing event is invoked right before the page disappears.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<PageDisappearingEventArgs> Disappearing;

        /// <summary>
        /// Appeared event is invoked right after the page appears.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<PageAppearedEventArgs> Appeared;

        /// <summary>
        /// Disappeared event is invoked right after the page disappears.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<PageDisappearedEventArgs> Disappeared;

        /// <summary>
        /// Gets or sets if this page proceeds back navigation when back button or back key is pressed and released.
        /// Back navigation pops the peek page if Navigator has more than one page.
        /// If Navigator has only one page, then the current program is exited.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableBackNavigation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableBackNavigationProperty);
                }
                else
                {
                    return InternalEnableBackNavigation;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableBackNavigationProperty, value);
                }
                else
                {
                    InternalEnableBackNavigation = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalEnableBackNavigation
        {
            set
            {
                enableBackNavigation = value;
            }
            get
            {
                return enableBackNavigation;
            }
        }

        internal void InvokeAppearing()
        {
            Appearing?.Invoke(this, new PageAppearingEventArgs());
        }

        internal void InvokeDisappearing()
        {
            Disappearing?.Invoke(this, new PageDisappearingEventArgs());
        }

        internal void InvokeAppeared()
        {
            Appeared?.Invoke(this, new PageAppearedEventArgs());
        }

        internal void InvokeDisappeared()
        {
            Disappeared?.Invoke(this, new PageDisappearedEventArgs());
        }

        /// <summary>
        /// works only when DefaultAlgorithm is enabled.
        /// to save the currently focused View when disappeared.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual void SaveKeyFocus()
        {
            if (FocusManager.Instance.IsDefaultAlgorithmEnabled())
            {
                if (this is DialogPage)
                {
                    FocusManager.Instance.ResetFocusFinderRootView();
                }

                var currentFocusedView = FocusManager.Instance.GetCurrentFocusView();
                if (currentFocusedView)
                {
                    var findChild = FindDescendantByID(currentFocusedView.ID);
                    if (findChild)
                    {
                        LastFocusedView = findChild;
                        return;
                    }
                }
                LastFocusedView = null;
            }
        }

        /// <summary>
        /// works only when DefaultAlgorithm is enabled.
        /// to set key focused View when showing.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual void RestoreKeyFocus()
        {
            if (FocusManager.Instance.IsDefaultAlgorithmEnabled())
            {
                if (LastFocusedView)
                {
                    FocusManager.Instance.SetCurrentFocusView(LastFocusedView);
                }
                else
                {
                    var temp = new Tizen.NUI.BaseComponents.View()
                    {
                        Size = new Size(0.1f, 0.1f, 0.0f),
                        Position = new Position(0, 0, 0),
                        Focusable = true,
                    };
                    this.Add(temp);
                    temp.LowerToBottom();
                    FocusManager.Instance.SetCurrentFocusView(temp);
                    var focused = FocusManager.Instance.GetNearestFocusableActor(this, temp, Tizen.NUI.BaseComponents.View.FocusDirection.Down);
                    if (focused)
                    {
                        FocusManager.Instance.SetCurrentFocusView(focused);
                    }
                    else
                    {
                        FocusManager.Instance.ClearFocus();
                    }
                    temp.Unparent();
                    temp.Dispose();
                }

                if (this is DialogPage)
                {
                    FocusManager.Instance.SetFocusFinderRootView(this);
                }
            }
        }

        /// <summary>
        /// Called when the back navigation is started.
        /// Back navigation pops the peek page if Navigator has more than one page.
        /// If Navigator has only one page, then the current program is exited.
        /// </summary>
        /// <param name="eventArgs">The back navigation information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnBackNavigation(PageBackNavigationEventArgs eventArgs)
        {
            if (Navigator.PageCount > 1)
            {
                Navigator.Pop();
            }
            else
            {
                NUIApplication.Current?.Exit();
            }
        }

        /// <summary>
        /// Called when the back navigation is required outside Navigator.
        /// </summary>
        internal void NavigateBack()
        {
            OnBackNavigation(new PageBackNavigationEventArgs());
        }
    }

    /// <summary>
    /// PageBackNavigationEventArgs is a class to record back navigation event arguments which will sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PageBackNavigationEventArgs : EventArgs
    {
    }
}
