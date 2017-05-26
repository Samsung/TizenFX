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
    [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_append")]
    internal static extern ErrorCode Append(this CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_remove")]
    internal static extern ErrorCode Remove(this CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, CoordinatesHandle /* maps_coordinates_h */ coordinates);


    internal class CoordinatesListHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CoordinatesCallback(int index, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_coordinates_list_h */ coordinatesList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_coordinates_list_h */ coordinatesList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_foreach")]
        internal static extern ErrorCode Foreach(IntPtr /* maps_coordinates_list_h */ coordinatesList, CoordinatesCallback callback, IntPtr /* void */ userData);

        internal CoordinatesListHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy) { }

        internal CoordinatesListHandle(bool needToRelease = true) : this(IntPtr.Zero, needToRelease)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal void Add(CoordinatesHandle handleToAdd)
        {
            using (var clonedHandle = CoordinatesHandle.CloneFrom(handleToAdd))
            {
                if (this.Append(clonedHandle).WarnIfFailed("Failed to add coordinates to the list"))
                {
                    clonedHandle.HasOwnership = false;
                }
            }
        }

        internal void ForEach(Action<CoordinatesHandle> action)
        {
            CoordinatesCallback callback = (index, handle, userData) =>
            {
                action(CoordinatesHandle.CloneFrom(handle));
                return true;
            };

            Foreach(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get coordinates list from native handle");
        }
    }
}
