using System.Diagnostics;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Struct defining thickness around the edges of a Rectangle using doubles.
    /// </summary>
    [DebuggerDisplay("Left={Left}, Top={Top}, Right={Right}, Bottom={Bottom}, HorizontalThickness={HorizontalThickness}, VerticalThickness={VerticalThickness}")]
    [TypeConverter(typeof(ThicknessTypeConverter))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal struct Thickness
    {
        /// <summary>
        /// The thickness of the left side of a rectangle.
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// The thickness of the top of a rectangle.
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// The thickness of the right side of a rectangle.
        /// </summary>
        public double Right { get; set; }

        /// <summary>
        /// The thickness of the bottom of a rectangle.
        /// </summary>
        public double Bottom { get; set; }

        /// <summary>
        /// The sum of Left and Right.
        /// </summary>
        public double HorizontalThickness
        {
            get { return Left + Right; }
        }

        /// <summary>
        /// The sum of Top and Bottom.
        /// </summary>
        public double VerticalThickness
        {
            get { return Top + Bottom; }
        }

        internal bool IsDefault
        {
            get { return Left == 0 && Top == 0 && Right == 0 && Bottom == 0; }
        }

        /// <summary>
        /// Creates a new Thickness object that represents a uniform thickness of size uniformSize.
        /// </summary>
        /// <param name="uniformSize">The uniform size of all edges in the new thickness.</param>
        public Thickness(double uniformSize) : this(uniformSize, uniformSize, uniformSize, uniformSize)
        {
        }

        /// <summary>
        /// Creates a new Thickness object that has a horizontal thickness of horizontalSize and a vertical thickness of verticalSize.
        /// </summary>
        /// <param name="horizontalSize">The width of the left and right thicknesses.</param>
        /// <param name="verticalSize">The height of the top and bottom thicknesses.</param>
        public Thickness(double horizontalSize, double verticalSize) : this(horizontalSize, verticalSize, horizontalSize, verticalSize)
        {
        }

        /// <summary>
        /// Creates a new Thickness object with thicknesses defined by left, top, right, and bottom.
        /// </summary>
        /// <param name="left">The width of the left thickness.</param>
        /// <param name="top">The height of the top thickness.</param>
        /// <param name="right">The width of the right thickness.</param>
        /// <param name="bottom">The height of the bottom thickness.</param>
        public Thickness(double left, double top, double right, double bottom) : this()
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Converts a Size into a Thickness.
        /// </summary>
        /// <param name="size">A Size to convert to a Thickness</param>
        public static implicit operator Thickness(Size size)
        {
            return new Thickness(size.Width, size.Height, size.Width, size.Height);
        }

        /// <summary>
        /// Implicit cast operator from Double.
        /// </summary>
        /// <param name="uniformSize">The value for the uniform Thickness.</param>
        public static implicit operator Thickness(double uniformSize)
        {
            return new Thickness(uniformSize);
        }

        /// <summary>
        /// Whether the other has equivalent values.
        /// </summary>
        /// <param name="other">A Thickness to be compared.</param>
        /// <returns>true if other has equivalent values.</returns>
        bool Equals(Thickness other)
        {
            return Left.Equals(other.Left) && Top.Equals(other.Top) && Right.Equals(other.Right) && Bottom.Equals(other.Bottom);
        }

        /// <summary>
        /// Whether the obj has equivalent values.
        /// </summary>
        /// <param name="obj">A Thickness to be compared.</param>
        /// <returns>true if obj is a Thickness and has equivalent values.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Thickness && Equals((Thickness)obj);
        }

        /// <summary>
        /// A hash value for this Thickness.
        /// </summary>
        /// <returns>The hash value</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Left.GetHashCode();
                hashCode = (hashCode * 397) ^ Top.GetHashCode();
                hashCode = (hashCode * 397) ^ Right.GetHashCode();
                hashCode = (hashCode * 397) ^ Bottom.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Whether two Thicknesses have identical values.
        /// </summary>
        /// <param name="left">A Thickness to be compared.</param>
        /// <param name="right">A Thickness to be compared.</param>
        /// <returns>true if left and right have identical values for Left,Right, Top, and Bottom.</returns>
        public static bool operator ==(Thickness left, Thickness right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Whether the values of two Thickness's have at least one difference.
        /// </summary>
        /// <param name="left">A Thickness to be compared.</param>
        /// <param name="right">A Thickness to be compared.</param>
        /// <returns>true if any of the Left,Right, Top, and Bottom values differ between left and right.</returns>
        public static bool operator !=(Thickness left, Thickness right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Stores the components of the thickness in the corresponding arguments.
        /// </summary>
        /// <param name="left">Variable in which to store the left thickness of thickness object.</param>
        /// <param name="top">Variable in which to store the top thickness of thickness object.</param>
        /// <param name="right">Variable in which to store the right thickness of thickness object.</param>
        /// <param name="bottom">Variable in which to store the bottom thickness of thickness object.</param>
        public void Deconstruct(out double left, out double top, out double right, out double bottom)
        {
            left = Left;
            top = Top;
            right = Right;
            bottom = Bottom;
        }
    }
}