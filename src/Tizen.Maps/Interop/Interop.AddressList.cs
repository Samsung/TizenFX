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
    [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_append")]
    internal static extern ErrorCode ListAppend(this AddressListHandle /* maps_address_list_h */ addressList, AddressHandle /* maps_address_h */ address);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_remove")]
    internal static extern ErrorCode ListRemove(this AddressListHandle /* maps_address_list_h */ addressList, AddressHandle /* maps_address_h */ address);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_get_length")]
    internal static extern ErrorCode ListGetLength(this AddressListHandle /* maps_address_list_h */ addressList, out int length);


    internal class AddressListHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AddressCallback(int index, IntPtr /* maps_address_h */ addressHandle, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_address_list_h */ addressList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_address_list_h */ addressList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_foreach")]
        internal static extern ErrorCode Foreach(IntPtr /* maps_address_list_h */ addressList, AddressCallback callback, IntPtr /* void */ userData);

        internal AddressListHandle() : base(IntPtr.Zero, true, Destroy)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal AddressListHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal void Foreach(Action<AddressHandle> action)
        {
            AddressCallback callback = (index, handle, userData) =>
            {
                action(AddressHandle.CloneFrom(handle));
                return true;
            };

            Foreach(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get address list from native handle");
        }
    }
}
