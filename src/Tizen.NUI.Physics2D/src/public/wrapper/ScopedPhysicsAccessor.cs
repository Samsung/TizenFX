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
using System.Collections.Generic;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Physics2D
{
    /// <summary>
    /// Scoped accessor to the physics world.
    ///
    /// Automatically locks the physics world with a mutex to prevent the
    /// integration step from running whilst the developer is accessing
    /// the world, e.g. to add/remove bodies or constraints, or to
    /// perform hit-test.
    ///
    /// When it is disposed, the mutex is unlocked, and the integration step
    /// can resume.
    ///
    /// Suggest that this is created with a "using" block:
    ///
    /// using(accessor=physicsAdaptor.GetAccessor())
    /// {
    ///   var space = accessor.GetNative();
    ///   // Perform operations on space or bodies.
    /// } // automatically disposed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScopedPhysicsAccessor : IDisposable
    {
        private IntPtr worldCPtr;

        // Can only be constructed by PhysicsAdaptor
        internal ScopedPhysicsAccessor(IntPtr worldCPtr)
        {
            this.worldCPtr = worldCPtr;
            Interop.World.Lock(worldCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get a weak handle to the native physics space. Disposing of
        /// this handle does not destroy the space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Chipmunk.SpaceRef GetNative()
        {
            IntPtr spaceCPtr = Interop.World.GetNative(worldCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Chipmunk.SpaceRef(spaceCPtr);
        }

        /// <summary>
        /// Perform a hit test on the given physics world ray, with a possible filter.
        /// The ray can be created with PhysicsAdaptor.BuildPickingRay().
        /// Returns a body if hit, along with the local pivot coordinates and the distance from the ray origin (usually camera)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Chipmunk.Body HitTest( NUI.Vector3 rayFromWorld, NUI.Vector3 rayToWorld, Chipmunk.ShapeFilter filter, /*out*/ NUI.Vector3 localPivot, out float distanceFromCamera)
        {
            IntPtr cPtr = Interop.World.HitTest(worldCPtr, NUI.Vector3.getCPtr(rayFromWorld), NUI.Vector3.getCPtr(rayToWorld), filter, NUI.Vector3.getCPtr(localPivot), out distanceFromCamera);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if(cPtr != global::System.IntPtr.Zero)
            {
                return new Chipmunk.Body(cPtr);
            }
            return null;
        }

        /// <summary>
        /// Dispose of this object.
        /// This ensures that the integration step is resumed
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            Interop.World.Unlock(worldCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Disposes the Space object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
