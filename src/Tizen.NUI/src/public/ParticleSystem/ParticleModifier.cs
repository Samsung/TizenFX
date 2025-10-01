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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tizen.NUI.ParticleSystem
{
    /// <summary>
    /// ParticleModifierInterface provides callbacks in order to define
    /// how particles in the system should be modified
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParticleModifierInterface
    {
        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleModifierInterface()
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
        /// Updates the ParticleModifier.
        /// </summary>
        /// <remarks>
        /// This callback is responsible for updating particles in the system.
        ///
        /// This callback runs on the Update thread! It should avoid using NUI objects.
        ///
        /// </remarks>
        /// <param name="emitterProxy">Proxy to the ParticleEmitter object</param>
        /// <param name="particleList">List of particles to be updated by the modifier</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Update(ParticleEmitterProxy emitterProxy, List<Particle> particleList)
        {
        }

        /// <summary>
        /// ParticleEmitter proxy that can be accessed by the user implementation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleEmitterProxy Emitter;
    }


    /// <summary>
    /// Class represents particle modifier
    /// </summary>
    /// <remarks>
    /// ParticleModifier modifies existing particles in the system.
    /// Modifiers can be stacked (more than one can be added to the ParticleEmitter).
    /// Output of one modifier becomes input for next modifier.
    ///
    /// Modifier calls into the implementation of <see cref="ParticleModifierInterface"/> class.
    ///
    /// </remarks>
    /// <typeparam name="T">Class of interface that derives from <see cref="ParticleModifierInterface"/></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ParticleModifier<T> : BaseHandle where T : ParticleModifierInterface, new()
    {
        // static cache for modifiers (binding between native side and interfaces)
        static ParticleInterfaceRegister<ParticleModifierInterface> gModifierInterfaceRegister = new ParticleInterfaceRegister<ParticleModifierInterface>();

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
                gModifierInterfaceRegister.Remove(mInterface);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Invoker for ParticleModifierInterface.Update()
        /// </summary>
        /// <param name="cPtr">Native pointer of ParticleModifier base object</param>
        /// <param name="listPtr">C-style array of integers</param>
        /// <param name="first">First particle to be modified (now always 0)</param>
        /// <param name="count">Number of particles to be modified</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static void OnUpdateInvoker(IntPtr cPtr, IntPtr listPtr, uint first, uint count)
        {
            if (count > 0)
            {
                T modifier = (cPtr == IntPtr.Zero) ? null : gModifierInterfaceRegister.Get(cPtr) as T;
                var list = modifier?.Emitter.AcquireParticleList(listPtr, count);
                modifier?.Update(modifier.Emitter, list);
                modifier?.Emitter.ReleaseParticleList(list);
            }
        }


        internal ParticleModifier(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// <summary>
        /// Constructor of ParticleModifier
        /// </summary>
        /// <remarks>
        /// ParticleModifier is a generic type that will call back into the given ParticleModifierInterface
        /// instance.
        /// The instance of T (derived from ParticleModifierInterface) is created internally and own by the
        /// ParticleModifier.
        /// The constructor takes variable number of arguments which is processed when called ParticleModifierInterface.Construct()
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleModifier(params object[] list) : this(Interop.ParticleModifier.New(mOnUpdateInvoker, out gRefObjectPtr), true)
        {
            // Create interface on the C# side (no direct connection with C++)
            mInterface = new T();
            mInterface.Construct(list);

            // Register interface using base ptr
            gModifierInterfaceRegister.Register(gRefObjectPtr, mInterface);

            // Initialise native side for this interface
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetEmitter(ParticleEmitter emitter)
        {
            mInterface.Emitter = new ParticleEmitterProxy(emitter);
        }

        private static Interop.ParticleModifier.ParticleModifierUpdateInvokerType mOnUpdateInvoker = OnUpdateInvoker;
        private ParticleModifierInterface mInterface;
        private static IntPtr gRefObjectPtr;
    }
}
