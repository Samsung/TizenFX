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
        internal static partial class VisualBase
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VisualBase__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVisualBase();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VisualBase", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVisualBase(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VisualBase__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVisualBase(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_SetName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_GetName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_SetTransformAndSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTransformAndSize(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_GetHeightForWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetHeightForWidth(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_GetWidthForHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetWidthForHeight(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_GetNaturalSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetNaturalSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_SetDepthIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDepthIndex(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_GetDepthIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDepthIndex(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualBase_CreatePropertyMap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CreatePropertyMap(IntPtr jarg1, IntPtr jarg2);
        }
    }
}





