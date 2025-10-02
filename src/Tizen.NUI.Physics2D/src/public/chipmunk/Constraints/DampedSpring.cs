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

using cpConstraint = System.IntPtr;


#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
using ObjCRuntime;
#endif

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// <see cref="DampedSpring"/> is a damped spring.
    /// The spring allows you to define the rest length, stiffness and damping.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DampedSpring : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="DampedSpring"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsDampedSpring(Constraint constraint) => NativeMethods.cpConstraintIsDampedSpring(constraint.Handle) != 0;

        /// <summary>
        /// Defined much like a slide joint.
        /// </summary>
        /// <param name="bodyA">The first connected body.</param>
        /// <param name="bodyB">The second connected body.</param>
        /// <param name="anchorA">Anchor point a, relative to body a.</param>
        /// <param name="anchorB"> Anchor point b, relative to body b.</param>
        /// <param name="restLength">The distance the spring wants to be.</param>
        /// <param name="stiffness">The spring constant (Young’s modulus).</param>
        /// <param name="damping">How soft to make the damping of the spring.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DampedSpring(
            Body bodyA,
            Body bodyB,
            Vect anchorA,
            Vect anchorB,
            double restLength,
            double stiffness,
            double damping)
            : base(NativeMethods.cpDampedSpringNew(
                bodyA.Handle,
                bodyB.Handle,
                anchorA,
                anchorB,
                restLength,
                stiffness,
                damping))
        {
            originalForceCallbackPointer = NativeMethods.cpDampedSpringGetSpringForceFunc(Handle);
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(DampedSpringForceFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static double DampedSpringForceCallback(cpConstraint springHandle, double distance)
        {
            var constraint = (DampedSpring)Constraint.FromHandle(springHandle);

            Func<DampedSpring, double, double> dampedSpringForceFunction = constraint.forceFunction;

            return dampedSpringForceFunction(constraint, distance);
        }

        private static DampedSpringForceFunction dampedSpringForceCallback = DampedSpringForceCallback;

        /// <summary>
        /// The location of the first anchor relative to the first body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorA
        {
            get => NativeMethods.cpDampedSpringGetAnchorA(Handle);
            set => NativeMethods.cpDampedSpringSetAnchorA(Handle, value);
        }

        /// <summary>
        /// The location of the second anchor relative to the second body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorB
        {
            get => NativeMethods.cpDampedSpringGetAnchorB(Handle);
            set => NativeMethods.cpDampedSpringSetAnchorB(Handle, value);
        }

        /// <summary>
        /// The rest length of the spring.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double RestLength
        {
            get => NativeMethods.cpDampedSpringGetRestLength(Handle);
            set => NativeMethods.cpDampedSpringSetRestLength(Handle, value);
        }

        /// <summary>
        /// The stiffness of the spring in force/distance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Stiffness
        {
            get => NativeMethods.cpDampedSpringGetStiffness(Handle);
            set => NativeMethods.cpDampedSpringSetStiffness(Handle, value);
        }

        /// <summary>
        /// The damping of the spring.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Damping
        {
            get => NativeMethods.cpDampedSpringGetDamping(Handle);
            set => NativeMethods.cpDampedSpringSetDamping(Handle, value);
        }

        private Func<DampedSpring, double, double> forceFunction;

        private IntPtr originalForceCallbackPointer;

        /// <summary>
        /// Damped spring force custom function callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Func<DampedSpring, double, double> ForceFunction
        {
            get => forceFunction;
            set
            {
                forceFunction = value;

                IntPtr callbackPointer;

                if (value == null)
                {
                    callbackPointer = originalForceCallbackPointer;
                }
                else
                {
                    callbackPointer = dampedSpringForceCallback.ToFunctionPointer();
                }

                NativeMethods.cpDampedSpringSetSpringForceFunc(Handle, callbackPointer);
            }
        }
    }
}
