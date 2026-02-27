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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static class RenderEffect
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Activate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Activate(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Deactivate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Deactivate(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_Refresh", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Refresh(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderEffect_IsActivated", StringMarshalling = StringMarshalling.Utf8)]
            public static partial bool IsActivated(IntPtr effect);
        }
    }
}



