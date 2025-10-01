/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
using ObjCRuntime;
#endif

using cpBody = System.IntPtr;
using cpArbiter = System.IntPtr;
using cpConstraint = System.IntPtr;
using cpShape = System.IntPtr;
using cpSpace = System.IntPtr;
using cpDataPointer = System.IntPtr;
using System.Diagnostics;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Mass and moment are ignored when <see cref="BodyType"/> is <see cref="BodyType.Kinematic"/>
    /// or <see cref="BodyType.Static"/>. Guessing the mass for a body is usually fine, but guessing
    /// a moment of inertia can lead to a very poor simulation. It’s recommended to use Chipmunk’s
    /// moment-calculating functions to estimate the moment for you.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Body : IDisposable
    {
#pragma warning disable IDE0032
        private readonly cpBody body;
#pragma warning restore IDE0032

        /// <summary>
        /// The native handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public cpBody Handle => body;

        /// <summary>
        /// Create a Dynamic Body with no mass and no moment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body()
            : this(BodyType.Dynamic)
        {
        }

        internal Body(cpBody handle)
        {
            body = handle;
            RegisterUserData();
        }

        /// <summary>
        ///  Create a <see cref="Body"/> of the given <see cref="BodyType"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body(BodyType type)
        {
            body = InitializeBody(type);
            RegisterUserData();
        }

        /// <summary>
        /// Creates a body with the given mass and moment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body(double mass, double moment) : this(mass, moment, BodyType.Dynamic)
        {
        }

        /// <summary>
        /// Creates a body with the given mass and moment, of the give <see cref="BodyType"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body(double mass, double moment, BodyType type)
        {
            body = InitializeBody(type);
            NativeMethods.cpBodySetMass(body, mass);
            NativeMethods.cpBodySetMoment(body, moment);
            RegisterUserData();
        }

        void RegisterUserData()
        {
            cpDataPointer pointer = NativeInterop.RegisterHandle(this);
            NativeMethods.cpBodySetUserData(body, pointer);
        }

        void ReleaseUserData()
        {
            cpDataPointer pointer = NativeMethods.cpBodyGetUserData(body);
            NativeInterop.ReleaseHandle(pointer);
        }

        /// <summary>
        /// Get a <see cref="Body"/> object from a native cpBody handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Body FromHandle(cpBody body)
        {
            cpDataPointer handle = NativeMethods.cpBodyGetUserData(body);
            return NativeInterop.FromIntPtr<Body>(handle);
        }

        /// <summary>
        /// Get the managed <see cref="Body"/> object from the native handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Body FromHandleSafe(cpBody nativeBodyHandle)
        {
            if (nativeBodyHandle == IntPtr.Zero)
            {
                return null;
            }

            return FromHandle(nativeBodyHandle);
        }

        private static cpBody InitializeBody(BodyType type)
        {
            if (type == BodyType.Kinematic)
            {
                return NativeMethods.cpBodyNewKinematic();
            }

            if (type == BodyType.Static)
            {
                return NativeMethods.cpBodyNewStatic();
            }

            return NativeMethods.cpBodyNew(0.0, 0.0);
        }

        /// <summary>
        /// Destroy and free the body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Free()
        {
            var space = Space;

            if (space != null)
                space.RemoveBody(this);

            ReleaseUserData();
            NativeMethods.cpBodyFree(body);
        }

        /// <summary>
        /// Dispose the body.
        /// </summary>
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                Debug.WriteLine("Disposing body {0} on finalizer... (consider Dispose explicitly)", body);
            }

            Free();
        }

        /// <summary>
        /// Dispose the body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Properties

        /// <summary>
        /// Arbitrary user data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Data { get; set; }

        /// <summary>
        /// Rotation of the body in radians. When changing the rotation, you may also want to call
        /// <see cref="Space.ReindexShapesForBody"/> to update the collision detection information
        /// for the attached shapes if you plan to make any queries against the space. A body
        /// rotates around its center of gravity, not its position.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Angle
        {
            get => NativeMethods.cpBodyGetAngle(body);
            set => NativeMethods.cpBodySetAngle(body, value);
        }

        /// <summary>
        /// Set body position and rotation angle (in radians)
        /// </summary>
        /// <param name="position"></param>
        /// <param name="angle"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTransform(Vect position, double angle)
        {
            NativeMethods.cpBodySetTransform(body, position, angle);
        }

        /// <summary>
        /// Get body position and rotation angle (in radians)
        /// </summary>
        /// <param name="position"></param>
        /// <param name="angle"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetTransform(out Vect position, out double angle)
        {
            NativeMethods.cpBodyGetTransform(body, out position, out angle);
        }

        /// <summary>
        /// The way the body behaves in physics simulations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BodyType Type
        {
            get => (BodyType)NativeMethods.cpBodyGetType(body);
            set => NativeMethods.cpBodySetType(body, (int)value);
        }

        /// <summary>
        /// Mass of the rigid body. Mass does not have to be expressed in any particular units, but
        /// relative masses should be consistent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Mass
        {
            get => NativeMethods.cpBodyGetMass(body);
            set => NativeMethods.cpBodySetMass(body, value);
        }

        /// <summary>
        /// Moment of inertia of the body. The mass tells you how hard it is to push an object,
        /// the MoI tells you how hard it is to spin the object. Don't try to guess the MoI, use the
        /// MomentFor*() functions to estimate it, or the physics may behave strangely.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Moment
        {
            get => NativeMethods.cpBodyGetMoment(body);
            set => NativeMethods.cpBodySetMoment(body, value);
        }

        /// <summary>
        /// Get the space this body is associated with, or null if it is not currently associated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Space Space
        {
            get
            {
                cpSpace space = NativeMethods.cpBodyGetSpace(body);
                return Space.FromHandleSafe(space);
            }
        }

        /// <summary>
        /// Position of the body. When changing the position, you may also want to call
        /// <see cref="Space.ReindexShapesForBody"/> to update the collision detection information
        /// for the attached shapes if you plan to make any queries against the space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Position
        {
            get => NativeMethods.cpBodyGetPosition(body);
            set => NativeMethods.cpBodySetPosition(body, value);
        }

        /// <summary>
        /// Location of the center of gravity in body-local coordinates. The default value is
        /// (0, 0), meaning the center of gravity is the same as the position of the body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect CenterOfGravity
        {
            get => NativeMethods.cpBodyGetCenterOfGravity(body);
            set => NativeMethods.cpBodySetCenterOfGravity(body, value);
        }

        /// <summary>
        /// Linear velocity of the center of gravity of the body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Velocity
        {
            get => NativeMethods.cpBodyGetVelocity(body);
            set => NativeMethods.cpBodySetVelocity(body, value);
        }

        /// <summary>
        /// Force applied to the center of gravity of the body. This value is reset for every time
        /// step.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Force
        {
            get => NativeMethods.cpBodyGetForce(body);
            set => NativeMethods.cpBodySetForce(body, value);
        }

        /// <summary>
        /// The angular velocity of the body in radians per second.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double AngularVelocity
        {
            get => NativeMethods.cpBodyGetAngularVelocity(body);
            set => NativeMethods.cpBodySetAngularVelocity(body, value);
        }

        /// <summary>
        /// The torque applied to the body. This value is reset for every time step.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Torque
        {
            get => NativeMethods.cpBodyGetTorque(body);
            set => NativeMethods.cpBodySetTorque(body, value);
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(BodyArbiterIteratorFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void AddEachArbiterToArray(cpBody body, cpArbiter arbiter, IntPtr data)
        {
            var list = (List<Arbiter>)GCHandle.FromIntPtr(data).Target;
            var a = new Arbiter(arbiter);
            list.Add(a);
        }

        private static BodyArbiterIteratorFunction eachArbiterFunc = AddEachArbiterToArray;

        /// <summary>
        /// The rotation vector for the body. Can be used with cpvrotate() or cpvunrotate() to perform fast rotations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Rotation => NativeMethods.cpBodyGetRotation(body);

        /// <summary>
        /// Get the list of body Arbiters
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<Arbiter> Arbiters
        {
            get
            {
                var list = new List<Arbiter>();
                var gcHandle = GCHandle.Alloc(list);
                NativeMethods.cpBodyEachArbiter(body, eachArbiterFunc.ToFunctionPointer(), GCHandle.ToIntPtr(gcHandle));
                gcHandle.Free();
                return list;
            }
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(BodyArbiterIteratorFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void AddEachConstraintToArray(cpBody body, cpConstraint constraint, IntPtr data)
        {
            var list = (List<Constraint>)GCHandle.FromIntPtr(data).Target;
            var c = Constraint.FromHandle(constraint);
            list.Add(c);
        }

        private static BodyConstraintIteratorFunction eachConstraintFunc = AddEachConstraintToArray;

        /// <summary>
        /// All constraints attached to the body
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<Constraint> Constraints
        {
            get
            {
                var list = new List<Constraint>();
                var gcHandle = GCHandle.Alloc(list);
                NativeMethods.cpBodyEachConstraint(body, eachConstraintFunc.ToFunctionPointer(), GCHandle.ToIntPtr(gcHandle));
                gcHandle.Free();
                return list.ToArray();
            }
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(BodyShapeIteratorFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void AddEachShapeToArray(cpBody body, cpShape shape, IntPtr data)
        {
            var list = (List<Shape>)GCHandle.FromIntPtr(data).Target;
            var s = Shape.FromHandle(shape);
            list.Add(s);
        }

        private static BodyShapeIteratorFunction eachShapeFunc = AddEachShapeToArray;

        /// <summary>
        /// All shapes attached to the body
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<Shape> Shapes
        {
            get
            {
                var list = new List<Shape>();
                var gcHandle = GCHandle.Alloc(list);
                NativeMethods.cpBodyEachShape(body, eachShapeFunc.ToFunctionPointer(), GCHandle.ToIntPtr(gcHandle));
                gcHandle.Free();
                return list.ToArray();
            }
        }

        /// <summary>
        /// Returns true if body is sleeping.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSleeping => NativeMethods.cpBodyIsSleeping(body) != 0;

        // Actions

        /// <summary>
        ///     Reset the idle timer on a body.
        ///     If it was sleeping, wake it and any other bodies it was touching.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Activate() => NativeMethods.cpBodyActivate(body);

        /// <summary>
        /// Similar in function to Activate(). Activates all bodies touching body. If filter is not NULL, then only bodies touching through filter will be awoken.
        /// </summary>
        /// <param name="filter"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateStatic(Shape filter) => NativeMethods.cpBodyActivateStatic(body, filter.Handle);

        /// <summary>
        /// Add the local force force to body as if applied from the body local point.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="point"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyForceAtLocalPoint(Vect force, Vect point)
        {
            NativeMethods.cpBodyApplyForceAtLocalPoint(body, force, point);
        }

        /// <summary>
        /// Apply torque.
        /// </summary>
        /// <param name="torque"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyTorque(double torque)
        {
            NativeMethods.cpBodyApplyTorque(body, torque);
        }

        /// <summary>
        /// Apply angular impulse.
        /// </summary>
        /// <param name="impulse"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyAngularImpulse(double impulse)
        {
            NativeMethods.cpBodyApplyAngularImpulse(body, impulse);
        }

        /// <summary>
        ///     Add the force force to body as if applied from the world point.
        ///     People are sometimes confused by the difference between a force and an impulse.
        ///     An impulse is a very large force applied over a very short period of time.
        ///     Some examples are a ball hitting a wall or cannon firing.
        ///     Chipmunk treats impulses as if they occur instantaneously by adding directly to the velocity of an object.
        ///     Both impulses and forces are affected the mass of an object.
        ///     Doubling the mass of the object will halve the effect.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="point"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyForceAtWorldPoint(Vect force, Vect point)
        {
            NativeMethods.cpBodyApplyForceAtWorldPoint(body, force, point);
        }

        /// <summary>
        /// Apply an impulse to a body. Both the impulse and point are expressed in world coordinates.
        /// </summary>
        /// <param name="impulse"></param>
        /// <param name="point"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyImpulseAtWorldPoint(Vect impulse, Vect point)
        {
            NativeMethods.cpBodyApplyImpulseAtWorldPoint(body, impulse, point);
        }

        /// <summary>
        /// Apply an impulse to a body. Both the impulse and point are expressed in body local coordinates.
        /// </summary>
        /// <param name="impulse"></param>
        /// <param name="point"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyImpulseAtLocalPoint(Vect impulse, Vect point)
        {
            NativeMethods.cpBodyApplyImpulseAtLocalPoint(body, impulse, point);
        }

        /// <summary>
        /// Forces a body to fall asleep immediately even if it’s in midair. Cannot be called from a callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Sleep()
        {
            NativeMethods.cpBodySleep(body);
        }

        /// <summary>
        /// When objects in Chipmunk sleep, they sleep as a group of all objects that are touching or jointed together.
        /// When an object is woken up, all of the objects in its group are woken up.
        /// SleepWithGroup() allows you group sleeping objects together. It acts identically to Sleep() if you pass null as
        /// group by starting a new group.
        /// If you pass a sleeping body for group, body will be awoken when group is awoken.
        /// You can use this to initialize levels and start stacks of objects in a pre-sleeping state.
        /// </summary>
        /// <param name="group"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SleepWithGroup(Body group)
        {
            NativeMethods.cpBodySleepWithGroup(body, group != null ? group.Handle : IntPtr.Zero);
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(BodyVelocityFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void BodyVelocityFunctionCallback(cpBody bodyHandle, Vect gravity, double damping, double dt)
        {
            var body = FromHandle(bodyHandle);

            body.velocityUpdateFunction(body, gravity, damping, dt);
        }

        private static BodyVelocityFunction BodyVelocityFunctionCallbackDelegate = BodyVelocityFunctionCallback;

        private Action<Body, Vect, double, double> velocityUpdateFunction;
        /// <summary>
        /// Set the callback used to update a body's velocity.
        /// Parameters: body, gravity, damping and deltaTime
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Action<Body, Vect, double, double> VelocityUpdateFunction
        {
            get => velocityUpdateFunction;
            set
            {
                velocityUpdateFunction = value;

                IntPtr callbackPointer;

                if (value == null)
                    callbackPointer = NativeMethods.cpBodyGetDefaultVelocityUpdateFunc();
                else
                    callbackPointer = BodyVelocityFunctionCallbackDelegate.ToFunctionPointer();

                NativeMethods.cpBodySetVelocityUpdateFunc(body, callbackPointer);
            }
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(BodyPositionFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void BodyPositionFunctionCallback(cpBody bodyHandle, double dt)
        {
            var body = FromHandle(bodyHandle);

            body.positionUpdateFunction(body, dt);
        }

        private static BodyPositionFunction BodyUpdateFunctionCallbackDelegate = BodyPositionFunctionCallback;

        private Action<Body, double> positionUpdateFunction;

        /// <summary>
        /// Set the callback used to update a body's position.
        /// Parameters: body, deltaTime
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Action<Body, double> PositionUpdateFunction
        {
            get => positionUpdateFunction;
            set
            {
                positionUpdateFunction = value;

                IntPtr callbackPointer;

                if (value == null)
                    callbackPointer = NativeMethods.cpBodyGetDefaultPositionUpdateFunc();
                else
                    callbackPointer = BodyUpdateFunctionCallbackDelegate.ToFunctionPointer();

                NativeMethods.cpBodySetPositionUpdateFunc(body, callbackPointer);
            }
        }

        /// <summary>
        /// Default velocity integration function..
        /// </summary>
        /// <param name="gravity"></param>
        /// <param name="damping"></param>
        /// <param name="dt"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateVelocity(Vect gravity, double damping, double dt)
        {
            NativeMethods.cpBodyUpdateVelocity(body, gravity, damping, dt);
        }

        /// <summary>
        /// Default position integration function.
        /// </summary>
        /// <param name="dt"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdatePosition(double dt)
        {
            NativeMethods.cpBodyUpdatePosition(body, dt);
        }

        /// <summary>
        /// Convert body relative/local coordinates to absolute/world coordinates.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect LocalToWorld(Vect point)
        {
            return NativeMethods.cpBodyLocalToWorld(body, point);
        }

        /// <summary>
        /// Convert body absolute/world coordinates to  relative/local coordinates.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect WorldToLocal(Vect point)
        {
            return NativeMethods.cpBodyWorldToLocal(body, point);
        }

        /// <summary>
        /// Get the velocity on a body (in world units) at a point on the body in world coordinates.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect GetVelocityAtWorldPoint(Vect point)
        {
            return NativeMethods.cpBodyGetVelocityAtWorldPoint(body, point);
        }

        /// <summary>
        /// Get the velocity on a body (in world units) at a point on the body in local coordinates.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect GetVelocityAtLocalPoint(Vect point)
        {
            return NativeMethods.cpBodyGetVelocityAtLocalPoint(body, point);
        }

        /// <summary>
        /// Get the kinetic energy of a body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double KineticEnergy => NativeMethods.cpBodyKineticEnergy(body);

        /// <summary>
        /// Calculate the moment of inertia for a solid box centered on the body.
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForBox(double mass, double width, double height)
        {
            return NativeMethods.cpMomentForBox(mass, width, height);
        }

        /// <summary>
        /// Get the list of all bodies in contact with this one
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<Body> AllContactedBodies
        {
            get
            {
                int count = NativeMethods.cpBodyGetContactedBodiesCount(body);
                int intptrBytes = checked(IntPtr.Size * count);

                if (intptrBytes == 0)
                    return Array.Empty<Body>();

                IntPtr ptrBodies = Marshal.AllocHGlobal(intptrBytes);
                NativeMethods.cpBodyGetUserDataContactedBodies(body, ptrBodies);

                IntPtr[] userDataArray = new IntPtr[count];

                Marshal.Copy(ptrBodies, userDataArray, 0, count);

                Marshal.FreeHGlobal(ptrBodies);

                Body[] bodies = new Body[count];

                for (int i = 0; i < count; i++)
                {
                    Body b = NativeInterop.FromIntPtr<Body>(userDataArray[i]);
                    bodies[i] = b;
                }

                return bodies;
            }
        }

        /// <summary>
        /// Check if a Body is in contact with another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactWith(Body other)
        {
            return NativeMethods.cpBodyContactWith(body, other.body) != 0;
        }
    }
}
