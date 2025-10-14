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

namespace Tizen.NUI.ParticleSystem
{
    internal static partial class Interop
    {
        internal static partial class ParticleEmitter
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ParticleEmitter")]
            internal static extern void DeleteParticleEmitter(global::System.Runtime.InteropServices.HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_New_SWIG_0")]
            internal static extern global::System.IntPtr New(HandleRef view);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Assign")]
            internal static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetSource")]
            internal static extern void SetSource(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetDomain")]
            internal static extern void SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetRenderer")]
            internal static extern void SetRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_AddModifier")]
            internal static extern void AddModifier(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetParticleCount")]
            internal static extern void SetParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetParticleCount")]
            internal static extern uint GetParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetEmissionRate")]
            internal static extern void SetEmissionRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetInitialParticleCount")]
            internal static extern void SetInitialParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetActiveParticlesLimit")]
            internal static extern void SetActiveParticlesLimit(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Start")]
            internal static extern void Start(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Stop")]
            internal static extern void Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_RemoveModifierAt")]
            internal static extern void RemoveModifierAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetParticleList")]
            internal static extern global::System.IntPtr GetParticleList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetSource")]
            internal static extern global::System.IntPtr GetSource(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetDomain")]
            internal static extern global::System.IntPtr GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetRenderer")]
            internal static extern global::System.IntPtr GetRenderer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetEmissionRate")]
            internal static extern uint GetEmissionRate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetInitialParticleCount")]
            internal static extern uint GetInitialParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetActiveParticleLimit")]
            internal static extern uint GetActiveParticleLimit(global::System.Runtime.InteropServices.HandleRef jarg1);

            // ParticleRenderer
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_SetTexture")]
            internal static extern void SetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_SetBlendingMode")]
            internal static extern void SetBlendingMode(global::System.Runtime.InteropServices.HandleRef jarg1, ParticleBlendingMode mode);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleRenderer_GetBlendingMode")]
            internal static extern int GetBlendingMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_NewParticle")]
            internal static extern int NewParticle(global::System.IntPtr emitter, float lifetime);

            // ParticleList
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamInt")]
            internal static extern uint AddLocalStreamInt(global::System.Runtime.InteropServices.HandleRef jarg1, int defaultValue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamFloat")]
            internal static extern uint AddLocalStreamFloat(global::System.Runtime.InteropServices.HandleRef jarg1, float defaultValue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector2")]
            internal static extern uint AddLocalStreamVector2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr defaultValue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector3")]
            internal static extern uint AddLocalStreamVector3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr defaultValue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStreamVector4")]
            internal static extern uint AddLocalStreamVector4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr defaultValue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_GetDefaultStreamIndex")]
            internal static extern int GetDefaultStreamIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint builtInStream );

        }
    }
}

