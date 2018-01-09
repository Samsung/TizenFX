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
    /// The Rectangle is a class that is used to draw a solid colored rectangle.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Rectangle : EvasObject
    {
        /// <summary>
        /// Creates and initializes a new instance of the Rectangle class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new slider will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Rectangle(EvasObject parent) : base(parent)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, 1.0, 1.0);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.Evas.evas_object_evas_get(parent.Handle);
            return Interop.Evas.evas_object_rectangle_add(evas);
        }
    }
}
