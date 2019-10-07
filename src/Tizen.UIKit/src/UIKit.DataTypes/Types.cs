#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit
{

namespace DataTypes
{

/// <summary>Eina unicode type</summary>
public struct Unicode
{
    private uint payload;

    /// <summary>Converts an instance of uint to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static implicit operator Unicode(uint value)
    {
        return new Unicode{payload=value};
    }

    /// <summary>Converts an instance of this struct to uint.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    public static implicit operator uint(Unicode value)
    {
        return value.payload;
    }
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>A rectangle in pixel dimensions.</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct Rect
{
    /// <summary>X coordinate of the rectangle, from the top-left corner.</summary>
    public int X;
    /// <summary>Y coordinate of the rectangle, from the top-left corner.</summary>
    public int Y;
    /// <summary>Width of the rectangle in pixels.</summary>
    public int W;
    /// <summary>Height of the rectangle in pixels.</summary>
    public int H;
    /// <summary>Constructor for Rect.</summary>
    /// <param name="X">X coordinate of the rectangle, from the top-left corner.</param>
    /// <param name="Y">Y coordinate of the rectangle, from the top-left corner.</param>
    /// <param name="W">Width of the rectangle in pixels.</param>
    /// <param name="H">Height of the rectangle in pixels.</param>
    public Rect(
        int X = default(int),
        int Y = default(int),
        int W = default(int),
        int H = default(int)    )
    {
        this.X = X;
        this.Y = Y;
        this.W = W;
        this.H = H;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Rect(IntPtr ptr)
    {
        var tmp = (Rect.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Rect.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Rect.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int X;
        
        public int Y;
        
        public int W;
        
        public int H;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Rect.NativeStruct(Rect _external_struct)
        {
            var _internal_struct = new Rect.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            _internal_struct.W = _external_struct.W;
            _internal_struct.H = _external_struct.H;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Rect(Rect.NativeStruct _internal_struct)
        {
            var _external_struct = new Rect();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            _external_struct.W = _internal_struct.W;
            _external_struct.H = _internal_struct.H;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>A 2D location in pixels.</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct Position2D
{
    /// <summary>X position in pixels, from the top-left corner.</summary>
    public int X;
    /// <summary>Y position in pixels, from the top-left corner.</summary>
    public int Y;
    /// <summary>Constructor for Position2D.</summary>
    /// <param name="X">X position in pixels, from the top-left corner.</param>
    /// <param name="Y">Y position in pixels, from the top-left corner.</param>
    public Position2D(
        int X = default(int),
        int Y = default(int)    )
    {
        this.X = X;
        this.Y = Y;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Position2D(IntPtr ptr)
    {
        var tmp = (Position2D.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Position2D.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Position2D.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int X;
        
        public int Y;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Position2D.NativeStruct(Position2D _external_struct)
        {
            var _internal_struct = new Position2D.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Position2D(Position2D.NativeStruct _internal_struct)
        {
            var _external_struct = new Position2D();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>A 2D size in pixels.</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct Size2D
{
    /// <summary>X position in pixels, from the top-left corner.</summary>
    public int W;
    /// <summary>Y position in pixels, from the top-left corner.</summary>
    public int H;
    /// <summary>Constructor for Size2D.</summary>
    /// <param name="W">X position in pixels, from the top-left corner.</param>
    /// <param name="H">Y position in pixels, from the top-left corner.</param>
    public Size2D(
        int W = default(int),
        int H = default(int)    )
    {
        this.W = W;
        this.H = H;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Size2D(IntPtr ptr)
    {
        var tmp = (Size2D.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Size2D.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Size2D.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int W;
        
        public int H;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Size2D.NativeStruct(Size2D _external_struct)
        {
            var _internal_struct = new Size2D.NativeStruct();
            _internal_struct.W = _external_struct.W;
            _internal_struct.H = _external_struct.H;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Size2D(Size2D.NativeStruct _internal_struct)
        {
            var _external_struct = new Size2D();
            _external_struct.W = _internal_struct.W;
            _external_struct.H = _internal_struct.H;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>Eina file data structure</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct File
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator File(IntPtr ptr)
    {
        var tmp = (File.NativeStruct)Marshal.PtrToStructure(ptr, typeof(File.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct File.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator File.NativeStruct(File _external_struct)
        {
            var _internal_struct = new File.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator File(File.NativeStruct _internal_struct)
        {
            var _external_struct = new File();
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>A simple 2D vector type using floating point values.</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct Vector2
{
    /// <summary>X coordinate.</summary>
    public double X;
    /// <summary>Y coordinate.</summary>
    public double Y;
    /// <summary>Constructor for Vector2.</summary>
    /// <param name="X">X coordinate.</param>
    /// <param name="Y">Y coordinate.</param>
    public Vector2(
        double X = default(double),
        double Y = default(double)    )
    {
        this.X = X;
        this.Y = Y;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Vector2(IntPtr ptr)
    {
        var tmp = (Vector2.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Vector2.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Vector2.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double X;
        
        public double Y;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Vector2.NativeStruct(Vector2 _external_struct)
        {
            var _internal_struct = new Vector2.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Vector2(Vector2.NativeStruct _internal_struct)
        {
            var _external_struct = new Vector2();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

namespace UIKit
{

namespace DataTypes
{

/// <summary>Eina 3x3 Matrix</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct Matrix3
{
    /// <summary>XX matrix value</summary>
    public double Xx;
    /// <summary>XY matrix value</summary>
    public double Xy;
    /// <summary>XZ matrix value</summary>
    public double Xz;
    /// <summary>YX matrix value</summary>
    public double Yx;
    /// <summary>YY matrix value</summary>
    public double Yy;
    /// <summary>YZ matrix value</summary>
    public double Yz;
    /// <summary>ZX matrix value</summary>
    public double Zx;
    /// <summary>ZY matrix value</summary>
    public double Zy;
    /// <summary>ZZ matrix value</summary>
    public double Zz;
    /// <summary>Constructor for Matrix3.</summary>
    /// <param name="Xx">XX matrix value</param>
    /// <param name="Xy">XY matrix value</param>
    /// <param name="Xz">XZ matrix value</param>
    /// <param name="Yx">YX matrix value</param>
    /// <param name="Yy">YY matrix value</param>
    /// <param name="Yz">YZ matrix value</param>
    /// <param name="Zx">ZX matrix value</param>
    /// <param name="Zy">ZY matrix value</param>
    /// <param name="Zz">ZZ matrix value</param>
    public Matrix3(
        double Xx = default(double),
        double Xy = default(double),
        double Xz = default(double),
        double Yx = default(double),
        double Yy = default(double),
        double Yz = default(double),
        double Zx = default(double),
        double Zy = default(double),
        double Zz = default(double)    )
    {
        this.Xx = Xx;
        this.Xy = Xy;
        this.Xz = Xz;
        this.Yx = Yx;
        this.Yy = Yy;
        this.Yz = Yz;
        this.Zx = Zx;
        this.Zy = Zy;
        this.Zz = Zz;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Matrix3(IntPtr ptr)
    {
        var tmp = (Matrix3.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Matrix3.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Matrix3.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Xx;
        
        public double Xy;
        
        public double Xz;
        
        public double Yx;
        
        public double Yy;
        
        public double Yz;
        
        public double Zx;
        
        public double Zy;
        
        public double Zz;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Matrix3.NativeStruct(Matrix3 _external_struct)
        {
            var _internal_struct = new Matrix3.NativeStruct();
            _internal_struct.Xx = _external_struct.Xx;
            _internal_struct.Xy = _external_struct.Xy;
            _internal_struct.Xz = _external_struct.Xz;
            _internal_struct.Yx = _external_struct.Yx;
            _internal_struct.Yy = _external_struct.Yy;
            _internal_struct.Yz = _external_struct.Yz;
            _internal_struct.Zx = _external_struct.Zx;
            _internal_struct.Zy = _external_struct.Zy;
            _internal_struct.Zz = _external_struct.Zz;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Matrix3(Matrix3.NativeStruct _internal_struct)
        {
            var _external_struct = new Matrix3();
            _external_struct.Xx = _internal_struct.Xx;
            _external_struct.Xy = _internal_struct.Xy;
            _external_struct.Xz = _internal_struct.Xz;
            _external_struct.Yx = _internal_struct.Yx;
            _external_struct.Yy = _internal_struct.Yy;
            _external_struct.Yz = _internal_struct.Yz;
            _external_struct.Zx = _internal_struct.Zx;
            _external_struct.Zy = _internal_struct.Zy;
            _external_struct.Zz = _internal_struct.Zz;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

}

