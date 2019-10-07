using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Reflection;
using System.Collections;

namespace UIKit
{

namespace Wrapper
{

/// <summary>
/// Abstract class that delivers base level binding to UIKit Objects.
///
/// Most of it is protected functionalities to serve the generated
/// binding classes that inherit from it.
/// </summary>
public abstract class ObjectWrapper : IWrapper, IDisposable
{
    /// <summary>Object used to synchronize access to EFL events.</summary>
    private readonly object eflBindingEventLock = new object();
    private bool generated = true;
    private System.IntPtr handle = IntPtr.Zero;

    private static UIKit.EventCb ownershipUniqueDelegate = new UIKit.EventCb(OwnershipUniqueCallback);
    private static UIKit.EventCb ownershipSharedDelegate = new UIKit.EventCb(OwnershipSharedCallback);

    private Hashtable keyValueHash = null;

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.
    /// For a class that inherited from an EFL# class to be properly constructed from native code
    /// one must create a constructor with this signature and calls this base constructor from it.
    /// This constructor will take care of calling base constructors of the native classes and
    /// perform additional setup so objects are ready to use.
    /// It is advisable to check for the <see cref="NativeHandle"/> property in the top level
    /// constructor and signal an error when it has a value of IntPtr.Zero after this
    /// constructor completion.
    /// Warning: Do not use this constructor directly from a `new` statement.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ObjectWrapper(ConstructingHandle ch)
    {
        generated = false;
        handle = UIKit.Wrapper.Globals.efl_constructor(UIKit.Wrapper.Globals.efl_super(ch.NativeHandle, UIKit.Wrapper.Globals.efl_class_get(ch.NativeHandle)));
        if (handle == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Warning("Natice constructor returned NULL");
            return;
        }

        AddWrapperSupervisor();
        // Make an additional reference to C#
        // - Will also call EVENT_OWNERSHIP_SHARED
        UIKit.Wrapper.Globals.efl_ref(handle);
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
    /// Do not implement this constructor.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ObjectWrapper(UIKit.Wrapper.Globals.WrappingHandle wh)
    {
        handle = wh.NativeHandle;
        AddWrapperSupervisor();
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to actually call the native library constructors. C# subclasses
    /// must use the public constructor only.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    /// <param name="file">Name of the file from where the constructor is called.</param>
    /// <param name="line">Number of the line from where the constructor is called.</param>
    protected ObjectWrapper(IntPtr baseKlass, UIKit.Object parent,
                        [CallerFilePath] string file = null,
                        [CallerLineNumber] int line = 0)
    {
        generated = UIKit.Wrapper.BindingEntity.IsBindingEntity(((object)this).GetType());
        IntPtr actual_klass = baseKlass;
        if (!generated)
        {
            actual_klass = UIKit.Wrapper.ClassRegister.GetInheritKlassOrRegister(baseKlass, ((object)this).GetType());
        }

        // Creation of the unfinalized Eo handle
        UIKit.DataTypes.Log.Debug($"Instantiating from klass 0x{actual_klass.ToInt64():x}");
        System.IntPtr parent_ptr = System.IntPtr.Zero;
        if (parent != null)
        {
            parent_ptr = parent.NativeHandle;
        }

        if (generated)
        {
            handle = UIKit.Wrapper.Globals._efl_add_internal_start(file, line, actual_klass, parent_ptr, 1, 0);
        }
        else
        {
            handle = UIKit.Wrapper.Globals._efl_add_internal_start_bindings(file, line, actual_klass, parent_ptr, 1, 0,
                                                                     UIKit.Wrapper.Globals.efl_mono_avoid_top_level_constructor_callback_addr_get(),
                                                                     IntPtr.Zero);
        }

        if (handle == System.IntPtr.Zero)
        {
            throw new Exception("Instantiation failed");
        }

        UIKit.DataTypes.Log.Debug($"Eo instance right after internal_start 0x{handle.ToInt64():x} with refcount {UIKit.Wrapper.Globals.efl_ref_count(handle)}");
        UIKit.DataTypes.Log.Debug($"Parent was 0x{parent_ptr.ToInt64()}");

        // Creation of wrapper supervisor
        AddWrapperSupervisor();
    }

    /// <summary>Destructor.</summary>
    ~ObjectWrapper()
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

    /// <summary>
    /// Whether this object type is one of the generated binding classes or a custom
    /// class defined by the user and that inherit from one of the generated ones.
    /// </summary>
    /// <returns>
    /// True if this object type is one of the generated binding classes,
    /// false if it is class that is manually defined and that inherits from
    /// one of the generated ones, including user defined classes.
    /// </returns>
    protected bool IsGeneratedBindingClass
    {
        get { return generated; }
    }

    /// <summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing && handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;
            UIKit.Wrapper.Globals.efl_mono_native_dispose(h);
        }
        else
        {
            Monitor.Enter(UIKit.All.InitLock);
            if (UIKit.All.MainLoopInitialized)
            {
                UIKit.Wrapper.Globals.efl_mono_thread_safe_native_dispose(handle);
            }

            Monitor.Exit(UIKit.All.InitLock);
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
        ((UIKit.Object)this).SetParent(null);
        Dispose();
    }

    /// <summary>Finishes instantiating this object.
    /// Internal usage by generated code.</summary>
    protected void FinishInstantiation()
    {
        UIKit.DataTypes.Log.Debug("calling efl_add_internal_end");
        var h = UIKit.Wrapper.Globals._efl_add_end(handle, 1, 0);
        UIKit.DataTypes.Log.Debug($"efl_add_end returned eo 0x{handle.ToInt64():x}");

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
    protected void AddNativeEventHandler(string lib, string key, UIKit.EventCb evtCaller, object evtDelegate)
    {
        lock (eflBindingEventLock)
        {
            IntPtr desc = UIKit.EventDescription.GetNative(lib, key);
            if (desc == IntPtr.Zero)
            {
                UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
                return;
            }

            var wsPtr = UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_get(handle);
            var ws = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(wsPtr);
            if (ws.EoEvents.ContainsKey((desc, evtDelegate)))
            {
                UIKit.DataTypes.Log.Warning($"Event proxy for event {key} already registered!");
                return;
            }

            IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
            if (!UIKit.Wrapper.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, wsPtr))
            {
                UIKit.DataTypes.Log.Error($"Failed to add event proxy for event {key}");
                return;
            }

            ws.EoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
            UIKit.DataTypes.Error.RaiseIfUnhandledException();
        }
    }

    /// <summary>Removes the given event handler for the given event. For internal use only.</summary>
    /// <param name="lib">The name of the native library definining the event.</param>
    /// <param name="key">The name of the native event.</param>
    /// <param name="evtDelegate">The delegate to be removed.</param>
    protected void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        lock (eflBindingEventLock)
        {
            IntPtr desc = UIKit.EventDescription.GetNative(lib, key);
            if (desc == IntPtr.Zero)
            {
                UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
                return;
            }

            var wsPtr = UIKit.Wrapper.Globals.efl_mono_wrapper_supervisor_get(handle);
            var ws = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(wsPtr);
            var evtPair = (desc, evtDelegate);
            if (ws.EoEvents.TryGetValue(evtPair, out var caller))
            {
                if (!UIKit.Wrapper.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, wsPtr))
                {
                    UIKit.DataTypes.Log.Error($"Failed to remove event proxy for event {key}");
                    return;
                }

                ws.EoEvents.Remove(evtPair);
                UIKit.DataTypes.Error.RaiseIfUnhandledException();
            }
            else
            {
                UIKit.DataTypes.Log.Error($"Trying to remove proxy for event {key} when it is not registered.");
            }
        }
    }

