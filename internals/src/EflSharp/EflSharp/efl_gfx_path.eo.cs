#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>EFL graphics path object interface</summary>
[PathConcreteNativeInherit]
public interface Path : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Set the list of commands and points to be used to create the content of path.
/// 1.18</summary>
/// <param name="op">Command list</param>
/// <param name="points">Point list</param>
/// <returns></returns>
 void GetPath( out Efl.Gfx.PathCommandType op,  out double points);
   /// <summary>Set the list of commands and points to be used to create the content of path.
/// 1.18</summary>
/// <param name="op">Command list</param>
/// <param name="points">Point list</param>
/// <returns></returns>
 void SetPath( Efl.Gfx.PathCommandType op,  double points);
   /// <summary>Path length property</summary>
/// <param name="commands">Commands</param>
/// <param name="points">Points</param>
/// <returns></returns>
 void GetLength( out  uint commands,  out  uint points);
   /// <summary>Current point coordinates</summary>
/// <param name="x">X co-ordinate of the current point.</param>
/// <param name="y">Y co-ordinate of the current point.</param>
/// <returns></returns>
 void GetCurrent( out double x,  out double y);
   /// <summary>Current control point coordinates</summary>
/// <param name="x">X co-ordinate of control point.</param>
/// <param name="y">Y co-ordinate of control point.</param>
/// <returns></returns>
 void GetCurrentCtrl( out double x,  out double y);
   /// <summary>Copy the path data from the object specified.
/// 1.18</summary>
/// <param name="dup_from">Shape object from where data will be copied.</param>
/// <returns></returns>
 void CopyFrom( Efl.Object dup_from);
   /// <summary>Compute and return the bounding box of the currently set path
/// 1.18</summary>
/// <param name="r">Contain the bounding box of the currently set path</param>
/// <returns></returns>
 void GetBounds( out Eina.Rect r);
   /// <summary>Reset the path data of the path object.
/// 1.18</summary>
/// <returns></returns>
 void Reset();
   /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
/// See also <see cref="Efl.Gfx.Path.CloseAppend"/>.
/// 1.18</summary>
/// <param name="x">X co-ordinate of the current point.</param>
/// <param name="y">Y co-ordinate of the current point.</param>
/// <returns></returns>
 void AppendMoveTo( double x,  double y);
   /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
/// If no current position present, it draws a line to itself, basically a point.
/// 
/// See also <see cref="Efl.Gfx.Path.AppendMoveTo"/>.
/// 1.18</summary>
/// <param name="x">X co-ordinate of end point of the line.</param>
/// <param name="y">Y co-ordinate of end point of the line.</param>
/// <returns></returns>
 void AppendLineTo( double x,  double y);
   /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.
/// 1.18</summary>
/// <param name="x">X co-ordinate of end point of the line.</param>
/// <param name="y">Y co-ordinate of end point of the line.</param>
/// <param name="ctrl_x">X co-ordinate of control point.</param>
/// <param name="ctrl_y">Y co-ordinate of control point.</param>
/// <returns></returns>
 void AppendQuadraticTo( double x,  double y,  double ctrl_x,  double ctrl_y);
   /// <summary>Same as efl_gfx_path_append_quadratic_to() api only difference is that it uses the current control point to draw the bezier.
/// See also <see cref="Efl.Gfx.Path.AppendQuadraticTo"/>.
/// 1.18</summary>
/// <param name="x">X co-ordinate of end point of the line.</param>
/// <param name="y">Y co-ordinate of end point of the line.</param>
/// <returns></returns>
 void AppendSquadraticTo( double x,  double y);
   /// <summary>Adds a cubic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x0, ctrl_y0), and (ctrl_x1, ctrl_y1). After the path is drawn, the current position is updated to be at the end point of the path.
/// 1.18</summary>
/// <param name="ctrl_x0">X co-ordinate of 1st control point.</param>
/// <param name="ctrl_y0">Y co-ordinate of 1st control point.</param>
/// <param name="ctrl_x1">X co-ordinate of 2nd control point.</param>
/// <param name="ctrl_y1">Y co-ordinate of 2nd control point.</param>
/// <param name="x">X co-ordinate of end point of the line.</param>
/// <param name="y">Y co-ordinate of end point of the line.</param>
/// <returns></returns>
 void AppendCubicTo( double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y);
   /// <summary>Same as efl_gfx_path_append_cubic_to() api only difference is that it uses the current control point to draw the bezier.
/// See also <see cref="Efl.Gfx.Path.AppendCubicTo"/>.
/// 1.18</summary>
/// <param name="x">X co-ordinate of end point of the line.</param>
/// <param name="y">Y co-ordinate of end point of the line.</param>
/// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
/// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
/// <returns></returns>
 void AppendScubicTo( double x,  double y,  double ctrl_x,  double ctrl_y);
   /// <summary>Append an arc that connects from the current point int the point list to the given point (x,y). The arc is defined by the given radius in  x-direction (rx) and radius in y direction (ry).
