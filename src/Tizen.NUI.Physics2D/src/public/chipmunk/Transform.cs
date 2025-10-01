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
using System.Runtime.InteropServices;

#pragma warning disable IDE1006
#pragma warning disable IDE0032

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Type used for 2x3 affine transforms. See wikipedia for details:
    /// http://en.wikipedia.org/wiki/Affine_transformation. The properties map to the matrix in this
    /// way: [[a  c   tx], [b  d   ty]]. We can't use System.Numerics.Matrix32 since it does't use
    /// doubles.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public struct Transform : IEquatable<Transform>
    {
        private static readonly Transform identity = new Transform(1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);

        private double a;
        private double b;
        private double c;
        private double d;
        private double tx;
        private double ty;

        /// <summary>
        /// Create a matrix transformation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transform(double a, double b, double c, double d, double tx, double ty) : this()
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.tx = tx;
            this.ty = ty;
        }

        /// <summary>
        /// Create a transpose matrix.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Transform CreateTranspose(double a, double c, double tx, double b, double d, double ty)
        {
            return new Transform(a, b, c, d, tx, ty);
        }

        /// <summary>
        /// Create a translation matrix.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Transform CreateTranslation(Vect translate)
        {
            return CreateTranspose(1.0, 0.0, translate.X, 0.0, 1.0, translate.Y);
        }

        /// <summary>
        /// Create an identity matrix.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Transform Identity => identity;

        /// <summary>
        /// A
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double A { get => a; set => a = value; }

        /// <summary>
        /// B
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double B { get => b; set => b = value; }

        /// <summary>
        /// C
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double C { get => c; set => c = value; }

        /// <summary>
        /// D
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double D { get => d; set => d = value; }

        /// <summary>
        /// Tx
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Tx { get => tx; set => tx = value; }

        /// <summary>
        /// Ty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Ty { get => ty; set => ty = value; }

        /// <summary>
        /// Return true if all matrix values are within <see cref="Single.Epsilon"/> of each other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            Transform? transform = obj as Transform?;

            if (transform == null)
                return false;

            return Equals(transform.Value);
        }

        /// <summary>
        /// Return true if all matrix values are within <see cref="Single.Epsilon"/> of each other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Transform other)
        {
            return Math.Abs(a - other.a) < double.Epsilon &&
                   Math.Abs(b - other.b) < double.Epsilon &&
                   Math.Abs(c - other.c) < double.Epsilon &&
                   Math.Abs(d - other.d) < double.Epsilon &&
                   Math.Abs(tx - other.tx) < double.Epsilon &&
                   Math.Abs(ty - other.ty) < double.Epsilon;
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = -884009331;
#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
                hashCode = hashCode * -1521134295 + a.GetHashCode();
                hashCode = hashCode * -1521134295 + b.GetHashCode();
                hashCode = hashCode * -1521134295 + c.GetHashCode();
                hashCode = hashCode * -1521134295 + d.GetHashCode();
                hashCode = hashCode * -1521134295 + tx.GetHashCode();
                hashCode = hashCode * -1521134295 + ty.GetHashCode();
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
                return hashCode;
            }
        }

        /// <summary>
        /// Return a string formatted like "(a,b|c,d|tx,ty)".
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return $"({a},{b}|{c},{d}|{tx},{ty})";
        }

        /// <summary>
        /// Return true if all matrix values are within <see cref="Single.Epsilon"/> of each other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Transform transform1, Transform transform2)
        {
            return transform1.Equals(transform2);
        }

        /// <summary>
        /// Return true if all matrix values are not within <see cref="Single.Epsilon"/> of each
        /// other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Transform transform1, Transform transform2)
        {
            return !(transform1 == transform2);
        }
    }
}

#pragma warning restore IDE1006
#pragma warning restore IDE0032
