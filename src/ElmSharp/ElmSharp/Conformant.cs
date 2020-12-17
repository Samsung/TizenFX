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
    /// The Conformant is a widget that can be used in elementary applications
    /// to account for space taken up by the indicator,
    /// virtual keypad &amp; softkey windows when running the illume2 module of E17.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Conformant : Widget
    {
        /// <summary>
        /// Creates and initializes a new instance of the Conformant class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by Conformant
        /// as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public Conformant(Window parent) : base(parent)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, 1.0, 1.0);
            Interop.Elementary.elm_win_conformant_set(parent.Handle, true);
            parent.AddResizeObject(this);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_conformant_add(parent.Handle);
        }
    }
}
