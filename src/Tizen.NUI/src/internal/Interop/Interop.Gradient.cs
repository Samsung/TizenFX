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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Gradient
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_SetColorStops")]
            public static extern void SetColorStops(global::System.Runtime.InteropServices.HandleRef gradient, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] stops, uint stopsLength);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsCount")]
            public static extern uint GetColorStopsCount(global::System.Runtime.InteropServices.HandleRef gradient);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsOffsetIndexOf")]
            public static extern float GetColorStopsOffsetIndexOf(global::System.Runtime.InteropServices.HandleRef gradient, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetColorStopsColorIndexOf")]
            public static extern global::System.IntPtr GetColorStopsColorIndexOf(global::System.Runtime.InteropServices.HandleRef gradient, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_SetSpread")]
            public static extern void SetSpread(global::System.Runtime.InteropServices.HandleRef gradient, int index);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Gradient_GetSpread")]
            public static extern int GetSpread(global::System.Runtime.InteropServices.HandleRef gradient);
        }
    }
}
