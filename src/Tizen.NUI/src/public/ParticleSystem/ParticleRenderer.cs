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
using System.Runtime.InteropServices;
using global::System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.ParticleSystem
{
    
    public class ParticleRenderer : BaseHandle
    {
        internal ParticleRenderer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized  ParticleRenderer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleRenderer() : this(Interop.ParticleRenderer.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="particleEmitter">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleRenderer(ParticleRenderer particleRenderer) : this(Interop. ParticleRenderer.Copy( ParticleRenderer.getCPtr(particleRenderer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="particleEmitter">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ParticleRenderer Assign( ParticleRenderer particleRenderer)
        {
            ParticleRenderer ret = new  ParticleRenderer(Interop.ParticleRenderer.Assign(SwigCPtr,  ParticleRenderer.getCPtr(particleRenderer)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTexture(Texture texture)
        {
            Interop.ParticleRenderer.SetTexture(SwigCPtr, texture.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        

    }
    
    
    
    
}