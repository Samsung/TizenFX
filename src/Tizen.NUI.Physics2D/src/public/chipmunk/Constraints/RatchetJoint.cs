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
    /// <see cref="RatchetJoint"/> is a rotary ratchet, which works like a socket wrench.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RatchetJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="RatchetJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsRatchetJoint(Constraint constraint) => NativeMethods.cpConstraintIsRatchetJoint(constraint.Handle) != 0;

        /// <summary>
        /// Works like a socket wrench.
        /// </summary>
        /// <param name="bodyA">One of the two bodies to connect.</param>
        /// <param name="bodyB">One of the two bodies to connect.</param>
        /// <param name="phase">
        /// The initial offset to use when deciding where the ratchet angles are.
        /// </param>
        /// <param name="ratchet">
        /// The distance between "clicks" (following the socket wrench analogy).
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RatchetJoint(Body bodyA, Body bodyB, double phase, double ratchet)
            : base(NativeMethods.cpRatchetJointNew(bodyA.Handle, bodyB.Handle, phase, ratchet))
        {
        }

        /// <summary>
        /// The angle of the current ratchet tooth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Angle
        {
            get => NativeMethods.cpRatchetJointGetAngle(Handle);
            set => NativeMethods.cpRatchetJointSetAngle(Handle, value);
        }

        /// <summary>
        /// The phase offset of the ratchet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Phase
        {
            get => NativeMethods.cpRatchetJointGetPhase(Handle);
            set => NativeMethods.cpRatchetJointSetPhase(Handle, value);
        }

        /// <summary>
        /// The angular distance of each ratchet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Rachet
        {
            get => NativeMethods.cpRatchetJointGetRatchet(Handle);
            set => NativeMethods.cpRatchetJointSetRatchet(Handle, value);
        }
    }
}
