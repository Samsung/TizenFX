using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Defines the thickness of a border around a control.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct UIExtents : IEquatable<UIExtents>
    {
        /// <summary>
        /// Represents a <see cref="UIExtents"/> with all values set to 0.
        /// </summary>
        public static readonly UIExtents Zero = new (0);

        /// <summary>
        /// Initializes a new instance of the <see cref="UIExtents"/> struct with the specified uniform size.
        /// </summary>
        /// <param name="uniformSize">The uniform size of the borders.</param>
        public UIExtents(float uniformSize) : this(uniformSize, uniformSize, uniformSize, uniformSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIExtents"/> struct with the specified horizontal and vertical sizes.
        /// </summary>
        /// <param name="horizontalSize">The horizontal size of the borders.</param>
        /// <param name="verticalSize">The vertical size of the borders.</param>
        public UIExtents(float horizontalSize, float verticalSize) : this(horizontalSize, horizontalSize, verticalSize, verticalSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIExtents"/> struct with the specified left, top, right, and bottom sizes.
        /// </summary>
        /// <param name="start">The width of the left border.</param>
        /// <param name="top">The width of the top border.</param>
        /// <param name="end">The width of the right border.</param>
        /// <param name="bottom">The width of the bottom border.</param>
        public UIExtents(float start, float end, float top, float bottom) : this()
        {
            Start = start;
            End = end;
            Top = top;
            Bottom = bottom;
        }

        /// <summary>
        /// Gets or sets the width of the left border.
        /// </summary>
        public float Start { get; init; }

        /// <summary>
        /// Gets or sets the width of the right border.
        /// </summary>
        public float End { get; init; }

        /// <summary>
        /// Gets or sets the width of the top border.
        /// </summary>
        public float Top { get; init; }

        /// <summary>
        /// Gets or sets the width of the bottom border.
        /// </summary>
        public float Bottom { get; init; }

        /// <summary>
        /// Gets the total width of the horizontal borders.
        /// </summary>
        public float HorizontalExtents => Start + End;

        /// <summary>
        /// Gets the total height of the vertical borders.
        /// </summary>
        public float VerticalExtents => Top + Bottom;

        /// <summary>
        /// Gets a value indicating whether this is zero.
        /// </summary>
        public readonly bool IsZero => Start == 0 && Top == 0 && End == 0 && Bottom == 0;

        /// <summary>
        /// Gets a value indicating whether any border has a width of NaN.
        /// </summary>
        public bool IsNaN => float.IsNaN(Start) && float.IsNaN(Top) && float.IsNaN(End) && float.IsNaN(Bottom);

        /// <summary>
        /// Implicitly converts a float to a <see cref="UIExtents"/>.
        /// </summary>
        /// <param name="uniformSize">The uniform size to convert.</param>
        public static implicit operator UIExtents(float uniformSize)
        {
            return new UIExtents(uniformSize);
        }

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        public bool Equals(UIExtents other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End) && Top.Equals(other.Top) && Bottom.Equals(other.Bottom);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is UIExtents && Equals((UIExtents)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Start.GetHashCode();
                hashCode = (hashCode * 397) ^ End.GetHashCode();
                hashCode = (hashCode * 397) ^ Top.GetHashCode();
                hashCode = (hashCode * 397) ^ Bottom.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Compares two <see cref="UIExtents"/> objects for equality.
        /// </summary>
        /// <param name="left">The first <see cref="UIExtents"/> object to compare.</param>
        /// <param name="right">The second <see cref="UIExtents"/> object to compare.</param>
        /// <returns>True if the objects are equal, otherwise false.</returns>
        public static bool operator ==(UIExtents left, UIExtents right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="UIExtents"/> objects for inequality.
        /// </summary>
        /// <param name="left">The first <see cref="UIExtents"/> object to compare.</param>
        /// <param name="right">The second <see cref="UIExtents"/> object to compare.</param>
        /// <returns>True if the objects are not equal, otherwise false.</returns>
        public static bool operator !=(UIExtents left, UIExtents right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Deconstructs the <see cref="UIExtents"/> into its individual components.
        /// </summary>
        /// <param name="start">The width of the left border.</param>
        /// <param name="top">The width of the top border.</param>
        /// <param name="end">The width of the right border.</param>
        /// <param name="bottom">The width of the bottom border.</param>
        public void Deconstruct(out float start, out float end, out float top,  float bottom)
        {
            start = Start;
            end = End;
            top = Top;
            bottom = Bottom;
        }

        /// <summary>
        /// Adds the specified <see cref="float"/> to each component of the <see cref="UIExtents"/>.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="addend">The float value to add.</param>
        /// <returns>A new <see cref="UIExtents"/> with the added values.</returns>
        public static UIExtents operator +(UIExtents left, float addend) => new UIExtents(left.Start + addend, left.End + addend, left.Top + addend, left.Bottom + addend);

        /// <summary>
        /// Adds the specified <see cref="UIExtents"/> to the current <see cref="UIExtents"/>.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>A new <see cref="UIExtents"/> with the added values.</returns>
        public static UIExtents operator +(UIExtents left, UIExtents right) => new UIExtents(left.Start + right.Start, left.End + right.End, left.Top + right.Top, left.Bottom + right.Bottom);

        /// <summary>
        /// Subtracts the specified <see cref="float"/> from each component of the <see cref="UIExtents"/>.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="subtrahend">The value to subtract.</param>
        /// <returns>A new <see cref="UIExtents"/> with the subtracted values.</returns>
        public static UIExtents operator -(UIExtents left, float subtrahend) => left + (-subtrahend);

        /// <summary>
        /// Converts the <see cref="UIExtents"/> to an <see cref="Extents"/>.
        /// </summary>
        /// <param name="uiExtents">The <see cref="UIExtents"/> to convert.</param>
        public static implicit operator Extents(UIExtents uiExtents) => new Extents((ushort)uiExtents.Start, (ushort)uiExtents.End, (ushort)uiExtents.Top, (ushort)uiExtents.Bottom);

        internal readonly Extents ToReferenceType() => new Extents((ushort)Start, (ushort)End, (ushort)Top, (ushort)Bottom);
    }
}
