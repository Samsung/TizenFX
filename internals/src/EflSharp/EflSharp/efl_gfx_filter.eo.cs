#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Graphical filters can be applied to any object implementing this interface.
/// Filters are programmable effects that run whenever the object is rendered on its canvas. The program language is Lua and a complete reference can be found under &quot;EFL Graphics Filters&quot;.
/// 
/// This was a beta feature since 1.15.
/// 1.18</summary>
[FilterConcreteNativeInherit]
public interface Filter : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.
/// 1.18</summary>
/// <param name="code">The Lua program source code.
/// 1.18</param>
/// <param name="name">An optional name for this filter.
/// 1.18</param>
/// <returns></returns>
 void GetFilterProgram( out  System.String code,  out  System.String name);
   /// <summary>Set a graphical filter program on this object.
/// Valid for Text and Image objects at the moment.
/// 
/// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
/// 
/// Set to <c>null</c> to disable filtering.
/// 1.18</summary>
/// <param name="code">The Lua program source code.
/// 1.18</param>
/// <param name="name">An optional name for this filter.
/// 1.18</param>
/// <returns></returns>
 void SetFilterProgram(  System.String code,   System.String name);
   /// <summary>Set the current state of the filter.
/// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
/// 
/// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
/// 1.18</summary>
/// <param name="cur_state">Current state of the filter
/// 1.18</param>
/// <param name="cur_val">Current value
/// 1.18</param>
/// <param name="next_state">Next filter state, optional
/// 1.18</param>
/// <param name="next_val">Next value, optional
/// 1.18</param>
/// <param name="pos">Position, optional
/// 1.18</param>
/// <returns></returns>
 void GetFilterState( out  System.String cur_state,  out double cur_val,  out  System.String next_state,  out double next_val,  out double pos);
   /// <summary>Set the current state of the filter.
/// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
/// 
/// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
/// 1.18</summary>
/// <param name="cur_state">Current state of the filter
/// 1.18</param>
/// <param name="cur_val">Current value
/// 1.18</param>
/// <param name="next_state">Next filter state, optional
/// 1.18</param>
/// <param name="next_val">Next value, optional
/// 1.18</param>
/// <param name="pos">Position, optional
/// 1.18</param>
/// <returns></returns>
 void SetFilterState(  System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos);
   /// <summary>Gets the padding required to apply this filter.
/// 1.18</summary>
/// <param name="l">Padding on the left
/// 1.18</param>
/// <param name="r">Padding on the right
/// 1.18</param>
/// <param name="t">Padding on the top
/// 1.18</param>
/// <param name="b">Padding on the bottom
/// 1.18</param>
/// <returns></returns>
 void GetFilterPadding( out  int l,  out  int r,  out  int t,  out  int b);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
/// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
/// 1.18</summary>
/// <param name="name">Buffer name as used in the program.
/// 1.18</param>
/// <returns>Object to use as a source of pixels.
/// 1.18</returns>
Efl.Gfx.Entity GetFilterSource(  System.String name);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
/// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
/// 1.18</summary>
/// <param name="name">Buffer name as used in the program.
/// 1.18</param>
/// <param name="source">Object to use as a source of pixels.
/// 1.18</param>
/// <returns></returns>
 void SetFilterSource(  System.String name,  Efl.Gfx.Entity source);
   /// <summary>Extra data used by the filter program.
/// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
/// 
/// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
/// 1.18</summary>
/// <param name="name">Name of the global variable
/// 1.18</param>
/// <param name="value">String value to use as data
/// 1.18</param>
/// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
/// 1.18</param>
/// <returns></returns>
 void GetFilterData(  System.String name,  out  System.String value,  out bool execute);
   /// <summary>Extra data used by the filter program.
/// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
/// 
/// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
/// 1.18</summary>
/// <param name="name">Name of the global variable
/// 1.18</param>
/// <param name="value">String value to use as data
/// 1.18</param>
/// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
/// 1.18</param>
/// <returns></returns>
 void SetFilterData(  System.String name,   System.String value,  bool execute);
                           }
/// <summary>Graphical filters can be applied to any object implementing this interface.
/// Filters are programmable effects that run whenever the object is rendered on its canvas. The program language is Lua and a complete reference can be found under &quot;EFL Graphics Filters&quot;.
/// 
/// This was a beta feature since 1.15.
/// 1.18</summary>
sealed public class FilterConcrete : 

