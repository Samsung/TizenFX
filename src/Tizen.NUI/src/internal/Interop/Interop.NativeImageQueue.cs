/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NativeImageQueue
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_NativeImageQueuePtr_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewHandle(uint queueCount, uint width, uint height, int colorFormat);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_GetPtr", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Get(IntPtr queue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_NativeImageQueuePtr", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Delete(IntPtr queue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_CanDequeueBuffer", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool CanDequeueBuffer(IntPtr queue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_DequeueBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DequeueBuffer(IntPtr queue, ref int width, ref int height, ref int colorDepth);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_EnqueueBuffer", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EnqueueBuffer(IntPtr queue, IntPtr buffer);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_GetQueueCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetQueueCount(IntPtr queue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_GenerateUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GenerateUrl(IntPtr queue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_GenerateUrl_With_PreMultiplied", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GenerateUrl(IntPtr queue, [MarshalAs(UnmanagedType.U1)] bool preMultiplied);

            // Platform dependency methods
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueuePtr_New_Handle_With_TbmQueue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewHandleWithTbmQueue(IntPtr csTbmQueue);
        }
    }
}





