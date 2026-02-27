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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI.ParticleSystem
{
    internal static partial class Interop
    {
        internal static partial class Particle
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadFloat", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern float ReadFloat(IntPtr jarg1, uint streamIndex, uint particleIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector2", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr ReadVector2(IntPtr jarg1, uint streamIndex, uint particleIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector3", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr ReadVector3(IntPtr jarg1, uint streamIndex, uint particleIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_ReadVector4", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr ReadVector4(IntPtr jarg1, uint streamIndex, uint particleIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteFloat", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void WriteFloat(IntPtr jarg1, uint streamIndex, uint particleIndex, float value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector2", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void WriteVector2(IntPtr jarg1, uint streamIndex, uint particleIndex, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector3", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void WriteVector3(IntPtr jarg1, uint streamIndex, uint particleIndex, IntPtr value);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Particle_WriteVector4", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void WriteVector4(IntPtr jarg1, uint streamIndex, uint particleIndex, IntPtr value);
        }
    }
}






