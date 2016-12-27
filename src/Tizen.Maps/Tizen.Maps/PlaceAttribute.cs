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
    /// Place Attributes information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceAttribute
    {
        private string _id;
        private string _label;
        private string _text;

        internal PlaceAttribute(IntPtr nativeHandle)
        {
            var handle = new Interop.PlaceAttributeHandle(nativeHandle);
            var err = Interop.PlaceAttribute.GetId(handle, out _id);
            err.WarnIfFailed("Failed to get id for this attribute");

            err = Interop.PlaceAttribute.GetLabel(handle, out _label);
            err.WarnIfFailed("Failed to get label for this attribute");

            err = Interop.PlaceAttribute.GetText(handle, out _text);
            err.WarnIfFailed("Failed to get text for this attribute");
        }

        /// <summary>
        /// Place Attribute ID
        /// </summary>
        public string Id { get { return _id; } }

        /// <summary>
        /// Place attribute label
        /// </summary>
        public string Label { get { return _label; } }

        /// <summary>
        /// Place attribute text
        /// </summary>
        public string Text { get { return _text; } }
    }
}
