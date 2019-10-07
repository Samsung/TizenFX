#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Eina {

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

namespace Eina {

namespace Xattr {

/// <summary>Eina file extended attributes flags</summary>
[Efl.Eo.BindingEntity]
public enum Flags
{
/// <summary>This is the default behaviour, it will either create or replace the extended attribute</summary>
Insert = 0,
/// <summary>This will only succeed if the extended attribute previously existed</summary>
Replace = 1,
/// <summary>This will only succeed if the extended attribute wasn&apos;t previously set</summary>
Created = 2,
}
}
}

namespace Eina {

/// <summary>A rectangle in pixel dimensions.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>A 2D location in pixels.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>A 2D size in pixels.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>Eina file data structure</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>A simple 2D vector type using floating point values.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>Eina 3x3 Matrix</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
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

namespace Eina {

/// <summary>Eina file direct information data structure</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct FileDirectInfo
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator FileDirectInfo(IntPtr ptr)
    {
        var tmp = (FileDirectInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(FileDirectInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct FileDirectInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator FileDirectInfo.NativeStruct(FileDirectInfo _external_struct)
        {
            var _internal_struct = new FileDirectInfo.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator FileDirectInfo(FileDirectInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new FileDirectInfo();
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace Eina {

/// <summary>The structure to store some file statistics.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Stat
{
    /// <summary>The device where this file is located</summary>
    public uint Dev;
    /// <summary>The inode</summary>
    public uint Ino;
    /// <summary>The mode</summary>
    public uint Mode;
    /// <summary>The link number</summary>
    public uint Nlink;
    /// <summary>The owner user id</summary>
    public uint Uid;
    /// <summary>The owner group id</summary>
    public uint Gid;
    /// <summary>The remote device</summary>
    public uint Rdev;
    /// <summary>The file size in bytes</summary>
    public uint Size;
    /// <summary>The block size in bytes</summary>
    public uint Blksize;
    /// <summary>The number of blocks allocated</summary>
    public uint Blocks;
    /// <summary>The tilestamp when the file was last accessed</summary>
    public uint Atime;
    /// <summary>The nano version of the timestmap when the file was last accessed</summary>
    public uint Atimensec;
    /// <summary>The tilestamp when the file was modified</summary>
    public uint Mtime;
    /// <summary>The nano version of the timestmap when the file was modified</summary>
    public uint Mtimensec;
    /// <summary>The tilestamp when the file was created</summary>
    public uint Ctime;
    /// <summary>The nano version of the timestmap when the file was created</summary>
    public uint Ctimensec;
    /// <summary>Constructor for Stat.</summary>
    /// <param name="Dev">The device where this file is located</param>
    /// <param name="Ino">The inode</param>
    /// <param name="Mode">The mode</param>
    /// <param name="Nlink">The link number</param>
    /// <param name="Uid">The owner user id</param>
    /// <param name="Gid">The owner group id</param>
    /// <param name="Rdev">The remote device</param>
    /// <param name="Size">The file size in bytes</param>
    /// <param name="Blksize">The block size in bytes</param>
    /// <param name="Blocks">The number of blocks allocated</param>
    /// <param name="Atime">The tilestamp when the file was last accessed</param>
    /// <param name="Atimensec">The nano version of the timestmap when the file was last accessed</param>
    /// <param name="Mtime">The tilestamp when the file was modified</param>
    /// <param name="Mtimensec">The nano version of the timestmap when the file was modified</param>
    /// <param name="Ctime">The tilestamp when the file was created</param>
    /// <param name="Ctimensec">The nano version of the timestmap when the file was created</param>
    public Stat(
        uint Dev = default(uint),
        uint Ino = default(uint),
        uint Mode = default(uint),
        uint Nlink = default(uint),
        uint Uid = default(uint),
        uint Gid = default(uint),
        uint Rdev = default(uint),
        uint Size = default(uint),
        uint Blksize = default(uint),
        uint Blocks = default(uint),
        uint Atime = default(uint),
        uint Atimensec = default(uint),
        uint Mtime = default(uint),
        uint Mtimensec = default(uint),
        uint Ctime = default(uint),
        uint Ctimensec = default(uint)    )
    {
        this.Dev = Dev;
        this.Ino = Ino;
        this.Mode = Mode;
        this.Nlink = Nlink;
        this.Uid = Uid;
        this.Gid = Gid;
        this.Rdev = Rdev;
        this.Size = Size;
        this.Blksize = Blksize;
        this.Blocks = Blocks;
        this.Atime = Atime;
        this.Atimensec = Atimensec;
        this.Mtime = Mtime;
        this.Mtimensec = Mtimensec;
        this.Ctime = Ctime;
        this.Ctimensec = Ctimensec;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Stat(IntPtr ptr)
    {
        var tmp = (Stat.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Stat.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Stat.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Dev;
        
        public uint Ino;
        
        public uint Mode;
        
        public uint Nlink;
        
        public uint Uid;
        
        public uint Gid;
        
        public uint Rdev;
        
        public uint Size;
        
        public uint Blksize;
        
        public uint Blocks;
        
        public uint Atime;
        
        public uint Atimensec;
        
        public uint Mtime;
        
        public uint Mtimensec;
        
        public uint Ctime;
        
        public uint Ctimensec;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Stat.NativeStruct(Stat _external_struct)
        {
            var _internal_struct = new Stat.NativeStruct();
            _internal_struct.Dev = _external_struct.Dev;
            _internal_struct.Ino = _external_struct.Ino;
            _internal_struct.Mode = _external_struct.Mode;
            _internal_struct.Nlink = _external_struct.Nlink;
            _internal_struct.Uid = _external_struct.Uid;
            _internal_struct.Gid = _external_struct.Gid;
            _internal_struct.Rdev = _external_struct.Rdev;
            _internal_struct.Size = _external_struct.Size;
            _internal_struct.Blksize = _external_struct.Blksize;
            _internal_struct.Blocks = _external_struct.Blocks;
            _internal_struct.Atime = _external_struct.Atime;
            _internal_struct.Atimensec = _external_struct.Atimensec;
            _internal_struct.Mtime = _external_struct.Mtime;
            _internal_struct.Mtimensec = _external_struct.Mtimensec;
            _internal_struct.Ctime = _external_struct.Ctime;
            _internal_struct.Ctimensec = _external_struct.Ctimensec;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Stat(Stat.NativeStruct _internal_struct)
        {
            var _external_struct = new Stat();
            _external_struct.Dev = _internal_struct.Dev;
            _external_struct.Ino = _internal_struct.Ino;
            _external_struct.Mode = _internal_struct.Mode;
            _external_struct.Nlink = _internal_struct.Nlink;
            _external_struct.Uid = _internal_struct.Uid;
            _external_struct.Gid = _internal_struct.Gid;
            _external_struct.Rdev = _internal_struct.Rdev;
            _external_struct.Size = _internal_struct.Size;
            _external_struct.Blksize = _internal_struct.Blksize;
            _external_struct.Blocks = _internal_struct.Blocks;
            _external_struct.Atime = _internal_struct.Atime;
            _external_struct.Atimensec = _internal_struct.Atimensec;
            _external_struct.Mtime = _internal_struct.Mtime;
            _external_struct.Mtimensec = _internal_struct.Mtimensec;
            _external_struct.Ctime = _internal_struct.Ctime;
            _external_struct.Ctimensec = _internal_struct.Ctimensec;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

