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

namespace Filter {

/// <summary>Evas internal implementation of filters.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Filter.IInternalConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IInternal : 
    Efl.Gfx.IFilter ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Marks this filter as changed.</summary>
/// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
void SetFilterChanged(bool val);
    /// <summary>Marks this filter as invalid.</summary>
/// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
void SetFilterInvalid(bool val);
    /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
/// <returns>Output buffer</returns>
System.IntPtr GetFilterOutputBuffer();
    /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool FilterInputAlpha();
    /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
/// <param name="state">State info to fill in</param>
/// <param name="data">Private data for the class</param>
void FilterStatePrepare(out Efl.Canvas.Filter.State state, System.IntPtr data);
    /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
/// <param name="filter">Current filter context</param>
/// <param name="engine">Engine context</param>
/// <param name="output">Output context</param>
/// <param name="drawctx">Draw context (for evas engine)</param>
/// <param name="data">Private data used by textblock</param>
/// <param name="l">Left</param>
/// <param name="r">Right</param>
/// <param name="t">Top</param>
/// <param name="b">Bottom</param>
/// <param name="x">X offset</param>
/// <param name="y">Y offset</param>
/// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
/// <returns>Indicates success from the object render function.</returns>
bool FilterInputRender(System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async);
    /// <summary>Called when filter changes must trigger a redraw of the object.
/// Virtual, to be implemented in the parent class.</summary>
void FilterDirty();
                                /// <summary>Marks this filter as changed.</summary>
    /// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
    bool FilterChanged {
        set;
    }
    /// <summary>Marks this filter as invalid.</summary>
    /// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
    bool FilterInvalid {
        set;
    }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <value>Output buffer</value>
    System.IntPtr FilterOutputBuffer {
        get;
    }
}
/// <summary>Evas internal implementation of filters.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IInternalConcrete :
    Efl.Eo.EoWrapper
    , IInternal
    , Efl.Gfx.IFilter
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IInternalConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IInternalConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_filter_internal_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IInternal"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IInternalConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Marks this filter as changed.</summary>
    /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
    public void SetFilterChanged(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_changed_set_ptr.Value.Delegate(this.NativeHandle,val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Marks this filter as invalid.</summary>
    /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
    public void SetFilterInvalid(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_invalid_set_ptr.Value.Delegate(this.NativeHandle,val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <returns>Output buffer</returns>
    public System.IntPtr GetFilterOutputBuffer() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_output_buffer_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool FilterInputAlpha() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_alpha_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
    /// <param name="state">State info to fill in</param>
    /// <param name="data">Private data for the class</param>
    public void FilterStatePrepare(out Efl.Canvas.Filter.State state, System.IntPtr data) {
                         var _out_state = new Efl.Canvas.Filter.State.NativeStruct();
                                Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_state_prepare_ptr.Value.Delegate(this.NativeHandle,out _out_state, data);
        Eina.Error.RaiseIfUnhandledException();
        state = _out_state;
                                 }
    /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
    /// <param name="filter">Current filter context</param>
    /// <param name="engine">Engine context</param>
    /// <param name="output">Output context</param>
    /// <param name="drawctx">Draw context (for evas engine)</param>
    /// <param name="data">Private data used by textblock</param>
    /// <param name="l">Left</param>
    /// <param name="r">Right</param>
    /// <param name="t">Top</param>
    /// <param name="b">Bottom</param>
    /// <param name="x">X offset</param>
    /// <param name="y">Y offset</param>
    /// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
    /// <returns>Indicates success from the object render function.</returns>
    public bool FilterInputRender(System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async) {
                                                                                                                                                                                                                                                                                                         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_render_ptr.Value.Delegate(this.NativeHandle,filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Called when filter changes must trigger a redraw of the object.
    /// Virtual, to be implemented in the parent class.</summary>
    public void FilterDirty() {
         Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_dirty_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    public void GetFilterProgram(out System.String code, out System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_get_ptr.Value.Delegate(this.NativeHandle,out code, out name);
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
    public void SetFilterProgram(System.String code, System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_set_ptr.Value.Delegate(this.NativeHandle,code, name);
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
    public void GetFilterState(out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_get_ptr.Value.Delegate(this.NativeHandle,out cur_state, out cur_val, out next_state, out next_val, out pos);
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
    public void SetFilterState(System.String cur_state, double cur_val, System.String next_state, double next_val, double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_set_ptr.Value.Delegate(this.NativeHandle,cur_state, cur_val, next_state, next_val, pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Gets the padding required to apply this filter.</summary>
    /// <param name="l">Padding on the left</param>
    /// <param name="r">Padding on the right</param>
    /// <param name="t">Padding on the top</param>
    /// <param name="b">Padding on the bottom</param>
    public void GetFilterPadding(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_padding_get_ptr.Value.Delegate(this.NativeHandle,out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <returns>Object to use as a source of pixels.</returns>
    public Efl.Gfx.IEntity GetFilterSource(System.String name) {
                                 var _ret_var = Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_get_ptr.Value.Delegate(this.NativeHandle,name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <param name="source">Object to use as a source of pixels.</param>
    public void SetFilterSource(System.String name, Efl.Gfx.IEntity source) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_set_ptr.Value.Delegate(this.NativeHandle,name, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    public void GetFilterData(System.String name, out System.String value, out bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_get_ptr.Value.Delegate(this.NativeHandle,name, out value, out execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    public void SetFilterData(System.String name, System.String value, bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_set_ptr.Value.Delegate(this.NativeHandle,name, value, execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Marks this filter as changed.</summary>
    /// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
    public bool FilterChanged {
        set { SetFilterChanged(value); }
    }
    /// <summary>Marks this filter as invalid.</summary>
    /// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
    public bool FilterInvalid {
        set { SetFilterInvalid(value); }
    }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <value>Output buffer</value>
    public System.IntPtr FilterOutputBuffer {
        get { return GetFilterOutputBuffer(); }
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
        return Efl.Canvas.Filter.IInternalConcrete.efl_canvas_filter_internal_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (evas_filter_changed_set_static_delegate == null)
            {
                evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterChanged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate) });
            }

            if (evas_filter_invalid_set_static_delegate == null)
            {
                evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterInvalid") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate) });
            }

            if (evas_filter_output_buffer_get_static_delegate == null)
            {
                evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterOutputBuffer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate) });
            }

            if (evas_filter_input_alpha_static_delegate == null)
            {
                evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate) });
            }

            if (evas_filter_state_prepare_static_delegate == null)
            {
                evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterStatePrepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate) });
            }

            if (evas_filter_input_render_static_delegate == null)
            {
                evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputRender") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate) });
            }

            if (evas_filter_dirty_static_delegate == null)
            {
                evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterDirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate) });
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Filter.IInternalConcrete.efl_canvas_filter_internal_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_changed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate> evas_filter_changed_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate>(Module, "evas_filter_changed_set");

        private static void filter_changed_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_changed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IInternal)ws.Target).SetFilterChanged(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_changed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;

        
        private delegate void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_invalid_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate> evas_filter_invalid_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate>(Module, "evas_filter_invalid_set");

        private static void filter_invalid_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_invalid_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IInternal)ws.Target).SetFilterInvalid(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_invalid_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;

        
        private delegate System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr evas_filter_output_buffer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate> evas_filter_output_buffer_get_ptr = new Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate>(Module, "evas_filter_output_buffer_get");

        private static System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_output_buffer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((IInternal)ws.Target).GetFilterOutputBuffer();
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
                return evas_filter_output_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_alpha_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate> evas_filter_input_alpha_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate>(Module, "evas_filter_input_alpha");

        private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_input_alpha was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IInternal)ws.Target).FilterInputAlpha();
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
                return evas_filter_input_alpha_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;

        
        private delegate void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        
        public delegate void evas_filter_state_prepare_api_delegate(System.IntPtr obj,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate> evas_filter_state_prepare_ptr = new Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate>(Module, "evas_filter_state_prepare");

        private static void filter_state_prepare(System.IntPtr obj, System.IntPtr pd, out Efl.Canvas.Filter.State.NativeStruct state, System.IntPtr data)
        {
            Eina.Log.Debug("function evas_filter_state_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                                    
                try
                {
                    ((IInternal)ws.Target).FilterStatePrepare(out _out_state, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        state = _out_state;
                                
            }
            else
            {
                evas_filter_state_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out state, data);
            }
        }

        private static evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_render_api_delegate(System.IntPtr obj,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate> evas_filter_input_render_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate>(Module, "evas_filter_input_render");

        private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd, System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async)
        {
            Eina.Log.Debug("function evas_filter_input_render was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                                                                                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IInternal)ws.Target).FilterInputRender(filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
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
                return evas_filter_input_render_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
            }
        }

        private static evas_filter_input_render_delegate evas_filter_input_render_static_delegate;

        
        private delegate void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void evas_filter_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate> evas_filter_dirty_ptr = new Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate>(Module, "evas_filter_dirty");

        private static void filter_dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IInternal)ws.Target).FilterDirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                evas_filter_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_dirty_delegate evas_filter_dirty_static_delegate;

        
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
                    ((IInternal)ws.Target).GetFilterProgram(out _out_code, out _out_name);
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
                    ((IInternal)ws.Target).SetFilterProgram(code, name);
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
                    ((IInternal)ws.Target).GetFilterState(out _out_cur_state, out cur_val, out _out_next_state, out next_val, out pos);
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
                    ((IInternal)ws.Target).SetFilterState(cur_state, cur_val, next_state, next_val, pos);
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
                    ((IInternal)ws.Target).GetFilterPadding(out l, out r, out t, out b);
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
                    _ret_var = ((IInternal)ws.Target).GetFilterSource(name);
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
                    ((IInternal)ws.Target).SetFilterSource(name, source);
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
                    ((IInternal)ws.Target).GetFilterData(name, out _out_value, out execute);
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
                    ((IInternal)ws.Target).SetFilterData(name, value, execute);
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

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_FilterIInternalConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> FilterChanged<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Filter.IInternal, T>magic = null) where T : Efl.Canvas.Filter.IInternal {
        return new Efl.BindableProperty<bool>("filter_changed", fac);
    }

    public static Efl.BindableProperty<bool> FilterInvalid<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Filter.IInternal, T>magic = null) where T : Efl.Canvas.Filter.IInternal {
        return new Efl.BindableProperty<bool>("filter_invalid", fac);
    }

    
    
    
    
    
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Gfx {

/// <summary>32 bit color data structure</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Color32
{
    /// <summary>Red component of the color</summary>
    public byte R;
    /// <summary>Green component of the color</summary>
    public byte G;
    /// <summary>Blue component of the color</summary>
    public byte B;
    /// <summary>Translucent component of the color</summary>
    public byte A;
    /// <summary>Constructor for Color32.</summary>
    /// <param name="R">Red component of the color</param>;
    /// <param name="G">Green component of the color</param>;
    /// <param name="B">Blue component of the color</param>;
    /// <param name="A">Translucent component of the color</param>;
    public Color32(
        byte R = default(byte),
        byte G = default(byte),
        byte B = default(byte),
        byte A = default(byte)    )
    {
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Color32(IntPtr ptr)
    {
        var tmp = (Color32.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Color32.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Color32.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public byte R;
        
        public byte G;
        
        public byte B;
        
        public byte A;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Color32.NativeStruct(Color32 _external_struct)
        {
            var _internal_struct = new Color32.NativeStruct();
            _internal_struct.R = _external_struct.R;
            _internal_struct.G = _external_struct.G;
            _internal_struct.B = _external_struct.B;
            _internal_struct.A = _external_struct.A;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Color32(Color32.NativeStruct _internal_struct)
        {
            var _external_struct = new Color32();
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

namespace Canvas {

namespace Filter {

/// <summary>Filter state name structure</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct StateName
{
    /// <summary>Filter state name</summary>
    public System.String Name;
    /// <summary>Filter state value</summary>
    public double Value;
    /// <summary>Constructor for StateName.</summary>
    /// <param name="Name">Filter state name</param>;
    /// <param name="Value">Filter state value</param>;
    public StateName(
        System.String Name = default(System.String),
        double Value = default(double)    )
    {
        this.Name = Name;
        this.Value = Value;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator StateName(IntPtr ptr)
    {
        var tmp = (StateName.NativeStruct)Marshal.PtrToStructure(ptr, typeof(StateName.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct StateName.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Name</summary>
        public System.IntPtr Name;
        
        public double Value;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator StateName.NativeStruct(StateName _external_struct)
        {
            var _internal_struct = new StateName.NativeStruct();
            _internal_struct.Name = Eina.MemoryNative.StrDup(_external_struct.Name);
            _internal_struct.Value = _external_struct.Value;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator StateName(StateName.NativeStruct _internal_struct)
        {
            var _external_struct = new StateName();
            _external_struct.Name = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Name);
            _external_struct.Value = _internal_struct.Value;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Canvas {

namespace Filter {

/// <summary>Filter state text structure</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct StateText
{
    /// <summary>Text outline color</summary>
    /// <value>32 bit color data structure</value>
    public Efl.Gfx.Color32 Outline;
    /// <summary>Text shadow color</summary>
    /// <value>32 bit color data structure</value>
    public Efl.Gfx.Color32 Shadow;
    /// <summary>Text glow color</summary>
    /// <value>32 bit color data structure</value>
    public Efl.Gfx.Color32 Glow;
    /// <summary>Text glow2 color</summary>
    /// <value>32 bit color data structure</value>
    public Efl.Gfx.Color32 Glow2;
    /// <summary>Constructor for StateText.</summary>
    /// <param name="Outline">Text outline color</param>;
    /// <param name="Shadow">Text shadow color</param>;
    /// <param name="Glow">Text glow color</param>;
    /// <param name="Glow2">Text glow2 color</param>;
    public StateText(
        Efl.Gfx.Color32 Outline = default(Efl.Gfx.Color32),
        Efl.Gfx.Color32 Shadow = default(Efl.Gfx.Color32),
        Efl.Gfx.Color32 Glow = default(Efl.Gfx.Color32),
        Efl.Gfx.Color32 Glow2 = default(Efl.Gfx.Color32)    )
    {
        this.Outline = Outline;
        this.Shadow = Shadow;
        this.Glow = Glow;
        this.Glow2 = Glow2;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator StateText(IntPtr ptr)
    {
        var tmp = (StateText.NativeStruct)Marshal.PtrToStructure(ptr, typeof(StateText.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct StateText.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Gfx.Color32.NativeStruct Outline;
        
        public Efl.Gfx.Color32.NativeStruct Shadow;
        
        public Efl.Gfx.Color32.NativeStruct Glow;
        
        public Efl.Gfx.Color32.NativeStruct Glow2;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator StateText.NativeStruct(StateText _external_struct)
        {
            var _internal_struct = new StateText.NativeStruct();
            _internal_struct.Outline = _external_struct.Outline;
            _internal_struct.Shadow = _external_struct.Shadow;
            _internal_struct.Glow = _external_struct.Glow;
            _internal_struct.Glow2 = _external_struct.Glow2;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator StateText(StateText.NativeStruct _internal_struct)
        {
            var _external_struct = new StateText();
            _external_struct.Outline = _internal_struct.Outline;
            _external_struct.Shadow = _internal_struct.Shadow;
            _external_struct.Glow = _internal_struct.Glow;
            _external_struct.Glow2 = _internal_struct.Glow2;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Canvas {

namespace Filter {

/// <summary>Internal structure representing the state of a Gfx Filter</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct State
{
    /// <summary>Text state</summary>
    /// <value>Filter state text structure</value>
    public Efl.Canvas.Filter.StateText Text;
    /// <summary>Color</summary>
    /// <value>32 bit color data structure</value>
    public Efl.Gfx.Color32 Color;
    /// <summary>Current state</summary>
    /// <value>Filter state name structure</value>
    public Efl.Canvas.Filter.StateName Cur;
    /// <summary>Next state</summary>
    /// <value>Filter state name structure</value>
    public Efl.Canvas.Filter.StateName Next;
    /// <summary>Width</summary>
    public int W;
    /// <summary>Height</summary>
    public int H;
    /// <summary>Scale factor</summary>
    public double Scale;
    /// <summary>Position</summary>
    public double Pos;
    /// <summary>Constructor for State.</summary>
    /// <param name="Text">Text state</param>;
    /// <param name="Color">Color</param>;
    /// <param name="Cur">Current state</param>;
    /// <param name="Next">Next state</param>;
    /// <param name="W">Width</param>;
    /// <param name="H">Height</param>;
    /// <param name="Scale">Scale factor</param>;
    /// <param name="Pos">Position</param>;
    public State(
        Efl.Canvas.Filter.StateText Text = default(Efl.Canvas.Filter.StateText),
        Efl.Gfx.Color32 Color = default(Efl.Gfx.Color32),
        Efl.Canvas.Filter.StateName Cur = default(Efl.Canvas.Filter.StateName),
        Efl.Canvas.Filter.StateName Next = default(Efl.Canvas.Filter.StateName),
        int W = default(int),
        int H = default(int),
        double Scale = default(double),
        double Pos = default(double)    )
    {
        this.Text = Text;
        this.Color = Color;
        this.Cur = Cur;
        this.Next = Next;
        this.W = W;
        this.H = H;
        this.Scale = Scale;
        this.Pos = Pos;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator State(IntPtr ptr)
    {
        var tmp = (State.NativeStruct)Marshal.PtrToStructure(ptr, typeof(State.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct State.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Canvas.Filter.StateText.NativeStruct Text;
        
        public Efl.Gfx.Color32.NativeStruct Color;
        
        public Efl.Canvas.Filter.StateName.NativeStruct Cur;
        
        public Efl.Canvas.Filter.StateName.NativeStruct Next;
        
        public int W;
        
        public int H;
        
        public double Scale;
        
        public double Pos;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator State.NativeStruct(State _external_struct)
        {
            var _internal_struct = new State.NativeStruct();
            _internal_struct.Text = _external_struct.Text;
            _internal_struct.Color = _external_struct.Color;
            _internal_struct.Cur = _external_struct.Cur;
            _internal_struct.Next = _external_struct.Next;
            _internal_struct.W = _external_struct.W;
            _internal_struct.H = _external_struct.H;
            _internal_struct.Scale = _external_struct.Scale;
            _internal_struct.Pos = _external_struct.Pos;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator State(State.NativeStruct _internal_struct)
        {
            var _external_struct = new State();
            _external_struct.Text = _internal_struct.Text;
            _external_struct.Color = _internal_struct.Color;
            _external_struct.Cur = _internal_struct.Cur;
            _external_struct.Next = _internal_struct.Next;
            _external_struct.W = _internal_struct.W;
            _external_struct.H = _internal_struct.H;
            _external_struct.Scale = _internal_struct.Scale;
            _external_struct.Pos = _internal_struct.Pos;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

