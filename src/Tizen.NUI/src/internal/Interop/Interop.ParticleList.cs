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
        internal static partial class ParticleList
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_New_SWIG_0")]
            internal static extern global::System.IntPtr New(HandleRef emitter);
            
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ParticleList_SWIG_1")]
            public static extern global::System.IntPtr Copy(HandleRef handle);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ParticleList")]
            public static extern void DeleteParticleList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);
            
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_AddLocalStream")]
            public unsafe static extern uint AddLocalStream(global::System.Runtime.InteropServices.HandleRef jarg1, uint streamType, void* defaultValue, uint typeSize );

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_GetDefaultStreamIndex")]
            public unsafe static extern int GetDefaultStreamIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint builtInStream );

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ParticleList_GetParticle")]
            public static extern uint GetParticle(global::System.Runtime.InteropServices.HandleRef jarg1, uint particleIndex);
            
        }
    }
}  

