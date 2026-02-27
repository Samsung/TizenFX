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
        internal static partial class DaliException
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DaliException", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewDaliException(string jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LocationSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string LocationGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ConditionSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string ConditionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DaliException", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteDaliException(IntPtr jarg1);
        }
    }
}





