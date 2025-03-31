/* Copyright (c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI
{   
    /// <summary>
    /// Represents a rectangular area by defining its position and size.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct UIRect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIRect"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public UIRect(float x, float y, float width, float height) : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Gets a <see cref="UIRect"/> structure with all coordinates and sizes set to zero.
        /// </summary>
        public static readonly UIRect Zero;

        /// <summary>
        /// Gets the y-coordinate of the top edge of the rectangle.
        /// </summary>
        public float Top => Y;

        /// <summary>
        /// Gets the y-coordinate of the bottom edge of the rectangle.
        /// </summary>
        public float Bottom => Y + Height;

        /// <summary>
        /// Gets the x-coordinate of the right edge of the rectangle.
        /// </summary>
        public float Right => X + Width;

        /// <summary>
        /// Gets the x-coordinate of the left edge of the rectangle.
        /// </summary>
        public float Left => X;

        /// <summary>
        /// Gets a value indicating whether this <see cref="UIRect"/> is empty.
        /// </summary>
        public bool IsEmpty => (Width <= 0) || (Height <= 0);

        /// <summary>
        /// Gets or sets the size of the rectangle.
        /// </summary>
        public UIVector2 Size
        {
            get => new UIVector2(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// Gets or sets the location of the upper-left corner of the rectangle.
        /// </summary>
        public UIVector2 Location
        {
            get => new UIVector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets the center UIVector2 of the rectangle.
        /// </summary>
        public UIVector2 Center => new UIVector2(X + Width / 2, Y + Height / 2);

        /// <summary>
        /// Creates a new <see cref="UIRect"/> structure with the specified values.
        /// </summary>
        /// <param name="left">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="top">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="right">The x-coordinate of the lower-right corner of the rectangle.</param>
        /// <param name="bottom">The y-coordinate of the lower-right corner of the rectangle.</param>
        /// <returns>A new <see cref="UIRect"/> structure with the specified values.</returns>
        public static UIRect FromLTRB(float left, float top, float right, float bottom) => new UIRect(left, top, right - left, bottom - top);

        /// <summary>
        /// Indicates whether this instance and another specified <see cref="UIRect"/> structure are equal.
        /// </summary>
        /// <param name="other">The <see cref="UIRect"/> structure to compare with the current instance.</param>
        /// <returns>true if <paramref name="other"/> and this instance are equal; otherwise, false.</returns>
        public bool Equals(UIRect other) => X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return obj is UIRect rect && Equals(rect);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Compares two <see cref="UIRect"/> structures for equality.
        /// </summary>
        /// <param name="r1">The first <see cref="UIRect"/> structure to compare.</param>
        /// <param name="r2">The second <see cref="UIRect"/> structure to compare.</param>
        /// <returns>true if <paramref name="r1"/> and <paramref name="r2"/> are equal; otherwise, false.</returns>
        public static bool operator ==(UIRect r1, UIRect r2) => r1.Equals(r2);

        /// <summary>
        /// Compares two <see cref="UIRect"/> structures for inequality.
        /// </summary>
        /// <param name="r1">The first <see cref="UIRect"/> structure to compare.</param>
        /// <param name="r2">The second <see cref="UIRect"/> structure to compare.</param>
        /// <returns>true if <paramref name="r1"/> and <paramref name="r2"/> are not equal; otherwise, false.</returns>
        public static bool operator !=(UIRect r1, UIRect r2) => !(r1 == r2);

        // Hit Testing / Intersection / Union

        /// <summary>
        /// Checks if the specified rectangle is completely inside this rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to check.</param>
        /// <returns>True if the specified rectangle is completely inside this rectangle, otherwise false.</returns>
        public bool Contains(UIRect rect) => X <= rect.X && Right >= rect.Right && Y <= rect.Y && Bottom >= rect.Bottom;

        /// <summary>
        /// Indicates whether the specified UIVector2 is contained within the rectangular region defined by this <see cref="UIRect"/> structure.
        /// </summary>
        /// <param name="pt">The UIVector2 to test.</param>
        /// <returns>true if <paramref name="pt"/> is contained within the rectangular region defined by this <see cref="UIRect"/> structure; otherwise, false.</returns>
        public bool Contains(UIVector2 pt) => Contains(pt.X, pt.Y);

        /// <summary>
        /// Indicates whether the specified UIVector2 is contained within the rectangular region defined by this <see cref="UIRect"/> structure.
        /// </summary>
        /// <param name="x">The x-coordinate of the UIVector2 to test.</param>
        /// <param name="y">The y-coordinate of the UIVector2 to test.</param>
        /// <returns>true if <paramref name="x"/> and <paramref name="y"/> are contained within the rectangular region defined by this <see cref="UIRect"/> structure; otherwise, false.</returns>
        public bool Contains(float x, float y) => (x >= Left) && (x < Right) && (y >= Top) && (y < Bottom);

        /// <summary>
        /// Indicates whether the rectangular region represented by this <see cref="UIRect"/> intersects with the rectangular region represented by the specified <see cref="UIRect"/> structure.
        /// </summary>
        /// <param name="r">The <see cref="UIRect"/> structure to test for intersection.</param>
        /// <returns>true if the rectangular region represented by this <see cref="UIRect"/> intersects with the rectangular region represented by <paramref name="r"/>; otherwise, false.</returns>
        public bool IntersectsWith(UIRect r) => !((Left >= r.Right) || (Right <= r.Left) || (Top >= r.Bottom) || (Bottom <= r.Top));

        /// <summary>
        /// Returns a rectangle that represents the union of the current rectangle and the specified rectangle.
        /// </summary>
        /// <param name="r">The rectangle to combine with the current rectangle.</param>
        /// <returns>A new rectangle that represents the union of the current rectangle and the specified rectangle.</returns>
        public UIRect Union(UIRect r) => Union(this, r);

        /// <summary>
        /// Returns a rectangle that represents the union of the two given rectangles.
        /// </summary>
        /// <param name="r1">The first rectangle.</param>
        /// <param name="r2">The second rectangle.</param>
        /// <returns>A new rectangle that represents the union of the two given rectangles.</returns>
        public static UIRect Union(UIRect r1, UIRect r2) => FromLTRB(Math.Min(r1.Left, r2.Left), Math.Min(r1.Top, r2.Top), Math.Max(r1.Right, r2.Right), Math.Max(r1.Bottom, r2.Bottom));

        /// <summary>
        /// Returns a new rectangle that represents the intersection of the current rectangle and the specified rectangle.
        /// </summary>
        /// <param name="r">The rectangle to intersect with the current rectangle.</param>
        /// <returns>A new rectangle that represents the intersection of the current rectangle specified rectangle.</returns>
        public UIRect Intersect(UIRect r) => Intersect(this, r);

        /// <summary>
        /// Returns a new rectangle that represents the intersection of two given rectangles.
        /// </summary>
        /// <param name="r1">The first rectangle.</param>
        /// <param name="r2">The second rectangle.</param>
        /// <returns>A new rectangle representing the intersection of the two given rectangles.</returns>
        public static UIRect Intersect(UIRect r1, UIRect r2)
        {
            float x = Math.Max(r1.X, r2.X);
            float y = Math.Max(r1.Y, r2.Y);
            float width = Math.Min(r1.Right, r2.Right) - x;
            float height = Math.Min(r1.Bottom, r2.Bottom) - y;

            if (width < 0 || height < 0)
                return Zero;

            return new UIRect(x, y, width, height);
        }

        // Inflate and Offset

        /// <summary>
        /// Returns a new <see cref="UIRect"/> structure that has been inflated by the specified amount.
        /// </summary>
        /// <param name="sz">The size of the inflation.</param>
        /// <returns>A new <see cref="UIRect"/> structure that represents the inflated rectangle.</returns>
        public UIRect Inflate(UIVector2 sz) => Inflate(sz.Width, sz.Height);

        /// <summary>
        /// Inflates the current rectangle by the specified width and height.
        /// </summary>
        /// <param name="width">The amount to inflate the rectangle horizontally.</param>
        /// <param name="height">The amount to inflate the rectangle vertically.</param>
        /// <returns>A new rectangle that represents the inflated version of the current rectangle.</returns>
        public UIRect Inflate(float width, float height)
        {
            UIRect r = this;
            r.X -= width;
            r.Y -= height;
            r.Width += width * 2;
            r.Height += height * 2;
            return r;
        }

        /// <summary>
        /// Returns a new rectangle that is offset by the specified amount.
        /// </summary>
        /// <param name="dx">The horizontal offset.</param>
        /// <param name="dy">The vertical offset.</param>
        /// <returns>A new rectangle with the offset applied.</returns>
        public UIRect Offset(float dx, float dy)
        {
            UIRect r = this;
            r.X += dx;
            r.Y += dy;
            return r;
        }

        /// <summary>
        /// Returns a new UIRect that has been offset by the specified distance.
        /// </summary>
        /// <param name="dr">The distance to offset the UIRect.</param>
        /// <returns>A new UIRect that has been offset by the specified distance.</returns>
        public UIRect Offset(UIVector2 dr) => Offset(dr.X, dr.Y);

        /// <summary>
        /// Rounds the values of the X, Y, Width, and Height properties of the current UIRect object to the nearest whole number.
        /// </summary>
        /// <returns>A new UIRect object with the rounded values.</returns>
        public UIRect Round() => new UIRect((float)Math.Round(X), (float)Math.Round(Y), (float)Math.Round(Width), (float)Math.Round(Height));

        /// <summary>
        /// Deconstructs the UIRect object into its individual components (X, Y, Width, Height).
        /// </summary>
        /// <param name="x">The X coordinate of the rectangle.</param>
        /// <param name="y">The Y coordinate of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void Deconstruct(out float x, out float y, out float width, out float height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"{{X={X.ToString(CultureInfo.InvariantCulture)} Y={Y.ToString(CultureInfo.InvariantCulture)} Width={Width.ToString(CultureInfo.InvariantCulture)} Height={Height.ToString(CultureInfo.InvariantCulture)}}}";
    }
}