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
    internal static partial class Address
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AddressCallback(int index, IntPtr /* maps_address_h */ addressHandle, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_address_h */ origin, out IntPtr /* maps_address_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_building_number")]
        internal static extern ErrorCode GetBuildingNumber(AddressHandle /* maps_address_h */ address, out string buildingNumber);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_street")]
        internal static extern ErrorCode GetStreet(AddressHandle /* maps_address_h */ address, out string street);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_district")]
        internal static extern ErrorCode GetDistrict(AddressHandle /* maps_address_h */ address, out string district);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_city")]
        internal static extern ErrorCode GetCity(AddressHandle /* maps_address_h */ address, out string city);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_state")]
        internal static extern ErrorCode GetState(AddressHandle /* maps_address_h */ address, out string state);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_country")]
        internal static extern ErrorCode GetCountry(AddressHandle /* maps_address_h */ address, out string country);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_country_code")]
        internal static extern ErrorCode GetCountryCode(AddressHandle /* maps_address_h */ address, out string countryCode);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_county")]
        internal static extern ErrorCode GetCounty(AddressHandle /* maps_address_h */ address, out string county);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_postal_code")]
        internal static extern ErrorCode GetPostalCode(AddressHandle /* maps_address_h */ address, out string postalCode);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_freetext")]
        internal static extern ErrorCode GetFreetext(AddressHandle /* maps_address_h */ address, out string freetext);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_building_number")]
        internal static extern ErrorCode SetBuildingNumber(AddressHandle /* maps_address_h */ address, string buildingNumber);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_street")]
        internal static extern ErrorCode SetStreet(AddressHandle /* maps_address_h */ address, string street);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_district")]
        internal static extern ErrorCode SetDistrict(AddressHandle /* maps_address_h */ address, string district);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_city")]
        internal static extern ErrorCode SetCity(AddressHandle /* maps_address_h */ address, string city);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_state")]
        internal static extern ErrorCode SetState(AddressHandle /* maps_address_h */ address, string state);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_country")]
        internal static extern ErrorCode SetCountry(AddressHandle /* maps_address_h */ address, string country);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_country_code")]
        internal static extern ErrorCode SetCountryCode(AddressHandle /* maps_address_h */ address, string countryCode);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_county")]
        internal static extern ErrorCode SetCounty(AddressHandle /* maps_address_h */ address, string county);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_postal_code")]
        internal static extern ErrorCode SetPostalCode(AddressHandle /* maps_address_h */ address, string postalCode);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_freetext")]
        internal static extern ErrorCode SetFreetext(AddressHandle /* maps_address_h */ address, string freetext);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_create")]
        internal static extern ErrorCode ListCreate(out IntPtr /* maps_address_list_h */ addressList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_append")]
        internal static extern ErrorCode ListAppend(AddressListHandle /* maps_address_list_h */ addressList, AddressHandle /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_remove")]
        internal static extern ErrorCode ListRemove(AddressListHandle /* maps_address_list_h */ addressList, AddressHandle /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_get_length")]
        internal static extern ErrorCode ListGetLength(AddressListHandle /* maps_address_list_h */ addressList, out int length);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_foreach")]
        internal static extern ErrorCode ListForeach(AddressListHandle /* maps_address_list_h */ addressList, AddressCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_list_destroy")]
        internal static extern ErrorCode ListDestroy(IntPtr /* maps_address_list_h */ addressList);
    }

    internal class AddressHandle : SafeMapsHandle
    {
        public AddressHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Address.Destroy; }
    }


    internal class AddressListHandle : SafeMapsHandle
    {
        public AddressListHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Address.ListDestroy; }
    }
}
