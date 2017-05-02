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
    internal static partial class Mtp
    {
        //Callback for event
        //mtp_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MptStateChangedCallback(int eventType, int eventParameter, IntPtr userData);

        //capi-network-mtp-1.3.16-2.3.armv7l.rpm
        ////Mtp Manager
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_deinitialize")]
        internal static extern int Deinitialize();
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_get_devices")]
        internal static extern int GetDevices(out IntPtr devices, out int count);
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_get_storages")]
        internal static extern int GetStorages(int device, out IntPtr storages, out int count);
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_get_object_handles")]
        internal static extern int GetObjectHandles(int device, int storage, int fileType, int parentHandle, out IntPtr objectHandle, out int count);
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_get_object")]
        internal static extern bool GetObject(int device, int objectHandle, string fileDestinationPath);
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_get_thumbnail")]
        internal static extern int getThumbnail(int device, int objectHandle, string fileDestinationPath);

        [DllImport(Libraries.Mtp, EntryPoint = "mtp_add_mtp_event_cb")]
        internal static extern int AddMtpStateChangedCallback(MptStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Mtp, EntryPoint = "mtp_remove_mtp_event_cb")]
        internal static extern int RemoveMtpStateChangedCallback(MptStateChangedCallback callback);

        internal static class DeviceInfomation
        {
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_deviceinfo_get_manufacturer_name")]
            internal static extern int GetManufacturerName(int device, out IntPtr manufacturerName);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_deviceinfo_get_model_name")]
            internal static extern int GetModelName(int device, out IntPtr modelName);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_deviceinfo_get_serial_number")]
            internal static extern int GetSerialNumber(int device, out IntPtr serialNumber);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_deviceinfo_get_device_version")]
            internal static extern int GetDeviceVersion(int device, out IntPtr deviceVersion);
        }

        internal static class StorageInformation
        {
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_storageinfo_get_description")]
            internal static extern int GetDescription(int device, int storage, out IntPtr description);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_storageinfo_get_free_space")]
            internal static extern int GetFreeSpace(int device, int storage, out UInt64 freeSpace);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_storageinfo_get_max_capacity")]
            internal static extern int GetMaxCapacity(int device, int storage, out UInt64 maxCapacity);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_storageinfo_get_storage_type")]
            internal static extern int GetStorageType(int device, int storage, out int storageType);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_storageinfo_get_volume_identifier")]
            internal static extern int GetVolumeIdentifier(int device, int storage, out IntPtr volumeIdentifier);
        }

        internal static class ObjectInformation
        {
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_file_name")]
            internal static extern int GetFileName(int device, int objectHandle, out IntPtr fileName);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_keywords")]
            internal static extern int GetKeywords(int device, int objectHandle, out IntPtr keyWords);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_association_desc")]
            internal static extern int GetAssociationDescription(int device, int objectHandle, out int associationDescription);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_association_type")]
            internal static extern int GetAssociationType(int device, int objectHandle, out int associationType);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_size")]
            internal static extern int GetSize(int device, int objectHandle, out int size);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_parent_object_handle")]
            internal static extern int GetParentObjectHandle(int device, int objectHandle, out int parentObjectHandle);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_storage")]
            internal static extern int GetStorage(int device, int objectHandle, out int stroage);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_date_created")]
            internal static extern int GetDateCreated(int device, int objectHandle, out int dateCreated);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_date_modified")]
            internal static extern int GetDateModified(int device, int objectHandle, out int dateModified);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_file_type")]
            internal static extern int GetFileType(int device, int objectHandle, out int fileType);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_image_bit_depth")]
            internal static extern int GetImageBitDepth(int device, int objectHandle, out int depth);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_image_pix_width")]
            internal static extern int GetImagePixWidth(int device, int objectHandle, out int width);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_image_pix_height")]
            internal static extern int GetImagePixHeight(int device, int objectHandle, out int height);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_thumbnail_size")]
            internal static extern int GetThumbnailSize(int device, int objectHandle, out int size);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_thumbnail_file_type")]
            internal static extern int GetThumbnailFileType(int device, int objectHandle, out int fileType);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_thumbnail_pix_height")]
            internal static extern int GetThumbnailPixHeight(int device, int objectHandle, out int height);
            [DllImport(Libraries.Mtp, EntryPoint = "mtp_objectinfo_get_thumbnail_pix_width")]
            internal static extern int GetThumbnailPixWidth(int device, int objectHandle, out int width);
        }

    }
}
