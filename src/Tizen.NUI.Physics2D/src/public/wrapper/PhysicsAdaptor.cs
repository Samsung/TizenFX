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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI;

namespace Tizen.NUI.Physics2D
{
    /// <summary>
    /// Enumeration to turn the integration step on or off.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum IntegrationState
        {
            ///<summary>
            ///Integration state is turned off - physics stops running
            ///</summary>
            Off,

            ///<summary>
            ///Integration state is turned on - physics runs in Update thread
            ///</summary>
            On
        };

    /// <summary>
    /// Enumeration to turn the debug layer on or off.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DebugState
        {
            ///<summary>
            ///Debug state is turned off - no debug is drawn
            ///</summary>
            Off,

            ///<summary>
            ///Debug state is turned on - if there is a Debug layer, then
            ///the physics debug is drawn over the top of the root layer
            ///</summary>
            On
        };

    /// <summary>
    /// Adaptor to manage access to the physics world and pairing actors and physics
    /// bodies, plus some translation methods to/from the physics space and dali space.
    ///
    /// Also manages a debug renderer that may utilize the physics engine debug.
    /// It is up to the developer to retrieve the root actor and parent it into the scene.
    ///
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PhysicsAdaptor : NUI.BaseHandle
    {
        /// <summary>
        /// Initialize the physics system.
        /// <param name="transform"> Transformation matrix from NUI space to the Physics Space</param>
        /// <param name="size">Size of the root layer that the adaptor creates</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsAdaptor(NUI.Matrix transform, NUI.Vector2 size)
            : this(Interop.Adaptor.PhysicsAdaptorNew(NUI.Matrix.getCPtr(transform), NUI.Vector2.getCPtr(size)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsAdaptor(PhysicsAdaptor adaptor) : this( Interop.Adaptor.NewPhysicsAdaptor(PhysicsAdaptor.getCPtr(adaptor)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PhysicsAdaptor Assign(PhysicsAdaptor rhs)
        {
            PhysicsAdaptor adaptor = new PhysicsAdaptor(Interop.Adaptor.Assign(SwigCPtr, PhysicsAdaptor.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return adaptor;
        }

        internal PhysicsAdaptor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Dispose the PhysicsAdaptor
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

        /// This will not be publicly opened
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Adaptor.DeletePhysicsAdaptor(swigCPtr);
        }

        /// <summary>
        /// The time that the integration step notionally takes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Timestep
        {
            get
            {
                return GetTimestep();
            }
            set
            {
                SetTimestep(value);
            }
        }

        internal float GetTimestep()
        {
            float timestep = Interop.Adaptor.GetTimestep(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return timestep;
        }
        internal void SetTimestep(float timestep)
        {
            Interop.Adaptor.SetTimestep(SwigCPtr, timestep);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Property to handle the IntegrationState of the adaptor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntegrationState IntegrationState
        {
            get
            {
                return GetIntegrationState();
            }
            set
            {
                SetIntegrationState(value);
            }
        }
        internal IntegrationState GetIntegrationState()
        {
            int state = Interop.Adaptor.GetIntegrationState(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (IntegrationState)state;
        }
        internal void SetIntegrationState(IntegrationState state)
        {
            Interop.Adaptor.SetIntegrationState(SwigCPtr, (int)state);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Property to handle the debug state of the adaptor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Physics2D.DebugState DebugState
        {
            get
            {
                return GetDebugState();
            }
            set
            {
                SetDebugState(value);
            }
        }
        internal DebugState GetDebugState()
        {
            int state = Interop.Adaptor.GetDebugState(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (DebugState)state;
        }
        internal void SetDebugState(DebugState state)
        {
            Interop.Adaptor.SetDebugState(SwigCPtr, (int)state);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// Change the transform matrix or the size of the root view
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTransformAndSize(Matrix transform, Vector2 size)
        {
            Interop.Adaptor.SetTransformAndSize(SwigCPtr, Matrix.getCPtr(transform), Vector2.getCPtr(size));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Return an accessor to the physics world.
        /// Internally, this locks a mutex to prevent the integration step from running,
        /// this will also block the Update thread. It is important that this accessor
        /// is disposed of when not needed to restart the update thread. (Suggest use of
        /// "using" block).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScopedPhysicsAccessor GetAccessor()
        {
            global::System.IntPtr worldCPtr = Interop.Adaptor.GetPhysicsWorld(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new ScopedPhysicsAccessor(worldCPtr);
        }

        /// <summary>
        /// Add a view to the body. The view will be used to render the body. It is parented onto the root layer.
        /// The physics body should be added to the physics space by the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsActor AddViewToBody(View view, Chipmunk.Body body)
        {
            // @todo Converting a View to an Actor internally _should_ be OK?!
            global::System.IntPtr cPtr = Interop.Adaptor.AddActorBody(SwigCPtr, View.getCPtr(view), body.Handle);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new PhysicsActor(cPtr, false);
        }

        /// <summary>
        /// This will unparent the View from the root layer, and dis-associate it
        /// from the physics body. It is the responsibility of the user to remove
        /// the physics body from the world.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveViewFromBody(PhysicsActor actor)
        {
            Interop.Adaptor.RemoveActorBody(SwigCPtr, PhysicsActor.getCPtr(actor));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieve a PhysicsActor given a physics body.
        /// If there is no associated PhysicsActor, this will return null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PhysicsActor GetPhysicsActor(Chipmunk.Body body)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.GetPhysicsActor(SwigCPtr, body.Handle);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // @todo This creates a new PhysicsActor on native side, but it's
            // not registered with native or c# registries. Do we need to add functionality?
            if(cPtr != global::System.IntPtr.Zero)
            {
                return new PhysicsActor(cPtr, false);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Set the root layer. All actors previously parented on the old root will be moved.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRootLayer(Layer layer)
        {
            Interop.Adaptor.SetRootActor(SwigCPtr, Layer.getCPtr(layer));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the root layer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Layer GetRootLayer()
        {
            global::System.IntPtr cPtr = Interop.Adaptor.GetRootActor(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // @todo Test against registry?
            Layer layer = new Layer(cPtr, false);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return layer;
        }

        /// <summary>
        /// Convert a touch point into a picking ray in the Physics space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BuildPickingRay(Vector3 origin, Vector3 direction, /*out*/ Vector3 rayFromWorld, /*out*/ Vector3 rayToWorld)
        {
            Interop.Adaptor.BuildPickingRay(SwigCPtr, Vector3.getCPtr(origin), Vector3.getCPtr(direction),
                                            Vector3.getCPtr(rayFromWorld), Vector3.getCPtr(rayToWorld));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Project a point from the origin (in NUI space) a distance along the direction
        /// vector (in NUI space) and returns the projected point in physics space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 ProjectPoint(Vector3 origin, Vector3 direction, float distance)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.ProjectPoint(SwigCPtr, Vector3.getCPtr(origin), Vector3.getCPtr(direction), distance);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Transforms a position from NUI space to physics space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 TransformPositionToPhysicsSpace(Vector3 position)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.TranslatePositionToPhysicsSpace(SwigCPtr, Vector3.getCPtr(position));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Transform a rotation from NUI to physics space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation TransformRotationToPhysicsSpace(Rotation rotation)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.TranslateRotationToPhysicsSpace(SwigCPtr, Rotation.getCPtr(rotation));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Rotation(cPtr, true);
        }

        /// <summary>
        /// Transform a position in Physics space to NUI space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 TransformPositionFromPhysicsSpace(Vector3 position)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.TranslatePositionFromPhysicsSpace(SwigCPtr, Vector3.getCPtr(position));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Convert a rotation in physics space into NUI space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation TransformRotationFromPhysicsSpace(Rotation rotation)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.TranslateRotationFromPhysicsSpace(SwigCPtr, Rotation.getCPtr(rotation));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Rotation(cPtr, true);
        }

        /// <summary>
        /// Converts a vector (not a point) in NUI space to Physics space
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 ConvertVectorToPhysicsSpace(Vector3 vector)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.ConvertVectorToPhysicsSpace(SwigCPtr, Vector3.getCPtr(vector));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// Converts a vector (not a point) in physics space to NUI space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 ConvertVectorFromPhysicsSpace(Vector3 vector)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.ConvertVectorFromPhysicsSpace(SwigCPtr, Vector3.getCPtr(vector));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Vector3(cPtr, true);
        }

        /// <summary>
        /// The debug layer uses a drawable actor and the debug features of the native physics engine
        /// to render any debug graphics for the physics bodies.
        /// This layer needs to be created before setting the DebugState has any effect.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Layer CreateDebugLayer(Window window)
        {
            global::System.IntPtr cPtr = Interop.Adaptor.CreateDebugLayer(SwigCPtr, Window.getCPtr(window));
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Layer(cPtr, false);
        }

        /// <summary>
        /// A sync point is necessary to synchronize Async calls in the update thread.
        /// Any use of the PhysicsActor.AsyncNNN calls will require this API to be called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CreateSyncPoint()
        {
            Interop.Adaptor.CreateSyncPoint(SwigCPtr);
            if(NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        // @todo Define interface for Queue that can accept cdecls.
    }
}
