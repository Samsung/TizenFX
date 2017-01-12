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
    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_building_number")]
    internal static extern ErrorCode GetBuildingNumber(this AddressHandle /* maps_address_h */ address, out string buildingNumber);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_building_number")]
    internal static extern ErrorCode SetBuildingNumber(this AddressHandle /* maps_address_h */ address, string buildingNumber);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_street")]
    internal static extern ErrorCode GetStreet(this AddressHandle /* maps_address_h */ address, out string street);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_street")]
    internal static extern ErrorCode SetStreet(this AddressHandle /* maps_address_h */ address, string street);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_district")]
    internal static extern ErrorCode GetDistrict(this AddressHandle /* maps_address_h */ address, out string district);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_district")]
    internal static extern ErrorCode SetDistrict(this AddressHandle /* maps_address_h */ address, string district);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_city")]
    internal static extern ErrorCode GetCity(this AddressHandle /* maps_address_h */ address, out string city);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_city")]
    internal static extern ErrorCode SetCity(this AddressHandle /* maps_address_h */ address, string city);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_state")]
    internal static extern ErrorCode GetState(this AddressHandle /* maps_address_h */ address, out string state);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_state")]
    internal static extern ErrorCode SetState(this AddressHandle /* maps_address_h */ address, string state);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_country")]
    internal static extern ErrorCode GetCountry(this AddressHandle /* maps_address_h */ address, out string country);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_country")]
    internal static extern ErrorCode SetCountry(this AddressHandle /* maps_address_h */ address, string country);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_country_code")]
    internal static extern ErrorCode GetCountryCode(this AddressHandle /* maps_address_h */ address, out string countryCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_country_code")]
    internal static extern ErrorCode SetCountryCode(this AddressHandle /* maps_address_h */ address, string countryCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_county")]
    internal static extern ErrorCode GetCounty(this AddressHandle /* maps_address_h */ address, out string county);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_county")]
    internal static extern ErrorCode SetCounty(this AddressHandle /* maps_address_h */ address, string county);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_postal_code")]
    internal static extern ErrorCode GetPostalCode(this AddressHandle /* maps_address_h */ address, out string postalCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_postal_code")]
    internal static extern ErrorCode SetPostalCode(this AddressHandle /* maps_address_h */ address, string postalCode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_get_freetext")]
    internal static extern ErrorCode GetFreetext(this AddressHandle /* maps_address_h */ address, out string freetext);

    [DllImport(Libraries.MapService, EntryPoint = "maps_address_set_freetext")]
    internal static extern ErrorCode SetFreetext(this AddressHandle /* maps_address_h */ address, string freetext);

    internal class AddressHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_address_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_address_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_address_h */ origin, out IntPtr /* maps_address_h */ cloned);

        internal string Building
        {
            get { return NativeGet(this.GetBuildingNumber); }
            set { NativeSet(this.SetBuildingNumber, value); }
        }

        internal string Street
        {
            get { return NativeGet(this.GetStreet); }
            set { NativeSet(this.SetStreet, value); }
        }

        internal string City
        {
            get { return NativeGet(this.GetCity); }
            set { NativeSet(this.SetCity, value); }
        }

        internal string District
        {
            get { return NativeGet(this.GetDistrict); }
            set { NativeSet(this.SetDistrict, value); }
        }

        internal string State
        {
            get { return NativeGet(this.GetState); }
            set { NativeSet(this.SetState, value); }
        }

        internal string Country
        {
            get { return NativeGet(this.GetCountry); }
            set { NativeSet(this.SetCountry, value); }
        }

        internal string CountryCode
        {
            get { return NativeGet(this.GetCountryCode); }
            set { NativeSet(this.SetCountryCode, value); }
        }

        internal string County
        {
            get { return NativeGet(this.GetCounty); }
            set { NativeSet(this.SetCounty, value); }
        }

        internal string PostalCode
        {
            get { return NativeGet(this.GetPostalCode); }
            set { NativeSet(this.SetPostalCode, value); }
        }

        internal string Freetext
        {
            get { return NativeGet(this.GetFreetext); }
            set { NativeSet(this.SetFreetext, value); }
        }

        internal AddressHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal AddressHandle() : this(IntPtr.Zero, true)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal static AddressHandle CloneFrom(IntPtr nativeHandle)
        {
            IntPtr handle;
            Clone(nativeHandle, out handle).ThrowIfFailed("Failed to clone native handle");
            return new AddressHandle(handle, true);
        }

        internal static AddressHandle Create(IntPtr nativeHandle)
        {
            return new AddressHandle(nativeHandle, true);
        }
    }
}
