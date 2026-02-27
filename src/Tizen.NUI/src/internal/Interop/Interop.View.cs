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
        internal static partial class View
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_NewWithBehaviour", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWithBehaviour(int behaviour);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_View", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_View", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteControlHandleView(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_DownCast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DownCast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_HasKeyInputFocus", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool HasKeyInputFocus(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_SetStyleName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStyleName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetStyleName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetStyleName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ClearBackground", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearBackground(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_SetRenderEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRenderEffect(IntPtr self, IntPtr effectRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetRenderEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRenderEffect(IntPtr self);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetOffScreenRenderingOutput", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetOffScreenRenderingOutput(IntPtr self);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ClearRenderEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearRenderEffect(IntPtr self);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_View__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewViewInternal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetVisualResourceStatus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetVisualResourceStatus(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_CreateTransition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateTransition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_DoAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoAction(IntPtr jarg1, int jarg2, int jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetVisualProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetVisualProperty(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsResourceReady", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsResourceReady(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ResourceReadySignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ResourceReadySignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_GetVisualResourceStatus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int View_GetVisualResourceStatus(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_DoActionExtension", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoActionExtension(IntPtr control, int visualIndex, int actionId, int id, string keyPath, int property, global::System.IntPtr callback);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_DoActionWithEmptyAttributes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoActionWithEmptyAttributes(IntPtr control, int visualIndex, int actionId);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_DoActionWithSingleIntAttributes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DoActionWithSingleIntAttributes(IntPtr control, int visualIndex, int actionId, int actionValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyBool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyBool(IntPtr control, int visualIndex, int visualPropertyIndex, [MarshalAs(UnmanagedType.U1)] bool valBool);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyFloat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyFloat(IntPtr control, int visualIndex, int visualPropertyIndex, float valFloat);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyInt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyInt(IntPtr control, int visualIndex, int visualPropertyIndex, int valInt);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyIntPair", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyIntPair(IntPtr control, int visualIndex, int visualPropertyIndex, int valInt1, int valInt2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyString", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyString(IntPtr control, int visualIndex, int visualPropertyIndex, string valString);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyStringPair", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyStringPair(IntPtr control, int visualIndex, int visualPropertyIndex, string valString1, string valString2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_InternalUpdateVisualPropertyVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalUpdateVisualPropertyVector4(IntPtr control, int visualIndex, int visualPropertyIndex, IntPtr vector4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingVisualPropertyInt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingVisualPropertyInt(IntPtr actor,  int visualIndex, int visualPropertyIndex, out int valInt);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingVisualPropertyString", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingVisualPropertyString(IntPtr actor,  int visualIndex, int visualPropertyIndex, out string valString);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingVisualPropertyVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingVisualPropertyVector4(IntPtr actor,  int visualIndex, int visualPropertyIndex, IntPtr retrievingVector4);
        }
    }
}





