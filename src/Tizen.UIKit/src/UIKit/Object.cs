#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>Callback priority. Range is -32k - 32k. The lower the number, the higher the priority.
/// This is used to insert an event handler relative to the existing stack of sorted event handlers according to that priority. All event handlers always have a priority. If not specified <see cref="UIKit.Constants.CallbackPriorityDefault"/> is to be assumed.
/// 
/// See <see cref="UIKit.Constants.CallbackPriorityBefore"/> <see cref="UIKit.Constants.CallbackPriorityDefault"/>  <see cref="UIKit.Constants.CallbackPriorityAfter"/></summary>
/// <since_tizen> 6 </since_tizen>
public struct CallbackPriority
{
    private short payload;

    /// <summary>Converts an instance of short to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator CallbackPriority(short value)
    {
        return new CallbackPriority{payload=value};
    }

    /// <summary>Converts an instance of this struct to short.</summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator short(CallbackPriority value)
    {
        return value.payload;
    }
}
}

namespace UIKit {

public partial class Constants
{
    /// <summary>Slightly more prioritized than default.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly UIKit.CallbackPriority CallbackPriorityBefore = -100;
}
}

namespace UIKit {

public partial class Constants
{
    /// <summary>Default priority.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly UIKit.CallbackPriority CallbackPriorityDefault = 0;
}
}

namespace UIKit {

public partial class Constants
{
    /// <summary>Slightly less prioritized than default.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly UIKit.CallbackPriority CallbackPriorityAfter = 100;
}
}

