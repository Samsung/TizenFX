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
    /// <summary>
    /// The Background is a widget that use for setting (solid) background decorations to a window (unless it has transparency enabled)
    /// or to any container object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Background : Layout
    {
        /// <summary>
        /// Creates and initializes a new instance of the Background class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new background will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Background(EvasObject parent) : base(parent)
        {
            Style = "transparent";
        }

        /// <summary>
        /// Sets or gets the color to the background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color Color
        {
            get
            {
                return BackgroundColor;
            }
            set
            {
                BackgroundColor = value;
            }
        }

        /// <summary>
        /// Sets or gets the image to the background.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string File
        {
            get
            {
                return Interop.Elementary.BackgroundFileGet(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_bg_file_set(RealHandle, value, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Sets or gets the mode of display for a given background widget's image.
        /// </summary>
        /// <remarks>
        /// This sets how the background widget will display its image.
        /// This will only work if the file was previously set with an image file on object.
        /// The image can be display tiled, scaled, centered, or stretched. Scaled by default.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public BackgroundOptions BackgroundOption
        {
            get
            {
                return (BackgroundOptions)Interop.Elementary.elm_bg_option_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_bg_option_set(RealHandle, (Interop.Elementary.BackgroundOptions)value);
            }
        }

        /// <summary>
        /// Sets the size of the pixmap representation of the image set on a given background widget.
        /// This method just makes sense if an image file was set.
        /// This is just a hint for the underlying system.
        /// The real size of the pixmap may differ depending on the type of image being loaded, being bigger than requested.
        /// </summary>
        /// <param name="w">The new width of the image pixmap representation.</param>
        /// <param name="h">The new height of the image pixmap representation.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFileLoadSize(int w, int h)
        {
            if (File != null)
            {
                Interop.Elementary.elm_bg_load_size_set(RealHandle, w, h);
            }
            else
            {
                throw new InvalidOperationException("This method just makes sense if an image file was set.");
            }
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_bg_add(parent.Handle);
        }
    }

    /// <summary>
    /// Enumeration for the background types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum BackgroundOptions
    {
        /// <summary>
        /// Centers the background image.
        /// </summary>
        Center,

        /// <summary>
        /// Scales the background image, retaining the aspect ratio.
        /// </summary>
        Scale,

        /// <summary>
        /// Stretches the background image to fill the UI component's area.
        /// </summary>
        Stretch,

        /// <summary>
        /// Tiles the background image at its original size.
        /// </summary>
        Tile
    }
}