Filter
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FilterConcrete))
            return Efl.Gfx.FilterConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_filter_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public FilterConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FilterConcrete()
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
   public static FilterConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FilterConcrete(obj.NativeHandle);
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
    private static extern  void efl_gfx_filter_program_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String name);
   /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterProgram( out  System.String code,  out  System.String name) {
                                           efl_gfx_filter_program_get(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  out code,  out name);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_program_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Set a graphical filter program on this object.
   /// Valid for Text and Image objects at the moment.
   /// 
   /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
   /// 
   /// Set to <c>null</c> to disable filtering.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterProgram(  System.String code,   System.String name) {
                                           efl_gfx_filter_program_set(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  code,  name);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_state_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String next_state,   out double next_val,   out double pos);
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterState( out  System.String cur_state,  out double cur_val,  out  System.String next_state,  out double next_val,  out double pos) {
                                                                                                 efl_gfx_filter_state_get(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_state_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterState(  System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos) {
                                                                                                 efl_gfx_filter_state_set(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  cur_state,  cur_val,  next_state,  next_val,  pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_padding_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
   /// <summary>Gets the padding required to apply this filter.
   /// 1.18</summary>
   /// <param name="l">Padding on the left
   /// 1.18</param>
   /// <param name="r">Padding on the right
   /// 1.18</param>
   /// <param name="t">Padding on the top
   /// 1.18</param>
   /// <param name="b">Padding on the bottom
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterPadding( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               efl_gfx_filter_padding_get(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_gfx_filter_source_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <returns>Object to use as a source of pixels.
   /// 1.18</returns>
   public Efl.Gfx.Entity GetFilterSource(  System.String name) {
                         var _ret_var = efl_gfx_filter_source_get(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <param name="source">Object to use as a source of pixels.
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterSource(  System.String name,  Efl.Gfx.Entity source) {
                                           efl_gfx_filter_source_set(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  name,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterData(  System.String name,  out  System.String value,  out bool execute) {
                                                             efl_gfx_filter_data_get(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  name,  out value,  out execute);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_filter_data_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterData(  System.String name,   System.String value,  bool execute) {
                                                             efl_gfx_filter_data_set(Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get(),  name,  value,  execute);
      Eina.Error.RaiseIfUnhandledException();
                                           }
}
public class FilterConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate)});
      efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate)});
      efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate)});
      efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate)});
      efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate)});
      efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate)});
      efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate)});
      efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate)});
      efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.FilterConcrete.efl_gfx_filter_interface_get();
   }


    private delegate  void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr code,   out  System.IntPtr name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_program_get(System.IntPtr obj,   out  System.IntPtr code,   out  System.IntPtr name);
    private static  void filter_program_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr code,  out  System.IntPtr name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_code = default( System.String);
       System.String _out_name = default( System.String);
                     
         try {
            ((Filter)wrapper).GetFilterProgram( out _out_code,  out _out_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      code= Efl.Eo.Globals.cached_string_to_intptr(((FilterConcrete)wrapper).cached_strings, _out_code);
      name= Efl.Eo.Globals.cached_string_to_intptr(((FilterConcrete)wrapper).cached_strings, _out_name);
                        } else {
         efl_gfx_filter_program_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out code,  out name);
      }
   }
   private efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;


    private delegate  void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_program_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static  void filter_program_set(System.IntPtr obj, System.IntPtr pd,   System.String code,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Filter)wrapper).SetFilterProgram( code,  name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_program_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code,  name);
      }
   }
   private efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;


    private delegate  void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr cur_state,   out double cur_val,   out  System.IntPtr next_state,   out double next_val,   out double pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_state_get(System.IntPtr obj,   out  System.IntPtr cur_state,   out double cur_val,   out  System.IntPtr next_state,   out double next_val,   out double pos);
    private static  void filter_state_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr cur_state,  out double cur_val,  out  System.IntPtr next_state,  out double next_val,  out double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                              System.String _out_cur_state = default( System.String);
      cur_val = default(double);       System.String _out_next_state = default( System.String);
      next_val = default(double);      pos = default(double);                                       
         try {
            ((Filter)wrapper).GetFilterState( out _out_cur_state,  out cur_val,  out _out_next_state,  out next_val,  out pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      cur_state= Efl.Eo.Globals.cached_string_to_intptr(((FilterConcrete)wrapper).cached_strings, _out_cur_state);
            next_state= Efl.Eo.Globals.cached_string_to_intptr(((FilterConcrete)wrapper).cached_strings, _out_next_state);
                                                      } else {
         efl_gfx_filter_state_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      }
   }
   private efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;


    private delegate  void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_state_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
    private static  void filter_state_set(System.IntPtr obj, System.IntPtr pd,   System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Filter)wrapper).SetFilterState( cur_state,  cur_val,  next_state,  next_val,  pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_filter_state_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur_state,  cur_val,  next_state,  next_val,  pos);
      }
   }
   private efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;


    private delegate  void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_padding_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    private static  void filter_padding_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((Filter)wrapper).GetFilterPadding( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_filter_padding_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_gfx_filter_source_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Efl.Gfx.Entity filter_source_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Filter)wrapper).GetFilterSource( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_filter_source_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;


    private delegate  void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_source_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
    private static  void filter_source_set(System.IntPtr obj, System.IntPtr pd,   System.String name,  Efl.Gfx.Entity source)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Filter)wrapper).SetFilterSource( name,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_source_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  source);
      }
   }
   private efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;


    private delegate  void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   out  System.IntPtr value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_data_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   out  System.IntPtr value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
    private static  void filter_data_get(System.IntPtr obj, System.IntPtr pd,   System.String name,  out  System.IntPtr value,  out bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                        System.String _out_value = default( System.String);
      execute = default(bool);                           
         try {
            ((Filter)wrapper).GetFilterData( name,  out _out_value,  out execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            value= Efl.Eo.Globals.cached_string_to_intptr(((FilterConcrete)wrapper).cached_strings, _out_value);
                                    } else {
         efl_gfx_filter_data_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  out value,  out execute);
      }
   }
   private efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;


    private delegate  void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_filter_data_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
    private static  void filter_data_set(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String value,  bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Filter)wrapper).SetFilterData( name,  value,  execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_filter_data_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  value,  execute);
      }
   }
   private efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;
}
} } 
