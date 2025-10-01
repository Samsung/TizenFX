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
using System.Diagnostics;
using System.Runtime.InteropServices;
using cpBody = System.IntPtr;
using cpDataPointer = System.IntPtr;
using cpShape = System.IntPtr;
using cpSpace = System.IntPtr;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Abstract Chipmunk Shape
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Shape : IDisposable
    {
#pragma warning disable IDE0032
        private readonly cpShape shape;
#pragma warning restore IDE0032

        /// <summary>
        /// Create a Shape with the given <paramref name="shapeHandle"/>.
        /// </summary>
        /// <param name="shapeHandle">The native shape handle.</param>
        internal protected Shape(cpShape shapeHandle)
        {
            shape = shapeHandle;
            RegisterUserData();
        }

        /// <summary>
        /// The native handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public cpShape Handle => shape;

        /// <summary>
        /// Register managed object in the native user data.
        /// </summary>
        private void RegisterUserData()
        {
            cpDataPointer pointer = NativeInterop.RegisterHandle(this);
            NativeMethods.cpShapeSetUserData(shape, pointer);
        }

        void ReleaseUserData()
        {
            cpDataPointer pointer = NativeMethods.cpShapeGetUserData(shape);
            NativeInterop.ReleaseHandle(pointer);
        }

        /// <summary>
        /// Get a managed Shape from a native handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Shape FromHandle(cpShape shape)
        {
            cpDataPointer handle = NativeMethods.cpShapeGetUserData(shape);

            return NativeInterop.FromIntPtr<Shape>(handle);
        }

        /// <summary>
        /// Dispose the shape.
        /// </summary>
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                Debug.WriteLine("Disposing shape {0} on finalizer... (consider Dispose explicitly)", shape);
            }

            Free();
        }

        /// <summary>
        /// Destroy and free the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Free()
        {
            ReleaseUserData();
            NativeMethods.cpShapeFree(shape);
        }

        /// <summary>
        /// Destroy and free the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Shape properties

        /// <summary>
        /// Arbitrary user data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Data { get; set; }

        /// <summary>
        /// Gets the space that this shape is registered within.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Space Space
        {
            get
            {
                cpSpace space = NativeMethods.cpShapeGetSpace(shape);
                return Space.FromHandleSafe(space);
            }
        }

        /// <summary>
        /// The body that this shape is associated with.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body Body
        {
            get
            {
                cpBody body = NativeMethods.cpShapeGetBody(shape);
                return Body.FromHandleSafe(body);
            }
            set
            {
                Debug.Assert(value != null && Space == null,
                    "Body can't be null and you can only change body if the shape wasn't added to space");

                NativeMethods.cpShapeSetBody(shape, value.Handle);
            }
        }

        /// <summary>
        /// Mass of the shape to have Chipmunk calculate mass properties for you.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Mass
        {
            get => NativeMethods.cpShapeGetMass(shape);
            set => NativeMethods.cpShapeSetMass(shape, value);
        }

        /// <summary>
        /// Density of the shape if you are having Chipmunk calculate mass properties for you.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Density
        {
            get => NativeMethods.cpShapeGetDensity(shape);
            set => NativeMethods.cpShapeSetDensity(shape, value);
        }

        /// <summary>
        /// Get the calculated moment of inertia for the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Moment => NativeMethods.cpShapeGetMoment(shape);

        /// <summary>
        /// Get the calculated area of the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Area => NativeMethods.cpShapeGetArea(shape);

        /// <summary>
        /// Get the center of gravity of the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect CenterOfGravity => NativeMethods.cpShapeGetCenterOfGravity(shape);

        /// <summary>
        /// Get the bounding box that contains the shape, given it's current position and angle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BoundingBox BoundingBox => NativeMethods.cpShapeGetBB(shape);

        /// <summary>
        /// Whether the shape is a sensor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Sensor
        {
            get => NativeMethods.cpShapeGetSensor(shape) != 0;
            set => NativeMethods.cpShapeSetSensor(shape, value ? (byte)1 : (byte)0);
        }

        /// <summary>
        /// The elasticity of the shape. A value of 0.0 is perfectly inelastic (no bounce). A
        /// value of 1.0 is perfectly elastic. Due to simulation inaccuracy, values of 1.0 or
        /// greater are not recommended.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Elasticity
        {
            get => NativeMethods.cpShapeGetElasticity(shape);
            set => NativeMethods.cpShapeSetElasticity(shape, value);
        }

        /// <summary>
        /// The friction coefficient, following the Coulomb friction model. A value of 0.0 is
        /// frictionless. https://en.wikipedia.org/wiki/Friction#Coefficient_of_friction
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Friction
        {
            get => NativeMethods.cpShapeGetFriction(shape);
            set => NativeMethods.cpShapeSetFriction(shape, value);
        }

        /// <summary>
        ///  The surface velocity of the object. Useful for creating conveyor belts or players that
        ///  move around. This value is only used when calculating friction, not resolving the
        ///  collision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect SurfaceVelocity
        {
            get => NativeMethods.cpShapeGetSurfaceVelocity(shape);
            set => NativeMethods.cpShapeSetSurfaceVelocity(shape, value);
        }

        /// <summary>
        /// An arbitrary value representing the collision type of this shape. Only shapes with like
        /// collision types will collide.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CollisionType
        {
            get => (int)(uint)NativeMethods.cpShapeGetCollisionType(shape);
            set => NativeMethods.cpShapeSetCollisionType(shape, (UIntPtr)(uint)value);
        }

        /// <summary>
        /// An arbitrary value representing the collision type of this shape. Only shapes with like
        /// collision types will collide.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShapeFilter Filter
        {
            get => (ShapeFilter)NativeMethods.cpShapeGetFilter(shape);
            set => NativeMethods.cpShapeSetFilter(shape, (ShapeFilter)value);
        }

        /// <summary>
        /// Update, cache and return the bounding box of a shape based on the body it's attached to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BoundingBox CacheBB()
        {
            return NativeMethods.cpShapeCacheBB(shape);
        }

        /// <summary>
        /// Update, cache and return the bounding box of a shape with an explicit transformation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BoundingBox Update(Transform transform)
        {
            return NativeMethods.cpShapeUpdate(shape, transform);
        }

        /// <summary>
        /// Finds the point on the surface of the shape which is closest to the given point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PointQueryInfo PointQuery(Vect point)
        {
            var output = new cpPointQueryInfo();
            NativeMethods.cpShapePointQuery(shape, point, ref output);

            return PointQueryInfo.FromQueryInfo(output);
        }

        /// <summary>
        /// Perform a segment query against a shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SegmentQueryInfo SegmentQuery(Vect a, Vect b, double radius)
        {
            var queryInfo = new cpSegmentQueryInfo();
            NativeMethods.cpShapeSegmentQuery(shape, a, b, radius, ref queryInfo);

            return SegmentQueryInfo.FromQueryInfo(queryInfo);
        }

        /// <summary>
        /// Get the contact information between two shapes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContactPointSet Collide(Shape other)
        {
            Debug.Assert(Marshal.SizeOf(typeof(cpContactPointSet)) == 104,
                "check Chipmunk sizeof(cpContactPointSet)");

            cpContactPointSet contactPointSet = NativeMethods.cpShapesCollide(shape, other.Handle);

            return ContactPointSet.FromContactPointSet(contactPointSet);
        }
    }
}