    private static void OwnershipUniqueCallback(IntPtr data, ref UIKit.Event.NativeStruct evt)
    {
        var ws = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data);
        ws.MakeUnique();
    }

    private static void OwnershipSharedCallback(IntPtr data, ref UIKit.Event.NativeStruct evt)
    {
        var ws = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data);
        ws.MakeShared();
    }

    /// <summary>Create and set to the internal native state a C# supervisor for this Eo wrapper. For internal use only.</summary>
    private void AddWrapperSupervisor()
    {
        var ws = new UIKit.Wrapper.WrapperSupervisor(this);
        UIKit.Wrapper.Globals.SetWrapperSupervisor(handle, ws);
        if (UIKit.Wrapper.Globals.efl_ref_count(handle) > 1)
        {
            ws.MakeShared();
        }

        AddOwnershipEventHandlers();
    }

    /// <summary>Register handlers to ownership events, in order to control the object lifetime. For internal use only.</summary>
    private void AddOwnershipEventHandlers()
    {
        AddNativeEventHandler(UIKit.Libs.Eo, "_EFL_EVENT_INVALIDATE", ownershipUniqueDelegate, ownershipUniqueDelegate);
        AddNativeEventHandler(UIKit.Libs.Eo, "_EFL_EVENT_OWNERSHIP_UNIQUE", ownershipUniqueDelegate, ownershipUniqueDelegate);
        AddNativeEventHandler(UIKit.Libs.Eo, "_EFL_EVENT_OWNERSHIP_SHARED", ownershipSharedDelegate, ownershipSharedDelegate);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
    }

    /// <summary>
    /// Struct to be used when constructing objects from native code.
    /// Wraps the pointer handle to the native object instance.
    /// </summary>
    protected struct ConstructingHandle
    {
        /// <summary>Constructor for wrapping the native handle.</summary>
        public ConstructingHandle(IntPtr h)
        {
            NativeHandle = h;
        }

        /// <summary>Pointer to the native instance.</summary>
        public IntPtr NativeHandle { get; private set; }
    }

    /// <summary>
    /// Set a value object associated with a key object.
    /// </summary>
    public void SetKeyValue(object key, object val)
    {
        if (keyValueHash == null)
            keyValueHash = new Hashtable();

        keyValueHash.Add(key, val);
    }

    /// <summary>
    /// Get a value object associated with a key object.
    /// </summary>
    public object GetKeyValue(object key)
    {
        if (keyValueHash == null)
            return null;

        return keyValueHash[key];
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public abstract class NativeMethods : UIKit.Wrapper.NativeClass
    {
        private static UIKitConstructorDelegate csharpUIKitConstructorStaticDelegate = new UIKitConstructorDelegate(Constructor);
        private static UIKit.Wrapper.NativeModule EoModule = new UIKit.Wrapper.NativeModule(UIKit.Libs.Eo);

        private delegate IntPtr UIKitConstructorDelegate(IntPtr obj, IntPtr pd);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();

            descs.Add(new UIKit_Op_Description()
            {
                api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(EoModule.Module, "efl_constructor"),
                func = Marshal.GetFunctionPointerForDelegate(csharpUIKitConstructorStaticDelegate)
            });

            return descs;
        }

        private static IntPtr Constructor(IntPtr obj, IntPtr pd)
        {
            try
            {
                var eoKlass = UIKit.Wrapper.Globals.efl_class_get(obj);
                var managedType = ClassRegister.GetManagedType(eoKlass);
                if (managedType == null)
                {
                    IntPtr nativeName = UIKit.Wrapper.Globals.efl_class_name_get(eoKlass);
                    var name = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(nativeName);
                    UIKit.DataTypes.Log.Warning($"Can't get Managed class for object handle 0x{(UInt64)obj:x} with native class [{name}]");
                    return IntPtr.Zero;
                }

                var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                ConstructorInfo constructor = managedType.GetConstructor(flags, null, new Type[1] { typeof(ConstructingHandle) }, null);
                if (constructor == null)
                {
                    UIKit.DataTypes.Log.Error($"Type {managedType.FullName} lacks a constructor that receives a ConstructingHandle. It can not be constructed from native code.");
                    return IntPtr.Zero;
                }

                var eoWrapper = (UIKit.Wrapper.IWrapper) constructor.Invoke(new object[1] { new ConstructingHandle(obj) });
                if (eoWrapper == null)
                {
                    UIKit.DataTypes.Log.Warning("Constructor was unable to create a new object");
                    return IntPtr.Zero;
                }

                return eoWrapper.NativeHandle;
            }
            catch (Exception e)
            {
                UIKit.DataTypes.Log.Warning($"Inherited constructor error: {e.ToString()}");
                UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                return IntPtr.Zero;
            }
        }
    }
}

} // namespace Eo

/// <summary>Concrete realization of UIKit.Object.
///
/// Some legacy classes (like Evas.Canvas) may be returned by some methods. As these classes are not bound, we
/// allow minimal interaction with them through <see cref="UIKit.Object" />.
///
/// But as <see cref="UIKit.Object" /> is abstract, whis realized class will allow us to create C# instances of it.</summary>
internal class ObjectRealized : UIKit.Object
{
    protected ObjectRealized(UIKit.Wrapper.Globals.WrappingHandle ch) : base(ch) { }
}

} // namespace UIKit
