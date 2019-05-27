#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

public struct CallbackPriority
{
    private short payload;
    public static implicit operator CallbackPriority(short x)
    {
        return new CallbackPriority{payload=x};
    }

    public static implicit operator short(CallbackPriority x)
    {
        return x.payload;
    }

}

}

namespace Efl {

public partial class Constants
{
    public static readonly Efl.CallbackPriority CallbackPriorityBefore = -100;
}
}

namespace Efl {

public partial class Constants
{
    public static readonly Efl.CallbackPriority CallbackPriorityDefault = 0;
}
}

namespace Efl {

public partial class Constants
{
    public static readonly Efl.CallbackPriority CallbackPriorityAfter = 100;
}
}

namespace Efl {

/// <summary>Abstract EFL object class.
/// All EFL objects inherit from this class, which provides basic functionality like naming, debugging, hierarchy traversal, event emission and life cycle management.
/// 
/// Life Cycle Objects are created with efl_add() and mostly disposed of with efl_del(). As an optimization, efl_add() accepts a list of initialization functions which the programmer can use to further customize the object before it is fully constructed. Also, objects can have a parent which will keep them alive as long as the parent is alive, so the programmer does not need to keep track of references. (See the <see cref="Efl.Object.Parent"/> property for details). Due to the above characteristics, EFL objects undergo the following phases during their Life Cycle: - Construction: The Efl.Object.constructor method is called. Afterwards, any user-supplied initialization methods are called. - Finalization: The <see cref="Efl.Object.FinalizeAdd"/> method is called and <see cref="Efl.Object.GetFinalized"/> is set to <c>true</c> when it returns. Object is usable at this point. - Invalidation: The object has lost its parent. The <see cref="Efl.Object.Invalidate"/> method is called so all the object&apos;s relationships can be terminated. <see cref="Efl.Object.GetInvalidated"/> is set to <c>true</c>. - Destruction: The object has no parent and it can be destroyed. The <see cref="Efl.Object.Destructor"/> method is called, use it to return any resources the object might have gathered during its life.
/// (Since EFL 1.22)</summary>
[Efl.Object.NativeMethods]
public abstract class Object :  Efl.Eo.IWrapper, IDisposable
{
    ///<summary>Pointer to the native class description.</summary>
    public virtual System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Object))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    protected Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    protected readonly object eventLock = new object();
    protected bool inherited;
    protected  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] internal static extern System.IntPtr
        efl_object_class_get();
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Object(Efl.Object parent= null
            ) : this(efl_object_class_get(), typeof(Object), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Object(System.IntPtr raw)
    {
        handle = raw;
    }

    [Efl.Eo.PrivateNativeClass]
    private class ObjectRealized : Object
    {
        private ObjectRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to actually call the native library constructors. C# subclasses
    /// must use the public constructor only.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Object(IntPtr baseKlass, System.Type managedType, Efl.Object parent)
    {
        inherited = ((object)this).GetType() != managedType;
        IntPtr actual_klass = baseKlass;
        if (inherited)
        {
            actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(baseKlass, ((object)this).GetType());
        }

        handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
        if (inherited)
        {
            Efl.Eo.Globals.PrivateDataSet(this);
        }
    }

    /// <summary>Finishes instantiating this object.
    /// Internal usage by generated code.</summary>
    protected void FinishInstantiation()
    {
        handle = Efl.Eo.Globals.instantiate_end(handle);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Destructor.</summary>
    ~Object()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
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
    protected void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
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
    protected void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
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

    /// <summary>Object is being deleted. See <see cref="Efl.Object.Destructor"/>.
    /// (Since EFL 1.22)</summary>
    public event EventHandler DelEvt
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

                string key = "_EFL_EVENT_DEL";
                AddNativeEventHandler(efl.Libs.Eo, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_DEL";
                RemoveNativeEventHandler(efl.Libs.Eo, key, value);
            }
        }
    }
    ///<summary>Method to raise event DelEvt.</summary>
    public void OnDelEvt(EventArgs e)
    {
        var key = "_EFL_EVENT_DEL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Object is being invalidated and losing its parent. See <see cref="Efl.Object.Invalidate"/>.
    /// (Since EFL 1.22)</summary>
    public event EventHandler InvalidateEvt
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

                string key = "_EFL_EVENT_INVALIDATE";
                AddNativeEventHandler(efl.Libs.Eo, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_INVALIDATE";
                RemoveNativeEventHandler(efl.Libs.Eo, key, value);
            }
        }
    }
    ///<summary>Method to raise event InvalidateEvt.</summary>
    public void OnInvalidateEvt(EventArgs e)
    {
        var key = "_EFL_EVENT_INVALIDATE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Object has lost its last reference, only parent relationship is keeping it alive. Advanced usage.
    /// (Since EFL 1.22)</summary>
    public event EventHandler NorefEvt
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

                string key = "_EFL_EVENT_NOREF";
                AddNativeEventHandler(efl.Libs.Eo, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_NOREF";
                RemoveNativeEventHandler(efl.Libs.Eo, key, value);
            }
        }
    }
    ///<summary>Method to raise event NorefEvt.</summary>
    public void OnNorefEvt(EventArgs e)
    {
        var key = "_EFL_EVENT_NOREF";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Object has been fully destroyed. It can not be used beyond this point. This event should only serve to clean up any reference you keep to the object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler DestructEvt
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

                string key = "_EFL_EVENT_DESTRUCT";
                AddNativeEventHandler(efl.Libs.Eo, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_DESTRUCT";
                RemoveNativeEventHandler(efl.Libs.Eo, key, value);
            }
        }
    }
    ///<summary>Method to raise event DestructEvt.</summary>
    public void OnDestructEvt(EventArgs e)
    {
        var key = "_EFL_EVENT_DESTRUCT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The parent of an object.
    /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
    /// 
    /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
    /// 
    /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new parent.</returns>
    virtual public Efl.Object GetParent() {
         var _ret_var = Efl.Object.NativeMethods.efl_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The parent of an object.
    /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
    /// 
    /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
    /// 
    /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.
    /// (Since EFL 1.22)</summary>
    /// <param name="parent">The new parent.</param>
    virtual public void SetParent(Efl.Object parent) {
                                 Efl.Object.NativeMethods.efl_parent_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),parent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The name of the object.
    /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.
    /// (Since EFL 1.22)</summary>
    /// <returns>The name.</returns>
    virtual public System.String GetName() {
         var _ret_var = Efl.Object.NativeMethods.efl_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The name of the object.
    /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">The name.</param>
    virtual public void SetName(System.String name) {
                                 Efl.Object.NativeMethods.efl_name_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A human readable comment for the object.
    /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.
    /// (Since EFL 1.22)</summary>
    /// <returns>The comment.</returns>
    virtual public System.String GetComment() {
         var _ret_var = Efl.Object.NativeMethods.efl_comment_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A human readable comment for the object.
    /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.
    /// (Since EFL 1.22)</summary>
    /// <param name="comment">The comment.</param>
    virtual public void SetComment(System.String comment) {
                                 Efl.Object.NativeMethods.efl_comment_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),comment);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Return the global count of freeze events.
    /// This is the amount of calls to <see cref="Efl.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="Efl.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The global event freeze count.</returns>
    public static int GetEventGlobalFreezeCount() {
         var _ret_var = Efl.Object.NativeMethods.efl_event_global_freeze_count_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Return the count of freeze events for this object.
    /// This is the amount of calls to <see cref="Efl.Object.FreezeEvent"/> minus the amount of calls to <see cref="Efl.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The event freeze count of this object.</returns>
    virtual public int GetEventFreezeCount() {
         var _ret_var = Efl.Object.NativeMethods.efl_event_freeze_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is finalized, <c>false</c> otherwise.</returns>
    virtual public bool GetFinalized() {
         var _ret_var = Efl.Object.NativeMethods.efl_finalized_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is invalidated, <c>false</c> otherwise.</returns>
    virtual public bool GetInvalidated() {
         var _ret_var = Efl.Object.NativeMethods.efl_invalidated_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="Efl.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is invalidating, <c>false</c> otherwise.</returns>
    virtual public bool GetInvalidating() {
         var _ret_var = Efl.Object.NativeMethods.efl_invalidating_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Allow an object to be deleted by unref even if it has a parent.
    /// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
    /// 
    /// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as efl_unref() is stealing the ref from the parent.
    /// 
    /// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether to allow efl_unref() to zero even if <see cref="Efl.Object.Parent"/> is not <c>null</c>.</returns>
    virtual public bool GetAllowParentUnref() {
         var _ret_var = Efl.Object.NativeMethods.efl_allow_parent_unref_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Allow an object to be deleted by unref even if it has a parent.
    /// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
    /// 
    /// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as efl_unref() is stealing the ref from the parent.
    /// 
    /// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.
    /// (Since EFL 1.22)</summary>
    /// <param name="allow">Whether to allow efl_unref() to zero even if <see cref="Efl.Object.Parent"/> is not <c>null</c>.</param>
    virtual public void SetAllowParentUnref(bool allow) {
                                 Efl.Object.NativeMethods.efl_allow_parent_unref_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),allow);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Build a read-only name for this object used for debugging.
    /// Multiple calls using efl_super() can be chained in order to build the entire debug name, from parent to child classes. In C the usual way to build the string is as follows:
    /// 
    /// efl_debug_name_override(efl_super(obj, MY_CLASS), sb); eina_strbuf_append_printf(sb, &quot;new_information&quot;);
    /// 
    /// Usually more debug information should be added to <c>sb</c> after calling the super function.
    /// (Since EFL 1.22)</summary>
    /// <param name="sb">A string buffer, must not be <c>null</c>.</param>
    virtual public void DebugNameOverride(Eina.Strbuf sb) {
                                 Efl.Object.NativeMethods.efl_debug_name_override_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),sb);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Searches upwards in the object tree for a provider which knows the given class/interface.
    /// The object from the provider will then be returned. The base implementation calls the provider_find function on the object parent, and returns its result. If no parent is present NULL is returned. Each implementation has to support this function by overriding it and returning itself if the interface matches the parameter. If this is not done the class cannot be found up in the object tree.
    /// (Since EFL 1.22)</summary>
    /// <param name="klass">The class identifier to search for.</param>
    /// <returns>Object from the provider list.</returns>
    virtual public Efl.Object FindProvider(Type klass) {
                                 var _ret_var = Efl.Object.NativeMethods.efl_provider_find_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),klass);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Implement this method to provide deinitialization code for your object if you need it.
    /// Will be called once <see cref="Efl.Object.Invalidate"/> has returned. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    virtual public void Destructor() {
         Efl.Object.NativeMethods.efl_destructor_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implement this method to finish the initialization of your object after all (if any) user-provided configuration methods have been executed.
    /// Use this method to delay expensive operations until user configuration has finished, to avoid building the object in a &quot;default&quot; state in the constructor, just to have to throw it all away because a user configuration (a property being set, for example) requires a different state. This is the last call inside efl_add() and will set <see cref="Efl.Object.GetFinalized"/> to <c>true</c> once it returns. This is an optimization and implementing this method is optional if you already perform all your initialization in the Efl.Object.constructor method. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new object. Return <c>NULL</c> to abort object creation.</returns>
    virtual public Efl.Object FinalizeAdd() {
         var _ret_var = Efl.Object.NativeMethods.efl_finalize_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Implement this method to perform special actions when your object loses its parent, if you need to.
    /// It is called when the parent reference is lost or set to <c>NULL</c>. After this call returns, <see cref="Efl.Object.GetInvalidated"/> is set to <c>true</c>. This allows a simpler tear down of complex hierarchies, by performing object destruction in two steps, first all object relationships are broken and then the isolated objects are destroyed. Performing everything in the <see cref="Efl.Object.Destructor"/> can sometimes lead to deadlocks, but implementing this method is optional if this is not your case. When an object with a parent is destroyed, it first receives a call to <see cref="Efl.Object.Invalidate"/> and then to <see cref="Efl.Object.Destructor"/>. See the Life Cycle section in this class&apos; description.
    /// (Since EFL 1.22)</summary>
    virtual public void Invalidate() {
         Efl.Object.NativeMethods.efl_invalidate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Find a child object with the given name and return it.
    /// The search string can be a glob (shell style, using *). It can also specify class name in the format of &quot;class:name&quot; where &quot;:&quot; separates class and name. Both class and name can be globs. If the class is specified but the name is empty like &quot;class:&quot; then the search will match any object of that class.
    /// (Since EFL 1.22)</summary>
    /// <param name="search">The name search string.</param>
    /// <returns>The first object found.</returns>
    virtual public Efl.Object FindName(System.String search) {
                                 var _ret_var = Efl.Object.NativeMethods.efl_name_find_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),search);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Thaw events of object.
    /// Allows event callbacks to be called again for this object after a call to <see cref="Efl.Object.FreezeEvent"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.
    /// (Since EFL 1.22)</summary>
    virtual public void ThawEvent() {
         Efl.Object.NativeMethods.efl_event_thaw_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Freeze events of this object.
    /// Prevents event callbacks from being called for this object. Enable events again using <see cref="Efl.Object.ThawEvent"/>. Events marked <c>hot</c> cannot be stopped.
    /// (Since EFL 1.22)</summary>
    virtual public void FreezeEvent() {
         Efl.Object.NativeMethods.efl_event_freeze_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Gobally thaw events for ALL EFL OBJECTS.
    /// Allows event callbacks to be called for all EFL objects after they have been disabled by <see cref="Efl.Object.FreezeEventGlobal"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.
    /// (Since EFL 1.22)</summary>
    public static void ThawEventGlobal() {
         Efl.Object.NativeMethods.efl_event_global_thaw_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Globally freeze events for ALL EFL OBJECTS.
    /// Prevents event callbacks from being called for all EFL objects. Enable events again using <see cref="Efl.Object.ThawEventGlobal"/>. Events marked <c>hot</c> cannot be stopped.
    /// 
    /// Note: USE WITH CAUTION.
    /// (Since EFL 1.22)</summary>
    public static void FreezeEventGlobal() {
         Efl.Object.NativeMethods.efl_event_global_freeze_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop the current callback call.
    /// This stops the current callback call. Any other callbacks for the current event will not be called. This is useful when you want to filter out events. Just add higher priority events and call this under certain conditions to block a certain event.
    /// (Since EFL 1.22)</summary>
    virtual public void EventCallbackStop() {
         Efl.Object.NativeMethods.efl_event_callback_stop_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Remove an event callback forwarder for a specified event and object.
    /// (Since EFL 1.22)</summary>
    /// <param name="desc">The description of the event to listen to</param>
    /// <param name="new_obj">The object to emit events from</param>
    virtual public void DelEventCallbackForwarder(Efl.EventDescription desc, Efl.Object new_obj) {
         var _in_desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(desc);
                                                Efl.Object.NativeMethods.efl_event_callback_forwarder_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_desc, new_obj);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get an iterator on all childrens
    /// (Since EFL 1.22)</summary>
    /// <returns>Children iterator</returns>
    virtual public Eina.Iterator<Efl.Object> NewChildrenIterator() {
         var _ret_var = Efl.Object.NativeMethods.efl_children_iterator_new_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Object>(_ret_var, true, false);
 }
    /// <summary>Make an object a composite object of another.
    /// The class of comp_obj must be part of the extensions of the class of the parent. It isn&apos;t possible to attach more then 1 composite of the same class. This function also sets the parent of comp_obj to parent.
    /// 
    /// See <see cref="Efl.Object.CompositeDetach"/>, <see cref="Efl.Object.IsCompositePart"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="comp_obj">the object that will be used to composite the parent.</param>
    /// <returns><c>true</c> if successful. <c>false</c> otherwise.</returns>
    virtual public bool AttachComposite(Efl.Object comp_obj) {
                                 var _ret_var = Efl.Object.NativeMethods.efl_composite_attach_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),comp_obj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Detach a composite object from another object.
    /// This functions also sets the parent of comp_obj to <c>null</c>.
    /// 
    /// See <see cref="Efl.Object.AttachComposite"/>, <see cref="Efl.Object.IsCompositePart"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="comp_obj">The object that will be removed from the parent.</param>
    /// <returns><c>true</c> if successful. <c>false</c> otherwise.</returns>
    virtual public bool CompositeDetach(Efl.Object comp_obj) {
                                 var _ret_var = Efl.Object.NativeMethods.efl_composite_detach_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),comp_obj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Check if an object is part of a composite object.
    /// See <see cref="Efl.Object.AttachComposite"/>, <see cref="Efl.Object.IsCompositePart"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if it is. <c>false</c> otherwise.</returns>
    virtual public bool IsCompositePart() {
         var _ret_var = Efl.Object.NativeMethods.efl_composite_part_is_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The parent of an object.
/// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
/// 
/// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
/// 
/// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.
/// (Since EFL 1.22)</summary>
/// <value>The new parent.</value>
    public Efl.Object Parent {
        get { return GetParent(); }
        set { SetParent(value); }
    }
    /// <summary>The name of the object.
/// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.
/// (Since EFL 1.22)</summary>
/// <value>The name.</value>
    public System.String Name {
        get { return GetName(); }
        set { SetName(value); }
    }
    /// <summary>A human readable comment for the object.
/// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.
/// (Since EFL 1.22)</summary>
/// <value>The comment.</value>
    public System.String Comment {
        get { return GetComment(); }
        set { SetComment(value); }
    }
    /// <summary>Return the global count of freeze events.
/// This is the amount of calls to <see cref="Efl.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="Efl.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).
/// (Since EFL 1.22)</summary>
/// <value>The global event freeze count.</value>
    public static int EventGlobalFreezeCount {
        get { return GetEventGlobalFreezeCount(); }
    }
    /// <summary>Return the count of freeze events for this object.
/// This is the amount of calls to <see cref="Efl.Object.FreezeEvent"/> minus the amount of calls to <see cref="Efl.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).
/// (Since EFL 1.22)</summary>
/// <value>The event freeze count of this object.</value>
    public int EventFreezeCount {
        get { return GetEventFreezeCount(); }
    }
    /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is finalized, <c>false</c> otherwise.</value>
    public bool Finalized {
        get { return GetFinalized(); }
    }
    /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is invalidated, <c>false</c> otherwise.</value>
    public bool Invalidated {
        get { return GetInvalidated(); }
    }
    /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="Efl.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is invalidating, <c>false</c> otherwise.</value>
    public bool Invalidating {
        get { return GetInvalidating(); }
    }
    /// <summary>Allow an object to be deleted by unref even if it has a parent.
/// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
/// 
/// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as efl_unref() is stealing the ref from the parent.
/// 
/// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.
/// (Since EFL 1.22)</summary>
/// <value>Whether to allow efl_unref() to zero even if <see cref="Efl.Object.Parent"/> is not <c>null</c>.</value>
    public bool AllowParentUnref {
        get { return GetAllowParentUnref(); }
        set { SetAllowParentUnref(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Object.efl_object_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Eo);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_parent_get_static_delegate == null)
            {
                efl_parent_get_static_delegate = new efl_parent_get_delegate(parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_get_static_delegate) });
            }

            if (efl_parent_set_static_delegate == null)
            {
                efl_parent_set_static_delegate = new efl_parent_set_delegate(parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_set_static_delegate) });
            }

            if (efl_name_get_static_delegate == null)
            {
                efl_name_get_static_delegate = new efl_name_get_delegate(name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_name_get_static_delegate) });
            }

            if (efl_name_set_static_delegate == null)
            {
                efl_name_set_static_delegate = new efl_name_set_delegate(name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_name_set_static_delegate) });
            }

            if (efl_comment_get_static_delegate == null)
            {
                efl_comment_get_static_delegate = new efl_comment_get_delegate(comment_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetComment") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_get_static_delegate) });
            }

            if (efl_comment_set_static_delegate == null)
            {
                efl_comment_set_static_delegate = new efl_comment_set_delegate(comment_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetComment") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_set"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_set_static_delegate) });
            }

            if (efl_event_freeze_count_get_static_delegate == null)
            {
                efl_event_freeze_count_get_static_delegate = new efl_event_freeze_count_get_delegate(event_freeze_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEventFreezeCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_count_get_static_delegate) });
            }

            if (efl_finalized_get_static_delegate == null)
            {
                efl_finalized_get_static_delegate = new efl_finalized_get_delegate(finalized_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFinalized") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_finalized_get_static_delegate) });
            }

            if (efl_invalidated_get_static_delegate == null)
            {
                efl_invalidated_get_static_delegate = new efl_invalidated_get_delegate(invalidated_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInvalidated") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidated_get_static_delegate) });
            }

            if (efl_invalidating_get_static_delegate == null)
            {
                efl_invalidating_get_static_delegate = new efl_invalidating_get_delegate(invalidating_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInvalidating") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidating_get_static_delegate) });
            }

            if (efl_allow_parent_unref_get_static_delegate == null)
            {
                efl_allow_parent_unref_get_static_delegate = new efl_allow_parent_unref_get_delegate(allow_parent_unref_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAllowParentUnref") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_allow_parent_unref_get"), func = Marshal.GetFunctionPointerForDelegate(efl_allow_parent_unref_get_static_delegate) });
            }

            if (efl_allow_parent_unref_set_static_delegate == null)
            {
                efl_allow_parent_unref_set_static_delegate = new efl_allow_parent_unref_set_delegate(allow_parent_unref_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAllowParentUnref") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_allow_parent_unref_set"), func = Marshal.GetFunctionPointerForDelegate(efl_allow_parent_unref_set_static_delegate) });
            }

            if (efl_debug_name_override_static_delegate == null)
            {
                efl_debug_name_override_static_delegate = new efl_debug_name_override_delegate(debug_name_override);
            }

            if (methods.FirstOrDefault(m => m.Name == "DebugNameOverride") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_debug_name_override"), func = Marshal.GetFunctionPointerForDelegate(efl_debug_name_override_static_delegate) });
            }

            if (efl_provider_find_static_delegate == null)
            {
                efl_provider_find_static_delegate = new efl_provider_find_delegate(provider_find);
            }

            if (methods.FirstOrDefault(m => m.Name == "FindProvider") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_find"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_find_static_delegate) });
            }

            if (efl_destructor_static_delegate == null)
            {
                efl_destructor_static_delegate = new efl_destructor_delegate(destructor);
            }

            if (methods.FirstOrDefault(m => m.Name == "Destructor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_destructor"), func = Marshal.GetFunctionPointerForDelegate(efl_destructor_static_delegate) });
            }

            if (efl_finalize_static_delegate == null)
            {
                efl_finalize_static_delegate = new efl_finalize_delegate(finalize);
            }

            if (methods.FirstOrDefault(m => m.Name == "FinalizeAdd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalize"), func = Marshal.GetFunctionPointerForDelegate(efl_finalize_static_delegate) });
            }

            if (efl_invalidate_static_delegate == null)
            {
                efl_invalidate_static_delegate = new efl_invalidate_delegate(invalidate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Invalidate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidate"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidate_static_delegate) });
            }

            if (efl_name_find_static_delegate == null)
            {
                efl_name_find_static_delegate = new efl_name_find_delegate(name_find);
            }

            if (methods.FirstOrDefault(m => m.Name == "FindName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_find"), func = Marshal.GetFunctionPointerForDelegate(efl_name_find_static_delegate) });
            }

            if (efl_event_thaw_static_delegate == null)
            {
                efl_event_thaw_static_delegate = new efl_event_thaw_delegate(event_thaw);
            }

            if (methods.FirstOrDefault(m => m.Name == "ThawEvent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_event_thaw_static_delegate) });
            }

            if (efl_event_freeze_static_delegate == null)
            {
                efl_event_freeze_static_delegate = new efl_event_freeze_delegate(event_freeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "FreezeEvent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_static_delegate) });
            }

            if (efl_event_callback_stop_static_delegate == null)
            {
                efl_event_callback_stop_static_delegate = new efl_event_callback_stop_delegate(event_callback_stop);
            }

            if (methods.FirstOrDefault(m => m.Name == "EventCallbackStop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_callback_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_stop_static_delegate) });
            }

            if (efl_event_callback_forwarder_del_static_delegate == null)
            {
                efl_event_callback_forwarder_del_static_delegate = new efl_event_callback_forwarder_del_delegate(event_callback_forwarder_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelEventCallbackForwarder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_callback_forwarder_del"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_forwarder_del_static_delegate) });
            }

            if (efl_children_iterator_new_static_delegate == null)
            {
                efl_children_iterator_new_static_delegate = new efl_children_iterator_new_delegate(children_iterator_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewChildrenIterator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_children_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_children_iterator_new_static_delegate) });
            }

            if (efl_composite_attach_static_delegate == null)
            {
                efl_composite_attach_static_delegate = new efl_composite_attach_delegate(composite_attach);
            }

            if (methods.FirstOrDefault(m => m.Name == "AttachComposite") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_attach"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_attach_static_delegate) });
            }

            if (efl_composite_detach_static_delegate == null)
            {
                efl_composite_detach_static_delegate = new efl_composite_detach_delegate(composite_detach);
            }

            if (methods.FirstOrDefault(m => m.Name == "CompositeDetach") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_detach"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_detach_static_delegate) });
            }

            if (efl_composite_part_is_static_delegate == null)
            {
                efl_composite_part_is_static_delegate = new efl_composite_part_is_delegate(composite_part_is);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsCompositePart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_part_is"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_part_is_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Object.efl_object_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_parent_get_api_delegate> efl_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_parent_get_api_delegate>(Module, "efl_parent_get");

        private static Efl.Object parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_parent_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Object)wrapper).GetParent();
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
                return efl_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_parent_get_delegate efl_parent_get_static_delegate;

        
        private delegate void efl_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object parent);

        
        public delegate void efl_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object parent);

        public static Efl.Eo.FunctionWrapper<efl_parent_set_api_delegate> efl_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_parent_set_api_delegate>(Module, "efl_parent_set");

        private static void parent_set(System.IntPtr obj, System.IntPtr pd, Efl.Object parent)
        {
            Eina.Log.Debug("function efl_parent_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Object)wrapper).SetParent(parent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_parent_set_delegate efl_parent_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_name_get_api_delegate> efl_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_name_get_api_delegate>(Module, "efl_name_get");

        private static System.String name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_name_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Object)wrapper).GetName();
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
                return efl_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_name_get_delegate efl_name_get_static_delegate;

        
        private delegate void efl_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_name_set_api_delegate> efl_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_name_set_api_delegate>(Module, "efl_name_set");

        private static void name_set(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_name_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Object)wrapper).SetName(name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_name_set_delegate efl_name_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_comment_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_comment_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_comment_get_api_delegate> efl_comment_get_ptr = new Efl.Eo.FunctionWrapper<efl_comment_get_api_delegate>(Module, "efl_comment_get");

        private static System.String comment_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_comment_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Object)wrapper).GetComment();
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
                return efl_comment_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_comment_get_delegate efl_comment_get_static_delegate;

        
        private delegate void efl_comment_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String comment);

        
        public delegate void efl_comment_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String comment);

        public static Efl.Eo.FunctionWrapper<efl_comment_set_api_delegate> efl_comment_set_ptr = new Efl.Eo.FunctionWrapper<efl_comment_set_api_delegate>(Module, "efl_comment_set");

        private static void comment_set(System.IntPtr obj, System.IntPtr pd, System.String comment)
        {
            Eina.Log.Debug("function efl_comment_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Object)wrapper).SetComment(comment);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_comment_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), comment);
            }
        }

        private static efl_comment_set_delegate efl_comment_set_static_delegate;

        
        private delegate int efl_event_global_freeze_count_get_delegate();

        
        public delegate int efl_event_global_freeze_count_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate> efl_event_global_freeze_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate>(Module, "efl_event_global_freeze_count_get");

        private static int event_global_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_global_freeze_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = Object.GetEventGlobalFreezeCount();
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
                return efl_event_global_freeze_count_get_ptr.Value.Delegate();
            }
        }

        
        private delegate int efl_event_freeze_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_event_freeze_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_event_freeze_count_get_api_delegate> efl_event_freeze_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_event_freeze_count_get_api_delegate>(Module, "efl_event_freeze_count_get");

        private static int event_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_freeze_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Object)wrapper).GetEventFreezeCount();
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
                return efl_event_freeze_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_freeze_count_get_delegate efl_event_freeze_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_finalized_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_finalized_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_finalized_get_api_delegate> efl_finalized_get_ptr = new Efl.Eo.FunctionWrapper<efl_finalized_get_api_delegate>(Module, "efl_finalized_get");

        private static bool finalized_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_finalized_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).GetFinalized();
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
                return efl_finalized_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_finalized_get_delegate efl_finalized_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_invalidated_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_invalidated_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_invalidated_get_api_delegate> efl_invalidated_get_ptr = new Efl.Eo.FunctionWrapper<efl_invalidated_get_api_delegate>(Module, "efl_invalidated_get");

        private static bool invalidated_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_invalidated_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).GetInvalidated();
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
                return efl_invalidated_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidated_get_delegate efl_invalidated_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_invalidating_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_invalidating_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_invalidating_get_api_delegate> efl_invalidating_get_ptr = new Efl.Eo.FunctionWrapper<efl_invalidating_get_api_delegate>(Module, "efl_invalidating_get");

        private static bool invalidating_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_invalidating_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).GetInvalidating();
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
                return efl_invalidating_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidating_get_delegate efl_invalidating_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_allow_parent_unref_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_allow_parent_unref_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_allow_parent_unref_get_api_delegate> efl_allow_parent_unref_get_ptr = new Efl.Eo.FunctionWrapper<efl_allow_parent_unref_get_api_delegate>(Module, "efl_allow_parent_unref_get");

        private static bool allow_parent_unref_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_allow_parent_unref_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).GetAllowParentUnref();
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
                return efl_allow_parent_unref_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_allow_parent_unref_get_delegate efl_allow_parent_unref_get_static_delegate;

        
        private delegate void efl_allow_parent_unref_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allow);

        
        public delegate void efl_allow_parent_unref_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allow);

        public static Efl.Eo.FunctionWrapper<efl_allow_parent_unref_set_api_delegate> efl_allow_parent_unref_set_ptr = new Efl.Eo.FunctionWrapper<efl_allow_parent_unref_set_api_delegate>(Module, "efl_allow_parent_unref_set");

        private static void allow_parent_unref_set(System.IntPtr obj, System.IntPtr pd, bool allow)
        {
            Eina.Log.Debug("function efl_allow_parent_unref_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Object)wrapper).SetAllowParentUnref(allow);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_allow_parent_unref_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), allow);
            }
        }

        private static efl_allow_parent_unref_set_delegate efl_allow_parent_unref_set_static_delegate;

        
        private delegate void efl_debug_name_override_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf sb);

        
        public delegate void efl_debug_name_override_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf sb);

        public static Efl.Eo.FunctionWrapper<efl_debug_name_override_api_delegate> efl_debug_name_override_ptr = new Efl.Eo.FunctionWrapper<efl_debug_name_override_api_delegate>(Module, "efl_debug_name_override");

        private static void debug_name_override(System.IntPtr obj, System.IntPtr pd, Eina.Strbuf sb)
        {
            Eina.Log.Debug("function efl_debug_name_override was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Object)wrapper).DebugNameOverride(sb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_debug_name_override_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sb);
            }
        }

        private static efl_debug_name_override_delegate efl_debug_name_override_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_provider_find_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_provider_find_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEflClass))] Type klass);

        public static Efl.Eo.FunctionWrapper<efl_provider_find_api_delegate> efl_provider_find_ptr = new Efl.Eo.FunctionWrapper<efl_provider_find_api_delegate>(Module, "efl_provider_find");

        private static Efl.Object provider_find(System.IntPtr obj, System.IntPtr pd, Type klass)
        {
            Eina.Log.Debug("function efl_provider_find was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Object)wrapper).FindProvider(klass);
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
                return efl_provider_find_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), klass);
            }
        }

        private static efl_provider_find_delegate efl_provider_find_static_delegate;

        
        private delegate void efl_destructor_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_destructor_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_destructor_api_delegate> efl_destructor_ptr = new Efl.Eo.FunctionWrapper<efl_destructor_api_delegate>(Module, "efl_destructor");

        private static void destructor(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_destructor was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Object)wrapper).Destructor();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_destructor_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_destructor_delegate efl_destructor_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_finalize_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_finalize_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_finalize_api_delegate> efl_finalize_ptr = new Efl.Eo.FunctionWrapper<efl_finalize_api_delegate>(Module, "efl_finalize");

        private static Efl.Object finalize(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_finalize was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Object)wrapper).FinalizeAdd();
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
                return efl_finalize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_finalize_delegate efl_finalize_static_delegate;

        
        private delegate void efl_invalidate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_invalidate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_invalidate_api_delegate> efl_invalidate_ptr = new Efl.Eo.FunctionWrapper<efl_invalidate_api_delegate>(Module, "efl_invalidate");

        private static void invalidate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_invalidate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Object)wrapper).Invalidate();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_invalidate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidate_delegate efl_invalidate_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_name_find_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String search);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_name_find_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String search);

        public static Efl.Eo.FunctionWrapper<efl_name_find_api_delegate> efl_name_find_ptr = new Efl.Eo.FunctionWrapper<efl_name_find_api_delegate>(Module, "efl_name_find");

        private static Efl.Object name_find(System.IntPtr obj, System.IntPtr pd, System.String search)
        {
            Eina.Log.Debug("function efl_name_find was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Object)wrapper).FindName(search);
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
                return efl_name_find_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), search);
            }
        }

        private static efl_name_find_delegate efl_name_find_static_delegate;

        
        private delegate void efl_event_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_thaw_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_event_thaw_api_delegate> efl_event_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_event_thaw_api_delegate>(Module, "efl_event_thaw");

        private static void event_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_thaw was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Object)wrapper).ThawEvent();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_event_thaw_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_thaw_delegate efl_event_thaw_static_delegate;

        
        private delegate void efl_event_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_freeze_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_event_freeze_api_delegate> efl_event_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_event_freeze_api_delegate>(Module, "efl_event_freeze");

        private static void event_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_freeze was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Object)wrapper).FreezeEvent();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_event_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_freeze_delegate efl_event_freeze_static_delegate;

        
        private delegate void efl_event_global_thaw_delegate();

        
        public delegate void efl_event_global_thaw_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_event_global_thaw_api_delegate> efl_event_global_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_event_global_thaw_api_delegate>(Module, "efl_event_global_thaw");

        private static void event_global_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_global_thaw was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    Object.ThawEventGlobal();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_event_global_thaw_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_event_global_freeze_delegate();

        
        public delegate void efl_event_global_freeze_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_event_global_freeze_api_delegate> efl_event_global_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_event_global_freeze_api_delegate>(Module, "efl_event_global_freeze");

        private static void event_global_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_global_freeze was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    Object.FreezeEventGlobal();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_event_global_freeze_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_event_callback_stop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_callback_stop_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_event_callback_stop_api_delegate> efl_event_callback_stop_ptr = new Efl.Eo.FunctionWrapper<efl_event_callback_stop_api_delegate>(Module, "efl_event_callback_stop");

        private static void event_callback_stop(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_event_callback_stop was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((Object)wrapper).EventCallbackStop();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_event_callback_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_callback_stop_delegate efl_event_callback_stop_static_delegate;

        
        private delegate void efl_event_callback_forwarder_del_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object new_obj);

        
        public delegate void efl_event_callback_forwarder_del_api_delegate(System.IntPtr obj,  System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object new_obj);

        public static Efl.Eo.FunctionWrapper<efl_event_callback_forwarder_del_api_delegate> efl_event_callback_forwarder_del_ptr = new Efl.Eo.FunctionWrapper<efl_event_callback_forwarder_del_api_delegate>(Module, "efl_event_callback_forwarder_del");

        private static void event_callback_forwarder_del(System.IntPtr obj, System.IntPtr pd, System.IntPtr desc, Efl.Object new_obj)
        {
            Eina.Log.Debug("function efl_event_callback_forwarder_del was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        var _in_desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(desc);
                                                    
                try
                {
                    ((Object)wrapper).DelEventCallbackForwarder(_in_desc, new_obj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_event_callback_forwarder_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), desc, new_obj);
            }
        }

        private static efl_event_callback_forwarder_del_delegate efl_event_callback_forwarder_del_static_delegate;

        
        private delegate System.IntPtr efl_children_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_children_iterator_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_children_iterator_new_api_delegate> efl_children_iterator_new_ptr = new Efl.Eo.FunctionWrapper<efl_children_iterator_new_api_delegate>(Module, "efl_children_iterator_new");

        private static System.IntPtr children_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_children_iterator_new was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Iterator<Efl.Object> _ret_var = default(Eina.Iterator<Efl.Object>);
                try
                {
                    _ret_var = ((Object)wrapper).NewChildrenIterator();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_children_iterator_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_children_iterator_new_delegate efl_children_iterator_new_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_composite_attach_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object comp_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_composite_attach_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object comp_obj);

        public static Efl.Eo.FunctionWrapper<efl_composite_attach_api_delegate> efl_composite_attach_ptr = new Efl.Eo.FunctionWrapper<efl_composite_attach_api_delegate>(Module, "efl_composite_attach");

        private static bool composite_attach(System.IntPtr obj, System.IntPtr pd, Efl.Object comp_obj)
        {
            Eina.Log.Debug("function efl_composite_attach was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).AttachComposite(comp_obj);
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
                return efl_composite_attach_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), comp_obj);
            }
        }

        private static efl_composite_attach_delegate efl_composite_attach_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_composite_detach_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object comp_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_composite_detach_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object comp_obj);

        public static Efl.Eo.FunctionWrapper<efl_composite_detach_api_delegate> efl_composite_detach_ptr = new Efl.Eo.FunctionWrapper<efl_composite_detach_api_delegate>(Module, "efl_composite_detach");

        private static bool composite_detach(System.IntPtr obj, System.IntPtr pd, Efl.Object comp_obj)
        {
            Eina.Log.Debug("function efl_composite_detach was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).CompositeDetach(comp_obj);
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
                return efl_composite_detach_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), comp_obj);
            }
        }

        private static efl_composite_detach_delegate efl_composite_detach_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_composite_part_is_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_composite_part_is_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_composite_part_is_api_delegate> efl_composite_part_is_ptr = new Efl.Eo.FunctionWrapper<efl_composite_part_is_api_delegate>(Module, "efl_composite_part_is");

        private static bool composite_part_is(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_composite_part_is was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)wrapper).IsCompositePart();
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
                return efl_composite_part_is_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_composite_part_is_delegate efl_composite_part_is_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>A parameter passed in event callbacks holding extra event parameters.
