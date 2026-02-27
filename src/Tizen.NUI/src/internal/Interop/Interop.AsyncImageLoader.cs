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
        internal static partial class AsyncImageLoader
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AsyncImageLoader", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAsyncImageLoader(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint Load(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint Load(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint Load(IntPtr jarg1, string jarg2, IntPtr jarg3, int jarg4, int jarg5, [MarshalAs(UnmanagedType.U1)] bool jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Cancel", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Cancel(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_CancelAll", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CancelAll(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ImageLoadedSignalConnect(IntPtr asyncImageLoader, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ImageLoadedSignalDisconnect(IntPtr asyncImageLoader, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_PixelBufferLoadedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PixelBufferLoadedSignalConnect(IntPtr asyncImageLoader, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_PixelBufferLoadedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PixelBufferLoadedSignalDisconnect(IntPtr asyncImageLoader, IntPtr handler);
        }
    }
}





