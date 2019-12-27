/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.DataTypes
{
/// <summary>Eina unicode type.</summary>
/// <since_tizen> 6 </since_tizen>
public struct Unicode : IEquatable<Unicode>
{
    private uint payload;

    /// <summary>Converts an instance of uint to this struct.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator Unicode(uint value)
    {
        return new Unicode{payload=value};
    }

    /// <summary>Converts an instance of this struct to uint.
    /// </summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator uint(Unicode value)
    {
        return value.payload;
    }
    /// <summary>Converts an instance of uint to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static Unicode FromUInt32(uint value)
    {
        return value;
    }

    /// <summary>Converts an instance of this struct to uint.</summary>
    /// <returns>The actual value the alias is wrapping.</returns>
    public uint ToUInt32()
    {
        return this;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode() => payload.GetHashCode();
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Unicode other) => payload == other.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Unicode) ? Equals((Unicode)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Unicode lhs, Unicode rhs)
        => lhs.payload == rhs.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Unicode lhs, Unicode rhs)
        => lhs.payload != rhs.payload;
}
}

namespace CoreUI.DataTypes
{
    /// <summary>A rectangle in pixel dimensions.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Rect : IEquatable<Rect>
    {
        
        private int x;
        
        private int y;
        
        private int w;
        
        private int h;

        /// <summary>X coordinate of the rectangle, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int X { get => x; }
        /// <summary>Y coordinate of the rectangle, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Y { get => y; }
        /// <summary>Width of the rectangle in pixels.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int W { get => w; }
        /// <summary>Height of the rectangle in pixels.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int H { get => h; }
        /// <summary>Constructor for Rect.
        /// </summary>
        /// <param name="x">X coordinate of the rectangle, from the top-left corner.</param>
        /// <param name="y">Y coordinate of the rectangle, from the top-left corner.</param>
        /// <param name="w">Width of the rectangle in pixels.</param>
        /// <param name="h">Height of the rectangle in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public Rect(
            int x = default(int),
            int y = default(int),
            int w = default(int),
            int h = default(int))
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        /// <summary>Packs tuple into Rect object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator Rect((int x, int y, int w, int h) tuple)
            => new Rect(tuple.x, tuple.y, tuple.w, tuple.h);

