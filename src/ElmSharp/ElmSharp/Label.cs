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
        SmartEvent _slideCompleted;

        public Label(EvasObject parent) : base(parent)
        {
            _slideCompleted = new SmartEvent(this, this.RealHandle, "slide,end");
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
                return Interop.Elementary.elm_label_wrap_width_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_wrap_width_set(RealHandle, value);
            }
        }

        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_label_line_wrap_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_line_wrap_set(RealHandle, (int)value);
            }
        }

        public LabelSlideMode SlideMode
        {
            get
            {
                return (LabelSlideMode)Interop.Elementary.elm_label_slide_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_mode_set(RealHandle, (int)value);
            }
        }

        public double SlideDuration
        {
            get
            {
                return Interop.Elementary.elm_label_slide_duration_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_duration_set(RealHandle, value);
            }
        }

        public bool IsEllipsis
        {
            get
            {
                return Interop.Elementary.elm_label_ellipsis_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_ellipsis_set(RealHandle, value);
            }
        }

        public void PlaySlide()
        {
            Interop.Elementary.elm_label_slide_go(RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_label_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }

    public enum LabelSlideMode
    {
        None = 0,
        Auto,
        Always
    }
}
