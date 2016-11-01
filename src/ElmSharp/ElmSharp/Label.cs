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

namespace ElmSharp
{
    public class Label : Layout
    {
        Interop.SmartEvent _slideCompleted;

        public Label(EvasObject parent) : base(parent)
        {
            _slideCompleted = new Interop.SmartEvent(this, Handle, "slide,end");
            _slideCompleted.On += (s, e) =>
            {
                SlideCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler SlideCompleted;

        public int LineWrapWidth
        {
            get
            {
                return Interop.Elementary.elm_label_wrap_width_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_wrap_width_set(Handle, value);
            }
        }

        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_label_line_wrap_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_line_wrap_set(Handle, (int)value);
            }
        }

        public LabelSlideMode SlideMode
        {
            get
            {
                return (LabelSlideMode)Interop.Elementary.elm_label_slide_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_mode_set(Handle, (int)value);
            }
        }

        public double SlideDuration
        {
            get
            {
                return Interop.Elementary.elm_label_slide_duration_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_duration_set(Handle, value);
            }
        }

        public bool IsEllipsis
        {
            get
            {
                return Interop.Elementary.elm_label_ellipsis_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_ellipsis_set(Handle, value);
            }
        }

        public void PlaySlide()
        {
            Interop.Elementary.elm_label_slide_go(Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_label_add(parent.Handle);
        }
    }

    public enum LabelSlideMode
    {
        None = 0,
        Auto,
        Always
    }
}