        /// <summary>Unpacks Rect into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int x,
            out int y,
            out int w,
            out int h
        )
        {
            x = this.X;
            y = this.Y;
            w = this.W;
            h = this.H;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            hash = hash * 23 + W.GetHashCode();
            hash = hash * 23 + H.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Rect other)
        {
            return X == other.X && Y == other.Y && W == other.W && H == other.H;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Rect) ? Equals((Rect)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Rect lhs, Rect rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Rect lhs, Rect rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Rect(IntPtr ptr)
        {
            return (Rect)Marshal.PtrToStructure(ptr, typeof(Rect));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Rect FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A 2D location in pixels.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Position2D : IEquatable<Position2D>
    {
        
        private int x;
        
        private int y;

        /// <summary>X position in pixels, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int X { get => x; }
        /// <summary>Y position in pixels, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Y { get => y; }
        /// <summary>Constructor for Position2D.
        /// </summary>
        /// <param name="x">X position in pixels, from the top-left corner.</param>
        /// <param name="y">Y position in pixels, from the top-left corner.</param>
        /// <since_tizen> 6 </since_tizen>
        public Position2D(
            int x = default(int),
            int y = default(int))
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>Packs tuple into Position2D object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator Position2D((int x, int y) tuple)
            => new Position2D(tuple.x, tuple.y);

        /// <summary>Unpacks Position2D into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int x,
            out int y
        )
        {
            x = this.X;
            y = this.Y;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Position2D other)
        {
            return X == other.X && Y == other.Y;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Position2D) ? Equals((Position2D)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Position2D lhs, Position2D rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Position2D lhs, Position2D rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Position2D(IntPtr ptr)
        {
            return (Position2D)Marshal.PtrToStructure(ptr, typeof(Position2D));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Position2D FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A 2D size in pixels.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Size2D : IEquatable<Size2D>
    {
        
        private int w;
        
        private int h;

        /// <summary>X position in pixels, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int W { get => w; }
        /// <summary>Y position in pixels, from the top-left corner.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int H { get => h; }
        /// <summary>Constructor for Size2D.
        /// </summary>
        /// <param name="w">X position in pixels, from the top-left corner.</param>
        /// <param name="h">Y position in pixels, from the top-left corner.</param>
        /// <since_tizen> 6 </since_tizen>
        public Size2D(
            int w = default(int),
            int h = default(int))
        {
            this.w = w;
            this.h = h;
        }

        /// <summary>Packs tuple into Size2D object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator Size2D((int w, int h) tuple)
            => new Size2D(tuple.w, tuple.h);

        /// <summary>Unpacks Size2D into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int w,
            out int h
        )
        {
            w = this.W;
            h = this.H;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + W.GetHashCode();
            hash = hash * 23 + H.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Size2D other)
        {
            return W == other.W && H == other.H;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Size2D) ? Equals((Size2D)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Size2D lhs, Size2D rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Size2D lhs, Size2D rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Size2D(IntPtr ptr)
        {
            return (Size2D)Marshal.PtrToStructure(ptr, typeof(Size2D));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Size2D FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>Eina file data structure</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct File : IEquatable<File>
    {
        /// <summary>Placeholder field</summary>
        private IntPtr field;

        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            return field.GetHashCode();
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(File other)
        {
            return field.Equals(other.field);
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is File) ? Equals((File)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(File lhs, File rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(File lhs, File rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator File(IntPtr ptr)
        {
            return (File)Marshal.PtrToStructure(ptr, typeof(File));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static File FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A simple 2D vector type using floating point values.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Vector2 : IEquatable<Vector2>
    {
        
        private double x;
        
        private double y;

        /// <summary>X coordinate.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double X { get => x; }
        /// <summary>Y coordinate.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Y { get => y; }
        /// <summary>Constructor for Vector2.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <since_tizen> 6 </since_tizen>
        public Vector2(
            double x = default(double),
            double y = default(double))
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>Packs tuple into Vector2 object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator Vector2((double x, double y) tuple)
            => new Vector2(tuple.x, tuple.y);

        /// <summary>Unpacks Vector2 into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out double x,
            out double y
        )
        {
            x = this.X;
            y = this.Y;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Vector2) ? Equals((Vector2)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Vector2(IntPtr ptr)
        {
            return (Vector2)Marshal.PtrToStructure(ptr, typeof(Vector2));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Vector2 FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A bidimensional array of floating point values with 3 rows and 3 columns.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Matrix3 : IEquatable<Matrix3>
    {
        
        private double xx;
        
        private double xy;
        
        private double xz;
        
        private double yx;
        
        private double yy;
        
        private double yz;
        
        private double zx;
        
        private double zy;
        
        private double zz;

        /// <summary>XX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xx { get => xx; }
        /// <summary>XY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xy { get => xy; }
        /// <summary>XZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xz { get => xz; }
        /// <summary>YX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yx { get => yx; }
        /// <summary>YY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yy { get => yy; }
        /// <summary>YZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yz { get => yz; }
        /// <summary>ZX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zx { get => zx; }
        /// <summary>ZY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zy { get => zy; }
        /// <summary>ZZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zz { get => zz; }
        /// <summary>Constructor for Matrix3.
        /// </summary>
        /// <param name="xx">XX value.</param>
        /// <param name="xy">XY value.</param>
        /// <param name="xz">XZ value.</param>
        /// <param name="yx">YX value.</param>
        /// <param name="yy">YY value.</param>
        /// <param name="yz">YZ value.</param>
        /// <param name="zx">ZX value.</param>
        /// <param name="zy">ZY value.</param>
        /// <param name="zz">ZZ value.</param>
        /// <since_tizen> 6 </since_tizen>
        public Matrix3(
            double xx = default(double),
            double xy = default(double),
            double xz = default(double),
            double yx = default(double),
            double yy = default(double),
            double yz = default(double),
            double zx = default(double),
            double zy = default(double),
            double zz = default(double))
        {
            this.xx = xx;
            this.xy = xy;
            this.xz = xz;
            this.yx = yx;
            this.yy = yy;
            this.yz = yz;
            this.zx = zx;
            this.zy = zy;
            this.zz = zz;
        }

        /// <summary>Unpacks Matrix3 into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out double xx,
            out double xy,
            out double xz,
            out double yx,
            out double yy,
            out double yz,
            out double zx,
            out double zy,
            out double zz
        )
        {
            xx = this.Xx;
            xy = this.Xy;
            xz = this.Xz;
            yx = this.Yx;
            yy = this.Yy;
            yz = this.Yz;
            zx = this.Zx;
            zy = this.Zy;
            zz = this.Zz;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Xx.GetHashCode();
            hash = hash * 23 + Xy.GetHashCode();
            hash = hash * 23 + Xz.GetHashCode();
            hash = hash * 23 + Yx.GetHashCode();
            hash = hash * 23 + Yy.GetHashCode();
            hash = hash * 23 + Yz.GetHashCode();
            hash = hash * 23 + Zx.GetHashCode();
            hash = hash * 23 + Zy.GetHashCode();
            hash = hash * 23 + Zz.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Matrix3 other)
        {
            return Xx == other.Xx && Xy == other.Xy && Xz == other.Xz && Yx == other.Yx && Yy == other.Yy && Yz == other.Yz && Zx == other.Zx && Zy == other.Zy && Zz == other.Zz;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Matrix3) ? Equals((Matrix3)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Matrix3(IntPtr ptr)
        {
            return (Matrix3)Marshal.PtrToStructure(ptr, typeof(Matrix3));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Matrix3 FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A bidimensional array of floating point values with 4 rows and 4 columns.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Matrix4 : IEquatable<Matrix4>
    {
        
        private double xx;
        
        private double xy;
        
        private double xz;
        
        private double xw;
        
        private double yx;
        
        private double yy;
        
        private double yz;
        
        private double yw;
        
        private double zx;
        
        private double zy;
        
        private double zz;
        
        private double zw;
        
        private double wx;
        
        private double wy;
        
        private double wz;
        
        private double ww;

        /// <summary>XX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xx { get => xx; }
        /// <summary>XY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xy { get => xy; }
        /// <summary>XZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xz { get => xz; }
        /// <summary>XW value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Xw { get => xw; }
        /// <summary>YX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yx { get => yx; }
        /// <summary>YY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yy { get => yy; }
        /// <summary>YZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yz { get => yz; }
        /// <summary>YW value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Yw { get => yw; }
        /// <summary>ZX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zx { get => zx; }
        /// <summary>ZY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zy { get => zy; }
        /// <summary>ZZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zz { get => zz; }
        /// <summary>ZW value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Zw { get => zw; }
        /// <summary>WX value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Wx { get => wx; }
        /// <summary>WY value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Wy { get => wy; }
        /// <summary>WZ value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Wz { get => wz; }
        /// <summary>WW value.</summary>
        /// <since_tizen> 6 </since_tizen>
        public double Ww { get => ww; }
        /// <summary>Constructor for Matrix4.
        /// </summary>
        /// <param name="xx">XX value.</param>
        /// <param name="xy">XY value.</param>
        /// <param name="xz">XZ value.</param>
        /// <param name="xw">XW value.</param>
        /// <param name="yx">YX value.</param>
        /// <param name="yy">YY value.</param>
        /// <param name="yz">YZ value.</param>
        /// <param name="yw">YW value.</param>
        /// <param name="zx">ZX value.</param>
        /// <param name="zy">ZY value.</param>
        /// <param name="zz">ZZ value.</param>
        /// <param name="zw">ZW value.</param>
        /// <param name="wx">WX value.</param>
        /// <param name="wy">WY value.</param>
        /// <param name="wz">WZ value.</param>
        /// <param name="ww">WW value.</param>
        /// <since_tizen> 6 </since_tizen>
        public Matrix4(
            double xx = default(double),
            double xy = default(double),
            double xz = default(double),
            double xw = default(double),
            double yx = default(double),
            double yy = default(double),
            double yz = default(double),
            double yw = default(double),
            double zx = default(double),
            double zy = default(double),
            double zz = default(double),
            double zw = default(double),
            double wx = default(double),
            double wy = default(double),
            double wz = default(double),
            double ww = default(double))
        {
            this.xx = xx;
            this.xy = xy;
            this.xz = xz;
            this.xw = xw;
            this.yx = yx;
            this.yy = yy;
            this.yz = yz;
            this.yw = yw;
            this.zx = zx;
            this.zy = zy;
            this.zz = zz;
            this.zw = zw;
            this.wx = wx;
            this.wy = wy;
            this.wz = wz;
            this.ww = ww;
        }

        /// <summary>Unpacks Matrix4 into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out double xx,
            out double xy,
            out double xz,
            out double xw,
            out double yx,
            out double yy,
            out double yz,
            out double yw,
            out double zx,
            out double zy,
            out double zz,
            out double zw,
            out double wx,
            out double wy,
            out double wz,
            out double ww
        )
        {
            xx = this.Xx;
            xy = this.Xy;
            xz = this.Xz;
            xw = this.Xw;
            yx = this.Yx;
            yy = this.Yy;
            yz = this.Yz;
            yw = this.Yw;
            zx = this.Zx;
            zy = this.Zy;
            zz = this.Zz;
            zw = this.Zw;
            wx = this.Wx;
            wy = this.Wy;
            wz = this.Wz;
            ww = this.Ww;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Xx.GetHashCode();
            hash = hash * 23 + Xy.GetHashCode();
            hash = hash * 23 + Xz.GetHashCode();
            hash = hash * 23 + Xw.GetHashCode();
            hash = hash * 23 + Yx.GetHashCode();
            hash = hash * 23 + Yy.GetHashCode();
            hash = hash * 23 + Yz.GetHashCode();
            hash = hash * 23 + Yw.GetHashCode();
            hash = hash * 23 + Zx.GetHashCode();
            hash = hash * 23 + Zy.GetHashCode();
            hash = hash * 23 + Zz.GetHashCode();
            hash = hash * 23 + Zw.GetHashCode();
            hash = hash * 23 + Wx.GetHashCode();
            hash = hash * 23 + Wy.GetHashCode();
            hash = hash * 23 + Wz.GetHashCode();
            hash = hash * 23 + Ww.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Matrix4 other)
        {
            return Xx == other.Xx && Xy == other.Xy && Xz == other.Xz && Xw == other.Xw && Yx == other.Yx && Yy == other.Yy && Yz == other.Yz && Yw == other.Yw && Zx == other.Zx && Zy == other.Zy && Zz == other.Zz && Zw == other.Zw && Wx == other.Wx && Wy == other.Wy && Wz == other.Wz && Ww == other.Ww;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Matrix4) ? Equals((Matrix4)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Matrix4 lhs, Matrix4 rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Matrix4 lhs, Matrix4 rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Matrix4(IntPtr ptr)
        {
            return (Matrix4)Marshal.PtrToStructure(ptr, typeof(Matrix4));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Matrix4 FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.DataTypes
{
    /// <summary>A range sequence of values.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Range : IEquatable<Range>
    {
        
        private uint start;
        
        private uint length;

        /// <summary>Start of the range.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Start { get => start; }
        /// <summary>Length of the range.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Length { get => length; }
        /// <summary>Constructor for Range.
        /// </summary>
        /// <param name="start">Start of the range.</param>
        /// <param name="length">Length of the range.</param>
        /// <since_tizen> 6 </since_tizen>
        public Range(
            uint start = default(uint),
            uint length = default(uint))
        {
            this.start = start;
            this.length = length;
        }

        /// <summary>Packs tuple into Range object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator Range((uint start, uint length) tuple)
            => new Range(tuple.start, tuple.length);

        /// <summary>Unpacks Range into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint start,
            out uint length
        )
        {
            start = this.Start;
            length = this.Length;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Start.GetHashCode();
            hash = hash * 23 + Length.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Range other)
        {
            return Start == other.Start && Length == other.Length;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Range) ? Equals((Range)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Range lhs, Range rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Range lhs, Range rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Range(IntPtr ptr)
        {
            return (Range)Marshal.PtrToStructure(ptr, typeof(Range));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Range FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

