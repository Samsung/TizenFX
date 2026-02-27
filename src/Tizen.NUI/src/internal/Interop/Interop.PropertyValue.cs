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
        internal static partial class PropertyValue
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValue();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValue([MarshalAs(UnmanagedType.U1)] bool jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValue(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValue(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector2(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector4(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_7", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueMatrix3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_8", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueMatrix(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_9", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueRect(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_10", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueAngleAxis(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_11", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueQuaternion(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_12", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueString(string jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_14", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueArray(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_15", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueMap(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_16", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueExtents(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_17", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueType(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value__SWIG_18", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueValue(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool NotEqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Property_Value", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePropertyValue(IntPtr jarg1);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Property_Value", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePropertyValueIntPtr(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PropertyValueGetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGet(IntPtr jarg1, out bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGet(IntPtr jarg1, out float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGet(IntPtr jarg1, out int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetRect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetVector2(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetVector3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_7", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetVector4(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_8", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetMatrix3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_9", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetMatrix(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_10", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetAngleAxis(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_11", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetQuaternion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_12", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetString(IntPtr jarg1, out string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_13", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetArray(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_14", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetMap(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get__SWIG_15", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetExtents(IntPtr jarg1, IntPtr jarg2);

            // For internal managed memory optimization
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value_Vector2_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector2Componentwise(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value_Vector3_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector3Componentwise(float jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Value_Vector4_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyValueVector4Componentwise(float jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get_Vector2_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGetVector2Componentwise(IntPtr jarg1, out float jarg2, out float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get_Vector3_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGetVector3Componentwise(IntPtr jarg1, out float jarg2, out float jarg3, out float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Get_Vector4_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PropertyValueGetVector4Componentwise(IntPtr jarg1, out float jarg2, out float jarg3, out float jarg4, out float jarg5);

            // Internal Assign API
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBoolean(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFloat(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInteger(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector2(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_7", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector4(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_8", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMatrix3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_9", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMatrix(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_10", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_11", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAngleAxis(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_12", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetQuaternion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_13", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetString(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_14", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetArray(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_15", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMap(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set__SWIG_16", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetExtents(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set_Vector2_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PropertyValueSetVector2Componentwise(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set_Vector3_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PropertyValueSetVector3Componentwise(IntPtr jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Value_Set_Vector4_Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PropertyValueSetVector4Componentwise(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5);
        }
    }
}