/// Use this api if you know the end point&apos;s of the arc otherwise use more convenient function <see cref="Efl.Gfx.Path.AppendArc"/>.
/// 1.18</summary>
/// <param name="x">X co-ordinate of end point of the arc.</param>
/// <param name="y">Y co-ordinate of end point of the arc.</param>
/// <param name="rx">Radius of arc in x direction.</param>
/// <param name="ry">Radius of arc in y direction.</param>
/// <param name="angle">X-axis rotation , normally 0.</param>
/// <param name="large_arc">Defines whether to draw the larger arc or smaller arc joining two point.</param>
/// <param name="sweep">Defines whether the arc will be drawn counter-clockwise or clockwise from current point to the end point taking into account the large_arc property.</param>
/// <returns></returns>
 void AppendArcTo( double x,  double y,  double rx,  double ry,  double angle,  bool large_arc,  bool sweep);
   /// <summary>Append an arc that enclosed in the given rectangle (x, y, w, h). The angle is defined in counter clock wise , use -ve angle for clockwise arc.
/// 1.18</summary>
/// <param name="x">X co-ordinate of the rect.</param>
/// <param name="y">Y co-ordinate of the rect.</param>
/// <param name="w">Width of the rect.</param>
/// <param name="h">Height of the rect.</param>
/// <param name="start_angle">Angle at which the arc will start</param>
/// <param name="sweep_length">@ Length of the arc.</param>
/// <returns></returns>
 void AppendArc( double x,  double y,  double w,  double h,  double start_angle,  double sweep_length);
   /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
/// If the subpath does not contain any points, this function does nothing.
/// 1.18</summary>
/// <returns></returns>
 void CloseAppend();
   /// <summary>Append a circle with given center and radius.
/// 1.18</summary>
/// <param name="x">X co-ordinate of the center of the circle.</param>
/// <param name="y">Y co-ordinate of the center of the circle.</param>
/// <param name="radius">Radius of the circle.</param>
/// <returns></returns>
 void AppendCircle( double x,  double y,  double radius);
   /// <summary>Append the given rectangle with rounded corner to the path.
/// The xr and yr arguments specify the radii of the ellipses defining the corners of the rounded rectangle.
/// 
/// xr and yr are specified in terms of width and height respectively.
/// 
/// If xr and yr are 0, then it will draw a rectangle without rounded corner.
/// 1.18</summary>
/// <param name="x">X co-ordinate of the rectangle.</param>
/// <param name="y">Y co-ordinate of the rectangle.</param>
/// <param name="w">Width of the rectangle.</param>
/// <param name="h">Height of the rectangle.</param>
/// <param name="rx">The x radius of the rounded corner and should be in range [ 0 to w/2 ]</param>
/// <param name="ry">The y radius of the rounded corner and should be in range [ 0 to h/2 ]</param>
/// <returns></returns>
 void AppendRect( double x,  double y,  double w,  double h,  double rx,  double ry);
   /// <summary>Append SVG path data</summary>
/// <param name="svg_path_data">SVG path data to append</param>
/// <returns></returns>
 void AppendSvgPath(  System.String svg_path_data);
   /// <summary>Creates intermediary path part-way between two paths
/// Sets the points of the <c>obj</c> as the linear interpolation of the points in the <c>from</c> and <c>to</c> paths.  The path&apos;s x,y position and control point coordinates are likewise interpolated.
/// 
/// The <c>from</c> and <c>to</c> paths must not already have equivalent points, and <c>to</c> must contain at least as many points as <c>from</c>, else the function returns <c>false</c> with no interpolation performed.  If <c>to</c> has more points than <c>from</c>, the excess points are ignored.</summary>
/// <param name="from">Source path</param>
/// <param name="to">Destination path</param>
/// <param name="pos_map">Position map in range 0.0 to 1.0</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool Interpolate( Efl.Object from,  Efl.Object to,  double pos_map);
   /// <summary>Equal commands in object</summary>
/// <param name="with">Object</param>
/// <returns>True on success, <c>false</c> otherwise</returns>
bool EqualCommands( Efl.Object with);
   /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.
/// 1.22</summary>
/// <param name="cmd_count">Commands count to reserve</param>
/// <param name="pts_count">Pointers count to reserve</param>
/// <returns></returns>
 void Reserve(  uint cmd_count,   uint pts_count);
   /// <summary>Request to update the path object.
/// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
/// <returns></returns>
 void Commit();
                                                                        }
/// <summary>EFL graphics path object interface</summary>
sealed public class PathConcrete : 

