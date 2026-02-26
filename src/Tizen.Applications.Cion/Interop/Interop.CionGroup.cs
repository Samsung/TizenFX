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
    internal static partial class CionGroup
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupPayloadReceivedCb(IntPtr group, IntPtr peerInfo, IntPtr payload, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupJoinedCb(string topicName, IntPtr peerInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionGroupLeftCb(string topicName, IntPtr peerInfo, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupCreate(out GroupSafeHandle group, string topicName, IntPtr security);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupDestroy(IntPtr group);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_subscribe", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupSubscribe(GroupSafeHandle group);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_unsubscribe", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupUnsubscribe(GroupSafeHandle group);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_publish", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupPublish(GroupSafeHandle group, PayloadSafeHandle data);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_add_payload_received_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupAddPayloadReceivedCb(GroupSafeHandle group, CionGroupPayloadReceivedCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_remove_payload_received_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupRemovePayloadReceivedCb(GroupSafeHandle group, CionGroupPayloadReceivedCb cb);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_add_joined_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupAddJoinedCb(GroupSafeHandle group, CionGroupJoinedCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_remove_joined_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupRemoveJoinedCb(GroupSafeHandle group, CionGroupJoinedCb cb);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_add_left_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupAddLeftCb(GroupSafeHandle group, CionGroupLeftCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_group_remove_left_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionGroupRemoveLeftCb(GroupSafeHandle group, CionGroupLeftCb cb);
    }
}



