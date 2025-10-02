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

using System;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI.ParticleSystem
{
    internal static partial class Interop
    {
        internal static partial class Particle
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadFloat")]
            internal static extern float ReadFloat(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector2")]
            internal static extern global::System.IntPtr ReadVector2(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector3")]
            internal static extern global::System.IntPtr ReadVector3(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector4")]
            internal static extern global::System.IntPtr ReadVector4(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteFloat")]
            internal static extern void WriteFloat(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex, float value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector2")]
            internal static extern void WriteVector2(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex, HandleRef value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector3")]
            internal static extern void WriteVector3(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex, HandleRef value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector4")]
            internal static extern void WriteVector4(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamIndex, uint particleIndex, HandleRef value);
        }
    }
}

