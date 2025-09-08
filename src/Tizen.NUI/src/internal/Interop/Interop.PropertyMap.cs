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
using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PropertyMap
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Map__SWIG_0")]
            public static extern global::System.IntPtr NewPropertyMap();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Property_Map__SWIG_1")]
            public static extern global::System.IntPtr NewPropertyMap(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Property_Map")]
            public static extern void DeletePropertyMap(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Count")]
            public static extern uint Count(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Empty")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert__SWIG_0")]
            public static extern void Insert(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert__SWIG_2")]
            public static extern void Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add__SWIG_0")]
            public static extern global::System.IntPtr Add(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add__SWIG_2")]
            public static extern global::System.IntPtr Add(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Remove__SWIG_0")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool Remove(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Remove__SWIG_1")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool Remove(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_GetValue")]
            public static extern global::System.IntPtr GetValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_GetKeyAt")]
            public static extern global::System.IntPtr GetKeyAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_0")]
            public static extern global::System.IntPtr Find(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_2")]
            public static extern global::System.IntPtr Find(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Find__SWIG_3")]
            public static extern global::System.IntPtr Find(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Clear")]
            public static extern void Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Merge")]
            public static extern void Merge(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_ValueOfIndex__SWIG_0")]
            public static extern global::System.IntPtr ValueOfIndex(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_ValueOfIndex__SWIG_2")]
            public static extern global::System.IntPtr ValueOfIndex(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_StringKey")]
            public static extern void SetValueStringKey(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_IntKey")]
            public static extern void SetValueIntKey(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_None")]
            public static extern IntPtr AddNone(HandleRef propertyMap, int key);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_None")]
            public static extern IntPtr AddNone(HandleRef propertyMap, string key);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_None")]
            public static extern IntPtr SetNone(HandleRef propertyMap, int key);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_None")]
            public static extern IntPtr SetNone(HandleRef propertyMap, string key);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Bool")]
            public static extern IntPtr AddBool(HandleRef propertyMap, int key, bool value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Bool")]
            public static extern IntPtr AddBool(HandleRef propertyMap, string key, bool value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Bool")]
            public static extern IntPtr SetBool(HandleRef propertyMap, int key, bool value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Bool")]
            public static extern IntPtr SetBool(HandleRef propertyMap, string key, bool value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Int")]
            public static extern IntPtr AddInt(HandleRef propertyMap, int key, int value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Int")]
            public static extern IntPtr AddInt(HandleRef propertyMap, string key, int value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Int")]
            public static extern IntPtr SetInt(HandleRef propertyMap, int key, int value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Int")]
            public static extern IntPtr SetInt(HandleRef propertyMap, string key, int value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Float")]
            public static extern IntPtr AddFloat(HandleRef propertyMap, int key, float value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Float")]
            public static extern IntPtr AddFloat(HandleRef propertyMap, string key, float value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Float")]
            public static extern IntPtr SetFloat(HandleRef propertyMap, int key, float value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Float")]
            public static extern IntPtr SetFloat(HandleRef propertyMap, string key, float value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Str")]
            public static extern IntPtr AddString(HandleRef propertyMap, int key, string value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Str")]
            public static extern IntPtr AddString(HandleRef propertyMap, string key, string value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Str")]
            public static extern IntPtr SetString(HandleRef propertyMap, int key, string value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_Str")]
            public static extern IntPtr SetString(HandleRef propertyMap, string key, string value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector2")]
            public static extern IntPtr AddVector2(HandleRef propertyMap, int key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_Vector2")]
            public static extern IntPtr AddVector2(HandleRef propertyMap, string key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_NVector2")]
            public static extern IntPtr AddVector2(HandleRef propertyMap, int key, float x, float y);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_NVector2")]
            public static extern IntPtr AddVector2(HandleRef propertyMap, string key, float x, float y);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_NVector2")]
            public static extern IntPtr SetVector2(HandleRef propertyMap, int key, float x, float y);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_NVector2")]
            public static extern IntPtr SetVector2(HandleRef propertyMap, string key, float x, float y);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector3")]
            public static extern IntPtr AddVector3(HandleRef propertyMap, int key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Vector4")]
            public static extern IntPtr AddVector4(HandleRef propertyMap, int key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_NVector4")]
            public static extern IntPtr AddVector4(HandleRef propertyMap, int key, float x, float y, float z, float w);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Str_NVector4")]
            public static extern IntPtr AddVector4(HandleRef propertyMap, string key, float x, float y, float z, float w);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_NVector4")]
            public static extern IntPtr SetVector4(HandleRef propertyMap, int key, float x, float y, float z, float w);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Str_NVector4")]
            public static extern IntPtr SetVector4(HandleRef propertyMap, string key, float x, float y, float z, float w);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Rectangle")]
            public static extern IntPtr AddRectangle(HandleRef propertyMap, int key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Set_Int_Rectangle")]
            public static extern IntPtr SetRectangle(HandleRef propertyMap, int key, HandleRef value);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Add_Int_Map")]
            public static extern IntPtr AddPropertyMap(HandleRef propertyMap, int key, HandleRef value);
        }
    }
}
