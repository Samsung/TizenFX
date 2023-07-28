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

using System.Reflection;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.ParticleSystem
{
    public class ParticleModifierInterface
    {
        public ParticleModifierInterface()
        {
        }

        public virtual void Construct(params object[] list)
        {
        }

        public virtual void Update(ParticleList particleList, uint first, uint count)
        {
        }
        
        public ParticleEmitter Emitter;
    }
    
    public partial class ParticleModifier<T> : BaseHandle where T : ParticleModifierInterface, new()
    {
        static void OnUpdateInvoker(IntPtr cPtr, IntPtr listPtr, uint first, uint count)
        {
            ParticleModifier<T> modifier = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromRefObject(cPtr) as ParticleModifier<T>;
            ParticleList list = (listPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromRefObject(listPtr) as ParticleList;

            if (list == null)
            {
                return;
            }
            modifier.mInterface.Update(list, first, count);
        }
        
        internal ParticleModifier(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }
        
        internal static Interop.ParticleModifier.ParticleModifierUpdateInvokerType mOnUpdateInvoker = OnUpdateInvoker;
        
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleModifier(params object[] list) : this(Interop.ParticleModifier.New(mOnUpdateInvoker), true)
        {
            // Create interface on the C# side (no direct connection with C++)
            mInterface = new T();
            mInterface.Construct(list);
            
            // Initialise native side for this interface
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        internal void SetEmitter(ParticleEmitter emitter)
        {
            mInterface.Emitter = emitter;
        }
        
        private ParticleModifierInterface mInterface = null;
    }
}