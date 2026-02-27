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
        internal static partial class ParticleEmitter
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ParticleEmitter", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void DeleteParticleEmitter(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_New_SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr New(IntPtr view);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Assign", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetSource", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetSource(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetDomain", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetDomain(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetRenderer", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetRenderer(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_AddModifier", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void AddModifier(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetParticleCount", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetParticleCount(IntPtr jarg1, uint count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetParticleCount", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint GetParticleCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetEmissionRate", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetEmissionRate(IntPtr jarg1, uint count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetInitialParticleCount", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetInitialParticleCount(IntPtr jarg1, uint count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetActiveParticlesLimit", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetActiveParticlesLimit(IntPtr jarg1, uint count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Start", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void Start(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Stop", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void Stop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_RemoveModifierAt", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void RemoveModifierAt(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetParticleList", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr GetParticleList(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetSource", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr GetSource(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetDomain", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr GetDomain(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetRenderer", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern global::System.IntPtr GetRenderer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetEmissionRate", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint GetEmissionRate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetInitialParticleCount", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint GetInitialParticleCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetActiveParticleLimit", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint GetActiveParticleLimit(IntPtr jarg1);

            // ParticleRenderer
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_SetTexture", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetTexture(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_SetBlendingMode", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern void SetBlendingMode(IntPtr jarg1, ParticleBlendingMode mode);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_GetBlendingMode", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern int GetBlendingMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_NewParticle", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern int NewParticle(global::System.IntPtr emitter, float lifetime);

            // ParticleList
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamInt", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint AddLocalStreamInt(IntPtr jarg1, int defaultValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamFloat", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint AddLocalStreamFloat(IntPtr jarg1, float defaultValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector2", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint AddLocalStreamVector2(IntPtr jarg1, global::System.IntPtr defaultValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector3", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint AddLocalStreamVector3(IntPtr jarg1, global::System.IntPtr defaultValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector4", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern uint AddLocalStreamVector4(IntPtr jarg1, global::System.IntPtr defaultValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_GetDefaultStreamIndex", StringMarshalling = StringMarshalling.Utf8)]
            internal static extern int GetDefaultStreamIndex(IntPtr jarg1, uint builtInStream );

        }
    }
}






