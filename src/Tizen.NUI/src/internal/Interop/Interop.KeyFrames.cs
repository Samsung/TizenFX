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
        internal static partial class KeyFrames
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyFrames", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteKeyFrames(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_GetKeyFrameCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetKeyFrameCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_GetKeyFrame", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetKeyFrame(IntPtr jarg1, uint index, out float time, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_SetKeyFrameValue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetKeyFrameValue(IntPtr jarg1, uint index, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_Add__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Add(IntPtr jarg1, float jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyFrames_Add__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Add(IntPtr jarg1, float jarg2, IntPtr jarg3, IntPtr jarg4);
        }
    }
}





