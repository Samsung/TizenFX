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
using System.ComponentModel;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Flags to enable or disable DebugDrawing.
    /// </summary>
    [Flags]
        [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DebugDrawFlags
    {
        /// <summary>
        /// Draw nothing.
        /// </summary>
        None = 0,

        /// <summary>
        /// Draw Shapes.
        /// </summary>
        Shapes = 1 << 0,

        /// <summary>
        /// Draw Constraints.
        /// </summary>
        Constraints = 1 << 1,

        /// <summary>
        ///  Draw Collision Points.
        /// </summary>
        CollisionPoints = 1 << 2,

        /// <summary>
        /// Draw All.
        /// </summary>
        All = Shapes | Constraints | CollisionPoints
    }
}
