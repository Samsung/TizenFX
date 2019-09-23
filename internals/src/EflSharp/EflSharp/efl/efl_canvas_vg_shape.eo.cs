#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

namespace Vg {

/// <summary>Efl vector graphics shape class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Shape.NativeMethods]
[Efl.Eo.BindingEntity]
public class Shape : Efl.Canvas.Vg.Node, Efl.Gfx.IShape
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Shape))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_vg_shape_class_get();
    /// <summary>Initializes a new instance of the <see cref="Shape"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Shape(Efl.Object parent= null
            ) : base(efl_canvas_vg_shape_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Shape(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Shape"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Shape(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Shape"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Shape(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Fill of the shape object</summary>
    /// <returns>Fill object</returns>
    public virtual Efl.Canvas.Vg.Node GetFill() {
         var _ret_var = Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Fill of the shape object</summary>
    /// <param name="f">Fill object</param>
    public virtual void SetFill(Efl.Canvas.Vg.Node f) {
                                 Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Stroke fill of the shape object</summary>
    /// <returns>Stroke fill object</returns>
    public virtual Efl.Canvas.Vg.Node GetStrokeFill() {
         var _ret_var = Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_stroke_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stroke fill of the shape object</summary>
    /// <param name="f">Stroke fill object</param>
    public virtual void SetStrokeFill(Efl.Canvas.Vg.Node f) {
                                 Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_stroke_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Stroke marker of the shape object</summary>
    /// <returns>Stroke marker object</returns>
    public virtual Efl.Canvas.Vg.Node GetStrokeMarker() {
         var _ret_var = Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_stroke_marker_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stroke marker of the shape object</summary>
    /// <param name="m">Stroke marker object</param>
    public virtual void SetStrokeMarker(Efl.Canvas.Vg.Node m) {
                                 Efl.Canvas.Vg.Shape.NativeMethods.efl_canvas_vg_shape_stroke_marker_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),m);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.</summary>
    /// <returns>Stroke scale value</returns>
    public virtual double GetStrokeScale() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.</summary>
    /// <param name="s">Stroke scale value</param>
    public virtual void SetStrokeScale(double s) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),s);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The color to be used for stroking the path.</summary>
    /// <param name="r">The red component of the given color.</param>
    /// <param name="g">The green component of the given color.</param>
    /// <param name="b">The blue component of the given color.</param>
    /// <param name="a">The alpha component of the given color.</param>
    public virtual void GetStrokeColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>The color to be used for stroking the path.</summary>
    /// <param name="r">The red component of the given color.</param>
    /// <param name="g">The green component of the given color.</param>
    /// <param name="b">The blue component of the given color.</param>
    /// <param name="a">The alpha component of the given color.</param>
    public virtual void SetStrokeColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>The stroke width to be used for stroking the path.</summary>
    /// <returns>Stroke width to be used</returns>
    public virtual double GetStrokeWidth() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The stroke width to be used for stroking the path.</summary>
    /// <param name="w">Stroke width to be used</param>
    public virtual void SetStrokeWidth(double w) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),w);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Not implemented</summary>
    /// <returns>Centered stroke location</returns>
    public virtual double GetStrokeLocation() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_location_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Not implemented</summary>
    /// <param name="centered">Centered stroke location</param>
    public virtual void SetStrokeLocation(double centered) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_location_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),centered);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
    /// See also <see cref="Efl.Gfx.Dash"/></summary>
    /// <param name="dash">Stroke dash</param>
    /// <param name="length">Stroke dash length</param>
    public virtual void GetStrokeDash(out Efl.Gfx.Dash dash, out uint length) {
                         var _out_dash = new System.IntPtr();
                                Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_dash_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_dash, out length);
        Eina.Error.RaiseIfUnhandledException();
        dash = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.Dash>(_out_dash);
                                 }
    /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
    /// See also <see cref="Efl.Gfx.Dash"/></summary>
    /// <param name="dash">Stroke dash</param>
    /// <param name="length">Stroke dash length</param>
    public virtual void SetStrokeDash(ref Efl.Gfx.Dash dash, uint length) {
         Efl.Gfx.Dash.NativeStruct _in_dash = dash;
                                                Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_dash_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_dash, length);
        Eina.Error.RaiseIfUnhandledException();
                        dash = _in_dash;
                 }
    /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
    /// See also <see cref="Efl.Gfx.Cap"/>.</summary>
    /// <returns>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></returns>
    public virtual Efl.Gfx.Cap GetStrokeCap() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_cap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
    /// See also <see cref="Efl.Gfx.Cap"/>.</summary>
    /// <param name="c">Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></param>
    public virtual void SetStrokeCap(Efl.Gfx.Cap c) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_cap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),c);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
    /// See also <see cref="Efl.Gfx.Join"/>.</summary>
    /// <returns>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></returns>
    public virtual Efl.Gfx.Join GetStrokeJoin() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_join_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
    /// See also <see cref="Efl.Gfx.Join"/>.</summary>
    /// <param name="j">Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></param>
    public virtual void SetStrokeJoin(Efl.Gfx.Join j) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_join_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),j);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The stroke_miterlimit is a presentation defining a limit on the ratio of the miter length to the stroke-width used to draw a miter join.</summary>
    /// <returns>Limit value on the ratio of the miter.</returns>
    public virtual double GetStrokeMiterlimit() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_miterlimit_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The stroke_miterlimit is a presentation defining a limit on the ratio of the miter length to the stroke-width used to draw a miter join.</summary>
    /// <param name="miterlimit">Limit value on the ratio of the miter.</param>
    public virtual void SetStrokeMiterlimit(double miterlimit) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_stroke_miterlimit_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),miterlimit);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.</summary>
    /// <returns>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></returns>
    public virtual Efl.Gfx.FillRule GetFillRule() {
         var _ret_var = Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_fill_rule_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.</summary>
    /// <param name="fill_rule">The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></param>
    public virtual void SetFillRule(Efl.Gfx.FillRule fill_rule) {
                                 Efl.Gfx.ShapeConcrete.NativeMethods.efl_gfx_shape_fill_rule_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fill_rule);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Fill of the shape object</summary>
    /// <value>Fill object</value>
    public Efl.Canvas.Vg.Node Fill {
        get { return GetFill(); }
        set { SetFill(value); }
    }
    /// <summary>Stroke fill of the shape object</summary>
    /// <value>Stroke fill object</value>
    public Efl.Canvas.Vg.Node StrokeFill {
        get { return GetStrokeFill(); }
        set { SetStrokeFill(value); }
    }
    /// <summary>Stroke marker of the shape object</summary>
    /// <value>Stroke marker object</value>
    public Efl.Canvas.Vg.Node StrokeMarker {
        get { return GetStrokeMarker(); }
        set { SetStrokeMarker(value); }
    }
    /// <summary>The stroke scale to be used for stroking the path. Will be used along with stroke width property.</summary>
    /// <value>Stroke scale value</value>
    public double StrokeScale {
        get { return GetStrokeScale(); }
        set { SetStrokeScale(value); }
    }
    /// <summary>The color to be used for stroking the path.</summary>
    /// <value>The red component of the given color.</value>
    public (int, int, int, int) StrokeColor {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetStrokeColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetStrokeColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>The stroke width to be used for stroking the path.</summary>
    /// <value>Stroke width to be used</value>
    public double StrokeWidth {
        get { return GetStrokeWidth(); }
        set { SetStrokeWidth(value); }
    }
    /// <summary>Not implemented</summary>
    /// <value>Centered stroke location</value>
    public double StrokeLocation {
        get { return GetStrokeLocation(); }
        set { SetStrokeLocation(value); }
    }
    /// <summary>Set stroke dash pattern. A dash pattern is specified by dashes, an array of <see cref="Efl.Gfx.Dash"/>. <see cref="Efl.Gfx.Dash"/> values(length, gap) must be positive.
    /// See also <see cref="Efl.Gfx.Dash"/></summary>
    /// <value>Stroke dash</value>
    public (Efl.Gfx.Dash, uint) StrokeDash {
        get {
            Efl.Gfx.Dash _out_dash = default(Efl.Gfx.Dash);
            uint _out_length = default(uint);
            GetStrokeDash(out _out_dash,out _out_length);
            return (_out_dash,_out_length);
        }
        set { SetStrokeDash(ref  value.Item1,  value.Item2); }
    }
    /// <summary>The cap style to be used for stroking the path. The cap will be used for capping the end point of a open subpath.
    /// See also <see cref="Efl.Gfx.Cap"/>.</summary>
    /// <value>Cap style to use, default is <see cref="Efl.Gfx.Cap.Butt"/></value>
    public Efl.Gfx.Cap StrokeCap {
        get { return GetStrokeCap(); }
        set { SetStrokeCap(value); }
    }
    /// <summary>The join style to be used for stroking the path. The join style will be used for joining the two line segment while stroking the path.
    /// See also <see cref="Efl.Gfx.Join"/>.</summary>
    /// <value>Join style to use, default is <see cref="Efl.Gfx.Join.Miter"/></value>
    public Efl.Gfx.Join StrokeJoin {
        get { return GetStrokeJoin(); }
        set { SetStrokeJoin(value); }
    }
    /// <summary>The stroke_miterlimit is a presentation defining a limit on the ratio of the miter length to the stroke-width used to draw a miter join.</summary>
    /// <value>Limit value on the ratio of the miter.</value>
    public double StrokeMiterlimit {
        get { return GetStrokeMiterlimit(); }
        set { SetStrokeMiterlimit(value); }
    }
    /// <summary>The fill rule of the given shape object. <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/>.</summary>
    /// <value>The current fill rule of the shape object. One of <see cref="Efl.Gfx.FillRule.Winding"/> or <see cref="Efl.Gfx.FillRule.OddEven"/></value>
    public Efl.Gfx.FillRule FillRule {
        get { return GetFillRule(); }
        set { SetFillRule(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Shape.efl_canvas_vg_shape_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Vg.Node.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_vg_shape_fill_get_static_delegate == null)
            {
                efl_canvas_vg_shape_fill_get_static_delegate = new efl_canvas_vg_shape_fill_get_delegate(fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_fill_get_static_delegate) });
            }

            if (efl_canvas_vg_shape_fill_set_static_delegate == null)
            {
                efl_canvas_vg_shape_fill_set_static_delegate = new efl_canvas_vg_shape_fill_set_delegate(fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_fill_set_static_delegate) });
            }

            if (efl_canvas_vg_shape_stroke_fill_get_static_delegate == null)
            {
                efl_canvas_vg_shape_stroke_fill_get_static_delegate = new efl_canvas_vg_shape_stroke_fill_get_delegate(stroke_fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrokeFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_stroke_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_fill_get_static_delegate) });
            }

            if (efl_canvas_vg_shape_stroke_fill_set_static_delegate == null)
            {
                efl_canvas_vg_shape_stroke_fill_set_static_delegate = new efl_canvas_vg_shape_stroke_fill_set_delegate(stroke_fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrokeFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_stroke_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_fill_set_static_delegate) });
            }

            if (efl_canvas_vg_shape_stroke_marker_get_static_delegate == null)
            {
                efl_canvas_vg_shape_stroke_marker_get_static_delegate = new efl_canvas_vg_shape_stroke_marker_get_delegate(stroke_marker_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrokeMarker") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_stroke_marker_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_marker_get_static_delegate) });
            }

            if (efl_canvas_vg_shape_stroke_marker_set_static_delegate == null)
            {
                efl_canvas_vg_shape_stroke_marker_set_static_delegate = new efl_canvas_vg_shape_stroke_marker_set_delegate(stroke_marker_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrokeMarker") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_shape_stroke_marker_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_shape_stroke_marker_set_static_delegate) });
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
            return Efl.Canvas.Vg.Shape.efl_canvas_vg_shape_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_fill_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_fill_get_api_delegate> efl_canvas_vg_shape_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_fill_get_api_delegate>(Module, "efl_canvas_vg_shape_fill_get");

        private static Efl.Canvas.Vg.Node fill_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
                try
                {
                    _ret_var = ((Shape)ws.Target).GetFill();
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
                return efl_canvas_vg_shape_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_shape_fill_get_delegate efl_canvas_vg_shape_fill_get_static_delegate;

        
        private delegate void efl_canvas_vg_shape_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node f);

        
        public delegate void efl_canvas_vg_shape_fill_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node f);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_fill_set_api_delegate> efl_canvas_vg_shape_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_fill_set_api_delegate>(Module, "efl_canvas_vg_shape_fill_set");

        private static void fill_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.Node f)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Shape)ws.Target).SetFill(f);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_vg_shape_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_canvas_vg_shape_fill_set_delegate efl_canvas_vg_shape_fill_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_fill_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_fill_get_api_delegate> efl_canvas_vg_shape_stroke_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_fill_get_api_delegate>(Module, "efl_canvas_vg_shape_stroke_fill_get");

        private static Efl.Canvas.Vg.Node stroke_fill_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_stroke_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
                try
                {
                    _ret_var = ((Shape)ws.Target).GetStrokeFill();
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
                return efl_canvas_vg_shape_stroke_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_shape_stroke_fill_get_delegate efl_canvas_vg_shape_stroke_fill_get_static_delegate;

        
        private delegate void efl_canvas_vg_shape_stroke_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node f);

        
        public delegate void efl_canvas_vg_shape_stroke_fill_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node f);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_fill_set_api_delegate> efl_canvas_vg_shape_stroke_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_fill_set_api_delegate>(Module, "efl_canvas_vg_shape_stroke_fill_set");

        private static void stroke_fill_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.Node f)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_stroke_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Shape)ws.Target).SetStrokeFill(f);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_vg_shape_stroke_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_canvas_vg_shape_stroke_fill_set_delegate efl_canvas_vg_shape_stroke_fill_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_marker_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Vg.Node efl_canvas_vg_shape_stroke_marker_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_marker_get_api_delegate> efl_canvas_vg_shape_stroke_marker_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_marker_get_api_delegate>(Module, "efl_canvas_vg_shape_stroke_marker_get");

        private static Efl.Canvas.Vg.Node stroke_marker_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_stroke_marker_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
                try
                {
                    _ret_var = ((Shape)ws.Target).GetStrokeMarker();
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
                return efl_canvas_vg_shape_stroke_marker_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_shape_stroke_marker_get_delegate efl_canvas_vg_shape_stroke_marker_get_static_delegate;

        
        private delegate void efl_canvas_vg_shape_stroke_marker_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node m);

        
        public delegate void efl_canvas_vg_shape_stroke_marker_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node m);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_marker_set_api_delegate> efl_canvas_vg_shape_stroke_marker_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_shape_stroke_marker_set_api_delegate>(Module, "efl_canvas_vg_shape_stroke_marker_set");

        private static void stroke_marker_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.Node m)
        {
            Eina.Log.Debug("function efl_canvas_vg_shape_stroke_marker_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Shape)ws.Target).SetStrokeMarker(m);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_vg_shape_stroke_marker_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), m);
            }
        }

        private static efl_canvas_vg_shape_stroke_marker_set_delegate efl_canvas_vg_shape_stroke_marker_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgShape_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Canvas.Vg.Node> Fill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Canvas.Vg.Node>("fill", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Vg.Node> StrokeFill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Canvas.Vg.Node>("stroke_fill", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Vg.Node> StrokeMarker<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Canvas.Vg.Node>("stroke_marker", fac);
    }

    public static Efl.BindableProperty<double> StrokeScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<double>("stroke_scale", fac);
    }

    
    public static Efl.BindableProperty<double> StrokeWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<double>("stroke_width", fac);
    }

    public static Efl.BindableProperty<double> StrokeLocation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<double>("stroke_location", fac);
    }

    
    public static Efl.BindableProperty<Efl.Gfx.Cap> StrokeCap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Gfx.Cap>("stroke_cap", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.Join> StrokeJoin<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Gfx.Join>("stroke_join", fac);
    }

    public static Efl.BindableProperty<double> StrokeMiterlimit<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<double>("stroke_miterlimit", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.FillRule> FillRule<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Shape, T>magic = null) where T : Efl.Canvas.Vg.Shape {
        return new Efl.BindableProperty<Efl.Gfx.FillRule>("fill_rule", fac);
    }

}
#pragma warning restore CS1591
#endif
