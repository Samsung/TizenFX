/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

using global::System.Runtime.InteropServices;
using System.Reflection;
using System;

namespace Tizen.NUI.ParticleSystem
{
    internal static partial class Interop
    {
        internal static partial class ParticleModifier
        {
            internal delegate void ParticleModifierUpdateInvokerType(IntPtr ptr, IntPtr particleListPtr, uint first, uint count);
            
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleModifier_New_SWIG_0")]
            public static extern global::System.IntPtr New(ParticleModifierUpdateInvokerType updateInvoker, out IntPtr basePtr);
        }
    }
}