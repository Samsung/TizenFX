#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Font {

/// <summary>Efl font size type</summary>
public struct Size
{
    private int payload;

    /// <summary>Converts an instance of int to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static implicit operator Size(int value)
    {
        return new Size{payload=value};
    }

    /// <summary>Converts an instance of this struct to int.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    public static implicit operator int(Size value)
    {
        return value.payload;
    }
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>Graphics colorspace type</summary>
[Efl.Eo.BindingEntity]
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
/// <summary>OpenGL ETC1 encoding of RGB texture (4 bit per pixel)</summary>
/// <since_tizen> 6 </since_tizen>
Etc1 = 9,
/// <summary>OpenGL GL_COMPRESSED_RGB8_ETC2 texture compression format (4 bit per pixel)</summary>
/// <since_tizen> 6 </since_tizen>
Rgb8Etc2 = 10,
/// <summary>OpenGL GL_COMPRESSED_RGBA8_ETC2_EAC texture compression format, supports alpha (8 bit per pixel)</summary>
/// <since_tizen> 6 </since_tizen>
Rgba8Etc2Eac = 11,
/// <summary>ETC1 with alpha support using two planes: ETC1 RGB and ETC1 grey for alpha</summary>
/// <since_tizen> 6 </since_tizen>
Etc1Alpha = 12,
/// <summary>OpenGL COMPRESSED_RGB_S3TC_DXT1_EXT format with RGB only.</summary>
/// <since_tizen> 6 </since_tizen>
RgbS3tcDxt1 = 13,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT1_EXT format with RGBA punchthrough.</summary>
/// <since_tizen> 6 </since_tizen>
RgbaS3tcDxt1 = 14,
/// <summary>DirectDraw DXT2 format with premultiplied RGBA. Not supported by OpenGL itself.</summary>
/// <since_tizen> 6 </since_tizen>
RgbaS3tcDxt2 = 15,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT3_EXT format with RGBA.</summary>
/// <since_tizen> 6 </since_tizen>
RgbaS3tcDxt3 = 16,
/// <summary>DirectDraw DXT4 format with premultiplied RGBA. Not supported by OpenGL itself.</summary>
/// <since_tizen> 6 </since_tizen>
RgbaS3tcDxt4 = 17,
/// <summary>OpenGL COMPRESSED_RGBA_S3TC_DXT5_EXT format with RGBA.</summary>
/// <since_tizen> 6 </since_tizen>
RgbaS3tcDxt5 = 18,
Palette = 19,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>Graphics render operation mode</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
public enum RenderOp
{
/// <summary>Alpha blending onto destination (default); d = d*(1-sa) + s.</summary>
Blend = 0,
/// <summary>Copy source to destination; d = s.</summary>
Copy = 1,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 2,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>These values determine how the points are interpreted in a stream of points.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Gfx {

/// <summary>These values determine how the end of opened sub-paths are rendered in a stroke. <see cref="Efl.Gfx.IShape.SetStrokeCap"/></summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Gfx {

/// <summary>These values determine how two joining lines are rendered in a stroker. <see cref="Efl.Gfx.IShape.SetStrokeJoin"/></summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Gfx {

/// <summary>Specifies how the area outside the gradient area should be filled. <see cref="Efl.Gfx.IGradient.SetSpread"/></summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Gfx {

/// <summary>Type defining how an image content get filled.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
public enum FillRule
{
/// <summary>Draw a horizontal line from the point to a location outside the shape. Determine whether the direction of the line at each intersection point is up or down. The winding number is determined by summing the direction of each intersection. If the number is non zero, the point is inside the shape. This mode is the default</summary>
Winding = 0,
/// <summary>Draw a horizontal line from the point to a location outside the shape, and count the number of intersections. If the number of intersections is an odd number, the point is inside the shape.</summary>
OddEven = 1,
}
}
}

namespace Efl {

namespace Gfx {

[Efl.Eo.BindingEntity]
public enum VgCompositeMethod
{
None = 0,
MatteAlpha = 1,
MatteAlphaInverse = 2,
MaskAdd = 3,
MaskSubstract = 4,
MaskIntersect = 5,
MaskDifference = 6,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>How an image&apos;s center region (the complement to the border region) should be rendered by EFL</summary>
[Efl.Eo.BindingEntity]
public enum CenterFillMode
{
/// <summary>Image&apos;s center region is <c>not</c> to be rendered</summary>
None = 0,
/// <summary>Image&apos;s center region is to be <c>blended</c> with objects underneath it, if it has transparency. This is the default behavior for image objects</summary>
Default = 1,
/// <summary>Image&apos;s center region is to be made solid, even if it has transparency on it</summary>
Solid = 2,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>What property got changed for this object</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
public enum ChangeFlag
{
/// <summary>Nothing changed.</summary>
None = 0,
/// <summary>Matrix got changed.</summary>
Matrix = 1,
/// <summary>Path got changed.</summary>
Path = 2,
/// <summary>Coloring or fill information changed, not geometry.</summary>
Fill = 4,
/// <summary>All properties got changed.</summary>
All = 65535,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>Aspect types/policies for scaling size hints.
/// See also <see cref="Efl.Gfx.IHint.GetHintAspect"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
public enum HintAspect
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
}
}

namespace Efl {

namespace Gfx {

/// <summary>Efl Gfx Color Class layer enum</summary>
[Efl.Eo.BindingEntity]
public enum ColorClassLayer
{
/// <summary>Default color</summary>
Normal = 0,
/// <summary>Outline color</summary>
Outline = 1,
/// <summary>Shadow color</summary>
Shadow = 2,
}
}
}

namespace Efl {

namespace Gfx {

/// <summary>Type describing dash. <see cref="Efl.Gfx.IShape.GetStrokeDash"/></summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Dash
{
    /// <summary>Dash drawing length.</summary>
    public double Length;
    /// <summary>Distance between two dashes.</summary>
    public double Gap;
    /// <summary>Constructor for Dash.</summary>
    /// <param name="Length">Dash drawing length.</param>
    /// <param name="Gap">Distance between two dashes.</param>
    public Dash(
        double Length = default(double),
        double Gap = default(double)    )
    {
        this.Length = Length;
        this.Gap = Gap;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Dash(IntPtr ptr)
    {
        var tmp = (Dash.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Dash.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Dash.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Length;
        
        public double Gap;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Dash.NativeStruct(Dash _external_struct)
        {
            var _internal_struct = new Dash.NativeStruct();
            _internal_struct.Length = _external_struct.Length;
            _internal_struct.Gap = _external_struct.Gap;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Dash(Dash.NativeStruct _internal_struct)
        {
            var _external_struct = new Dash();
            _external_struct.Length = _internal_struct.Length;
            _external_struct.Gap = _internal_struct.Gap;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Gfx {

/// <summary>Type defining gradient stops. Describes the location and color of a transition point in a gradient.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct GradientStop
{
    /// <summary>The location of the gradient stop within the gradient vector</summary>
    public double Offset;
    /// <summary>The component R color of the gradient stop</summary>
    public int R;
    /// <summary>The component G color of the gradient stop</summary>
    public int G;
    /// <summary>The component B color of the gradient stop</summary>
    public int B;
    /// <summary>The component A color of the gradient stop</summary>
    public int A;
    /// <summary>Constructor for GradientStop.</summary>
    /// <param name="Offset">The location of the gradient stop within the gradient vector</param>
    /// <param name="R">The component R color of the gradient stop</param>
    /// <param name="G">The component G color of the gradient stop</param>
    /// <param name="B">The component B color of the gradient stop</param>
    /// <param name="A">The component A color of the gradient stop</param>
    public GradientStop(
        double Offset = default(double),
        int R = default(int),
        int G = default(int),
        int B = default(int),
        int A = default(int)    )
    {
        this.Offset = Offset;
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator GradientStop(IntPtr ptr)
    {
        var tmp = (GradientStop.NativeStruct)Marshal.PtrToStructure(ptr, typeof(GradientStop.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct GradientStop.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Offset;
        
        public int R;
        
        public int G;
        
        public int B;
        
        public int A;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator GradientStop.NativeStruct(GradientStop _external_struct)
        {
            var _internal_struct = new GradientStop.NativeStruct();
            _internal_struct.Offset = _external_struct.Offset;
            _internal_struct.R = _external_struct.R;
            _internal_struct.G = _external_struct.G;
            _internal_struct.B = _external_struct.B;
            _internal_struct.A = _external_struct.A;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator GradientStop(GradientStop.NativeStruct _internal_struct)
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
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Gfx {

/// <summary>Internal structure for <see cref="Efl.Gfx.Stroke"/>.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct StrokeColor
{
    /// <summary>The component R color of the stroke</summary>
    public int R;
    /// <summary>The component G color of the stroke</summary>
    public int G;
    /// <summary>The component B color of the stroke</summary>
    public int B;
    /// <summary>The component A color of the stroke</summary>
    public int A;
    /// <summary>Constructor for StrokeColor.</summary>
    /// <param name="R">The component R color of the stroke</param>
    /// <param name="G">The component G color of the stroke</param>
    /// <param name="B">The component B color of the stroke</param>
    /// <param name="A">The component A color of the stroke</param>
    public StrokeColor(
        int R = default(int),
        int G = default(int),
        int B = default(int),
        int A = default(int)    )
    {
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator StrokeColor(IntPtr ptr)
    {
        var tmp = (StrokeColor.NativeStruct)Marshal.PtrToStructure(ptr, typeof(StrokeColor.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct StrokeColor.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int R;
        
        public int G;
        
        public int B;
        
        public int A;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator StrokeColor.NativeStruct(StrokeColor _external_struct)
        {
            var _internal_struct = new StrokeColor.NativeStruct();
            _internal_struct.R = _external_struct.R;
            _internal_struct.G = _external_struct.G;
            _internal_struct.B = _external_struct.B;
            _internal_struct.A = _external_struct.A;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator StrokeColor(StrokeColor.NativeStruct _internal_struct)
        {
            var _external_struct = new StrokeColor();
            _external_struct.R = _internal_struct.R;
            _external_struct.G = _internal_struct.G;
            _external_struct.B = _internal_struct.B;
            _external_struct.A = _internal_struct.A;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Gfx {

/// <summary>Type defining stroke information. Describes the properties to define the path stroke.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Stroke
{
    /// <summary>Stroke scale</summary>
    public double Scale;
    /// <summary>Stroke width</summary>
    public double Width;
    /// <summary>Stroke centered</summary>
    public double Centered;
    /// <summary>Stroke color</summary>
    /// <value>Internal structure for @Efl.Gfx.Stroke.</value>
    public Efl.Gfx.StrokeColor Color;
    /// <summary>Stroke dash</summary>
    /// <value>Type describing dash. @Efl.Gfx.Shape.stroke_dash.set</value>
    public Efl.Gfx.Dash Dash;
    /// <summary>Stroke dash length</summary>
    public uint Dash_length;
    /// <summary>Stroke cap</summary>
    /// <value>These values determine how the end of opened sub-paths are rendered in a stroke. @Efl.Gfx.Shape.stroke_cap.set</value>
    public Efl.Gfx.Cap Cap;
    /// <summary>Stroke join</summary>
    /// <value>These values determine how two joining lines are rendered in a stroker. @Efl.Gfx.Shape.stroke_join.set</value>
    public Efl.Gfx.Join Join;
    /// <summary>Stroke miterlimit</summary>
    public double Miterlimit;
    /// <summary>Constructor for Stroke.</summary>
    /// <param name="Scale">Stroke scale</param>
    /// <param name="Width">Stroke width</param>
    /// <param name="Centered">Stroke centered</param>
    /// <param name="Color">Stroke color</param>
    /// <param name="Dash">Stroke dash</param>
    /// <param name="Dash_length">Stroke dash length</param>
    /// <param name="Cap">Stroke cap</param>
    /// <param name="Join">Stroke join</param>
    /// <param name="Miterlimit">Stroke miterlimit</param>
    public Stroke(
        double Scale = default(double),
        double Width = default(double),
        double Centered = default(double),
        Efl.Gfx.StrokeColor Color = default(Efl.Gfx.StrokeColor),
        Efl.Gfx.Dash Dash = default(Efl.Gfx.Dash),
        uint Dash_length = default(uint),
        Efl.Gfx.Cap Cap = default(Efl.Gfx.Cap),
        Efl.Gfx.Join Join = default(Efl.Gfx.Join),
        double Miterlimit = default(double)    )
    {
        this.Scale = Scale;
        this.Width = Width;
        this.Centered = Centered;
        this.Color = Color;
        this.Dash = Dash;
        this.Dash_length = Dash_length;
        this.Cap = Cap;
        this.Join = Join;
        this.Miterlimit = Miterlimit;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Stroke(IntPtr ptr)
    {
        var tmp = (Stroke.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Stroke.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Stroke.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Scale;
        
        public double Width;
        
        public double Centered;
        
        public Efl.Gfx.StrokeColor.NativeStruct Color;
        
        public Efl.Gfx.Dash.NativeStruct Dash;
        
        public uint Dash_length;
        
        public Efl.Gfx.Cap Cap;
        
        public Efl.Gfx.Join Join;
        
        public double Miterlimit;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Stroke.NativeStruct(Stroke _external_struct)
        {
            var _internal_struct = new Stroke.NativeStruct();
            _internal_struct.Scale = _external_struct.Scale;
            _internal_struct.Width = _external_struct.Width;
            _internal_struct.Centered = _external_struct.Centered;
            _internal_struct.Color = _external_struct.Color;
            _internal_struct.Dash = _external_struct.Dash;
            _internal_struct.Dash_length = _external_struct.Dash_length;
            _internal_struct.Cap = _external_struct.Cap;
            _internal_struct.Join = _external_struct.Join;
            _internal_struct.Miterlimit = _external_struct.Miterlimit;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Stroke(Stroke.NativeStruct _internal_struct)
        {
            var _external_struct = new Stroke();
            _external_struct.Scale = _internal_struct.Scale;
            _external_struct.Width = _internal_struct.Width;
            _external_struct.Centered = _internal_struct.Centered;
            _external_struct.Color = _internal_struct.Color;
            _external_struct.Dash = _internal_struct.Dash;
            _external_struct.Dash_length = _internal_struct.Dash_length;
            _external_struct.Cap = _internal_struct.Cap;
            _external_struct.Join = _internal_struct.Join;
            _external_struct.Miterlimit = _internal_struct.Miterlimit;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Gfx {

/// <summary>Public shape</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ShapePublic
{
    /// <summary>Internal representation as stroke</summary>
    /// <value>Type defining stroke information. Describes the properties to define the path stroke.</value>
    public Efl.Gfx.Stroke Stroke;
    /// <summary>Constructor for ShapePublic.</summary>
    /// <param name="Stroke">Internal representation as stroke</param>
    public ShapePublic(
        Efl.Gfx.Stroke Stroke = default(Efl.Gfx.Stroke)    )
    {
        this.Stroke = Stroke;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ShapePublic(IntPtr ptr)
    {
        var tmp = (ShapePublic.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ShapePublic.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ShapePublic.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Gfx.Stroke.NativeStruct Stroke;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ShapePublic.NativeStruct(ShapePublic _external_struct)
        {
            var _internal_struct = new ShapePublic.NativeStruct();
            _internal_struct.Stroke = _external_struct.Stroke;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ShapePublic(ShapePublic.NativeStruct _internal_struct)
        {
            var _external_struct = new ShapePublic();
            _external_struct.Stroke = _internal_struct.Stroke;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Gfx {

namespace Event {

/// <summary>Data sent along a &quot;render,post&quot; event, after a frame has been rendered.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct RenderPost
{
    /// <summary>A list of rectangles that were updated in the canvas.</summary>
    public Eina.List<Eina.Rect> Updated_area;
    /// <summary>Constructor for RenderPost.</summary>
    /// <param name="Updated_area">A list of rectangles that were updated in the canvas.</param>
    public RenderPost(
        Eina.List<Eina.Rect> Updated_area = default(Eina.List<Eina.Rect>)    )
    {
        this.Updated_area = Updated_area;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator RenderPost(IntPtr ptr)
    {
        var tmp = (RenderPost.NativeStruct)Marshal.PtrToStructure(ptr, typeof(RenderPost.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct RenderPost.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Updated_area;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator RenderPost.NativeStruct(RenderPost _external_struct)
        {
            var _internal_struct = new RenderPost.NativeStruct();
            _internal_struct.Updated_area = _external_struct.Updated_area.Handle;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator RenderPost(RenderPost.NativeStruct _internal_struct)
        {
            var _external_struct = new RenderPost();
            _external_struct.Updated_area = new Eina.List<Eina.Rect>(_internal_struct.Updated_area, false, false);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}
}

