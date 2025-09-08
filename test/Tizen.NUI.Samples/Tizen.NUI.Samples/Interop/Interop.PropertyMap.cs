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


namespace Tizen.NUI.Samples
{
    internal static partial class Interop
    {

        internal static partial class PropertyMap
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Int__SWIG_0")]
            public static extern void Insert(global::System.IntPtr jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Bool__SWIG_0")]
            public static extern void Insert(global::System.IntPtr jarg1, string jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Float__SWIG_0")]
            public static extern void Insert(global::System.IntPtr jarg1, string jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Vector2__SWIG_0")]
            public static extern void Insert(global::System.IntPtr jarg1, string jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Int__SWIG_2")]
            public static extern void Insert(global::System.IntPtr jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Bool__SWIG_2")]
            public static extern void Insert(global::System.IntPtr jarg1, int jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_Insert_Float__SWIG_2")]
            public static extern void Insert(global::System.IntPtr jarg1, int jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_StringKey_IntValue")]
            public static extern void SetValueStringKey(global::System.IntPtr jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_StringKey_BoolValue")]
            public static extern void SetValueStringKey(global::System.IntPtr jarg1, string jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_StringKey_Vector2")]
            public static extern void SetValueStringKey(global::System.IntPtr jarg1, string jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_IntKey_IntValue")]
            public static extern void SetValueIntKey(global::System.IntPtr jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Property_Map_SetValue_IntKey_BoolValue")]
            public static extern void SetValueIntKey(global::System.IntPtr jarg1, int jarg2, bool jarg3);
        }
    }
}
