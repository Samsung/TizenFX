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
    /// A line segment shape between two points, which is mainly useful when it behaves statically,
    /// though it can be beveled to give it thickness.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Segment : Shape
    {
        /// <summary>
        /// Create a line segment.
        /// </summary>
        /// <param name="body">The body to attach the segment to.</param>
        /// <param name="a">The first endpoint of the segment.</param>
        /// <param name="b">The second endpoint of the segment.</param>
        /// <param name="radius">The thickness of the segment.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Segment(Body body, Vect a, Vect b, double radius)
            : base(NativeMethods.cpSegmentShapeNew(body.Handle, a, b, radius))
        {
        }

        /// <summary>
        /// Let Chipmunk know about the geometry of adjacent segments to avoid colliding with endcaps.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetNeighbors(Vect prev, Vect next)
        {
            NativeMethods.cpSegmentShapeSetNeighbors(Handle, prev, next);
        }

        /// <summary>
        /// Get the first endpoint of the segment shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect A => NativeMethods.cpSegmentShapeGetA(Handle);

        /// <summary>
        /// Get the second endpoint of the segment shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect B => NativeMethods.cpSegmentShapeGetB(Handle);

        /// <summary>
        /// Get the normal of the segment shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Normal => NativeMethods.cpSegmentShapeGetNormal(Handle);

        /// <summary>
        /// Get the segment radius.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Radius => NativeMethods.cpSegmentShapeGetRadius(Handle);

        /// <summary>
        /// Calculate the area of the segment, assuming a thickness has been provided. The area is
        /// calculated assuming the endpoints would be rounded, like a capsule.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double Area => AreaForSegment(A, B, Radius);

        /// <summary>
        /// Calculate the moment of inertia of the segment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double MomentForMass(double mass)
        {
            return MomentForSegment(mass, A, B, Radius);
        }

        /// <summary>
        /// Calculate the moment of inertia for the line segment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForSegment(double mass, Vect a, Vect b, double radius)
        {
            return NativeMethods.cpMomentForSegment(mass, a, b, radius);
        }

        /// <summary>
        /// Calculate the area of a segment, assuming a thickness has been provided. The area is
        /// calculated assuming the endpoints would be rounded, like a capsule.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double AreaForSegment(Vect a, Vect b, double radius)
        {
            return NativeMethods.cpAreaForSegment(a, b, radius);
        }
    }
}
