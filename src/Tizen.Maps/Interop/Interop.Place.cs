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
    internal static partial class Place
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PropertiesCallback(int index, int total, string key, string /* void */ value, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CategoriesCallback(int index, int total, IntPtr /* maps_place_category_h */ category, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AttributesCallback(int index, int total, IntPtr /* maps_place_attribute_h */ attribute, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ContactsCallback(int index, int total, IntPtr /* maps_place_contact_h */ contact, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool EditorialsCallback(int index, int total, IntPtr /* maps_place_editorial_h */ editorial, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ImagesCallback(int index, int total, IntPtr /* maps_place_image_h */ image, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ReviewsCallback(int index, int total, IntPtr /* maps_place_review_h */ review, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaceCallback(int index, IntPtr /* maps_place_h */ place, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_h */ place);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_clone")]
        internal static extern ErrorCode Clone(PlaceHandle /* maps_place_h */ origin, out IntPtr /* maps_place_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_id")]
        internal static extern ErrorCode GetId(PlaceHandle /* maps_place_h */ place, out string id);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_name")]
        internal static extern ErrorCode GetName(PlaceHandle /* maps_place_h */ place, out string name);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_uri")]
        internal static extern ErrorCode GetUri(PlaceHandle /* maps_place_h */ place, out string uri);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_location")]
        internal static extern ErrorCode GetLocation(PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_coordinates_h */ location);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_distance")]
        internal static extern ErrorCode GetDistance(PlaceHandle /* maps_place_h */ place, out int distance);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_address")]
        internal static extern ErrorCode GetAddress(PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_address_h */ address);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_rating")]
        internal static extern ErrorCode GetRating(PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_rating_h */ rating);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_property")]
        internal static extern ErrorCode ForeachProperty(PlaceHandle /* maps_place_h */ place, PropertiesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_category")]
        internal static extern ErrorCode ForeachCategory(PlaceHandle /* maps_place_h */ place, CategoriesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_attribute")]
        internal static extern ErrorCode ForeachAttribute(PlaceHandle /* maps_place_h */ place, AttributesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_contact")]
        internal static extern ErrorCode ForeachContact(PlaceHandle /* maps_place_h */ place, ContactsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_editorial")]
        internal static extern ErrorCode ForeachEditorial(PlaceHandle /* maps_place_h */ place, EditorialsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_image")]
        internal static extern ErrorCode ForeachImage(PlaceHandle /* maps_place_h */ place, ImagesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_review")]
        internal static extern ErrorCode ForeachReview(PlaceHandle /* maps_place_h */ place, ReviewsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_supplier_link")]
        internal static extern ErrorCode GetSupplierLink(PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_link_object_h */ supplier);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_related_link")]
        internal static extern ErrorCode GetRelatedLink(PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_link_object_h */ related);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_list_foreach")]
        internal static extern ErrorCode ListForeach(PlaceListHandle /* maps_place_list_h */ placeList, PlaceCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_list_destroy")]
        internal static extern ErrorCode ListDestroy(IntPtr /* maps_place_list_h */ placeList);
    }

    internal class PlaceHandle : SafeMapsHandle
    {
        public PlaceHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Place.Destroy; }
    }

    internal class PlaceListHandle : SafeMapsHandle
    {
        public PlaceListHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Place.ListDestroy; }
    }
}
