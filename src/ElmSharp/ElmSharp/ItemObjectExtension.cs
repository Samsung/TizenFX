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
    /// The ItemObjectExtension is used to manage the item object extension.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class ItemObjectExtension
    {
        /// <summary>
        /// Grabs the highlight of the item object.
        /// </summary>
        /// <param name="obj">The item object, which has grabbed the highlight.</param>
        /// <since_tizen> preview </since_tizen>
        public static void GrabHighlight(this ItemObject obj)
        {
            Interop.Elementary.elm_atspi_component_highlight_grab(obj.Handle);
        }

        /// <summary>
        /// Clears the highlight of the item object.
        /// </summary>
        /// <param name="obj">The item object, which has cleared the highlight.</param>
        /// <since_tizen> preview </since_tizen>
        public static void ClearHighlight(this ItemObject obj)
        {
            Interop.Elementary.elm_atspi_component_highlight_clear(obj.Handle);
        }
    }
}
