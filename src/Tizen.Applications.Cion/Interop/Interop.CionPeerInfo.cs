/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Applications.Cion;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionPeerInfo
    {
        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_clone")]
        internal static partial ErrorCode CionPeerInfoClone(IntPtr peerInfo, out PeerInfoSafeHandle peerInfoClone);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_destroy")]
        internal static partial ErrorCode CionPeerInfoDestroy(IntPtr peerInfo);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetDeviceId(PeerInfoSafeHandle peerInfo, out string deviceId);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetDeviceName(PeerInfoSafeHandle peerInfo, out string deviceName);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_platform", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetDevicePlatform(PeerInfoSafeHandle peerInfo, out string devicePlatform);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_platform_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetDevicePlatformVersion(PeerInfoSafeHandle peerInfo, out string devicePlatformVersion);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetDeviceType(PeerInfoSafeHandle peerInfo, out string deviceType);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetAppId(PeerInfoSafeHandle peerInfo, out string appId);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_app_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetAppVersion(PeerInfoSafeHandle peerInfo, out string appVersion);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_uuid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPeerInfoGetUuid(PeerInfoSafeHandle peerInfo, out string uuid);
    }
}



