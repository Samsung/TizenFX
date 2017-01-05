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
    /// Place Link Object information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceLink
    {
        private string _id;
        private string _name;
        private string _string;
        private string _type;

        internal PlaceLink(IntPtr nativeHandle)
        {
            var handle = new Interop.PlaceLinkObjectHandle(nativeHandle);

            Interop.PlaceLinkObject.GetId(handle, out _id);
            Interop.PlaceLinkObject.GetName(handle, out _name);
            Interop.PlaceLinkObject.GetString(handle, out _string);
            Interop.PlaceLinkObject.GetType(handle, out _type);
        }

        /// <summary>
        /// Place link ID
        /// </summary>
        public string Id { get { return _id; } }

        /// <summary>
        /// Place link name
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Place link string
        /// </summary>
        public string LinkString { get { return _string; } }

        /// <summary>
        /// Place link type
        /// </summary>
        public string Type { get { return _type; } }
    }
}