namespace UIKit {

/// <summary>Abstract EFL object class.
/// All EFL objects inherit from this class, which provides basic functionality like naming, debugging, hierarchy traversal, event emission and life cycle management.
/// 
/// Life Cycle Objects are created with efl_add() and mostly disposed of with efl_del(). As an optimization, efl_add() accepts a list of initialization functions which the programmer can use to further customize the object before it is fully constructed. Also, objects can have a parent which will keep them alive as long as the parent is alive, so the programmer does not need to keep track of references. (See the <see cref="UIKit.Object.Parent"/> property for details). Due to the above characteristics, EFL objects undergo the following phases during their Life Cycle: - Construction: The UIKit.Object.constructor method is called. Afterwards, any user-supplied initialization methods are called. - Finalization: The <see cref="UIKit.Object.FinalizeAdd"/> method is called and <see cref="UIKit.Object.GetFinalized"/> is set to <c>true</c> when it returns. Object is usable at this point. - Invalidation: The object has lost its parent. The <see cref="UIKit.Object.Invalidate"/> method is called so all the object&apos;s relationships can be terminated. <see cref="UIKit.Object.GetInvalidated"/> is set to <c>true</c>. - Destruction: The object has no parent and it can be destroyed. The <see cref="UIKit.Object.Destructor"/> method is called, use it to return any resources the object might have gathered during its life.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Object.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public abstract partial class Object : UIKit.Wrapper.ObjectWrapper
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Object))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Eo)] internal static extern System.IntPtr
        efl_object_class_get();

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Object(UIKit.Object parent= null
            ) : base(efl_object_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Object(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Object(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [UIKit.Wrapper.PrivateNativeClass]
    private class ObjectRealized : Object
    {
        private ObjectRealized(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Object(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Object is being deleted. See <see cref="UIKit.Object.Destructor"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler DelEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_DEL";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_DEL";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event DelEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDelEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_DEL";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object is being invalidated and losing its parent. See <see cref="UIKit.Object.Invalidate"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler InvalidateEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_INVALIDATE";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_INVALIDATE";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event InvalidateEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnInvalidateEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_INVALIDATE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object has lost its last reference, only parent relationship is keeping it alive. Advanced usage.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler NorefEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_NOREF";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_NOREF";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event NorefEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnNorefEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_NOREF";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object has lost a reference and only one is left. It has just one owner now. Triggered whenever the refcount goes from two to one.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler OwnershipUniqueEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_OWNERSHIP_UNIQUE";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_OWNERSHIP_UNIQUE";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event OwnershipUniqueEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnOwnershipUniqueEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_OWNERSHIP_UNIQUE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object has acquired a second reference. It has multiple owners now. Triggered whenever increasing the refcount from one to two, it will not trigger by further increasing the refcount beyond two.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler OwnershipSharedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_OWNERSHIP_SHARED";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_OWNERSHIP_SHARED";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event OwnershipSharedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnOwnershipSharedEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_OWNERSHIP_SHARED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object has been fully destroyed. It can not be used beyond this point. This event should only serve to clean up any reference you keep to the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler DestructEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_DESTRUCT";
            AddNativeEventHandler(UIKit.Libs.Eo, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_DESTRUCT";
            RemoveNativeEventHandler(UIKit.Libs.Eo, key, value);
        }
    }

    /// <summary>Method to raise event DestructEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDestructEvent(EventArgs e)
    {
        var key = "_EFL_EVENT_DESTRUCT";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Eo, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }


    /// <summary>The parent of an object.
    /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
    /// 
    /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
    /// 
    /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The new parent.</returns>
    public virtual UIKit.Object GetParent() {
        var _ret_var = UIKit.Object.NativeMethods.efl_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The parent of an object.
    /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
    /// 
    /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
    /// 
    /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="parent">The new parent.</param>
    public virtual void SetParent(UIKit.Object parent) {
        UIKit.Object.NativeMethods.efl_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),parent);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The name of the object.
    /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The name.</returns>
    public virtual System.String GetName() {
        var _ret_var = UIKit.Object.NativeMethods.efl_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The name of the object.
    /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="name">The name.</param>
    public virtual void SetName(System.String name) {
        UIKit.Object.NativeMethods.efl_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>A human readable comment for the object.
    /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The comment.</returns>
    public virtual System.String GetComment() {
        var _ret_var = UIKit.Object.NativeMethods.efl_comment_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A human readable comment for the object.
    /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="comment">The comment.</param>
    public virtual void SetComment(System.String comment) {
        UIKit.Object.NativeMethods.efl_comment_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),comment);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Return the global count of freeze events.
    /// This is the amount of calls to <see cref="UIKit.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="UIKit.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The global event freeze count.</returns>
    public static int GetEventGlobalFreezeCount() {
        var _ret_var = UIKit.Object.NativeMethods.efl_event_global_freeze_count_get_ptr.Value.Delegate();
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Return the count of freeze events for this object.
    /// This is the amount of calls to <see cref="UIKit.Object.FreezeEvent"/> minus the amount of calls to <see cref="UIKit.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The event freeze count of this object.</returns>
    public virtual int GetEventFreezeCount() {
        var _ret_var = UIKit.Object.NativeMethods.efl_event_freeze_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is finalized, <c>false</c> otherwise.</returns>
    public virtual bool GetFinalized() {
        var _ret_var = UIKit.Object.NativeMethods.efl_finalized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is invalidated, <c>false</c> otherwise.</returns>
    public virtual bool GetInvalidated() {
        var _ret_var = UIKit.Object.NativeMethods.efl_invalidated_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="UIKit.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is invalidating, <c>false</c> otherwise.</returns>
    public virtual bool GetInvalidating() {
        var _ret_var = UIKit.Object.NativeMethods.efl_invalidating_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Build a read-only name for this object used for debugging.
    /// Multiple calls using efl_super() can be chained in order to build the entire debug name, from parent to child classes. In C the usual way to build the string is as follows:
    /// 
    /// efl_debug_name_override(efl_super(obj, MY_CLASS), sb); eina_strbuf_append_printf(sb, &quot;new_information&quot;);
    /// 
    /// Usually more debug information should be added to <c>sb</c> after calling the super function.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sb">A string buffer, must not be <c>null</c>.</param>
    public virtual void DebugNameOverride(UIKit.DataTypes.Strbuf sb) {
        UIKit.Object.NativeMethods.efl_debug_name_override_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),sb);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Searches upwards in the object tree for a provider which knows the given class/interface.
    /// The object from the provider will then be returned. The base implementation calls the provider_find function on the object parent, and returns its result. If no parent is present <c>NULL</c> is returned. Each implementation has to support this function by overriding it and returning itself if the interface matches the parameter. If this is not done the class cannot be found up in the object tree.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class identifier to search for.</param>
    /// <returns>Object from the provider list.</returns>
    public virtual UIKit.Object FindProvider(Type klass) {
        var _ret_var = UIKit.Object.NativeMethods.efl_provider_find_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Implement this method to provide deinitialization code for your object if you need it.
    /// Will be called once <see cref="UIKit.Object.Invalidate"/> has returned. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Destructor() {
        UIKit.Object.NativeMethods.efl_destructor_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Implement this method to finish the initialization of your object after all (if any) user-provided configuration methods have been executed.
    /// Use this method to delay expensive operations until user configuration has finished, to avoid building the object in a &quot;default&quot; state in the constructor, just to have to throw it all away because a user configuration (a property being set, for example) requires a different state. This is the last call inside efl_add() and will set <see cref="UIKit.Object.GetFinalized"/> to <c>true</c> once it returns. This is an optimization and implementing this method is optional if you already perform all your initialization in the UIKit.Object.constructor method. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The new object. Return <c>NULL</c> to abort object creation.</returns>
    public virtual UIKit.Object FinalizeAdd() {
        var _ret_var = UIKit.Object.NativeMethods.efl_finalize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Implement this method to perform special actions when your object loses its parent, if you need to.
    /// It is called when the parent reference is lost or set to <c>NULL</c>. After this call returns, <see cref="UIKit.Object.GetInvalidated"/> is set to <c>true</c>. This allows a simpler tear down of complex hierarchies, by performing object destruction in two steps, first all object relationships are broken and then the isolated objects are destroyed. Performing everything in the <see cref="UIKit.Object.Destructor"/> can sometimes lead to deadlocks, but implementing this method is optional if this is not your case. When an object with a parent is destroyed, it first receives a call to <see cref="UIKit.Object.Invalidate"/> and then to <see cref="UIKit.Object.Destructor"/>. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Invalidate() {
        UIKit.Object.NativeMethods.efl_invalidate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Thaw events of object.
    /// Allows event callbacks to be called again for this object after a call to <see cref="UIKit.Object.FreezeEvent"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void ThawEvent() {
        UIKit.Object.NativeMethods.efl_event_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Freeze events of this object.
    /// Prevents event callbacks from being called for this object. Enable events again using <see cref="UIKit.Object.ThawEvent"/>. Events marked <c>hot</c> cannot be stopped.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void FreezeEvent() {
        UIKit.Object.NativeMethods.efl_event_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Globally thaw events for ALL EFL OBJECTS.
    /// Allows event callbacks to be called for all EFL objects after they have been disabled by <see cref="UIKit.Object.FreezeEventGlobal"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static void ThawEventGlobal() {
        UIKit.Object.NativeMethods.efl_event_global_thaw_ptr.Value.Delegate();
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Globally freeze events for ALL EFL OBJECTS.
    /// Prevents event callbacks from being called for all EFL objects. Enable events again using <see cref="UIKit.Object.ThawEventGlobal"/>. Events marked <c>hot</c> cannot be stopped.
    /// 
    /// Note: USE WITH CAUTION.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static void FreezeEventGlobal() {
        UIKit.Object.NativeMethods.efl_event_global_freeze_ptr.Value.Delegate();
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Stop the current callback call.
    /// This stops the current callback call. Any other callbacks for the current event will not be called. This is useful when you want to filter out events. Just add higher priority events and call this under certain conditions to block a certain event.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void EventCallbackStop() {
        UIKit.Object.NativeMethods.efl_event_callback_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Remove an event callback forwarder for a specified event and object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="desc">The description of the event to listen to</param>
    /// <param name="new_obj">The object to emit events from</param>
    public virtual void DelEventCallbackForwarder(UIKit.EventDescription desc, UIKit.Object new_obj) {
        var _in_desc = UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(desc);
UIKit.Object.NativeMethods.efl_event_callback_forwarder_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_desc, new_obj);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Get an iterator on all children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Children iterator</returns>
    public virtual UIKit.DataTypes.Iterator<UIKit.Object> NewChildrenIterator() {
        var _ret_var = UIKit.Object.NativeMethods.efl_children_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return new UIKit.DataTypes.Iterator<UIKit.Object>(_ret_var, true);

    }

    /// <summary>Will register a manager of a specific class to be answered by <see cref="UIKit.Object.FindProvider"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class provided by the registered provider.</param>
    /// <param name="provider">The provider for the newly registered class that has to provide that said UIKit.Class.</param>
    /// <returns><c>true</c> if successfully register, <c>false</c> otherwise.</returns>
    public virtual bool RegisterProvider(Type klass, UIKit.Object provider) {
        var _ret_var = UIKit.Object.NativeMethods.efl_provider_register_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass, provider);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Will unregister a manager of a specific class that was previously registered and answered by <see cref="UIKit.Object.FindProvider"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class provided by the provider to unregister for.</param>
    /// <param name="provider">The provider for the registered class to unregister.</param>
    /// <returns><c>true</c> if successfully unregistered, <c>false</c> otherwise.</returns>
    public virtual bool UnregisterProvider(Type klass, UIKit.Object provider) {
        var _ret_var = UIKit.Object.NativeMethods.efl_provider_unregister_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass, provider);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The parent of an object.
    /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
    /// 
    /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
    /// 
    /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The new parent.</value>
    public UIKit.Object Parent {
        get { return GetParent(); }
        set { SetParent(value); }
    }

    /// <summary>The name of the object.
    /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The name.</value>
    public System.String Name {
        get { return GetName(); }
        set { SetName(value); }
    }

    /// <summary>A human readable comment for the object.
    /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The comment.</value>
    public System.String Comment {
        get { return GetComment(); }
        set { SetComment(value); }
    }

    /// <summary>Return the global count of freeze events.
    /// This is the amount of calls to <see cref="UIKit.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="UIKit.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The global event freeze count.</value>
    public static int EventGlobalFreezeCount {
        get { return GetEventGlobalFreezeCount(); }
    }

    /// <summary>Return the count of freeze events for this object.
    /// This is the amount of calls to <see cref="UIKit.Object.FreezeEvent"/> minus the amount of calls to <see cref="UIKit.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The event freeze count of this object.</value>
    public int EventFreezeCount {
        get { return GetEventFreezeCount(); }
    }

    /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the object is finalized, <c>false</c> otherwise.</value>
    public bool Finalized {
        get { return GetFinalized(); }
    }

    /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the object is invalidated, <c>false</c> otherwise.</value>
    public bool Invalidated {
        get { return GetInvalidated(); }
    }

    /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="UIKit.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the object is invalidating, <c>false</c> otherwise.</value>
    public bool Invalidating {
        get { return GetInvalidating(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Object.efl_object_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Wrapper.ObjectWrapper.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Eo);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_parent_get_static_delegate == null)
            {
                efl_parent_get_static_delegate = new efl_parent_get_delegate(parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetParent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_get_static_delegate) });
            }

            if (efl_parent_set_static_delegate == null)
            {
                efl_parent_set_static_delegate = new efl_parent_set_delegate(parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetParent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_set_static_delegate) });
            }

            if (efl_name_get_static_delegate == null)
            {
                efl_name_get_static_delegate = new efl_name_get_delegate(name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetName") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_name_get_static_delegate) });
            }

            if (efl_name_set_static_delegate == null)
            {
                efl_name_set_static_delegate = new efl_name_set_delegate(name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetName") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_name_set_static_delegate) });
            }

            if (efl_comment_get_static_delegate == null)
            {
                efl_comment_get_static_delegate = new efl_comment_get_delegate(comment_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetComment") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_get_static_delegate) });
            }

            if (efl_comment_set_static_delegate == null)
            {
                efl_comment_set_static_delegate = new efl_comment_set_delegate(comment_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetComment") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_set"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_set_static_delegate) });
            }

            if (efl_event_freeze_count_get_static_delegate == null)
            {
                efl_event_freeze_count_get_static_delegate = new efl_event_freeze_count_get_delegate(event_freeze_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEventFreezeCount") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_count_get_static_delegate) });
            }

            if (efl_finalized_get_static_delegate == null)
            {
                efl_finalized_get_static_delegate = new efl_finalized_get_delegate(finalized_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFinalized") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_finalized_get_static_delegate) });
            }

            if (efl_invalidated_get_static_delegate == null)
            {
                efl_invalidated_get_static_delegate = new efl_invalidated_get_delegate(invalidated_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInvalidated") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidated_get_static_delegate) });
            }

            if (efl_invalidating_get_static_delegate == null)
            {
                efl_invalidating_get_static_delegate = new efl_invalidating_get_delegate(invalidating_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInvalidating") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidating_get_static_delegate) });
            }

            if (efl_debug_name_override_static_delegate == null)
            {
                efl_debug_name_override_static_delegate = new efl_debug_name_override_delegate(debug_name_override);
            }

            if (methods.FirstOrDefault(m => m.Name == "DebugNameOverride") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_debug_name_override"), func = Marshal.GetFunctionPointerForDelegate(efl_debug_name_override_static_delegate) });
            }

            if (efl_provider_find_static_delegate == null)
            {
                efl_provider_find_static_delegate = new efl_provider_find_delegate(provider_find);
            }

            if (methods.FirstOrDefault(m => m.Name == "FindProvider") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_find"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_find_static_delegate) });
            }

            if (efl_destructor_static_delegate == null)
            {
                efl_destructor_static_delegate = new efl_destructor_delegate(destructor);
            }

            if (methods.FirstOrDefault(m => m.Name == "Destructor") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_destructor"), func = Marshal.GetFunctionPointerForDelegate(efl_destructor_static_delegate) });
            }

            if (efl_finalize_static_delegate == null)
            {
                efl_finalize_static_delegate = new efl_finalize_delegate(finalize);
            }

            if (methods.FirstOrDefault(m => m.Name == "FinalizeAdd") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalize"), func = Marshal.GetFunctionPointerForDelegate(efl_finalize_static_delegate) });
            }

            if (efl_invalidate_static_delegate == null)
            {
                efl_invalidate_static_delegate = new efl_invalidate_delegate(invalidate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Invalidate") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidate"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidate_static_delegate) });
            }

            if (efl_event_thaw_static_delegate == null)
            {
                efl_event_thaw_static_delegate = new efl_event_thaw_delegate(event_thaw);
            }

            if (methods.FirstOrDefault(m => m.Name == "ThawEvent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_event_thaw_static_delegate) });
            }

            if (efl_event_freeze_static_delegate == null)
            {
                efl_event_freeze_static_delegate = new efl_event_freeze_delegate(event_freeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "FreezeEvent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_static_delegate) });
            }

            if (efl_event_callback_stop_static_delegate == null)
            {
                efl_event_callback_stop_static_delegate = new efl_event_callback_stop_delegate(event_callback_stop);
            }

            if (methods.FirstOrDefault(m => m.Name == "EventCallbackStop") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_callback_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_stop_static_delegate) });
            }

            if (efl_event_callback_forwarder_del_static_delegate == null)
            {
                efl_event_callback_forwarder_del_static_delegate = new efl_event_callback_forwarder_del_delegate(event_callback_forwarder_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelEventCallbackForwarder") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_callback_forwarder_del"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_forwarder_del_static_delegate) });
            }

            if (efl_children_iterator_new_static_delegate == null)
            {
                efl_children_iterator_new_static_delegate = new efl_children_iterator_new_delegate(children_iterator_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewChildrenIterator") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_children_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_children_iterator_new_static_delegate) });
            }

            if (efl_provider_register_static_delegate == null)
            {
                efl_provider_register_static_delegate = new efl_provider_register_delegate(provider_register);
            }

            if (methods.FirstOrDefault(m => m.Name == "RegisterProvider") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_register"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_register_static_delegate) });
            }

            if (efl_provider_unregister_static_delegate == null)
            {
                efl_provider_unregister_static_delegate = new efl_provider_unregister_delegate(provider_unregister);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnregisterProvider") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_unregister_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.Object.efl_object_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Object efl_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Object efl_parent_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_parent_get_api_delegate> efl_parent_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_parent_get_api_delegate>(Module, "efl_parent_get");

        private static UIKit.Object parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_parent_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Object _ret_var = default(UIKit.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).GetParent();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_parent_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_parent_get_delegate efl_parent_get_static_delegate;

        
        private delegate void efl_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object parent);

        
        public delegate void efl_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object parent);

        public static UIKit.Wrapper.FunctionWrapper<efl_parent_set_api_delegate> efl_parent_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_parent_set_api_delegate>(Module, "efl_parent_set");

        private static void parent_set(System.IntPtr obj, System.IntPtr pd, UIKit.Object parent)
        {
            UIKit.DataTypes.Log.Debug("function efl_parent_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetParent(parent);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_parent_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_parent_set_delegate efl_parent_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_name_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_name_get_api_delegate> efl_name_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_name_get_api_delegate>(Module, "efl_name_get");

        private static System.String name_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_name_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Object)ws.Target).GetName();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_name_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_name_get_delegate efl_name_get_static_delegate;

        
        private delegate void efl_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

        public static UIKit.Wrapper.FunctionWrapper<efl_name_set_api_delegate> efl_name_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_name_set_api_delegate>(Module, "efl_name_set");

        private static void name_set(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            UIKit.DataTypes.Log.Debug("function efl_name_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetName(name);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_name_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_name_set_delegate efl_name_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_comment_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_comment_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_comment_get_api_delegate> efl_comment_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_comment_get_api_delegate>(Module, "efl_comment_get");

        private static System.String comment_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_comment_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Object)ws.Target).GetComment();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_comment_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_comment_get_delegate efl_comment_get_static_delegate;

        
        private delegate void efl_comment_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String comment);

        
        public delegate void efl_comment_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String comment);

        public static UIKit.Wrapper.FunctionWrapper<efl_comment_set_api_delegate> efl_comment_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_comment_set_api_delegate>(Module, "efl_comment_set");

        private static void comment_set(System.IntPtr obj, System.IntPtr pd, System.String comment)
        {
            UIKit.DataTypes.Log.Debug("function efl_comment_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetComment(comment);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_comment_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), comment);
            }
        }

        private static efl_comment_set_delegate efl_comment_set_static_delegate;

        
        private delegate int efl_event_global_freeze_count_get_delegate();

        
        public delegate int efl_event_global_freeze_count_get_api_delegate();

        public static UIKit.Wrapper.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate> efl_event_global_freeze_count_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate>(Module, "efl_event_global_freeze_count_get");

        private static int event_global_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_global_freeze_count_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = Object.GetEventGlobalFreezeCount();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
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

        public static UIKit.Wrapper.FunctionWrapper<efl_event_freeze_count_get_api_delegate> efl_event_freeze_count_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_freeze_count_get_api_delegate>(Module, "efl_event_freeze_count_get");

        private static int event_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_freeze_count_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Object)ws.Target).GetEventFreezeCount();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_event_freeze_count_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_freeze_count_get_delegate efl_event_freeze_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_finalized_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_finalized_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_finalized_get_api_delegate> efl_finalized_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_finalized_get_api_delegate>(Module, "efl_finalized_get");

        private static bool finalized_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_finalized_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetFinalized();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_finalized_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_finalized_get_delegate efl_finalized_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_invalidated_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_invalidated_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_invalidated_get_api_delegate> efl_invalidated_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_invalidated_get_api_delegate>(Module, "efl_invalidated_get");

        private static bool invalidated_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_invalidated_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetInvalidated();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_invalidated_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidated_get_delegate efl_invalidated_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_invalidating_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_invalidating_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_invalidating_get_api_delegate> efl_invalidating_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_invalidating_get_api_delegate>(Module, "efl_invalidating_get");

        private static bool invalidating_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_invalidating_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetInvalidating();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_invalidating_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidating_get_delegate efl_invalidating_get_static_delegate;

        
        private delegate void efl_debug_name_override_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StrbufKeepOwnershipMarshaler))] UIKit.DataTypes.Strbuf sb);

        
        public delegate void efl_debug_name_override_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StrbufKeepOwnershipMarshaler))] UIKit.DataTypes.Strbuf sb);

        public static UIKit.Wrapper.FunctionWrapper<efl_debug_name_override_api_delegate> efl_debug_name_override_ptr = new UIKit.Wrapper.FunctionWrapper<efl_debug_name_override_api_delegate>(Module, "efl_debug_name_override");

        private static void debug_name_override(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Strbuf sb)
        {
            UIKit.DataTypes.Log.Debug("function efl_debug_name_override was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).DebugNameOverride(sb);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_debug_name_override_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sb);
            }
        }

        private static efl_debug_name_override_delegate efl_debug_name_override_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Object efl_provider_find_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Object efl_provider_find_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass);

        public static UIKit.Wrapper.FunctionWrapper<efl_provider_find_api_delegate> efl_provider_find_ptr = new UIKit.Wrapper.FunctionWrapper<efl_provider_find_api_delegate>(Module, "efl_provider_find");

        private static UIKit.Object provider_find(System.IntPtr obj, System.IntPtr pd, Type klass)
        {
            UIKit.DataTypes.Log.Debug("function efl_provider_find was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Object _ret_var = default(UIKit.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).FindProvider(klass);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_provider_find_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), klass);
            }
        }

        private static efl_provider_find_delegate efl_provider_find_static_delegate;

        
        private delegate void efl_destructor_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_destructor_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_destructor_api_delegate> efl_destructor_ptr = new UIKit.Wrapper.FunctionWrapper<efl_destructor_api_delegate>(Module, "efl_destructor");

        private static void destructor(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_destructor was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).Destructor();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_destructor_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_destructor_delegate efl_destructor_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Object efl_finalize_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Object efl_finalize_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_finalize_api_delegate> efl_finalize_ptr = new UIKit.Wrapper.FunctionWrapper<efl_finalize_api_delegate>(Module, "efl_finalize");

        private static UIKit.Object finalize(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_finalize was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Object _ret_var = default(UIKit.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).FinalizeAdd();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_finalize_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_finalize_delegate efl_finalize_static_delegate;

        
        private delegate void efl_invalidate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_invalidate_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_invalidate_api_delegate> efl_invalidate_ptr = new UIKit.Wrapper.FunctionWrapper<efl_invalidate_api_delegate>(Module, "efl_invalidate");

        private static void invalidate(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_invalidate was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).Invalidate();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_invalidate_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_invalidate_delegate efl_invalidate_static_delegate;

        
        private delegate void efl_event_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_thaw_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_event_thaw_api_delegate> efl_event_thaw_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_thaw_api_delegate>(Module, "efl_event_thaw");

        private static void event_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_thaw was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).ThawEvent();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_thaw_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_thaw_delegate efl_event_thaw_static_delegate;

        
        private delegate void efl_event_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_freeze_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_event_freeze_api_delegate> efl_event_freeze_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_freeze_api_delegate>(Module, "efl_event_freeze");

        private static void event_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_freeze was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).FreezeEvent();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_freeze_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_freeze_delegate efl_event_freeze_static_delegate;

        
        private delegate void efl_event_global_thaw_delegate();

        
        public delegate void efl_event_global_thaw_api_delegate();

        public static UIKit.Wrapper.FunctionWrapper<efl_event_global_thaw_api_delegate> efl_event_global_thaw_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_global_thaw_api_delegate>(Module, "efl_event_global_thaw");

        private static void event_global_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_global_thaw was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    Object.ThawEventGlobal();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_global_thaw_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_event_global_freeze_delegate();

        
        public delegate void efl_event_global_freeze_api_delegate();

        public static UIKit.Wrapper.FunctionWrapper<efl_event_global_freeze_api_delegate> efl_event_global_freeze_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_global_freeze_api_delegate>(Module, "efl_event_global_freeze");

        private static void event_global_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_global_freeze was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    Object.FreezeEventGlobal();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_global_freeze_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_event_callback_stop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_event_callback_stop_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_event_callback_stop_api_delegate> efl_event_callback_stop_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_callback_stop_api_delegate>(Module, "efl_event_callback_stop");

        private static void event_callback_stop(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_callback_stop was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).EventCallbackStop();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_callback_stop_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_event_callback_stop_delegate efl_event_callback_stop_static_delegate;

        
        private delegate void efl_event_callback_forwarder_del_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object new_obj);

        
        public delegate void efl_event_callback_forwarder_del_api_delegate(System.IntPtr obj,  System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object new_obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_event_callback_forwarder_del_api_delegate> efl_event_callback_forwarder_del_ptr = new UIKit.Wrapper.FunctionWrapper<efl_event_callback_forwarder_del_api_delegate>(Module, "efl_event_callback_forwarder_del");

        private static void event_callback_forwarder_del(System.IntPtr obj, System.IntPtr pd, System.IntPtr desc, UIKit.Object new_obj)
        {
            UIKit.DataTypes.Log.Debug("function efl_event_callback_forwarder_del was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_desc = UIKit.DataTypes.PrimitiveConversion.PointerToManaged<UIKit.EventDescription>(desc);

                try
                {
                    ((Object)ws.Target).DelEventCallbackForwarder(_in_desc, new_obj);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_event_callback_forwarder_del_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), desc, new_obj);
            }
        }

        private static efl_event_callback_forwarder_del_delegate efl_event_callback_forwarder_del_static_delegate;

        
        private delegate System.IntPtr efl_children_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_children_iterator_new_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_children_iterator_new_api_delegate> efl_children_iterator_new_ptr = new UIKit.Wrapper.FunctionWrapper<efl_children_iterator_new_api_delegate>(Module, "efl_children_iterator_new");

        private static System.IntPtr children_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_children_iterator_new was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Iterator<UIKit.Object> _ret_var = default(UIKit.DataTypes.Iterator<UIKit.Object>);
                try
                {
                    _ret_var = ((Object)ws.Target).NewChildrenIterator();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_children_iterator_new_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_children_iterator_new_delegate efl_children_iterator_new_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_provider_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object provider);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_provider_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object provider);

        public static UIKit.Wrapper.FunctionWrapper<efl_provider_register_api_delegate> efl_provider_register_ptr = new UIKit.Wrapper.FunctionWrapper<efl_provider_register_api_delegate>(Module, "efl_provider_register");

        private static bool provider_register(System.IntPtr obj, System.IntPtr pd, Type klass, UIKit.Object provider)
        {
            UIKit.DataTypes.Log.Debug("function efl_provider_register was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).RegisterProvider(klass, provider);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_provider_register_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), klass, provider);
            }
        }

        private static efl_provider_register_delegate efl_provider_register_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_provider_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object provider);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_provider_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalUIKitClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object provider);

        public static UIKit.Wrapper.FunctionWrapper<efl_provider_unregister_api_delegate> efl_provider_unregister_ptr = new UIKit.Wrapper.FunctionWrapper<efl_provider_unregister_api_delegate>(Module, "efl_provider_unregister");

        private static bool provider_unregister(System.IntPtr obj, System.IntPtr pd, Type klass, UIKit.Object provider)
        {
            UIKit.DataTypes.Log.Debug("function efl_provider_unregister was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).UnregisterProvider(klass, provider);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_provider_unregister_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), klass, provider);
            }
        }

        private static efl_provider_unregister_delegate efl_provider_unregister_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKitObject_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
