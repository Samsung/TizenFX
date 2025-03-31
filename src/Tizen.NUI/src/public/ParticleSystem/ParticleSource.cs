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
using System.ComponentModel;

namespace Tizen.NUI.ParticleSystem
{
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// ParticleSourceInterface provides callbacks in order to define
    /// how new particles are emitted.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParticleSourceInterface
    {
        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSourceInterface()
        {
        }

        /// <summary>
        /// Second constructor
        /// </summary>
        /// <remarks>
        /// Second constructor should be overriden by the implementation.
        /// It allows passing variable number of arguments for processing.
        /// It is called immediately following the class constructor.
        /// </remarks>
        /// <param name="list">List of arguments</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Construct(params object[] list)
        {
        }

        /// <summary>
        /// Updates the ParticleSource.
        /// </summary>
        /// <remarks>
        /// This callback is responsible for spawning new particles. To spawn new particle,
        /// emitter.NewParticle() must be call. Number of particles to emit is given as 'count'.
        ///
        /// This callback runs on the Update thread! It should avoid using NUI objects.
        /// 
        /// </remarks>
        /// <param name="emitterProxy">Proxy to the ParticleEmitter object</param>
        /// <param name="count">Number of particles emitter expects to be spawned during call</param>
        /// <returns>Number of spawned particles</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual uint Update(ParticleEmitterProxy emitterProxy, uint count)
        {
            return 0;
        }

        /// <summary>
        /// Initializes ParticleSource  
        /// </summary>
        /// <remarks>
        /// This callback should be overriden in order to initialise the ParticleSource.
        /// It is called after ParticleEmitter.SetSource() and runs on the Event thread.
        /// It is the only place where ParticleSource may use NUI objects.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Init()
        {
            
        }

        /// <summary>
        /// ParticleEmitter proxy that can be accessed by the user implementation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleEmitterProxy Emitter;
    }
    
    /// <summary>
    /// Class represents the particle source
    /// </summary>
    /// <remarks>
    /// ParticleSource is responsible for emission of particles.
    /// It calls the implementation of <see cref="ParticleSourceInterface"/> class.
    /// The callback runs on update thread.
    /// </remarks>
    /// <typeparam name="T">Class of interface that derives from <see cref="ParticleSourceInterface"/></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ParticleSource<T> : BaseHandle where T : ParticleSourceInterface, new()
    {
        // static cache for sources (binding between native side and interfaces)
        private static ParticleInterfaceRegister<ParticleSourceInterface> gSourceInterfaceRegister = new ParticleInterfaceRegister<ParticleSourceInterface>();

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

            if (HasBody())
            {
                gSourceInterfaceRegister.Remove(mInterface);
            }
            base.Dispose(type);
        }
        
        /// <summary>
        /// Invoker for ParticleSourceInterface.Init()
        /// </summary>
        /// <remarks>
        /// Function is called from the native side
        /// </remarks>
        /// <param name="cPtr">Native pointer of ParticleSource base object</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static void OnInitInvoker(IntPtr cPtr)
        {
            // This function runs on Event thread
            T source = gSourceInterfaceRegister.Get(cPtr) as T;
            source?.Init();
        }
        
        /// <summary>
        /// Invoker for ParticleSourceInterface.Update()
        /// </summary>
        /// <remarks>
        /// Function is called from the native side
        /// </remarks>
        /// <param name="cPtr">Native pointer of ParticleSource base object</param>
        /// <param name="count">Number of particles to emit</param>
        /// <returns>Number of emitted particles</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static uint OnUpdateInvoker(IntPtr cPtr, uint count)
        {
            T source = gSourceInterfaceRegister.Get(cPtr) as T;
            var retval= source?.Update(source.Emitter, count);
            return retval.HasValue ? retval.Value : 0;
        }
        
        internal ParticleSource(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Constructor of ParticleSource
        /// </summary>
        /// <remarks>
        /// ParticleSource is a generic type that will call back into the given ParticleSourceInterface
        /// instance.
        /// The instance of T (derived from ParticleSourceInterface) is created internally and own by the
        /// ParticleSource.
        /// The constructor takes variable number of arguments which is processed when called ParticleSourceInterface.Construct()
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSource(params object[] list) : this(Interop.ParticleSource.New( mOnInitInvoker, mOnUpdateInvoker, out gRefObjectPtr ), true)
        {
            // Create interface on the C# side (no direct connection with C++)
            mInterface = new T();
            mInterface.Construct(list);
            
            // Register interface using base ptr
            gSourceInterfaceRegister.Register(gRefObjectPtr, mInterface);
            
            // Initialise native side for this interface
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Returns associated source callback interface
        /// </summary>
        /// <returns>Source callback interface</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private T GetCallbackInterface()
        {
            return mInterface as T;
        }

        /// <summary>
        /// Returns associated source callback interface
        /// </summary>
        /// <returns>Source callback interface</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Callback => GetCallbackInterface();

        internal void SetEmitter(ParticleEmitter emitter)
        {
            mInterface.Emitter = new ParticleEmitterProxy(emitter);
        }
        
        // private fields
        private static Interop.ParticleSource.ParticleSourceInitInvokerType mOnInitInvoker = OnInitInvoker;
        private static Interop.ParticleSource.ParticleSourceUpdateInvokerType mOnUpdateInvoker = OnUpdateInvoker;
        private ParticleSourceInterface mInterface;
        private static IntPtr gRefObjectPtr;
    }
}
