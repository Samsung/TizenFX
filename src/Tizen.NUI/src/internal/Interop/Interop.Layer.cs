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
        internal static partial class Layer
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_Property_BEHAVIOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BehaviorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Layer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteLayer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_RaiseToTop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RaiseToTop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_LowerToBottom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LowerToBottom(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_MoveAbove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MoveAbove(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_MoveBelow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MoveBelow(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_SetBehavior", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBehavior(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_GetBehavior", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBehavior(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_SetClipping", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClipping(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_SetClippingBox__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClippingBox(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_SetTouchConsumed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTouchConsumed(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_IsTouchConsumed", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTouchConsumed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_SetHoverConsumed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetHoverConsumed(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Layer_IsHoverConsumed", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsHoverConsumed(IntPtr jarg1);
        }
    }
}





