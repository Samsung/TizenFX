#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl Ui Textpath class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Textpath.NativeMethods]
[Efl.Eo.BindingEntity]
public class Textpath : Efl.Ui.LayoutBase, Efl.IText, Efl.Gfx.IPath
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Textpath))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_textpath_class_get();

    /// <summary>Initializes a new instance of the <see cref="Textpath"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Textpath(Efl.Object parent
            , System.String style = null) : base(efl_ui_textpath_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Textpath(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Textpath"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Textpath(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Textpath"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Textpath(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>The number of slices. The larger the number of slice_num is, The better the text follows the path.
    /// internal</summary>
    /// <returns>Number of slices</returns>
    public virtual int GetSliceNumber() {
        var _ret_var = Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_slice_number_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The number of slices. The larger the number of slice_num is, The better the text follows the path.
    /// internal</summary>
    /// <param name="slice_no">Number of slices</param>
    public virtual void SetSliceNumber(int slice_no) {
        Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_slice_number_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),slice_no);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the ellipsis behavior of the textpath.
    /// since_tizen 5.5</summary>
    /// <returns>To ellipsis text or not</returns>
    public virtual bool GetEllipsis() {
        var _ret_var = Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_ellipsis_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the ellipsis behavior of the textpath.
    /// since_tizen 5.5</summary>
    /// <param name="ellipsis">To ellipsis text or not</param>
    public virtual void SetEllipsis(bool ellipsis) {
        Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_ellipsis_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ellipsis);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set a circle with given radius and start angle. The center of the circle will be decided by the object center position.
    /// since_tizen 5.5</summary>
    /// <param name="radius">Radius of the circle</param>
    /// <param name="start_angle">Start angle of the circle</param>
    /// <param name="direction">Textpath direction</param>
    public virtual void SetCircular(double radius, double start_angle, Efl.Ui.TextpathDirection direction) {
        Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_circular_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),radius, start_angle, direction);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
        var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetText(System.String text) {
        Efl.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    public virtual void GetPath(out Efl.Gfx.PathCommandType op, out double points) {
        System.IntPtr _out_op = System.IntPtr.Zero;
System.IntPtr _out_points = System.IntPtr.Zero;
Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_op, out _out_points);
        Eina.Error.RaiseIfUnhandledException();
op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(_out_op);
points = Eina.PrimitiveConversion.PointerToManaged<double>(_out_points);
        
    }

    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    public virtual void SetPath(Efl.Gfx.PathCommandType op, double points) {
        var _in_op = Eina.PrimitiveConversion.ManagedToPointerAlloc(op);
var _in_points = Eina.PrimitiveConversion.ManagedToPointerAlloc(points);
Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_op, _in_points);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Path length property</summary>
    /// <param name="commands">Commands</param>
    /// <param name="points">Points</param>
    public virtual void GetLength(out uint commands, out uint points) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out commands, out points);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Current point coordinates</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    public virtual void GetCurrent(out double x, out double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_current_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Current control point coordinates</summary>
    /// <param name="x">X co-ordinate of control point.</param>
    /// <param name="y">Y co-ordinate of control point.</param>
    public virtual void GetCurrentCtrl(out double x, out double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_current_ctrl_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Copy the path data from the object specified.</summary>
    /// <param name="dup_from">Shape object from where data will be copied.</param>
    public virtual void CopyFrom(Efl.Object dup_from) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_copy_from_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dup_from);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Compute and return the bounding box of the currently set path</summary>
    /// <param name="r">Contain the bounding box of the currently set path</param>
    public virtual void GetBounds(out Eina.Rect r) {
        var _out_r = new Eina.Rect.NativeStruct();
Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_bounds_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_r);
        Eina.Error.RaiseIfUnhandledException();
r = _out_r;
        
    }

    /// <summary>Reset the path data of the path object.</summary>
    public virtual void Reset() {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
    /// See also <see cref="Efl.Gfx.IPath.CloseAppend"/>.</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    public virtual void AppendMoveTo(double x, double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_move_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
    /// If no current position present, it draws a line to itself, basically a point.
    /// 
    /// See also <see cref="Efl.Gfx.IPath.AppendMoveTo"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendLineTo(double x, double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_line_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of control point.</param>
    public virtual void AppendQuadraticTo(double x, double y, double ctrl_x, double ctrl_y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_quadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Same as <see cref="Efl.Gfx.IPath.AppendQuadraticTo"/> api only difference is that it uses the current control point to draw the bezier.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendSquadraticTo(double x, double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_squadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Adds a cubic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x0, ctrl_y0), and (ctrl_x1, ctrl_y1). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="ctrl_x0">X co-ordinate of 1st control point.</param>
    /// <param name="ctrl_y0">Y co-ordinate of 1st control point.</param>
    /// <param name="ctrl_x1">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y1">Y co-ordinate of 2nd control point.</param>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendCubicTo(double ctrl_x0, double ctrl_y0, double ctrl_x1, double ctrl_y1, double x, double y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_cubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ctrl_x0, ctrl_y0, ctrl_x1, ctrl_y1, x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Same as <see cref="Efl.Gfx.IPath.AppendCubicTo"/> api only difference is that it uses the current control point to draw the bezier.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
    public virtual void AppendScubicTo(double x, double y, double ctrl_x, double ctrl_y) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_scubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Append an arc that connects from the current point int the point list to the given point (x,y). The arc is defined by the given radius in  x-direction (rx) and radius in y direction (ry).
    /// Use this api if you know the end point&apos;s of the arc otherwise use more convenient function <see cref="Efl.Gfx.IPath.AppendArc"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the arc.</param>
    /// <param name="y">Y co-ordinate of end point of the arc.</param>
    /// <param name="rx">Radius of arc in x direction.</param>
    /// <param name="ry">Radius of arc in y direction.</param>
    /// <param name="angle">X-axis rotation , normally 0.</param>
    /// <param name="large_arc">Defines whether to draw the larger arc or smaller arc joining two point.</param>
    /// <param name="sweep">Defines whether the arc will be drawn counter-clockwise or clockwise from current point to the end point taking into account the large_arc property.</param>
    public virtual void AppendArcTo(double x, double y, double rx, double ry, double angle, bool large_arc, bool sweep) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_arc_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, rx, ry, angle, large_arc, sweep);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Append an arc that enclosed in the given rectangle (x, y, w, h). The angle is defined in counter clock wise , use -ve angle for clockwise arc.</summary>
    /// <param name="x">X co-ordinate of the rect.</param>
    /// <param name="y">Y co-ordinate of the rect.</param>
    /// <param name="w">Width of the rect.</param>
    /// <param name="h">Height of the rect.</param>
    /// <param name="start_angle">Angle at which the arc will start</param>
    /// <param name="sweep_length">@ Length of the arc.</param>
    public virtual void AppendArc(double x, double y, double w, double h, double start_angle, double sweep_length) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_arc_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, start_angle, sweep_length);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
    /// If the subpath does not contain any points, this function does nothing.</summary>
    public virtual void CloseAppend() {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_close_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Append a circle with given center and radius.</summary>
    /// <param name="x">X co-ordinate of the center of the circle.</param>
    /// <param name="y">Y co-ordinate of the center of the circle.</param>
    /// <param name="radius">Radius of the circle.</param>
    public virtual void AppendCircle(double x, double y, double radius) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_circle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, radius);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Append the given rectangle with rounded corner to the path.
    /// The xr and yr arguments specify the radii of the ellipses defining the corners of the rounded rectangle.
    /// 
    /// xr and yr are specified in terms of width and height respectively.
    /// 
    /// If xr and yr are 0, then it will draw a rectangle without rounded corner.</summary>
    /// <param name="x">X co-ordinate of the rectangle.</param>
    /// <param name="y">Y co-ordinate of the rectangle.</param>
    /// <param name="w">Width of the rectangle.</param>
    /// <param name="h">Height of the rectangle.</param>
    /// <param name="rx">The x radius of the rounded corner and should be in range [ 0 to w/2 ]</param>
    /// <param name="ry">The y radius of the rounded corner and should be in range [ 0 to h/2 ]</param>
    public virtual void AppendRect(double x, double y, double w, double h, double rx, double ry) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_rect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, rx, ry);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Append SVG path data</summary>
    /// <param name="svg_path_data">SVG path data to append</param>
    public virtual void AppendSvgPath(System.String svg_path_data) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_svg_path_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),svg_path_data);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Creates intermediary path part-way between two paths
    /// Sets the points of the <c>obj</c> as the linear interpolation of the points in the <c>from</c> and <c>to</c> paths.  The path&apos;s x,y position and control point coordinates are likewise interpolated.
    /// 
    /// The <c>from</c> and <c>to</c> paths must not already have equivalent points, and <c>to</c> must contain at least as many points as <c>from</c>, else the function returns <c>false</c> with no interpolation performed.  If <c>to</c> has more points than <c>from</c>, the excess points are ignored.</summary>
    /// <param name="from">Source path</param>
    /// <param name="to">Destination path</param>
    /// <param name="pos_map">Position map in range 0.0 to 1.0</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool Interpolate(Efl.Object from, Efl.Object to, double pos_map) {
        var _ret_var = Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from, to, pos_map);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Equal commands in object</summary>
    /// <param name="with">Object</param>
    /// <returns>True on success, <c>false</c> otherwise</returns>
    public virtual bool EqualCommands(Efl.Object with) {
        var _ret_var = Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_equal_commands_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),with);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.</summary>
    /// <param name="cmd_count">Commands count to reserve</param>
    /// <param name="pts_count">Pointers count to reserve</param>
    public virtual void Reserve(uint cmd_count, uint pts_count) {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_reserve_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cmd_count, pts_count);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Request to update the path object.
    /// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
    public virtual void Commit() {
        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_commit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The number of slices. The larger the number of slice_num is, The better the text follows the path.
    /// internal</summary>
    /// <value>Number of slices</value>
    public int SliceNumber {
        get { return GetSliceNumber(); }
        set { SetSliceNumber(value); }
    }

    /// <summary>Control the ellipsis behavior of the textpath.
    /// since_tizen 5.5</summary>
    /// <value>To ellipsis text or not</value>
    public bool Ellipsis {
        get { return GetEllipsis(); }
        set { SetEllipsis(value); }
    }

    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <value>Command list</value>
    public (Efl.Gfx.PathCommandType, double) Path {
        get {
            Efl.Gfx.PathCommandType _out_op = default(Efl.Gfx.PathCommandType);
            double _out_points = default(double);
            GetPath(out _out_op,out _out_points);
            return (_out_op,_out_points);
        }
        set { SetPath( value.Item1,  value.Item2); }
    }

    /// <summary>Path length property</summary>
    public (uint, uint) Length {
        get {
            uint _out_commands = default(uint);
            uint _out_points = default(uint);
            GetLength(out _out_commands,out _out_points);
            return (_out_commands,_out_points);
        }
    }

    /// <summary>Current point coordinates</summary>
    public (double, double) Current {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetCurrent(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
    }

    /// <summary>Current control point coordinates</summary>
    public (double, double) CurrentCtrl {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetCurrentCtrl(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Textpath.efl_ui_textpath_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_textpath_slice_number_get_static_delegate == null)
            {
                efl_ui_textpath_slice_number_get_static_delegate = new efl_ui_textpath_slice_number_get_delegate(slice_number_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSliceNumber") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_textpath_slice_number_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_textpath_slice_number_get_static_delegate) });
            }

            if (efl_ui_textpath_slice_number_set_static_delegate == null)
            {
                efl_ui_textpath_slice_number_set_static_delegate = new efl_ui_textpath_slice_number_set_delegate(slice_number_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSliceNumber") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_textpath_slice_number_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_textpath_slice_number_set_static_delegate) });
            }

            if (efl_ui_textpath_ellipsis_get_static_delegate == null)
            {
                efl_ui_textpath_ellipsis_get_static_delegate = new efl_ui_textpath_ellipsis_get_delegate(ellipsis_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_textpath_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_textpath_ellipsis_get_static_delegate) });
            }

            if (efl_ui_textpath_ellipsis_set_static_delegate == null)
            {
                efl_ui_textpath_ellipsis_set_static_delegate = new efl_ui_textpath_ellipsis_set_delegate(ellipsis_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_textpath_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_textpath_ellipsis_set_static_delegate) });
            }

            if (efl_ui_textpath_circular_set_static_delegate == null)
            {
                efl_ui_textpath_circular_set_static_delegate = new efl_ui_textpath_circular_set_delegate(circular_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCircular") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_textpath_circular_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_textpath_circular_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Textpath.efl_ui_textpath_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_textpath_slice_number_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_textpath_slice_number_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_textpath_slice_number_get_api_delegate> efl_ui_textpath_slice_number_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_textpath_slice_number_get_api_delegate>(Module, "efl_ui_textpath_slice_number_get");

        private static int slice_number_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_textpath_slice_number_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Textpath)ws.Target).GetSliceNumber();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_ui_textpath_slice_number_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_textpath_slice_number_get_delegate efl_ui_textpath_slice_number_get_static_delegate;

        
        private delegate void efl_ui_textpath_slice_number_set_delegate(System.IntPtr obj, System.IntPtr pd,  int slice_no);

        
        public delegate void efl_ui_textpath_slice_number_set_api_delegate(System.IntPtr obj,  int slice_no);

        public static Efl.Eo.FunctionWrapper<efl_ui_textpath_slice_number_set_api_delegate> efl_ui_textpath_slice_number_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_textpath_slice_number_set_api_delegate>(Module, "efl_ui_textpath_slice_number_set");

        private static void slice_number_set(System.IntPtr obj, System.IntPtr pd, int slice_no)
        {
            Eina.Log.Debug("function efl_ui_textpath_slice_number_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Textpath)ws.Target).SetSliceNumber(slice_no);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_textpath_slice_number_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice_no);
            }
        }

        private static efl_ui_textpath_slice_number_set_delegate efl_ui_textpath_slice_number_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_textpath_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_textpath_ellipsis_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_textpath_ellipsis_get_api_delegate> efl_ui_textpath_ellipsis_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_textpath_ellipsis_get_api_delegate>(Module, "efl_ui_textpath_ellipsis_get");

        private static bool ellipsis_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_textpath_ellipsis_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Textpath)ws.Target).GetEllipsis();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_ui_textpath_ellipsis_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_textpath_ellipsis_get_delegate efl_ui_textpath_ellipsis_get_static_delegate;

        
        private delegate void efl_ui_textpath_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool ellipsis);

        
        public delegate void efl_ui_textpath_ellipsis_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool ellipsis);

        public static Efl.Eo.FunctionWrapper<efl_ui_textpath_ellipsis_set_api_delegate> efl_ui_textpath_ellipsis_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_textpath_ellipsis_set_api_delegate>(Module, "efl_ui_textpath_ellipsis_set");

        private static void ellipsis_set(System.IntPtr obj, System.IntPtr pd, bool ellipsis)
        {
            Eina.Log.Debug("function efl_ui_textpath_ellipsis_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Textpath)ws.Target).SetEllipsis(ellipsis);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_textpath_ellipsis_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ellipsis);
            }
        }

        private static efl_ui_textpath_ellipsis_set_delegate efl_ui_textpath_ellipsis_set_static_delegate;

        
        private delegate void efl_ui_textpath_circular_set_delegate(System.IntPtr obj, System.IntPtr pd,  double radius,  double start_angle,  Efl.Ui.TextpathDirection direction);

        
        public delegate void efl_ui_textpath_circular_set_api_delegate(System.IntPtr obj,  double radius,  double start_angle,  Efl.Ui.TextpathDirection direction);

        public static Efl.Eo.FunctionWrapper<efl_ui_textpath_circular_set_api_delegate> efl_ui_textpath_circular_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_textpath_circular_set_api_delegate>(Module, "efl_ui_textpath_circular_set");

        private static void circular_set(System.IntPtr obj, System.IntPtr pd, double radius, double start_angle, Efl.Ui.TextpathDirection direction)
        {
            Eina.Log.Debug("function efl_ui_textpath_circular_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Textpath)ws.Target).SetCircular(radius, start_angle, direction);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_textpath_circular_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), radius, start_angle, direction);
            }
        }

        private static efl_ui_textpath_circular_set_delegate efl_ui_textpath_circular_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiTextpath_ExtensionMethods {
    public static Efl.BindableProperty<int> SliceNumber<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Textpath, T>magic = null) where T : Efl.Ui.Textpath {
        return new Efl.BindableProperty<int>("slice_number", fac);
    }

    public static Efl.BindableProperty<bool> Ellipsis<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Textpath, T>magic = null) where T : Efl.Ui.Textpath {
        return new Efl.BindableProperty<bool>("ellipsis", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Textpath direction
/// since_tizen 5.5</summary>
[Efl.Eo.BindingEntity]
public enum TextpathDirection
{
/// <summary>Clockwise</summary>
Cw = 0,
/// <summary>Counter-clockwise</summary>
Ccw = 1,
/// <summary>Clockwise, middle of text will be at start angle</summary>
/// <since_tizen> 6 </since_tizen>
CwCenter = 2,
/// <summary>Counter-clockwise, middle of text will be at start angle</summary>
/// <since_tizen> 6 </since_tizen>
CcwCenter = 3,
}
}
}

