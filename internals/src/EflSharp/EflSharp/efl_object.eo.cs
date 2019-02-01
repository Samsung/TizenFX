#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
public struct CallbackPriority {
   private  short payload;
   public static implicit operator CallbackPriority( short x)
   {
      return new CallbackPriority{payload=x};
   }
   public static implicit operator  short(CallbackPriority x)
   {
      return x.payload;
   }
}
} 
namespace Efl { 
/// <summary>Abstract Efl object class</summary>
[ObjectNativeInherit]
public class Object :  Efl.Eo.IWrapper, IDisposable
{
   public static System.IntPtr klass = System.IntPtr.Zero;
   public static Efl.ObjectNativeInherit nativeInherit = new Efl.ObjectNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public virtual System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Object))
            return Efl.ObjectNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   protected EventHandlerList eventHandlers = new EventHandlerList();
   private static readonly object klassAllocLock = new object();
   protected bool inherited;
   protected  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public delegate void ConstructingMethod(Object obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] internal static extern System.IntPtr
      efl_object_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Object(Efl.Object parent = null, ConstructingMethod init_cb=null) : this("Object", efl_object_class_get(), typeof(Object), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   protected Object(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent)
   {
      inherited = ((object)this).GetType() != managed_type;
      IntPtr actual_klass = base_klass;
      if (inherited) {
         if (!Efl.Eo.Globals.klasses.ContainsKey(((object)this).GetType())) {
            lock (klassAllocLock) {
                  actual_klass = Efl.Eo.Globals.register_class(klass_name, base_klass, ((object)this).GetType());
                  if (actual_klass == System.IntPtr.Zero) {
                     throw new System.InvalidOperationException("Failed to initialize class 'Object'");
                  }
                  Efl.Eo.Globals.klasses[((object)this).GetType()] = actual_klass;
            }
         }
         else
            actual_klass = Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
      handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
      register_event_proxies();
   }
   protected void FinishInstantiation()
   {
      if (inherited) {
         Efl.Eo.Globals.data_set(this);
      }
      handle = Efl.Eo.Globals.instantiate_end(handle);
      Eina.Error.RaiseIfUnhandledException();
   }
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Object(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~Object()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   protected virtual void Dispose(bool disposing)
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
   public static Object static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Object(obj.NativeHandle);
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
   protected readonly object eventLock = new object();
   protected Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   protected bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
   protected bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
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
private static object DelEvtKey = new object();
   /// <summary>Object is being deleted.</summary>
   public event EventHandler DelEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_DEL";
            if (add_cpp_event_handler(key, this.evt_DelEvt_delegate)) {
               eventHandlers.AddHandler(DelEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_DEL";
            if (remove_cpp_event_handler(key, this.evt_DelEvt_delegate)) { 
               eventHandlers.RemoveHandler(DelEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DelEvt.</summary>
   public void On_DelEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DelEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DelEvt_delegate;
   private void on_DelEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DelEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object InvalidateEvtKey = new object();
   /// <summary>Object is being invalidated and loosing its parent.</summary>
   public event EventHandler InvalidateEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_INVALIDATE";
            if (add_cpp_event_handler(key, this.evt_InvalidateEvt_delegate)) {
               eventHandlers.AddHandler(InvalidateEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_INVALIDATE";
            if (remove_cpp_event_handler(key, this.evt_InvalidateEvt_delegate)) { 
               eventHandlers.RemoveHandler(InvalidateEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event InvalidateEvt.</summary>
   public void On_InvalidateEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[InvalidateEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_InvalidateEvt_delegate;
   private void on_InvalidateEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_InvalidateEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object NorefEvtKey = new object();
   /// <summary>Object has lost its last reference, only parent relationship is keeping it alive.</summary>
   public event EventHandler NorefEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_NOREF";
            if (add_cpp_event_handler(key, this.evt_NorefEvt_delegate)) {
               eventHandlers.AddHandler(NorefEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_NOREF";
            if (remove_cpp_event_handler(key, this.evt_NorefEvt_delegate)) { 
               eventHandlers.RemoveHandler(NorefEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event NorefEvt.</summary>
   public void On_NorefEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[NorefEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_NorefEvt_delegate;
   private void on_NorefEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_NorefEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DestructEvtKey = new object();
   /// <summary>Object has been fully destroyed. It can not be used beyond this point. This event should only serve to clean up any dangling pointer.</summary>
   public event EventHandler DestructEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_DESTRUCT";
            if (add_cpp_event_handler(key, this.evt_DestructEvt_delegate)) {
               eventHandlers.AddHandler(DestructEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_DESTRUCT";
            if (remove_cpp_event_handler(key, this.evt_DestructEvt_delegate)) { 
               eventHandlers.RemoveHandler(DestructEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DestructEvt.</summary>
   public void On_DestructEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DestructEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DestructEvt_delegate;
   private void on_DestructEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DestructEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected virtual void register_event_proxies()
   {
      evt_DelEvt_delegate = new Efl.EventCb(on_DelEvt_NativeCallback);
      evt_InvalidateEvt_delegate = new Efl.EventCb(on_InvalidateEvt_NativeCallback);
      evt_NorefEvt_delegate = new Efl.EventCb(on_NorefEvt_NativeCallback);
      evt_DestructEvt_delegate = new Efl.EventCb(on_DestructEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_parent_get(System.IntPtr obj);
   /// <summary>The parent of an object.
   /// Parents keep references to their children. In order to delete objects which have parents you need to set parent to NULL or use efl_del(). This will both delete &amp; unref the object).
   /// 
   /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
   /// 
   /// For example: If you have a widget that has a box internally and when you &apos;swallow&apos; a widget and the swallowed object ends up in the box, the parent should be the widget, not the box.</summary>
   /// <returns>The new parent</returns>
   virtual public Efl.Object GetParent() {
       var _ret_var = efl_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object parent);
   /// <summary>The parent of an object.
   /// Parents keep references to their children. In order to delete objects which have parents you need to set parent to NULL or use efl_del(). This will both delete &amp; unref the object).
   /// 
   /// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
   /// 
   /// For example: If you have a widget that has a box internally and when you &apos;swallow&apos; a widget and the swallowed object ends up in the box, the parent should be the widget, not the box.</summary>
   /// <param name="parent">The new parent</param>
   /// <returns></returns>
   virtual public  void SetParent( Efl.Object parent) {
                         efl_parent_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  parent);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_name_get(System.IntPtr obj);
   /// <summary>The name of the object.
   /// Every object can have a string name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a NULL string or no string for the name.</summary>
   /// <returns>The name</returns>
   virtual public  System.String GetName() {
       var _ret_var = efl_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>The name of the object.
   /// Every object can have a string name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a NULL string or no string for the name.</summary>
   /// <param name="name">The name</param>
   /// <returns></returns>
   virtual public  void SetName(  System.String name) {
                         efl_name_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_comment_get(System.IntPtr obj);
   /// <summary>A human readable comment for the object
   /// Every object can have a string comment. This is intended for developers and debugging. An empty string is considered the same as a NULL string or no string for the comment.</summary>
   /// <returns>The comment</returns>
   virtual public  System.String GetComment() {
       var _ret_var = efl_comment_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_comment_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String comment);
   /// <summary>A human readable comment for the object
   /// Every object can have a string comment. This is intended for developers and debugging. An empty string is considered the same as a NULL string or no string for the comment.</summary>
   /// <param name="comment">The comment</param>
   /// <returns></returns>
   virtual public  void SetComment(  System.String comment) {
                         efl_comment_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  comment);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  int efl_event_global_freeze_count_get(System.IntPtr obj);
   /// <summary>Return freeze events of object.
   /// Return event freeze count.</summary>
   /// <returns>The event freeze count of the object</returns>
   public static  int GetEventGlobalFreezeCount() {
       var _ret_var = efl_event_global_freeze_count_get(Efl.Object.efl_object_class_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  int efl_event_freeze_count_get(System.IntPtr obj);
   /// <summary>Return freeze events of object.
   /// Return event freeze count.</summary>
   /// <returns>The event freeze count of the object</returns>
   virtual public  int GetEventFreezeCount() {
       var _ret_var = efl_event_freeze_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_finalized_get(System.IntPtr obj);
   /// <summary>True if the object is already finalized, otherwise false.</summary>
   /// <returns><c>true</c> if the object is finalized, <c>false</c> otherwise</returns>
   virtual public bool GetFinalized() {
       var _ret_var = efl_finalized_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_invalidated_get(System.IntPtr obj);
   /// <summary>True if the object is already invalidated, otherwise false.</summary>
   /// <returns><c>true</c> if the object is invalidated, <c>false</c> otherwise</returns>
   virtual public bool GetInvalidated() {
       var _ret_var = efl_invalidated_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_invalidating_get(System.IntPtr obj);
   /// <summary>True if the object is about to be invalidated, and the invalidation of the children is already happening.
   /// Note this is true before the invalidate call on the object.</summary>
   /// <returns><c>true</c> if the object is invalidating, <c>false</c> otherwise</returns>
   virtual public bool GetInvalidating() {
       var _ret_var = efl_invalidating_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_allow_parent_unref_get(System.IntPtr obj);
   /// <summary>Allow an object to be deleted by unref even if it has a parent.
   /// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
   /// 
   /// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as <c>efl_unref</c>() is stealing the ref from the parent.
   /// 
   /// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.</summary>
   /// <returns>Whether to allow <c>efl_unref</c>() to zero even if <see cref="Efl.Object.Parent"/> is not <c>null</c>.</returns>
   virtual public bool GetAllowParentUnref() {
       var _ret_var = efl_allow_parent_unref_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_allow_parent_unref_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   /// <summary>Allow an object to be deleted by unref even if it has a parent.
   /// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
   /// 
   /// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as <c>efl_unref</c>() is stealing the ref from the parent.
   /// 
   /// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.</summary>
   /// <param name="allow">Whether to allow <c>efl_unref</c>() to zero even if <see cref="Efl.Object.Parent"/> is not <c>null</c>.</param>
   /// <returns></returns>
   virtual public  void SetAllowParentUnref( bool allow) {
                         efl_allow_parent_unref_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  allow);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_debug_name_override(System.IntPtr obj,   Eina.Strbuf sb);
   /// <summary>Build a read-only name for this object used for debugging.
   /// Multiple calls using efl_super() can be chained in order to build the entire debug name, from parent to child classes. In C the usual way to build the string is as follows:
   /// 
   /// efl_debug_name_override(efl_super(obj, MY_CLASS), sb); eina_strbuf_append_printf(sb, &quot;new_information&quot;);
   /// 
   /// Usually more debug information should be added to <c>sb</c> after calling the super function.
   /// 1.21</summary>
   /// <param name="sb">A string buffer, must not be <c>null</c>.</param>
   /// <returns></returns>
   virtual public  void DebugNameOverride( Eina.Strbuf sb) {
                         efl_debug_name_override((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sb);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_provider_find(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
   /// <summary>Searches upwards in the object tree for a provider which knows the given class/interface.
   /// The object from the provider will then be returned. The base implementation calls the provider_find function on the object parent, and returns its result. If no parent is present NULL is returned. Each implementation has to support this function by overriding it and returning itself if the interface matches the parameter. If this is not done the class cannot be found up in the object tree.</summary>
   /// <param name="klass">The class identifier to search for</param>
   /// <returns>Object from the provider list</returns>
   virtual public Efl.Object FindProvider( Efl.Class klass) {
                         var _ret_var = efl_provider_find((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  klass);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_constructor(System.IntPtr obj);
   /// <summary>Call the object&apos;s constructor.
   /// Should not be used with #eo_do. Only use it with #eo_do_super.</summary>
   /// <returns>The new object created, can be NULL if aborting</returns>
   virtual public Efl.Object Constructor() {
       var _ret_var = efl_constructor((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_destructor(System.IntPtr obj);
   /// <summary>Call the object&apos;s destructor.
   /// Should not be used with #efl_do. Only use it with #efl_do_super. Will be triggered once #invalidate and #noref have been triggered.</summary>
   /// <returns></returns>
   virtual public  void Destructor() {
       efl_destructor((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_finalize(System.IntPtr obj);
   /// <summary>Called at the end of efl_add. Should not be called, just overridden.</summary>
   /// <returns>The new object created, can be NULL if aborting</returns>
   virtual public Efl.Object FinalizeAdd() {
       var _ret_var = efl_finalize((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_invalidate(System.IntPtr obj);
   /// <summary>Called when parent reference is lost/set to <c>NULL</c> and switch the state of the object to invalidate.</summary>
   /// <returns></returns>
   virtual public  void Invalidate() {
       efl_invalidate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_noref(System.IntPtr obj);
   /// <summary>Triggered when no reference are keeping the object alive.
   /// The parent can be the last one keeping an object alive and so <c>noref</c> can happen before <c>invalidate</c> as it is only impacted by the ref/unref of the object.</summary>
   /// <returns></returns>
   virtual public  void Noref() {
       efl_noref((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_name_find(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String search);
   /// <summary>Find a child object with the given name and return it.
   /// The search string can be a glob (shell style, using *). It can also specify class name in the format of &quot;class:name&quot; where &quot;:&quot; separates class and name. Both class and name can be globs. If the class is specified but the name is empty like &quot;class:&quot; then the search will match any object of that class.</summary>
   /// <param name="search">The name search string</param>
   /// <returns>The first object found</returns>
   virtual public Efl.Object FindName(  System.String search) {
                         var _ret_var = efl_name_find((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  search);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_thaw(System.IntPtr obj);
   /// <summary>Thaw events of object.
   /// Allows event callbacks to be called for an object.</summary>
   /// <returns></returns>
   virtual public  void ThawEvent() {
       efl_event_thaw((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_freeze(System.IntPtr obj);
   /// <summary>Freeze events of object.
   /// Prevents event callbacks from being called for an object.</summary>
   /// <returns></returns>
   virtual public  void FreezeEvent() {
       efl_event_freeze((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_global_thaw(System.IntPtr obj);
   /// <summary>Thaw events of object.
   /// Allows event callbacks be called for an object.</summary>
   /// <returns></returns>
   public static  void ThawEventGlobal() {
       efl_event_global_thaw(Efl.Object.efl_object_class_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_global_freeze(System.IntPtr obj);
   /// <summary>Freeze events of object.
   /// Prevents event callbacks from being called for an object.</summary>
   /// <returns></returns>
   public static  void FreezeEventGlobal() {
       efl_event_global_freeze(Efl.Object.efl_object_class_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_callback_stop(System.IntPtr obj);
   /// <summary>Stop the current callback call.
   /// This stops the current callback call. Any other callbacks for the current event will not be called. This is useful when you want to filter out events. Just add higher priority events and call this under certain conditions to block a certain event.</summary>
   /// <returns></returns>
   virtual public  void EventCallbackStop() {
       efl_event_callback_stop((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  void efl_event_callback_forwarder_del(System.IntPtr obj,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object new_obj);
   /// <summary>Remove an event callback forwarder for a specified event and object.</summary>
   /// <param name="desc">The description of the event to listen to</param>
   /// <param name="new_obj">The object to emit events from</param>
   /// <returns></returns>
   virtual public  void DelEventCallbackForwarder( Efl.EventDescription desc,  Efl.Object new_obj) {
       var _in_desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(desc);
                                    efl_event_callback_forwarder_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_desc,  new_obj);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    protected static extern  System.IntPtr efl_children_iterator_new(System.IntPtr obj);
   /// <summary>Get an iterator on all childrens</summary>
   /// <returns>Children iterator</returns>
   virtual public Eina.Iterator<Efl.Object> NewChildrenIterator() {
       var _ret_var = efl_children_iterator_new((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Object>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_composite_attach(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
   /// <summary>Make an object a composite object of another.
   /// The class of comp_obj must be part of the extensions of the class of the parent. It isn&apos;t possible to attach more then 1 composite of the same class. This function also sets the parent of comp_obj to parent.
   /// 
   /// See <see cref="Efl.Object.CompositeDetach"/>, <see cref="Efl.Object.IsCompositePart"/>.</summary>
   /// <param name="comp_obj">the object that will be used to composite the parent.</param>
   /// <returns><c>true</c> if successful. <c>false</c> otherwise.</returns>
   virtual public bool AttachComposite( Efl.Object comp_obj) {
                         var _ret_var = efl_composite_attach((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  comp_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_composite_detach(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
   /// <summary>Detach a composite object from another object.
   /// This functions also sets the parent of comp_obj to <c>null</c>.
   /// 
   /// See <see cref="Efl.Object.AttachComposite"/>, <see cref="Efl.Object.IsCompositePart"/>.</summary>
   /// <param name="comp_obj">The object that will be removed from the parent.</param>
   /// <returns><c>true</c> if successful. <c>false</c> otherwise.</returns>
   virtual public bool CompositeDetach( Efl.Object comp_obj) {
                         var _ret_var = efl_composite_detach((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  comp_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_composite_part_is(System.IntPtr obj);
   /// <summary>Check if an object is part of a composite object.
   /// See <see cref="Efl.Object.AttachComposite"/>, <see cref="Efl.Object.IsCompositePart"/>.</summary>
   /// <returns><c>true</c> if it is. <c>false</c> otherwise.</returns>
   virtual public bool IsCompositePart() {
       var _ret_var = efl_composite_part_is((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The parent of an object.
/// Parents keep references to their children. In order to delete objects which have parents you need to set parent to NULL or use efl_del(). This will both delete &amp; unref the object).
/// 
/// The Eo parent is conceptually user set. That means that a parent should not be changed behind the scenes in an unexpected way.
/// 
/// For example: If you have a widget that has a box internally and when you &apos;swallow&apos; a widget and the swallowed object ends up in the box, the parent should be the widget, not the box.</summary>
   public Efl.Object Parent {
      get { return GetParent(); }
      set { SetParent( value); }
   }
   /// <summary>The name of the object.
/// Every object can have a string name. Names may not contain the following characters: / ? * [ ] !  : Using any of these in a name will result in undefined behavior later on. An empty string is considered the same as a NULL string or no string for the name.</summary>
   public  System.String Name {
      get { return GetName(); }
      set { SetName( value); }
   }
   /// <summary>A human readable comment for the object
/// Every object can have a string comment. This is intended for developers and debugging. An empty string is considered the same as a NULL string or no string for the comment.</summary>
   public  System.String Comment {
      get { return GetComment(); }
      set { SetComment( value); }
   }
   /// <summary>Return freeze events of object.
/// Return event freeze count.</summary>
   public static  int EventGlobalFreezeCount {
      get { return GetEventGlobalFreezeCount(); }
   }
   /// <summary>Return freeze events of object.
/// Return event freeze count.</summary>
   public  int EventFreezeCount {
      get { return GetEventFreezeCount(); }
   }
   /// <summary>True if the object is already finalized, otherwise false.</summary>
   public bool Finalized {
      get { return GetFinalized(); }
   }
   /// <summary>True if the object is already invalidated, otherwise false.</summary>
   public bool Invalidated {
      get { return GetInvalidated(); }
   }
   /// <summary>True if the object is about to be invalidated, and the invalidation of the children is already happening.
/// Note this is true before the invalidate call on the object.</summary>
   public bool Invalidating {
      get { return GetInvalidating(); }
   }
   /// <summary>Allow an object to be deleted by unref even if it has a parent.
/// This simply hides the error message warning that an object being destroyed still has a parent. This property is false by default.
/// 
/// In a normal object use case, when ownership of an object is given to a caller, said ownership should be released with efl_unref(). If the object has a parent, this will print error messages, as <c>efl_unref</c>() is stealing the ref from the parent.
/// 
/// Warning: Use this function very carefully, unless you&apos;re absolutely sure of what you are doing.</summary>
   public bool AllowParentUnref {
      get { return GetAllowParentUnref(); }
      set { SetAllowParentUnref( value); }
   }
}
public class ObjectNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_parent_get_static_delegate = new efl_parent_get_delegate(parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_get_static_delegate)});
      efl_parent_set_static_delegate = new efl_parent_set_delegate(parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_parent_set_static_delegate)});
      efl_name_get_static_delegate = new efl_name_get_delegate(name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_name_get_static_delegate)});
      efl_name_set_static_delegate = new efl_name_set_delegate(name_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_name_set_static_delegate)});
      efl_comment_get_static_delegate = new efl_comment_get_delegate(comment_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_comment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_get_static_delegate)});
      efl_comment_set_static_delegate = new efl_comment_set_delegate(comment_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_comment_set"), func = Marshal.GetFunctionPointerForDelegate(efl_comment_set_static_delegate)});
      efl_event_freeze_count_get_static_delegate = new efl_event_freeze_count_get_delegate(event_freeze_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_event_freeze_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_count_get_static_delegate)});
      efl_finalized_get_static_delegate = new efl_finalized_get_delegate(finalized_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_finalized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_finalized_get_static_delegate)});
      efl_invalidated_get_static_delegate = new efl_invalidated_get_delegate(invalidated_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_invalidated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidated_get_static_delegate)});
      efl_invalidating_get_static_delegate = new efl_invalidating_get_delegate(invalidating_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_invalidating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidating_get_static_delegate)});
      efl_allow_parent_unref_get_static_delegate = new efl_allow_parent_unref_get_delegate(allow_parent_unref_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_allow_parent_unref_get"), func = Marshal.GetFunctionPointerForDelegate(efl_allow_parent_unref_get_static_delegate)});
      efl_allow_parent_unref_set_static_delegate = new efl_allow_parent_unref_set_delegate(allow_parent_unref_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_allow_parent_unref_set"), func = Marshal.GetFunctionPointerForDelegate(efl_allow_parent_unref_set_static_delegate)});
      efl_debug_name_override_static_delegate = new efl_debug_name_override_delegate(debug_name_override);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_debug_name_override"), func = Marshal.GetFunctionPointerForDelegate(efl_debug_name_override_static_delegate)});
      efl_provider_find_static_delegate = new efl_provider_find_delegate(provider_find);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_provider_find"), func = Marshal.GetFunctionPointerForDelegate(efl_provider_find_static_delegate)});
      efl_constructor_static_delegate = new efl_constructor_delegate(constructor);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_constructor"), func = Marshal.GetFunctionPointerForDelegate(efl_constructor_static_delegate)});
      efl_destructor_static_delegate = new efl_destructor_delegate(destructor);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_destructor"), func = Marshal.GetFunctionPointerForDelegate(efl_destructor_static_delegate)});
      efl_finalize_static_delegate = new efl_finalize_delegate(finalize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_finalize"), func = Marshal.GetFunctionPointerForDelegate(efl_finalize_static_delegate)});
      efl_invalidate_static_delegate = new efl_invalidate_delegate(invalidate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_invalidate"), func = Marshal.GetFunctionPointerForDelegate(efl_invalidate_static_delegate)});
      efl_noref_static_delegate = new efl_noref_delegate(noref);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_noref"), func = Marshal.GetFunctionPointerForDelegate(efl_noref_static_delegate)});
      efl_name_find_static_delegate = new efl_name_find_delegate(name_find);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_name_find"), func = Marshal.GetFunctionPointerForDelegate(efl_name_find_static_delegate)});
      efl_event_thaw_static_delegate = new efl_event_thaw_delegate(event_thaw);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_event_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_event_thaw_static_delegate)});
      efl_event_freeze_static_delegate = new efl_event_freeze_delegate(event_freeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_event_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_event_freeze_static_delegate)});
      efl_event_callback_stop_static_delegate = new efl_event_callback_stop_delegate(event_callback_stop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_event_callback_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_stop_static_delegate)});
      efl_event_callback_forwarder_del_static_delegate = new efl_event_callback_forwarder_del_delegate(event_callback_forwarder_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_event_callback_forwarder_del"), func = Marshal.GetFunctionPointerForDelegate(efl_event_callback_forwarder_del_static_delegate)});
      efl_children_iterator_new_static_delegate = new efl_children_iterator_new_delegate(children_iterator_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_children_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_children_iterator_new_static_delegate)});
      efl_composite_attach_static_delegate = new efl_composite_attach_delegate(composite_attach);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_composite_attach"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_attach_static_delegate)});
      efl_composite_detach_static_delegate = new efl_composite_detach_delegate(composite_detach);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_composite_detach"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_detach_static_delegate)});
      efl_composite_part_is_static_delegate = new efl_composite_part_is_delegate(composite_part_is);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_composite_part_is"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_part_is_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Object.efl_object_class_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Object.efl_object_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_parent_get(System.IntPtr obj);
    private static Efl.Object parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Object)wrapper).GetParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_parent_get_delegate efl_parent_get_static_delegate;


    private delegate  void efl_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object parent);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object parent);
    private static  void parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object parent)
   {
      Eina.Log.Debug("function efl_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_parent_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private efl_parent_set_delegate efl_parent_set_static_delegate;


    private delegate  System.IntPtr efl_name_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  System.IntPtr efl_name_get(System.IntPtr obj);
    private static  System.IntPtr name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Object)wrapper).GetName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Object)wrapper).cached_strings, _ret_var);
      } else {
         return efl_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_name_get_delegate efl_name_get_static_delegate;


    private delegate  void efl_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static  void name_set(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_name_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetName( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_name_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_name_set_delegate efl_name_set_static_delegate;


    private delegate  System.IntPtr efl_comment_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  System.IntPtr efl_comment_get(System.IntPtr obj);
    private static  System.IntPtr comment_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_comment_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Object)wrapper).GetComment();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Object)wrapper).cached_strings, _ret_var);
      } else {
         return efl_comment_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_comment_get_delegate efl_comment_get_static_delegate;


    private delegate  void efl_comment_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String comment);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_comment_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String comment);
    private static  void comment_set(System.IntPtr obj, System.IntPtr pd,   System.String comment)
   {
      Eina.Log.Debug("function efl_comment_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetComment( comment);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_comment_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  comment);
      }
   }
   private efl_comment_set_delegate efl_comment_set_static_delegate;


    private delegate  int efl_event_freeze_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  int efl_event_freeze_count_get(System.IntPtr obj);
    private static  int event_freeze_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_event_freeze_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Object)wrapper).GetEventFreezeCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_event_freeze_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_event_freeze_count_get_delegate efl_event_freeze_count_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_finalized_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_finalized_get(System.IntPtr obj);
    private static bool finalized_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_finalized_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetFinalized();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_finalized_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_finalized_get_delegate efl_finalized_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_invalidated_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_invalidated_get(System.IntPtr obj);
    private static bool invalidated_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_invalidated_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetInvalidated();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_invalidated_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_invalidated_get_delegate efl_invalidated_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_invalidating_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_invalidating_get(System.IntPtr obj);
    private static bool invalidating_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_invalidating_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetInvalidating();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_invalidating_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_invalidating_get_delegate efl_invalidating_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_allow_parent_unref_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_allow_parent_unref_get(System.IntPtr obj);
    private static bool allow_parent_unref_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_allow_parent_unref_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetAllowParentUnref();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_allow_parent_unref_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_allow_parent_unref_get_delegate efl_allow_parent_unref_get_static_delegate;


    private delegate  void efl_allow_parent_unref_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_allow_parent_unref_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
    private static  void allow_parent_unref_set(System.IntPtr obj, System.IntPtr pd,  bool allow)
   {
      Eina.Log.Debug("function efl_allow_parent_unref_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetAllowParentUnref( allow);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_allow_parent_unref_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allow);
      }
   }
   private efl_allow_parent_unref_set_delegate efl_allow_parent_unref_set_static_delegate;


    private delegate  void efl_debug_name_override_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Strbuf sb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_debug_name_override(System.IntPtr obj,   Eina.Strbuf sb);
    private static  void debug_name_override(System.IntPtr obj, System.IntPtr pd,  Eina.Strbuf sb)
   {
      Eina.Log.Debug("function efl_debug_name_override was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).DebugNameOverride( sb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_debug_name_override(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sb);
      }
   }
   private efl_debug_name_override_delegate efl_debug_name_override_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_provider_find_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_provider_find(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Class, Efl.Eo.NonOwnTag>))]  Efl.Class klass);
    private static Efl.Object provider_find(System.IntPtr obj, System.IntPtr pd,  Efl.Class klass)
   {
      Eina.Log.Debug("function efl_provider_find was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Object)wrapper).FindProvider( klass);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_provider_find(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass);
      }
   }
   private efl_provider_find_delegate efl_provider_find_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_constructor_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_constructor(System.IntPtr obj);
    private static Efl.Object constructor(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_constructor was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Object)wrapper).Constructor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_constructor(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_constructor_delegate efl_constructor_static_delegate;


    private delegate  void efl_destructor_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_destructor(System.IntPtr obj);
    private static  void destructor(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_destructor was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).Destructor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_destructor(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_destructor_delegate efl_destructor_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_finalize_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_finalize(System.IntPtr obj);
    private static Efl.Object finalize(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_finalize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Object)wrapper).FinalizeAdd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_finalize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_finalize_delegate efl_finalize_static_delegate;


    private delegate  void efl_invalidate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_invalidate(System.IntPtr obj);
    private static  void invalidate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_invalidate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).Invalidate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_invalidate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_invalidate_delegate efl_invalidate_static_delegate;


    private delegate  void efl_noref_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_noref(System.IntPtr obj);
    private static  void noref(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_noref was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).Noref();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_noref(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_noref_delegate efl_noref_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_name_find_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String search);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_name_find(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String search);
    private static Efl.Object name_find(System.IntPtr obj, System.IntPtr pd,   System.String search)
   {
      Eina.Log.Debug("function efl_name_find was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Object)wrapper).FindName( search);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_name_find(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  search);
      }
   }
   private efl_name_find_delegate efl_name_find_static_delegate;


    private delegate  void efl_event_thaw_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_event_thaw(System.IntPtr obj);
    private static  void event_thaw(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_event_thaw was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).ThawEvent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_event_thaw(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_event_thaw_delegate efl_event_thaw_static_delegate;


    private delegate  void efl_event_freeze_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_event_freeze(System.IntPtr obj);
    private static  void event_freeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_event_freeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).FreezeEvent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_event_freeze(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_event_freeze_delegate efl_event_freeze_static_delegate;


    private delegate  void efl_event_callback_stop_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_event_callback_stop(System.IntPtr obj);
    private static  void event_callback_stop(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_event_callback_stop was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).EventCallbackStop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_event_callback_stop(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_event_callback_stop_delegate efl_event_callback_stop_static_delegate;


    private delegate  void efl_event_callback_forwarder_del_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object new_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  void efl_event_callback_forwarder_del(System.IntPtr obj,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object new_obj);
    private static  void event_callback_forwarder_del(System.IntPtr obj, System.IntPtr pd,   System.IntPtr desc,  Efl.Object new_obj)
   {
      Eina.Log.Debug("function efl_event_callback_forwarder_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(desc);
                                       
         try {
            ((Object)wrapper).DelEventCallbackForwarder( _in_desc,  new_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_event_callback_forwarder_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  desc,  new_obj);
      }
   }
   private efl_event_callback_forwarder_del_delegate efl_event_callback_forwarder_del_static_delegate;


    private delegate  System.IntPtr efl_children_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  private static extern  System.IntPtr efl_children_iterator_new(System.IntPtr obj);
    private static  System.IntPtr children_iterator_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_children_iterator_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Object> _ret_var = default(Eina.Iterator<Efl.Object>);
         try {
            _ret_var = ((Object)wrapper).NewChildrenIterator();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_children_iterator_new(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_children_iterator_new_delegate efl_children_iterator_new_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_composite_attach_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_composite_attach(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
    private static bool composite_attach(System.IntPtr obj, System.IntPtr pd,  Efl.Object comp_obj)
   {
      Eina.Log.Debug("function efl_composite_attach was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).AttachComposite( comp_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_composite_attach(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  comp_obj);
      }
   }
   private efl_composite_attach_delegate efl_composite_attach_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_composite_detach_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_composite_detach(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object comp_obj);
    private static bool composite_detach(System.IntPtr obj, System.IntPtr pd,  Efl.Object comp_obj)
   {
      Eina.Log.Debug("function efl_composite_detach was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).CompositeDetach( comp_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_composite_detach(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  comp_obj);
      }
   }
   private efl_composite_detach_delegate efl_composite_detach_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_composite_part_is_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_composite_part_is(System.IntPtr obj);
    private static bool composite_part_is(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_composite_part_is was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).IsCompositePart();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_composite_part_is(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_composite_part_is_delegate efl_composite_part_is_static_delegate;
}
} 
namespace Efl { 
/// <summary>A parameter passed in event callbacks holding extra event parameters.
/// This is the full event information passed to callbacks in C.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Event
{
   /// <summary>The object the callback was called on.</summary>
   public Efl.Object Object;
   /// <summary>The event description.</summary>
   public Efl.EventDescription Desc;
   /// <summary>Extra event information passed by the event caller</summary>
   public  System.IntPtr Info;
   ///<summary>Constructor for Event.</summary>
   public Event(
      Efl.Object Object=default(Efl.Object),
      Efl.EventDescription Desc=default(Efl.EventDescription),
       System.IntPtr Info=default( System.IntPtr)   )
   {
      this.Object = Object;
      this.Desc = Desc;
      this.Info = Info;
   }
public static implicit operator Event(IntPtr ptr)
   {
      var tmp = (Event_StructInternal)Marshal.PtrToStructure(ptr, typeof(Event_StructInternal));
      return Event_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Event.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Event_StructInternal
{
///<summary>Internal wrapper for field Object</summary>
public System.IntPtr Object;
   
   public  System.IntPtr Desc;
   
   public  System.IntPtr Info;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Event(Event_StructInternal struct_)
   {
      return Event_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Event_StructInternal(Event struct_)
   {
      return Event_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Event</summary>
public static class Event_StructConversion
{
   internal static Event_StructInternal ToInternal(Event _external_struct)
   {
      var _internal_struct = new Event_StructInternal();

      _internal_struct.Object = _external_struct.Object.NativeHandle;
      _internal_struct.Desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(_external_struct.Desc);
      _internal_struct.Info = _external_struct.Info;

      return _internal_struct;
   }

   internal static Event ToManaged(Event_StructInternal _internal_struct)
   {
      var _external_struct = new Event();


      _external_struct.Object = (Efl.Object) System.Activator.CreateInstance(typeof(Efl.Object), new System.Object[] {_internal_struct.Object});
      Efl.Eo.Globals.efl_ref(_internal_struct.Object);

      _external_struct.Desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(_internal_struct.Desc);
      _external_struct.Info = _internal_struct.Info;

      return _external_struct;
   }

}
} 