/// This is the full event information passed to callbacks in C.
/// (Since EFL 1.22)</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Event
{
    /// <summary>The object the callback was called on.
/// (Since EFL 1.22)</summary>
    public Efl.Object Object;
    /// <summary>The event description.
/// (Since EFL 1.22)</summary>
    public Efl.EventDescription Desc;
    /// <summary>Extra event information passed by the event caller. Must be cast to the event type declared in the EO file. Keep in mind that: 1) Objects are passed as a normal Eo*. Event subscribers can call functions on these objects. 2) Structs, built-in types and containers are passed as const pointers, with one level of indirection.
/// (Since EFL 1.22)</summary>
    public System.IntPtr Info;
    ///<summary>Constructor for Event.</summary>
    public Event(
        Efl.Object Object = default(Efl.Object),
        Efl.EventDescription Desc = default(Efl.EventDescription),
        System.IntPtr Info = default(System.IntPtr)    )
    {
        this.Object = Object;
        this.Desc = Desc;
        this.Info = Info;
    }

    public static implicit operator Event(IntPtr ptr)
    {
        var tmp = (Event.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Event.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct Event.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        ///<summary>Internal wrapper for field Object</summary>
        public System.IntPtr Object;
        
        public System.IntPtr Desc;
        
        public System.IntPtr Info;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Event.NativeStruct(Event _external_struct)
        {
            var _internal_struct = new Event.NativeStruct();
            _internal_struct.Object = _external_struct.Object?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(_external_struct.Desc);
            _internal_struct.Info = _external_struct.Info;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Event(Event.NativeStruct _internal_struct)
        {
            var _external_struct = new Event();

            _external_struct.Object = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Object);
            _external_struct.Desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(_internal_struct.Desc);
            _external_struct.Info = _internal_struct.Info;
            return _external_struct;
        }

    }

}

}

