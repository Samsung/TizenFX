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
    internal static partial class CionGroup
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupPayloadReceivedCb(IntPtr group, IntPtr peerInfo, IntPtr payload, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupJoinedCb(string topicName, IntPtr peerInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupLeftCb(string topicName, IntPtr peerInfo, IntPtr userData);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_create")]
        internal static extern ErrorCode CionGroupCreate(out GroupSafeHandle group, string topicName, IntPtr security);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_destroy")]
        internal static extern ErrorCode CionGroupDestroy(IntPtr group);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_subscribe")]
        internal static extern ErrorCode CionGroupSubscribe(GroupSafeHandle group);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_unsubscribe")]
        internal static extern ErrorCode CionGroupUnsubscribe(GroupSafeHandle group);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_publish")]
        internal static extern ErrorCode CionGroupPublish(GroupSafeHandle group, PayloadSafeHandle data);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_add_payload_received_cb")]
        internal static extern ErrorCode CionGroupAddPayloadReceivedCb(GroupSafeHandle group, CionGroupPayloadReceivedCb cb, IntPtr userData);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_remove_payload_received_cb")]
        internal static extern ErrorCode CionGroupRemovePayloadReceivedCb(GroupSafeHandle group, CionGroupPayloadReceivedCb cb);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_add_joined_cb")]
        internal static extern ErrorCode CionGroupAddJoinedCb(GroupSafeHandle group, CionGroupJoinedCb cb, IntPtr userData);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_remove_joined_cb")]
        internal static extern ErrorCode CionGroupRemoveJoinedCb(GroupSafeHandle group, CionGroupJoinedCb cb);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_add_left_cb")]
        internal static extern ErrorCode CionGroupAddLeftCb(GroupSafeHandle group, CionGroupLeftCb cb, IntPtr userData);

        [DllImport(Libraries.Cion, EntryPoint = "cion_group_remove_left_cb")]
        internal static extern ErrorCode CionGroupRemoveLeftCb(GroupSafeHandle group, CionGroupLeftCb cb);
    }
}
