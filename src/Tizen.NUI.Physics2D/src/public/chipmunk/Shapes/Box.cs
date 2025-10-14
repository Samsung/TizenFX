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
    /// A retangular shape shape
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Box : Shape
    {
        /// <summary>
        /// Create and initialize a box polygon shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Box(Body body, double width, double height, double radius)
            : base(NativeMethods.cpBoxShapeNew(body.Handle, width, height, radius))
        {

        }

        /// <summary>
        /// Create and initialize an offset box polygon shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Box(Body body, BoundingBox box, double radius)
            : base(NativeMethods.cpBoxShapeNew2(body.Handle, box, radius))
        {

        }

        /// <summary>
        /// Calculate the moment of inertia for a solid box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForBox(double mass, double width, double height)
        {
            return NativeMethods.cpMomentForBox(mass, width, height);
        }

        /// <summary>
        /// Calculate the moment of inertia for a solid box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double MomentForBox(double mass, BoundingBox boundingBox)
        {
            return NativeMethods.cpMomentForBox2(mass, boundingBox);
        }
    }
}
