#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Efl input state interface</summary>
[StateConcreteNativeInherit]
public interface State : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...</summary>
/// <param name="mod">The modifier key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key modifier is pressed.</returns>
bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat);
   /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...</summary>
/// <param name="kw_lock">The lock key to test.</param>
/// <param name="seat">The seat device, may be <c>null</c></param>
/// <returns><c>true</c> if the key lock is on.</returns>
bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat);
      }
/// <summary>Efl input state interface</summary>
sealed public class StateConcrete : 

State
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (StateConcrete))
            return Efl.Input.StateConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_input_state_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public StateConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~StateConcrete()
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
   public static StateConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new StateConcrete(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_modifier_enabled_get(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...</summary>
   /// <param name="mod">The modifier key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key modifier is pressed.</returns>
   public bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat) {
                                           var _ret_var = efl_input_modifier_enabled_get(Efl.Input.StateConcrete.efl_input_state_interface_get(),  mod,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_lock_enabled_get(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...</summary>
   /// <param name="kw_lock">The lock key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key lock is on.</returns>
   public bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat) {
                                           var _ret_var = efl_input_lock_enabled_get(Efl.Input.StateConcrete.efl_input_state_interface_get(),  kw_lock,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
}
public class StateConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate)});
      efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Input.StateConcrete.efl_input_state_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Input.StateConcrete.efl_input_state_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_modifier_enabled_get(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool modifier_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Modifier mod,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_modifier_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((State)wrapper).GetModifierEnabled( mod,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_input_modifier_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mod,  seat);
      }
   }
   private efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_lock_enabled_get(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool lock_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Lock kw_lock,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_lock_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((State)wrapper).GetLockEnabled( kw_lock,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_input_lock_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_lock,  seat);
      }
   }
   private efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;
}
} } 
