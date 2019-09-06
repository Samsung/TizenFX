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
    virtual public int GetSliceNumber() {
         var _ret_var = Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_slice_number_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The number of slices. The larger the number of slice_num is, The better the text follows the path.
    /// internal</summary>
    /// <param name="slice_no">Number of slices</param>
    virtual public void SetSliceNumber(int slice_no) {
                                 Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_slice_number_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),slice_no);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the ellipsis behavior of the textpath.
    /// since_tizen 5.5</summary>
    /// <returns>To ellipsis text or not</returns>
    virtual public bool GetEllipsis() {
         var _ret_var = Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_ellipsis_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the ellipsis behavior of the textpath.
    /// since_tizen 5.5</summary>
    /// <param name="ellipsis">To ellipsis text or not</param>
    virtual public void SetEllipsis(bool ellipsis) {
                                 Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_ellipsis_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ellipsis);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set a circle with given radius and start angle. The center of the circle will be decided by the object center position.
    /// since_tizen 5.5</summary>
    /// <param name="radius">Radius of the circle</param>
    /// <param name="start_angle">Start angle of the circle</param>
    /// <param name="direction">Textpath direction</param>
    virtual public void SetCircular(double radius, double start_angle, Efl.Ui.TextpathDirection direction) {
                                                                                 Efl.Ui.Textpath.NativeMethods.efl_ui_textpath_circular_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),radius, start_angle, direction);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    virtual public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    virtual public void GetPath(out Efl.Gfx.PathCommandType op, out double points) {
                         System.IntPtr _out_op = System.IntPtr.Zero;
        System.IntPtr _out_points = System.IntPtr.Zero;
                        Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_op, out _out_points);
        Eina.Error.RaiseIfUnhandledException();
        op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(_out_op);
        points = Eina.PrimitiveConversion.PointerToManaged<double>(_out_points);
                         }
    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    virtual public void SetPath(Efl.Gfx.PathCommandType op, double points) {
         var _in_op = Eina.PrimitiveConversion.ManagedToPointerAlloc(op);
        var _in_points = Eina.PrimitiveConversion.ManagedToPointerAlloc(points);
                                        Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_op, _in_points);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Path length property</summary>
    /// <param name="commands">Commands</param>
    /// <param name="points">Points</param>
    virtual public void GetLength(out uint commands, out uint points) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out commands, out points);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Current point coordinates</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    virtual public void GetCurrent(out double x, out double y) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_current_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Current control point coordinates</summary>
    /// <param name="x">X co-ordinate of control point.</param>
    /// <param name="y">Y co-ordinate of control point.</param>
    virtual public void GetCurrentCtrl(out double x, out double y) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_current_ctrl_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Copy the path data from the object specified.</summary>
    /// <param name="dup_from">Shape object from where data will be copied.</param>
    virtual public void CopyFrom(Efl.Object dup_from) {
                                 Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_copy_from_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dup_from);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Compute and return the bounding box of the currently set path</summary>
    /// <param name="r">Contain the bounding box of the currently set path</param>
    virtual public void GetBounds(out Eina.Rect r) {
                 var _out_r = new Eina.Rect.NativeStruct();
                Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_bounds_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_r);
        Eina.Error.RaiseIfUnhandledException();
        r = _out_r;
                 }
    /// <summary>Reset the path data of the path object.</summary>
    virtual public void Reset() {
         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
    /// See also <see cref="Efl.Gfx.IPath.CloseAppend"/>.</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    virtual public void AppendMoveTo(double x, double y) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_move_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
    /// If no current position present, it draws a line to itself, basically a point.
    /// 
    /// See also <see cref="Efl.Gfx.IPath.AppendMoveTo"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    virtual public void AppendLineTo(double x, double y) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_line_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of control point.</param>
    virtual public void AppendQuadraticTo(double x, double y, double ctrl_x, double ctrl_y) {
                                                                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_quadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Same as efl_gfx_path_append_quadratic_to() api only difference is that it uses the current control point to draw the bezier.
    /// See also <see cref="Efl.Gfx.IPath.AppendQuadraticTo"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    virtual public void AppendSquadraticTo(double x, double y) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_squadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a cubic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x0, ctrl_y0), and (ctrl_x1, ctrl_y1). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="ctrl_x0">X co-ordinate of 1st control point.</param>
    /// <param name="ctrl_y0">Y co-ordinate of 1st control point.</param>
    /// <param name="ctrl_x1">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y1">Y co-ordinate of 2nd control point.</param>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    virtual public void AppendCubicTo(double ctrl_x0, double ctrl_y0, double ctrl_x1, double ctrl_y1, double x, double y) {
                                                                                                                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_cubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ctrl_x0, ctrl_y0, ctrl_x1, ctrl_y1, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Same as efl_gfx_path_append_cubic_to() api only difference is that it uses the current control point to draw the bezier.
    /// See also <see cref="Efl.Gfx.IPath.AppendCubicTo"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
    virtual public void AppendScubicTo(double x, double y, double ctrl_x, double ctrl_y) {
                                                                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_scubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
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
    virtual public void AppendArcTo(double x, double y, double rx, double ry, double angle, bool large_arc, bool sweep) {
                                                                                                                                                                                 Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_arc_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, rx, ry, angle, large_arc, sweep);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Append an arc that enclosed in the given rectangle (x, y, w, h). The angle is defined in counter clock wise , use -ve angle for clockwise arc.</summary>
    /// <param name="x">X co-ordinate of the rect.</param>
    /// <param name="y">Y co-ordinate of the rect.</param>
    /// <param name="w">Width of the rect.</param>
    /// <param name="h">Height of the rect.</param>
    /// <param name="start_angle">Angle at which the arc will start</param>
    /// <param name="sweep_length">@ Length of the arc.</param>
    virtual public void AppendArc(double x, double y, double w, double h, double start_angle, double sweep_length) {
                                                                                                                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_arc_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, start_angle, sweep_length);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
    /// If the subpath does not contain any points, this function does nothing.</summary>
    virtual public void CloseAppend() {
         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_close_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Append a circle with given center and radius.</summary>
    /// <param name="x">X co-ordinate of the center of the circle.</param>
    /// <param name="y">Y co-ordinate of the center of the circle.</param>
    /// <param name="radius">Radius of the circle.</param>
    virtual public void AppendCircle(double x, double y, double radius) {
                                                                                 Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_circle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, radius);
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
    virtual public void AppendRect(double x, double y, double w, double h, double rx, double ry) {
                                                                                                                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_rect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, rx, ry);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Append SVG path data</summary>
    /// <param name="svg_path_data">SVG path data to append</param>
    virtual public void AppendSvgPath(System.String svg_path_data) {
                                 Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_append_svg_path_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),svg_path_data);
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
    virtual public bool Interpolate(Efl.Object from, Efl.Object to, double pos_map) {
                                                                                 var _ret_var = Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from, to, pos_map);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Equal commands in object</summary>
    /// <param name="with">Object</param>
    /// <returns>True on success, <c>false</c> otherwise</returns>
    virtual public bool EqualCommands(Efl.Object with) {
                                 var _ret_var = Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_equal_commands_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),with);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.</summary>
    /// <param name="cmd_count">Commands count to reserve</param>
    /// <param name="pts_count">Pointers count to reserve</param>
    virtual public void Reserve(uint cmd_count, uint pts_count) {
                                                         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_reserve_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cmd_count, pts_count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Request to update the path object.
    /// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
    virtual public void Commit() {
         Efl.Gfx.IPathConcrete.NativeMethods.efl_gfx_path_commit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (efl_text_get_static_delegate == null)
            {
                efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate) });
            }

            if (efl_text_set_static_delegate == null)
            {
                efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate) });
            }

            if (efl_gfx_path_get_static_delegate == null)
            {
                efl_gfx_path_get_static_delegate = new efl_gfx_path_get_delegate(path_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPath") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_get_static_delegate) });
            }

            if (efl_gfx_path_set_static_delegate == null)
            {
                efl_gfx_path_set_static_delegate = new efl_gfx_path_set_delegate(path_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPath") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_set_static_delegate) });
            }

            if (efl_gfx_path_length_get_static_delegate == null)
            {
                efl_gfx_path_length_get_static_delegate = new efl_gfx_path_length_get_delegate(length_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_length_get_static_delegate) });
            }

            if (efl_gfx_path_current_get_static_delegate == null)
            {
                efl_gfx_path_current_get_static_delegate = new efl_gfx_path_current_get_delegate(current_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCurrent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_current_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_get_static_delegate) });
            }

            if (efl_gfx_path_current_ctrl_get_static_delegate == null)
            {
                efl_gfx_path_current_ctrl_get_static_delegate = new efl_gfx_path_current_ctrl_get_delegate(current_ctrl_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCurrentCtrl") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_current_ctrl_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_ctrl_get_static_delegate) });
            }

            if (efl_gfx_path_copy_from_static_delegate == null)
            {
                efl_gfx_path_copy_from_static_delegate = new efl_gfx_path_copy_from_delegate(copy_from);
            }

            if (methods.FirstOrDefault(m => m.Name == "CopyFrom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_copy_from"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_copy_from_static_delegate) });
            }

            if (efl_gfx_path_bounds_get_static_delegate == null)
            {
                efl_gfx_path_bounds_get_static_delegate = new efl_gfx_path_bounds_get_delegate(bounds_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBounds") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_bounds_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_bounds_get_static_delegate) });
            }

            if (efl_gfx_path_reset_static_delegate == null)
            {
                efl_gfx_path_reset_static_delegate = new efl_gfx_path_reset_delegate(reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "Reset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reset_static_delegate) });
            }

            if (efl_gfx_path_append_move_to_static_delegate == null)
            {
                efl_gfx_path_append_move_to_static_delegate = new efl_gfx_path_append_move_to_delegate(append_move_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendMoveTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_move_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_move_to_static_delegate) });
            }

            if (efl_gfx_path_append_line_to_static_delegate == null)
            {
                efl_gfx_path_append_line_to_static_delegate = new efl_gfx_path_append_line_to_delegate(append_line_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendLineTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_line_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_line_to_static_delegate) });
            }

            if (efl_gfx_path_append_quadratic_to_static_delegate == null)
            {
                efl_gfx_path_append_quadratic_to_static_delegate = new efl_gfx_path_append_quadratic_to_delegate(append_quadratic_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendQuadraticTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_quadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_quadratic_to_static_delegate) });
            }

            if (efl_gfx_path_append_squadratic_to_static_delegate == null)
            {
                efl_gfx_path_append_squadratic_to_static_delegate = new efl_gfx_path_append_squadratic_to_delegate(append_squadratic_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendSquadraticTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_squadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_squadratic_to_static_delegate) });
            }

            if (efl_gfx_path_append_cubic_to_static_delegate == null)
            {
                efl_gfx_path_append_cubic_to_static_delegate = new efl_gfx_path_append_cubic_to_delegate(append_cubic_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendCubicTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_cubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_cubic_to_static_delegate) });
            }

            if (efl_gfx_path_append_scubic_to_static_delegate == null)
            {
                efl_gfx_path_append_scubic_to_static_delegate = new efl_gfx_path_append_scubic_to_delegate(append_scubic_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendScubicTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_scubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_scubic_to_static_delegate) });
            }

            if (efl_gfx_path_append_arc_to_static_delegate == null)
            {
                efl_gfx_path_append_arc_to_static_delegate = new efl_gfx_path_append_arc_to_delegate(append_arc_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendArcTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_arc_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_to_static_delegate) });
            }

            if (efl_gfx_path_append_arc_static_delegate == null)
            {
                efl_gfx_path_append_arc_static_delegate = new efl_gfx_path_append_arc_delegate(append_arc);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendArc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_arc"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_static_delegate) });
            }

            if (efl_gfx_path_append_close_static_delegate == null)
            {
                efl_gfx_path_append_close_static_delegate = new efl_gfx_path_append_close_delegate(append_close);
            }

            if (methods.FirstOrDefault(m => m.Name == "CloseAppend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_close"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_close_static_delegate) });
            }

            if (efl_gfx_path_append_circle_static_delegate == null)
            {
                efl_gfx_path_append_circle_static_delegate = new efl_gfx_path_append_circle_delegate(append_circle);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendCircle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_circle"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_circle_static_delegate) });
            }

            if (efl_gfx_path_append_rect_static_delegate == null)
            {
                efl_gfx_path_append_rect_static_delegate = new efl_gfx_path_append_rect_delegate(append_rect);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendRect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_rect"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_rect_static_delegate) });
            }

            if (efl_gfx_path_append_svg_path_static_delegate == null)
            {
                efl_gfx_path_append_svg_path_static_delegate = new efl_gfx_path_append_svg_path_delegate(append_svg_path);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendSvgPath") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_append_svg_path"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_svg_path_static_delegate) });
            }

            if (efl_gfx_path_interpolate_static_delegate == null)
            {
                efl_gfx_path_interpolate_static_delegate = new efl_gfx_path_interpolate_delegate(interpolate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Interpolate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_interpolate_static_delegate) });
            }

            if (efl_gfx_path_equal_commands_static_delegate == null)
            {
                efl_gfx_path_equal_commands_static_delegate = new efl_gfx_path_equal_commands_delegate(equal_commands);
            }

            if (methods.FirstOrDefault(m => m.Name == "EqualCommands") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_equal_commands"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_equal_commands_static_delegate) });
            }

            if (efl_gfx_path_reserve_static_delegate == null)
            {
                efl_gfx_path_reserve_static_delegate = new efl_gfx_path_reserve_delegate(reserve);
            }

            if (methods.FirstOrDefault(m => m.Name == "Reserve") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_reserve"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reserve_static_delegate) });
            }

            if (efl_gfx_path_commit_static_delegate == null)
            {
                efl_gfx_path_commit_static_delegate = new efl_gfx_path_commit_delegate(commit);
            }

            if (methods.FirstOrDefault(m => m.Name == "Commit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_path_commit"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_commit_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
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

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(Module, "efl_text_get");

        private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Textpath)ws.Target).GetText();
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
                return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_get_delegate efl_text_get_static_delegate;

        
        private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate void efl_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(Module, "efl_text_set");

        private static void text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Textpath)ws.Target).SetText(text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text);
            }
        }

        private static efl_text_set_delegate efl_text_set_static_delegate;

        
        private delegate void efl_gfx_path_get_delegate(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr op,  out System.IntPtr points);

        
        public delegate void efl_gfx_path_get_api_delegate(System.IntPtr obj,  out System.IntPtr op,  out System.IntPtr points);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_get_api_delegate> efl_gfx_path_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_get_api_delegate>(Module, "efl_gfx_path_get");

        private static void path_get(System.IntPtr obj, System.IntPtr pd, out System.IntPtr op, out System.IntPtr points)
        {
            Eina.Log.Debug("function efl_gfx_path_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.Gfx.PathCommandType _out_op = default(Efl.Gfx.PathCommandType);
        double _out_points = default(double);
                            
                try
                {
                    ((Textpath)ws.Target).GetPath(out _out_op, out _out_points);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        op = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_op);
        points = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_points);
                        
            }
            else
            {
                efl_gfx_path_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out op, out points);
            }
        }

        private static efl_gfx_path_get_delegate efl_gfx_path_get_static_delegate;

        
        private delegate void efl_gfx_path_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr op,  System.IntPtr points);

        
        public delegate void efl_gfx_path_set_api_delegate(System.IntPtr obj,  System.IntPtr op,  System.IntPtr points);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_set_api_delegate> efl_gfx_path_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_set_api_delegate>(Module, "efl_gfx_path_set");

        private static void path_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr op, System.IntPtr points)
        {
            Eina.Log.Debug("function efl_gfx_path_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(op);
        var _in_points = Eina.PrimitiveConversion.PointerToManaged<double>(points);
                                            
                try
                {
                    ((Textpath)ws.Target).SetPath(_in_op, _in_points);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), op, points);
            }
        }

        private static efl_gfx_path_set_delegate efl_gfx_path_set_static_delegate;

        
        private delegate void efl_gfx_path_length_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint commands,  out uint points);

        
        public delegate void efl_gfx_path_length_get_api_delegate(System.IntPtr obj,  out uint commands,  out uint points);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_length_get_api_delegate> efl_gfx_path_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_length_get_api_delegate>(Module, "efl_gfx_path_length_get");

        private static void length_get(System.IntPtr obj, System.IntPtr pd, out uint commands, out uint points)
        {
            Eina.Log.Debug("function efl_gfx_path_length_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        commands = default(uint);        points = default(uint);                            
                try
                {
                    ((Textpath)ws.Target).GetLength(out commands, out points);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out commands, out points);
            }
        }

        private static efl_gfx_path_length_get_delegate efl_gfx_path_length_get_static_delegate;

        
        private delegate void efl_gfx_path_current_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_path_current_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_current_get_api_delegate> efl_gfx_path_current_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_current_get_api_delegate>(Module, "efl_gfx_path_current_get");

        private static void current_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_path_current_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((Textpath)ws.Target).GetCurrent(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_current_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_path_current_get_delegate efl_gfx_path_current_get_static_delegate;

        
        private delegate void efl_gfx_path_current_ctrl_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_path_current_ctrl_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_current_ctrl_get_api_delegate> efl_gfx_path_current_ctrl_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_current_ctrl_get_api_delegate>(Module, "efl_gfx_path_current_ctrl_get");

        private static void current_ctrl_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_path_current_ctrl_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((Textpath)ws.Target).GetCurrentCtrl(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_current_ctrl_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_path_current_ctrl_get_delegate efl_gfx_path_current_ctrl_get_static_delegate;

        
        private delegate void efl_gfx_path_copy_from_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object dup_from);

        
        public delegate void efl_gfx_path_copy_from_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object dup_from);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_copy_from_api_delegate> efl_gfx_path_copy_from_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_copy_from_api_delegate>(Module, "efl_gfx_path_copy_from");

        private static void copy_from(System.IntPtr obj, System.IntPtr pd, Efl.Object dup_from)
        {
            Eina.Log.Debug("function efl_gfx_path_copy_from was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Textpath)ws.Target).CopyFrom(dup_from);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_path_copy_from_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dup_from);
            }
        }

        private static efl_gfx_path_copy_from_delegate efl_gfx_path_copy_from_static_delegate;

        
        private delegate void efl_gfx_path_bounds_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Eina.Rect.NativeStruct r);

        
        public delegate void efl_gfx_path_bounds_get_api_delegate(System.IntPtr obj,  out Eina.Rect.NativeStruct r);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_bounds_get_api_delegate> efl_gfx_path_bounds_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_bounds_get_api_delegate>(Module, "efl_gfx_path_bounds_get");

        private static void bounds_get(System.IntPtr obj, System.IntPtr pd, out Eina.Rect.NativeStruct r)
        {
            Eina.Log.Debug("function efl_gfx_path_bounds_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _out_r = default(Eina.Rect);
                    
                try
                {
                    ((Textpath)ws.Target).GetBounds(out _out_r);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        r = _out_r;
                
            }
            else
            {
                efl_gfx_path_bounds_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r);
            }
        }

        private static efl_gfx_path_bounds_get_delegate efl_gfx_path_bounds_get_static_delegate;

        
        private delegate void efl_gfx_path_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_path_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_reset_api_delegate> efl_gfx_path_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_reset_api_delegate>(Module, "efl_gfx_path_reset");

        private static void reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_path_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Textpath)ws.Target).Reset();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_path_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_path_reset_delegate efl_gfx_path_reset_static_delegate;

        
        private delegate void efl_gfx_path_append_move_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_path_append_move_to_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_move_to_api_delegate> efl_gfx_path_append_move_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_move_to_api_delegate>(Module, "efl_gfx_path_append_move_to");

        private static void append_move_to(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_move_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Textpath)ws.Target).AppendMoveTo(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_append_move_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_path_append_move_to_delegate efl_gfx_path_append_move_to_static_delegate;

        
        private delegate void efl_gfx_path_append_line_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_path_append_line_to_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_line_to_api_delegate> efl_gfx_path_append_line_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_line_to_api_delegate>(Module, "efl_gfx_path_append_line_to");

        private static void append_line_to(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_line_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Textpath)ws.Target).AppendLineTo(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_append_line_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_path_append_line_to_delegate efl_gfx_path_append_line_to_static_delegate;

        
        private delegate void efl_gfx_path_append_quadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y);

        
        public delegate void efl_gfx_path_append_quadratic_to_api_delegate(System.IntPtr obj,  double x,  double y,  double ctrl_x,  double ctrl_y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_quadratic_to_api_delegate> efl_gfx_path_append_quadratic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_quadratic_to_api_delegate>(Module, "efl_gfx_path_append_quadratic_to");

        private static void append_quadratic_to(System.IntPtr obj, System.IntPtr pd, double x, double y, double ctrl_x, double ctrl_y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_quadratic_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Textpath)ws.Target).AppendQuadraticTo(x, y, ctrl_x, ctrl_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_path_append_quadratic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, ctrl_x, ctrl_y);
            }
        }

        private static efl_gfx_path_append_quadratic_to_delegate efl_gfx_path_append_quadratic_to_static_delegate;

        
        private delegate void efl_gfx_path_append_squadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_path_append_squadratic_to_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_squadratic_to_api_delegate> efl_gfx_path_append_squadratic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_squadratic_to_api_delegate>(Module, "efl_gfx_path_append_squadratic_to");

        private static void append_squadratic_to(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_squadratic_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Textpath)ws.Target).AppendSquadraticTo(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_append_squadratic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_path_append_squadratic_to_delegate efl_gfx_path_append_squadratic_to_static_delegate;

        
        private delegate void efl_gfx_path_append_cubic_to_delegate(System.IntPtr obj, System.IntPtr pd,  double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y);

        
        public delegate void efl_gfx_path_append_cubic_to_api_delegate(System.IntPtr obj,  double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_cubic_to_api_delegate> efl_gfx_path_append_cubic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_cubic_to_api_delegate>(Module, "efl_gfx_path_append_cubic_to");

        private static void append_cubic_to(System.IntPtr obj, System.IntPtr pd, double ctrl_x0, double ctrl_y0, double ctrl_x1, double ctrl_y1, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_cubic_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                            
                try
                {
                    ((Textpath)ws.Target).AppendCubicTo(ctrl_x0, ctrl_y0, ctrl_x1, ctrl_y1, x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                        
            }
            else
            {
                efl_gfx_path_append_cubic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ctrl_x0, ctrl_y0, ctrl_x1, ctrl_y1, x, y);
            }
        }

        private static efl_gfx_path_append_cubic_to_delegate efl_gfx_path_append_cubic_to_static_delegate;

        
        private delegate void efl_gfx_path_append_scubic_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y);

        
        public delegate void efl_gfx_path_append_scubic_to_api_delegate(System.IntPtr obj,  double x,  double y,  double ctrl_x,  double ctrl_y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_scubic_to_api_delegate> efl_gfx_path_append_scubic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_scubic_to_api_delegate>(Module, "efl_gfx_path_append_scubic_to");

        private static void append_scubic_to(System.IntPtr obj, System.IntPtr pd, double x, double y, double ctrl_x, double ctrl_y)
        {
            Eina.Log.Debug("function efl_gfx_path_append_scubic_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Textpath)ws.Target).AppendScubicTo(x, y, ctrl_x, ctrl_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_path_append_scubic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, ctrl_x, ctrl_y);
            }
        }

        private static efl_gfx_path_append_scubic_to_delegate efl_gfx_path_append_scubic_to_static_delegate;

        
        private delegate void efl_gfx_path_append_arc_to_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double rx,  double ry,  double angle, [MarshalAs(UnmanagedType.U1)] bool large_arc, [MarshalAs(UnmanagedType.U1)] bool sweep);

        
        public delegate void efl_gfx_path_append_arc_to_api_delegate(System.IntPtr obj,  double x,  double y,  double rx,  double ry,  double angle, [MarshalAs(UnmanagedType.U1)] bool large_arc, [MarshalAs(UnmanagedType.U1)] bool sweep);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_to_api_delegate> efl_gfx_path_append_arc_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_to_api_delegate>(Module, "efl_gfx_path_append_arc_to");

        private static void append_arc_to(System.IntPtr obj, System.IntPtr pd, double x, double y, double rx, double ry, double angle, bool large_arc, bool sweep)
        {
            Eina.Log.Debug("function efl_gfx_path_append_arc_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                    
                try
                {
                    ((Textpath)ws.Target).AppendArcTo(x, y, rx, ry, angle, large_arc, sweep);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                        
            }
            else
            {
                efl_gfx_path_append_arc_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, rx, ry, angle, large_arc, sweep);
            }
        }

        private static efl_gfx_path_append_arc_to_delegate efl_gfx_path_append_arc_to_static_delegate;

        
        private delegate void efl_gfx_path_append_arc_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double start_angle,  double sweep_length);

        
        public delegate void efl_gfx_path_append_arc_api_delegate(System.IntPtr obj,  double x,  double y,  double w,  double h,  double start_angle,  double sweep_length);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_api_delegate> efl_gfx_path_append_arc_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_api_delegate>(Module, "efl_gfx_path_append_arc");

        private static void append_arc(System.IntPtr obj, System.IntPtr pd, double x, double y, double w, double h, double start_angle, double sweep_length)
        {
            Eina.Log.Debug("function efl_gfx_path_append_arc was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                            
                try
                {
                    ((Textpath)ws.Target).AppendArc(x, y, w, h, start_angle, sweep_length);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                        
            }
            else
            {
                efl_gfx_path_append_arc_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, w, h, start_angle, sweep_length);
            }
        }

        private static efl_gfx_path_append_arc_delegate efl_gfx_path_append_arc_static_delegate;

        
        private delegate void efl_gfx_path_append_close_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_path_append_close_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_close_api_delegate> efl_gfx_path_append_close_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_close_api_delegate>(Module, "efl_gfx_path_append_close");

        private static void append_close(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_path_append_close was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Textpath)ws.Target).CloseAppend();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_path_append_close_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_path_append_close_delegate efl_gfx_path_append_close_static_delegate;

        
        private delegate void efl_gfx_path_append_circle_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double radius);

        
        public delegate void efl_gfx_path_append_circle_api_delegate(System.IntPtr obj,  double x,  double y,  double radius);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_circle_api_delegate> efl_gfx_path_append_circle_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_circle_api_delegate>(Module, "efl_gfx_path_append_circle");

        private static void append_circle(System.IntPtr obj, System.IntPtr pd, double x, double y, double radius)
        {
            Eina.Log.Debug("function efl_gfx_path_append_circle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Textpath)ws.Target).AppendCircle(x, y, radius);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_path_append_circle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, radius);
            }
        }

        private static efl_gfx_path_append_circle_delegate efl_gfx_path_append_circle_static_delegate;

        
        private delegate void efl_gfx_path_append_rect_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double rx,  double ry);

        
        public delegate void efl_gfx_path_append_rect_api_delegate(System.IntPtr obj,  double x,  double y,  double w,  double h,  double rx,  double ry);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_rect_api_delegate> efl_gfx_path_append_rect_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_rect_api_delegate>(Module, "efl_gfx_path_append_rect");

        private static void append_rect(System.IntPtr obj, System.IntPtr pd, double x, double y, double w, double h, double rx, double ry)
        {
            Eina.Log.Debug("function efl_gfx_path_append_rect was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                            
                try
                {
                    ((Textpath)ws.Target).AppendRect(x, y, w, h, rx, ry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                        
            }
            else
            {
                efl_gfx_path_append_rect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y, w, h, rx, ry);
            }
        }

        private static efl_gfx_path_append_rect_delegate efl_gfx_path_append_rect_static_delegate;

        
        private delegate void efl_gfx_path_append_svg_path_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String svg_path_data);

        
        public delegate void efl_gfx_path_append_svg_path_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String svg_path_data);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_svg_path_api_delegate> efl_gfx_path_append_svg_path_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_svg_path_api_delegate>(Module, "efl_gfx_path_append_svg_path");

        private static void append_svg_path(System.IntPtr obj, System.IntPtr pd, System.String svg_path_data)
        {
            Eina.Log.Debug("function efl_gfx_path_append_svg_path was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Textpath)ws.Target).AppendSvgPath(svg_path_data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_path_append_svg_path_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), svg_path_data);
            }
        }

        private static efl_gfx_path_append_svg_path_delegate efl_gfx_path_append_svg_path_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_path_interpolate_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object to,  double pos_map);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_path_interpolate_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object to,  double pos_map);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_interpolate_api_delegate> efl_gfx_path_interpolate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_interpolate_api_delegate>(Module, "efl_gfx_path_interpolate");

        private static bool interpolate(System.IntPtr obj, System.IntPtr pd, Efl.Object from, Efl.Object to, double pos_map)
        {
            Eina.Log.Debug("function efl_gfx_path_interpolate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Textpath)ws.Target).Interpolate(from, to, pos_map);
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
                return efl_gfx_path_interpolate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), from, to, pos_map);
            }
        }

        private static efl_gfx_path_interpolate_delegate efl_gfx_path_interpolate_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_path_equal_commands_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object with);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_path_equal_commands_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object with);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_equal_commands_api_delegate> efl_gfx_path_equal_commands_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_equal_commands_api_delegate>(Module, "efl_gfx_path_equal_commands");

        private static bool equal_commands(System.IntPtr obj, System.IntPtr pd, Efl.Object with)
        {
            Eina.Log.Debug("function efl_gfx_path_equal_commands was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Textpath)ws.Target).EqualCommands(with);
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
                return efl_gfx_path_equal_commands_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), with);
            }
        }

        private static efl_gfx_path_equal_commands_delegate efl_gfx_path_equal_commands_static_delegate;

        
        private delegate void efl_gfx_path_reserve_delegate(System.IntPtr obj, System.IntPtr pd,  uint cmd_count,  uint pts_count);

        
        public delegate void efl_gfx_path_reserve_api_delegate(System.IntPtr obj,  uint cmd_count,  uint pts_count);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_reserve_api_delegate> efl_gfx_path_reserve_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_reserve_api_delegate>(Module, "efl_gfx_path_reserve");

        private static void reserve(System.IntPtr obj, System.IntPtr pd, uint cmd_count, uint pts_count)
        {
            Eina.Log.Debug("function efl_gfx_path_reserve was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Textpath)ws.Target).Reserve(cmd_count, pts_count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_path_reserve_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cmd_count, pts_count);
            }
        }

        private static efl_gfx_path_reserve_delegate efl_gfx_path_reserve_static_delegate;

        
        private delegate void efl_gfx_path_commit_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_path_commit_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_path_commit_api_delegate> efl_gfx_path_commit_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_commit_api_delegate>(Module, "efl_gfx_path_commit");

        private static void commit(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_path_commit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Textpath)ws.Target).Commit();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_path_commit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_path_commit_delegate efl_gfx_path_commit_static_delegate;

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
/// <summary>Clockwise, middle of text will be at start angle
/// (Since EFL 1.23)</summary>
CwCenter = 2,
/// <summary>Counter-clockwise, middle of text will be at start angle
/// (Since EFL 1.23)</summary>
CcwCenter = 3,
}

}

}

