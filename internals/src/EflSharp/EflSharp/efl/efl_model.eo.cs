#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl model interface</summary>
[Efl.IModelConcrete.NativeMethods]
public interface IModel : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get properties from model.
/// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
/// 
/// See also <see cref="Efl.IModel.PropertiesChangedEvt"/>.</summary>
/// <returns>Array of current properties</returns>
Eina.Iterator<System.String> GetProperties();
    /// <summary>Retrieve the value of a given property name.
/// At this point the caller is free to get values from properties. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> may be raised to notify listeners of the property/value.
/// 
/// See <see cref="Efl.IModel.GetProperties"/>, <see cref="Efl.IModel.PropertiesChangedEvt"/></summary>
/// <param name="property">Property name</param>
/// <returns>Property value</returns>
Eina.Value GetProperty(System.String property);
    /// <summary>Set a property value of a given property name.
/// The caller must ensure to call at least efl_model_prop_list before being able to see/set properties. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="Efl.IModel.PropertiesChangedEvt"/> event in order to notify listeners of the new value of the property.
/// 
/// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
/// 
/// See <see cref="Efl.IModel.GetProperty"/>, <see cref="Efl.IModel.PropertiesChangedEvt"/></summary>
/// <param name="property">Property name</param>
/// <param name="value">Property value</param>
/// <returns>Return an error in case the property could not be set, the value that was set otherwise.</returns>
 Eina.Future SetProperty(System.String property, Eina.Value value);
    /// <summary>Get children count.
/// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvt"/> is emitted when count is finished.
/// 
/// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
/// <returns>Current known children count</returns>
uint GetChildrenCount();
    /// <summary>Get a future value when it changes to something that is not error:EAGAIN
/// <see cref="Efl.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disapears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
/// 
/// The future can also be canceled if the model itself gets destroyed.</summary>
/// <param name="property">Property name.</param>
/// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
 Eina.Future GetPropertyReady(System.String property);
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
 Eina.Future GetChildrenSlice(uint start, uint count);
    /// <summary>Add a new child.
/// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="Efl.IModel.ChildAddedEvt"/> is then raised and the new child is kept along with other children.</summary>
/// <returns>Child object</returns>
Efl.Object AddChild();
    /// <summary>Remove a child.
/// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="Efl.IModel.ChildRemovedEvt"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
/// <param name="child">Child to be removed</param>
void DelChild(Efl.Object child);
                /// <summary>Async wrapper for <see cref="SetProperty" />.</summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<Eina.Value> SetPropertyAsync(System.String property,Eina.Value value, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

            /// <summary>Async wrapper for <see cref="GetPropertyReady" />.</summary>
    /// <param name="property">Property name.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<Eina.Value> GetPropertyReadyAsync(System.String property, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

        /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.</summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<Eina.Value> GetChildrenSliceAsync(uint start,uint count, System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

            /// <summary>Event dispatched when properties list is available.</summary>
    event EventHandler<Efl.IModelPropertiesChangedEvt_Args> PropertiesChangedEvt;
    /// <summary>Event dispatched when new child is added.</summary>
    event EventHandler<Efl.IModelChildAddedEvt_Args> ChildAddedEvt;
    /// <summary>Event dispatched when child is removed.</summary>
    event EventHandler<Efl.IModelChildRemovedEvt_Args> ChildRemovedEvt;
    /// <summary>Event dispatched when children count is finished.</summary>
    event EventHandler ChildrenCountChangedEvt;
    /// <summary>Get properties from model.
    /// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="Efl.IModel.PropertiesChangedEvt"/>.</summary>
    /// <value>Array of current properties</value>
    Eina.Iterator<System.String> Properties {
        get ;
    }
    /// <summary>Get children count.
    /// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvt"/> is emitted when count is finished.
    /// 
    /// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
    /// <value>Current known children count</value>
    uint ChildrenCount {
        get ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.IModel.PropertiesChangedEvt"/>.</summary>
public class IModelPropertiesChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.ModelPropertyEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.IModel.ChildAddedEvt"/>.</summary>
public class IModelChildAddedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.ModelChildrenEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.IModel.ChildRemovedEvt"/>.</summary>
public class IModelChildRemovedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.ModelChildrenEvent arg { get; set; }
}
/// <summary>Efl model interface</summary>
sealed public class IModelConcrete :
    Efl.Eo.EoWrapper
    , IModel
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IModelConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_model_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IModel"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IModelConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Event dispatched when properties list is available.</summary>
    public event EventHandler<Efl.IModelPropertiesChangedEvt_Args> PropertiesChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.IModelPropertiesChangedEvt_Args args = new Efl.IModelPropertiesChangedEvt_Args();
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event PropertiesChangedEvt.</summary>
    public void OnPropertiesChangedEvt(Efl.IModelPropertiesChangedEvt_Args e)
    {
        var key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    public event EventHandler<Efl.IModelChildAddedEvt_Args> ChildAddedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.IModelChildAddedEvt_Args args = new Efl.IModelChildAddedEvt_Args();
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildAddedEvt.</summary>
    public void OnChildAddedEvt(Efl.IModelChildAddedEvt_Args e)
    {
        var key = "_EFL_MODEL_EVENT_CHILD_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    public event EventHandler<Efl.IModelChildRemovedEvt_Args> ChildRemovedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.IModelChildRemovedEvt_Args args = new Efl.IModelChildRemovedEvt_Args();
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildRemovedEvt.</summary>
    public void OnChildRemovedEvt(Efl.IModelChildRemovedEvt_Args e)
    {
        var key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    public event EventHandler ChildrenCountChangedEvt
    {
        add
        {
            lock (eventLock)
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildrenCountChangedEvt.</summary>
    public void OnChildrenCountChangedEvt(EventArgs e)
    {
        var key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Get properties from model.
    /// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="Efl.IModel.PropertiesChangedEvt"/>.</summary>
    /// <returns>Array of current properties</returns>
    public Eina.Iterator<System.String> GetProperties() {
         var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_properties_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<System.String>(_ret_var, true, false);
 }
    /// <summary>Retrieve the value of a given property name.
    /// At this point the caller is free to get values from properties. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> may be raised to notify listeners of the property/value.
    /// 
    /// See <see cref="Efl.IModel.GetProperties"/>, <see cref="Efl.IModel.PropertiesChangedEvt"/></summary>
    /// <param name="property">Property name</param>
    /// <returns>Property value</returns>
    public Eina.Value GetProperty(System.String property) {
                                 var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_property_get_ptr.Value.Delegate(this.NativeHandle,property);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set a property value of a given property name.
    /// The caller must ensure to call at least efl_model_prop_list before being able to see/set properties. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="Efl.IModel.PropertiesChangedEvt"/> event in order to notify listeners of the new value of the property.
    /// 
    /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
    /// 
    /// See <see cref="Efl.IModel.GetProperty"/>, <see cref="Efl.IModel.PropertiesChangedEvt"/></summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <returns>Return an error in case the property could not be set, the value that was set otherwise.</returns>
    public  Eina.Future SetProperty(System.String property, Eina.Value value) {
                                                         var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_property_set_ptr.Value.Delegate(this.NativeHandle,property, value);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Get children count.
    /// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvt"/> is emitted when count is finished.
    /// 
    /// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
    /// <returns>Current known children count</returns>
    public uint GetChildrenCount() {
         var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_children_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get a future value when it changes to something that is not error:EAGAIN
    /// <see cref="Efl.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disapears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
    /// 
    /// The future can also be canceled if the model itself gets destroyed.</summary>
    /// <param name="property">Property name.</param>
    /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
    public  Eina.Future GetPropertyReady(System.String property) {
                                 var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_property_ready_get_ptr.Value.Delegate(this.NativeHandle,property);
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
    public  Eina.Future GetChildrenSlice(uint start, uint count) {
                                                         var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_children_slice_get_ptr.Value.Delegate(this.NativeHandle,start, count);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Add a new child.
    /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="Efl.IModel.ChildAddedEvt"/> is then raised and the new child is kept along with other children.</summary>
    /// <returns>Child object</returns>
    public Efl.Object AddChild() {
         var _ret_var = Efl.IModelConcrete.NativeMethods.efl_model_child_add_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Remove a child.
    /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="Efl.IModel.ChildRemovedEvt"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
    /// <param name="child">Child to be removed</param>
    public void DelChild(Efl.Object child) {
                                 Efl.IModelConcrete.NativeMethods.efl_model_child_del_ptr.Value.Delegate(this.NativeHandle,child);
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
    /// properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="Efl.IModel.PropertiesChangedEvt"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="Efl.IModel.PropertiesChangedEvt"/>.</summary>
    /// <value>Array of current properties</value>
    public Eina.Iterator<System.String> Properties {
        get { return GetProperties(); }
    }
    /// <summary>Get children count.
    /// When efl_model_load is completed <see cref="Efl.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="Efl.IModel.GetChildrenCount"/> can also be used before calling <see cref="Efl.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="Efl.IModel.ChildrenCountChangedEvt"/> is emitted when count is finished.
    /// 
    /// See also <see cref="Efl.IModel.GetChildrenSlice"/>.</summary>
    /// <value>Current known children count</value>
    public uint ChildrenCount {
        get { return GetChildrenCount(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IModelConcrete.efl_model_interface_get();
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

            if (efl_model_properties_get_static_delegate == null)
            {
                efl_model_properties_get_static_delegate = new efl_model_properties_get_delegate(properties_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetProperties") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_properties_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_properties_get_static_delegate) });
            }

            if (efl_model_property_get_static_delegate == null)
            {
                efl_model_property_get_static_delegate = new efl_model_property_get_delegate(property_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetProperty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_get_static_delegate) });
            }

            if (efl_model_property_set_static_delegate == null)
            {
                efl_model_property_set_static_delegate = new efl_model_property_set_delegate(property_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetProperty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_set_static_delegate) });
            }

            if (efl_model_children_count_get_static_delegate == null)
            {
                efl_model_children_count_get_static_delegate = new efl_model_children_count_get_delegate(children_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetChildrenCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_count_get_static_delegate) });
            }

            if (efl_model_property_ready_get_static_delegate == null)
            {
                efl_model_property_ready_get_static_delegate = new efl_model_property_ready_get_delegate(property_ready_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPropertyReady") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_ready_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_ready_get_static_delegate) });
            }

            if (efl_model_children_slice_get_static_delegate == null)
            {
                efl_model_children_slice_get_static_delegate = new efl_model_children_slice_get_delegate(children_slice_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetChildrenSlice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_slice_get_static_delegate) });
            }

            if (efl_model_child_add_static_delegate == null)
            {
                efl_model_child_add_static_delegate = new efl_model_child_add_delegate(child_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddChild") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_add_static_delegate) });
            }

            if (efl_model_child_del_static_delegate == null)
            {
                efl_model_child_del_static_delegate = new efl_model_child_del_delegate(child_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelChild") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_del"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_del_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IModelConcrete.efl_model_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_model_properties_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_model_properties_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_model_properties_get_api_delegate> efl_model_properties_get_ptr = new Efl.Eo.FunctionWrapper<efl_model_properties_get_api_delegate>(Module, "efl_model_properties_get");

        private static System.IntPtr properties_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_model_properties_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<System.String> _ret_var = default(Eina.Iterator<System.String>);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperties();
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
                return efl_model_properties_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_model_properties_get_delegate efl_model_properties_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_model_property_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_model_property_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        public static Efl.Eo.FunctionWrapper<efl_model_property_get_api_delegate> efl_model_property_get_ptr = new Efl.Eo.FunctionWrapper<efl_model_property_get_api_delegate>(Module, "efl_model_property_get");

        private static Eina.Value property_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            Eina.Log.Debug("function efl_model_property_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperty(property);
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
                return efl_model_property_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), property);
            }
        }

        private static efl_model_property_get_delegate efl_model_property_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_model_property_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value value);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_model_property_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value value);

        public static Efl.Eo.FunctionWrapper<efl_model_property_set_api_delegate> efl_model_property_set_ptr = new Efl.Eo.FunctionWrapper<efl_model_property_set_api_delegate>(Module, "efl_model_property_set");

        private static  Eina.Future property_set(System.IntPtr obj, System.IntPtr pd, System.String property, Eina.Value value)
        {
            Eina.Log.Debug("function efl_model_property_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).SetProperty(property, value);
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
                return efl_model_property_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), property, value);
            }
        }

        private static efl_model_property_set_delegate efl_model_property_set_static_delegate;

        
        private delegate uint efl_model_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_model_children_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_model_children_count_get_api_delegate> efl_model_children_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_model_children_count_get_api_delegate>(Module, "efl_model_children_count_get");

        private static uint children_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_model_children_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenCount();
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
                return efl_model_children_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_model_children_count_get_delegate efl_model_children_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_model_property_ready_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_model_property_ready_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        public static Efl.Eo.FunctionWrapper<efl_model_property_ready_get_api_delegate> efl_model_property_ready_get_ptr = new Efl.Eo.FunctionWrapper<efl_model_property_ready_get_api_delegate>(Module, "efl_model_property_ready_get");

        private static  Eina.Future property_ready_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            Eina.Log.Debug("function efl_model_property_ready_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                     Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetPropertyReady(property);
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
                return efl_model_property_ready_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), property);
            }
        }

        private static efl_model_property_ready_get_delegate efl_model_property_ready_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_model_children_slice_get_delegate(System.IntPtr obj, System.IntPtr pd,  uint start,  uint count);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_model_children_slice_get_api_delegate(System.IntPtr obj,  uint start,  uint count);

        public static Efl.Eo.FunctionWrapper<efl_model_children_slice_get_api_delegate> efl_model_children_slice_get_ptr = new Efl.Eo.FunctionWrapper<efl_model_children_slice_get_api_delegate>(Module, "efl_model_children_slice_get");

        private static  Eina.Future children_slice_get(System.IntPtr obj, System.IntPtr pd, uint start, uint count)
        {
            Eina.Log.Debug("function efl_model_children_slice_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenSlice(start, count);
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
                return efl_model_children_slice_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, count);
            }
        }

        private static efl_model_children_slice_get_delegate efl_model_children_slice_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_model_child_add_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_model_child_add_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_model_child_add_api_delegate> efl_model_child_add_ptr = new Efl.Eo.FunctionWrapper<efl_model_child_add_api_delegate>(Module, "efl_model_child_add");

        private static Efl.Object child_add(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_model_child_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((IModel)ws.Target).AddChild();
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
                return efl_model_child_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_model_child_add_delegate efl_model_child_add_static_delegate;

        
        private delegate void efl_model_child_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child);

        
        public delegate void efl_model_child_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child);

        public static Efl.Eo.FunctionWrapper<efl_model_child_del_api_delegate> efl_model_child_del_ptr = new Efl.Eo.FunctionWrapper<efl_model_child_del_api_delegate>(Module, "efl_model_child_del");

        private static void child_del(System.IntPtr obj, System.IntPtr pd, Efl.Object child)
        {
            Eina.Log.Debug("function efl_model_child_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IModel)ws.Target).DelChild(child);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_model_child_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child);
            }
        }

        private static efl_model_child_del_delegate efl_model_child_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace Efl {

/// <summary>EFL model property event data structure</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ModelPropertyEvent
{
    /// <summary>List of changed properties</summary>
    public Eina.Array<System.String> Changed_properties;
    /// <summary>Removed properties identified by name</summary>
    public Eina.Array<System.String> Invalidated_properties;
    ///<summary>Constructor for ModelPropertyEvent.</summary>
    public ModelPropertyEvent(
        Eina.Array<System.String> Changed_properties = default(Eina.Array<System.String>),
        Eina.Array<System.String> Invalidated_properties = default(Eina.Array<System.String>)    )
    {
        this.Changed_properties = Changed_properties;
        this.Invalidated_properties = Invalidated_properties;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ModelPropertyEvent(IntPtr ptr)
    {
        var tmp = (ModelPropertyEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ModelPropertyEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct ModelPropertyEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public System.IntPtr Changed_properties;
        
        public System.IntPtr Invalidated_properties;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ModelPropertyEvent.NativeStruct(ModelPropertyEvent _external_struct)
        {
            var _internal_struct = new ModelPropertyEvent.NativeStruct();
            _internal_struct.Changed_properties = _external_struct.Changed_properties.Handle;
            _internal_struct.Invalidated_properties = _external_struct.Invalidated_properties.Handle;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ModelPropertyEvent(ModelPropertyEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ModelPropertyEvent();
            _external_struct.Changed_properties = new Eina.Array<System.String>(_internal_struct.Changed_properties, false, false);
            _external_struct.Invalidated_properties = new Eina.Array<System.String>(_internal_struct.Invalidated_properties, false, false);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

namespace Efl {

/// <summary>Every time a child is added the event <see cref="Efl.IModel.ChildAddedEvt"/> is dispatched passing along this structure.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ModelChildrenEvent
{
    /// <summary>index is a hint and is intended to provide a way for applications to control/know children relative positions through listings.</summary>
    public uint Index;
    /// <summary>If an object has been built for this index and it is currently tracked by the parent, it will be available here.</summary>
    public Efl.Object Child;
    ///<summary>Constructor for ModelChildrenEvent.</summary>
    public ModelChildrenEvent(
        uint Index = default(uint),
        Efl.Object Child = default(Efl.Object)    )
    {
        this.Index = Index;
        this.Child = Child;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ModelChildrenEvent(IntPtr ptr)
    {
        var tmp = (ModelChildrenEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ModelChildrenEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct ModelChildrenEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Index;
        ///<summary>Internal wrapper for field Child</summary>
        public System.IntPtr Child;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ModelChildrenEvent.NativeStruct(ModelChildrenEvent _external_struct)
        {
            var _internal_struct = new ModelChildrenEvent.NativeStruct();
            _internal_struct.Index = _external_struct.Index;
            _internal_struct.Child = _external_struct.Child?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ModelChildrenEvent(ModelChildrenEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ModelChildrenEvent();
            _external_struct.Index = _internal_struct.Index;

            _external_struct.Child = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Child);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

