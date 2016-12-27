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
using System.Collections.Generic;

namespace Tizen.Maps
{
    public class MapObject
    {
        internal Interop.ViewObjectHandle handle;
        private static Dictionary<IntPtr, MapObject> s_HandleToItemTable = new Dictionary<IntPtr, MapObject>();

        internal MapObject(Interop.ViewObjectHandle nativeHandle)
        {
            handle = nativeHandle;
        }


        /// <summary>
        /// Clicked event
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// Map Object's visibility
        /// </summary>
        public bool IsVisible
        {
            get
            {
                bool value;
                Interop.ViewObject.GetVisible(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.SetVisible(handle, value);
            }
        }

        internal void AddToMapObjectTable()
        {
            s_HandleToItemTable[handle] = this;
        }

        internal void RemoveFromMapObjectTable()
        {
            s_HandleToItemTable.Remove(handle);
        }

        internal static MapObject GetItemByHandle(IntPtr handle)
        {
            MapObject value;
            s_HandleToItemTable.TryGetValue(handle, out value);
            return value;
        }

        internal void HandleClickedEvent()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
