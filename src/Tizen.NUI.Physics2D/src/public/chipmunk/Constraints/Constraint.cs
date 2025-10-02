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
using System.Diagnostics;
using System.ComponentModel;
using cpBody = System.IntPtr;
using cpConstraint = System.IntPtr;
using cpDataPointer = System.IntPtr;
using cpSpace = System.IntPtr;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
using ObjCRuntime;
#endif


namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Base class of all constraints.
    /// You usually don’t want to create instances of this class directly, but instead use one of
    /// the specific constraints such as the <see cref="PinJoint"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Constraint : IDisposable
    {
#pragma warning disable IDE0032
        cpConstraint constraint;
#pragma warning restore IDE0032

        /// <summary>
        /// Construct a constraint with the given native handle.
        /// </summary>
        /// <param name="handle"></param>
        internal protected Constraint(cpConstraint handle)
        {
            constraint = handle;
            RegisterUserData();
        }

        /// <summary>
        /// Native handle to constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public cpConstraint Handle => constraint;

        /// <summary>
        /// Register managed object to native user data.
        /// </summary>
        private void RegisterUserData()
        {
            cpDataPointer pointer = NativeInterop.RegisterHandle(this);
            NativeMethods.cpConstraintSetUserData(constraint, pointer);
        }

        void ReleaseUserData()
        {
            cpDataPointer pointer = NativeMethods.cpConstraintGetUserData(constraint);
            NativeInterop.ReleaseHandle(pointer);
        }

        /// <summary>
        /// Get a Constraint object from a native handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Constraint FromHandle(cpConstraint constraint)
        {
            cpDataPointer handle = NativeMethods.cpConstraintGetUserData(constraint);
            return NativeInterop.FromIntPtr<Constraint>(handle);
        }

        /// <summary>
        /// Dispose the constraint.
        /// </summary>
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                Debug.WriteLine("Disposing constraint {0} on finalizer... (consider Dispose explicitly)", constraint);
            }

            Free();
        }

        /// <summary>
        /// Destroy and free the constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Free()
        {
            ReleaseUserData();
            NativeMethods.cpConstraintFree(constraint);
        }

        /// <summary>
        /// Destroy the constraint
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get the cpSpace this constraint is added to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Space Space
        {
            get
            {
                cpSpace space = NativeMethods.cpConstraintGetSpace(constraint);
                return Space.FromHandleSafe(space);
            }
        }

        /// <summary>
        /// Get the first body the constraint is attached to.
        /// </summary>
        public Body BodyA
        {
            get
            {
                cpBody body = NativeMethods.cpConstraintGetBodyA(constraint);
                return Body.FromHandleSafe(body);
            }
        }

        /// <summary>
        /// Get the second body the constraint is attached to.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Body BodyB
        {
            get
            {
                cpBody body = NativeMethods.cpConstraintGetBodyB(constraint);
                return Body.FromHandleSafe(body);
            }
        }

        /// <summary>;
        /// The maximum force that this constraint is allowed to use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double MaxForce
        {
            get => NativeMethods.cpConstraintGetMaxForce(constraint);
            set => NativeMethods.cpConstraintSetMaxForce(constraint, value);
        }

        /// <summary>
        /// Rate at which joint error is corrected.
        /// Defaults to pow(1.0 - 0.1, 60.0) meaning that it will
        /// correct 10% of the error every 1/60th of a second.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double ErrorBias
        {
            get => NativeMethods.cpConstraintGetErrorBias(constraint);
            set => NativeMethods.cpConstraintSetErrorBias(constraint, value);
        }


        /// <summary>
        /// The maximum rate at which joint error is corrected.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double MaxBias
        {
            get => NativeMethods.cpConstraintGetMaxBias(constraint);
            set => NativeMethods.cpConstraintSetMaxBias(constraint, value);
        }

        /// <summary>
        /// Whether the two bodies connected by the constraint are allowed to collide or not.
        ///
        /// When two bodies collide, Chipmunk ignores the collisions if this property is set to
        /// False on any constraint that connects the two bodies. Defaults to True. This can be
        /// used to create a chain that self-collides, but adjacent links in the chain do not collide.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CollideBodies
        {
            get => NativeMethods.cpConstraintGetCollideBodies(constraint) != 0;
            set => NativeMethods.cpConstraintSetCollideBodies(constraint, value ? (byte)1 : (byte)0);
        }

        private static ConstraintSolveFunction preSolveFunctionCallback = ConstraintPreSolveFunctionCallback;
        private static ConstraintSolveFunction postSolveFunctionCallback = ConstraintPostSolveFunctionCallback;

        private Action<Constraint, Space> preSolve;
        private Action<Constraint, Space> postSolve;

        /// <summary>
        /// Pre-solve function that is called before the solver runs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Action<Constraint, Space> PreSolve
        {
            get => preSolve;
            set
            {
                preSolve = value;

                IntPtr callbackPointer;

                if (value == null)
                    callbackPointer = IntPtr.Zero;
                else
                    callbackPointer = preSolveFunctionCallback.ToFunctionPointer();

                NativeMethods.cpConstraintSetPreSolveFunc(constraint, callbackPointer);
            }
        }

        /// <summary>
        /// Post-solve function that is called after the solver runs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Action<Constraint, Space> PostSolve
        {
            get => postSolve;
            set
            {
                postSolve = value;

                IntPtr callbackPointer;

                if (value == null)
                    callbackPointer = IntPtr.Zero;
                else
                    callbackPointer = postSolveFunctionCallback.ToFunctionPointer();

                NativeMethods.cpConstraintSetPostSolveFunc(constraint, callbackPointer);
            }
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(ConstraintSolveFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void ConstraintPreSolveFunctionCallback(cpConstraint constraintHandle, cpSpace spaceHandle)
        {
            var constraint = Constraint.FromHandle(constraintHandle);
            var space = Space.FromHandle(spaceHandle);

            Action<Constraint, Space> preSolve = constraint.PreSolve;

            preSolve(constraint, space);
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(ConstraintSolveFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static void ConstraintPostSolveFunctionCallback(cpConstraint constraintHandle, cpSpace spaceHandle)
        {
            var constraint = Constraint.FromHandle(constraintHandle);
            var space = Space.FromHandle(spaceHandle);

            Action<Constraint, Space> postSolve = constraint.PostSolve;

            postSolve(constraint, space);
        }

        /// <summary>
        /// The user-definable data pointer for this constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Data { get; set; }

        /// <summary>
        /// Get the last impulse applied by this constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Impulse => NativeMethods.cpConstraintGetImpulse(constraint);
    }
}
