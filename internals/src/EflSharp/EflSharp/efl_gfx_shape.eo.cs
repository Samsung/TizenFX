#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>EFL graphics shape object interface</summary>
[ShapeNativeInherit]
public interface Shape : 
   Efl.Gfx.Path ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
/// 1.14</summary>
/// <returns>Stroke scale value</returns>
double GetStrokeScale();
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
/// 1.14</summary>
/// <param name="s">Stroke scale value</param>
/// <returns></returns>
 void SetStrokeScale( double s);
   /// <summary>The color to be used for stroking the path.
/// 1.14</summary>
/// <param name="r">The red component of the given color.</param>
/// <param name="g">The green component of the given color.</param>
/// <param name="b">The blue component of the given color.</param>
/// <param name="a">The alpha component of the given color.</param>
/// <returns></returns>
 void GetStrokeColor( out  int r,  out  int g,  out  int b,  out  int a);
   /// <summary>The color to be used for stroking the path.
/// 1.14</summary>
/// <param name="r">The red component of the given color.</param>
/// <param name="g">The green component of the given color.</param>
/// <param name="b">The blue component of the given color.</param>
/// <param name="a">The alpha component of the given color.</param>
/// <returns></returns>
 void SetStrokeColor(  int r,   int g,   int b,   int a);
   /// <summary>The stroke width to be used for stroking the path.
/// 1.14</summary>
/// <returns>Stroke width to be used</returns>
double GetStrokeWidth();
   /// <summary>The stroke width to be used for stroking the path.
/// 1.14</summary>
/// <param name="w">Stroke width to be used</param>
/// <returns></returns>
 void SetStrokeWidth( double w);
   /// <summary>Not implemented</summary>
/// <returns>Centered stroke location</returns>
double GetStrokeLocation();
   /// <summary>Not implemented</summary>
/// <param name="centered">Centered stroke location</param>
/// <returns></returns>
 void SetStrokeLocation( double centered);
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
/// See also <see cref="Efl.Gfx.Dash"/></summary>
/// <param name="dash">Stroke dash</param>
/// <param name="length">Stroke dash length</param>
/// <returns></returns>
 void GetStrokeDash( out Efl.Gfx.Dash dash,  out  uint length);
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
/// See also <see cref="Efl.Gfx.Dash"/></summary>
/// <param name="dash">Stroke dash</param>
/// <param name="length">Stroke dash length</param>
/// <returns></returns>
 void SetStrokeDash( ref Efl.Gfx.Dash dash,   uint length);
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
/// See also <see cref="Efl.Gfx.Cap"/>.
/// 1.14</summary>
/// <returns>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></returns>
Efl.Gfx.Cap GetStrokeCap();
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
/// See also <see cref="Efl.Gfx.Cap"/>.
/// 1.14</summary>
/// <param name="c">Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></param>
/// <returns></returns>
 void SetStrokeCap( Efl.Gfx.Cap c);
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
/// See also <see cref="Efl.Gfx.Join"/>.
/// 1.14</summary>
/// <returns>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></returns>
Efl.Gfx.Join GetStrokeJoin();
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
/// See also <see cref="Efl.Gfx.Join"/>.
/// 1.14</summary>
/// <param name="j">Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></param>
/// <returns></returns>
 void SetStrokeJoin( Efl.Gfx.Join j);
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
/// 1.14</summary>
/// <returns>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></returns>
Efl.Gfx.FillRule GetFillRule();
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
/// 1.14</summary>
/// <param name="fill_rule">The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></param>
/// <returns></returns>
 void SetFillRule( Efl.Gfx.FillRule fill_rule);
                                                   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
/// 1.14</summary>
/// <value>Stroke scale value</value>
   double StrokeScale {
      get ;
      set ;
   }
   /// <summary>The stroke width to be used for stroking the path.
/// 1.14</summary>
/// <value>Stroke width to be used</value>
   double StrokeWidth {
      get ;
      set ;
   }
   /// <summary>Not implemented</summary>
/// <value>Centered stroke location</value>
   double StrokeLocation {
      get ;
      set ;
   }
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
/// See also <see cref="Efl.Gfx.Cap"/>.
/// 1.14</summary>
/// <value>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></value>
   Efl.Gfx.Cap StrokeCap {
      get ;
      set ;
   }
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
/// See also <see cref="Efl.Gfx.Join"/>.
/// 1.14</summary>
/// <value>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></value>
   Efl.Gfx.Join StrokeJoin {
      get ;
      set ;
   }
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
/// 1.14</summary>
/// <value>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></value>
   Efl.Gfx.FillRule FillRule {
      get ;
      set ;
   }
}
/// <summary>EFL graphics shape object interface</summary>
sealed public class ShapeConcrete : 

