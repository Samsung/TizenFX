#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary></summary>
[ModelLoopNativeInherit]
public class ModelLoop : Efl.LoopConsumer, Efl.Eo.IWrapper,Efl.Model
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ModelLoopNativeInherit nativeInherit = new Efl.ModelLoopNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ModelLoop))
            return Efl.ModelLoopNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ModelLoop obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_model_loop_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ModelLoop(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ModelLoop", efl_model_loop_class_get(), typeof(ModelLoop), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ModelLoop(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ModelLoop(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ModelLoop static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ModelLoop(obj.NativeHandle);
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
private static object PropertiesChangedEvtKey = new object();
   /// <summary>Event dispatched when properties list is available.</summary>
   public event EventHandler<Efl.ModelPropertiesChangedEvt_Args> PropertiesChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
            if (add_cpp_event_handler(key, this.evt_PropertiesChangedEvt_delegate)) {
               eventHandlers.AddHandler(PropertiesChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PropertiesChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PropertiesChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PropertiesChangedEvt.</summary>
   public void On_PropertiesChangedEvt(Efl.ModelPropertiesChangedEvt_Args e)
   {
      EventHandler<Efl.ModelPropertiesChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ModelPropertiesChangedEvt_Args>)eventHandlers[PropertiesChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PropertiesChangedEvt_delegate;
   private void on_PropertiesChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ModelPropertiesChangedEvt_Args args = new Efl.ModelPropertiesChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_PropertiesChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildAddedEvtKey = new object();
   /// <summary>Event dispatched when new child is added.</summary>
   public event EventHandler<Efl.ModelChildAddedEvt_Args> ChildAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
            if (add_cpp_event_handler(key, this.evt_ChildAddedEvt_delegate)) {
               eventHandlers.AddHandler(ChildAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ChildAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildAddedEvt.</summary>
   public void On_ChildAddedEvt(Efl.ModelChildAddedEvt_Args e)
   {
      EventHandler<Efl.ModelChildAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ModelChildAddedEvt_Args>)eventHandlers[ChildAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildAddedEvt_delegate;
   private void on_ChildAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ModelChildAddedEvt_Args args = new Efl.ModelChildAddedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChildAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildRemovedEvtKey = new object();
   /// <summary>Event dispatched when child is removed.</summary>
   public event EventHandler<Efl.ModelChildRemovedEvt_Args> ChildRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
            if (add_cpp_event_handler(key, this.evt_ChildRemovedEvt_delegate)) {
               eventHandlers.AddHandler(ChildRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_ChildRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildRemovedEvt.</summary>
   public void On_ChildRemovedEvt(Efl.ModelChildRemovedEvt_Args e)
   {
      EventHandler<Efl.ModelChildRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ModelChildRemovedEvt_Args>)eventHandlers[ChildRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildRemovedEvt_delegate;
   private void on_ChildRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ModelChildRemovedEvt_Args args = new Efl.ModelChildRemovedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChildRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildrenCountChangedEvtKey = new object();
   /// <summary>Event dispatched when children count is finished.</summary>
   public event EventHandler ChildrenCountChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChildrenCountChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChildrenCountChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChildrenCountChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildrenCountChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildrenCountChangedEvt.</summary>
   public void On_ChildrenCountChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChildrenCountChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildrenCountChangedEvt_delegate;
   private void on_ChildrenCountChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChildrenCountChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PropertiesChangedEvt_delegate = new Efl.EventCb(on_PropertiesChangedEvt_NativeCallback);
      evt_ChildAddedEvt_delegate = new Efl.EventCb(on_ChildAddedEvt_NativeCallback);
      evt_ChildRemovedEvt_delegate = new Efl.EventCb(on_ChildRemovedEvt_NativeCallback);
      evt_ChildrenCountChangedEvt_delegate = new Efl.EventCb(on_ChildrenCountChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  System.IntPtr efl_model_properties_get(System.IntPtr obj);
   /// <summary>Get properties from model.
   /// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.Model.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
   /// 
   /// See also <see cref="Efl.Model.PropertiesChangedEvt"/>.
   /// 1.14</summary>
   /// <returns>Array of current properties</returns>
   virtual public Eina.Iterator< System.String> GetProperties() {
       var _ret_var = efl_model_properties_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator< System.String>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] protected static extern  Eina.Value efl_model_property_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Retrieve the value of a given property name.
   /// At this point the caller is free to get values from properties. The event <see cref="Efl.Model.PropertiesChangedEvt"/> may be raised to notify listeners of the property/value.
   /// 
   /// See <see cref="Efl.Model.GetProperties"/>, <see cref="Efl.Model.PropertiesChangedEvt"/>
   /// 1.14</summary>
   /// <param name="property">Property name</param>
   /// <returns>Property value</returns>
   virtual public  Eina.Value GetProperty(  System.String property) {
                         var _ret_var = efl_model_property_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  property);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_model_property_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]   Eina.Value value);
   /// <summary>Set a property value of a given property name.
   /// The caller must ensure to call at least efl_model_prop_list before being able to see/set properties. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="Efl.Model.PropertiesChangedEvt"/> event in order to notify listeners of the new value of the property.
   /// 
   /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
   /// 
   /// See <see cref="Efl.Model.GetProperty"/>, <see cref="Efl.Model.PropertiesChangedEvt"/>
   /// 1.14</summary>
   /// <param name="property">Property name</param>
   /// <param name="value">Property value</param>
   /// <returns>Return an error in case the property could not be set, the value that was set otherwise.</returns>
   virtual public  Eina.Future SetProperty(  System.String property,   Eina.Value value) {
                                           var _ret_var = efl_model_property_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  property,  value);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  uint efl_model_children_count_get(System.IntPtr obj);
   /// <summary>Get children count.
   /// When efl_model_load is completed <see cref="Efl.Model.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.Model.GetChildrenCount"/> can also be used before calling <see cref="Efl.Model.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.Model.ChildrenCountChangedEvt"/> is emitted when count is finished.
   /// 
   /// See also <see cref="Efl.Model.GetChildrenSlice"/>.
   /// 1.14</summary>
   /// <returns>Current known children count</returns>
   virtual public  uint GetChildrenCount() {
       var _ret_var = efl_model_children_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_model_property_ready_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   /// <summary>Get a future value when it changes to something that is not error:EAGAIN
   /// <see cref="Efl.Model.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disapears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
   /// 
   /// The future can also be canceled if the model itself gets destroyed.</summary>
   /// <param name="property"></param>
   /// <returns></returns>
   virtual public  Eina.Future GetPropertyReady(  System.String property) {
                         var _ret_var = efl_model_property_ready_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  property);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_model_children_slice_get(System.IntPtr obj,    uint start,    uint count);
   /// <summary>Get children slice OR full range.
   /// <see cref="Efl.Model.GetChildrenSlice"/> behaves in two different ways, it may provide the slice if <c>count</c> is non-zero OR full range otherwise.
   /// 
   /// Since &apos;slice&apos; is a range, for example if we have 20 children a slice could be the range from 3(start) with 4(count), see:
   /// 
   /// child 0  [no] child 1  [no] child 2  [no] child 3  [yes] child 4  [yes] child 5  [yes] child 6  [yes] child 7  [no]
   /// 
   /// Optionally the user can call <see cref="Efl.Model.GetChildrenCount"/> to know the number of children so a valid range can be known in advance.
   /// 
   /// See <see cref="Efl.Model.GetChildrenCount"/>
   /// 1.14</summary>
   /// <param name="start">Range begin - start from here.</param>
   /// <param name="count">Range size. If count is 0, start is ignored.</param>
   /// <returns>Array of children</returns>
   virtual public  Eina.Future GetChildrenSlice(  uint start,   uint count) {
                                           var _ret_var = efl_model_children_slice_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  start,  count);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_model_child_add(System.IntPtr obj);
   /// <summary>Add a new child.
   /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="Efl.Model.ChildAddedEvt"/> is then raised and the new child is kept along with other children.
   /// 1.14</summary>
   /// <returns>Child object</returns>
   virtual public Efl.Object AddChild() {
       var _ret_var = efl_model_child_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_model_child_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object child);
   /// <summary>Remove a child.
   /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="Efl.Model.ChildRemovedEvt"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.
   /// 1.14</summary>
   /// <param name="child">Child to be removed</param>
   /// <returns></returns>
   virtual public  void DelChild( Efl.Object child) {
                         efl_model_child_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child);
      Eina.Error.RaiseIfUnhandledException();
                   }
   public System.Threading.Tasks.Task<Eina.Value> SetPropertyAsync(  System.String property,  Eina.Value value, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = SetProperty(  property,  value);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   public System.Threading.Tasks.Task<Eina.Value> GetPropertyReadyAsync(  System.String property, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = GetPropertyReady(  property);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   public System.Threading.Tasks.Task<Eina.Value> GetChildrenSliceAsync(  uint start,  uint count, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = GetChildrenSlice(  start,  count);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>Get properties from model.
/// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.Model.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
/// 
/// See also <see cref="Efl.Model.PropertiesChangedEvt"/>.
/// 1.14</summary>
   public Eina.Iterator< System.String> Properties {
      get { return GetProperties(); }
   }
   /// <summary>Get children count.
/// When efl_model_load is completed <see cref="Efl.Model.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.Model.GetChildrenCount"/> can also be used before calling <see cref="Efl.Model.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.Model.ChildrenCountChangedEvt"/> is emitted when count is finished.
/// 
/// See also <see cref="Efl.Model.GetChildrenSlice"/>.
/// 1.14</summary>
   public  uint ChildrenCount {
      get { return GetChildrenCount(); }
   }
}
public class ModelLoopNativeInherit : Efl.LoopConsumerNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_model_properties_get_static_delegate = new efl_model_properties_get_delegate(properties_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_properties_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_properties_get_static_delegate)});
      efl_model_property_get_static_delegate = new efl_model_property_get_delegate(property_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_property_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_get_static_delegate)});
      efl_model_property_set_static_delegate = new efl_model_property_set_delegate(property_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_property_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_set_static_delegate)});
      efl_model_children_count_get_static_delegate = new efl_model_children_count_get_delegate(children_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_count_get_static_delegate)});
      efl_model_property_ready_get_static_delegate = new efl_model_property_ready_get_delegate(property_ready_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_property_ready_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_ready_get_static_delegate)});
      efl_model_children_slice_get_static_delegate = new efl_model_children_slice_get_delegate(children_slice_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_children_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_slice_get_static_delegate)});
      efl_model_child_add_static_delegate = new efl_model_child_add_delegate(child_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_child_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_add_static_delegate)});
      efl_model_child_del_static_delegate = new efl_model_child_del_delegate(child_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_model_child_del"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_del_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ModelLoop.efl_model_loop_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ModelLoop.efl_model_loop_class_get();
   }


    private delegate  System.IntPtr efl_model_properties_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_model_properties_get(System.IntPtr obj);
    private static  System.IntPtr properties_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_model_properties_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator< System.String> _ret_var = default(Eina.Iterator< System.String>);
         try {
            _ret_var = ((ModelLoop)wrapper).GetProperties();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_model_properties_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_model_properties_get_delegate efl_model_properties_get_static_delegate;


    private delegate  Eina.Value efl_model_property_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  Eina.Value efl_model_property_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    private static  Eina.Value property_get(System.IntPtr obj, System.IntPtr pd,   System.String property)
   {
      Eina.Log.Debug("function efl_model_property_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Value _ret_var = default( Eina.Value);
         try {
            _ret_var = ((ModelLoop)wrapper).GetProperty( property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_model_property_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  property);
      }
   }
   private efl_model_property_get_delegate efl_model_property_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_model_property_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,    Eina.Value value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_model_property_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property,    Eina.Value value);
    private static  Eina.Future property_set(System.IntPtr obj, System.IntPtr pd,   System.String property,   Eina.Value value)
   {
      Eina.Log.Debug("function efl_model_property_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((ModelLoop)wrapper).SetProperty( property,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_model_property_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  property,  value);
      }
   }
   private efl_model_property_set_delegate efl_model_property_set_static_delegate;


    private delegate  uint efl_model_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  uint efl_model_children_count_get(System.IntPtr obj);
    private static  uint children_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_model_children_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((ModelLoop)wrapper).GetChildrenCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_model_children_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_model_children_count_get_delegate efl_model_children_count_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_model_property_ready_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_model_property_ready_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String property);
    private static  Eina.Future property_ready_get(System.IntPtr obj, System.IntPtr pd,   System.String property)
   {
      Eina.Log.Debug("function efl_model_property_ready_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((ModelLoop)wrapper).GetPropertyReady( property);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_model_property_ready_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  property);
      }
   }
   private efl_model_property_ready_get_delegate efl_model_property_ready_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_model_children_slice_get_delegate(System.IntPtr obj, System.IntPtr pd,    uint start,    uint count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_model_children_slice_get(System.IntPtr obj,    uint start,    uint count);
    private static  Eina.Future children_slice_get(System.IntPtr obj, System.IntPtr pd,   uint start,   uint count)
   {
      Eina.Log.Debug("function efl_model_children_slice_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((ModelLoop)wrapper).GetChildrenSlice( start,  count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_model_children_slice_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  count);
      }
   }
   private efl_model_children_slice_get_delegate efl_model_children_slice_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_model_child_add_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_model_child_add(System.IntPtr obj);
    private static Efl.Object child_add(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_model_child_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((ModelLoop)wrapper).AddChild();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_model_child_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_model_child_add_delegate efl_model_child_add_static_delegate;


    private delegate  void efl_model_child_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object child);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_model_child_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object child);
    private static  void child_del(System.IntPtr obj, System.IntPtr pd,  Efl.Object child)
   {
      Eina.Log.Debug("function efl_model_child_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ModelLoop)wrapper).DelChild( child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_model_child_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child);
      }
   }
   private efl_model_child_del_delegate efl_model_child_del_static_delegate;
}
} 
