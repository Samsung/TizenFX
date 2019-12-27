/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
/// <summary>Callback priority. Range is -32k - 32k. The lower the number, the higher the priority.
/// 
/// This is used to insert an event handler relative to the existing stack of sorted event handlers according to that priority. All event handlers always have a priority. If not specified <see cref="CoreUI.Constants.CallbackPriorityDefault"/> is to be assumed.
/// 
/// See <see cref="CoreUI.Constants.CallbackPriorityBefore"/> <see cref="CoreUI.Constants.CallbackPriorityDefault"/>  <see cref="CoreUI.Constants.CallbackPriorityAfter"/></summary>
/// <since_tizen> 6 </since_tizen>
public struct CallbackPriority : IEquatable<CallbackPriority>
{
    private short payload;

    /// <summary>Converts an instance of short to this struct.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator CallbackPriority(short value)
    {
        return new CallbackPriority{payload=value};
    }

    /// <summary>Converts an instance of this struct to short.
    /// </summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator short(CallbackPriority value)
    {
        return value.payload;
    }
    /// <summary>Converts an instance of short to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static CallbackPriority FromInt16(short value)
    {
        return value;
    }

    /// <summary>Converts an instance of this struct to short.</summary>
    /// <returns>The actual value the alias is wrapping.</returns>
    public short ToInt16()
    {
        return this;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode() => payload.GetHashCode();
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(CallbackPriority other) => payload == other.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is CallbackPriority) ? Equals((CallbackPriority)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(CallbackPriority lhs, CallbackPriority rhs)
        => lhs.payload == rhs.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(CallbackPriority lhs, CallbackPriority rhs)
        => lhs.payload != rhs.payload;
}
}

namespace CoreUI {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Slightly more prioritized than default.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly CoreUI.CallbackPriority CallbackPriorityBefore = -100;
}
}

namespace CoreUI {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Default priority.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly CoreUI.CallbackPriority CallbackPriorityDefault = 0;
}
}

namespace CoreUI {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Slightly less prioritized than default.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly CoreUI.CallbackPriority CallbackPriorityAfter = 100;
}
}

