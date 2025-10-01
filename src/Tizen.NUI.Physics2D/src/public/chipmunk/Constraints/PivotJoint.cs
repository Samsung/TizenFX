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
    /// <see cref="PivotJoint"/> acts like a swivel, allowing two objects to pivot about a single
    /// point.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PivotJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="PinJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsPivotJoint(Constraint constraint) => NativeMethods.cpConstraintIsPivotJoint(constraint.Handle) != 0;

        /// <summary>
        /// Initialize a pivot joint with two anchors. Since the anchors are provided in world
        /// coordinates, the bodies must already be correctly positioned. The joint is fixed as soon
        /// as the containing space is simulated.
        /// </summary>
        /// <param name="bodyA">One of the two bodies to connect.</param>
        /// <param name="bodyB">One of the two bodies to connect.</param>
        /// <param name="anchorA">
        /// The location of one of the anchors, specified in world coordinates.
        /// </param>
        /// <param name="anchorB">
        /// The location of one of the anchors, specified in world coordinates.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PivotJoint(Body bodyA, Body bodyB, Vect anchorA, Vect anchorB)
            : base(NativeMethods.cpPivotJointNew2(bodyA.Handle, bodyB.Handle, anchorA, anchorB))
        {
        }

        /// <summary>
        /// Initialize a pivot joint with one anchor. Since the pivot is provided in world
        /// coordinates, the bodies must already be correctly positioned.
        /// </summary>
        /// <param name="bodyA">One of the two bodies to connect.</param>
        /// <param name="bodyB">One of the two bodies to connect.</param>
        /// <param name="anchor">The location of the pivot, specified in world coordinates.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PivotJoint(Body bodyA, Body bodyB, Vect anchor) :
        base(NativeMethods.cpPivotJointNew(bodyA.Handle, bodyB.Handle, anchor))
        {

        }

        /// <summary>
        /// The location of the first anchor relative to the first body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorA
        {
            get => NativeMethods.cpPivotJointGetAnchorA(Handle);
            set => NativeMethods.cpPivotJointSetAnchorA(Handle, value);
        }

        /// <summary>
        /// The location of the second anchor relative to the second body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorB
        {
            get => NativeMethods.cpPivotJointGetAnchorB(Handle);
            set => NativeMethods.cpPivotJointSetAnchorB(Handle, value);
        }

    }
}
