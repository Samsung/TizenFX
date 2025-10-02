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

using System.ComponentModel;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// <see cref="SimpleMotor"/> keeps the relative angular velocity constant.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SimpleMotor : Constraint
    {
        /// <summary>
        /// Check if constraint is a <see cref="SimpleMotor"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsSimpleMotor(Constraint constraint) => NativeMethods.cpConstraintIsSimpleMotor(constraint.Handle) != 0;

        /// <summary>
        /// Rotate with a constant relative angular velocity constant between two bodies.
        /// </summary>
        /// <param name="bodyA">One of the two bodies.</param>
        /// <param name="bodyB">One of the two bodies.</param>
        /// <param name="rate">The rate of rotation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SimpleMotor(Body bodyA, Body bodyB, double rate)
            : base(NativeMethods.cpSimpleMotorNew(bodyA.Handle, bodyB.Handle, rate))
        {
        }

        /// <summary>
        /// The rate of the motor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Rate
        {
            get => NativeMethods.cpSimpleMotorGetRate(Handle);
            set => NativeMethods.cpSimpleMotorSetRate(Handle, value);
        }
    }
}
