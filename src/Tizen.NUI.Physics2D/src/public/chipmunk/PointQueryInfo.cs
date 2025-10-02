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
    /// <see cref="PointQueryInfo"/> holds the result of a point query made on a <see cref="Shape"/>
    /// or <see cref="Space"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PointQueryInfo : IEquatable<PointQueryInfo>
    {
#pragma warning disable IDE0032
        private readonly Shape shape;
        private readonly Vect point;
        private readonly double distance;
        private readonly Vect gradient;
#pragma warning restore IDE0032

        /// <summary>
        /// The nearest shape, None if no shape was within range.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shape Shape => shape;

        /// <summary>
        /// The closest point on the shape’s surface (in world space coordinates).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Point => point;

        /// <summary>
        /// The distance to the point. The distance is negative if the point is inside the shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Distance => distance;

        /// <summary>
        /// The gradient of the signed distance function.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Gradient => gradient;

        /// <summary>
        /// Create a <see cref="PointQueryInfo"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PointQueryInfo(Shape s, Vect p, double d, Vect g)
        {
            shape = s;
            point = p;
            distance = d;
            gradient = g;
        }

        /// <summary>
        /// Return true if this <see cref="PointQueryInfo"/> object is reference-equal to the given
        /// object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            var other = obj as PointQueryInfo;

            if (other == null)
            {
                return false;
            }

            return this == other;
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return shape.Handle.ToInt32() ^
                point.GetHashCode() ^
                distance.GetHashCode() ^
                (gradient.GetHashCode() << 4);
        }

        /// <summary>
        /// Return true if this <see cref="PointQueryInfo"/> object is reference-equal to the given
        /// object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(PointQueryInfo left, PointQueryInfo right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Return true if this <see cref="PointQueryInfo"/> object is not reference-equal to the
        /// given object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(PointQueryInfo a, PointQueryInfo b)
        {
            return !(a == b);
        }

        internal static PointQueryInfo FromQueryInfo(cpPointQueryInfo queryInfo)
        {
            var shape = Shape.FromHandle(queryInfo.shape);

            return new PointQueryInfo(
                shape,
                queryInfo.point,
                queryInfo.distance,
                queryInfo.gradient);
        }

        /// <summary>
        /// Return true if this <see cref="PointQueryInfo"/> object's distance is within
        /// <see cref="Single.Epsilon"/> of the other and all other fields are equivalent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(PointQueryInfo other)
        {
            if (ReferenceEquals(other, null) ||
                shape.Handle != other.shape.Handle ||
                point != other.point ||
                gradient != other.gradient)
            {
                return false;
            }

            return Math.Abs(distance - other.distance) < float.Epsilon;
        }
    }
}
