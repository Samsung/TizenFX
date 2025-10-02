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
    /// Interface to draw debug primitives (circle, point, segment).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDebugDraw
    {
        /// <summary>
        /// Draw stroked circle.
        /// </summary>
        void DrawCircle(Vect pos, double angle, double radius, DebugColor outlineColor, DebugColor fillColor);

        /// <summary>
        /// Draws a line segment.
        /// </summary>
        void DrawSegment(Vect a, Vect b, DebugColor color);

        /// <summary>
        /// Draws a thick line segment.
        /// </summary>
        void DrawFatSegment(Vect a, Vect b, double radius, DebugColor outlineColor, DebugColor fillColor);

        /// <summary>
        /// Draws a convex polygon.
        /// </summary>
        void DrawPolygon(Vect[] vectors, double radius, DebugColor outlineColor, DebugColor fillColor);

        /// <summary>
        /// Draws a dot.
        /// </summary>
        void DrawDot(double size, Vect pos, DebugColor color);

        /// <summary>
        /// Returns a color for a given shape. This gives you an opportunity to color shapes based
        /// on how they are used in your engine.
        /// </summary>
        DebugColor ColorForShape(Shape shape);
    }
}
