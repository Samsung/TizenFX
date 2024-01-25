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
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class ScaleTransitionItem
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScaleTransition")]
            public static extern IntPtr NewEmpty();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_New_1")]
            public static extern IntPtr New(HandleRef view, float scale, HandleRef timePeriod);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_New_2")]
            public static extern IntPtr New(HandleRef view, HandleRef scale, HandleRef timePeriod);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScaleTransition")]
            public static extern void Delete(HandleRef scaleTransition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScaleTransition_Set")]
            public static extern IntPtr NewScaleTransitionItem(HandleRef scaleTransition);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScaleTransition_Assign")]
            public static extern IntPtr Assign(HandleRef destination, HandleRef source);
        }
    }
}
