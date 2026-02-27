/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using global::System.Collections.Generic;
using global::System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class DoGestureSignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Signal_GesturePairToVoid_GetSizeOfGestureInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetSizeOfGestureInfo();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Signal_GesturePairToVoid_GetResult", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetResult(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Signal_GesturePairToVoid_SetResult", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetResult(global::System.IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool result);
        }
    }
}





