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
        internal static partial class PropertyInputContainer
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPropertyType(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetBoolean", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetBoolean(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetFloat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFloat(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetInteger", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetInteger(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector2_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetVector2Componentwise(IntPtr jarg1, uint index, out float x, out float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector3_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetVector3Componentwise(IntPtr jarg1, uint index, out float x, out float y, out float z);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector4_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetVector4Componentwise(IntPtr jarg1, uint index, out float x, out float y, out float z, out float w);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetMatrix3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetMatrix3(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetMatrix", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetMatrix(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetQuaternion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRotation(IntPtr jarg1, uint index);
        }
    }
}





