/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        internal static class RenderEffect
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Activate")]
            public static extern void Activate(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Deactivate")]
            public static extern void Deactivate(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Refresh")]
            public static extern void Refresh(HandleRef effect);
        }
    }
}
