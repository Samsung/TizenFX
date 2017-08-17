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
    /// Place contact information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceContact
    {
        private string _label;
        private string _type;
        private string _value;

        internal PlaceContact(Interop.PlaceContactHandle handle)
        {
            _label = handle.Label;
            _type = handle.Type;
            _value = handle.Value;
        }

        internal PlaceContact(IntPtr nativeHandle, bool needToRelease) : this(new Interop.PlaceContactHandle(nativeHandle, needToRelease))
        {
        }

        /// <summary>
        /// Gets an ID for this place contact.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Id { get { return _type; } }

        /// <summary>
        /// Gets a label for this place contact.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Label { get { return _label; } }

        /// <summary>
        /// Gets a value for this place contact.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Value { get { return _value; } }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
        public override string ToString()
        {
            return $"{Label}: {Value}";
        }
    }
}
