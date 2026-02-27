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
        internal static partial class AlphaFunction
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunction();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_BuiltInFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunction(int builtInFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_CustomAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunction(IntPtr alphaFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_Bezier", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunction(IntPtr controlPoint0, IntPtr controlPoint1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_BuiltInSpring", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunctionSpringType(int springType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_CustomSpring", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAlphaFunctionSpringData(float stiffness, float damping, float mass);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBezierControlPoints", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBezierControlPoints(IntPtr alphaFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBuiltinFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBuiltinFunction(IntPtr alphaFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetMode(IntPtr alphaFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAlphaFunction(IntPtr jarg1);
        }
    }
}





