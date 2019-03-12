/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// <summary>
    /// The Label is a widget to display text, with a simple HTML-like markup.
    /// Inherits Layout.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Label : Layout
    {
        SmartEvent _slideCompleted;

        /// <summary>
        /// Creates and initializes a new instance of the Label class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the Label as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public Label(EvasObject parent) : base(parent)
        {
            _slideCompleted = new SmartEvent(this, this.RealHandle, "slide,end");
            _slideCompleted.On += (s, e) =>
            {
                SlideCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// SlideCompleted will be triggered when the slide is completed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler SlideCompleted;

        /// <summary>
        /// Sets or gets the wrap width of the label.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the wrapping behavior of the label.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_label_line_wrap_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_line_wrap_set(RealHandle, (int)value);
                if (value != WrapType.None)
                {
                    Interop.Evas.evas_object_size_hint_min_get(RealHandle, IntPtr.Zero, out int h);
                    Interop.Evas.evas_object_size_hint_min_set(RealHandle, 0, h);
                }
            }
        }

        /// <summary>
        /// Sets or gets the slide mode of the Label widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the slide duration of the label.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the slide speed of the label.
        /// </summary>
        /// <remarks>
        /// The speed of the slide animation in px per seconds.
        /// If you set the duration of the slide using elm_label_slide_duration_set(), you cannot get the correct speed using this function until the label is actually rendered and resized.
        /// </remarks>
        /// <seealso cref="SlideDuration"/>
        /// <since_tizen> preview </since_tizen>
        public double SlideSpeed
        {
            get
            {
                return Interop.Elementary.elm_label_slide_speed_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_speed_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the ellipsis behavior of the label.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the style of the label text.
        /// </summary>
        /// <remarks>
        /// APIs, elm_label_text_style_user_peek/pop/push, are internal APIs only in Tizen. Available since Tizen_4.0.
        /// </remarks>
        /// 
        /// <since_tizen> preview </since_tizen>
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.elm_label_text_style_user_peek(RealHandle);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Interop.Elementary.elm_label_text_style_user_pop(RealHandle);
                }
                else
                {
                    Interop.Elementary.elm_label_text_style_user_push(RealHandle, value);
                }
            }
        }

        /// <summary>
        /// Starts the slide effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PlaySlide()
        {
            Interop.Elementary.elm_label_slide_go(RealHandle);
        }

        /// <summary>
        /// Sets the content at a part of a given container widget.
        /// </summary>
        /// <param name="parent">EvasObject</param>
        /// <returns>The new object, otherwise null if it cannot be created.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {            
            return Interop.Elementary.elm_label_add(parent.Handle);
        }
    }

    /// <summary>
    /// Enumeration for the slide modes of a label widget.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum LabelSlideMode
    {
        /// <summary>
        /// No slide effect.
        /// </summary>
        None = 0,
        /// <summary>
        /// Slide only if the label area is bigger than the text width length.
        /// </summary>
        Auto,
        /// <summary>
        /// Slide always.
        /// </summary>
        Always
    }
}
