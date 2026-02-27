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
        internal static partial class ActorInternal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsRoot", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsRoot(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetChildAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetChildAt(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetParentOrigin", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetParentOrigin(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSize__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSize(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSize__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSize(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSize__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSizeVector2(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSize__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSizeVector3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetPosition__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPosition(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetPosition__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPosition(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetPosition__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPosition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetX", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetX(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetY", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetY(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetZ", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetZ(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_TranslateBy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TranslateBy(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetInheritPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInheritPosition(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsPositionInherited", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPositionInherited(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetOrientation__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOrientationDegree(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetOrientation__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOrientationRadian(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetOrientation__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOrientationQuaternion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RotateBy__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotateByDegree(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RotateBy__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotateByRadian(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RotateBy__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotateByQuaternion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentOrientation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetInheritOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInheritOrientation(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsOrientationInherited", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsOrientationInherited(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentWorldOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentWorldOrientation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetScale__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScale(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetScale__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScale(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetScale__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScale(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_ScaleBy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScaleBy(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_LookAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LookAt(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetInheritScale", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInheritScale(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsScaleInherited", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsScaleInherited(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentWorldMatrix", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentWorldMatrix(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsVisible", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsVisible(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetOpacity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOpacity(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentOpacity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetCurrentOpacity(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetColorMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetColorMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetColorMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetColorMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetDrawMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDrawMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetDrawMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDrawMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetKeyboardFocusable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetKeyboardFocusable(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsKeyboardFocusable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsKeyboardFocusable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetKeyboardFocusableChildren", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetKeyboardFocusableChildren(IntPtr manager, [MarshalAs(UnmanagedType.U1)] bool focusable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_AreChildrenKeyBoardFocusable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AreChildrenKeyBoardFocusable(IntPtr manager);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetTouchFocusable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFocusableInTouch(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsTouchFocusable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFocusableInTouch(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetMinimumSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMinimumSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetMaximumSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaximumSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_DevelActor_Property_SetTouchAreaOffset", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTouchAreaOffset(IntPtr jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_DevelActor_Property_GetTouchAreaOffset", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetTouchAreaOffset(IntPtr jarg1, out int jarg2, out int jarg3, out int jarg4, out int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RetrieveTargetSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RetrieveTargetSize(IntPtr actor, IntPtr retrievingVector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RetrieveCurrentPropertyVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RetrieveCurrentPropertyVector3(IntPtr actor, int propertyType, IntPtr retrievingVector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RetrieveCurrentPropertyVector2ActualVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RetrieveCurrentPropertyVector2ActualVector3(IntPtr actor, int propertyType, IntPtr retrievingVector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RetrieveCurrentPropertyVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RetrieveCurrentPropertyVector4(IntPtr actor, int propertyType, IntPtr retrievingVector4);
        }
    }
}





