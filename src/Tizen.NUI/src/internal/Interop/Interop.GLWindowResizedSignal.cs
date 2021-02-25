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

using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLWindowResizedSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Empty")]
            public static extern bool GlWindowResizedSignalEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_GetConnectionCount")]
            public static extern uint GlWindowResizedSignalGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Connect")]
            public static extern void GlWindowResizedSignalConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Disconnect")]
            public static extern void GlWindowResizedSignalDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Emit")]
            public static extern void GlWindowResizedSignalEmit(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_ResizedSignal")]
            public static extern global::System.IntPtr NewGlWindowResizedSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_delete_ResizedSignal")]
            public static extern void GlWindowDeleteResizedSignal(HandleRef jarg1);
        }
    }
}
