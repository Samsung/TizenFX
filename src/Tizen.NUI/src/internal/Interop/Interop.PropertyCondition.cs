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
        internal static partial class PropertyCondition
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyCondition__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyCondition();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PropertyCondition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePropertyCondition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_GetArgumentCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetArgumentCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_GetArgument", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetArgument(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LessThanCondition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr LessThanCondition(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GreaterThanCondition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GreaterThanCondition(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InsideCondition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr InsideCondition(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_OutsideCondition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr OutsideCondition(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StepCondition__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr StepCondition(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StepCondition__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr StepCondition(float jarg1);
        }
    }
}





