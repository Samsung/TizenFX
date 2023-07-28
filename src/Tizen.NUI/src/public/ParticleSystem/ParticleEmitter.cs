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
    using Tizen.NUI.BaseComponents;
    
    public class ParticleEmitter : BaseHandle
    {
        internal ParticleEmitter(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized  ParticleEmitter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleEmitter(View view) : this(Interop.ParticleEmitter.New(view.SwigCPtr), true)
        {
            // It's necessary to initialise internal ParticleList so a valid NUI counterpart
            // will be registered.

            mParticleList = new ParticleList(SwigCPtr);
            
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private ParticleList mParticleList;

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="particleEmitter">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleEmitter( ParticleEmitter particleEmitter) : this(Interop. ParticleEmitter.New( ParticleEmitter.getCPtr(particleEmitter)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="particleEmitter">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ParticleEmitter Assign( ParticleEmitter particleEmitter)
        {
            ParticleEmitter ret = new  ParticleEmitter(Interop.ParticleEmitter.Assign(SwigCPtr,  ParticleEmitter.getCPtr(particleEmitter)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSource<T>(ParticleSource<T> source) where T : ParticleSourceInterface, new()
        {
            // update interface
            source.SetEmitter(this);
            
            // Set native source
            Interop.ParticleEmitter.SetSource(SwigCPtr, source.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDomain(ParticleDomain domain)
        {
            Interop.ParticleEmitter.SetSource(SwigCPtr, domain.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetParticleCount(uint count)
        {
            Interop.ParticleEmitter.SetParticleCount(SwigCPtr, count);
            
            // Reinitialize particle list
            mParticleList = new ParticleList(SwigCPtr);
            
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetEmissionRate(uint value)
        {
            Interop.ParticleEmitter.SetEmissionRate(SwigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }        
        
        public void SetInitialParticleCount(uint value)
        {
            Interop.ParticleEmitter.SetInitialParticleCount(SwigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }        
        
        public void SetActiveParticlesLimit(uint value)
        {
            Interop.ParticleEmitter.SetActiveParticlesLimit(SwigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRenderer(ParticleRenderer renderer)
        {
            Interop.ParticleEmitter.SetRenderer(SwigCPtr, renderer.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddModifier<T>(ParticleModifier<T> modifier) where T : ParticleModifierInterface, new()
        {
            // update interface
            modifier.SetEmitter(this);
            
            Interop.ParticleEmitter.AddModifier(SwigCPtr, modifier.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSource<T> GetSource<T>() where T : ParticleSourceInterface, new()
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetSource(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleSource<T> ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleSource<T>;
            return ret;
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleDomain GetDomain()
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetDomain(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleDomain ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleDomain;
            return ret;
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleModifier<ParticleModifierInterface> GetModifierAt(uint index)
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetModifierAt(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleModifier<ParticleModifierInterface> ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleModifier<ParticleModifierInterface>;
            return ret;
        }
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        //
        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSource GetRenderer(uint index)
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetRenderer(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleSource ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleSource;
            return ret;
        }
        */
        
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start()
        {
            Interop.ParticleEmitter.Start(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            Interop.ParticleEmitter.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        
        public uint AddLocalStreamFloat(float defaultValue)
        {
            return mParticleList.AddLocalStreamFloat(defaultValue);
        }
        
        public uint AddLocalStreamVector2(Vector2 defaultValue)
        {
            return mParticleList.AddLocalStreamVector2(defaultValue);
        }
        
        public uint AddLocalStreamVector3(Vector3 defaultValue)
        {
            return mParticleList.AddLocalStreamVector3(defaultValue);
        }
        
        public uint AddLocalStreamVector4(Vector4 defaultValue)
        {
            return mParticleList.AddLocalStreamVector4(defaultValue);
        }
        
    }
    

    
    
    
}