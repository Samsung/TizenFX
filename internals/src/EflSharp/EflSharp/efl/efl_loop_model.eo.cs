#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.LoopModel.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class LoopModel : Efl.LoopConsumer, Efl.IModel
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopModel))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopModel(Efl.Object parent= null
            ) : base(efl_loop_model_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected LoopModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LoopModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class LoopModelRealized : LoopModel
    {
        private LoopModelRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="LoopModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Event dispatched when properties list is available.</summary>
    /// <value><see cref="Efl.ModelPropertiesChangedEventArgs"/></value>
    public event EventHandler<Efl.ModelPropertiesChangedEventArgs> PropertiesChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.ModelPropertiesChangedEventArgs args = new Efl.ModelPropertiesChangedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event PropertiesChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPropertiesChangedEvent(Efl.ModelPropertiesChangedEventArgs e)
    {
        var key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Event dispatched when new child is added.</summary>
    /// <value><see cref="Efl.ModelChildAddedEventArgs"/></value>
    public event EventHandler<Efl.ModelChildAddedEventArgs> ChildAddedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.ModelChildAddedEventArgs args = new Efl.ModelChildAddedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ChildAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChildAddedEvent(Efl.ModelChildAddedEventArgs e)
    {
        var key = "_EFL_MODEL_EVENT_CHILD_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Event dispatched when child is removed.</summary>
    /// <value><see cref="Efl.ModelChildRemovedEventArgs"/></value>
    public event EventHandler<Efl.ModelChildRemovedEventArgs> ChildRemovedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.ModelChildRemovedEventArgs args = new Efl.ModelChildRemovedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ChildRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChildRemovedEvent(Efl.ModelChildRemovedEventArgs e)
    {
        var key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Event dispatched when children count is finished.</summary>
    public event EventHandler ChildrenCountChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
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

                string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event ChildrenCountChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChildrenCountChangedEvent(EventArgs e)
    {
        var key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>To be called when a Child model is created by <see cref="Efl.IModel.GetChildrenSlice"/> by the one creating the child object.
    /// This function is used to properly define the lifecycle of the new Child Model object and make sure that once it has 0 ref except its parent Model, it will be destroyed. This function should only be called once per child. It is useful for <see cref="Efl.IModel"/> who have a lot of children and shouldn&apos;t keep more than what is used in memory.</summary>
    public virtual void VolatileMake() {
         Efl.LoopModel.NativeMethods.efl_loop_model_volatile_make_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Get properties from model.
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="Efl.IModel.PropertiesChangedEvent"/>.</summary>
    /// <returns>Array of current properties</returns>
    public virtual Eina.Iterator<System.String> GetProperties() {
         var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_properties_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<System.String>(_ret_var, true);
 }
    /// <summary>Retrieve the value of a given property name.
    /// At this point the caller is free to get values from properties. The event <see cref="Efl.IModel.PropertiesChangedEvent"/> may be raised to notify listeners of the property/value.
    /// 
    /// See <see cref="Efl.IModel.GetProperties"/>, <see cref="Efl.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <returns>Property value</returns>
    public virtual Eina.Value GetProperty(System.String property) {
                                 var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_property_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),property);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set a property value of a given property name.
    /// The caller must ensure to call at least efl_model_prop_list before being able to see/set properties. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="Efl.IModel.PropertiesChangedEvent"/> event in order to notify listeners of the new value of the property.
    /// 
    /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
    /// 
    /// See <see cref="Efl.IModel.GetProperty"/>, <see cref="Efl.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <returns>Return an error in case the property could not be set, or the value that was set otherwise.</returns>
    public virtual  Eina.Future SetProperty(System.String property, Eina.Value value) {
                                                         var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_property_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),property, value);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Number of children.
    /// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
    /// <returns>Current known children count</returns>
    public virtual uint GetChildrenCount() {
         var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_children_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get a future value when it changes to something that is not error:EAGAIN
    /// <see cref="Efl.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disappears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
    /// 
    /// The future can also be canceled if the model itself gets destroyed.</summary>
    /// <param name="property">Property name.</param>
    /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
    public virtual  Eina.Future GetPropertyReady(System.String property) {
                                 var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_property_ready_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),property);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get children slice OR full range.
    /// <see cref="Efl.IModel.GetChildrenSlice"/> behaves in two different ways, it may provide the slice if <c>count</c> is non-zero OR full range otherwise.
    /// 
    /// Since &apos;slice&apos; is a range, for example if we have 20 children a slice could be the range from 3(start) with 4(count), see:
    /// 
    /// child 0  [no] child 1  [no] child 2  [no] child 3  [yes] child 4  [yes] child 5  [yes] child 6  [yes] child 7  [no]
    /// 
    /// Optionally the user can call <see cref="Efl.IModel.GetChildrenCount"/> to know the number of children so a valid range can be known in advance.
    /// 
    /// See <see cref="Efl.IModel.GetChildrenCount"/>
    /// 
    /// Note: The returned children will live only as long as the future itself. Once the future is done, if you want to keep the object alive, you need to take a reference for yourself.</summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <returns>Array of children</returns>
    public virtual  Eina.Future GetChildrenSlice(uint start, uint count) {
                                                         var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_children_slice_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, count);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Add a new child.
    /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="Efl.IModel.ChildAddedEvent"/> is then raised and the new child is kept along with other children.</summary>
    /// <returns>Child object</returns>
    public virtual Efl.Object AddChild() {
         var _ret_var = Efl.ModelConcrete.NativeMethods.efl_model_child_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Remove a child.
    /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="Efl.IModel.ChildRemovedEvent"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
    /// <param name="child">Child to be removed</param>
    public virtual void DelChild(Efl.Object child) {
                                 Efl.ModelConcrete.NativeMethods.efl_model_child_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Async wrapper for <see cref="SetProperty" />.</summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> SetPropertyAsync(System.String property,Eina.Value value, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetProperty( property, value);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="GetPropertyReady" />.</summary>
    /// <param name="property">Property name.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> GetPropertyReadyAsync(System.String property, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = GetPropertyReady( property);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.</summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> GetChildrenSliceAsync(uint start,uint count, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = GetChildrenSlice( start, count);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>Get properties from model.
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="Efl.IModel.PropertiesChangedEvent"/>.</summary>
    /// <value>Array of current properties</value>
    public Eina.Iterator<System.String> Properties {
        get { return GetProperties(); }
    }
    /// <summary>Number of children.
    /// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
    /// <value>Current known children count</value>
    public uint ChildrenCount {
        get { return GetChildrenCount(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopModel.efl_loop_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_model_volatile_make_static_delegate == null)
            {
                efl_loop_model_volatile_make_static_delegate = new efl_loop_model_volatile_make_delegate(volatile_make);
            }

            if (methods.FirstOrDefault(m => m.Name == "VolatileMake") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_model_volatile_make"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_model_volatile_make_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopModel.efl_loop_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_loop_model_volatile_make_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_loop_model_volatile_make_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_model_volatile_make_api_delegate> efl_loop_model_volatile_make_ptr = new Efl.Eo.FunctionWrapper<efl_loop_model_volatile_make_api_delegate>(Module, "efl_loop_model_volatile_make");

        private static void volatile_make(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_model_volatile_make was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((LoopModel)ws.Target).VolatileMake();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_loop_model_volatile_make_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_model_volatile_make_delegate efl_loop_model_volatile_make_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflLoopModel_ExtensionMethods {
    
    
    
}
#pragma warning restore CS1591
#endif
