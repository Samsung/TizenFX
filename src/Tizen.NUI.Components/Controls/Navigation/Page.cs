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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PageAppearingEventArgs is a class to record page appearing event arguments which will be sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PageAppearingEventArgs : EventArgs
    {
    }

    /// <summary>
    /// PageDisappearingEventArgs is a class to record page disappearing event arguments which will be sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PageDisappearingEventArgs : EventArgs
    {
    }

    /// <summary>
    /// The Page class is a class which is an element of navigation.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class Page : Control
    {
        private Navigator navigator = null;

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
        /// An event for the page appearing signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PageAppearingEventArgs> Appearing;

        /// <summary>
        /// An event for the page disappearing signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PageDisappearingEventArgs> Disappearing;

        internal void InvokeAppearing()
        {
            Appearing?.Invoke(this, new PageAppearingEventArgs());
        }

        internal void InvokeDisappearing()
        {
            Disappearing?.Invoke(this, new PageDisappearingEventArgs());
        }
    }
}
