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
    /// DampedRotarySpring works like <see cref="DampedSpring"/>, but in an angular fashion.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DampedRotarySpring : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="DampedRotarySpring"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsDampedRotarySpring(Constraint constraint) => NativeMethods.cpConstraintIsDampedRotarySpring(constraint.Handle) != 0;

        /// <summary>
        /// Create a damped rotary spring.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DampedRotarySpring(
            Body bodyA,
            Body bodyB,
            double restAngle,
            double stiffness,
            double damping)
            : base(
                NativeMethods.cpDampedRotarySpringNew(
                    bodyA.Handle,
                    bodyB.Handle,
                    restAngle,
                    stiffness,
                    damping))
        {
            originalTorqueCallbackPointer = NativeMethods.cpDampedRotarySpringGetSpringTorqueFunc(Handle);
        }

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
#pragma warning disable CA1416 // Validate platform compatibility
        [MonoPInvokeCallback(typeof(DampedRotarySpringTorqueFunction))]
#pragma warning restore CA1416 // Validate platform compatibility
#endif
        private static double DampedRotarySpringTorqueCallback(cpConstraint springHandle, double relativeAngle)
        {
            var constraint = (DampedRotarySpring)FromHandle(springHandle);

            Func<DampedRotarySpring, double, double> dampedRotarySpringTorqueFunction = constraint.TorqueFunction;

            return dampedRotarySpringTorqueFunction(constraint, relativeAngle);
        }

        private static DampedRotarySpringTorqueFunction DampedRotarySpringForceCallback = DampedRotarySpringTorqueCallback;

        /// <summary>
        /// The rest angle of the spring.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double RestAngle
        {
            get => NativeMethods.cpDampedRotarySpringGetRestAngle(Handle);
            set => NativeMethods.cpDampedRotarySpringSetRestAngle(Handle, value);
        }

        /// <summary>
        /// The stiffness of the spring in force/distance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Stiffness
        {
            get => NativeMethods.cpDampedRotarySpringGetStiffness(Handle);
            set => NativeMethods.cpDampedRotarySpringSetStiffness(Handle, value);
        }

        /// <summary>
        /// The damping of the spring.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Damping
        {
            get => NativeMethods.cpDampedRotarySpringGetDamping(Handle);
            set => NativeMethods.cpDampedRotarySpringSetDamping(Handle, value);
        }

        private Func<DampedRotarySpring, double, double> torqueFunction;
        private IntPtr originalTorqueCallbackPointer;

        /// <summary>
        /// Damped rotary spring torque custom function callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Func<DampedRotarySpring, double, double> TorqueFunction
        {
            get => torqueFunction;
            set
            {
                torqueFunction = value;

                IntPtr callbackPointer;

                if (value == null)
                {
                    callbackPointer = originalTorqueCallbackPointer;
                }
                else
                {
                    callbackPointer = DampedRotarySpringForceCallback.ToFunctionPointer();
                }

                NativeMethods.cpDampedRotarySpringSetSpringTorqueFunc(Handle, callbackPointer);
            }
        }
    }
}
