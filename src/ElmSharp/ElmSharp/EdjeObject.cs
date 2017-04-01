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
    /// The EdjeObject is a class that evas object exist in
    /// </summary>
    public class EdjeObject
    {
        IntPtr _edjeHandle;

        internal EdjeObject(IntPtr handle)
        {
            _edjeHandle = handle;
        }

        /// <summary>
        /// Checks whether an edje part exists in a given edje object's group definition.
        /// This function returns if a given part exists in the edje group bound to object obj
        /// </summary>
        /// <remarks>This call is useful, for example, when one could expect a given GUI element, depending on the theme applied to obj.</remarks>
        /// <param name="part">The part's name to check for existence in obj's group</param>
        /// <returns>TRUE, if the edje part exists in obj's group, otherwise FALSE</returns>
        public EdjeTextPartObject this[string part]
        {
            get
            {
                if (Interop.Elementary.edje_object_part_exists(_edjeHandle, part))
                {
                    return new EdjeTextPartObject(_edjeHandle, part);
                }
                return null;
            }
        }

        /// <summary>
        /// Sends/emits an edje signal to a given edje object.
        /// </summary>
        /// <param name="emission">The signal's "emission" string</param>
        /// <param name="source">The signal's "source" string</param>
        public void EmitSignal(string emission, string source)
        {
            Interop.Elementary.edje_object_signal_emit(_edjeHandle, emission, source);
        }

        /// <summary>
        /// Deletes the object color class.
        /// This function deletes any values at the object level for the specified object and color class.
        /// </summary>
        /// <remarks>Deleting the color class defined in the theme file.</remarks>
        /// <param name="part">The color class to be deleted</param>
        public void DeleteColorClass(string part)
        {
            Interop.Elementary.edje_object_color_class_del(_edjeHandle, part);
        }
    }

    /// <summary>
    /// An EdjeTextPartObject is a class dealing with parts of type text.
    /// </summary>
    public class EdjeTextPartObject
    {
        string _part;
        IntPtr _edjeHandle;

        internal EdjeTextPartObject(IntPtr edjeHandle, string part)
        {
            _edjeHandle = edjeHandle;
            _part = part;
        }

        /// <summary>
        /// Gets the name of the EdjeTextPartObject
        /// </summary>
        public string Name { get { return _part; } }

        /// <summary>
        /// Gets or sets the text for an object part.
        /// </summary>
        public string Text
        {
            get
            {
                return Interop.Elementary.edje_object_part_text_get(_edjeHandle, _part);
            }
            set
            {
                Interop.Elementary.edje_object_part_text_set(_edjeHandle, _part, value);
            }
        }

        /// <summary>
        /// Sets or gets the style of the object part.
        /// </summary>
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.edje_object_part_text_style_user_peek(_edjeHandle, _part);
            }
            set
            {
                if (value == null)
                {
                    Interop.Elementary.edje_object_part_text_style_user_pop(_edjeHandle, _part);
                }
                else
                {
                    Interop.Elementary.edje_object_part_text_style_user_push(_edjeHandle, _part, value);
                }
            }
        }

        /// <summary>
        /// Gets the geometry of a given edje part, in a given edje object's group definition, relative to the object's area.
        /// </summary>
        public Rect Geometry
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.edje_object_part_geometry_get(_edjeHandle, _part, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        /// <summary>
        /// Gets the native width and height.
        /// </summary>
        public Size TextBlockNativeSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_native_get(part, out w, out h);
                return new Size(w, h);
            }
        }

        /// <summary>
        /// Gets the formatted width and height.
        /// </summary>
        public Size TextBlockFormattedSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_formatted_get(part, out w, out h);
                return new Size(w, h);
            }
        }
    }
}
