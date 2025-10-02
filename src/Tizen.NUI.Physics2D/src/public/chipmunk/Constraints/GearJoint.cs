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
    /// <see cref="GearJoint"/> keeps the angular velocity ratio of a pair of bodies constant.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GearJoint : Constraint
    {
        /// <summary>
        /// Check if a constraint is a <see cref="GearJoint"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsGearJoint(Constraint constraint) => NativeMethods.cpConstraintIsGearJoint(constraint.Handle) != 0;

        /// <summary>
        /// Keeps the angular velocity ratio of a pair of bodies constant.
        /// </summary>
        /// <param name="bodyA">The first connected body.</param>
        /// <param name="bodyB">The second connected body.</param>
        /// <param name="phase">The seconded connected body.</param>
        /// <param name="ratio">
        /// Measured in absolute terms. It is currently not possible to set
        /// the ratio in relation to a third body’s angular velocity.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GearJoint(Body bodyA, Body bodyB, double phase, double ratio) :
            base(NativeMethods.cpGearJointNew(bodyA.Handle, bodyB.Handle, phase, ratio))
        {
        }

        /// <summary>
        /// The phase offset of the gears.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Phase
        {
            get => NativeMethods.cpGearJointGetPhase(Handle);
            set => NativeMethods.cpGearJointSetPhase(Handle, value);
        }

        /// <summary>
        /// The ratio of a gear joint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Ratio
        {
            get => NativeMethods.cpGearJointGetRatio(Handle);
            set => NativeMethods.cpGearJointSetRatio(Handle, value);
        }
    }
}
