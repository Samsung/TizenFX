#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl control interface</summary>
[ControlConcreteNativeInherit]
public interface Control : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Control the priority of the object.</summary>
/// <returns>The priority of the object</returns>
 int GetPriority();
   /// <summary>Control the priority of the object.</summary>
/// <param name="priority">The priority of the object</param>
/// <returns></returns>
 void SetPriority(  int priority);
   /// <summary>Controls whether the object is suspended or not.</summary>
/// <returns>Controls whether the object is suspended or not.</returns>
bool GetSuspend();
   /// <summary>Controls whether the object is suspended or not.</summary>
/// <param name="suspend">Controls whether the object is suspended or not.</param>
/// <returns></returns>
 void SetSuspend( bool suspend);
               /// <summary>Control the priority of the object.</summary>
    int Priority {
      get ;
      set ;
   }
   /// <summary>Controls whether the object is suspended or not.</summary>
   bool Suspend {
      get ;
      set ;
   }
}
/// <summary>Efl control interface</summary>
sealed public class ControlConcrete : 

Control
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ControlConcrete))
            return Efl.ControlConcreteNativeInherit.GetEflClassStatic();
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
      efl_control_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ControlConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ControlConcrete()
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
   public static ControlConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ControlConcrete(obj.NativeHandle);
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
    private static extern  int efl_control_priority_get(System.IntPtr obj);
   /// <summary>Control the priority of the object.</summary>
   /// <returns>The priority of the object</returns>
   public  int GetPriority() {
       var _ret_var = efl_control_priority_get(Efl.ControlConcrete.efl_control_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_control_priority_set(System.IntPtr obj,    int priority);
   /// <summary>Control the priority of the object.</summary>
   /// <param name="priority">The priority of the object</param>
   /// <returns></returns>
   public  void SetPriority(  int priority) {
                         efl_control_priority_set(Efl.ControlConcrete.efl_control_interface_get(),  priority);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_control_suspend_get(System.IntPtr obj);
   /// <summary>Controls whether the object is suspended or not.</summary>
   /// <returns>Controls whether the object is suspended or not.</returns>
   public bool GetSuspend() {
       var _ret_var = efl_control_suspend_get(Efl.ControlConcrete.efl_control_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_control_suspend_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool suspend);
   /// <summary>Controls whether the object is suspended or not.</summary>
   /// <param name="suspend">Controls whether the object is suspended or not.</param>
   /// <returns></returns>
   public  void SetSuspend( bool suspend) {
                         efl_control_suspend_set(Efl.ControlConcrete.efl_control_interface_get(),  suspend);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the priority of the object.</summary>
   public  int Priority {
      get { return GetPriority(); }
      set { SetPriority( value); }
   }
   /// <summary>Controls whether the object is suspended or not.</summary>
   public bool Suspend {
      get { return GetSuspend(); }
      set { SetSuspend( value); }
   }
}
public class ControlConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_control_priority_get_static_delegate = new efl_control_priority_get_delegate(priority_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_control_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_control_priority_get_static_delegate)});
      efl_control_priority_set_static_delegate = new efl_control_priority_set_delegate(priority_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_control_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_control_priority_set_static_delegate)});
      efl_control_suspend_get_static_delegate = new efl_control_suspend_get_delegate(suspend_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_control_suspend_get"), func = Marshal.GetFunctionPointerForDelegate(efl_control_suspend_get_static_delegate)});
      efl_control_suspend_set_static_delegate = new efl_control_suspend_set_delegate(suspend_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_control_suspend_set"), func = Marshal.GetFunctionPointerForDelegate(efl_control_suspend_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ControlConcrete.efl_control_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.ControlConcrete.efl_control_interface_get();
   }


    private delegate  int efl_control_priority_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_control_priority_get(System.IntPtr obj);
    private static  int priority_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_control_priority_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Control)wrapper).GetPriority();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_control_priority_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_control_priority_get_delegate efl_control_priority_get_static_delegate;


    private delegate  void efl_control_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,    int priority);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_control_priority_set(System.IntPtr obj,    int priority);
    private static  void priority_set(System.IntPtr obj, System.IntPtr pd,   int priority)
   {
      Eina.Log.Debug("function efl_control_priority_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Control)wrapper).SetPriority( priority);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_control_priority_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  priority);
      }
   }
   private efl_control_priority_set_delegate efl_control_priority_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_control_suspend_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_control_suspend_get(System.IntPtr obj);
    private static bool suspend_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_control_suspend_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Control)wrapper).GetSuspend();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_control_suspend_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_control_suspend_get_delegate efl_control_suspend_get_static_delegate;


    private delegate  void efl_control_suspend_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool suspend);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_control_suspend_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool suspend);
    private static  void suspend_set(System.IntPtr obj, System.IntPtr pd,  bool suspend)
   {
      Eina.Log.Debug("function efl_control_suspend_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Control)wrapper).SetSuspend( suspend);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_control_suspend_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  suspend);
      }
   }
   private efl_control_suspend_set_delegate efl_control_suspend_set_static_delegate;
}
} 
