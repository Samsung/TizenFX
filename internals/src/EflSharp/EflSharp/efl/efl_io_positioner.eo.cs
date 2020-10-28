#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Io { 
/// <summary>Generic interface for objects that can change or report position.</summary>
[IPositionerNativeInherit]
public interface IPositioner : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Position property</summary>
/// <returns>Position in file or buffer</returns>
ulong GetPosition();
    /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.IPositioner.Seek"/></summary>
/// <param name="position">Position in file or buffer</param>
/// <returns><c>true</c> if could reposition, <c>false</c> if errors.</returns>
bool SetPosition( ulong position);
    /// <summary>Seek in data</summary>
/// <param name="offset">Offset in byte relative to whence</param>
/// <param name="whence">Whence</param>
/// <returns>0 on succeed, a mapping of errno otherwise</returns>
Eina.Error Seek( long offset,  Efl.Io.PositionerWhence whence);
                /// <summary>Notifies position changed</summary>
    event EventHandler PositionChangedEvt;
    /// <summary>Position property</summary>
/// <value>Position in file or buffer</value>
    ulong Position {
        get ;
        set ;
    }
}
/// <summary>Generic interface for objects that can change or report position.</summary>
sealed public class IPositionerConcrete : 

IPositioner
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IPositionerConcrete))
                return Efl.Io.IPositionerNativeInherit.GetEflClassStatic();
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
        efl_io_positioner_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IPositionerConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IPositionerConcrete()
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
private static object PositionChangedEvtKey = new object();
    /// <summary>Notifies position changed</summary>
    public event EventHandler PositionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_IO_POSITIONER_EVENT_POSITION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void On_PositionChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PositionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionChangedEvt_delegate;
    private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PositionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
    }
    /// <summary>Position property</summary>
    /// <returns>Position in file or buffer</returns>
    public ulong GetPosition() {
         var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_position_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Try to set position object, relative to start of file. See <see cref="Efl.Io.IPositioner.Seek"/></summary>
    /// <param name="position">Position in file or buffer</param>
    /// <returns><c>true</c> if could reposition, <c>false</c> if errors.</returns>
    public bool SetPosition( ulong position) {
                                 var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_position_set_ptr.Value.Delegate(this.NativeHandle, position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Seek in data</summary>
    /// <param name="offset">Offset in byte relative to whence</param>
    /// <param name="whence">Whence</param>
    /// <returns>0 on succeed, a mapping of errno otherwise</returns>
    public Eina.Error Seek( long offset,  Efl.Io.PositionerWhence whence) {
                                                         var _ret_var = Efl.Io.IPositionerNativeInherit.efl_io_positioner_seek_ptr.Value.Delegate(this.NativeHandle, offset,  whence);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Position property</summary>
/// <value>Position in file or buffer</value>
    public ulong Position {
        get { return GetPosition(); }
        set { SetPosition( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Io.IPositionerConcrete.efl_io_positioner_mixin_get();
    }
}
public class IPositionerNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_io_positioner_position_get_static_delegate == null)
            efl_io_positioner_position_get_static_delegate = new efl_io_positioner_position_get_delegate(position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_get_static_delegate)});
        if (efl_io_positioner_position_set_static_delegate == null)
            efl_io_positioner_position_set_static_delegate = new efl_io_positioner_position_set_delegate(position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_position_set_static_delegate)});
        if (efl_io_positioner_seek_static_delegate == null)
            efl_io_positioner_seek_static_delegate = new efl_io_positioner_seek_delegate(seek);
        if (methods.FirstOrDefault(m => m.Name == "Seek") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_io_positioner_seek"), func = Marshal.GetFunctionPointerForDelegate(efl_io_positioner_seek_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Io.IPositionerConcrete.efl_io_positioner_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Io.IPositionerConcrete.efl_io_positioner_mixin_get();
    }


     private delegate ulong efl_io_positioner_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate ulong efl_io_positioner_position_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate> efl_io_positioner_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_get_api_delegate>(_Module, "efl_io_positioner_position_get");
     private static ulong position_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_io_positioner_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        ulong _ret_var = default(ulong);
            try {
                _ret_var = ((IPositionerConcrete)wrapper).GetPosition();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_io_positioner_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_io_positioner_position_get_delegate efl_io_positioner_position_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_io_positioner_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   ulong position);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_io_positioner_position_set_api_delegate(System.IntPtr obj,   ulong position);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate> efl_io_positioner_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_position_set_api_delegate>(_Module, "efl_io_positioner_position_set");
     private static bool position_set(System.IntPtr obj, System.IntPtr pd,  ulong position)
    {
        Eina.Log.Debug("function efl_io_positioner_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((IPositionerConcrete)wrapper).SetPosition( position);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_io_positioner_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
        }
    }
    private static efl_io_positioner_position_set_delegate efl_io_positioner_position_set_static_delegate;


     private delegate Eina.Error efl_io_positioner_seek_delegate(System.IntPtr obj, System.IntPtr pd,   long offset,   Efl.Io.PositionerWhence whence);


     public delegate Eina.Error efl_io_positioner_seek_api_delegate(System.IntPtr obj,   long offset,   Efl.Io.PositionerWhence whence);
     public static Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate> efl_io_positioner_seek_ptr = new Efl.Eo.FunctionWrapper<efl_io_positioner_seek_api_delegate>(_Module, "efl_io_positioner_seek");
     private static Eina.Error seek(System.IntPtr obj, System.IntPtr pd,  long offset,  Efl.Io.PositionerWhence whence)
    {
        Eina.Log.Debug("function efl_io_positioner_seek was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((IPositionerConcrete)wrapper).Seek( offset,  whence);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_io_positioner_seek_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset,  whence);
        }
    }
    private static efl_io_positioner_seek_delegate efl_io_positioner_seek_static_delegate;
}
} } 
namespace Efl { namespace Io { 
/// <summary>Seek position modes</summary>
public enum PositionerWhence
{
/// <summary>Seek from start of the stream/file</summary>
Start = 0,
/// <summary>Seek from current position</summary>
Current = 1,
/// <summary>Seek from the end of stream/file</summary>
End = 2,
}
} } 
