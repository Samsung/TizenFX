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
    /// A circle shape defined by a radius
    /// This is the fastest and simplest collision shape
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Circle : Shape
    {
        /// <summary>
        /// Create and initialize a circle polygon shape.
        /// </summary>
        /// <param name="body">The body to attach the circle to.</param>
        /// <param name="radius">The radius of the circle.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Circle(Body body, double radius)
            : this(body, radius, Vect.Zero)
        {
        }

        /// <summary>
        /// Create and initialize an offset circle polygon shape.
        /// </summary>
        /// <param name="body">The body to attach the circle to.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="offset">
        /// The offset from the body's center of gravity in coordinates local to the body.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Circle(Body body, double radius, Vect offset)
            : base(NativeMethods.cpCircleShapeNew(body.Handle, radius, offset))
        {
        }

        /// <summary>
        /// Get the offset of the circle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Offset => NativeMethods.cpCircleShapeGetOffset(Handle);

        /// <summary>
        ///  Get the radius of the circle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Radius => NativeMethods.cpCircleShapeGetRadius(Handle);

        /// <summary>
        /// Get the calculated area of the circle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double Area => AreaForCircle(0.0, Radius);

        /// <summary>
        /// Calculate the moment of the circle for the given mass.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double MomentForMass(double mass)
        {
            return MomentForCircle(mass, Radius, Offset);
        }

        /// <summary>
        /// Calculate the moment of inertia for the circle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForCircle(double mass, double innerRadius, double radius, Vect offset)
        {
            return NativeMethods.cpMomentForCircle(mass, innerRadius, radius, offset);
        }

        /// <summary>
        /// Calculate the moment of inertia for the circle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForCircle(double mass, double radius, Vect offset)
        {
            return NativeMethods.cpMomentForCircle(mass, 0.0, radius, offset);
        }

        /// <summary>
        /// Calculate the area of a circle or donut.
        /// </summary>
        /// <param name="innerRadius">
        /// The radius of the 'donut hole', which defines the area missing.
        /// </param>
        /// <param name="radius">
        /// The outer radius of the donut. This should be greater than the
        /// <paramref name="innerRadius"/>.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double AreaForCircle(double innerRadius, double radius)
        {
            return NativeMethods.cpAreaForCircle(innerRadius, radius);
        }
    }
}
