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
    public class ParticleListView
    {
        public ParticleListView(IntPtr nativePtr)
        {
            
        }
        
        public Particle NewParticle(float lifetime)
        {
            // This has to be done slightly differently to its native counterpart because
            // of the C# side
            /*
            IntPtr result = Interop.Particle.New(SwigCPtr, lifetime);
            Particle particle = Registry.GetManagedBaseHandleFromNativePtr(result) as Particle;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return particle;
            */
            return null;
        }

        public uint AddLocalStreamFloat(float defaultValue)
        {
            return 0;
        }
        
        public uint AddLocalStreamVector2(Vector2 defaultValue)
        {
            return 0;
        }
        
        public uint AddLocalStreamVector3(Vector4 defaultValue)
        {
            return 0;
        }
        
        public uint AddLocalStreamVector4(Vector3 defaultValue)
        {
            return 0;
        }
        
        private IntPtr mNativePtr;
    }

    internal enum StreamType
    {
        FLOAT = 0,
        FVEC2 = 1,
        FVEC3 = 2,
        FVEC4 = 3,
        INTEGER = 4,
        IVEC2 = 5,
        IVEC3 = 6,
        IVEC4 = 7,
    }
    
    public class ParticleList : BaseHandle
    {
        internal ParticleList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized  ParticleList.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ParticleList(HandleRef emitter) : this(Interop.ParticleList.New(emitter), true)
        {
            // Retrieve the internal object
            
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="particleEmitter">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleList(ParticleList particleRenderer) : this(Interop. ParticleList.Copy( ParticleList.getCPtr(particleRenderer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="particleEmitter">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ParticleList Assign( ParticleList particleRenderer)
        {
            ParticleList ret = new  ParticleList(Interop.ParticleList.Assign(SwigCPtr,  ParticleList.getCPtr(particleRenderer)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        
        public Particle NewParticle(float lifetime)
        {
            // This has to be done slightly differently to its native counterpart because
            // of the C# side
            uint outIndex;
            bool result = Interop.Particle.New(SwigCPtr, lifetime, out outIndex); // this returns only index of particle, shouldn't be stored
            if (result)
            {
                Particle particle = new Particle(SwigCPtr, outIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return particle;
            }

            return null;
        }

        public Particle GetParticle(uint index)
        {
            var particleRealIndex = Interop.ParticleList.GetParticle(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Particle(SwigCPtr, particleRealIndex);
        }

        public unsafe uint AddLocalStreamFloat(float defaultValue)
        {
            var result = Interop.ParticleList.AddLocalStream(SwigCPtr, (uint)StreamType.FLOAT, &defaultValue, sizeof(float));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        public unsafe uint AddLocalStreamVector2(Vector2 defaultValue)
        {
            var result = Interop.ParticleList.AddLocalStream(SwigCPtr, (uint)StreamType.FVEC2, (void*)defaultValue.SwigCPtr.Handle, sizeof(float)*2);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        public unsafe uint AddLocalStreamVector3(Vector3 defaultValue)
        {
            var result = Interop.ParticleList.AddLocalStream(SwigCPtr, (uint)StreamType.FVEC3, (void*)defaultValue.SwigCPtr.Handle, sizeof(float)*3);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        public unsafe uint AddLocalStreamVector4(Vector4 defaultValue)
        {
            var result = Interop.ParticleList.AddLocalStream(SwigCPtr, (uint)StreamType.FVEC4, (void*)defaultValue.SwigCPtr.Handle, sizeof(float)*4);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        
        private ParticleListView mParticleListView;
    }
    
    
    
    
}