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
using Tizen.Applications;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionPeerInfo
    {
        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_clone")]
        internal static extern ErrorCode CionPeerInfoClone(IntPtr peerInfo, out PeerInfoSafeHandle peerInfoClone);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_destroy")]
        internal static extern ErrorCode CionPeerInfoDestroy(IntPtr peerInfo);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_id")]
        internal static extern ErrorCode CionPeerInfoGetDeviceId(PeerInfoSafeHandle peerInfo, out string deviceId);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_name")]
        internal static extern ErrorCode CionPeerInfoGetDeviceName(PeerInfoSafeHandle peerInfo, out string deviceName);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_platform")]
        internal static extern ErrorCode CionPeerInfoGetDevicePlatform(PeerInfoSafeHandle peerInfo, out string devicePlatform);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_platform_version")]
        internal static extern ErrorCode CionPeerInfoGetDevicePlatformVersion(PeerInfoSafeHandle peerInfo, out string devicePlatformVersion);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_device_type")]
        internal static extern ErrorCode CionPeerInfoGetDeviceType(PeerInfoSafeHandle peerInfo, out string deviceType);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_app_id")]
        internal static extern ErrorCode CionPeerInfoGetAppId(PeerInfoSafeHandle peerInfo, out string appId);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_app_version")]
        internal static extern ErrorCode CionPeerInfoGetAppVersion(PeerInfoSafeHandle peerInfo, out string appVersion);

        [DllImport(Libraries.Cion, EntryPoint = "cion_peer_info_get_uuid")]
        internal static extern ErrorCode CionPeerInfoGetUuid(PeerInfoSafeHandle peerInfo, out string uuid);
    }
}
