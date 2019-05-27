#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
[Efl.IPackLayoutConcrete.NativeMethods]
public interface IPackLayout : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Requests EFL to call the <see cref="Efl.IPackLayout.UpdateLayout"/> method on this object.
/// This <see cref="Efl.IPackLayout.UpdateLayout"/> may be called asynchronously.</summary>
void LayoutRequest();
    /// <summary>Implementation of this container&apos;s layout algorithm.
/// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
/// 
/// This can be overriden to implement custom layout behaviors.</summary>
void UpdateLayout();
            /// <summary>Sent after the layout was updated.</summary>
    event EventHandler LayoutUpdatedEvt;
}
/// <summary>Low-level APIs for object that can lay their children out.
/// Used for containers (box, grid).</summary>
sealed public class IPackLayoutConcrete : 

IPackLayout
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IPackLayoutConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    private readonly object eventLock = new object();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_pack_layout_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IPackLayout"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IPackLayoutConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IPackLayoutConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (eoEvents.Count != 0)
            {
                GCHandle gcHandle = GCHandle.Alloc(eoEvents);
                gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            }

            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtCaller">Delegate to be called by native code on event raising.</param>
    ///<param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    private void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
        }

        if (eoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, IntPtr.Zero))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        eoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtDelegate">The delegate to be removed.</param>
    private void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var evtPair = (desc, evtDelegate);
        if (eoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, IntPtr.Zero))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            eoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is nothing registered.");
        }
    }

    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
    public void OnLayoutUpdatedEvt(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Requests EFL to call the <see cref="Efl.IPackLayout.UpdateLayout"/> method on this object.
    /// This <see cref="Efl.IPackLayout.UpdateLayout"/> may be called asynchronously.</summary>
    public void LayoutRequest() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overriden to implement custom layout behaviors.</summary>
    public void UpdateLayout() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IPackLayoutConcrete.efl_pack_layout_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_pack_layout_request_static_delegate == null)
            {
                efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
            }

            if (methods.FirstOrDefault(m => m.Name == "LayoutRequest") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IPackLayoutConcrete.efl_pack_layout_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_request_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate>(Module, "efl_pack_layout_request");

        private static void layout_request(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_request was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IPackLayout)wrapper).LayoutRequest();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_request_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IPackLayout)wrapper).UpdateLayout();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

