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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_id")]
    internal static extern ErrorCode GetId(this PlaceHandle /* maps_place_h */ place, out string id);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_name")]
    internal static extern ErrorCode GetName(this PlaceHandle /* maps_place_h */ place, out string name);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_uri")]
    internal static extern ErrorCode GetUri(this PlaceHandle /* maps_place_h */ place, out string uri);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_distance")]
    internal static extern ErrorCode GetDistance(this PlaceHandle /* maps_place_h */ place, out int distance);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_location")]
    internal static extern ErrorCode GetLocation(this PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_coordinates_h */ location);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_address")]
    internal static extern ErrorCode GetAddress(this PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_address_h */ address);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_rating")]
    internal static extern ErrorCode GetRating(this PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_rating_h */ rating);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_supplier_link")]
    internal static extern ErrorCode GetSupplierLink(this PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_link_object_h */ supplier);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_get_related_link")]
    internal static extern ErrorCode GetRelatedLink(this PlaceHandle /* maps_place_h */ place, out IntPtr /* maps_place_link_object_h */ related);

    internal class PlaceHandle : SafeMapsHandle
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

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_property")]
        internal static extern ErrorCode ForeachProperty(IntPtr /* maps_place_h */ place, PropertiesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_category")]
        internal static extern ErrorCode ForeachCategory(IntPtr /* maps_place_h */ place, CategoriesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_attribute")]
        internal static extern ErrorCode ForeachAttribute(IntPtr /* maps_place_h */ place, AttributesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_contact")]
        internal static extern ErrorCode ForeachContact(IntPtr /* maps_place_h */ place, ContactsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_editorial")]
        internal static extern ErrorCode ForeachEditorial(IntPtr /* maps_place_h */ place, EditorialsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_image")]
        internal static extern ErrorCode ForeachImage(IntPtr /* maps_place_h */ place, ImagesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_foreach_review")]
        internal static extern ErrorCode ForeachReview(IntPtr /* maps_place_h */ place, ReviewsCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_h */ place);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_place_h */ origin, out IntPtr /* maps_place_h */ cloned);

        internal string Id
        {
            get { return NativeGet(this.GetId); }
        }

        internal string Name
        {
            get { return NativeGet(this.GetName); }
        }

        internal string Uri
        {
            get { return NativeGet(this.GetUri); }
        }

        internal int Distance
        {
            get { return NativeGet<int>(this.GetDistance); }
        }

        internal CoordinatesHandle Coordinates
        {
            get { return NativeGet(this.GetLocation, CoordinatesHandle.Create); }
        }

        internal AddressHandle Address
        {
            get { return NativeGet(this.GetAddress, AddressHandle.Create); }
        }

        internal PlaceRatingHandle Rating
        {
            get { return NativeGet(this.GetRating, PlaceRatingHandle.Create); }
        }

        internal PlaceLinkObjectHandle Supplier
        {
            get { return NativeGet(this.GetSupplierLink, PlaceLinkObjectHandle.Create); }
        }

        internal PlaceLinkObjectHandle Related
        {
            get { return NativeGet(this.GetRelatedLink, PlaceLinkObjectHandle.Create); }
        }

        public PlaceHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal static PlaceHandle CloneFrom(IntPtr nativeHandle)
        {
            IntPtr handle;
            Clone(nativeHandle, out handle).ThrowIfFailed("Failed to clone native handle");
            return new PlaceHandle(handle, true);
        }


        internal void ForeachProperty(Action<string, string> action)
        {
            PropertiesCallback callback = (index, total, key, value, userData) =>
            {
                action(key, value);
                return true;
            };

            ForeachProperty(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get property list from native handle");
        }

        internal void ForeachCategory(Action<PlaceCategoryHandle> action)
        {
            // PlaceCategoryHandle is valid only in this callback and users should not keep its reference
            CategoriesCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceCategoryHandle(handle, true));
                return true;
            };

            ForeachCategory(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get category list from native handle");
        }

        internal void ForeachAttribute(Action<PlaceAttributeHandle> action)
        {
            // PlaceAttributeHandle is valid only in this callback and users should not keep its reference
            AttributesCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceAttributeHandle(handle, true));
                return true;
            };

            ForeachAttribute(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get attributes list from native handle");
        }

        internal void ForeachContact(Action<PlaceContactHandle> action)
        {
            // PlaceContactHandle is valid only in this callback and users should not keep its reference
            ContactsCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceContactHandle(handle, true));
                return true;
            };

            ForeachContact(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get contacts list from native handle");
        }

        internal void ForeachEditorial(Action<PlaceEditorialHandle> action)
        {
            // PlaceEditorialHandle is valid only in this callback and users should not keep its reference
            EditorialsCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceEditorialHandle(handle, true));
                return true;
            };

            ForeachEditorial(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get editorial list from native handle");
        }

        internal void ForeachImage(Action<PlaceImageHandle> action)
        {
            // PlaceImageHandle is valid only in this callback and users should not keep its reference
            ImagesCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceImageHandle(handle, true));
                return true;
            };

            ForeachImage(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get image list from native handle");
        }

        internal void ForeachReview(Action<PlaceReviewHandle> action)
        {
            // PlaceReviewHandle is valid only in this callback and users should not keep its reference
            ReviewsCallback callback = (index, total, handle, userData) =>
            {
                action(new PlaceReviewHandle(handle, true));
                return true;
            };

            ForeachReview(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get review list from native handle");
        }
    }
}
