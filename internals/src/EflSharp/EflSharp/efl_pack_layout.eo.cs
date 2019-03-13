#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
[PackLayoutNativeInherit]
public interface PackLayout : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Requests EFL to call the <see cref="Efl.PackLayout.UpdateLayout"/> method on this object.
/// This <see cref="Efl.PackLayout.UpdateLayout"/> may be called asynchronously.</summary>
/// <returns></returns>
 void LayoutRequest();
   /// <summary>Implementation of this container&apos;s layout algorithm.
/// EFL will call this function whenever the contents of this container need to be re-layed out on the canvas.
/// 
/// This can be overriden to implement custom layout behaviours.</summary>
/// <returns></returns>
 void UpdateLayout();
         /// <summary>Sent after the layout was updated.</summary>
   event EventHandler LayoutUpdatedEvt;
}
/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
sealed public class PackLayoutConcrete : 

PackLayout
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PackLayoutConcrete))
            return Efl.PackLayoutNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_pack_layout_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PackLayoutConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PackLayoutConcrete()
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
   public static PackLayoutConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PackLayoutConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object LayoutUpdatedEvtKey = new object();
   /// <summary>Sent after the layout was updated.</summary>
   public event EventHandler LayoutUpdatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_LayoutUpdatedEvt_delegate)) {
               eventHandlers.AddHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (remove_cpp_event_handler(key, this.evt_LayoutUpdatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
   public void On_LayoutUpdatedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[LayoutUpdatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LayoutUpdatedEvt_delegate;
   private void on_LayoutUpdatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_LayoutUpdatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_LayoutUpdatedEvt_delegate = new Efl.EventCb(on_LayoutUpdatedEvt_NativeCallback);
   }
   /// <summary>Requests EFL to call the <see cref="Efl.PackLayout.UpdateLayout"/> method on this object.
   /// This <see cref="Efl.PackLayout.UpdateLayout"/> may be called asynchronously.</summary>
   /// <returns></returns>
   public  void LayoutRequest() {
       Efl.PackLayoutNativeInherit.efl_pack_layout_request_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Implementation of this container&apos;s layout algorithm.
   /// EFL will call this function whenever the contents of this container need to be re-layed out on the canvas.
   /// 
   /// This can be overriden to implement custom layout behaviours.</summary>
   /// <returns></returns>
   public  void UpdateLayout() {
       Efl.PackLayoutNativeInherit.efl_pack_layout_update_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class PackLayoutNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_pack_layout_request_static_delegate == null)
      efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate)});
      if (efl_pack_layout_update_static_delegate == null)
      efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PackLayoutConcrete.efl_pack_layout_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PackLayoutConcrete.efl_pack_layout_interface_get();
   }


    private delegate  void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_pack_layout_request_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate>(_Module, "efl_pack_layout_request");
    private static  void layout_request(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_request was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PackLayout)wrapper).LayoutRequest();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_request_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;


    private delegate  void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_pack_layout_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(_Module, "efl_pack_layout_update");
    private static  void layout_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((PackLayout)wrapper).UpdateLayout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;
}
} 
