/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the popup orientation types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum PopupOrientation
    {
        /// <summary>
        /// Appears in the top of parent, by default.
        /// </summary>
        Top,
        /// <summary>
        /// Appears in the center of parent.
        /// </summary>
        Center,
        /// <summary>
        /// Appears in the bottom of parent.
        /// </summary>
        Bottom,
        /// <summary>
        /// Appears in the left of parent.
        /// </summary>
        Left,
        /// <summary>
        /// Appears in the right of parent.
        /// </summary>
        Right,
        /// <summary>
        /// Appears in the top left of parent.
        /// </summary>
        TopLeft,
        /// <summary>
        /// Appears in the top right of parent.
        /// </summary>
        TopRight,
        /// <summary>
        /// Appears in the bottom left of parent.
        /// </summary>
        BottomLeft,
        /// <summary>
        /// Appears in the bottom right of parent.
        /// </summary>
        BottomRight
    }

    /// <summary>
    /// The Popup is a widget that is an enhancement of notify.
    /// In addition to content area, there are two optional sections, namely title area and action area.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Popup : Layout
    {
        HashSet<PopupItem> _children = new HashSet<PopupItem>();
        SmartEvent _dismissed;
        SmartEvent _blockClicked;
        SmartEvent _timeout;
        SmartEvent _showFinished;

        /// <summary>
        /// Creates and initializes a new instance of the Popup class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new popup will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Popup(EvasObject parent) : base(parent)
        {
            _dismissed = new SmartEvent(this, "dismissed");
            _dismissed.On += (sender, e) =>
            {
                Dismissed?.Invoke(this, EventArgs.Empty);
            };

            _blockClicked = new SmartEvent(this, "block,clicked");
            _blockClicked.On += (sender, e) =>
            {
                OutsideClicked?.Invoke(this, EventArgs.Empty);
            };

            _timeout = new SmartEvent(this, "timeout");
            _timeout.On += (sender, e) =>
            {
                TimedOut?.Invoke(this, EventArgs.Empty);
            };

            _showFinished = new SmartEvent(this, "show,finished");
            _showFinished.On += (sender, e) =>
            {
                ShowAnimationFinished?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Dismissed will be triggered when the popup has been dismissed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Dismissed;

        /// <summary>
        /// OutsideClicked will be triggered when users taps on the outside of Popup.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler OutsideClicked;

        /// <summary>
        /// OutsideClicked will be triggered when the popup is closed as a result of timeout.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler TimedOut;

        /// <summary>
        /// OutsideClicked will be triggered when the popup transition has finished in showing.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ShowAnimationFinished;

        /// <summary>
        /// Sets or gets the position in which the popup will appear in its parent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public PopupOrientation Orientation
        {
            get
            {
                return (PopupOrientation)Interop.Elementary.elm_popup_orient_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_popup_orient_set(Handle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the wrapping type of content text packed in the content area of Popup widget.
        /// </summary>
        /// <remarks>
        /// Popup need to wrap the content text, so not allowing WrapType.None.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public WrapType ContentTextWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_popup_content_text_wrap_type_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_popup_content_text_wrap_type_set(Handle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the timeout value set to the popup (in seconds).
        /// </summary>
        /// <remarks>
        /// Since calling Show() on a popup restarts the timer controlling when it is hidden,
        /// setting this before the popup is shown, will in effect mean starting the timer when the popup is shown.
        /// TimedOut is called afterwards, which can be handled, if needed.
        /// <![CDATA[Set a value <= 0.0 to disable a running timer. If the value is > 0.0 and the popup is previously visible,]]>
        /// the timer will be started with this value, canceling any running timer.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double Timeout
        {
            get
            {
                return Interop.Elementary.elm_popup_timeout_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_popup_timeout_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether events should be passed to the event blocked area by a click outside.
        /// </summary>
        /// <remarks>
        /// The visible region of the popup is surrounded by a translucent region called the Blocked event area.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool AllowEvents
        {
            get
            {
                return Interop.Elementary.elm_popup_allow_events_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_popup_allow_events_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the AlignmentX in which the popup will appear in its parent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override double AlignmentX
        {
            get
            {
                return Interop.Elementary.GetPopupAlignX(Handle);
            }
            set
            {
                Interop.Elementary.SetPopupAlignX(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the AlignmentY in which the popup will appear in its parent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override double AlignmentY
        {
            get
            {
                return Interop.Elementary.GetPopupAlignY(Handle);
            }
            set
            {
                Interop.Elementary.SetPopupAlignY(Handle, value);
            }
        }

        /// <summary>
        /// Gets the opacity value of the popup.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }

            set
            {
                Console.WriteLine("Popup instance doesn't support to set Opacity.");
            }
        }

        /// <summary>
        /// Adds the label to a Popup widget.
        /// </summary>
        /// <param name="label"></param>
        /// <returns>The new PopupItem which contains a label.</returns>
        /// <since_tizen> preview </since_tizen>
        public PopupItem Append(string label)
        {
            return Append(label, null);
        }

        /// <summary>
        /// Adds the Label and icon to a Popup widget.
        /// </summary>
        /// <param name="label">The Label, which will be added into a new PopupItem.</param>
        /// <param name="icon">The icon, which will be added into a new PopupItem. </param>
        /// <returns>The new PopupItem, which contains the label and icon.</returns>
        /// <since_tizen> preview </since_tizen>
        public PopupItem Append(string label, EvasObject icon)
        {
            PopupItem item = new PopupItem(this, label, icon);
            item.Handle = Interop.Elementary.elm_popup_item_append(Handle, label, icon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Uses this function to dismiss the popup in hide effect.
        /// When the Popup is dismissed, the "dismissed" signal will be emitted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dismiss()
        {
            Interop.Elementary.elm_popup_dismiss(Handle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_popup_add(parent.Handle);
        }
        void AddInternal(PopupItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }
        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((PopupItem)sender);
        }
    }
}
