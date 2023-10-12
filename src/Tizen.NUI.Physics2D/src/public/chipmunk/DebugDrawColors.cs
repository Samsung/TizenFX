﻿/*
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

﻿using System.ComponentModel;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Default DebugColors for ShapeOutline, Constraint and CollisionPoint
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DebugDrawColors
    {
#pragma warning disable IDE0032
        static readonly DebugDrawColors defaultColors = new DebugDrawColors()
        {
            ShapeOutline = new DebugColor(1, 1, 1),
            Constraint = new DebugColor(0, 1, 0),
            CollisionPoint = new DebugColor(1, 0, 1)
        };
#pragma warning restore IDE0032

        /// <summary>
        /// Shape outline color.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DebugColor ShapeOutline { get; set; }

        /// <summary>
        /// Constraint color.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DebugColor Constraint { get; set; }

        /// <summary>
        /// Collision point color.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DebugColor CollisionPoint { get; set; }

        /// <summary>
        /// The Default DebugDrawColors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DebugDrawColors Default => defaultColors;

    }
}
