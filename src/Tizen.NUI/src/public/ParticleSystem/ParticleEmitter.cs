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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI.ParticleSystem
{
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Enum defining blending options when rendering the particles.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ParticleBlendingMode
    {
        Additive = 0,
        Screen = 1,
        Default = Additive
    }

    /// <summary>
    /// Class ParticleEmitter creates a single emitter attached to a specified
    /// View. ParticleEmitter is responsible for spawning and updating particles.
    ///
    /// Emitter must contain:
    /// ParticleSource - responsible for spawning new particles
    /// ParticleModifier(s) - responsible for updating particles in the system
    ///
    /// ParticleSource and ParticleModifier callback interfaces should not be accessing
    /// Event side (NUI) objects. Both callbacks are executed on Update thread.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParticleEmitter : BaseHandle
    {
        internal ParticleEmitter(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized ParticleEmitter.
        /// </summary>
        /// <param name="view">View to attach the particle emitter.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleEmitter(View view) : this(Interop.ParticleEmitter.New(view.SwigCPtr), true)
        {
            mProxy = new ParticleEmitterProxy(this);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="particleEmitter">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal ParticleEmitter Assign( ParticleEmitter particleEmitter)
        {
            ParticleEmitter ret = new ParticleEmitter(Interop.ParticleEmitter.Assign(SwigCPtr, ParticleEmitter.getCPtr(particleEmitter)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        
        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        /// <param name="source">Source object to copy.</param>
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
        /// Maximum particle count
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ParticleCount
        {
            get
            {
                var value = Interop.ParticleEmitter.GetParticleCount(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                return value;
            }
            set
            {
                Interop.ParticleEmitter.SetParticleCount(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Rate of emission per second
        /// </summary>
        /// <remarks>
        /// EmissionRate defines number of particles emitted per second.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint EmissionRate
        {
            get
            {
                var value = Interop.ParticleEmitter.GetEmissionRate(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return value;
            }
            set
            {
                Interop.ParticleEmitter.SetEmissionRate(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        
        /// <summary>
        /// Initial particle count
        /// </summary>
        /// <remarks>
        /// Initial number of particles to be emitted immediately after emitter starts. It allows
        /// initial burst emission. By default it's set to 0.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint InitialParticleCount
        {
            get
            {
                var value = Interop.ParticleEmitter.GetInitialParticleCount(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return value;
            }
            set 
            {
                Interop.ParticleEmitter.SetInitialParticleCount(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve(); 
            }
        }
        
        /// <summary>
        /// Limit of active particles in the system
        /// </summary>
        /// <remarks>
        /// Active particles in the system can be limited without changing <see cref="ParticleCount"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ActiveParticleLimit
        {
            get{
                var value = Interop.ParticleEmitter.GetActiveParticlesLimit(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return value;
            }
            set 
            {
                Interop.ParticleEmitter.SetActiveParticlesLimit(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            
        }

        /// <summary>
        /// Gets/sets blending mode for particle renderer
        /// </summary>
        /// <remarks>
        /// Currently two blending modes are supported: Additive and Screen (advanced blending mode).
        /// <see cref="ParticleBlendingMode"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleBlendingMode RendererBlendingMode
        {
            get
            {                
                var value = Interop.ParticleEmitter.GetBlendingMode(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (ParticleBlendingMode)value;
            }
            set
            {
                Interop.ParticleEmitter.SetBlendingMode(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        
        /// <summary>
        /// Sets texture to be used by the renderer
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TextureResourceUrl
        {
            set
            {
                using var pixelBuffer = ImageLoader.LoadImageFromFile(value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                using Texture tex = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, pixelBuffer.GetWidth(),
                        pixelBuffer.GetHeight());
                using var pd = pixelBuffer.CreatePixelData();
                tex.Upload(pd);

                Interop.ParticleEmitter.SetTexture(SwigCPtr, tex.SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        
        /// <summary>
        /// Adds ParticleModifier to the stack
        /// </summary>
        /// <remarks>
        /// ParticleEmitter implements a stack of modifiers which are responsible for
        /// updating particles in the system. The stack is processed such as result of
        /// previous modifier is an input for next modifier.
        /// </remarks>
        /// <param name="modifier">Valid modifier object</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddModifier<T>(ParticleModifier<T> modifier) where T : ParticleModifierInterface, new()
        {
            // update interface
            modifier.SetEmitter(this);
            
            Interop.ParticleEmitter.AddModifier(SwigCPtr, modifier.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns associated ParticleSource object
        /// </summary>
        /// <returns>Valid ParticleSource object or null</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSource<T> GetSource<T>() where T : ParticleSourceInterface, new()
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetSource(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleSource<T> ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleSource<T>;
            return ret;
        }

        /// <summary>
        /// Returns modifier at specified index
        /// </summary>
        /// <param name="index">Index within modifier stack</param>
        /// <returns>Valid ParticleModifier object or null</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleModifier<ParticleModifierInterface> GetModifierAt(uint index)
        {
            IntPtr cPtr = Interop.ParticleEmitter.GetModifierAt(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ParticleModifier<ParticleModifierInterface> ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ParticleModifier<ParticleModifierInterface>;
            return ret;
        }

        /// <summary>
        /// Starts emission of particles.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start()
        {
            Interop.ParticleEmitter.Start(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops emission of particles.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            Interop.ParticleEmitter.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Adds local (not used by shader) data stream to the particle emitter
        /// </summary>
        /// <remarks>
        /// Adds new stream of float type.
        /// </remarks>
        /// <param name="defaultValue">Default value to fill the stream with</param>
        /// <returns>Index of newly created data stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamFloat(float defaultValue)
        {
            var result = Interop.ParticleEmitter.AddLocalStreamFloat(SwigCPtr, defaultValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        /// <summary>
        /// Adds local (not used by shader) data stream to the particle emitter
        /// </summary>
        /// <remarks>
        /// Adds new stream of Vector2 type.
        /// </remarks>
        /// <param name="defaultValue">Default value to fill the stream with</param>
        /// <returns>Index of newly created data stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector2(Vector2 defaultValue)
        {
            var result = Interop.ParticleEmitter.AddLocalStreamVector2(SwigCPtr, defaultValue.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        /// <summary>
        /// Adds local (not used by shader) data stream to the particle emitter
        /// </summary>
        /// <remarks>
        /// Adds new stream of Vector3 type.
        /// </remarks>
        /// <param name="defaultValue">Default value to fill the stream with</param>
        /// <returns>Index of newly created data stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector3(Vector3 defaultValue)
        {
            var result = Interop.ParticleEmitter.AddLocalStreamVector3(SwigCPtr, defaultValue.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
        
        /// <summary>
        /// Adds local (not used by shader) data stream to the particle emitter
        /// </summary>
        /// <remarks>
        /// Adds new stream of Vector4 type.
        /// </remarks>
        /// <param name="defaultValue">Default value to fill the stream with</param>
        /// <returns>Index of newly created data stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector4(Vector4 defaultValue)
        {
            var result = Interop.ParticleEmitter.AddLocalStreamVector4(SwigCPtr, defaultValue.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        // Internal proxy object to be used on the update thread
        internal ParticleEmitterProxy EmitterProxy => mProxy;
        private ParticleEmitterProxy mProxy;
    }
    
    /// <summary>
    /// This class provides functionality that can be used inside the Source/Modifier callbacks.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParticleEmitterProxy
    {
        internal ParticleEmitterProxy(ParticleEmitter emitter)
        {
            mEmitterBasePtr = emitter.SwigCPtr.Handle;
            mEmitter = emitter;
        }
        
        /// <summary>
        /// Creates new particle
        /// </summary>
        /// <remarks>
        /// Function may fail and return null if current number of particles exceeds limits of emitter.
        /// Particle is valid only inside the callback and must not be stored and used anywhere else. Otherwise
        /// the behaviour is undefined.
        /// </remarks>
        /// <param name="lifetime">Lifetime of the particle in seconds</param>
        /// <returns>New Particle object or null</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Particle NewParticle( float lifetime )
        {
            var result = Interop.ParticleEmitter.NewParticle(mEmitterBasePtr, lifetime);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (result >= 0)
            {
                // TODO: new particles should be coming form cached queue
                return new Particle(mEmitter.SwigCPtr, (uint)result);
            }
            return null;
        }
        
        /// <summary>
        /// Acquires list of Particles of specified length
        /// </summary>
        /// <remarks>
        /// The function should be use internally only. Native side passes list of indices of particles (int[]).
        /// Before calling the callback the indices must be marshalled and converted into the Particle objects.
        ///
        /// Internal Particle cache is used to speed up acquiring new Particle.
        /// </remarks>
        /// <param name="nativePtr">Native pointer to the list of indices (int32)</param>
        /// <param name="count">Number of elements</param>
        /// <returns>List of Particle objects</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal List<Particle> AcquireParticleList(IntPtr nativePtr, uint count)
        {
            // Populate enough particles into cache
            while(mParticleCache.Count < count)
            {
                mParticleCache.Push(new Particle(mEmitter.SwigCPtr, 0));
            }
            
            List<Particle> retval = new List<Particle>();
            for (var i = 0; i < count; ++i)
            {
                var particleIndex = Marshal.ReadInt32(nativePtr, i * 4);
                Particle p = mParticleCache.Pop();
                p.Index = (uint)particleIndex;
                retval.Add(p);
            }

            return retval;
        }

        /// <summary>
        /// Releases list of Particles back into the pool
        /// </summary>
        /// <remarks>
        /// Acquired particles come from internal pool and must be returned so then they can
        /// be recycled.
        /// </remarks>
        /// <param name="particles">List of particles to be returned</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void ReleaseParticleList(List<Particle> particles)
        {
            // return particles back into the pull
            for(var i = 0; i < particles.Count; ++i)
            {
                mParticleCache.Push(particles[i]);
            }
            
            // clear the list (probably not needed?)
            particles.Clear();
        }
        
        /// <summary>
        /// Adds local particle data stream of float values
        /// </summary>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Index of new stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamFloat(float defaultValue)
        {
            return mEmitter.AddLocalStreamFloat(defaultValue);
        }
        
        /// <summary>
        /// Adds local particle data stream of Vector2 values
        /// </summary>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Index of new stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector2(Vector2 defaultValue)
        {
            return mEmitter.AddLocalStreamVector2(defaultValue);
        }
        
        /// <summary>
        /// Adds local particle data stream of Vector3 values
        /// </summary>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Index of new stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector3(Vector3 defaultValue)
        {
            return mEmitter.AddLocalStreamVector3(defaultValue);
        }
        
        /// <summary>
        /// Adds local particle data stream of Vector4 values
        /// </summary>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Index of new stream</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddLocalStreamVector4(Vector4 defaultValue)
        {
            return mEmitter.AddLocalStreamVector4(defaultValue);
        }
        
        // Stack of cached particles
        private Stack<Particle> mParticleCache = new Stack<Particle>();
        
        private IntPtr mEmitterBasePtr;
        private ParticleEmitter mEmitter;

    }

    /// <summary>
    /// Register binding Source/Modifier interface to the pointer of a native counterpart 
    /// </summary>
    /// <typeparam name="T">Class type of objects to be stored in the register</typeparam>
    internal class ParticleInterfaceRegister<T> where T : class
    {
        internal void Register(IntPtr cPtr, T iface)
        {
            lock (mBasePtr)
            {
                mBasePtr.Add(cPtr);
                mInterfaces.Add(iface);
            }
        }

        internal bool Remove(IntPtr cPtr)
        {
            lock (mBasePtr)
            {
                var result = mBasePtr.FindIndex(0, x => x == cPtr);
                if (result >= 0)
                {
                    mBasePtr.RemoveAt(result);
                    mInterfaces.RemoveAt(result);
                }

                return result >= 0;
            }
        }

        internal bool Remove(T iface)
        {
            lock (mBasePtr)
            {
                var result = mInterfaces.FindIndex(0, x => x.Equals(iface));
                if (result >= 0)
                {
                    mBasePtr.RemoveAt(result);
                    mInterfaces.RemoveAt(result);
                }

                return result >= 0;
            }
        }
        
        internal T Get(IntPtr cPtr)
        {
            lock (mBasePtr)
            {
                var result = mBasePtr.FindIndex(0, x => x == cPtr);
                if (result >= 0)
                {
                    return mInterfaces[result];
                }

                return null;
            }
        }
        
        private List<IntPtr> mBasePtr = new List<IntPtr>();
        private List<T> mInterfaces = new List<T>();
    }
}
