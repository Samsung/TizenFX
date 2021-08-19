using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The Dp class is density independent pixel.
    /// One dp is a virtual pixel unit that's roughly equal to one pixel
    /// on a medium-density(160dpi) screen.
    /// To convert Dp to pixel, use Pixel property or,
    /// See <see cref="Tizen.NUI.DisplayTypeManager" /> and <see cref="Tizen.NUI.DisplayTypeConverter" /> also.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Dp : Disposable, ICloneable
    {
        private float dp;

        /// <summary>
        /// Create a new Dp.
        /// </summary>
        /// <param name="dpSize">The size of Dp.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dp(float dpSize)
        {
            dp = dpSize;
        }

        /// <summary>
        /// Dp value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Value
        {
            get
            {
                return dp;
            }
        }

        /// <summary>
        /// Pixel converted value.
        /// In medium-density(160dpi) screen, pixel will be same as dp value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Pixel
        {
            get
            {
                return (GraphicsTypeManager.Instance.ConvertToPixel(dp));
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Dp(dp);

        /// <summary>
        /// Constant Zero Dp
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp Zero
        {
            get
            {
               return new Dp(0.0f);
            }
        }

        /// <summary>
        /// Static helper to get Dp class from pixel.
        /// </summary>
        /// <param name="pixelSize">The size of pixel.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp GetDp(float pixelSize)
        {
            return new Dp(GraphicsTypeManager.Instance.ConvertFromPixel(pixelSize));
        }

        /// <summary>
        /// An addition operator.
        /// </summary>
        /// <param name="a">The Dp to add.</param>
        /// <param name="b">The Dp to add.</param>
        /// <returns>The Dp containing the result of the addition.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator +(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            else return new Dp(a.dp + b.dp);
        }

        /// <summary>
        /// An addition operator.
        /// </summary>
        /// <param name="a">The Dp to add.</param>
        /// <param name="b">The float value to add.</param>
        /// <returns>The Dp containing the result of the addition.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator +(Dp a, float b)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            a.dp = (a.dp + b);
            return a;
        }

        /// <summary>
        /// An subtraction operator.
        /// </summary>
        /// <param name="a">The Dp to subtract.</param>
        /// <param name="b">The Dp to subtract.</param>
        /// <returns>The Dp containing the result of the subtraction.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator -(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            else return new Dp(a.dp - b.dp);
        }

        /// <summary>
        /// An subtraction operator.
        /// </summary>
        /// <param name="a">The Dp to subtract.</param>
        /// <param name="b">The float value to subtract.</param>
        /// <returns>The Dp containing the result of the subtraction.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator -(Dp a, float b)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            a.dp = (a.dp - b);
            return a;
        }

        /// <summary>
        /// An multiplication operator.
        /// </summary>
        /// <param name="a">The Dp to multiply.</param>
        /// <param name="b">The Dp to multiply.</param>
        /// <returns>The Dp containing the result of the multiplication.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator *(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            else return new Dp(a.dp * b.dp);
        }

        /// <summary>
        /// An multiplication operator.
        /// </summary>
        /// <param name="a">The Dp to multiply.</param>
        /// <param name="b">The float value to multiply.</param>
        /// <returns>The Dp containing the result of the multiplication.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator *(Dp a, float b)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            a.dp = (a.dp * b);
            return a;
        }

        /// <summary>
        /// An division operator.
        /// </summary>
        /// <param name="a">The Dp for division.</param>
        /// <param name="b">The Dp to divide.</param>
        /// <returns>The Dp containing the result of the division.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator /(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            else if (b.dp == 0.0f) throw new DivideByZeroException();
            else return new Dp(a.dp / b.dp);
        }

        /// <summary>
        /// An division operator.
        /// </summary>
        /// <param name="a">The Dp for division.</param>
        /// <param name="b">The float value to divide.</param>
        /// <returns>The Dp containing the result of the division.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator /(Dp a, float b)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            else if (b == 0.0f) throw new DivideByZeroException();
            a.dp = (a.dp / b);
            return a;
        }

        /// <summary>
        /// An increasing operator.
        /// </summary>
        /// <param name="a">The Dp for increasing.</param>
        /// <returns>The Dp containing the result of the increasing.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator ++(Dp a)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            return new Dp(a.dp++);
        }

        /// <summary>
        /// An decreasing operator.
        /// </summary>
        /// <param name="a">The Dp for decreasing.</param>
        /// <returns>The Dp containing the result of the decreasing.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Dp operator --(Dp a)
        {
            if (object.ReferenceEquals(a, null)) throw new NullReferenceException();
            return new Dp(a.dp--);
        }

        /// <summary>
        /// An equality compare operator.
        /// </summary>
        /// <param name="a">The Dp for checking equality.</param>
        /// <param name="b">The Dp for checking equality.</param>
        /// <returns>The result of the equality. Return true if dp value is same.
        /// To check equality of references, use GetHashCode(). </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Dp a, Dp b)
        {
            if (object.ReferenceEquals(a, null))
            {
                if (object.ReferenceEquals(b, null)) return true;
                else return false;
            }
            else if (object.ReferenceEquals(b, null)) return false;
            else
            {
                return (a.dp == b.dp);
            }
        }

        /// <summary>
        /// An disequality compare operator.
        /// </summary>
        /// <param name="a">The Dp for checking equality.</param>
        /// <param name="b">The Dp for checking equality.</param>
        /// <returns>The result of the disequality. Return true if dp value is not same.
        /// To check disequality of references, use GetHashCode(). </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Dp a, Dp b)
        {
            if (object.ReferenceEquals(a, null))
            {
                if (object.ReferenceEquals(b, null)) return false;
                else return true;
            }
            else if (object.ReferenceEquals(b, null)) return true;
            else
            {
                return (a.dp != b.dp);
            }
        }

        /// <summary>
        /// An greater than operator.
        /// </summary>
        /// <param name="a">The Dp for checking greater.</param>
        /// <param name="b">The Dp for checking lesser.</param>
        /// <returns>The result of greater than. Return true if a's dp value is greater than b's dp value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator >(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            return (a.dp > b.dp);
        }

        /// <summary>
        /// An greater than or equal operator.
        /// </summary>
        /// <param name="a">The Dp for checking greater or equal.</param>
        /// <param name="b">The Dp for checking lesser or equal.</param>
        /// <returns>The result of greater than or equal. Return true if a's dp value is greater than or equal b's dp value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator >=(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            return (a.dp >= b.dp);
        }

        /// <summary>
        /// An lesser than operator.
        /// </summary>
        /// <param name="a">The Dp for checking lesser.</param>
        /// <param name="b">The Dp for checking greater.</param>
        /// <returns>The result of lesser than. Return true if a's dp value is lesser than b's dp value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator <(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            return (a.dp < b.dp);
        }

        /// <summary>
        /// An lesser than or equal operator.
        /// </summary>
        /// <param name="a">The Dp for checking lesser or equal.</param>
        /// <param name="b">The Dp for checking greater or equal.</param>
        /// <returns>The result of lesser than or equal. Return true if a's dp value is lesser than or equal b's dp value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator <=(Dp a, Dp b)
        {
            if ((object.ReferenceEquals(a, null)) || (object.ReferenceEquals(b, null))) throw new NullReferenceException();
            return (a.dp <= b.dp);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object o)
        {
            Dp a = o as Dp;
            if (object.ReferenceEquals(a, null)) return false;
            return (dp == a.dp);
        }

        /// <summary>
        /// Gets the hash code of this Dp.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// To string of this class and values.
        /// </summary>
        /// <returns>The string with class name with dp, pixel values.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => $"Tizen.NUI.Dp (Dp:{dp}, Pixel:{Pixel})";
    }
}
