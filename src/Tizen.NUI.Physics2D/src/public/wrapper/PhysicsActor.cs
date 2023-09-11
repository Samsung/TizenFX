/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Physics2D
{
    /// <summary>
    /// Class to associate a physics body (such as btRigidBody*) with a View
    /// for rendering.
    ///
    /// This object offers methods to modify basic physics properties
    /// asynchronously, that is, on the Update thread.
    ///
    /// Currently, using the Physics API directly should be done after
    /// blocking the physics integration step, by getting a ScopedAccessor from
    /// the PhysicsAdaptor. Once the ScopedAccessor is disposed, then the
    /// physics integration will run again.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PhysicsActor : BaseHandle
    {
#pragma warning disable IDE0032
        private readonly View _view;
#pragma warning restore IDE0032

        /// <summary>
        /// View is the view used for rendering the associated physics body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUI.BaseComponents.View View => _view;

        /// <summary>
        /// Binds the actor to the given body. This should be a body that has
        /// been added to the physics world, and has physical postion and
        /// rotation in that space. The Actor is used to render that object in
        /// DALi space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsActor(View view, Chipmunk.Body body, PhysicsAdaptor adaptor)
            : this(Interop.Actor.PhysicsActorNew(View.getCPtr(view), body.Handle, PhysicsAdaptor.getCPtr(adaptor)), true)
        {
            this._view = view;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsActor(PhysicsActor adaptor) : this( Interop.Actor.NewPhysicsActor(PhysicsActor.getCPtr(adaptor)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment "operator"
        /// </summary>
        internal PhysicsActor Assign(PhysicsActor rhs)
        {
            PhysicsActor adaptor = new PhysicsActor(Interop.Actor.Assign(SwigCPtr, PhysicsActor.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return adaptor;
        }

        internal PhysicsActor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Dispose the physics actor
        /// This will release the View, but it's up to the caller to release the Body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }
            if(type == DisposeTypes.Explicit)
            {
                // Called by user
                // Release managed resources
            }
            // Release unmanaged resources

            base.Dispose(type);
        }

        /**
         */
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Actor.DeletePhysicsActor(swigCPtr);
        }

        /// <summary>
        /// Get the physics body associated with this physics actor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Chipmunk.Body GetBody()
        {
            IntPtr cPtr = Interop.Actor.GetBody(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Chipmunk.Body(cPtr);
        }

        /// <summary>
        /// Queue a method to set the position on the associated physics body
        /// in the update thread before the next integration.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AsyncSetPhysicsPosition(Vector3 position)
        {
            Interop.Actor.AsyncSetPhysicsPosition(SwigCPtr, Vector3.getCPtr(position));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Queue a method to set the rotation of the associated physics body
        /// in the update thread before the next integration.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AsyncSetPhysicsRotation(Rotation position)
        {
            Interop.Actor.AsyncSetPhysicsRotation(SwigCPtr, Rotation.getCPtr(position));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the current position of the physics body in Physics space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetPhysicsPosition()
        {
            IntPtr cPtr = Interop.Actor.GetPhysicsPosition(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Get the current rotation of the physics body in Physics space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation GetPhysicsRotation()
        {
            IntPtr cPtr = Interop.Actor.GetPhysicsRotation(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Rotation(cPtr, true);
        }

        /// <summary>
        /// Get the current position of the View in world space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetActorPosition()
        {
            IntPtr cPtr = Interop.Actor.GetActorPosition(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Get the current rotation of the View in world space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation GetActorRotation()
        {
            IntPtr cPtr = Interop.Actor.GetActorRotation(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Rotation(cPtr, true);
        }
    }
}
