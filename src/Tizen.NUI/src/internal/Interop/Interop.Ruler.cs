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
        internal static partial class Ruler
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerDomain__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRulerDomain(float jarg1, float jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerDomain__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRulerDomain(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_min_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerDomainMinSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_min_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainMinGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_max_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerDomainMaxSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_max_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainMaxGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_enabled_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerDomainEnabledSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_enabled_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RulerDomainEnabledGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainClamp(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainClamp(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_GetSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerDomainGetSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RulerDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRulerDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Snap__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Snap(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Snap__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Snap(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetPositionFromPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetPositionFromPage(IntPtr jarg1, uint jarg2, out uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetPageFromPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetPageFromPosition(IntPtr jarg1, float jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetTotalPages", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTotalPages(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_IsEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Enable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Enable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Disable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Disable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SetDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDomain(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_DisableDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DisableDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Clamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Clamp(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Clamp(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Clamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapAndClamp(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapAndClamp(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5, IntPtr jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DefaultRuler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewDefaultRuler();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_Snap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float DefaultRulerSnap(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetPositionFromPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float DefaultRulerGetPositionFromPage(IntPtr jarg1, uint jarg2, out uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetPageFromPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint DefaultRulerGetPageFromPosition(IntPtr jarg1, float jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetTotalPages", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint DefaultRulerGetTotalPages(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DefaultRuler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteDefaultRuler(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FixedRuler__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFixedRuler(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FixedRuler__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFixedRuler();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_Snap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FixedRulerSnap(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetPositionFromPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float FixedRulerGetPositionFromPage(IntPtr jarg1, uint jarg2, out uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetPageFromPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FixedRulerGetPageFromPosition(IntPtr jarg1, float jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetTotalPages", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint FixedRulerGetTotalPages(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FixedRuler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFixedRuler(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRulerPtr();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRulerPtr(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRulerPtrPtr(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RulerPtr", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRulerPtr(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr___deref__", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrDeref(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr___ref__", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrRef(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Assign__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AssignPtr(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Assign__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reset__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrReset(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reset__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrReset(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Detach", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrDetach(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Snap__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnap(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Snap__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnap(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetPositionFromPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrGetPositionFromPage(IntPtr jarg1, uint jarg2, out uint jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetPageFromPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint RulerPtrGetPageFromPosition(IntPtr jarg1, float jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetTotalPages", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint RulerPtrGetTotalPages(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RulerPtrGetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_IsEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RulerPtrIsEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Enable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrEnable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Disable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrDisable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SetDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrSetDomain(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RulerPtrGetDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_DisableDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrDisableDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrClamp(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrClamp(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnapAndClamp(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnapAndClamp(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RulerPtrSnapAndClamp(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5, IntPtr jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reference", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrReference(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Unreference", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RulerPtrUnreference(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_ReferenceCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RulerPtrReferenceCount(IntPtr jarg1);
        }
    }
}





