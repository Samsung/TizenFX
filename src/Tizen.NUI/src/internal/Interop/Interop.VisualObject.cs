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
        internal static partial class VisualObject
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr VisualObjectNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_GetContainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetContainer(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_CreateVisual", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CreateVisual(IntPtr visualObject, IntPtr propertyMap);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RetrieveVisualPropertyMap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RetrieveVisualPropertyMap(IntPtr visualObject, IntPtr propertyMap);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoAction_UpdatePropertyMap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UpdateVisualPropertyMap(IntPtr visualObject, IntPtr propertyMap);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoActionWithEmptyAttributes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoActionWithEmptyAttributes(IntPtr visualObject, int actionId);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoActionWithSingleIntAttributes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoActionWithSingleIntAttributes(IntPtr visualObject, int actionId, int actionValue);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_SetSiblingOrder", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSiblingOrder(IntPtr visualObject, uint siblingOrder);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_GetSiblingOrder", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetSiblingOrder(IntPtr visualObject);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DetachFromContainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Detach(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_Raise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Raise(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_Lower", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Lower(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RaiseToTop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RaiseToTop(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_LowerToBottom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LowerToBottom(IntPtr visualObject);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RaiseAbove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RaiseAbove(IntPtr visualObject, IntPtr target);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_LowerBelow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LowerBelow(IntPtr visualObject, IntPtr target);
        }
    }
}





