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

namespace Tizen.Maps
{
    /// <summary>
    /// Place attributes information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceAttribute
    {
        private string _id;
        private string _label;
        private string _text;

        internal PlaceAttribute(Interop.PlaceAttributeHandle nativeHandle)
        {
            _id = nativeHandle.Id;
            _label = nativeHandle.Label;
            _text = nativeHandle.Text;
        }

        internal PlaceAttribute(IntPtr nativeHandle, bool needToRelease)
            : this(new Interop.PlaceAttributeHandle(nativeHandle, needToRelease))
        {
        }

        /// <summary>
        /// Gets an ID for the place attribute.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Id { get { return _id; } }

        /// <summary>
        /// Gets a label for the place attribute.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Label { get { return _label; } }

        /// <summary>
        /// Gets a text for the place attribute.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text { get { return _text; } }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
        public override string ToString()
        {
            return $"{Label}: {Text}";
        }
    }
}
