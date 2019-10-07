#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Font {

/// <summary>UIKit font size type</summary>
public struct Size
{
    private int payload;

    /// <summary>Converts an instance of int to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator Size(int value)
    {
        return new Size{payload=value};
    }

    /// <summary>Converts an instance of this struct to int.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator int(Size value)
    {
        return value.payload;
    }
}
}
}

namespace UIKit {

namespace Gfx {

/// <summary>Graphics render operation mode</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>These values determine how the points are interpreted in a stream of points.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>These values determine how the end of opened sub-paths are rendered in a stroke. <span class="text-muted">UIKit.Gfx.IShape.SetStrokeCap (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>These values determine how two joining lines are rendered in a stroker. <span class="text-muted">UIKit.Gfx.IShape.SetStrokeJoin (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>Specifies how the area outside the gradient area should be filled. <span class="text-muted">UIKit.Gfx.IGradient.SetSpread (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>How an image&apos;s center region (the complement to the border region) should be rendered by EFL</summary>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>What property got changed for this object</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>Aspect types/policies for scaling size hints.
/// See also <see cref="UIKit.Gfx.IHint.GetHintAspect"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>Type describing dash. <span class="text-muted">UIKit.Gfx.IShape.GetStrokeDash (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

/// <summary>Type defining gradient stops. Describes the location and color of a transition point in a gradient.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
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

namespace UIKit {

namespace Gfx {

namespace Event {

/// <summary>Data sent along a &quot;render,post&quot; event, after a frame has been rendered.</summary>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct RenderPost
{
    /// <summary>A list of rectangles that were updated in the canvas.</summary>
    public UIKit.DataTypes.List<UIKit.DataTypes.Rect> Updated_area;
    /// <summary>Constructor for RenderPost.</summary>
    /// <param name="Updated_area">A list of rectangles that were updated in the canvas.</param>
    public RenderPost(
        UIKit.DataTypes.List<UIKit.DataTypes.Rect> Updated_area = default(UIKit.DataTypes.List<UIKit.DataTypes.Rect>)    )
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
            _external_struct.Updated_area = new UIKit.DataTypes.List<UIKit.DataTypes.Rect>(_internal_struct.Updated_area, false, false);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}
}

