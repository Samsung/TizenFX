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
    /// Enumeration for the icon lookup order. Should look for icons in the theme, FDO paths, or both.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum IconLookupOrder
    {
        /// <summary>
        /// Icon look up order: freedesktop, theme.
        /// </summary>
        FreeDesktopFirst = 0,
        /// <summary>
        /// Icon look up order: theme, freedesktop.
        /// </summary>
        ThemeFirst,
        /// <summary>
        /// Icon look up order: freedesktop.
        /// </summary>
        FreeDesktopOnly,
        /// <summary>
        /// Icon look up order: theme.
        /// </summary>
        ThemeOnly
    }

    /// <summary>
    /// The Icon is a widget that displays the standard icon images ("delete", "edit", "arrows", etc.)
    /// or images coming from a custom file (PNG, JPG, EDJE, etc.), on the icon context.
    /// Inherits Image.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Icon : Image
    {
        /// <summary>
        /// Creates and initializes a new instance of the Icon class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by Icon as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public Icon(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets the standard icon name of a given Icon widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string StandardIconName
        {
            get
            {
                return Interop.Elementary.elm_icon_standard_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_icon_standard_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the icon lookup order of a given Icon widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IconLookupOrder IconLookupOrder
        {
            get
            {
                return (IconLookupOrder)Interop.Elementary.elm_icon_order_lookup_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_icon_order_lookup_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets the file that is used, but uses a generated thumbnail.
        /// </summary>
        /// <param name="file">The path to the file that is used as an icon image.</param>
        /// <param name="group">The group that the icon belongs to.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetThumb(string file, string group)
        {
            Interop.Elementary.elm_icon_thumb_set(RealHandle, file, group);
        }

        /// <summary>
        /// Adds a new icon object to the parent.
        /// </summary>
        /// <param name="parent">EvasObject</param>
        /// <returns>The new object, otherwise null if it cannot be created.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_icon_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
