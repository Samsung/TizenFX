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
        internal static partial class WindowInternal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeHandle")]
            public static extern IntPtr WindowGetNativeHandle(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddFrameRenderedCallback")]
            public static extern void AddFrameRenderedCallback(HandleRef nuiWindow, HandleRef nuiCallbakc, int nuiFrameId);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddFramePresentedCallback")]
            public static extern void AddFramePresentedCallback(HandleRef nuiWindow, HandleRef nuiCallbakc, int nuiFrameId);
        }
    }
}
