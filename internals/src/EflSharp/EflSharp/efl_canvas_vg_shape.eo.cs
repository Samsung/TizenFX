#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Vg { 
/// <summary>Efl vector graphics shape class</summary>
[ShapeNativeInherit]
public class Shape : Efl.Canvas.Vg.Node, Efl.Eo.IWrapper,Efl.Gfx.Shape
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.Vg.ShapeNativeInherit nativeInherit = new Efl.Canvas.Vg.ShapeNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Shape))
            return Efl.Canvas.Vg.ShapeNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Shape obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_vg_shape_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Shape(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Shape", efl_canvas_vg_shape_class_get(), typeof(Shape), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Shape(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Shape(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Shape static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Shape(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_fill_get(System.IntPtr obj);
   /// <summary>Fill of the shape object</summary>
   /// <returns>Fill object</returns>
   virtual public Efl.Canvas.Vg.Node GetFill() {
       var _ret_var = efl_canvas_vg_shape_fill_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_vg_shape_fill_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
   /// <summary>Fill of the shape object</summary>
   /// <param name="f">Fill object</param>
   /// <returns></returns>
   virtual public  void SetFill( Efl.Canvas.Vg.Node f) {
                         efl_canvas_vg_shape_fill_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  f);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_fill_get(System.IntPtr obj);
   /// <summary>Stroke fill of the shape object</summary>
   /// <returns>Stroke fill object</returns>
   virtual public Efl.Canvas.Vg.Node GetStrokeFill() {
       var _ret_var = efl_canvas_vg_shape_stroke_fill_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_vg_shape_stroke_fill_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
   /// <summary>Stroke fill of the shape object</summary>
   /// <param name="f">Stroke fill object</param>
   /// <returns></returns>
   virtual public  void SetStrokeFill( Efl.Canvas.Vg.Node f) {
                         efl_canvas_vg_shape_stroke_fill_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  f);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_marker_get(System.IntPtr obj);
   /// <summary>Stroke marker of the shape object</summary>
   /// <returns>Stroke marker object</returns>
   virtual public Efl.Canvas.Vg.Node GetStrokeMarker() {
       var _ret_var = efl_canvas_vg_shape_stroke_marker_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_vg_shape_stroke_marker_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node m);
   /// <summary>Stroke marker of the shape object</summary>
   /// <param name="m">Stroke marker object</param>
   /// <returns></returns>
   virtual public  void SetStrokeMarker( Efl.Canvas.Vg.Node m) {
                         efl_canvas_vg_shape_stroke_marker_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  m);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_shape_stroke_scale_get(System.IntPtr obj);
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
   /// 1.14</summary>
   /// <returns>Stroke scale value</returns>
   virtual public double GetStrokeScale() {
       var _ret_var = efl_gfx_shape_stroke_scale_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_scale_set(System.IntPtr obj,   double s);
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
   /// 1.14</summary>
   /// <param name="s">Stroke scale value</param>
   /// <returns></returns>
   virtual public  void SetStrokeScale( double s) {
                         efl_gfx_shape_stroke_scale_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  s);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>The color to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="r">The red component of the given color.</param>
   /// <param name="g">The green component of the given color.</param>
   /// <param name="b">The blue component of the given color.</param>
   /// <param name="a">The alpha component of the given color.</param>
   /// <returns></returns>
   virtual public  void GetStrokeColor( out  int r,  out  int g,  out  int b,  out  int a) {
                                                                               efl_gfx_shape_stroke_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
   /// <summary>The color to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="r">The red component of the given color.</param>
   /// <param name="g">The green component of the given color.</param>
   /// <param name="b">The blue component of the given color.</param>
   /// <param name="a">The alpha component of the given color.</param>
   /// <returns></returns>
   virtual public  void SetStrokeColor(  int r,   int g,   int b,   int a) {
                                                                               efl_gfx_shape_stroke_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_shape_stroke_width_get(System.IntPtr obj);
   /// <summary>The stroke width to be used for stroking the path.
   /// 1.14</summary>
   /// <returns>Stroke width to be used</returns>
   virtual public double GetStrokeWidth() {
       var _ret_var = efl_gfx_shape_stroke_width_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_width_set(System.IntPtr obj,   double w);
   /// <summary>The stroke width to be used for stroking the path.
   /// 1.14</summary>
   /// <param name="w">Stroke width to be used</param>
   /// <returns></returns>
   virtual public  void SetStrokeWidth( double w) {
                         efl_gfx_shape_stroke_width_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  w);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_shape_stroke_location_get(System.IntPtr obj);
   /// <summary>Not implemented</summary>
   /// <returns>Centered stroke location</returns>
   virtual public double GetStrokeLocation() {
       var _ret_var = efl_gfx_shape_stroke_location_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_location_set(System.IntPtr obj,   double centered);
   /// <summary>Not implemented</summary>
   /// <param name="centered">Centered stroke location</param>
   /// <returns></returns>
   virtual public  void SetStrokeLocation( double centered) {
                         efl_gfx_shape_stroke_location_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  centered);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_dash_get(System.IntPtr obj,   out  System.IntPtr dash,   out  uint length);
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
   /// See also <see cref="Efl.Gfx.Dash"/></summary>
   /// <param name="dash">Stroke dash</param>
   /// <param name="length">Stroke dash length</param>
   /// <returns></returns>
   virtual public  void GetStrokeDash( out Efl.Gfx.Dash dash,  out  uint length) {
                   var _out_dash = new  System.IntPtr();
                        efl_gfx_shape_stroke_dash_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out _out_dash,  out length);
      Eina.Error.RaiseIfUnhandledException();
      dash = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.Dash>(_out_dash);
                         }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_dash_set(System.IntPtr obj,   ref Efl.Gfx.Dash_StructInternal dash,    uint length);
   /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
   /// See also <see cref="Efl.Gfx.Dash"/></summary>
   /// <param name="dash">Stroke dash</param>
   /// <param name="length">Stroke dash length</param>
   /// <returns></returns>
   virtual public  void SetStrokeDash( ref Efl.Gfx.Dash dash,   uint length) {
       var _in_dash = Efl.Gfx.Dash_StructConversion.ToInternal(dash);
                                    efl_gfx_shape_stroke_dash_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_dash,  length);
      Eina.Error.RaiseIfUnhandledException();
                  dash = Efl.Gfx.Dash_StructConversion.ToManaged(_in_dash);
             }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.Cap efl_gfx_shape_stroke_cap_get(System.IntPtr obj);
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
   /// See also <see cref="Efl.Gfx.Cap"/>.
   /// 1.14</summary>
   /// <returns>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></returns>
   virtual public Efl.Gfx.Cap GetStrokeCap() {
       var _ret_var = efl_gfx_shape_stroke_cap_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_cap_set(System.IntPtr obj,   Efl.Gfx.Cap c);
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
   /// See also <see cref="Efl.Gfx.Cap"/>.
   /// 1.14</summary>
   /// <param name="c">Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></param>
   /// <returns></returns>
   virtual public  void SetStrokeCap( Efl.Gfx.Cap c) {
                         efl_gfx_shape_stroke_cap_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  c);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.Join efl_gfx_shape_stroke_join_get(System.IntPtr obj);
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
   /// See also <see cref="Efl.Gfx.Join"/>.
   /// 1.14</summary>
   /// <returns>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></returns>
   virtual public Efl.Gfx.Join GetStrokeJoin() {
       var _ret_var = efl_gfx_shape_stroke_join_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_stroke_join_set(System.IntPtr obj,   Efl.Gfx.Join j);
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
   /// See also <see cref="Efl.Gfx.Join"/>.
   /// 1.14</summary>
   /// <param name="j">Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></param>
   /// <returns></returns>
   virtual public  void SetStrokeJoin( Efl.Gfx.Join j) {
                         efl_gfx_shape_stroke_join_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  j);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Gfx.FillRule efl_gfx_shape_fill_rule_get(System.IntPtr obj);
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
   /// 1.14</summary>
   /// <returns>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></returns>
   virtual public Efl.Gfx.FillRule GetFillRule() {
       var _ret_var = efl_gfx_shape_fill_rule_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_shape_fill_rule_set(System.IntPtr obj,   Efl.Gfx.FillRule fill_rule);
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
   /// 1.14</summary>
   /// <param name="fill_rule">The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></param>
   /// <returns></returns>
   virtual public  void SetFillRule( Efl.Gfx.FillRule fill_rule) {
                         efl_gfx_shape_fill_rule_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fill_rule);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Fill of the shape object</summary>
   public Efl.Canvas.Vg.Node Fill {
      get { return GetFill(); }
      set { SetFill( value); }
   }
   /// <summary>Stroke fill of the shape object</summary>
   public Efl.Canvas.Vg.Node StrokeFill {
      get { return GetStrokeFill(); }
      set { SetStrokeFill( value); }
   }
   /// <summary>Stroke marker of the shape object</summary>
   public Efl.Canvas.Vg.Node StrokeMarker {
      get { return GetStrokeMarker(); }
      set { SetStrokeMarker( value); }
   }
   /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.
/// 1.14</summary>
   public double StrokeScale {
      get { return GetStrokeScale(); }
      set { SetStrokeScale( value); }
   }
   /// <summary>The stroke width to be used for stroking the path.
/// 1.14</summary>
   public double StrokeWidth {
      get { return GetStrokeWidth(); }
      set { SetStrokeWidth( value); }
   }
   /// <summary>Not implemented</summary>
   public double StrokeLocation {
      get { return GetStrokeLocation(); }
      set { SetStrokeLocation( value); }
   }
   /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
/// See also <see cref="Efl.Gfx.Cap"/>.
/// 1.14</summary>
   public Efl.Gfx.Cap StrokeCap {
      get { return GetStrokeCap(); }
      set { SetStrokeCap( value); }
   }
   /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
/// See also <see cref="Efl.Gfx.Join"/>.
/// 1.14</summary>
   public Efl.Gfx.Join StrokeJoin {
      get { return GetStrokeJoin(); }
      set { SetStrokeJoin( value); }
   }
   /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.
/// 1.14</summary>
   public Efl.Gfx.FillRule FillRule {
      get { return GetFillRule(); }
      set { SetFillRule( value); }
   }
}
public class ShapeNativeInherit : Efl.Canvas.Vg.NodeNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_vg_shape_fill_get_static_delegate = new efl_canvas_vg_shape_fill_get_delegate(fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_fill_get_static_delegate)});
      efl_canvas_vg_shape_fill_set_static_delegate = new efl_canvas_vg_shape_fill_set_delegate(fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_fill_set_static_delegate)});
      efl_canvas_vg_shape_stroke_fill_get_static_delegate = new efl_canvas_vg_shape_stroke_fill_get_delegate(stroke_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_stroke_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_fill_get_static_delegate)});
      efl_canvas_vg_shape_stroke_fill_set_static_delegate = new efl_canvas_vg_shape_stroke_fill_set_delegate(stroke_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_stroke_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_fill_set_static_delegate)});
      efl_canvas_vg_shape_stroke_marker_get_static_delegate = new efl_canvas_vg_shape_stroke_marker_get_delegate(stroke_marker_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_stroke_marker_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_marker_get_static_delegate)});
      efl_canvas_vg_shape_stroke_marker_set_static_delegate = new efl_canvas_vg_shape_stroke_marker_set_delegate(stroke_marker_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_vg_shape_stroke_marker_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_marker_set_static_delegate)});
      efl_gfx_shape_stroke_scale_get_static_delegate = new efl_gfx_shape_stroke_scale_get_delegate(stroke_scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_scale_get_static_delegate)});
      efl_gfx_shape_stroke_scale_set_static_delegate = new efl_gfx_shape_stroke_scale_set_delegate(stroke_scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_scale_set_static_delegate)});
      efl_gfx_shape_stroke_color_get_static_delegate = new efl_gfx_shape_stroke_color_get_delegate(stroke_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_color_get_static_delegate)});
      efl_gfx_shape_stroke_color_set_static_delegate = new efl_gfx_shape_stroke_color_set_delegate(stroke_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_color_set_static_delegate)});
      efl_gfx_shape_stroke_width_get_static_delegate = new efl_gfx_shape_stroke_width_get_delegate(stroke_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_width_get_static_delegate)});
      efl_gfx_shape_stroke_width_set_static_delegate = new efl_gfx_shape_stroke_width_set_delegate(stroke_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_width_set_static_delegate)});
      efl_gfx_shape_stroke_location_get_static_delegate = new efl_gfx_shape_stroke_location_get_delegate(stroke_location_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_location_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_location_get_static_delegate)});
      efl_gfx_shape_stroke_location_set_static_delegate = new efl_gfx_shape_stroke_location_set_delegate(stroke_location_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_location_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_location_set_static_delegate)});
      efl_gfx_shape_stroke_dash_get_static_delegate = new efl_gfx_shape_stroke_dash_get_delegate(stroke_dash_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_dash_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_dash_get_static_delegate)});
      efl_gfx_shape_stroke_dash_set_static_delegate = new efl_gfx_shape_stroke_dash_set_delegate(stroke_dash_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_dash_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_dash_set_static_delegate)});
      efl_gfx_shape_stroke_cap_get_static_delegate = new efl_gfx_shape_stroke_cap_get_delegate(stroke_cap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_cap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_cap_get_static_delegate)});
      efl_gfx_shape_stroke_cap_set_static_delegate = new efl_gfx_shape_stroke_cap_set_delegate(stroke_cap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_cap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_cap_set_static_delegate)});
      efl_gfx_shape_stroke_join_get_static_delegate = new efl_gfx_shape_stroke_join_get_delegate(stroke_join_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_join_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_join_get_static_delegate)});
      efl_gfx_shape_stroke_join_set_static_delegate = new efl_gfx_shape_stroke_join_set_delegate(stroke_join_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_stroke_join_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_stroke_join_set_static_delegate)});
      efl_gfx_shape_fill_rule_get_static_delegate = new efl_gfx_shape_fill_rule_get_delegate(fill_rule_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_fill_rule_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_fill_rule_get_static_delegate)});
      efl_gfx_shape_fill_rule_set_static_delegate = new efl_gfx_shape_fill_rule_set_delegate(fill_rule_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_shape_fill_rule_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_shape_fill_rule_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Vg.Shape.efl_canvas_vg_shape_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.Shape.efl_canvas_vg_shape_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_fill_get(System.IntPtr obj);
    private static Efl.Canvas.Vg.Node fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
         try {
            _ret_var = ((Shape)wrapper).GetFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_vg_shape_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_vg_shape_fill_get_delegate efl_canvas_vg_shape_fill_get_static_delegate;


    private delegate  void efl_canvas_vg_shape_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_vg_shape_fill_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
    private static  void fill_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Vg.Node f)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetFill( f);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_vg_shape_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
      }
   }
   private efl_canvas_vg_shape_fill_set_delegate efl_canvas_vg_shape_fill_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_fill_get(System.IntPtr obj);
    private static Efl.Canvas.Vg.Node stroke_fill_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_stroke_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeFill();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_vg_shape_stroke_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_vg_shape_stroke_fill_get_delegate efl_canvas_vg_shape_stroke_fill_get_static_delegate;


    private delegate  void efl_canvas_vg_shape_stroke_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_vg_shape_stroke_fill_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node f);
    private static  void stroke_fill_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Vg.Node f)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_stroke_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeFill( f);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_vg_shape_stroke_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
      }
   }
   private efl_canvas_vg_shape_stroke_fill_set_delegate efl_canvas_vg_shape_stroke_fill_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_marker_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_marker_get(System.IntPtr obj);
    private static Efl.Canvas.Vg.Node stroke_marker_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_stroke_marker_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeMarker();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_vg_shape_stroke_marker_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_vg_shape_stroke_marker_get_delegate efl_canvas_vg_shape_stroke_marker_get_static_delegate;


    private delegate  void efl_canvas_vg_shape_stroke_marker_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node m);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_vg_shape_stroke_marker_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Vg.Node, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Vg.Node m);
    private static  void stroke_marker_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Vg.Node m)
   {
      Eina.Log.Debug("function efl_canvas_vg_shape_stroke_marker_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeMarker( m);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_vg_shape_stroke_marker_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  m);
      }
   }
   private efl_canvas_vg_shape_stroke_marker_set_delegate efl_canvas_vg_shape_stroke_marker_set_static_delegate;


    private delegate double efl_gfx_shape_stroke_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_shape_stroke_scale_get(System.IntPtr obj);
    private static double stroke_scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_scale_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_stroke_scale_get_delegate efl_gfx_shape_stroke_scale_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double s);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_scale_set(System.IntPtr obj,   double s);
    private static  void stroke_scale_set(System.IntPtr obj, System.IntPtr pd,  double s)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeScale( s);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
      }
   }
   private efl_gfx_shape_stroke_scale_set_delegate efl_gfx_shape_stroke_scale_set_static_delegate;


    private delegate  void efl_gfx_shape_stroke_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    private static  void stroke_color_get(System.IntPtr obj, System.IntPtr pd,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( int);      g = default( int);      b = default( int);      a = default( int);                                 
         try {
            ((Shape)wrapper).GetStrokeColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_shape_stroke_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_shape_stroke_color_get_delegate efl_gfx_shape_stroke_color_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
    private static  void stroke_color_set(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Shape)wrapper).SetStrokeColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_shape_stroke_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_gfx_shape_stroke_color_set_delegate efl_gfx_shape_stroke_color_set_static_delegate;


    private delegate double efl_gfx_shape_stroke_width_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_shape_stroke_width_get(System.IntPtr obj);
    private static double stroke_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_width_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_stroke_width_get_delegate efl_gfx_shape_stroke_width_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   double w);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_width_set(System.IntPtr obj,   double w);
    private static  void stroke_width_set(System.IntPtr obj, System.IntPtr pd,  double w)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeWidth( w);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_width_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w);
      }
   }
   private efl_gfx_shape_stroke_width_set_delegate efl_gfx_shape_stroke_width_set_static_delegate;


    private delegate double efl_gfx_shape_stroke_location_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_shape_stroke_location_get(System.IntPtr obj);
    private static double stroke_location_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_location_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeLocation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_location_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_stroke_location_get_delegate efl_gfx_shape_stroke_location_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_location_set_delegate(System.IntPtr obj, System.IntPtr pd,   double centered);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_location_set(System.IntPtr obj,   double centered);
    private static  void stroke_location_set(System.IntPtr obj, System.IntPtr pd,  double centered)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_location_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeLocation( centered);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_location_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  centered);
      }
   }
   private efl_gfx_shape_stroke_location_set_delegate efl_gfx_shape_stroke_location_set_static_delegate;


    private delegate  void efl_gfx_shape_stroke_dash_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr dash,   out  uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_dash_get(System.IntPtr obj,   out  System.IntPtr dash,   out  uint length);
    private static  void stroke_dash_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr dash,  out  uint length)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_dash_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.Dash _out_dash = default(Efl.Gfx.Dash);
      length = default( uint);                     
         try {
            ((Shape)wrapper).GetStrokeDash( out _out_dash,  out length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      dash = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_dash);
                              } else {
         efl_gfx_shape_stroke_dash_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dash,  out length);
      }
   }
   private efl_gfx_shape_stroke_dash_get_delegate efl_gfx_shape_stroke_dash_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_dash_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.Dash_StructInternal dash,    uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_dash_set(System.IntPtr obj,   ref Efl.Gfx.Dash_StructInternal dash,    uint length);
    private static  void stroke_dash_set(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.Dash_StructInternal dash,   uint length)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_dash_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_dash = Efl.Gfx.Dash_StructConversion.ToManaged(dash);
                                       
         try {
            ((Shape)wrapper).SetStrokeDash( ref _in_dash,  length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  dash = Efl.Gfx.Dash_StructConversion.ToInternal(_in_dash);
                  } else {
         efl_gfx_shape_stroke_dash_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref dash,  length);
      }
   }
   private efl_gfx_shape_stroke_dash_set_delegate efl_gfx_shape_stroke_dash_set_static_delegate;


    private delegate Efl.Gfx.Cap efl_gfx_shape_stroke_cap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.Cap efl_gfx_shape_stroke_cap_get(System.IntPtr obj);
    private static Efl.Gfx.Cap stroke_cap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_cap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Cap _ret_var = default(Efl.Gfx.Cap);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeCap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_cap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_stroke_cap_get_delegate efl_gfx_shape_stroke_cap_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_cap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.Cap c);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_cap_set(System.IntPtr obj,   Efl.Gfx.Cap c);
    private static  void stroke_cap_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Cap c)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_cap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeCap( c);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_cap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  c);
      }
   }
   private efl_gfx_shape_stroke_cap_set_delegate efl_gfx_shape_stroke_cap_set_static_delegate;


    private delegate Efl.Gfx.Join efl_gfx_shape_stroke_join_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.Join efl_gfx_shape_stroke_join_get(System.IntPtr obj);
    private static Efl.Gfx.Join stroke_join_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_join_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Join _ret_var = default(Efl.Gfx.Join);
         try {
            _ret_var = ((Shape)wrapper).GetStrokeJoin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_stroke_join_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_stroke_join_get_delegate efl_gfx_shape_stroke_join_get_static_delegate;


    private delegate  void efl_gfx_shape_stroke_join_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.Join j);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_stroke_join_set(System.IntPtr obj,   Efl.Gfx.Join j);
    private static  void stroke_join_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Join j)
   {
      Eina.Log.Debug("function efl_gfx_shape_stroke_join_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetStrokeJoin( j);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_stroke_join_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  j);
      }
   }
   private efl_gfx_shape_stroke_join_set_delegate efl_gfx_shape_stroke_join_set_static_delegate;


    private delegate Efl.Gfx.FillRule efl_gfx_shape_fill_rule_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.FillRule efl_gfx_shape_fill_rule_get(System.IntPtr obj);
    private static Efl.Gfx.FillRule fill_rule_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_shape_fill_rule_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.FillRule _ret_var = default(Efl.Gfx.FillRule);
         try {
            _ret_var = ((Shape)wrapper).GetFillRule();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_shape_fill_rule_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_shape_fill_rule_get_delegate efl_gfx_shape_fill_rule_get_static_delegate;


    private delegate  void efl_gfx_shape_fill_rule_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.FillRule fill_rule);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_shape_fill_rule_set(System.IntPtr obj,   Efl.Gfx.FillRule fill_rule);
    private static  void fill_rule_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.FillRule fill_rule)
   {
      Eina.Log.Debug("function efl_gfx_shape_fill_rule_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Shape)wrapper).SetFillRule( fill_rule);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_shape_fill_rule_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill_rule);
      }
   }
   private efl_gfx_shape_fill_rule_set_delegate efl_gfx_shape_fill_rule_set_static_delegate;
}
} } } 