namespace CoreUI {
    /// <summary>Abstract EFL object class.
    /// 
    /// All EFL objects inherit from this class, which provides basic functionality like naming, debugging, hierarchy traversal, event emission and life cycle management.
    /// 
    /// Life Cycle Objects are created with efl_add() and mostly disposed of with efl_del(). As an optimization, efl_add() accepts a list of initialization functions which the programmer can use to further customize the object before it is fully constructed. Also, objects can have a parent which will keep them alive as long as the parent is alive, so the programmer does not need to keep track of references. (See the <see cref="CoreUI.Object.Parent"/> property for details). Due to the above characteristics, EFL objects undergo the following phases during their Life Cycle: - Construction: The CoreUI.Object.constructor method is called. Afterwards, any user-supplied initialization methods are called. - Finalization: The <see cref="CoreUI.Object.FinalizeAdd"/> method is called and <see cref="CoreUI.Object.GetFinalized"/> is set to <c>true</c> when it returns. Object is usable at this point. - Invalidation: The object has lost its parent. The <see cref="CoreUI.Object.Invalidate"/> method is called so all the object&apos;s relationships can be terminated. <see cref="CoreUI.Object.GetInvalidated"/> is set to <c>true</c>. - Destruction: The object has no parent and it can be destroyed. The <see cref="CoreUI.Object.Destructor"/> method is called, use it to return any resources the object might have gathered during its life.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Object.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract partial class Object : CoreUI.Wrapper.ObjectWrapper
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Object))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Eo)] internal static extern System.IntPtr
            efl_object_class_get();

        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Object(CoreUI.Object parent= null) : base(efl_object_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Object(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Object(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class ObjectRealized : Object
        {
            private ObjectRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Object(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Object has lost its last reference, only parent relationship is keeping it alive. Advanced usage.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Noref
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_EVENT_NOREF";
                AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_NOREF";
                RemoveNativeEventHandler(CoreUI.Libs.Eo, key, value);
            }
        }

        /// <summary>Method to raise event Noref.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnNoref()
        {
            CallNativeEventCallback(CoreUI.Libs.Eo, "_EFL_EVENT_NOREF", IntPtr.Zero, null);
        }

        /// <summary>Object has lost a reference and only one is left. It has just one owner now. Triggered whenever the refcount goes from two to one.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler OwnershipUnique
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_EVENT_OWNERSHIP_UNIQUE";
                AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_OWNERSHIP_UNIQUE";
                RemoveNativeEventHandler(CoreUI.Libs.Eo, key, value);
            }
        }

        /// <summary>Method to raise event OwnershipUnique.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnOwnershipUnique()
        {
            CallNativeEventCallback(CoreUI.Libs.Eo, "_EFL_EVENT_OWNERSHIP_UNIQUE", IntPtr.Zero, null);
        }

        /// <summary>Object has acquired a second reference. It has multiple owners now. Triggered whenever increasing the refcount from one to two, it will not trigger by further increasing the refcount beyond two.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler OwnershipShared
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_EVENT_OWNERSHIP_SHARED";
                AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_OWNERSHIP_SHARED";
                RemoveNativeEventHandler(CoreUI.Libs.Eo, key, value);
            }
        }

        /// <summary>Method to raise event OwnershipShared.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnOwnershipShared()
        {
            CallNativeEventCallback(CoreUI.Libs.Eo, "_EFL_EVENT_OWNERSHIP_SHARED", IntPtr.Zero, null);
        }

        /// <summary>Object has been fully destroyed. It can not be used beyond this point. This event should only serve to clean up any reference you keep to the object.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Destruct
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_EVENT_DESTRUCT";
                AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_DESTRUCT";
                RemoveNativeEventHandler(CoreUI.Libs.Eo, key, value);
            }
        }

        /// <summary>Method to raise event Destruct.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnDestruct()
        {
            CallNativeEventCallback(CoreUI.Libs.Eo, "_EFL_EVENT_DESTRUCT", IntPtr.Zero, null);
        }


        /// <summary>The parent of an object.
        /// 
        /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
        /// 
        /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
        /// 
        /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
        /// <returns>The new parent.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Object GetParent() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The parent of an object.
        /// 
        /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
        /// 
        /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
        /// 
        /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
        /// <param name="parent">The new parent.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetParent(CoreUI.Object parent) {
            CoreUI.Object.NativeMethods.efl_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), parent);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The name of the object.
        /// 
        /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
        /// <returns>The name.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetName() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The name of the object.
        /// 
        /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
        /// <param name="name">The name.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetName(System.String name) {
            CoreUI.Object.NativeMethods.efl_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A human readable comment for the object.
        /// 
        /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
        /// <returns>The comment.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetComment() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_comment_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A human readable comment for the object.
        /// 
        /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
        /// <param name="comment">The comment.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetComment(System.String comment) {
            CoreUI.Object.NativeMethods.efl_comment_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), comment);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Return the global count of freeze events.
        /// 
        /// This is the amount of calls to <see cref="CoreUI.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="CoreUI.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
        /// <returns>The global event freeze count.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static int GetEventGlobalFreezeCount() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_event_global_freeze_count_get_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Return the count of freeze events for this object.
        /// 
        /// This is the amount of calls to <see cref="CoreUI.Object.FreezeEvent"/> minus the amount of calls to <see cref="CoreUI.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
        /// <returns>The event freeze count of this object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetEventFreezeCount() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_event_freeze_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.</summary>
        /// <returns><c>true</c> if the object is finalized, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFinalized() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_finalized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.</summary>
        /// <returns><c>true</c> if the object is invalidated, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetInvalidated() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_invalidated_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="CoreUI.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.</summary>
        /// <returns><c>true</c> if the object is invalidating, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetInvalidating() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_invalidating_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Build a read-only name for this object used for debugging.
        /// 
        /// Multiple calls using efl_super() can be chained in order to build the entire debug name, from parent to child classes. In C the usual way to build the string is as follows:
        /// 
        /// efl_debug_name_override(efl_super(obj, MY_CLASS), sb); eina_strbuf_append_printf(sb, &quot;new_information&quot;);
        /// 
        /// Usually more debug information should be added to <c>sb</c> after calling the super function.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sb">A string buffer, must not be <c>null</c>.</param>
        public virtual void DebugNameOverride(CoreUI.DataTypes.Strbuf sb) {
            CoreUI.Object.NativeMethods.efl_debug_name_override_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sb);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Searches upwards in the object tree for a provider which knows the given class/interface.
        /// 
        /// The object from the provider will then be returned. The base implementation calls the provider_find function on the object parent, and returns its result. If no parent is present <c>NULL</c> is returned. Each implementation has to support this function by overriding it and returning itself if the interface matches the parameter. If this is not done the class cannot be found up in the object tree.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="klass">The class identifier to search for.</param>
        /// <returns>Object from the provider list.</returns>
        public virtual CoreUI.Object FindProvider(Type klass) {
            var _ret_var = CoreUI.Object.NativeMethods.efl_provider_find_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Implement this method to provide deinitialization code for your object if you need it.
        /// 
        /// Will be called once <see cref="CoreUI.Object.Invalidate"/> has returned. See the Life Cycle section in this class&apos; description.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Destructor() {
            CoreUI.Object.NativeMethods.efl_destructor_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Implement this method to finish the initialization of your object after all (if any) user-provided configuration methods have been executed.
        /// 
        /// Use this method to delay expensive operations until user configuration has finished, to avoid building the object in a &quot;default&quot; state in the constructor, just to have to throw it all away because a user configuration (a property being set, for example) requires a different state. This is the last call inside efl_add() and will set <see cref="CoreUI.Object.GetFinalized"/> to <c>true</c> once it returns. This is an optimization and implementing this method is optional if you already perform all your initialization in the CoreUI.Object.constructor method. See the Life Cycle section in this class&apos; description.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The new object. Return <c>NULL</c> to abort object creation.</returns>
        public virtual CoreUI.Object FinalizeAdd() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_finalize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Implement this method to perform special actions when your object loses its parent, if you need to.
        /// 
        /// It is called when the parent reference is lost or set to <c>NULL</c>. After this call returns, <see cref="CoreUI.Object.GetInvalidated"/> is set to <c>true</c>. This allows a simpler tear down of complex hierarchies, by performing object destruction in two steps, first all object relationships are broken and then the isolated objects are destroyed. Performing everything in the <see cref="CoreUI.Object.Destructor"/> can sometimes lead to deadlocks, but implementing this method is optional if this is not your case. When an object with a parent is destroyed, it first receives a call to <see cref="CoreUI.Object.Invalidate"/> and then to <see cref="CoreUI.Object.Destructor"/>. See the Life Cycle section in this class&apos; description.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Invalidate() {
            CoreUI.Object.NativeMethods.efl_invalidate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Thaw events of object.
        /// 
        /// Allows event callbacks to be called again for this object after a call to <see cref="CoreUI.Object.FreezeEvent"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ThawEvent() {
            CoreUI.Object.NativeMethods.efl_event_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Freeze events of this object.
        /// 
        /// Prevents event callbacks from being called for this object. Enable events again using <see cref="CoreUI.Object.ThawEvent"/>. Events marked <c>hot</c> cannot be stopped.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void FreezeEvent() {
            CoreUI.Object.NativeMethods.efl_event_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Globally thaw events for ALL EFL OBJECTS.
        /// 
        /// Allows event callbacks to be called for all EFL objects after they have been disabled by <see cref="CoreUI.Object.FreezeEventGlobal"/>. The amount of thaws must match the amount of freezes for events to be re-enabled.</summary>
        /// <since_tizen> 6 </since_tizen>
        public static void ThawEventGlobal() {
            CoreUI.Object.NativeMethods.efl_event_global_thaw_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Globally freeze events for ALL EFL OBJECTS.
        /// 
        /// Prevents event callbacks from being called for all EFL objects. Enable events again using <see cref="CoreUI.Object.ThawEventGlobal"/>. Events marked <c>hot</c> cannot be stopped.
        /// 
        /// <b>NOTE: </b>USE WITH CAUTION.</summary>
        /// <since_tizen> 6 </since_tizen>
        public static void FreezeEventGlobal() {
            CoreUI.Object.NativeMethods.efl_event_global_freeze_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Stop the current callback call.
        /// 
        /// This stops the current callback call. Any other callbacks for the current event will not be called. This is useful when you want to filter out events. Just add higher priority events and call this under certain conditions to block a certain event.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void EventCallbackStop() {
            CoreUI.Object.NativeMethods.efl_event_callback_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get an iterator on all children.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Children iterator</returns>
        public virtual IEnumerable<CoreUI.Object> NewChildrenIterator() {
            var _ret_var = CoreUI.Object.NativeMethods.efl_children_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Object>(_ret_var);
        }

        /// <summary>Will register a manager of a specific class to be answered by <see cref="CoreUI.Object.FindProvider"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="klass">The class provided by the registered provider.</param>
        /// <param name="provider">The provider for the newly registered class that has to provide that said CoreUI.Class.</param>
        /// <returns><c>true</c> if successfully register, <c>false</c> otherwise.</returns>
        public virtual bool RegisterProvider(Type klass, CoreUI.Object provider) {
            var _ret_var = CoreUI.Object.NativeMethods.efl_provider_register_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass, provider);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Will unregister a manager of a specific class that was previously registered and answered by <see cref="CoreUI.Object.FindProvider"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="klass">The class provided by the provider to unregister for.</param>
        /// <param name="provider">The provider for the registered class to unregister.</param>
        /// <returns><c>true</c> if successfully unregistered, <c>false</c> otherwise.</returns>
        public virtual bool UnregisterProvider(Type klass, CoreUI.Object provider) {
            var _ret_var = CoreUI.Object.NativeMethods.efl_provider_unregister_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass, provider);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The parent of an object.
        /// 
        /// Parents keep references to their children and will release these references when destroyed. In this way, objects can be assigned to a parent upon creation, tying their life cycle so the programmer does not need to worry about destroying the child object. In order to destroy an object before its parent, set the parent to <c>NULL</c> and use efl_unref(), or use efl_del() directly.
        /// 
        /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
        /// 
        /// For example: If you have a widget which can swallow objects into an internal box, the parent of the swallowed objects should be the widget, not the internal box. The user is not even aware of the existence of the internal box.</summary>
        /// <value>The new parent.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Object Parent {
            get { return GetParent(); }
            set { SetParent(value); }
        }

        /// <summary>The name of the object.
        /// 
        /// Every EFL object can have a name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a <c>NULL</c> string or no string for the name.</summary>
        /// <value>The name.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Name {
            get { return GetName(); }
            set { SetName(value); }
        }

        /// <summary>A human readable comment for the object.
        /// 
        /// Every EFL object can have a comment. This is intended for developers and debugging. An empty string is considered the same as a <c>NULL</c> string or no string for the comment.</summary>
        /// <value>The comment.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Comment {
            get { return GetComment(); }
            set { SetComment(value); }
        }

        /// <summary>Return the global count of freeze events.
        /// 
        /// This is the amount of calls to <see cref="CoreUI.Object.FreezeEventGlobal"/> minus the amount of calls to <see cref="CoreUI.Object.ThawEventGlobal"/>. EFL will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
        /// <value>The global event freeze count.</value>
        /// <since_tizen> 6 </since_tizen>
        public static int EventGlobalFreezeCount {
            get { return GetEventGlobalFreezeCount(); }
        }

        /// <summary>Return the count of freeze events for this object.
        /// 
        /// This is the amount of calls to <see cref="CoreUI.Object.FreezeEvent"/> minus the amount of calls to <see cref="CoreUI.Object.ThawEvent"/>. This object will not emit any event while this count is &gt; 0 (Except events marked <c>hot</c>).</summary>
        /// <value>The event freeze count of this object.</value>
        /// <since_tizen> 6 </since_tizen>
        public int EventFreezeCount {
            get { return GetEventFreezeCount(); }
        }

        /// <summary><c>true</c> if the object has been finalized, i.e. construction has finished. See the Life Cycle section in this class&apos; description.</summary>
        /// <value><c>true</c> if the object is finalized, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Finalized {
            get { return GetFinalized(); }
        }

        /// <summary><c>true</c> if the object has been invalidated, i.e. it has no parent. See the Life Cycle section in this class&apos; description.</summary>
        /// <value><c>true</c> if the object is invalidated, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Invalidated {
            get { return GetInvalidated(); }
        }

        /// <summary><c>true</c> if the object has started the invalidation phase, but has not finished it yet. Note: This might become <c>true</c> before <see cref="CoreUI.Object.Invalidate"/> is called. See the Life Cycle section in this class&apos; description.</summary>
        /// <value><c>true</c> if the object is invalidating, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Invalidating {
            get { return GetInvalidating(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Object.efl_object_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Eo);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_parent_get_static_delegate == null)
                {
                    efl_parent_get_static_delegate = new efl_parent_get_delegate(parent_get);
                }

                if (methods.Contains("GetParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_get_static_delegate) });
                }

                if (efl_parent_set_static_delegate == null)
                {
                    efl_parent_set_static_delegate = new efl_parent_set_delegate(parent_set);
                }

                if (methods.Contains("SetParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_set_static_delegate) });
                }

                if (efl_name_get_static_delegate == null)
                {
                    efl_name_get_static_delegate = new efl_name_get_delegate(name_get);
                }

                if (methods.Contains("GetName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_name_get_static_delegate) });
                }

                if (efl_name_set_static_delegate == null)
                {
                    efl_name_set_static_delegate = new efl_name_set_delegate(name_set);
                }

                if (methods.Contains("SetName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_name_set_static_delegate) });
                }

                if (efl_comment_get_static_delegate == null)
                {
                    efl_comment_get_static_delegate = new efl_comment_get_delegate(comment_get);
                }

                if (methods.Contains("GetComment"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_get_static_delegate) });
                }

                if (efl_comment_set_static_delegate == null)
                {
                    efl_comment_set_static_delegate = new efl_comment_set_delegate(comment_set);
                }

                if (methods.Contains("SetComment"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_comment_set"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_set_static_delegate) });
                }

                if (efl_event_freeze_count_get_static_delegate == null)
                {
                    efl_event_freeze_count_get_static_delegate = new efl_event_freeze_count_get_delegate(event_freeze_count_get);
                }

                if (methods.Contains("GetEventFreezeCount"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_count_get_static_delegate) });
                }

                if (efl_finalized_get_static_delegate == null)
                {
                    efl_finalized_get_static_delegate = new efl_finalized_get_delegate(finalized_get);
                }

                if (methods.Contains("GetFinalized"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_finalized_get_static_delegate) });
                }

                if (efl_invalidated_get_static_delegate == null)
                {
                    efl_invalidated_get_static_delegate = new efl_invalidated_get_delegate(invalidated_get);
                }

                if (methods.Contains("GetInvalidated"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidated_get_static_delegate) });
                }

                if (efl_invalidating_get_static_delegate == null)
                {
                    efl_invalidating_get_static_delegate = new efl_invalidating_get_delegate(invalidating_get);
                }

                if (methods.Contains("GetInvalidating"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidating_get_static_delegate) });
                }

                if (efl_debug_name_override_static_delegate == null)
                {
                    efl_debug_name_override_static_delegate = new efl_debug_name_override_delegate(debug_name_override);
                }

                if (methods.Contains("DebugNameOverride"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_debug_name_override"), func = Marshal.GetFunctionPointerForDelegate(efl_debug_name_override_static_delegate) });
                }

                if (efl_provider_find_static_delegate == null)
                {
                    efl_provider_find_static_delegate = new efl_provider_find_delegate(provider_find);
                }

                if (methods.Contains("FindProvider"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_find"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_find_static_delegate) });
                }

                if (efl_destructor_static_delegate == null)
                {
                    efl_destructor_static_delegate = new efl_destructor_delegate(destructor);
                }

                if (methods.Contains("Destructor"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_destructor"), func = Marshal.GetFunctionPointerForDelegate(efl_destructor_static_delegate) });
                }

                if (efl_finalize_static_delegate == null)
                {
                    efl_finalize_static_delegate = new efl_finalize_delegate(finalize);
                }

                if (methods.Contains("FinalizeAdd"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_finalize"), func = Marshal.GetFunctionPointerForDelegate(efl_finalize_static_delegate) });
                }

                if (efl_invalidate_static_delegate == null)
                {
                    efl_invalidate_static_delegate = new efl_invalidate_delegate(invalidate);
                }

                if (methods.Contains("Invalidate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_invalidate"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidate_static_delegate) });
                }

                if (efl_event_thaw_static_delegate == null)
                {
                    efl_event_thaw_static_delegate = new efl_event_thaw_delegate(event_thaw);
                }

                if (methods.Contains("ThawEvent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_event_thaw_static_delegate) });
                }

                if (efl_event_freeze_static_delegate == null)
                {
                    efl_event_freeze_static_delegate = new efl_event_freeze_delegate(event_freeze);
                }

                if (methods.Contains("FreezeEvent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_static_delegate) });
                }

                if (efl_event_callback_stop_static_delegate == null)
                {
                    efl_event_callback_stop_static_delegate = new efl_event_callback_stop_delegate(event_callback_stop);
                }

                if (methods.Contains("EventCallbackStop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_event_callback_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_stop_static_delegate) });
                }

                if (efl_children_iterator_new_static_delegate == null)
                {
                    efl_children_iterator_new_static_delegate = new efl_children_iterator_new_delegate(children_iterator_new);
                }

                if (methods.Contains("NewChildrenIterator"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_children_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_children_iterator_new_static_delegate) });
                }

                if (efl_provider_register_static_delegate == null)
                {
                    efl_provider_register_static_delegate = new efl_provider_register_delegate(provider_register);
                }

                if (methods.Contains("RegisterProvider"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_register"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_register_static_delegate) });
                }

                if (efl_provider_unregister_static_delegate == null)
                {
                    efl_provider_unregister_static_delegate = new efl_provider_unregister_delegate(provider_unregister);
                }

                if (methods.Contains("UnregisterProvider"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_provider_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_unregister_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.Object.efl_object_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_parent_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_parent_get_api_delegate> efl_parent_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_parent_get_api_delegate>(Module, "efl_parent_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object parent_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_parent_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetParent();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_parent_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_parent_get_delegate efl_parent_get_static_delegate;

            
            private delegate void efl_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object parent);

            
            internal delegate void efl_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object parent);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_parent_set_api_delegate> efl_parent_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_parent_set_api_delegate>(Module, "efl_parent_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void parent_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Object parent)
            {
                CoreUI.DataTypes.Log.Debug("function efl_parent_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetParent(parent);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_parent_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), parent);
                }
            }

            private static efl_parent_set_delegate efl_parent_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_name_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_name_get_api_delegate> efl_name_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_name_get_api_delegate>(Module, "efl_name_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String name_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_name_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetName();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_name_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_name_get_delegate efl_name_get_static_delegate;

            
            private delegate void efl_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            
            internal delegate void efl_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_name_set_api_delegate> efl_name_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_name_set_api_delegate>(Module, "efl_name_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void name_set(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_name_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetName(name);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_name_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_name_set_delegate efl_name_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_comment_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_comment_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_comment_get_api_delegate> efl_comment_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_comment_get_api_delegate>(Module, "efl_comment_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String comment_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_comment_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetComment();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_comment_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_comment_get_delegate efl_comment_get_static_delegate;

            
            private delegate void efl_comment_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String comment);

            
            internal delegate void efl_comment_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String comment);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_comment_set_api_delegate> efl_comment_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_comment_set_api_delegate>(Module, "efl_comment_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void comment_set(System.IntPtr obj, System.IntPtr pd, System.String comment)
            {
                CoreUI.DataTypes.Log.Debug("function efl_comment_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetComment(comment);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_comment_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), comment);
                }
            }

            private static efl_comment_set_delegate efl_comment_set_static_delegate;

            
            private delegate int efl_event_global_freeze_count_get_delegate();

            
            internal delegate int efl_event_global_freeze_count_get_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate> efl_event_global_freeze_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_global_freeze_count_get_api_delegate>(Module, "efl_event_global_freeze_count_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int event_global_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_global_freeze_count_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = Object.GetEventGlobalFreezeCount();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_event_global_freeze_count_get_ptr.Value.Delegate();
                }
            }

            
            private delegate int efl_event_freeze_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_event_freeze_count_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_freeze_count_get_api_delegate> efl_event_freeze_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_freeze_count_get_api_delegate>(Module, "efl_event_freeze_count_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int event_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_freeze_count_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetEventFreezeCount();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_event_freeze_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_event_freeze_count_get_delegate efl_event_freeze_count_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_finalized_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_finalized_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_finalized_get_api_delegate> efl_finalized_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_finalized_get_api_delegate>(Module, "efl_finalized_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool finalized_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_finalized_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetFinalized();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_finalized_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_finalized_get_delegate efl_finalized_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_invalidated_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_invalidated_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_invalidated_get_api_delegate> efl_invalidated_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_invalidated_get_api_delegate>(Module, "efl_invalidated_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool invalidated_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_invalidated_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetInvalidated();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_invalidated_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_invalidated_get_delegate efl_invalidated_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_invalidating_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_invalidating_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_invalidating_get_api_delegate> efl_invalidating_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_invalidating_get_api_delegate>(Module, "efl_invalidating_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool invalidating_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_invalidating_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetInvalidating();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_invalidating_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_invalidating_get_delegate efl_invalidating_get_static_delegate;

            
            private delegate void efl_debug_name_override_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf sb);

            
            internal delegate void efl_debug_name_override_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf sb);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_debug_name_override_api_delegate> efl_debug_name_override_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_debug_name_override_api_delegate>(Module, "efl_debug_name_override");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void debug_name_override(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Strbuf sb)
            {
                CoreUI.DataTypes.Log.Debug("function efl_debug_name_override was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).DebugNameOverride(sb);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_debug_name_override_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sb);
                }
            }

            private static efl_debug_name_override_delegate efl_debug_name_override_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_provider_find_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_provider_find_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_provider_find_api_delegate> efl_provider_find_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_provider_find_api_delegate>(Module, "efl_provider_find");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object provider_find(System.IntPtr obj, System.IntPtr pd, Type klass)
            {
                CoreUI.DataTypes.Log.Debug("function efl_provider_find was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((Object)ws.Target).FindProvider(klass);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_provider_find_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass);
                }
            }

            private static efl_provider_find_delegate efl_provider_find_static_delegate;

            
            private delegate void efl_destructor_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_destructor_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_destructor_api_delegate> efl_destructor_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_destructor_api_delegate>(Module, "efl_destructor");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void destructor(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_destructor was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).Destructor();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_destructor_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_destructor_delegate efl_destructor_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_finalize_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_finalize_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_finalize_api_delegate> efl_finalize_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_finalize_api_delegate>(Module, "efl_finalize");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object finalize(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_finalize was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((Object)ws.Target).FinalizeAdd();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_finalize_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_finalize_delegate efl_finalize_static_delegate;

            
            private delegate void efl_invalidate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_invalidate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_invalidate_api_delegate> efl_invalidate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_invalidate_api_delegate>(Module, "efl_invalidate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void invalidate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_invalidate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).Invalidate();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_invalidate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_invalidate_delegate efl_invalidate_static_delegate;

            
            private delegate void efl_event_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_event_thaw_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_thaw_api_delegate> efl_event_thaw_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_thaw_api_delegate>(Module, "efl_event_thaw");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void event_thaw(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_thaw was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).ThawEvent();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_event_thaw_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_event_thaw_delegate efl_event_thaw_static_delegate;

            
            private delegate void efl_event_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_event_freeze_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_freeze_api_delegate> efl_event_freeze_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_freeze_api_delegate>(Module, "efl_event_freeze");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void event_freeze(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_freeze was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).FreezeEvent();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_event_freeze_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_event_freeze_delegate efl_event_freeze_static_delegate;

            
            private delegate void efl_event_global_thaw_delegate();

            
            internal delegate void efl_event_global_thaw_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_global_thaw_api_delegate> efl_event_global_thaw_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_global_thaw_api_delegate>(Module, "efl_event_global_thaw");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void event_global_thaw(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_global_thaw was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        Object.ThawEventGlobal();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_event_global_thaw_ptr.Value.Delegate();
                }
            }

            
            private delegate void efl_event_global_freeze_delegate();

            
            internal delegate void efl_event_global_freeze_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_global_freeze_api_delegate> efl_event_global_freeze_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_global_freeze_api_delegate>(Module, "efl_event_global_freeze");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void event_global_freeze(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_global_freeze was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        Object.FreezeEventGlobal();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_event_global_freeze_ptr.Value.Delegate();
                }
            }

            
            private delegate void efl_event_callback_stop_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_event_callback_stop_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_event_callback_stop_api_delegate> efl_event_callback_stop_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_event_callback_stop_api_delegate>(Module, "efl_event_callback_stop");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void event_callback_stop(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_event_callback_stop was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).EventCallbackStop();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_event_callback_stop_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_event_callback_stop_delegate efl_event_callback_stop_static_delegate;

            
            private delegate System.IntPtr efl_children_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_children_iterator_new_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_children_iterator_new_api_delegate> efl_children_iterator_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_children_iterator_new_api_delegate>(Module, "efl_children_iterator_new");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr children_iterator_new(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_children_iterator_new was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.Object> _ret_var = null;
                    try
                    {
                        _ret_var = ((Object)ws.Target).NewChildrenIterator();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_children_iterator_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_children_iterator_new_delegate efl_children_iterator_new_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_provider_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object provider);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_provider_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object provider);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_provider_register_api_delegate> efl_provider_register_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_provider_register_api_delegate>(Module, "efl_provider_register");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool provider_register(System.IntPtr obj, System.IntPtr pd, Type klass, CoreUI.Object provider)
            {
                CoreUI.DataTypes.Log.Debug("function efl_provider_register was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).RegisterProvider(klass, provider);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_provider_register_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass, provider);
                }
            }

            private static efl_provider_register_delegate efl_provider_register_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_provider_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object provider);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_provider_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalCoreUIClass))] Type klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object provider);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_provider_unregister_api_delegate> efl_provider_unregister_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_provider_unregister_api_delegate>(Module, "efl_provider_unregister");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool provider_unregister(System.IntPtr obj, System.IntPtr pd, Type klass, CoreUI.Object provider)
            {
                CoreUI.DataTypes.Log.Debug("function efl_provider_unregister was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).UnregisterProvider(klass, provider);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_provider_unregister_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass, provider);
                }
            }

            private static efl_provider_unregister_delegate efl_provider_unregister_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ObjectExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Object> Parent<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Object, T>magic = null) where T : CoreUI.Object {
            return new CoreUI.BindableProperty<CoreUI.Object>("parent", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Name<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Object, T>magic = null) where T : CoreUI.Object {
            return new CoreUI.BindableProperty<System.String>("name", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Comment<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Object, T>magic = null) where T : CoreUI.Object {
            return new CoreUI.BindableProperty<System.String>("comment", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

