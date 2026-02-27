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
        internal static partial class Gradient
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_SetColorStops", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetColorStops(IntPtr gradient, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] stops, uint stopsLength);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetColorStopsCount(IntPtr gradient);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsOffsetIndexOf", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetColorStopsOffsetIndexOf(IntPtr gradient, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsColorIndexOf", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetColorStopsColorIndexOf(IntPtr gradient, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_SetSpread", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSpread(IntPtr gradient, int index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetSpread", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetSpread(IntPtr gradient);
        }
    }
}





