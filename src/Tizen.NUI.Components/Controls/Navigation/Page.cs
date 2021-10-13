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
        public static readonly BindableProperty AppearingTransitionProperty = BindableProperty.Create(nameof(AppearingTransition), typeof(TransitionBase), typeof(Page), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Page)bindable;
            if (newValue != null)
            {
                instance.InternalAppearingTransition = newValue as TransitionBase;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Page)bindable;
            return instance.InternalAppearingTransition;
        });

        /// <summary>
        /// DisappearingTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisappearingTransitionProperty = BindableProperty.Create(nameof(DisappearingTransition), typeof(TransitionBase), typeof(Page), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Page)bindable;
            if (newValue != null)
            {
                instance.InternalDisappearingTransition = newValue as TransitionBase;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Page)bindable;
            return instance.InternalDisappearingTransition;
        });

        private Navigator navigator = null;

        // Default transition is Fade.
        private TransitionBase appearingTransition = null;

        private TransitionBase disappearingTransition = null;

        /// <summary>
        /// Creates a new instance of a Page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Page() : base()
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
                return GetValue(AppearingTransitionProperty) as TransitionBase;
            }
            set
            {
                SetValue(AppearingTransitionProperty, value);
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
                return GetValue(DisappearingTransitionProperty) as TransitionBase;
            }
            set
            {
                SetValue(DisappearingTransitionProperty, value);
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
    }
}
