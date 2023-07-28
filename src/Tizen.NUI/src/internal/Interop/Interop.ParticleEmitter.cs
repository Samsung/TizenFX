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
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_New_SWIG_0")]
            public static extern global::System.IntPtr New(HandleRef view);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ParticleEmitter")]
            public static extern void DeleteParticleEmitter(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetSource")]
            public static extern void SetSource(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetDomain")]
            public static extern void SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
  
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetRenderer")]
            public static extern void SetRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_AddModifier")]
            public static extern void AddModifier(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetParticleCount")]
            public static extern void SetParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetEmissionRate")]
            public static extern void SetEmissionRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetInitialParticleCount")]
            public static extern void SetInitialParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_SetActiveParticlesLimit")]
            public static extern void SetActiveParticlesLimit(global::System.Runtime.InteropServices.HandleRef jarg1, uint count);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Start")]
            public static extern void Start(global::System.Runtime.InteropServices.HandleRef jarg1);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_Stop")]
            public static extern void Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_RemoveModifierAt")]
            public static extern void RemoveModifierAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetModifierAt")]
            public static extern global::System.IntPtr GetModifierAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetParticleList")]
            public static extern global::System.IntPtr GetParticleList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetSource")]
            public static extern global::System.IntPtr GetSource(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetDomain")]
            public static extern global::System.IntPtr GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetRenderer")]
            public static extern global::System.IntPtr GetRenderer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetEmissionRate")]
            public static extern uint GetEmissionRate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetInitialParticleCount")]
            public static extern uint GetInitialParticleCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleEmitter_GetActiveParticleLimit")]
            public static extern uint GetActiveParticleLimit(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}  

