using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Efl
{

namespace Eo
{

public abstract class EoWrapper : IWrapper, IDisposable
{
    protected readonly object eventLock = new object();
    protected bool inherited = false;
    protected System.IntPtr handle = IntPtr.Zero;

    private static Efl.EventCb ownershipUniqueDelegate = new Efl.EventCb(OwnershipUniqueCallback);
    private static Efl.EventCb ownershipSharedDelegate = new Efl.EventCb(OwnershipSharedCallback);

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected EoWrapper(System.IntPtr raw)
    {
        handle = raw;
        AddWrapperSupervisor();
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to actually call the native library constructors. C# subclasses
    /// must use the public constructor only.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    /// <param name="file">Name of the file from where the constructor is called.</param>
    /// <param name="line">Number of the line from where the constructor is called.</param>
    protected EoWrapper(IntPtr baseKlass, System.Type managedType, Efl.Object parent,
                        [CallerFilePath] string file = null,
                        [CallerLineNumber] int line = 0)
    {
        inherited = ((object)this).GetType() != managedType;
        IntPtr actual_klass = baseKlass;
        if (inherited)
        {
            actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(baseKlass, ((object)this).GetType());
        }

        // Creation of the unfinalized Eo handle
        Eina.Log.Debug($"Instantiating from klass 0x{actual_klass.ToInt64():x}");
        System.IntPtr parent_ptr = System.IntPtr.Zero;
        if (parent != null)
        {
            parent_ptr = parent.NativeHandle;
        }

        handle = Efl.Eo.Globals._efl_add_internal_start(file, line, actual_klass, parent_ptr, 1, 0);
        if (handle == System.IntPtr.Zero)
        {
            throw new Exception("Instantiation failed");
        }

        Eina.Log.Debug($"Eo instance right after internal_start 0x{handle.ToInt64():x} with refcount {Efl.Eo.Globals.efl_ref_count(handle)}");
        Eina.Log.Debug($"Parent was 0x{parent_ptr.ToInt64()}");

        // Creation of wrapper supervisor
        AddWrapperSupervisor();
    }

    /// <summary>Destructor.</summary>
    ~EoWrapper()
    {
        Dispose(false);
    }

    /// <summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    /// <summary>Pointer to the native class description.</summary>
    public abstract System.IntPtr NativeClass
    {
        get;
    }

    /// <summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing && handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;
            Efl.Eo.Globals.efl_mono_native_dispose(h);
        }
        else
        {
            Monitor.Enter(Efl.All.InitLock);
            if (Efl.All.MainLoopInitialized)
            {
                Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(handle);
            }

            Monitor.Exit(Efl.All.InitLock);
        }
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[0x{(UInt64)handle:x}]";
    }

    /// <summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Releases the underlying Eo object.
    ///
    /// This method is a C# counterpart to the C `efl_del` function. It removes the parent of the object
    /// and releases the Eo reference it was holding.
    /// </summary>
    public void Del()
    {
        // FIXME Implement this
        ((Efl.Object)this).SetParent(null);
        Dispose();
    }

    /// <summary>Finishes instantiating this object.
    /// Internal usage by generated code.</summary>
    protected void FinishInstantiation()
    {
        Eina.Log.Debug("calling efl_add_internal_end");
        var h = Efl.Eo.Globals._efl_add_end(handle, 1, 0);
        Eina.Log.Debug($"efl_add_end returned eo 0x{handle.ToInt64():x}");

        // if (h == IntPtr.Zero) // TODO
        // {
        // }

        handle = h;
    }

    /// <summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    /// <param name="lib">The name of the native library definining the event.</param>
    /// <param name="key">The name of the native event.</param>
    /// <param name="evtCaller">Delegate to be called by native code on event raising.</param>
    /// <param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    protected void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var wsPtr = Efl.Eo.Globals.efl_mono_wrapper_supervisor_get(handle);
        var ws = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(wsPtr);
        if (ws.EoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, wsPtr))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        ws.EoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    /// <summary>Removes the given event handler for the given event. For internal use only.</summary>
    /// <param name="lib">The name of the native library definining the event.</param>
    /// <param name="key">The name of the native event.</param>
    /// <param name="evtDelegate">The delegate to be removed.</param>
    protected void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var wsPtr = Efl.Eo.Globals.efl_mono_wrapper_supervisor_get(handle);
        var ws = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(wsPtr);
        var evtPair = (desc, evtDelegate);
        if (ws.EoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, wsPtr))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            ws.EoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is not registered.");
        }
    }

    private static void OwnershipUniqueCallback(IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        var ws = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data);
        ws.MakeUnique();
    }

    private static void OwnershipSharedCallback(IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        var ws = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data);
        ws.MakeShared();
    }

    /// <sumary>Create and set to the internal native state a C# supervisor for this Eo wrapper. For internal use only.</sumary>
    private void AddWrapperSupervisor()
    {
        var ws = new Efl.Eo.WrapperSupervisor(this);
        Efl.Eo.Globals.SetWrapperSupervisor(handle, ws);
        if (Efl.Eo.Globals.efl_ref_count(handle) > 1)
        {
            ws.MakeShared();
        }

        AddOwnershipEventHandlers();
    }

    /// <summary>Register handlers to ownership events, in order to control the object lifetime. For internal use only.</summary>
    private void AddOwnershipEventHandlers()
    {
        AddNativeEventHandler("eo", "_EFL_EVENT_INVALIDATE", ownershipUniqueDelegate, ownershipUniqueDelegate);
        AddNativeEventHandler("eo", "_EFL_EVENT_OWNERSHIP_UNIQUE", ownershipUniqueDelegate, ownershipUniqueDelegate);
        AddNativeEventHandler("eo", "_EFL_EVENT_OWNERSHIP_SHARED", ownershipSharedDelegate, ownershipSharedDelegate);
        Eina.Error.RaiseIfUnhandledException();
    }
}

} // namespace Global

} // namespace Efl
