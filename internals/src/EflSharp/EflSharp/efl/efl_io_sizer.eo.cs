#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.</summary>
[ISizerNativeInherit]
public interface ISizer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Size property</summary>
/// <returns>Object size</returns>
ulong GetSize();
    /// <summary>Try to resize the object, check with get if the value was accepted or not.</summary>
/// <param name="size">Object size</param>
/// <returns><c>true</c> if could resize, <c>false</c> if errors.</returns>
bool SetSize( ulong size);
    /// <summary>Resize object</summary>
/// <param name="size">Object size</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Resize( ulong size);
                /// <summary>Notifies size changed</summary>
    event EventHandler SizeChangedEvt;
    /// <summary>Size property</summary>
/// <value>Object size</value>
    ulong Size {
        get ;
        set ;
    }
}
/// <summary>Generic interface for objects that can resize or report size of themselves.
/// This interface allows external objects to transparently resize or report its size.</summary>
sealed public class ISizerConcrete : 

ISizer
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ISizerConcrete))
                return Efl.Io.ISizerNativeInherit.GetEflClassStatic();
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
        efl_io_sizer_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private ISizerConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~ISizerConcrete()
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
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
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
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
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
private static object SizeChangedEvtKey = new object();
    /// <summary>Notifies size changed</summary>
    public event EventHandler SizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_SIZER_EVENT_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void On_SizeChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SizeChangedEvt_delegate;
    private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SizeChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
    }
    /// <summary>Size property</summary>
    /// <returns>Object size</returns>
    public ulong GetSize() {
         var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to resize the object, check with get if the value was accepted or not.</summary>
    /// <param name="size">Object size</param>
    /// <returns><c>true</c> if could resize, <c>false</c> if errors.</returns>
    public bool SetSize( ulong size) {
                                 var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_size_set_ptr.Value.Delegate(this.NativeHandle, size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Resize object</summary>
    /// <param name="size">Object size</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Resize( ulong size) {
                                 var _ret_var = Efl.Io.ISizerNativeInherit.efl_io_sizer_resize_ptr.Value.Delegate(this.NativeHandle, size);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Size property</summary>
/// <value>Object size</value>
    public ulong Size {
        get { return GetSize(); }
        set { SetSize( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.ISizerConcrete.efl_io_sizer_mixin_get();
    }
}
public class ISizerNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_io_sizer_size_get_static_delegate == null)
            efl_io_sizer_size_get_static_delegate = new efl_io_sizer_size_get_delegate(size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_get_static_delegate)});
        if (efl_io_sizer_size_set_static_delegate == null)
            efl_io_sizer_size_set_static_delegate = new efl_io_sizer_size_set_delegate(size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_size_set_static_delegate)});
        if (efl_io_sizer_resize_static_delegate == null)
            efl_io_sizer_resize_static_delegate = new efl_io_sizer_resize_delegate(resize);
        if (methods.FirstOrDefault(m => m.Name == "Resize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_sizer_resize"), func = Marshal.GetFunctionPointerForDelegate(efl_io_sizer_resize_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Io.ISizerConcrete.efl_io_sizer_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Io.ISizerConcrete.efl_io_sizer_mixin_get();
    }


     private delegate ulong efl_io_sizer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_sizer_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate> efl_io_sizer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_get_api_delegate>(_Module, "efl_io_sizer_size_get");
     private static ulong size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_sizer_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((ISizerConcrete)wrapper).GetSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_sizer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_sizer_size_get_delegate efl_io_sizer_size_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_sizer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong size);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_sizer_size_set_api_delegate(System.IntPtr obj,   ulong size);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate> efl_io_sizer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_size_set_api_delegate>(_Module, "efl_io_sizer_size_set");
     private static bool size_set(System.IntPtr obj, System.IntPtr pd,  ulong size)
    {
        Eina.Log.Debug("function efl_io_sizer_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((ISizerConcrete)wrapper).SetSize( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_sizer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_sizer_size_set_delegate efl_io_sizer_size_set_static_delegate;


     private delegate Eina.Error efl_io_sizer_resize_delegate(System.IntPtr obj, System.IntPtr pd,   ulong size);


     public delegate Eina.Error efl_io_sizer_resize_api_delegate(System.IntPtr obj,   ulong size);
     public static Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate> efl_io_sizer_resize_ptr = new Efl.Eo.FunctionWrapper<efl_io_sizer_resize_api_delegate>(_Module, "efl_io_sizer_resize");
     private static Eina.Error resize(System.IntPtr obj, System.IntPtr pd,  ulong size)
    {
        Eina.Log.Debug("function efl_io_sizer_resize was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((ISizerConcrete)wrapper).Resize( size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_sizer_resize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_io_sizer_resize_delegate efl_io_sizer_resize_static_delegate;
}
} } 
