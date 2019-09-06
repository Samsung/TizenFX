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

/// <summary>A drop-shadow or glow effect around any widget.
/// A simple drop-shadow effect can be applied to any widget by setting the color and blur radius on this part.
/// 
/// For instance, a blue glow can be achieved with: obj.shadow().color_set(0, 128, 255, 255); obj.shadow().grow_set(2); obj.shadow().radius_set(3, 3);
/// 
/// As another example, here&apos;s a black drop-shadow: obj.shadow().color_set(0, 0, 0, 255); obj.shadow().grow_set(1); obj.shadow().radius_set(5, 5); obj.shadow().offset_set(5, 5);
/// 
/// It is also possible to manually specify which <see cref="Efl.Gfx.IFilter"/> program to use.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.WidgetPartShadow.NativeMethods]
[Efl.Eo.BindingEntity]
public class WidgetPartShadow : Efl.Ui.WidgetPart, Efl.Gfx.IBlur, Efl.Gfx.IColor, Efl.Gfx.IFilter
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WidgetPartShadow))
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
        efl_ui_widget_part_shadow_class_get();
    /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public WidgetPartShadow(Efl.Object parent= null
            ) : base(efl_ui_widget_part_shadow_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected WidgetPartShadow(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected WidgetPartShadow(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetPartShadow"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected WidgetPartShadow(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    virtual public void GetRadius(out double rx, out double ry) {
                                                         Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_radius_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out rx, out ry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    virtual public void SetRadius(double rx, double ry) {
                                                         Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_radius_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),rx, ry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    virtual public void GetOffset(out double ox, out double oy) {
                                                         Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_offset_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out ox, out oy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    virtual public void SetOffset(double ox, double oy) {
                                                         Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_offset_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ox, oy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <returns>How much to grow the original pixel data.</returns>
    virtual public double GetGrow() {
         var _ret_var = Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_grow_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <param name="radius">How much to grow the original pixel data.</param>
    virtual public void SetGrow(double radius) {
                                 Efl.Gfx.IBlurConcrete.NativeMethods.efl_gfx_blur_grow_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),radius);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the general/main color of the given Evas object.
    /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    virtual public void GetColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets the general/main color of the given Evas object to the given one.
    /// See also <see cref="Efl.Gfx.IColor.GetColor"/> (for an example)
    /// 
    /// These color values are expected to be premultiplied by alpha.
    /// (Since EFL 1.22)</summary>
    virtual public void SetColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    virtual public System.String GetColorCode() {
         var _ret_var = Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    virtual public void SetColorCode(System.String colorcode) {
                                 Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),colorcode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    virtual public void GetFilterProgram(out System.String code, out System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out code, out name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set a graphical filter program on this object.
    /// Valid for Text and Image objects at the moment.
    /// 
    /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
    /// 
    /// Set to <c>null</c> to disable filtering.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    virtual public void SetFilterProgram(System.String code, System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code, name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    virtual public void GetFilterState(out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out cur_state, out cur_val, out next_state, out next_val, out pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    virtual public void SetFilterState(System.String cur_state, double cur_val, System.String next_state, double next_val, double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur_state, cur_val, next_state, next_val, pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Gets the padding required to apply this filter.</summary>
    /// <param name="l">Padding on the left</param>
    /// <param name="r">Padding on the right</param>
    /// <param name="t">Padding on the top</param>
    /// <param name="b">Padding on the bottom</param>
    virtual public void GetFilterPadding(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <returns>Object to use as a source of pixels.</returns>
    virtual public Efl.Gfx.IEntity GetFilterSource(System.String name) {
                                 var _ret_var = Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <param name="source">Object to use as a source of pixels.</param>
    virtual public void SetFilterSource(System.String name, Efl.Gfx.IEntity source) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void GetFilterData(System.String name, out System.String value, out bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, out value, out execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void SetFilterData(System.String name, System.String value, bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, value, execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>The blur radius in pixels.</summary>
    /// <value>The horizontal blur radius.</value>
    public (double, double) Radius {
        get {
            double _out_rx = default(double);
            double _out_ry = default(double);
            GetRadius(out _out_rx,out _out_ry);
            return (_out_rx,_out_ry);
        }
        set { SetRadius( value.Item1,  value.Item2); }
    }
    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <value>Horizontal offset in pixels.</value>
    public (double, double) Offset {
        get {
            double _out_ox = default(double);
            double _out_oy = default(double);
            GetOffset(out _out_ox,out _out_oy);
            return (_out_ox,_out_oy);
        }
        set { SetOffset( value.Item1,  value.Item2); }
    }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <value>How much to grow the original pixel data.</value>
    public double Grow {
        get { return GetGrow(); }
        set { SetGrow(value); }
    }
    /// <summary>Retrieves the general/main color of the given Evas object.
    /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
    }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <value>The Lua program source code.</value>
    public (System.String, System.String) FilterProgram {
        get {
            System.String _out_code = default(System.String);
            System.String _out_name = default(System.String);
            GetFilterProgram(out _out_code,out _out_name);
            return (_out_code,_out_name);
        }
        set { SetFilterProgram( value.Item1,  value.Item2); }
    }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <value>Current state of the filter</value>
    public (System.String, double, System.String, double, double) FilterState {
        get {
            System.String _out_cur_state = default(System.String);
            double _out_cur_val = default(double);
            System.String _out_next_state = default(System.String);
            double _out_next_val = default(double);
            double _out_pos = default(double);
            GetFilterState(out _out_cur_state,out _out_cur_val,out _out_next_state,out _out_next_val,out _out_pos);
            return (_out_cur_state,_out_cur_val,_out_next_state,_out_next_val,_out_pos);
        }
        set { SetFilterState( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
    }
    /// <summary>Required padding to apply this filter without cropping.
    /// Read-only property that can be used to calculate the object&apos;s final geometry. This can be overridden (set) from inside the filter program by using the function &apos;padding_set&apos; in the Lua program.</summary>
    public (int, int, int, int) FilterPadding {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetFilterPadding(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WidgetPartShadow.efl_ui_widget_part_shadow_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.WidgetPart.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_blur_radius_get_static_delegate == null)
            {
                efl_gfx_blur_radius_get_static_delegate = new efl_gfx_blur_radius_get_delegate(radius_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_get_static_delegate) });
            }

            if (efl_gfx_blur_radius_set_static_delegate == null)
            {
                efl_gfx_blur_radius_set_static_delegate = new efl_gfx_blur_radius_set_delegate(radius_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_set_static_delegate) });
            }

            if (efl_gfx_blur_offset_get_static_delegate == null)
            {
                efl_gfx_blur_offset_get_static_delegate = new efl_gfx_blur_offset_get_delegate(offset_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_get_static_delegate) });
            }

            if (efl_gfx_blur_offset_set_static_delegate == null)
            {
                efl_gfx_blur_offset_set_static_delegate = new efl_gfx_blur_offset_set_delegate(offset_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_set_static_delegate) });
            }

            if (efl_gfx_blur_grow_get_static_delegate == null)
            {
                efl_gfx_blur_grow_get_static_delegate = new efl_gfx_blur_grow_get_delegate(grow_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGrow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_grow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_get_static_delegate) });
            }

            if (efl_gfx_blur_grow_set_static_delegate == null)
            {
                efl_gfx_blur_grow_set_static_delegate = new efl_gfx_blur_grow_set_delegate(grow_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGrow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_grow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_set_static_delegate) });
            }

            if (efl_gfx_color_get_static_delegate == null)
            {
                efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate) });
            }

            if (efl_gfx_color_set_static_delegate == null)
            {
                efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate) });
            }

            if (efl_gfx_color_code_get_static_delegate == null)
            {
                efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate) });
            }

            if (efl_gfx_color_code_set_static_delegate == null)
            {
                efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate) });
            }

            if (efl_gfx_filter_program_get_static_delegate == null)
            {
                efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate) });
            }

            if (efl_gfx_filter_program_set_static_delegate == null)
            {
                efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate) });
            }

            if (efl_gfx_filter_state_get_static_delegate == null)
            {
                efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate) });
            }

            if (efl_gfx_filter_state_set_static_delegate == null)
            {
                efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate) });
            }

            if (efl_gfx_filter_padding_get_static_delegate == null)
            {
                efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate) });
            }

            if (efl_gfx_filter_source_get_static_delegate == null)
            {
                efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate) });
            }

            if (efl_gfx_filter_source_set_static_delegate == null)
            {
                efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate) });
            }

            if (efl_gfx_filter_data_get_static_delegate == null)
            {
                efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate) });
            }

            if (efl_gfx_filter_data_set_static_delegate == null)
            {
                efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.WidgetPartShadow.efl_ui_widget_part_shadow_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_blur_radius_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double rx,  out double ry);

        
        public delegate void efl_gfx_blur_radius_get_api_delegate(System.IntPtr obj,  out double rx,  out double ry);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate> efl_gfx_blur_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate>(Module, "efl_gfx_blur_radius_get");

        private static void radius_get(System.IntPtr obj, System.IntPtr pd, out double rx, out double ry)
        {
            Eina.Log.Debug("function efl_gfx_blur_radius_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        rx = default(double);        ry = default(double);                            
                try
                {
                    ((WidgetPartShadow)ws.Target).GetRadius(out rx, out ry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_blur_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out rx, out ry);
            }
        }

        private static efl_gfx_blur_radius_get_delegate efl_gfx_blur_radius_get_static_delegate;

        
        private delegate void efl_gfx_blur_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,  double rx,  double ry);

        
        public delegate void efl_gfx_blur_radius_set_api_delegate(System.IntPtr obj,  double rx,  double ry);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate> efl_gfx_blur_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate>(Module, "efl_gfx_blur_radius_set");

        private static void radius_set(System.IntPtr obj, System.IntPtr pd, double rx, double ry)
        {
            Eina.Log.Debug("function efl_gfx_blur_radius_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).SetRadius(rx, ry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_blur_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rx, ry);
            }
        }

        private static efl_gfx_blur_radius_set_delegate efl_gfx_blur_radius_set_static_delegate;

        
        private delegate void efl_gfx_blur_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double ox,  out double oy);

        
        public delegate void efl_gfx_blur_offset_get_api_delegate(System.IntPtr obj,  out double ox,  out double oy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate> efl_gfx_blur_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate>(Module, "efl_gfx_blur_offset_get");

        private static void offset_get(System.IntPtr obj, System.IntPtr pd, out double ox, out double oy)
        {
            Eina.Log.Debug("function efl_gfx_blur_offset_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        ox = default(double);        oy = default(double);                            
                try
                {
                    ((WidgetPartShadow)ws.Target).GetOffset(out ox, out oy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_blur_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out ox, out oy);
            }
        }

        private static efl_gfx_blur_offset_get_delegate efl_gfx_blur_offset_get_static_delegate;

        
        private delegate void efl_gfx_blur_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ox,  double oy);

        
        public delegate void efl_gfx_blur_offset_set_api_delegate(System.IntPtr obj,  double ox,  double oy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate> efl_gfx_blur_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate>(Module, "efl_gfx_blur_offset_set");

        private static void offset_set(System.IntPtr obj, System.IntPtr pd, double ox, double oy)
        {
            Eina.Log.Debug("function efl_gfx_blur_offset_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).SetOffset(ox, oy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_blur_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ox, oy);
            }
        }

        private static efl_gfx_blur_offset_set_delegate efl_gfx_blur_offset_set_static_delegate;

        
        private delegate double efl_gfx_blur_grow_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_blur_grow_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate> efl_gfx_blur_grow_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate>(Module, "efl_gfx_blur_grow_get");

        private static double grow_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_blur_grow_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((WidgetPartShadow)ws.Target).GetGrow();
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
                return efl_gfx_blur_grow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_blur_grow_get_delegate efl_gfx_blur_grow_get_static_delegate;

        
        private delegate void efl_gfx_blur_grow_set_delegate(System.IntPtr obj, System.IntPtr pd,  double radius);

        
        public delegate void efl_gfx_blur_grow_set_api_delegate(System.IntPtr obj,  double radius);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate> efl_gfx_blur_grow_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate>(Module, "efl_gfx_blur_grow_set");

        private static void grow_set(System.IntPtr obj, System.IntPtr pd, double radius)
        {
            Eina.Log.Debug("function efl_gfx_blur_grow_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).SetGrow(radius);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_blur_grow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), radius);
            }
        }

        private static efl_gfx_blur_grow_set_delegate efl_gfx_blur_grow_set_static_delegate;

        
        private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a);

        
        public delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(Module, "efl_gfx_color_get");

        private static void color_get(System.IntPtr obj, System.IntPtr pd, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(int);        g = default(int);        b = default(int);        a = default(int);                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).GetColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;

        
        private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a);

        
        public delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(Module, "efl_gfx_color_set");

        private static void color_set(System.IntPtr obj, System.IntPtr pd, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).SetColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(Module, "efl_gfx_color_code_get");

        private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_color_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((WidgetPartShadow)ws.Target).GetColorCode();
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
                return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;

        
        private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        
        public delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(Module, "efl_gfx_color_code_set");

        private static void color_code_set(System.IntPtr obj, System.IntPtr pd, System.String colorcode)
        {
            Eina.Log.Debug("function efl_gfx_color_code_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).SetColorCode(colorcode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), colorcode);
            }
        }

        private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;

        
        private delegate void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        
        public delegate void efl_gfx_filter_program_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate> efl_gfx_filter_program_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate>(Module, "efl_gfx_filter_program_get");

        private static void filter_program_get(System.IntPtr obj, System.IntPtr pd, out System.String code, out System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_code = default(System.String);
        System.String _out_name = default(System.String);
                            
                try
                {
                    ((WidgetPartShadow)ws.Target).GetFilterProgram(out _out_code, out _out_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        code = _out_code;
        name = _out_name;
                        
            }
            else
            {
                efl_gfx_filter_program_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out code, out name);
            }
        }

        private static efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;

        
        private delegate void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_gfx_filter_program_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate> efl_gfx_filter_program_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate>(Module, "efl_gfx_filter_program_set");

        private static void filter_program_set(System.IntPtr obj, System.IntPtr pd, System.String code, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).SetFilterProgram(code, name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_program_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), code, name);
            }
        }

        private static efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;

        
        private delegate void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        
        public delegate void efl_gfx_filter_state_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate> efl_gfx_filter_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate>(Module, "efl_gfx_filter_state_get");

        private static void filter_state_get(System.IntPtr obj, System.IntPtr pd, out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                System.String _out_cur_state = default(System.String);
        cur_val = default(double);        System.String _out_next_state = default(System.String);
        next_val = default(double);        pos = default(double);                                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).GetFilterState(out _out_cur_state, out cur_val, out _out_next_state, out next_val, out pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        cur_state = _out_cur_state;
                next_state = _out_next_state;
                                                                
            }
            else
            {
                efl_gfx_filter_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out cur_state, out cur_val, out next_state, out next_val, out pos);
            }
        }

        private static efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;

        
        private delegate void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        
        public delegate void efl_gfx_filter_state_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate> efl_gfx_filter_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate>(Module, "efl_gfx_filter_state_set");

        private static void filter_state_set(System.IntPtr obj, System.IntPtr pd, System.String cur_state, double cur_val, System.String next_state, double next_val, double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).SetFilterState(cur_state, cur_val, next_state, next_val, pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_filter_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur_state, cur_val, next_state, next_val, pos);
            }
        }

        private static efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;

        
        private delegate void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_filter_padding_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate> efl_gfx_filter_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate>(Module, "efl_gfx_filter_padding_get");

        private static void filter_padding_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).GetFilterPadding(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_filter_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate> efl_gfx_filter_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate>(Module, "efl_gfx_filter_source_get");

        private static Efl.Gfx.IEntity filter_source_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((WidgetPartShadow)ws.Target).GetFilterSource(name);
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
                return efl_gfx_filter_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;

        
        private delegate void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        
        public delegate void efl_gfx_filter_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate> efl_gfx_filter_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate>(Module, "efl_gfx_filter_source_set");

        private static void filter_source_set(System.IntPtr obj, System.IntPtr pd, System.String name, Efl.Gfx.IEntity source)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((WidgetPartShadow)ws.Target).SetFilterSource(name, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, source);
            }
        }

        private static efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;

        
        private delegate void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        
        public delegate void efl_gfx_filter_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate> efl_gfx_filter_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate>(Module, "efl_gfx_filter_data_get");

        private static void filter_data_get(System.IntPtr obj, System.IntPtr pd, System.String name, out System.String value, out bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        System.String _out_value = default(System.String);
        execute = default(bool);                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).GetFilterData(name, out _out_value, out execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                value = _out_value;
                                        
            }
            else
            {
                efl_gfx_filter_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, out value, out execute);
            }
        }

        private static efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;

        
        private delegate void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        
        public delegate void efl_gfx_filter_data_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate> efl_gfx_filter_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate>(Module, "efl_gfx_filter_data_set");

        private static void filter_data_set(System.IntPtr obj, System.IntPtr pd, System.String name, System.String value, bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((WidgetPartShadow)ws.Target).SetFilterData(name, value, execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_filter_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, value, execute);
            }
        }

        private static efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWidgetPartShadow_ExtensionMethods {
    
    
    public static Efl.BindableProperty<double> Grow<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartShadow, T>magic = null) where T : Efl.Ui.WidgetPartShadow {
        return new Efl.BindableProperty<double>("grow", fac);
    }

    
    public static Efl.BindableProperty<System.String> ColorCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartShadow, T>magic = null) where T : Efl.Ui.WidgetPartShadow {
        return new Efl.BindableProperty<System.String>("color_code", fac);
    }

    
    
    
    
    
}
#pragma warning restore CS1591
#endif
