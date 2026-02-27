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
        internal static partial class PropertyMap
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Map__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyMap();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Map__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyMap(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Property_Map", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePropertyMap(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Count", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint Count(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Empty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Add(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Add(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Remove__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Remove(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Remove__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Remove(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_GetValue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetValue(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_GetKeyAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetKeyAt(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Find(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Find(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Find(IntPtr jarg1, int jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Clear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clear(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Merge", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Merge(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ValueOfIndex(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_ValueOfIndex__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ValueOfIndex(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_StringKey", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetValueStringKey(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_IntKey", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetValueIntKey(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_None", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddNone(IntPtr propertyMap, int key);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_None", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddNone(IntPtr propertyMap, string key);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_None", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetNone(IntPtr propertyMap, int key);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_None", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetNone(IntPtr propertyMap, string key);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Bool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddBool(IntPtr propertyMap, int key, [MarshalAs(UnmanagedType.U1)] bool value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Bool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddBool(IntPtr propertyMap, string key, [MarshalAs(UnmanagedType.U1)] bool value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Bool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetBool(IntPtr propertyMap, int key, [MarshalAs(UnmanagedType.U1)] bool value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Bool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetBool(IntPtr propertyMap, string key, [MarshalAs(UnmanagedType.U1)] bool value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Int", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddInt(IntPtr propertyMap, int key, int value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Int", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddInt(IntPtr propertyMap, string key, int value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Int", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetInt(IntPtr propertyMap, int key, int value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Int", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetInt(IntPtr propertyMap, string key, int value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddFloat(IntPtr propertyMap, int key, float value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddFloat(IntPtr propertyMap, string key, float value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetFloat(IntPtr propertyMap, int key, float value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetFloat(IntPtr propertyMap, string key, float value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Str", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddString(IntPtr propertyMap, int key, string value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Str", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddString(IntPtr propertyMap, string key, string value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Str", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetString(IntPtr propertyMap, int key, string value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Str", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetString(IntPtr propertyMap, string key, string value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector2(IntPtr propertyMap, int key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Vector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector2(IntPtr propertyMap, string key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_NVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector2(IntPtr propertyMap, int key, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_NVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector2(IntPtr propertyMap, string key, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_NVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetVector2(IntPtr propertyMap, int key, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_NVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetVector2(IntPtr propertyMap, string key, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector3(IntPtr propertyMap, int key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector4(IntPtr propertyMap, int key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_NVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector4(IntPtr propertyMap, int key, float x, float y, float z, float w);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_NVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddVector4(IntPtr propertyMap, string key, float x, float y, float z, float w);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_NVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetVector4(IntPtr propertyMap, int key, float x, float y, float z, float w);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_NVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetVector4(IntPtr propertyMap, string key, float x, float y, float z, float w);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Rectangle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddRectangle(IntPtr propertyMap, int key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Rectangle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr SetRectangle(IntPtr propertyMap, int key, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Map", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AddPropertyMap(IntPtr propertyMap, int key, IntPtr value);
        }
    }
}





