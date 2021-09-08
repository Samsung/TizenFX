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
        internal static partial class SlideTransitionDirection
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SlideTransitionDirectionTop_get")]
            public static extern global::System.IntPtr SlideTransitionDirectionTopGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SlideTransitionDirectionBottom_get")]
            public static extern global::System.IntPtr SlideTransitionDirectionBottomGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SlideTransitionDirectionRight_get")]
            public static extern global::System.IntPtr SlideTransitionDirectionRightGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SlideTransitionDirectionLeft_get")]
            public static extern global::System.IntPtr SlideTransitionDirectionLeftGet();
        }
    }
}
