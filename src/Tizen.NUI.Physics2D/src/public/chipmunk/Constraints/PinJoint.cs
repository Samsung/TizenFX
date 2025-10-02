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
    /// <see cref="PinJoint"/> links shapes with a solid bar or pin. Keeps the anchor points at a
    /// set distance from one another.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PinJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="PinJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsPinJoint(Constraint constraint) => NativeMethods.cpConstraintIsPinJoint(constraint.Handle) != 0;

        /// <summary>
        /// The distance between the two anchor points is measured when the joint is created. If you
        /// want to set a specific distance, use the setter function to override it.
        /// </summary>
        /// <param name="bodyA">One of the two bodies to connect.</param>
        /// <param name="bodyB">One of the two bodies to connect.</param>
        /// <param name="anchorA">The anchor point for <paramref name="bodyA"/>.</param>
        /// <param name="anchorB">The anchor point for <paramref name="bodyB"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinJoint(Body bodyA, Body bodyB, Vect anchorA, Vect anchorB)
            : base(NativeMethods.cpPinJointNew(bodyA.Handle, bodyB.Handle, anchorA, anchorB))
        {
        }

        /// <summary>
        /// The location of the first anchor relative to the first body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorA
        {
            get => NativeMethods.cpPinJointGetAnchorA(Handle);
            set => NativeMethods.cpPinJointSetAnchorA(Handle, value);
        }

        /// <summary>
        /// The location of the second anchor relative to the second body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorB
        {
            get => NativeMethods.cpPinJointGetAnchorB(Handle);
            set => NativeMethods.cpPinJointSetAnchorB(Handle, value);
        }

        /// <summary>
        /// The distance the joint will maintain between the two anchors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Distance
        {
            get => NativeMethods.cpPinJointGetDist(Handle);
            set => NativeMethods.cpPinJointSetDist(Handle, value);
        }
    }
}
