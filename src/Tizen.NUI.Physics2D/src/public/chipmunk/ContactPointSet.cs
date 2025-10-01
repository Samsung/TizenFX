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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Contact point sets make getting contact information simpler. There can be at most 2 contact
    /// points.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class ContactPointSet : IEquatable<ContactPointSet>
    {
#pragma warning disable IDE0032
        private readonly int count;
        private readonly Vect normal;
        private readonly ContactPoint[] points;
#pragma warning restore IDE0032

        private ContactPointSet(int count, Vect normal, ContactPoint[] points)
        {
            this.count = count;
            this.normal = normal;
            this.points = points;
        }

        /// <summary>
        /// Get the number of contact points in the contact set (maximum of two).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => count;

        /// <summary>
        /// Get the normal of the collision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vect Normal => normal;

        /// <summary>
        /// List of points in the contact point set
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ContactPoint> Points => points;

        /// <summary>
        /// Return true if the contact point set is sequence-equal to another.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(ContactPointSet other)
        {
            if (ReferenceEquals(other, null)
                || count != other.count
                || normal != other.normal
                || points.Length != other.points.Length)
            {
                return false;
            }

            return points.SequenceEqual(other.points);
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = -475635172;

                hashCode = hashCode * -1521134295 + count.GetHashCode();
                hashCode = hashCode * -1521134295 + normal.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<ContactPoint[]>.Default.GetHashCode(points);

                return hashCode;
            }
        }

        /// <summary>
        /// Return true if the <see cref="ContactPointSet"/> is sequence-equal to another.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            var other = obj as ContactPointSet;

            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        /// <summary>
        /// Return true if the contact point sets are sequence-equal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(ContactPointSet left, ContactPointSet right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Return true if the contact point sets are sequence-inequal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(ContactPointSet left, ContactPointSet right)
        {
            return !(left == right);
        }

        internal static ContactPointSet FromContactPointSet(cpContactPointSet contactPointSet)
        {
            var points = new ContactPoint[2];

            if (contactPointSet.count > 0)
            {
                points[0] = ContactPoint.FromCollidePoint(contactPointSet.points0);
            }
            else
            {
                points[0] = ContactPoint.Empty;
            }

            if (contactPointSet.count > 1)
            {
                points[1] = ContactPoint.FromCollidePoint(contactPointSet.points1);
            }
            else
            {
                points[1] = ContactPoint.Empty;
            }

            return new ContactPointSet(
                contactPointSet.count,
                contactPointSet.normal,
                points);
        }

        internal cpContactPointSet ToContactPointSet()
        {
            return new cpContactPointSet
            {
                normal = normal,
                points0 = points[0].ToContactPoint(),
                points1 = points[1].ToContactPoint(),
                count = count
            };
        }
    }
}
