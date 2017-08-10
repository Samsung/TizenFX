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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal class PlaceListHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaceCallback(int index, IntPtr /* maps_place_h */ place, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_list_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_list_h */ placeList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_list_foreach")]
        internal static extern ErrorCode Foreach(IntPtr /* maps_place_list_h */ placeList, PlaceCallback callback, IntPtr /* void */ userData);

        public PlaceListHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy) { }

        internal void Foreach(Action<PlaceHandle> action)
        {
            PlaceCallback callback = (index, handle, userData) =>
            {
                action(PlaceHandle.CloneFrom(handle));
                return true;
            };

            Foreach(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get place list from native handle");
        }
    }
}
