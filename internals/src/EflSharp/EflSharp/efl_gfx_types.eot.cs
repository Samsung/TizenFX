#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Font { 
public struct Size {
   private  int payload;
   public static implicit operator Size( int x)
   {
      return new Size{payload=x};
   }
   public static implicit operator  int(Size x)
   {
      return x.payload;
   }
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Graphics colorspace type</summary>
public enum Colorspace
{
/// <summary>ARGB 32 bits per pixel, high-byte is Alpha, accessed one 32bit word at a time.</summary>
Argb8888 = 0,
/// <summary>YCbCr 4:2:2 Planar, ITU.BT-601 specifications. The data pointed to is just an array of row pointer, pointing to the Y rows, then the Cb, then Cr rows.</summary>
Ycbcr422p601Pl = 1,
/// <summary>YCbCr 4:2:2 Planar, ITU.BT-709 specifications. The data pointed to is just an array of row pointer, pointing to the Y rows, then the Cb, then Cr rows.</summary>
Ycbcr422p709Pl = 2,
/// <summary>16bit rgb565 + Alpha plane at end - 5 bits of the 8 being used per alpha byte.</summary>
Rgb565A5p = 3,
/// <summary>8-bit gray image, or alpha only.</summary>
Gry8 = 4,
/// <summary>YCbCr 4:2:2, ITU.BT-601 specifications. The data pointed to is just an array of row pointer, pointing to line of Y,Cb,Y,Cr bytes.</summary>
Ycbcr422601Pl = 5,
/// <summary>YCbCr 4:2:0, ITU.BT-601 specifications. The data pointed to is just an array of row pointer, pointing to the Y rows, then the Cb,Cr rows..</summary>
Ycbcr420nv12601Pl = 6,
/// <summary>YCbCr 4:2:0, ITU.BT-601 specifications. The data pointed to is just an array of tiled row pointer, pointing to the Y rows, then the Cb,Cr rows..</summary>
Ycbcr420tm12601Pl = 7,
/// <summary>AY 8bits Alpha and 8bits Grey, accessed 1 16bits at a time.</summary>
Agry88 = 8,
/// <summary>OpenGL ETC1 encoding of RGB texture (4 bit per pixel)
/// 1.10.</summary>
Etc1 = 9,
/// <summary>OpenGL GL_COMPRESSED_RGB8_ETC2 texture compression format (4 bit per pixel)
/// 1.10.</summary>
Rgb8Etc2 = 10,
/// <summary>OpenGL GL_COMPRESSED_RGBA8_ETC2_EAC texture compression format, supports alpha (8 bit per pixel)
/// 1.10.</summary>
Rgba8Etc2Eac = 11,
/// <summary>ETC1 with alpha support using two planes: ETC1 RGB and ETC1 grey for alpha
/// 1.11.</summary>
Etc1Alpha = 12,
/// <summary>OpenGL COMPRESSED_RGB_S3TC_DXT1_EXT format with RGB only.
/// 1.11.</summary>
RgbS3tcDxt1 = 13,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT1_EXT format with RGBA punchthrough.
/// 1.11.</summary>
RgbaS3tcDxt1 = 14,
/// <summary>DirectDraw DXT2 format with premultiplied RGBA. Not supported by OpenGL itself.
/// 1.11.</summary>
RgbaS3tcDxt2 = 15,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT3_EXT format with RGBA.
/// 1.11.</summary>
RgbaS3tcDxt3 = 16,
/// <summary>DirectDraw DXT4 format with premultiplied RGBA. Not supported by OpenGL itself.
/// 1.11.</summary>
RgbaS3tcDxt4 = 17,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT5_EXT format with RGBA.
/// 1.11.</summary>
RgbaS3tcDxt5 = 18,
/// <summary></summary>
Palette = 19,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Graphics render operation mode</summary>
public enum RenderOp
{
/// <summary>Alpha blending onto destination (default); d = d*(1-sa) + s.</summary>
Blend = 0,
/// <summary>Copy source to destination; d = s.</summary>
Copy = 1,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 2,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>These values determine how the points are interpreted in a stream of points.
/// 1.14</summary>
public enum PathCommandType
{
/// <summary>The end of stream , no more points to process.</summary>
End = 0,
/// <summary>The next point is the start point of a sub path.</summary>
MoveTo = 1,
/// <summary>The next point is used to draw a line from current point.</summary>
LineTo = 2,
/// <summary>The next three point is used to draw a cubic bezier curve from current point.</summary>
CubicTo = 3,
/// <summary>Close the current subpath by drawing a line between current point and the first point of current subpath.</summary>
Close = 4,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 5,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>These values determine how the end of opened sub-paths are rendered in a stroke. <see cref="Efl.Gfx.Shape.SetStrokeCap"/>
/// 1.14</summary>
public enum Cap
{
/// <summary>The end of lines is rendered as a full stop on the last point itself.</summary>
Butt = 0,
/// <summary>The end of lines is rendered as a half-circle around the last point.</summary>
Round = 1,
/// <summary>The end of lines is rendered as a square around the last point.</summary>
Square = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 3,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>These values determine how two joining lines are rendered in a stroker. <see cref="Efl.Gfx.Shape.SetStrokeJoin"/>
/// 1.14</summary>
public enum Join
{
/// <summary>Used to render rounded line joins. Circular arcs are used to join two lines smoothly.</summary>
Miter = 0,
/// <summary>Used to render beveled line joins. The outer corner of the joined lines is filled by enclosing the triangular region of the corner with a straight line between the outer corners of each stroke.</summary>
Round = 1,
/// <summary>Used to render mitered line joins. The intersection of the strokes is clipped at a line perpendicular to the bisector of the angle between the strokes, at the distance from the intersection of the segments equal to the product of the miter limit value and the border radius.  This prevents long spikes being created.</summary>
Bevel = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 3,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Specifies how the area outside the gradient area should be filled. <see cref="Efl.Gfx.Gradient.SetSpread"/>
/// 1.14</summary>
public enum GradientSpread
{
/// <summary>The area is filled with the closest stop color. This is the default.</summary>
Pad = 0,
/// <summary>The gradient is reflected outside the gradient area.</summary>
Reflect = 1,
/// <summary>The gradient is repeated outside the gradient area.</summary>
Repeat = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 3,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Type defining how an image content get filled.
/// 1.14</summary>
public enum FillRule
{
/// <summary>Draw a horizontal line from the point to a location outside the shape. Determine whether the direction of the line at each intersection point is up or down. The winding number is determined by summing the direction of each intersection. If the number is non zero, the point is inside the shape. This mode is the default</summary>
Winding = 0,
/// <summary>Draw a horizontal line from the point to a location outside the shape, and count the number of intersections. If the number of intersections is an odd number, the point is inside the shape.</summary>
OddEven = 1,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>How an image&apos;s center region (the complement to the border region) should be rendered by EFL</summary>
public enum BorderFillMode
{
/// <summary>Image&apos;s center region is <c>not</c> to be rendered</summary>
None = 0,
/// <summary>Image&apos;s center region is to be <c>blended</c> with objects underneath it, if it has transparency. This is the default behavior for image objects</summary>
Default = 1,
/// <summary>Image&apos;s center region is to be made solid, even if it has transparency on it</summary>
Solid = 2,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>What property got changed for this object
/// 1.18</summary>
public enum ChangeFlag
{
/// <summary>No change</summary>
None = 0,
/// <summary>matrix got changed</summary>
Matrix = 1,
/// <summary>path got changes</summary>
Path = 2,
/// <summary>coloring or fill information changed, not geometry</summary>
Fill = 4,
/// <summary>all properties got changed</summary>
All = 65535,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Aspect types/policies for scaling size hints.
/// See also <see cref="Efl.Gfx.SizeHint.GetHintAspect"/>.</summary>
public enum SizeHintAspect
{
/// <summary>No preference on either direction of the container for aspect ratio control.</summary>
None = 0,
/// <summary>Same effect as disabling aspect ratio preference</summary>
Neither = 1,
/// <summary>Use all horizontal container space to place an object, using the given aspect.</summary>
Horizontal = 2,
/// <summary>Use all vertical container space to place an object, using the given aspect.</summary>
Vertical = 3,
/// <summary>Use all horizontal and vertical container spaces to place an object (never growing it out of those bounds), using the given aspect.</summary>
Both = 4,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Image or Edje load error type</summary>
public enum ImageLoadError
{
/// <summary>No error on load</summary>
None = 0,
/// <summary>A non-specific error occurred</summary>
Generic = 1,
/// <summary>File (or file path) does not exist</summary>
DoesNotExist = 2,
/// <summary>Permission denied to an existing file (or path)</summary>
PermissionDenied = 3,
/// <summary>Allocation of resources failure prevented load</summary>
ResourceAllocationFailed = 4,
/// <summary>File corrupt (but was detected as a known format)</summary>
CorruptFile = 5,
/// <summary>File is not a known format</summary>
UnknownFormat = 6,
/// <summary>Reading operation has been cancelled during decoding</summary>
Cancelled = 7,
/// <summary>(Edje only) The file pointed to is incompatible, i.e., it doesn&apos;t match the library&apos;s current version&apos;s format.</summary>
IncompatibleFile = 8,
/// <summary>(Edje only) The group/collection set to load from was not found in the file</summary>
UnknownCollection = 9,
/// <summary>(Edje only) The group/collection set to load from had recursive references on its components</summary>
RecursiveReference = 10,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Color Class layer enum</summary>
public enum ColorClassLayer
{
/// <summary>Default color</summary>
Normal = 0,
/// <summary>Outline color</summary>
Outline = 1,
/// <summary>Shadow color</summary>
Shadow = 2,
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Type describing dash. <see cref="Efl.Gfx.Shape.GetStrokeDash"/>
/// 1.14</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Dash
{
   /// <summary>Dash drawing length.</summary>
   public double Length;
   /// <summary>Distance between two dashes.</summary>
   public double Gap;
   ///<summary>Constructor for Dash.</summary>
   public Dash(
      double Length=default(double),
      double Gap=default(double)   )
   {
      this.Length = Length;
      this.Gap = Gap;
   }
public static implicit operator Dash(IntPtr ptr)
   {
      var tmp = (Dash_StructInternal)Marshal.PtrToStructure(ptr, typeof(Dash_StructInternal));
      return Dash_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Dash.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Dash_StructInternal
{
   
   public double Length;
   
   public double Gap;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Dash(Dash_StructInternal struct_)
   {
      return Dash_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Dash_StructInternal(Dash struct_)
   {
      return Dash_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Dash</summary>
public static class Dash_StructConversion
{
   internal static Dash_StructInternal ToInternal(Dash _external_struct)
   {
      var _internal_struct = new Dash_StructInternal();

      _internal_struct.Length = _external_struct.Length;
      _internal_struct.Gap = _external_struct.Gap;

      return _internal_struct;
   }

   internal static Dash ToManaged(Dash_StructInternal _internal_struct)
   {
      var _external_struct = new Dash();

      _external_struct.Length = _internal_struct.Length;
      _external_struct.Gap = _internal_struct.Gap;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Type defining gradient stops. Describes the location and color of a transition point in a gradient.
/// 1.14</summary>
[StructLayout(LayoutKind.Sequential)]
public struct GradientStop
{
   /// <summary>The location of the gradient stop within the gradient vector</summary>
   public double Offset;
   /// <summary>The component R color of the gradient stop</summary>
   public  int R;
   /// <summary>The component G color of the gradient stop</summary>
   public  int G;
   /// <summary>The component B color of the gradient stop</summary>
   public  int B;
   /// <summary>The component A color of the gradient stop</summary>
   public  int A;
   ///<summary>Constructor for GradientStop.</summary>
   public GradientStop(
      double Offset=default(double),
       int R=default( int),
       int G=default( int),
       int B=default( int),
       int A=default( int)   )
   {
      this.Offset = Offset;
      this.R = R;
      this.G = G;
      this.B = B;
      this.A = A;
   }
public static implicit operator GradientStop(IntPtr ptr)
   {
      var tmp = (GradientStop_StructInternal)Marshal.PtrToStructure(ptr, typeof(GradientStop_StructInternal));
      return GradientStop_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct GradientStop.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct GradientStop_StructInternal
{
   
   public double Offset;
   
   public  int R;
   
   public  int G;
   
   public  int B;
   
   public  int A;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator GradientStop(GradientStop_StructInternal struct_)
   {
      return GradientStop_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator GradientStop_StructInternal(GradientStop struct_)
   {
      return GradientStop_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct GradientStop</summary>
public static class GradientStop_StructConversion
{
   internal static GradientStop_StructInternal ToInternal(GradientStop _external_struct)
   {
      var _internal_struct = new GradientStop_StructInternal();

      _internal_struct.Offset = _external_struct.Offset;
      _internal_struct.R = _external_struct.R;
      _internal_struct.G = _external_struct.G;
      _internal_struct.B = _external_struct.B;
      _internal_struct.A = _external_struct.A;

      return _internal_struct;
   }

   internal static GradientStop ToManaged(GradientStop_StructInternal _internal_struct)
   {
      var _external_struct = new GradientStop();

      _external_struct.Offset = _internal_struct.Offset;
      _external_struct.R = _internal_struct.R;
      _external_struct.G = _internal_struct.G;
      _external_struct.B = _internal_struct.B;
      _external_struct.A = _internal_struct.A;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Internal structure for <see cref="Efl.Gfx.Stroke"/>.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StrokeColor
{
   /// <summary>The component R color of the stroke</summary>
   public  int R;
   /// <summary>The component G color of the stroke</summary>
   public  int G;
   /// <summary>The component B color of the stroke</summary>
   public  int B;
   /// <summary>The component A color of the stroke</summary>
   public  int A;
   ///<summary>Constructor for StrokeColor.</summary>
   public StrokeColor(
       int R=default( int),
       int G=default( int),
       int B=default( int),
       int A=default( int)   )
   {
      this.R = R;
      this.G = G;
      this.B = B;
      this.A = A;
   }
public static implicit operator StrokeColor(IntPtr ptr)
   {
      var tmp = (StrokeColor_StructInternal)Marshal.PtrToStructure(ptr, typeof(StrokeColor_StructInternal));
      return StrokeColor_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct StrokeColor.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StrokeColor_StructInternal
{
   
   public  int R;
   
   public  int G;
   
   public  int B;
   
   public  int A;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator StrokeColor(StrokeColor_StructInternal struct_)
   {
      return StrokeColor_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator StrokeColor_StructInternal(StrokeColor struct_)
   {
      return StrokeColor_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct StrokeColor</summary>
public static class StrokeColor_StructConversion
{
   internal static StrokeColor_StructInternal ToInternal(StrokeColor _external_struct)
   {
      var _internal_struct = new StrokeColor_StructInternal();

      _internal_struct.R = _external_struct.R;
      _internal_struct.G = _external_struct.G;
      _internal_struct.B = _external_struct.B;
      _internal_struct.A = _external_struct.A;

      return _internal_struct;
   }

   internal static StrokeColor ToManaged(StrokeColor_StructInternal _internal_struct)
   {
      var _external_struct = new StrokeColor();

      _external_struct.R = _internal_struct.R;
      _external_struct.G = _internal_struct.G;
      _external_struct.B = _internal_struct.B;
      _external_struct.A = _internal_struct.A;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Type defining stroke information. Describes the properties to define the path stroke.
/// 1.14</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Stroke
{
   /// <summary>Stroke scale</summary>
   public double Scale;
   /// <summary>Stroke width</summary>
   public double Width;
   /// <summary>Stroke centered</summary>
   public double Centered;
   /// <summary>Stroke color</summary>
   public Efl.Gfx.StrokeColor Color;
   /// <summary>Stroke dash</summary>
   public Efl.Gfx.Dash Dash;
   /// <summary>Stroke dash length</summary>
   public  uint Dash_length;
   /// <summary>Stroke cap</summary>
   public Efl.Gfx.Cap Cap;
   /// <summary>Stroke join</summary>
   public Efl.Gfx.Join Join;
   ///<summary>Constructor for Stroke.</summary>
   public Stroke(
      double Scale=default(double),
      double Width=default(double),
      double Centered=default(double),
      Efl.Gfx.StrokeColor Color=default(Efl.Gfx.StrokeColor),
      Efl.Gfx.Dash Dash=default(Efl.Gfx.Dash),
       uint Dash_length=default( uint),
      Efl.Gfx.Cap Cap=default(Efl.Gfx.Cap),
      Efl.Gfx.Join Join=default(Efl.Gfx.Join)   )
   {
      this.Scale = Scale;
      this.Width = Width;
      this.Centered = Centered;
      this.Color = Color;
      this.Dash = Dash;
      this.Dash_length = Dash_length;
      this.Cap = Cap;
      this.Join = Join;
   }
public static implicit operator Stroke(IntPtr ptr)
   {
      var tmp = (Stroke_StructInternal)Marshal.PtrToStructure(ptr, typeof(Stroke_StructInternal));
      return Stroke_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Stroke.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Stroke_StructInternal
{
   
   public double Scale;
   
   public double Width;
   
   public double Centered;
   
   public Efl.Gfx.StrokeColor_StructInternal Color;
   
   public Efl.Gfx.Dash_StructInternal Dash;
   
   public  uint Dash_length;
   
   public Efl.Gfx.Cap Cap;
   
   public Efl.Gfx.Join Join;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Stroke(Stroke_StructInternal struct_)
   {
      return Stroke_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Stroke_StructInternal(Stroke struct_)
   {
      return Stroke_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Stroke</summary>
public static class Stroke_StructConversion
{
   internal static Stroke_StructInternal ToInternal(Stroke _external_struct)
   {
      var _internal_struct = new Stroke_StructInternal();

      _internal_struct.Scale = _external_struct.Scale;
      _internal_struct.Width = _external_struct.Width;
      _internal_struct.Centered = _external_struct.Centered;
      _internal_struct.Color = Efl.Gfx.StrokeColor_StructConversion.ToInternal(_external_struct.Color);
      _internal_struct.Dash = Efl.Gfx.Dash_StructConversion.ToInternal(_external_struct.Dash);
      _internal_struct.Dash_length = _external_struct.Dash_length;
      _internal_struct.Cap = _external_struct.Cap;
      _internal_struct.Join = _external_struct.Join;

      return _internal_struct;
   }

   internal static Stroke ToManaged(Stroke_StructInternal _internal_struct)
   {
      var _external_struct = new Stroke();

      _external_struct.Scale = _internal_struct.Scale;
      _external_struct.Width = _internal_struct.Width;
      _external_struct.Centered = _internal_struct.Centered;
      _external_struct.Color = Efl.Gfx.StrokeColor_StructConversion.ToManaged(_internal_struct.Color);
      _external_struct.Dash = Efl.Gfx.Dash_StructConversion.ToManaged(_internal_struct.Dash);
      _external_struct.Dash_length = _internal_struct.Dash_length;
      _external_struct.Cap = _internal_struct.Cap;
      _external_struct.Join = _internal_struct.Join;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Public shape</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ShapePublic
{
   /// <summary>Internal representation as stroke</summary>
   public Efl.Gfx.Stroke Stroke;
   ///<summary>Constructor for ShapePublic.</summary>
   public ShapePublic(
      Efl.Gfx.Stroke Stroke=default(Efl.Gfx.Stroke)   )
   {
      this.Stroke = Stroke;
   }
public static implicit operator ShapePublic(IntPtr ptr)
   {
      var tmp = (ShapePublic_StructInternal)Marshal.PtrToStructure(ptr, typeof(ShapePublic_StructInternal));
      return ShapePublic_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ShapePublic.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ShapePublic_StructInternal
{
   
   public Efl.Gfx.Stroke_StructInternal Stroke;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ShapePublic(ShapePublic_StructInternal struct_)
   {
      return ShapePublic_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ShapePublic_StructInternal(ShapePublic struct_)
   {
      return ShapePublic_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ShapePublic</summary>
public static class ShapePublic_StructConversion
{
   internal static ShapePublic_StructInternal ToInternal(ShapePublic _external_struct)
   {
      var _internal_struct = new ShapePublic_StructInternal();

      _internal_struct.Stroke = Efl.Gfx.Stroke_StructConversion.ToInternal(_external_struct.Stroke);

      return _internal_struct;
   }

   internal static ShapePublic ToManaged(ShapePublic_StructInternal _internal_struct)
   {
      var _external_struct = new ShapePublic();

      _external_struct.Stroke = Efl.Gfx.Stroke_StructConversion.ToManaged(_internal_struct.Stroke);

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct PathChangeEvent
{
   /// <summary>Indicates what changed.</summary>
   public Efl.Gfx.ChangeFlag What;
   ///<summary>Constructor for PathChangeEvent.</summary>
   public PathChangeEvent(
      Efl.Gfx.ChangeFlag What=default(Efl.Gfx.ChangeFlag)   )
   {
      this.What = What;
   }
public static implicit operator PathChangeEvent(IntPtr ptr)
   {
      var tmp = (PathChangeEvent_StructInternal)Marshal.PtrToStructure(ptr, typeof(PathChangeEvent_StructInternal));
      return PathChangeEvent_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct PathChangeEvent.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct PathChangeEvent_StructInternal
{
   
   public Efl.Gfx.ChangeFlag What;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator PathChangeEvent(PathChangeEvent_StructInternal struct_)
   {
      return PathChangeEvent_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator PathChangeEvent_StructInternal(PathChangeEvent struct_)
   {
      return PathChangeEvent_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct PathChangeEvent</summary>
public static class PathChangeEvent_StructConversion
{
   internal static PathChangeEvent_StructInternal ToInternal(PathChangeEvent _external_struct)
   {
      var _internal_struct = new PathChangeEvent_StructInternal();

      _internal_struct.What = _external_struct.What;

      return _internal_struct;
   }

   internal static PathChangeEvent ToManaged(PathChangeEvent_StructInternal _internal_struct)
   {
      var _external_struct = new PathChangeEvent();

      _external_struct.What = _internal_struct.What;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Gfx { namespace Event { 
/// <summary>Data sent along a &quot;render,post&quot; event, after a frame has been rendered.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderPost
{
   /// <summary>A list of rectangles that were updated in the canvas.</summary>
   public Eina.List<Eina.Rect> Updated_area;
   ///<summary>Constructor for RenderPost.</summary>
   public RenderPost(
      Eina.List<Eina.Rect> Updated_area=default(Eina.List<Eina.Rect>)   )
   {
      this.Updated_area = Updated_area;
   }
public static implicit operator RenderPost(IntPtr ptr)
   {
      var tmp = (RenderPost_StructInternal)Marshal.PtrToStructure(ptr, typeof(RenderPost_StructInternal));
      return RenderPost_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct RenderPost.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderPost_StructInternal
{
   
   public  System.IntPtr Updated_area;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator RenderPost(RenderPost_StructInternal struct_)
   {
      return RenderPost_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator RenderPost_StructInternal(RenderPost struct_)
   {
      return RenderPost_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct RenderPost</summary>
public static class RenderPost_StructConversion
{
   internal static RenderPost_StructInternal ToInternal(RenderPost _external_struct)
   {
      var _internal_struct = new RenderPost_StructInternal();

      _internal_struct.Updated_area = _external_struct.Updated_area.Handle;

      return _internal_struct;
   }

   internal static RenderPost ToManaged(RenderPost_StructInternal _internal_struct)
   {
      var _external_struct = new RenderPost();

      _external_struct.Updated_area = new Eina.List<Eina.Rect>(_internal_struct.Updated_area, false, false);

      return _external_struct;
   }

}
} } } 