Shape
   , Efl.Gfx.Path
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ShapeConcrete))
            return Efl.Gfx.ShapeNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_shape_mixin_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ShapeConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ShapeConcrete()
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
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ShapeConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ShapeConcrete(obj.NativeHandle);
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
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
   /// 1.14</summary>
   /// <returns>Stroke scale value</returns>
   public double GetStrokeScale() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_scale_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
   /// 1.14</summary>
   /// <param name="s">Stroke scale value</param>
   /// <returns></returns>
   public  void SetStrokeScale( double s) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_scale_set_ptr.Value.Delegate(this.NativeHandle, s);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The color to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="r">The red component of the given color.</param>
   /// <param name="g">The green component of the given color.</param>
   /// <param name="b">The blue component of the given color.</param>
   /// <param name="a">The alpha component of the given color.</param>
   /// <returns></returns>
   public  void GetStrokeColor( out  int r,  out  int g,  out  int b,  out  int a) {
                                                                               Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>The color to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="r">The red component of the given color.</param>
   /// <param name="g">The green component of the given color.</param>
   /// <param name="b">The blue component of the given color.</param>
   /// <param name="a">The alpha component of the given color.</param>
   /// <returns></returns>
   public  void SetStrokeColor(  int r,   int g,   int b,   int a) {
                                                                               Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>The stroke width to be used for stroking the path.
   /// 1.14</summary>
   /// <returns>Stroke width to be used</returns>
   public double GetStrokeWidth() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_width_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The stroke width to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="w">Stroke width to be used</param>
   /// <returns></returns>
   public  void SetStrokeWidth( double w) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_width_set_ptr.Value.Delegate(this.NativeHandle, w);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Not implemented</summary>
   /// <returns>Centered stroke location</returns>
   public double GetStrokeLocation() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_location_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Not implemented</summary>
   /// <param name="centered">Centered stroke location</param>
   /// <returns></returns>
   public  void SetStrokeLocation( double centered) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_location_set_ptr.Value.Delegate(this.NativeHandle, centered);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
   /// See also <see cref="Efl.Gfx.Dash"/></summary>
   /// <param name="dash">Stroke dash</param>
   /// <param name="length">Stroke dash length</param>
   /// <returns></returns>
   public  void GetStrokeDash( out Efl.Gfx.Dash dash,  out  uint length) {
                   var _out_dash = new  System.IntPtr();
                        Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_dash_get_ptr.Value.Delegate(this.NativeHandle, out _out_dash,  out length);
      Eina.Error.RaiseIfUnhandledException();
      dash = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.Dash>(_out_dash);
                         }
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
   /// See also <see cref="Efl.Gfx.Dash"/></summary>
   /// <param name="dash">Stroke dash</param>
   /// <param name="length">Stroke dash length</param>
   /// <returns></returns>
   public  void SetStrokeDash( ref Efl.Gfx.Dash dash,   uint length) {
       var _in_dash = Efl.Gfx.Dash_StructConversion.ToInternal(dash);
                                    Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_dash_set_ptr.Value.Delegate(this.NativeHandle, ref _in_dash,  length);
      Eina.Error.RaiseIfUnhandledException();
                  dash = Efl.Gfx.Dash_StructConversion.ToManaged(_in_dash);
             }
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
   /// See also <see cref="Efl.Gfx.Cap"/>.
   /// 1.14</summary>
   /// <returns>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></returns>
   public Efl.Gfx.Cap GetStrokeCap() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_cap_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
   /// See also <see cref="Efl.Gfx.Cap"/>.
   /// 1.14</summary>
   /// <param name="c">Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></param>
   /// <returns></returns>
   public  void SetStrokeCap( Efl.Gfx.Cap c) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_cap_set_ptr.Value.Delegate(this.NativeHandle, c);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
   /// See also <see cref="Efl.Gfx.Join"/>.
   /// 1.14</summary>
   /// <returns>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></returns>
   public Efl.Gfx.Join GetStrokeJoin() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_join_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
   /// See also <see cref="Efl.Gfx.Join"/>.
   /// 1.14</summary>
   /// <param name="j">Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></param>
   /// <returns></returns>
   public  void SetStrokeJoin( Efl.Gfx.Join j) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_stroke_join_set_ptr.Value.Delegate(this.NativeHandle, j);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
   /// 1.14</summary>
   /// <returns>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></returns>
   public Efl.Gfx.FillRule GetFillRule() {
       var _ret_var = Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_fill_rule_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
   /// 1.14</summary>
   /// <param name="fill_rule">The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></param>
   /// <returns></returns>
   public  void SetFillRule( Efl.Gfx.FillRule fill_rule) {
                         Efl.Gfx.ShapeNativeInherit.efl_gfx_shape_fill_rule_set_ptr.Value.Delegate(this.NativeHandle, fill_rule);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set the list of commands and points to be used to create the content of path.
   /// 1.18</summary>
   /// <param name="op">Command list</param>
   /// <param name="points">Point list</param>
   /// <returns></returns>
   public  void GetPath( out Efl.Gfx.PathCommandType op,  out double points) {
                   System.IntPtr _out_op = System.IntPtr.Zero;
      System.IntPtr _out_points = System.IntPtr.Zero;
                  Efl.Gfx.PathNativeInherit.efl_gfx_path_get_ptr.Value.Delegate(this.NativeHandle, out _out_op,  out _out_points);
      Eina.Error.RaiseIfUnhandledException();
      op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(_out_op);
      points = Eina.PrimitiveConversion.PointerToManaged<double>(_out_points);
                   }
   /// <summary>Set the list of commands and points to be used to create the content of path.
   /// 1.18</summary>
   /// <param name="op">Command list</param>
   /// <param name="points">Point list</param>
   /// <returns></returns>
   public  void SetPath( Efl.Gfx.PathCommandType op,  double points) {
       var _in_op = Eina.PrimitiveConversion.ManagedToPointerAlloc(op);
      var _in_points = Eina.PrimitiveConversion.ManagedToPointerAlloc(points);
                              Efl.Gfx.PathNativeInherit.efl_gfx_path_set_ptr.Value.Delegate(this.NativeHandle, _in_op,  _in_points);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Path length property</summary>
   /// <param name="commands">Commands</param>
   /// <param name="points">Points</param>
   /// <returns></returns>
   public  void GetLength( out  uint commands,  out  uint points) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_length_get_ptr.Value.Delegate(this.NativeHandle, out commands,  out points);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Current point coordinates</summary>
   /// <param name="x">X co-ordinate of the current point.</param>
   /// <param name="y">Y co-ordinate of the current point.</param>
   /// <returns></returns>
   public  void GetCurrent( out double x,  out double y) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_current_get_ptr.Value.Delegate(this.NativeHandle, out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Current control point coordinates</summary>
   /// <param name="x">X co-ordinate of control point.</param>
   /// <param name="y">Y co-ordinate of control point.</param>
   /// <returns></returns>
   public  void GetCurrentCtrl( out double x,  out double y) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_current_ctrl_get_ptr.Value.Delegate(this.NativeHandle, out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Copy the path data from the object specified.
   /// 1.18</summary>
   /// <param name="dup_from">Shape object from where data will be copied.</param>
   /// <returns></returns>
   public  void CopyFrom( Efl.Object dup_from) {
                         Efl.Gfx.PathNativeInherit.efl_gfx_path_copy_from_ptr.Value.Delegate(this.NativeHandle, dup_from);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Compute and return the bounding box of the currently set path
   /// 1.18</summary>
   /// <param name="r">Contain the bounding box of the currently set path</param>
   /// <returns></returns>
   public  void GetBounds( out Eina.Rect r) {
             var _out_r = new Eina.Rect_StructInternal();
            Efl.Gfx.PathNativeInherit.efl_gfx_path_bounds_get_ptr.Value.Delegate(this.NativeHandle, out _out_r);
      Eina.Error.RaiseIfUnhandledException();
      r = Eina.Rect_StructConversion.ToManaged(_out_r);
             }
   /// <summary>Reset the path data of the path object.
   /// 1.18</summary>
   /// <returns></returns>
   public  void Reset() {
       Efl.Gfx.PathNativeInherit.efl_gfx_path_reset_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
   /// See also <see cref="Efl.Gfx.Path.CloseAppend"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the current point.</param>
   /// <param name="y">Y co-ordinate of the current point.</param>
   /// <returns></returns>
   public  void AppendMoveTo( double x,  double y) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_append_move_to_ptr.Value.Delegate(this.NativeHandle, x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
   /// If no current position present, it draws a line to itself, basically a point.
   /// 
   /// See also <see cref="Efl.Gfx.Path.AppendMoveTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <returns></returns>
   public  void AppendLineTo( double x,  double y) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_append_line_to_ptr.Value.Delegate(this.NativeHandle, x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <param name="ctrl_x">X co-ordinate of control point.</param>
   /// <param name="ctrl_y">Y co-ordinate of control point.</param>
   /// <returns></returns>
   public  void AppendQuadraticTo( double x,  double y,  double ctrl_x,  double ctrl_y) {
                                                                               Efl.Gfx.PathNativeInherit.efl_gfx_path_append_quadratic_to_ptr.Value.Delegate(this.NativeHandle, x,  y,  ctrl_x,  ctrl_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Same as efl_gfx_path_append_quadratic_to() api only difference is that it uses the current control point to draw the bezier.
   /// See also <see cref="Efl.Gfx.Path.AppendQuadraticTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <returns></returns>
   public  void AppendSquadraticTo( double x,  double y) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_append_squadratic_to_ptr.Value.Delegate(this.NativeHandle, x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
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
                                                                                                                   Efl.Gfx.PathNativeInherit.efl_gfx_path_append_cubic_to_ptr.Value.Delegate(this.NativeHandle, ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }
   /// <summary>Same as efl_gfx_path_append_cubic_to() api only difference is that it uses the current control point to draw the bezier.
   /// See also <see cref="Efl.Gfx.Path.AppendCubicTo"/>.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of end point of the line.</param>
   /// <param name="y">Y co-ordinate of end point of the line.</param>
   /// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
   /// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
   /// <returns></returns>
   public  void AppendScubicTo( double x,  double y,  double ctrl_x,  double ctrl_y) {
                                                                               Efl.Gfx.PathNativeInherit.efl_gfx_path_append_scubic_to_ptr.Value.Delegate(this.NativeHandle, x,  y,  ctrl_x,  ctrl_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
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
                                                                                                                                     Efl.Gfx.PathNativeInherit.efl_gfx_path_append_arc_to_ptr.Value.Delegate(this.NativeHandle, x,  y,  rx,  ry,  angle,  large_arc,  sweep);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }
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
                                                                                                                   Efl.Gfx.PathNativeInherit.efl_gfx_path_append_arc_ptr.Value.Delegate(this.NativeHandle, x,  y,  w,  h,  start_angle,  sweep_length);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }
   /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
   /// If the subpath does not contain any points, this function does nothing.
   /// 1.18</summary>
   /// <returns></returns>
   public  void CloseAppend() {
       Efl.Gfx.PathNativeInherit.efl_gfx_path_append_close_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Append a circle with given center and radius.
   /// 1.18</summary>
   /// <param name="x">X co-ordinate of the center of the circle.</param>
   /// <param name="y">Y co-ordinate of the center of the circle.</param>
   /// <param name="radius">Radius of the circle.</param>
   /// <returns></returns>
   public  void AppendCircle( double x,  double y,  double radius) {
                                                             Efl.Gfx.PathNativeInherit.efl_gfx_path_append_circle_ptr.Value.Delegate(this.NativeHandle, x,  y,  radius);
      Eina.Error.RaiseIfUnhandledException();
                                           }
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
                                                                                                                   Efl.Gfx.PathNativeInherit.efl_gfx_path_append_rect_ptr.Value.Delegate(this.NativeHandle, x,  y,  w,  h,  rx,  ry);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }
   /// <summary>Append SVG path data</summary>
   /// <param name="svg_path_data">SVG path data to append</param>
   /// <returns></returns>
   public  void AppendSvgPath(  System.String svg_path_data) {
                         Efl.Gfx.PathNativeInherit.efl_gfx_path_append_svg_path_ptr.Value.Delegate(this.NativeHandle, svg_path_data);
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
   public bool Interpolate( Efl.Object from,  Efl.Object to,  double pos_map) {
                                                             var _ret_var = Efl.Gfx.PathNativeInherit.efl_gfx_path_interpolate_ptr.Value.Delegate(this.NativeHandle, from,  to,  pos_map);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Equal commands in object</summary>
   /// <param name="with">Object</param>
   /// <returns>True on success, <c>false</c> otherwise</returns>
   public bool EqualCommands( Efl.Object with) {
                         var _ret_var = Efl.Gfx.PathNativeInherit.efl_gfx_path_equal_commands_ptr.Value.Delegate(this.NativeHandle, with);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.
   /// 1.22</summary>
   /// <param name="cmd_count">Commands count to reserve</param>
   /// <param name="pts_count">Pointers count to reserve</param>
   /// <returns></returns>
   public  void Reserve(  uint cmd_count,   uint pts_count) {
                                           Efl.Gfx.PathNativeInherit.efl_gfx_path_reserve_ptr.Value.Delegate(this.NativeHandle, cmd_count,  pts_count);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Request to update the path object.
   /// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
   /// <returns></returns>
   public  void Commit() {
       Efl.Gfx.PathNativeInherit.efl_gfx_path_commit_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
/// 1.14</summary>
/// <value>Stroke scale value</value>
   public double StrokeScale {
      get { return GetStrokeScale(); }
      set { SetStrokeScale( value); }
   }
   /// <summary>The stroke width to be used for stroking the path.
/// 1.14</summary>
/// <value>Stroke width to be used</value>
   public double StrokeWidth {
      get { return GetStrokeWidth(); }
      set { SetStrokeWidth( value); }
   }
   /// <summary>Not implemented</summary>
/// <value>Centered stroke location</value>
   public double StrokeLocation {
      get { return GetStrokeLocation(); }
      set { SetStrokeLocation( value); }
   }
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
/// See also <see cref="Efl.Gfx.Cap"/>.
/// 1.14</summary>
/// <value>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></value>
   public Efl.Gfx.Cap StrokeCap {
      get { return GetStrokeCap(); }
      set { SetStrokeCap( value); }
   }
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
/// See also <see cref="Efl.Gfx.Join"/>.
/// 1.14</summary>
/// <value>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></value>
   public Efl.Gfx.Join StrokeJoin {
      get { return GetStrokeJoin(); }
      set { SetStrokeJoin( value); }
   }
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
/// 1.14</summary>
/// <value>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></value>
   public Efl.Gfx.FillRule FillRule {
      get { return GetFillRule(); }
      set { SetFillRule( value); }
   }
}
public class ShapeNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_shape_stroke_scale_get_static_delegate == null)
      efl_gfx_shape_stroke_scale_get_static_delegate = new efl_gfx_shape_stroke_scale_get_delegate(stroke_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_scale_get_static_delegate)});
      if (efl_gfx_shape_stroke_scale_set_static_delegate == null)
      efl_gfx_shape_stroke_scale_set_static_delegate = new efl_gfx_shape_stroke_scale_set_delegate(stroke_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_scale_set_static_delegate)});
      if (efl_gfx_shape_stroke_color_get_static_delegate == null)
      efl_gfx_shape_stroke_color_get_static_delegate = new efl_gfx_shape_stroke_color_get_delegate(stroke_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_color_get_static_delegate)});
      if (efl_gfx_shape_stroke_color_set_static_delegate == null)
      efl_gfx_shape_stroke_color_set_static_delegate = new efl_gfx_shape_stroke_color_set_delegate(stroke_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_color_set_static_delegate)});
      if (efl_gfx_shape_stroke_width_get_static_delegate == null)
      efl_gfx_shape_stroke_width_get_static_delegate = new efl_gfx_shape_stroke_width_get_delegate(stroke_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_width_get_static_delegate)});
      if (efl_gfx_shape_stroke_width_set_static_delegate == null)
      efl_gfx_shape_stroke_width_set_static_delegate = new efl_gfx_shape_stroke_width_set_delegate(stroke_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_width_set_static_delegate)});
      if (efl_gfx_shape_stroke_location_get_static_delegate == null)
      efl_gfx_shape_stroke_location_get_static_delegate = new efl_gfx_shape_stroke_location_get_delegate(stroke_location_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_location_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_location_get_static_delegate)});
      if (efl_gfx_shape_stroke_location_set_static_delegate == null)
      efl_gfx_shape_stroke_location_set_static_delegate = new efl_gfx_shape_stroke_location_set_delegate(stroke_location_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_location_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_location_set_static_delegate)});
      if (efl_gfx_shape_stroke_dash_get_static_delegate == null)
      efl_gfx_shape_stroke_dash_get_static_delegate = new efl_gfx_shape_stroke_dash_get_delegate(stroke_dash_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_dash_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_dash_get_static_delegate)});
      if (efl_gfx_shape_stroke_dash_set_static_delegate == null)
      efl_gfx_shape_stroke_dash_set_static_delegate = new efl_gfx_shape_stroke_dash_set_delegate(stroke_dash_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_dash_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_dash_set_static_delegate)});
      if (efl_gfx_shape_stroke_cap_get_static_delegate == null)
      efl_gfx_shape_stroke_cap_get_static_delegate = new efl_gfx_shape_stroke_cap_get_delegate(stroke_cap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_cap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_cap_get_static_delegate)});
      if (efl_gfx_shape_stroke_cap_set_static_delegate == null)
      efl_gfx_shape_stroke_cap_set_static_delegate = new efl_gfx_shape_stroke_cap_set_delegate(stroke_cap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_cap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_cap_set_static_delegate)});
      if (efl_gfx_shape_stroke_join_get_static_delegate == null)
      efl_gfx_shape_stroke_join_get_static_delegate = new efl_gfx_shape_stroke_join_get_delegate(stroke_join_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_join_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_join_get_static_delegate)});
      if (efl_gfx_shape_stroke_join_set_static_delegate == null)
      efl_gfx_shape_stroke_join_set_static_delegate = new efl_gfx_shape_stroke_join_set_delegate(stroke_join_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_stroke_join_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_join_set_static_delegate)});
      if (efl_gfx_shape_fill_rule_get_static_delegate == null)
      efl_gfx_shape_fill_rule_get_static_delegate = new efl_gfx_shape_fill_rule_get_delegate(fill_rule_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_fill_rule_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_fill_rule_get_static_delegate)});
      if (efl_gfx_shape_fill_rule_set_static_delegate == null)
      efl_gfx_shape_fill_rule_set_static_delegate = new efl_gfx_shape_fill_rule_set_delegate(fill_rule_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_shape_fill_rule_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_fill_rule_set_static_delegate)});
      if (efl_gfx_path_get_static_delegate == null)
      efl_gfx_path_get_static_delegate = new efl_gfx_path_get_delegate(path_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_get_static_delegate)});
      if (efl_gfx_path_set_static_delegate == null)
      efl_gfx_path_set_static_delegate = new efl_gfx_path_set_delegate(path_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_set_static_delegate)});
      if (efl_gfx_path_length_get_static_delegate == null)
      efl_gfx_path_length_get_static_delegate = new efl_gfx_path_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_length_get_static_delegate)});
      if (efl_gfx_path_current_get_static_delegate == null)
      efl_gfx_path_current_get_static_delegate = new efl_gfx_path_current_get_delegate(current_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_current_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_get_static_delegate)});
      if (efl_gfx_path_current_ctrl_get_static_delegate == null)
      efl_gfx_path_current_ctrl_get_static_delegate = new efl_gfx_path_current_ctrl_get_delegate(current_ctrl_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_current_ctrl_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_current_ctrl_get_static_delegate)});
      if (efl_gfx_path_copy_from_static_delegate == null)
      efl_gfx_path_copy_from_static_delegate = new efl_gfx_path_copy_from_delegate(copy_from);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_copy_from"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_copy_from_static_delegate)});
      if (efl_gfx_path_bounds_get_static_delegate == null)
      efl_gfx_path_bounds_get_static_delegate = new efl_gfx_path_bounds_get_delegate(bounds_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_bounds_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_bounds_get_static_delegate)});
      if (efl_gfx_path_reset_static_delegate == null)
      efl_gfx_path_reset_static_delegate = new efl_gfx_path_reset_delegate(reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reset_static_delegate)});
      if (efl_gfx_path_append_move_to_static_delegate == null)
      efl_gfx_path_append_move_to_static_delegate = new efl_gfx_path_append_move_to_delegate(append_move_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_move_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_move_to_static_delegate)});
      if (efl_gfx_path_append_line_to_static_delegate == null)
      efl_gfx_path_append_line_to_static_delegate = new efl_gfx_path_append_line_to_delegate(append_line_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_line_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_line_to_static_delegate)});
      if (efl_gfx_path_append_quadratic_to_static_delegate == null)
      efl_gfx_path_append_quadratic_to_static_delegate = new efl_gfx_path_append_quadratic_to_delegate(append_quadratic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_quadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_quadratic_to_static_delegate)});
      if (efl_gfx_path_append_squadratic_to_static_delegate == null)
      efl_gfx_path_append_squadratic_to_static_delegate = new efl_gfx_path_append_squadratic_to_delegate(append_squadratic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_squadratic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_squadratic_to_static_delegate)});
      if (efl_gfx_path_append_cubic_to_static_delegate == null)
      efl_gfx_path_append_cubic_to_static_delegate = new efl_gfx_path_append_cubic_to_delegate(append_cubic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_cubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_cubic_to_static_delegate)});
      if (efl_gfx_path_append_scubic_to_static_delegate == null)
      efl_gfx_path_append_scubic_to_static_delegate = new efl_gfx_path_append_scubic_to_delegate(append_scubic_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_scubic_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_scubic_to_static_delegate)});
      if (efl_gfx_path_append_arc_to_static_delegate == null)
      efl_gfx_path_append_arc_to_static_delegate = new efl_gfx_path_append_arc_to_delegate(append_arc_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_arc_to"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_to_static_delegate)});
      if (efl_gfx_path_append_arc_static_delegate == null)
      efl_gfx_path_append_arc_static_delegate = new efl_gfx_path_append_arc_delegate(append_arc);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_arc"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_arc_static_delegate)});
      if (efl_gfx_path_append_close_static_delegate == null)
      efl_gfx_path_append_close_static_delegate = new efl_gfx_path_append_close_delegate(append_close);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_close"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_close_static_delegate)});
      if (efl_gfx_path_append_circle_static_delegate == null)
      efl_gfx_path_append_circle_static_delegate = new efl_gfx_path_append_circle_delegate(append_circle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_circle"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_circle_static_delegate)});
      if (efl_gfx_path_append_rect_static_delegate == null)
      efl_gfx_path_append_rect_static_delegate = new efl_gfx_path_append_rect_delegate(append_rect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_rect"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_rect_static_delegate)});
      if (efl_gfx_path_append_svg_path_static_delegate == null)
      efl_gfx_path_append_svg_path_static_delegate = new efl_gfx_path_append_svg_path_delegate(append_svg_path);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_append_svg_path"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_append_svg_path_static_delegate)});
      if (efl_gfx_path_interpolate_static_delegate == null)
      efl_gfx_path_interpolate_static_delegate = new efl_gfx_path_interpolate_delegate(interpolate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_interpolate_static_delegate)});
      if (efl_gfx_path_equal_commands_static_delegate == null)
      efl_gfx_path_equal_commands_static_delegate = new efl_gfx_path_equal_commands_delegate(equal_commands);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_equal_commands"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_equal_commands_static_delegate)});
      if (efl_gfx_path_reserve_static_delegate == null)
      efl_gfx_path_reserve_static_delegate = new efl_gfx_path_reserve_delegate(reserve);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_reserve"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_reserve_static_delegate)});
      if (efl_gfx_path_commit_static_delegate == null)
      efl_gfx_path_commit_static_delegate = new efl_gfx_path_commit_delegate(commit);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_path_commit"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_path_commit_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ShapeConcrete.efl_gfx_shape_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ShapeConcrete.efl_gfx_shape_mixin_get();
   }


    private delegate double efl_gfx_shape_stroke_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_shape_stroke_scale_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_scale_get_api_delegate> efl_gfx_shape_stroke_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_scale_get_api_delegate>(_Module, "efl_gfx_shape_stroke_scale_get");
    private static double stroke_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetStrokeScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_stroke_scale_get_delegate efl_gfx_shape_stroke_scale_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double s);


    public delegate  void efl_gfx_shape_stroke_scale_set_api_delegate(System.IntPtr obj,   double s);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_scale_set_api_delegate> efl_gfx_shape_stroke_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_scale_set_api_delegate>(_Module, "efl_gfx_shape_stroke_scale_set");
    private static  void stroke_scale_set(System.IntPtr obj, System.IntPtr pd,  double s)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetStrokeScale( s);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
      }
   }
   private static efl_gfx_shape_stroke_scale_set_delegate efl_gfx_shape_stroke_scale_set_static_delegate;


    private delegate  void efl_gfx_shape_stroke_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);


    public delegate  void efl_gfx_shape_stroke_color_get_api_delegate(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_color_get_api_delegate> efl_gfx_shape_stroke_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_color_get_api_delegate>(_Module, "efl_gfx_shape_stroke_color_get");
    private static  void stroke_color_get(System.IntPtr obj, System.IntPtr pd,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( int);      g = default( int);      b = default( int);      a = default( int);                                 
         try {
            ((ShapeConcrete)wrapper).GetStrokeColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_shape_stroke_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_gfx_shape_stroke_color_get_delegate efl_gfx_shape_stroke_color_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);


    public delegate  void efl_gfx_shape_stroke_color_set_api_delegate(System.IntPtr obj,    int r,    int g,    int b,    int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_color_set_api_delegate> efl_gfx_shape_stroke_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_color_set_api_delegate>(_Module, "efl_gfx_shape_stroke_color_set");
    private static  void stroke_color_set(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((ShapeConcrete)wrapper).SetStrokeColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_shape_stroke_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_gfx_shape_stroke_color_set_delegate efl_gfx_shape_stroke_color_set_static_delegate;


    private delegate double efl_gfx_shape_stroke_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_shape_stroke_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_width_get_api_delegate> efl_gfx_shape_stroke_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_width_get_api_delegate>(_Module, "efl_gfx_shape_stroke_width_get");
    private static double stroke_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetStrokeWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_stroke_width_get_delegate efl_gfx_shape_stroke_width_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   double w);


    public delegate  void efl_gfx_shape_stroke_width_set_api_delegate(System.IntPtr obj,   double w);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_width_set_api_delegate> efl_gfx_shape_stroke_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_width_set_api_delegate>(_Module, "efl_gfx_shape_stroke_width_set");
    private static  void stroke_width_set(System.IntPtr obj, System.IntPtr pd,  double w)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetStrokeWidth( w);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w);
      }
   }
   private static efl_gfx_shape_stroke_width_set_delegate efl_gfx_shape_stroke_width_set_static_delegate;


    private delegate double efl_gfx_shape_stroke_location_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_shape_stroke_location_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_location_get_api_delegate> efl_gfx_shape_stroke_location_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_location_get_api_delegate>(_Module, "efl_gfx_shape_stroke_location_get");
    private static double stroke_location_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_location_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetStrokeLocation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_location_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_stroke_location_get_delegate efl_gfx_shape_stroke_location_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_location_set_delegate(System.IntPtr obj, System.IntPtr pd,   double centered);


    public delegate  void efl_gfx_shape_stroke_location_set_api_delegate(System.IntPtr obj,   double centered);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_location_set_api_delegate> efl_gfx_shape_stroke_location_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_location_set_api_delegate>(_Module, "efl_gfx_shape_stroke_location_set");
    private static  void stroke_location_set(System.IntPtr obj, System.IntPtr pd,  double centered)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_location_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetStrokeLocation( centered);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_location_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  centered);
      }
   }
   private static efl_gfx_shape_stroke_location_set_delegate efl_gfx_shape_stroke_location_set_static_delegate;


    private delegate  void efl_gfx_shape_stroke_dash_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr dash,   out  uint length);


    public delegate  void efl_gfx_shape_stroke_dash_get_api_delegate(System.IntPtr obj,   out  System.IntPtr dash,   out  uint length);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_dash_get_api_delegate> efl_gfx_shape_stroke_dash_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_dash_get_api_delegate>(_Module, "efl_gfx_shape_stroke_dash_get");
    private static  void stroke_dash_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr dash,  out  uint length)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_dash_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.Dash _out_dash = default(Efl.Gfx.Dash);
      length = default( uint);                     
         try {
            ((ShapeConcrete)wrapper).GetStrokeDash( out _out_dash,  out length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      dash = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_dash);
                              } else {
         efl_gfx_shape_stroke_dash_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dash,  out length);
      }
   }
   private static efl_gfx_shape_stroke_dash_get_delegate efl_gfx_shape_stroke_dash_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_dash_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.Dash_StructInternal dash,    uint length);


    public delegate  void efl_gfx_shape_stroke_dash_set_api_delegate(System.IntPtr obj,   ref Efl.Gfx.Dash_StructInternal dash,    uint length);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_dash_set_api_delegate> efl_gfx_shape_stroke_dash_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_dash_set_api_delegate>(_Module, "efl_gfx_shape_stroke_dash_set");
    private static  void stroke_dash_set(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.Dash_StructInternal dash,   uint length)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_dash_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_dash = Efl.Gfx.Dash_StructConversion.ToManaged(dash);
                                       
         try {
            ((ShapeConcrete)wrapper).SetStrokeDash( ref _in_dash,  length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  dash = Efl.Gfx.Dash_StructConversion.ToInternal(_in_dash);
                  } else {
         efl_gfx_shape_stroke_dash_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref dash,  length);
      }
   }
   private static efl_gfx_shape_stroke_dash_set_delegate efl_gfx_shape_stroke_dash_set_static_delegate;


    private delegate Efl.Gfx.Cap efl_gfx_shape_stroke_cap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.Cap efl_gfx_shape_stroke_cap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_cap_get_api_delegate> efl_gfx_shape_stroke_cap_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_cap_get_api_delegate>(_Module, "efl_gfx_shape_stroke_cap_get");
    private static Efl.Gfx.Cap stroke_cap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_cap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Cap _ret_var = default(Efl.Gfx.Cap);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetStrokeCap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_cap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_stroke_cap_get_delegate efl_gfx_shape_stroke_cap_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_cap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.Cap c);


    public delegate  void efl_gfx_shape_stroke_cap_set_api_delegate(System.IntPtr obj,   Efl.Gfx.Cap c);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_cap_set_api_delegate> efl_gfx_shape_stroke_cap_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_cap_set_api_delegate>(_Module, "efl_gfx_shape_stroke_cap_set");
    private static  void stroke_cap_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Cap c)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_cap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetStrokeCap( c);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_cap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  c);
      }
   }
   private static efl_gfx_shape_stroke_cap_set_delegate efl_gfx_shape_stroke_cap_set_static_delegate;


    private delegate Efl.Gfx.Join efl_gfx_shape_stroke_join_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.Join efl_gfx_shape_stroke_join_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_join_get_api_delegate> efl_gfx_shape_stroke_join_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_join_get_api_delegate>(_Module, "efl_gfx_shape_stroke_join_get");
    private static Efl.Gfx.Join stroke_join_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_join_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Join _ret_var = default(Efl.Gfx.Join);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetStrokeJoin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_join_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_stroke_join_get_delegate efl_gfx_shape_stroke_join_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_join_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.Join j);


    public delegate  void efl_gfx_shape_stroke_join_set_api_delegate(System.IntPtr obj,   Efl.Gfx.Join j);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_join_set_api_delegate> efl_gfx_shape_stroke_join_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_stroke_join_set_api_delegate>(_Module, "efl_gfx_shape_stroke_join_set");
    private static  void stroke_join_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Join j)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_join_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetStrokeJoin( j);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_join_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  j);
      }
   }
   private static efl_gfx_shape_stroke_join_set_delegate efl_gfx_shape_stroke_join_set_static_delegate;


    private delegate Efl.Gfx.FillRule efl_gfx_shape_fill_rule_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.FillRule efl_gfx_shape_fill_rule_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_fill_rule_get_api_delegate> efl_gfx_shape_fill_rule_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_fill_rule_get_api_delegate>(_Module, "efl_gfx_shape_fill_rule_get");
    private static Efl.Gfx.FillRule fill_rule_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_fill_rule_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.FillRule _ret_var = default(Efl.Gfx.FillRule);
         try {
            _ret_var = ((ShapeConcrete)wrapper).GetFillRule();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_fill_rule_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_shape_fill_rule_get_delegate efl_gfx_shape_fill_rule_get_static_delegate;


    private delegate  void efl_gfx_shape_fill_rule_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.FillRule fill_rule);


    public delegate  void efl_gfx_shape_fill_rule_set_api_delegate(System.IntPtr obj,   Efl.Gfx.FillRule fill_rule);
    public static Efl.Eo.FunctionWrapper<efl_gfx_shape_fill_rule_set_api_delegate> efl_gfx_shape_fill_rule_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_shape_fill_rule_set_api_delegate>(_Module, "efl_gfx_shape_fill_rule_set");
    private static  void fill_rule_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.FillRule fill_rule)
   {
      Eina.Log.Debug("function efl_gfx_shape_fill_rule_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).SetFillRule( fill_rule);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_fill_rule_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill_rule);
      }
   }
   private static efl_gfx_shape_fill_rule_set_delegate efl_gfx_shape_fill_rule_set_static_delegate;


    private delegate  void efl_gfx_path_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr op,   out  System.IntPtr points);


    public delegate  void efl_gfx_path_get_api_delegate(System.IntPtr obj,   out  System.IntPtr op,   out  System.IntPtr points);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_get_api_delegate> efl_gfx_path_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_get_api_delegate>(_Module, "efl_gfx_path_get");
    private static  void path_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr op,  out  System.IntPtr points)
   {
      Eina.Log.Debug("function efl_gfx_path_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.PathCommandType _out_op = default(Efl.Gfx.PathCommandType);
      double _out_points = default(double);
                     
         try {
            ((ShapeConcrete)wrapper).GetPath( out _out_op,  out _out_points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      op = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_op);
      points = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_points);
                        } else {
         efl_gfx_path_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out op,  out points);
      }
   }
   private static efl_gfx_path_get_delegate efl_gfx_path_get_static_delegate;


    private delegate  void efl_gfx_path_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr op,    System.IntPtr points);


    public delegate  void efl_gfx_path_set_api_delegate(System.IntPtr obj,    System.IntPtr op,    System.IntPtr points);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_set_api_delegate> efl_gfx_path_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_set_api_delegate>(_Module, "efl_gfx_path_set");
    private static  void path_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr op,   System.IntPtr points)
   {
      Eina.Log.Debug("function efl_gfx_path_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(op);
      var _in_points = Eina.PrimitiveConversion.PointerToManaged<double>(points);
                                 
         try {
            ((ShapeConcrete)wrapper).SetPath( _in_op,  _in_points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  op,  points);
      }
   }
   private static efl_gfx_path_set_delegate efl_gfx_path_set_static_delegate;


    private delegate  void efl_gfx_path_length_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  uint commands,   out  uint points);


    public delegate  void efl_gfx_path_length_get_api_delegate(System.IntPtr obj,   out  uint commands,   out  uint points);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_length_get_api_delegate> efl_gfx_path_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_length_get_api_delegate>(_Module, "efl_gfx_path_length_get");
    private static  void length_get(System.IntPtr obj, System.IntPtr pd,  out  uint commands,  out  uint points)
   {
      Eina.Log.Debug("function efl_gfx_path_length_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           commands = default( uint);      points = default( uint);                     
         try {
            ((ShapeConcrete)wrapper).GetLength( out commands,  out points);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out commands,  out points);
      }
   }
   private static efl_gfx_path_length_get_delegate efl_gfx_path_length_get_static_delegate;


    private delegate  void efl_gfx_path_current_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_path_current_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_current_get_api_delegate> efl_gfx_path_current_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_current_get_api_delegate>(_Module, "efl_gfx_path_current_get");
    private static  void current_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_path_current_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((ShapeConcrete)wrapper).GetCurrent( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_current_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_path_current_get_delegate efl_gfx_path_current_get_static_delegate;


    private delegate  void efl_gfx_path_current_ctrl_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_path_current_ctrl_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_current_ctrl_get_api_delegate> efl_gfx_path_current_ctrl_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_current_ctrl_get_api_delegate>(_Module, "efl_gfx_path_current_ctrl_get");
    private static  void current_ctrl_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_path_current_ctrl_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((ShapeConcrete)wrapper).GetCurrentCtrl( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_current_ctrl_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_path_current_ctrl_get_delegate efl_gfx_path_current_ctrl_get_static_delegate;


    private delegate  void efl_gfx_path_copy_from_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object dup_from);


    public delegate  void efl_gfx_path_copy_from_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object dup_from);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_copy_from_api_delegate> efl_gfx_path_copy_from_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_copy_from_api_delegate>(_Module, "efl_gfx_path_copy_from");
    private static  void copy_from(System.IntPtr obj, System.IntPtr pd,  Efl.Object dup_from)
   {
      Eina.Log.Debug("function efl_gfx_path_copy_from was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).CopyFrom( dup_from);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_path_copy_from_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dup_from);
      }
   }
   private static efl_gfx_path_copy_from_delegate efl_gfx_path_copy_from_static_delegate;


    private delegate  void efl_gfx_path_bounds_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Eina.Rect_StructInternal r);


    public delegate  void efl_gfx_path_bounds_get_api_delegate(System.IntPtr obj,   out Eina.Rect_StructInternal r);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_bounds_get_api_delegate> efl_gfx_path_bounds_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_bounds_get_api_delegate>(_Module, "efl_gfx_path_bounds_get");
    private static  void bounds_get(System.IntPtr obj, System.IntPtr pd,  out Eina.Rect_StructInternal r)
   {
      Eina.Log.Debug("function efl_gfx_path_bounds_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     Eina.Rect _out_r = default(Eina.Rect);
               
         try {
            ((ShapeConcrete)wrapper).GetBounds( out _out_r);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      r = Eina.Rect_StructConversion.ToInternal(_out_r);
                  } else {
         efl_gfx_path_bounds_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r);
      }
   }
   private static efl_gfx_path_bounds_get_delegate efl_gfx_path_bounds_get_static_delegate;


    private delegate  void efl_gfx_path_reset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_path_reset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_reset_api_delegate> efl_gfx_path_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_reset_api_delegate>(_Module, "efl_gfx_path_reset");
    private static  void reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ShapeConcrete)wrapper).Reset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_path_reset_delegate efl_gfx_path_reset_static_delegate;


    private delegate  void efl_gfx_path_append_move_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_path_append_move_to_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_move_to_api_delegate> efl_gfx_path_append_move_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_move_to_api_delegate>(_Module, "efl_gfx_path_append_move_to");
    private static  void append_move_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_move_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ShapeConcrete)wrapper).AppendMoveTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_move_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_path_append_move_to_delegate efl_gfx_path_append_move_to_static_delegate;


    private delegate  void efl_gfx_path_append_line_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_path_append_line_to_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_line_to_api_delegate> efl_gfx_path_append_line_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_line_to_api_delegate>(_Module, "efl_gfx_path_append_line_to");
    private static  void append_line_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_line_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ShapeConcrete)wrapper).AppendLineTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_line_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_path_append_line_to_delegate efl_gfx_path_append_line_to_static_delegate;


    private delegate  void efl_gfx_path_append_quadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double ctrl_x,   double ctrl_y);


    public delegate  void efl_gfx_path_append_quadratic_to_api_delegate(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_quadratic_to_api_delegate> efl_gfx_path_append_quadratic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_quadratic_to_api_delegate>(_Module, "efl_gfx_path_append_quadratic_to");
    private static  void append_quadratic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_quadratic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((ShapeConcrete)wrapper).AppendQuadraticTo( x,  y,  ctrl_x,  ctrl_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_path_append_quadratic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  ctrl_x,  ctrl_y);
      }
   }
   private static efl_gfx_path_append_quadratic_to_delegate efl_gfx_path_append_quadratic_to_static_delegate;


    private delegate  void efl_gfx_path_append_squadratic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_path_append_squadratic_to_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_squadratic_to_api_delegate> efl_gfx_path_append_squadratic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_squadratic_to_api_delegate>(_Module, "efl_gfx_path_append_squadratic_to");
    private static  void append_squadratic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_squadratic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ShapeConcrete)wrapper).AppendSquadraticTo( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_append_squadratic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_path_append_squadratic_to_delegate efl_gfx_path_append_squadratic_to_static_delegate;


    private delegate  void efl_gfx_path_append_cubic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double ctrl_x0,   double ctrl_y0,   double ctrl_x1,   double ctrl_y1,   double x,   double y);


    public delegate  void efl_gfx_path_append_cubic_to_api_delegate(System.IntPtr obj,   double ctrl_x0,   double ctrl_y0,   double ctrl_x1,   double ctrl_y1,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_cubic_to_api_delegate> efl_gfx_path_append_cubic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_cubic_to_api_delegate>(_Module, "efl_gfx_path_append_cubic_to");
    private static  void append_cubic_to(System.IntPtr obj, System.IntPtr pd,  double ctrl_x0,  double ctrl_y0,  double ctrl_x1,  double ctrl_y1,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_cubic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((ShapeConcrete)wrapper).AppendCubicTo( ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_cubic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ctrl_x0,  ctrl_y0,  ctrl_x1,  ctrl_y1,  x,  y);
      }
   }
   private static efl_gfx_path_append_cubic_to_delegate efl_gfx_path_append_cubic_to_static_delegate;


    private delegate  void efl_gfx_path_append_scubic_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double ctrl_x,   double ctrl_y);


    public delegate  void efl_gfx_path_append_scubic_to_api_delegate(System.IntPtr obj,   double x,   double y,   double ctrl_x,   double ctrl_y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_scubic_to_api_delegate> efl_gfx_path_append_scubic_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_scubic_to_api_delegate>(_Module, "efl_gfx_path_append_scubic_to");
    private static  void append_scubic_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double ctrl_x,  double ctrl_y)
   {
      Eina.Log.Debug("function efl_gfx_path_append_scubic_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((ShapeConcrete)wrapper).AppendScubicTo( x,  y,  ctrl_x,  ctrl_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_path_append_scubic_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  ctrl_x,  ctrl_y);
      }
   }
   private static efl_gfx_path_append_scubic_to_delegate efl_gfx_path_append_scubic_to_static_delegate;


    private delegate  void efl_gfx_path_append_arc_to_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double rx,   double ry,   double angle,  [MarshalAs(UnmanagedType.U1)]  bool large_arc,  [MarshalAs(UnmanagedType.U1)]  bool sweep);


    public delegate  void efl_gfx_path_append_arc_to_api_delegate(System.IntPtr obj,   double x,   double y,   double rx,   double ry,   double angle,  [MarshalAs(UnmanagedType.U1)]  bool large_arc,  [MarshalAs(UnmanagedType.U1)]  bool sweep);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_to_api_delegate> efl_gfx_path_append_arc_to_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_to_api_delegate>(_Module, "efl_gfx_path_append_arc_to");
    private static  void append_arc_to(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double rx,  double ry,  double angle,  bool large_arc,  bool sweep)
   {
      Eina.Log.Debug("function efl_gfx_path_append_arc_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((ShapeConcrete)wrapper).AppendArcTo( x,  y,  rx,  ry,  angle,  large_arc,  sweep);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_path_append_arc_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  rx,  ry,  angle,  large_arc,  sweep);
      }
   }
   private static efl_gfx_path_append_arc_to_delegate efl_gfx_path_append_arc_to_static_delegate;


    private delegate  void efl_gfx_path_append_arc_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double w,   double h,   double start_angle,   double sweep_length);


    public delegate  void efl_gfx_path_append_arc_api_delegate(System.IntPtr obj,   double x,   double y,   double w,   double h,   double start_angle,   double sweep_length);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_api_delegate> efl_gfx_path_append_arc_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_arc_api_delegate>(_Module, "efl_gfx_path_append_arc");
    private static  void append_arc(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double start_angle,  double sweep_length)
   {
      Eina.Log.Debug("function efl_gfx_path_append_arc was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((ShapeConcrete)wrapper).AppendArc( x,  y,  w,  h,  start_angle,  sweep_length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_arc_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  w,  h,  start_angle,  sweep_length);
      }
   }
   private static efl_gfx_path_append_arc_delegate efl_gfx_path_append_arc_static_delegate;


    private delegate  void efl_gfx_path_append_close_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_path_append_close_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_close_api_delegate> efl_gfx_path_append_close_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_close_api_delegate>(_Module, "efl_gfx_path_append_close");
    private static  void append_close(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_append_close was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ShapeConcrete)wrapper).CloseAppend();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_append_close_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_path_append_close_delegate efl_gfx_path_append_close_static_delegate;


    private delegate  void efl_gfx_path_append_circle_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double radius);


    public delegate  void efl_gfx_path_append_circle_api_delegate(System.IntPtr obj,   double x,   double y,   double radius);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_circle_api_delegate> efl_gfx_path_append_circle_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_circle_api_delegate>(_Module, "efl_gfx_path_append_circle");
    private static  void append_circle(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double radius)
   {
      Eina.Log.Debug("function efl_gfx_path_append_circle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((ShapeConcrete)wrapper).AppendCircle( x,  y,  radius);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_path_append_circle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  radius);
      }
   }
   private static efl_gfx_path_append_circle_delegate efl_gfx_path_append_circle_static_delegate;


    private delegate  void efl_gfx_path_append_rect_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y,   double w,   double h,   double rx,   double ry);


    public delegate  void efl_gfx_path_append_rect_api_delegate(System.IntPtr obj,   double x,   double y,   double w,   double h,   double rx,   double ry);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_rect_api_delegate> efl_gfx_path_append_rect_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_rect_api_delegate>(_Module, "efl_gfx_path_append_rect");
    private static  void append_rect(System.IntPtr obj, System.IntPtr pd,  double x,  double y,  double w,  double h,  double rx,  double ry)
   {
      Eina.Log.Debug("function efl_gfx_path_append_rect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((ShapeConcrete)wrapper).AppendRect( x,  y,  w,  h,  rx,  ry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_path_append_rect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y,  w,  h,  rx,  ry);
      }
   }
   private static efl_gfx_path_append_rect_delegate efl_gfx_path_append_rect_static_delegate;


    private delegate  void efl_gfx_path_append_svg_path_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svg_path_data);


    public delegate  void efl_gfx_path_append_svg_path_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String svg_path_data);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_append_svg_path_api_delegate> efl_gfx_path_append_svg_path_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_append_svg_path_api_delegate>(_Module, "efl_gfx_path_append_svg_path");
    private static  void append_svg_path(System.IntPtr obj, System.IntPtr pd,   System.String svg_path_data)
   {
      Eina.Log.Debug("function efl_gfx_path_append_svg_path was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ShapeConcrete)wrapper).AppendSvgPath( svg_path_data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_path_append_svg_path_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  svg_path_data);
      }
   }
   private static efl_gfx_path_append_svg_path_delegate efl_gfx_path_append_svg_path_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_path_interpolate_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object to,   double pos_map);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_path_interpolate_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object from, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object to,   double pos_map);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_interpolate_api_delegate> efl_gfx_path_interpolate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_interpolate_api_delegate>(_Module, "efl_gfx_path_interpolate");
    private static bool interpolate(System.IntPtr obj, System.IntPtr pd,  Efl.Object from,  Efl.Object to,  double pos_map)
   {
      Eina.Log.Debug("function efl_gfx_path_interpolate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((ShapeConcrete)wrapper).Interpolate( from,  to,  pos_map);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_gfx_path_interpolate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from,  to,  pos_map);
      }
   }
   private static efl_gfx_path_interpolate_delegate efl_gfx_path_interpolate_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_path_equal_commands_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object with);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_path_equal_commands_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object with);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_equal_commands_api_delegate> efl_gfx_path_equal_commands_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_equal_commands_api_delegate>(_Module, "efl_gfx_path_equal_commands");
    private static bool equal_commands(System.IntPtr obj, System.IntPtr pd,  Efl.Object with)
   {
      Eina.Log.Debug("function efl_gfx_path_equal_commands was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ShapeConcrete)wrapper).EqualCommands( with);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_path_equal_commands_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  with);
      }
   }
   private static efl_gfx_path_equal_commands_delegate efl_gfx_path_equal_commands_static_delegate;


    private delegate  void efl_gfx_path_reserve_delegate(System.IntPtr obj, System.IntPtr pd,    uint cmd_count,    uint pts_count);


    public delegate  void efl_gfx_path_reserve_api_delegate(System.IntPtr obj,    uint cmd_count,    uint pts_count);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_reserve_api_delegate> efl_gfx_path_reserve_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_reserve_api_delegate>(_Module, "efl_gfx_path_reserve");
    private static  void reserve(System.IntPtr obj, System.IntPtr pd,   uint cmd_count,   uint pts_count)
   {
      Eina.Log.Debug("function efl_gfx_path_reserve was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ShapeConcrete)wrapper).Reserve( cmd_count,  pts_count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_path_reserve_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cmd_count,  pts_count);
      }
   }
   private static efl_gfx_path_reserve_delegate efl_gfx_path_reserve_static_delegate;


    private delegate  void efl_gfx_path_commit_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_gfx_path_commit_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_path_commit_api_delegate> efl_gfx_path_commit_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_path_commit_api_delegate>(_Module, "efl_gfx_path_commit");
    private static  void commit(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_path_commit was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ShapeConcrete)wrapper).Commit();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_path_commit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_path_commit_delegate efl_gfx_path_commit_static_delegate;
}
} } 