Path
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PathConcrete))
            return Efl.Gfx.PathConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_path_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public PathConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PathConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static PathConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PathConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_get(System.IntPtr obj,   out  System.IntPtr op,   out  System.IntPtr points);
   /// <summary>Set the list of commands and points to be used to create the content of path.
   /// 1.18</summary>
   /// <param name="op">Command list</param>
   /// <param name="points">Point list</param>
   /// <returns></returns>
   public  void GetPath( out Efl.Gfx.PathCommandType op,  out double points) {
                   System.IntPtr _out_op = System.IntPtr.Zero;
      System.IntPtr _out_points = System.IntPtr.Zero;
                  efl_gfx_path_get(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  out _out_op,  out _out_points);
      Eina.Error.RaiseIfUnhandledException();
      op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(_out_op);
      points = Eina.PrimitiveConversion.PointerToManaged<double>(_out_points);
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_set(System.IntPtr obj,    System.IntPtr op,    System.IntPtr points);
   /// <summary>Set the list of commands and points to be used to create the content of path.
   /// 1.18</summary>
   /// <param name="op">Command list</param>
   /// <param name="points">Point list</param>
   /// <returns></returns>
   public  void SetPath( Efl.Gfx.PathCommandType op,  double points) {
       var _in_op = Eina.PrimitiveConversion.ManagedToPointerAlloc(op);
      var _in_points = Eina.PrimitiveConversion.ManagedToPointerAlloc(points);
                              efl_gfx_path_set(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  _in_op,  _in_points);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_length_get(System.IntPtr obj,   out  uint commands,   out  uint points);
   /// <summary>Path length property</summary>
   /// <param name="commands">Commands</param>
   /// <param name="points">Points</param>
   /// <returns></returns>
   public  void GetLength( out  uint commands,  out  uint points) {
                                           efl_gfx_path_length_get(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  out commands,  out points);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_current_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Current point coordinates</summary>
   /// <param name="x">X co-ordinate of the current point.</param>
   /// <param name="y">Y co-ordinate of the current point.</param>
   /// <returns></returns>
   public  void GetCurrent( out double x,  out double y) {
                                           efl_gfx_path_current_get(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_current_ctrl_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Current control point coordinates</summary>
   /// <param name="x">X co-ordinate of control point.</param>
   /// <param name="y">Y co-ordinate of control point.</param>
   /// <returns></returns>
   public  void GetCurrentCtrl( out double x,  out double y) {
                                           efl_gfx_path_current_ctrl_get(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_copy_from(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object dup_from);
   /// <summary>Copy the path data from the object specified.
   /// 1.18</summary>
   /// <param name="dup_from">Shape object from where data will be copied.</param>
   /// <returns></returns>
   public  void CopyFrom( Efl.Object dup_from) {
                         efl_gfx_path_copy_from(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  dup_from);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_bounds_get(System.IntPtr obj,   out Eina.Rect_StructInternal r);
   /// <summary>Compute and return the bounding box of the currently set path
   /// 1.18</summary>
   /// <param name="r">Contain the bounding box of the currently set path</param>
   /// <returns></returns>
   public  void GetBounds( out Eina.Rect r) {
             var _out_r = new Eina.Rect_StructInternal();
            efl_gfx_path_bounds_get(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  out _out_r);
      Eina.Error.RaiseIfUnhandledException();
      r = Eina.Rect_StructConversion.ToManaged(_out_r);
             }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_reset(System.IntPtr obj);
   /// <summary>Reset the path data of the path object.
   /// 1.18</summary>
   /// <returns></returns>
   public  void Reset() {
       efl_gfx_path_reset(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_move_to(System.IntPtr obj,   double x,   double y);
   /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
   /// See also <see cref="Efl.Gfx.Path.CloseAppend"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the current point.</param>
   /// <param name="y">Y co-ordinate of the current point.</param>
   /// <returns></returns>
   public  void AppendMoveTo( double x,  double y) {
                                           efl_gfx_path_append_move_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_line_to(System.IntPtr obj,   double x,   double y);
   /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
   /// If no current position present, it draws a line to itself, basically a point.
   /// 
   /// See also <see cref="Efl.Gfx.Path.AppendMoveTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <returns></returns>
   public  void AppendLineTo( double x,  double y) {
                                           efl_gfx_path_append_line_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_quadratic_to(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
   /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <param name="ctrl_x">X co-ordinate of control point.</param>
   /// <param name="ctrl_y">Y co-ordinate of control point.</param>
   /// <returns></returns>
   public  void AppendQuadraticTo( double x,  double y,  double ctrl_x,  double ctrl_y) {
                                                                               efl_gfx_path_append_quadratic_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  ctrl_x,  ctrl_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_squadratic_to(System.IntPtr obj,   double x,   double y);
   /// <summary>Same as efl_gfx_path_append_quadratic_to() api only difference is that it uses the current control point to draw the bezier.
   /// See also <see cref="Efl.Gfx.Path.AppendQuadraticTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <returns></returns>
   public  void AppendSquadraticTo( double x,  double y) {
                                           efl_gfx_path_append_squadratic_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_cubic_to(System.IntPtr obj,   double ctrl_x0,   double ctrl_y0,   double ctrl_x1,   double ctrl_y1,   double x,   double y);
   /// <summary>Adds a cubic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x0, ctrl_y0), and (ctrl_x1, ctrl_y1). After the path is drawn, the current position is updated to be at the end point of the path.
   /// 1.18</summary>
   /// <param name="ctrl_x0">X co-ordinate of 1st control point.</param>
   /// <param name="ctrl_y0">Y co-ordinate of 1st control point.</param>
   /// <param name="ctrl_x1">X co-ordinate of 2nd control point.</param>
   /// <param name="ctrl_y1">Y co-ordinate of 2nd control point.</param>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <returns></returns>
   public  void AppendCubicTo( double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y) {
                                                                                                                   efl_gfx_path_append_cubic_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_scubic_to(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
   /// <summary>Same as efl_gfx_path_append_cubic_to() api only difference is that it uses the current control point to draw the bezier.
   /// See also <see cref="Efl.Gfx.Path.AppendCubicTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
   /// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
   /// <returns></returns>
   public  void AppendScubicTo( double x,  double y,  double ctrl_x,  double ctrl_y) {
                                                                               efl_gfx_path_append_scubic_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  ctrl_x,  ctrl_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_arc_to(System.IntPtr obj,   double x,   double y,   double rx,   double ry,   double angle,  [MarshalAs(UnmanagedType.U1)]  bool large_arc,  [MarshalAs(UnmanagedType.U1)]  bool sweep);
   /// <summary>Append an arc that connects from the current point int the point list to the given point (x,y). The arc is defined by the given radius in  x-direction (rx) and radius in y direction (ry).
   /// Use this api if you know the end point&apos;s of the arc otherwise use more convenient function <see cref="Efl.Gfx.Path.AppendArc"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the arc.</param>
   /// <param name="y">Y co-ordinate of end point of the arc.</param>
   /// <param name="rx">Radius of arc in x direction.</param>
   /// <param name="ry">Radius of arc in y direction.</param>
   /// <param name="angle">X-axis rotation , normally 0.</param>
   /// <param name="large_arc">Defines whether to draw the larger arc or smaller arc joining two point.</param>
   /// <param name="sweep">Defines whether the arc will be drawn counter-clockwise or clockwise from current point to the end point taking into account the large_arc property.</param>
   /// <returns></returns>
   public  void AppendArcTo( double x,  double y,  double rx,  double ry,  double angle,  bool large_arc,  bool sweep) {
                                                                                                                                     efl_gfx_path_append_arc_to(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  rx,  ry,  angle,  large_arc,  sweep);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_arc(System.IntPtr obj,   double x,   double y,   double w,   double h,   double start_angle,   double sweep_length);
   /// <summary>Append an arc that enclosed in the given rectangle (x, y, w, h). The angle is defined in counter clock wise , use -ve angle for clockwise arc.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the rect.</param>
   /// <param name="y">Y co-ordinate of the rect.</param>
   /// <param name="w">Width of the rect.</param>
   /// <param name="h">Height of the rect.</param>
   /// <param name="start_angle">Angle at which the arc will start</param>
   /// <param name="sweep_length">@ Length of the arc.</param>
   /// <returns></returns>
   public  void AppendArc( double x,  double y,  double w,  double h,  double start_angle,  double sweep_length) {
                                                                                                                   efl_gfx_path_append_arc(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  w,  h,  start_angle,  sweep_length);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_close(System.IntPtr obj);
   /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
   /// If the subpath does not contain any points, this function does nothing.
   /// 1.18</summary>
   /// <returns></returns>
   public  void CloseAppend() {
       efl_gfx_path_append_close(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_circle(System.IntPtr obj,   double x,   double y,   double radius);
   /// <summary>Append a circle with given center and radius.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the center of the circle.</param>
   /// <param name="y">Y co-ordinate of the center of the circle.</param>
   /// <param name="radius">Radius of the circle.</param>
   /// <returns></returns>
   public  void AppendCircle( double x,  double y,  double radius) {
                                                             efl_gfx_path_append_circle(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  radius);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_rect(System.IntPtr obj,   double x,   double y,   double w,   double h,   double rx,   double ry);
   /// <summary>Append the given rectangle with rounded corner to the path.
   /// The xr and yr arguments specify the radii of the ellipses defining the corners of the rounded rectangle.
   /// 
   /// xr and yr are specified in terms of width and height respectively.
   /// 
   /// If xr and yr are 0, then it will draw a rectangle without rounded corner.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the rectangle.</param>
   /// <param name="y">Y co-ordinate of the rectangle.</param>
   /// <param name="w">Width of the rectangle.</param>
   /// <param name="h">Height of the rectangle.</param>
   /// <param name="rx">The x radius of the rounded corner and should be in range [ 0 to w/2 ]</param>
   /// <param name="ry">The y radius of the rounded corner and should be in range [ 0 to h/2 ]</param>
   /// <returns></returns>
   public  void AppendRect( double x,  double y,  double w,  double h,  double rx,  double ry) {
                                                                                                                   efl_gfx_path_append_rect(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  x,  y,  w,  h,  rx,  ry);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_append_svg_path(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svg_path_data);
   /// <summary>Append SVG path data</summary>
   /// <param name="svg_path_data">SVG path data to append</param>
   /// <returns></returns>
   public  void AppendSvgPath(  System.String svg_path_data) {
                         efl_gfx_path_append_svg_path(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  svg_path_data);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_path_interpolate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object to,   double pos_map);
   /// <summary>Creates intermediary path part-way between two paths
   /// Sets the points of the <c>obj</c> as the linear interpolation of the points in the <c>from</c> and <c>to</c> paths.  The path&apos;s x,y position and control point coordinates are likewise interpolated.
   /// 
   /// The <c>from</c> and <c>to</c> paths must not already have equivalent points, and <c>to</c> must contain at least as many points as <c>from</c>, else the function returns <c>false</c> with no interpolation performed.  If <c>to</c> has more points than <c>from</c>, the excess points are ignored.</summary>
   /// <param name="from">Source path</param>
   /// <param name="to">Destination path</param>
   /// <param name="pos_map">Position map in range 0.0 to 1.0</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool Interpolate( Efl.Object from,  Efl.Object to,  double pos_map) {
                                                             var _ret_var = efl_gfx_path_interpolate(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  from,  to,  pos_map);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_path_equal_commands(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object with);
   /// <summary>Equal commands in object</summary>
   /// <param name="with">Object</param>
   /// <returns>True on success, <c>false</c> otherwise</returns>
   public bool EqualCommands( Efl.Object with) {
                         var _ret_var = efl_gfx_path_equal_commands(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  with);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_reserve(System.IntPtr obj,    uint cmd_count,    uint pts_count);
   /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.
   /// 1.22</summary>
   /// <param name="cmd_count">Commands count to reserve</param>
   /// <param name="pts_count">Pointers count to reserve</param>
   /// <returns></returns>
   public  void Reserve(  uint cmd_count,   uint pts_count) {
                                           efl_gfx_path_reserve(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get(),  cmd_count,  pts_count);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_path_commit(System.IntPtr obj);
   /// <summary>Request to update the path object.
   /// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
   /// <returns></returns>
   public  void Commit() {
       efl_gfx_path_commit(Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class PathConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_path_get_static_delegate = new efl_gfx_path_get_delegate(path_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_get_static_delegate)});
      efl_gfx_path_set_static_delegate = new efl_gfx_path_set_delegate(path_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_set_static_delegate)});
      efl_gfx_path_length_get_static_delegate = new efl_gfx_path_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_length_get_static_delegate)});
      efl_gfx_path_current_get_static_delegate = new efl_gfx_path_current_get_delegate(current_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_current_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_get_static_delegate)});
      efl_gfx_path_current_ctrl_get_static_delegate = new efl_gfx_path_current_ctrl_get_delegate(current_ctrl_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_current_ctrl_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_ctrl_get_static_delegate)});
      efl_gfx_path_copy_from_static_delegate = new efl_gfx_path_copy_from_delegate(copy_from);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_copy_from"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_copy_from_static_delegate)});
      efl_gfx_path_bounds_get_static_delegate = new efl_gfx_path_bounds_get_delegate(bounds_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_bounds_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_bounds_get_static_delegate)});
      efl_gfx_path_reset_static_delegate = new efl_gfx_path_reset_delegate(reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reset_static_delegate)});
      efl_gfx_path_append_move_to_static_delegate = new efl_gfx_path_append_move_to_delegate(append_move_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_move_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_move_to_static_delegate)});
      efl_gfx_path_append_line_to_static_delegate = new efl_gfx_path_append_line_to_delegate(append_line_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_line_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_line_to_static_delegate)});
      efl_gfx_path_append_quadratic_to_static_delegate = new efl_gfx_path_append_quadratic_to_delegate(append_quadratic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_quadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_quadratic_to_static_delegate)});
      efl_gfx_path_append_squadratic_to_static_delegate = new efl_gfx_path_append_squadratic_to_delegate(append_squadratic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_squadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_squadratic_to_static_delegate)});
      efl_gfx_path_append_cubic_to_static_delegate = new efl_gfx_path_append_cubic_to_delegate(append_cubic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_cubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_cubic_to_static_delegate)});
      efl_gfx_path_append_scubic_to_static_delegate = new efl_gfx_path_append_scubic_to_delegate(append_scubic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_scubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_scubic_to_static_delegate)});
      efl_gfx_path_append_arc_to_static_delegate = new efl_gfx_path_append_arc_to_delegate(append_arc_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_arc_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_to_static_delegate)});
      efl_gfx_path_append_arc_static_delegate = new efl_gfx_path_append_arc_delegate(append_arc);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_arc"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_static_delegate)});
      efl_gfx_path_append_close_static_delegate = new efl_gfx_path_append_close_delegate(append_close);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_close"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_close_static_delegate)});
      efl_gfx_path_append_circle_static_delegate = new efl_gfx_path_append_circle_delegate(append_circle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_circle"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_circle_static_delegate)});
      efl_gfx_path_append_rect_static_delegate = new efl_gfx_path_append_rect_delegate(append_rect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_rect"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_rect_static_delegate)});
      efl_gfx_path_append_svg_path_static_delegate = new efl_gfx_path_append_svg_path_delegate(append_svg_path);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_append_svg_path"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_svg_path_static_delegate)});
      efl_gfx_path_interpolate_static_delegate = new efl_gfx_path_interpolate_delegate(interpolate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_interpolate_static_delegate)});
      efl_gfx_path_equal_commands_static_delegate = new efl_gfx_path_equal_commands_delegate(equal_commands);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_equal_commands"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_equal_commands_static_delegate)});
      efl_gfx_path_reserve_static_delegate = new efl_gfx_path_reserve_delegate(reserve);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_reserve"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reserve_static_delegate)});
      efl_gfx_path_commit_static_delegate = new efl_gfx_path_commit_delegate(commit);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_path_commit"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_commit_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.PathConcrete.efl_gfx_path_mixin_get();
   }


    private delegate  void efl_gfx_path_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr op,   out  System.IntPtr points);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_get(System.IntPtr obj,   out  System.IntPtr op,   out  System.IntPtr points);
    private static  void path_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr op,  out  System.IntPtr points)
   {
      Eina.Log.Debug("function efl_gfx_path_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.PathCommandType _out_op = default(Efl.Gfx.PathCommandType);
      double _out_points = default(double);
                     
         try {
            ((PathConcrete)wrapper).GetPath( out _out_op,  out _out_points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      op = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_op);
      points = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_points);
                        } else {
         efl_gfx_path_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out op,  out points);
      }
   }
   private efl_gfx_path_get_delegate efl_gfx_path_get_static_delegate;


    private delegate  void efl_gfx_path_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr op,    System.IntPtr points);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_set(System.IntPtr obj,    System.IntPtr op,    System.IntPtr points);
    private static  void path_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr op,   System.IntPtr points)
   {
      Eina.Log.Debug("function efl_gfx_path_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(op);
      var _in_points = Eina.PrimitiveConversion.PointerToManaged<double>(points);
                                 
         try {
            ((PathConcrete)wrapper).SetPath( _in_op,  _in_points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  op,  points);
      }
   }
   private efl_gfx_path_set_delegate efl_gfx_path_set_static_delegate;


    private delegate  void efl_gfx_path_length_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  uint commands,   out  uint points);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_length_get(System.IntPtr obj,   out  uint commands,   out  uint points);
    private static  void length_get(System.IntPtr obj, System.IntPtr pd,  out  uint commands,  out  uint points)
   {
      Eina.Log.Debug("function efl_gfx_path_length_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           commands = default( uint);      points = default( uint);                     
         try {
            ((PathConcrete)wrapper).GetLength( out commands,  out points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_length_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out commands,  out points);
      }
   }
   private efl_gfx_path_length_get_delegate efl_gfx_path_length_get_static_delegate;


    private delegate  void efl_gfx_path_current_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_current_get(System.IntPtr obj,   out double x,   out double y);
    private static  void current_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_path_current_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((PathConcrete)wrapper).GetCurrent( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_current_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_path_current_get_delegate efl_gfx_path_current_get_static_delegate;


    private delegate  void efl_gfx_path_current_ctrl_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_current_ctrl_get(System.IntPtr obj,   out double x,   out double y);
    private static  void current_ctrl_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_path_current_ctrl_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((PathConcrete)wrapper).GetCurrentCtrl( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_current_ctrl_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_path_current_ctrl_get_delegate efl_gfx_path_current_ctrl_get_static_delegate;


    private delegate  void efl_gfx_path_copy_from_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object dup_from);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_copy_from(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object dup_from);
    private static  void copy_from(System.IntPtr obj, System.IntPtr pd,  Efl.Object dup_from)
   {
      Eina.Log.Debug("function efl_gfx_path_copy_from was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PathConcrete)wrapper).CopyFrom( dup_from);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_path_copy_from(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dup_from);
      }
   }
   private efl_gfx_path_copy_from_delegate efl_gfx_path_copy_from_static_delegate;


    private delegate  void efl_gfx_path_bounds_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Eina.Rect_StructInternal r);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_bounds_get(System.IntPtr obj,   out Eina.Rect_StructInternal r);
    private static  void bounds_get(System.IntPtr obj, System.IntPtr pd,  out Eina.Rect_StructInternal r)
   {
      Eina.Log.Debug("function efl_gfx_path_bounds_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     Eina.Rect _out_r = default(Eina.Rect);
               
         try {
            ((PathConcrete)wrapper).GetBounds( out _out_r);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      r = Eina.Rect_StructConversion.ToInternal(_out_r);
                  } else {
         efl_gfx_path_bounds_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r);
      }
   }
   private efl_gfx_path_bounds_get_delegate efl_gfx_path_bounds_get_static_delegate;


    private delegate  void efl_gfx_path_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_reset(System.IntPtr obj);
    private static  void reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PathConcrete)wrapper).Reset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_path_reset_delegate efl_gfx_path_reset_static_delegate;


    private delegate  void efl_gfx_path_append_move_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_move_to(System.IntPtr obj,   double x,   double y);
    private static  void append_move_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_move_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PathConcrete)wrapper).AppendMoveTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_move_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_path_append_move_to_delegate efl_gfx_path_append_move_to_static_delegate;


    private delegate  void efl_gfx_path_append_line_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_line_to(System.IntPtr obj,   double x,   double y);
    private static  void append_line_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_line_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PathConcrete)wrapper).AppendLineTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_line_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_path_append_line_to_delegate efl_gfx_path_append_line_to_static_delegate;


    private delegate  void efl_gfx_path_append_quadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double ctrl_x,   double ctrl_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_quadratic_to(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
    private static  void append_quadratic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_quadratic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((PathConcrete)wrapper).AppendQuadraticTo( x,  y,  ctrl_x,  ctrl_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_path_append_quadratic_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  ctrl_x,  ctrl_y);
      }
   }
   private efl_gfx_path_append_quadratic_to_delegate efl_gfx_path_append_quadratic_to_static_delegate;


    private delegate  void efl_gfx_path_append_squadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_squadratic_to(System.IntPtr obj,   double x,   double y);
    private static  void append_squadratic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_squadratic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PathConcrete)wrapper).AppendSquadraticTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_squadratic_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_path_append_squadratic_to_delegate efl_gfx_path_append_squadratic_to_static_delegate;


    private delegate  void efl_gfx_path_append_cubic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double ctrl_x0,   double ctrl_y0,   double ctrl_x1,   double ctrl_y1,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_cubic_to(System.IntPtr obj,   double ctrl_x0,   double ctrl_y0,   double ctrl_x1,   double ctrl_y1,   double x,   double y);
    private static  void append_cubic_to(System.IntPtr obj, System.IntPtr pd,  double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_cubic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((PathConcrete)wrapper).AppendCubicTo( ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_cubic_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
      }
   }
   private efl_gfx_path_append_cubic_to_delegate efl_gfx_path_append_cubic_to_static_delegate;


    private delegate  void efl_gfx_path_append_scubic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double ctrl_x,   double ctrl_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_scubic_to(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
    private static  void append_scubic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_scubic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((PathConcrete)wrapper).AppendScubicTo( x,  y,  ctrl_x,  ctrl_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_path_append_scubic_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  ctrl_x,  ctrl_y);
      }
   }
   private efl_gfx_path_append_scubic_to_delegate efl_gfx_path_append_scubic_to_static_delegate;


    private delegate  void efl_gfx_path_append_arc_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double rx,   double ry,   double angle,  [MarshalAs(UnmanagedType.U1)]  bool large_arc,  [MarshalAs(UnmanagedType.U1)]  bool sweep);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_arc_to(System.IntPtr obj,   double x,   double y,   double rx,   double ry,   double angle,  [MarshalAs(UnmanagedType.U1)]  bool large_arc,  [MarshalAs(UnmanagedType.U1)]  bool sweep);
    private static  void append_arc_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double rx,  double ry,  double angle,  bool large_arc,  bool sweep)
   {
      Eina.Log.Debug("function efl_gfx_path_append_arc_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((PathConcrete)wrapper).AppendArcTo( x,  y,  rx,  ry,  angle,  large_arc,  sweep);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_path_append_arc_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  rx,  ry,  angle,  large_arc,  sweep);
      }
   }
   private efl_gfx_path_append_arc_to_delegate efl_gfx_path_append_arc_to_static_delegate;


    private delegate  void efl_gfx_path_append_arc_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double w,   double h,   double start_angle,   double sweep_length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_arc(System.IntPtr obj,   double x,   double y,   double w,   double h,   double start_angle,   double sweep_length);
    private static  void append_arc(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double start_angle,  double sweep_length)
   {
      Eina.Log.Debug("function efl_gfx_path_append_arc was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((PathConcrete)wrapper).AppendArc( x,  y,  w,  h,  start_angle,  sweep_length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_arc(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  w,  h,  start_angle,  sweep_length);
      }
   }
   private efl_gfx_path_append_arc_delegate efl_gfx_path_append_arc_static_delegate;


    private delegate  void efl_gfx_path_append_close_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_close(System.IntPtr obj);
    private static  void append_close(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_append_close was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PathConcrete)wrapper).CloseAppend();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_append_close(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_path_append_close_delegate efl_gfx_path_append_close_static_delegate;


    private delegate  void efl_gfx_path_append_circle_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double radius);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_circle(System.IntPtr obj,   double x,   double y,   double radius);
    private static  void append_circle(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double radius)
   {
      Eina.Log.Debug("function efl_gfx_path_append_circle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((PathConcrete)wrapper).AppendCircle( x,  y,  radius);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_path_append_circle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  radius);
      }
   }
   private efl_gfx_path_append_circle_delegate efl_gfx_path_append_circle_static_delegate;


    private delegate  void efl_gfx_path_append_rect_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double w,   double h,   double rx,   double ry);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_rect(System.IntPtr obj,   double x,   double y,   double w,   double h,   double rx,   double ry);
    private static  void append_rect(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double rx,  double ry)
   {
      Eina.Log.Debug("function efl_gfx_path_append_rect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((PathConcrete)wrapper).AppendRect( x,  y,  w,  h,  rx,  ry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_rect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  w,  h,  rx,  ry);
      }
   }
   private efl_gfx_path_append_rect_delegate efl_gfx_path_append_rect_static_delegate;


    private delegate  void efl_gfx_path_append_svg_path_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svg_path_data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_append_svg_path(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svg_path_data);
    private static  void append_svg_path(System.IntPtr obj, System.IntPtr pd,   System.String svg_path_data)
   {
      Eina.Log.Debug("function efl_gfx_path_append_svg_path was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((PathConcrete)wrapper).AppendSvgPath( svg_path_data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_path_append_svg_path(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  svg_path_data);
      }
   }
   private efl_gfx_path_append_svg_path_delegate efl_gfx_path_append_svg_path_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_path_interpolate_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object to,   double pos_map);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_path_interpolate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object to,   double pos_map);
    private static bool interpolate(System.IntPtr obj, System.IntPtr pd,  Efl.Object from,  Efl.Object to,  double pos_map)
   {
      Eina.Log.Debug("function efl_gfx_path_interpolate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((PathConcrete)wrapper).Interpolate( from,  to,  pos_map);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_gfx_path_interpolate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from,  to,  pos_map);
      }
   }
   private efl_gfx_path_interpolate_delegate efl_gfx_path_interpolate_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_path_equal_commands_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object with);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_path_equal_commands(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object with);
    private static bool equal_commands(System.IntPtr obj, System.IntPtr pd,  Efl.Object with)
   {
      Eina.Log.Debug("function efl_gfx_path_equal_commands was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((PathConcrete)wrapper).EqualCommands( with);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_path_equal_commands(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  with);
      }
   }
   private efl_gfx_path_equal_commands_delegate efl_gfx_path_equal_commands_static_delegate;


    private delegate  void efl_gfx_path_reserve_delegate(System.IntPtr obj, System.IntPtr pd,    uint cmd_count,    uint pts_count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_reserve(System.IntPtr obj,    uint cmd_count,    uint pts_count);
    private static  void reserve(System.IntPtr obj, System.IntPtr pd,   uint cmd_count,   uint pts_count)
   {
      Eina.Log.Debug("function efl_gfx_path_reserve was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((PathConcrete)wrapper).Reserve( cmd_count,  pts_count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_reserve(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cmd_count,  pts_count);
      }
   }
   private efl_gfx_path_reserve_delegate efl_gfx_path_reserve_static_delegate;


    private delegate  void efl_gfx_path_commit_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_path_commit(System.IntPtr obj);
    private static  void commit(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_commit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PathConcrete)wrapper).Commit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_commit(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_path_commit_delegate efl_gfx_path_commit_static_delegate;
}
} } 
