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
    /// <see cref="SlideJoint"/> is like a <see cref="PinJoint"/>, but with a minimum and maximum
    /// distance. A chain could be modeled using this joint. It keeps the anchor points from getting
    /// too far apart, but will allow them to get closer together.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SlideJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="SlideJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsSlideJoint(Constraint constraint) => NativeMethods.cpConstraintIsSlideJoint(constraint.Handle) != 0;

        /// <summary>
        /// Create a slide constraint between two bodies.
        /// </summary>
        /// <param name="bodyA">One of the two bodies to connect.</param>
        /// <param name="bodyB">One of the two bodies to connect.</param>
        /// <param name="anchorA">The anchor point for <paramref name="bodyA"/>.</param>
        /// <param name="anchorB">The anchor point for <paramref name="bodyB"/>.</param>
        /// <param name="min">The minimum distance the anchor points can get to each other.</param>
        /// <param name="max">The maximum distance the anchor points can be apart.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SlideJoint(Body bodyA, Body bodyB, Vect anchorA, Vect anchorB, double min, double max)
            : base(NativeMethods.cpSlideJointNew(bodyA.Handle, bodyB.Handle, anchorA, anchorB, min, max))
        {
        }

        /// <summary>
        /// The location of the first anchor relative to the first body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorA
        {
            get => NativeMethods.cpSlideJointGetAnchorA(Handle);
            set => NativeMethods.cpSlideJointSetAnchorA(Handle, value);
        }

        /// <summary>
        /// The location of the second anchor relative to the second body.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect AnchorB
        {
            get => NativeMethods.cpSlideJointGetAnchorB(Handle);
            set => NativeMethods.cpSlideJointSetAnchorB(Handle, value);
        }

        /// <summary>
        /// The minimum distance the joint will maintain between the two anchors
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Minimum
        {
            get => NativeMethods.cpSlideJointGetMin(Handle);
            set => NativeMethods.cpSlideJointSetMin(Handle, value);
        }

        /// <summary>
        /// The maximum distance the joint will maintain between the two anchors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Maximum
        {
            get => NativeMethods.cpSlideJointGetMax(Handle);
            set => NativeMethods.cpSlideJointSetMax(Handle, value);
        }
    }
}
