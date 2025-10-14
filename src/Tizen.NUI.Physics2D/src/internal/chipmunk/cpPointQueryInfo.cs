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

using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Point query info.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct cpPointQueryInfo
    {
        /// <summary>
        /// The nearest shape, null if no shape was within range.
        /// </summary>
        public IntPtr shape;

        /// <summary>
        /// The closest point on the shape's surface. (in world space coordinates)
        /// </summary>
        public Vect point;

        /// <summary>
        /// The distance to the point. The distance is negative if the point is inside the shape.
        /// </summary>
        public double distance;

        /// <summary>
        /// The gradient of the signed distance function.
        /// </summary>
        public Vect gradient;
    }
}
