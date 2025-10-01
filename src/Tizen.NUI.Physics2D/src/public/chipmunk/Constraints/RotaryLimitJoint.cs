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
    /// <see cref="RotaryLimitJoint"/> constrains the relative rotations of two bodies.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RotaryLimitJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="RotaryLimitJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsRotaryLimitJoint(Constraint constraint) => NativeMethods.cpConstraintIsRotaryLimitJoint(constraint.Handle) != 0;

        /// <summary>
        /// Constrains the relative rotations of two bodies.
        /// </summary>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="mininum">
        /// The minimum angular limit in radians. May be greater than 1 backwards revolution.
        /// </param>
        /// <param name="maximum">
        /// The maximum angular limit in radians. May be greater than 1 revolution.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotaryLimitJoint(Body bodyA, Body bodyB, double mininum, double maximum)
            : base(NativeMethods.cpRotaryLimitJointNew(bodyA.Handle, bodyB.Handle, mininum, maximum))
        {
        }

        /// <summary>
        /// The minimum distance the joint will maintain between the two anchors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Minimum
        {
            get => NativeMethods.cpRotaryLimitJointGetMin(Handle);
            set => NativeMethods.cpRotaryLimitJointSetMin(Handle, value);
        }

        /// <summary>
        /// The maximum distance the joint will maintain between the two anchors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Maximum
        {
            get => NativeMethods.cpRotaryLimitJointGetMax(Handle);
            set => NativeMethods.cpRotaryLimitJointSetMax(Handle, value);
        }
    }
}
