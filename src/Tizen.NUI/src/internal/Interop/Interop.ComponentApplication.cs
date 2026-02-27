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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;
using global::System.Collections.Generic;
using global::System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ComponentApplication
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ComponentApplication", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int argc, string argv, string styleSheet);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ComponentApplication_SWIG1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewComponentApplication(IntPtr swigCPtr);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_assign_ComponentApplication", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr swigCPtr, IntPtr swigCPtr2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ComponentApplication", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DeleteComponentApplication(IntPtr swigCPtr);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateNativeSignal(IntPtr swigCPtr);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateNativeSignalConnect(IntPtr swigCPtr, IntPtr func);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ComponentApplication_CreateNativeSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateNativeSignalDisconnect(IntPtr swigCPtr, IntPtr func);
        }
    }
}





