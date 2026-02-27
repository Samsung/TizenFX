/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
        internal static partial class VisualObjectsContainer
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_ContainerRangeTypeBackgroundEffectGet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContainerRangeTypeBackgroundEffectGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_ContainerRangeTypeBackgroundGet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContainerRangeTypeBackgroundGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_ContainerRangeTypeContentGet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContainerRangeTypeContentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_ContainerRangeTypeDecorationGet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContainerRangeTypeDecorationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_ContainerRangeTypeForegroundEffectGet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContainerRangeTypeForegroundEffectGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VisualObjectsContainer__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVisualObjectsContainer();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr VisualObjectsContainerNew(IntPtr view, int rangeType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_GetOwner", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetOwner(IntPtr container);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_GetContainerRangeType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetContainerRangeType(IntPtr container);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_GetVisualObjectsCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetVisualObjectsCount(IntPtr container);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_GetVisualObjectAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetVisualObjectAt(IntPtr container, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_AddVisualObject", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddVisualObject(IntPtr container, IntPtr viewObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_AddShadowVisualObject", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddShadowVisualObject(IntPtr container, IntPtr viewObject, int shadowType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObjectsContainer_RemoveVisualObject", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveVisualObject(IntPtr container, IntPtr viewObject);
        }
    }
}





