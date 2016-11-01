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
    public enum PopupOrientation
    {
        Top,
        Center,
        Bottom,
        Left,
        Right,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public class Popup : Layout
    {
        HashSet<PopupItem> _children = new HashSet<PopupItem>();
        Interop.SmartEvent _dismissed;
        Interop.SmartEvent _blockClicked;
        Interop.SmartEvent _timeout;
        Interop.SmartEvent _showFinished;

        public Popup(EvasObject parent) : base(parent)
        {
            _dismissed = new Interop.SmartEvent(this, Handle, "dismissed");
            _dismissed.On += (sender, e) =>
            {
                Dismissed?.Invoke(this, EventArgs.Empty);
            };

            _blockClicked = new Interop.SmartEvent(this, Handle, "block,clicked");
            _blockClicked.On += (sender, e) =>
            {
                OutsideClicked?.Invoke(this, EventArgs.Empty);
            };

            _timeout = new Interop.SmartEvent(this, Handle, "timeout");
            _timeout.On += (sender, e) =>
            {
                TimedOut?.Invoke(this, EventArgs.Empty);
            };

            _showFinished = new Interop.SmartEvent(this, Handle, "show,finished");
            _showFinished.On += (sender, e) =>
            {
                ShowAnimationFinished?.Invoke(this, EventArgs.Empty);
            };

        }

        public event EventHandler Dismissed;

        public event EventHandler OutsideClicked;

        public event EventHandler TimedOut;

        public event EventHandler ShowAnimationFinished;

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

        public PopupItem Append(string label)
        {
            return Append(label, null);
        }

        public PopupItem Append(string label, EvasObject icon)
        {
            PopupItem item = new PopupItem(label, icon);
            item.Handle = Interop.Elementary.elm_popup_item_append(Handle, label, icon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        public void Dismiss()
        {
            Interop.Elementary.elm_popup_dismiss(Handle);
        }

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
