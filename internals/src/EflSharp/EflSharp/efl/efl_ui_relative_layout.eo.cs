#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>The relative layout class.
/// A relative layout calculates the size and position of all the children based on their relationship to each other.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.RelativeLayout.NativeMethods]
[Efl.Eo.BindingEntity]
public class RelativeLayout : Efl.Ui.Widget, Efl.IContainer, Efl.IPack, Efl.IPackLayout
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(RelativeLayout))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_relative_layout_class_get();
    /// <summary>Initializes a new instance of the <see cref="RelativeLayout"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public RelativeLayout(Efl.Object parent
            , System.String style = null) : base(efl_ui_relative_layout_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected RelativeLayout(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="RelativeLayout"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected RelativeLayout(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="RelativeLayout"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected RelativeLayout(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sent after a new sub-object was added.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentAddedEventArgs> ContentAddedEvent
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
                        Efl.ContainerContentAddedEventArgs args = new Efl.ContainerContentAddedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentAddedEvent(Efl.ContainerContentAddedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after a sub-object was removed, before unref.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentRemovedEventArgs> ContentRemovedEvent
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
                        Efl.ContainerContentRemovedEventArgs args = new Efl.ContainerContentRemovedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentRemovedEvent(Efl.ContainerContentRemovedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvent
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

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LayoutUpdatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLayoutUpdatedEvent(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Specifies the left side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    public virtual void GetRelationLeft(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_left_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the left side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    public virtual void SetRelationLeft(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_left_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the right side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    public virtual void GetRelationRight(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_right_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the right side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    public virtual void SetRelationRight(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_right_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the top side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    public virtual void GetRelationTop(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_top_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the top side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    public virtual void SetRelationTop(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_top_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the bottom side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    public virtual void GetRelationBottom(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_bottom_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the bottom side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    public virtual void SetRelationBottom(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_bottom_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator on object&apos;s content.</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns the number of contained sub-objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of sub-objects.</returns>
    public virtual int ContentCount() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool ClearPack() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool UnpackAll() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public virtual bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Requests EFL to recalculate the layout of this object.
    /// Internal layout methods might be called asynchronously.</summary>
    public virtual void LayoutRequest() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overridden to implement custom layout behaviors.</summary>
    protected virtual void UpdateLayout() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.RelativeLayout.efl_ui_relative_layout_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_relative_layout_relation_left_get_static_delegate == null)
            {
                efl_ui_relative_layout_relation_left_get_static_delegate = new efl_ui_relative_layout_relation_left_get_delegate(relation_left_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationLeft") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_left_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_left_get_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_left_set_static_delegate == null)
            {
                efl_ui_relative_layout_relation_left_set_static_delegate = new efl_ui_relative_layout_relation_left_set_delegate(relation_left_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRelationLeft") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_left_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_left_set_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_right_get_static_delegate == null)
            {
                efl_ui_relative_layout_relation_right_get_static_delegate = new efl_ui_relative_layout_relation_right_get_delegate(relation_right_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationRight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_right_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_right_get_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_right_set_static_delegate == null)
            {
                efl_ui_relative_layout_relation_right_set_static_delegate = new efl_ui_relative_layout_relation_right_set_delegate(relation_right_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRelationRight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_right_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_right_set_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_top_get_static_delegate == null)
            {
                efl_ui_relative_layout_relation_top_get_static_delegate = new efl_ui_relative_layout_relation_top_get_delegate(relation_top_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationTop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_top_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_top_get_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_top_set_static_delegate == null)
            {
                efl_ui_relative_layout_relation_top_set_static_delegate = new efl_ui_relative_layout_relation_top_set_delegate(relation_top_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRelationTop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_top_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_top_set_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_bottom_get_static_delegate == null)
            {
                efl_ui_relative_layout_relation_bottom_get_static_delegate = new efl_ui_relative_layout_relation_bottom_get_delegate(relation_bottom_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationBottom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_bottom_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_bottom_get_static_delegate) });
            }

            if (efl_ui_relative_layout_relation_bottom_set_static_delegate == null)
            {
                efl_ui_relative_layout_relation_bottom_set_static_delegate = new efl_ui_relative_layout_relation_bottom_set_delegate(relation_bottom_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRelationBottom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_relation_bottom_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_relation_bottom_set_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
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
            return Efl.Ui.RelativeLayout.efl_ui_relative_layout_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_relative_layout_relation_left_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        
        public delegate void efl_ui_relative_layout_relation_left_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_get_api_delegate> efl_ui_relative_layout_relation_left_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_get_api_delegate>(Module, "efl_ui_relative_layout_relation_left_get");

        private static void relation_left_get(System.IntPtr obj, System.IntPtr pd, Efl.Object child, out Efl.Object target, out double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_left_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)ws.Target).GetRelationLeft(child, out target, out relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_left_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, out target, out relative);
            }
        }

        private static efl_ui_relative_layout_relation_left_get_delegate efl_ui_relative_layout_relation_left_get_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_left_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        
        public delegate void efl_ui_relative_layout_relation_left_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_set_api_delegate> efl_ui_relative_layout_relation_left_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_set_api_delegate>(Module, "efl_ui_relative_layout_relation_left_set");

        private static void relation_left_set(System.IntPtr obj, System.IntPtr pd, Efl.Object child, Efl.Object target, double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_left_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)ws.Target).SetRelationLeft(child, target, relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_left_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, target, relative);
            }
        }

        private static efl_ui_relative_layout_relation_left_set_delegate efl_ui_relative_layout_relation_left_set_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_right_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        
        public delegate void efl_ui_relative_layout_relation_right_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_right_get_api_delegate> efl_ui_relative_layout_relation_right_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_right_get_api_delegate>(Module, "efl_ui_relative_layout_relation_right_get");

        private static void relation_right_get(System.IntPtr obj, System.IntPtr pd, Efl.Object child, out Efl.Object target, out double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_right_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)ws.Target).GetRelationRight(child, out target, out relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_right_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, out target, out relative);
            }
        }

        private static efl_ui_relative_layout_relation_right_get_delegate efl_ui_relative_layout_relation_right_get_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_right_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        
        public delegate void efl_ui_relative_layout_relation_right_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_right_set_api_delegate> efl_ui_relative_layout_relation_right_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_right_set_api_delegate>(Module, "efl_ui_relative_layout_relation_right_set");

        private static void relation_right_set(System.IntPtr obj, System.IntPtr pd, Efl.Object child, Efl.Object target, double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_right_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)ws.Target).SetRelationRight(child, target, relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_right_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, target, relative);
            }
        }

        private static efl_ui_relative_layout_relation_right_set_delegate efl_ui_relative_layout_relation_right_set_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_top_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        
        public delegate void efl_ui_relative_layout_relation_top_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_top_get_api_delegate> efl_ui_relative_layout_relation_top_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_top_get_api_delegate>(Module, "efl_ui_relative_layout_relation_top_get");

        private static void relation_top_get(System.IntPtr obj, System.IntPtr pd, Efl.Object child, out Efl.Object target, out double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_top_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)ws.Target).GetRelationTop(child, out target, out relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_top_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, out target, out relative);
            }
        }

        private static efl_ui_relative_layout_relation_top_get_delegate efl_ui_relative_layout_relation_top_get_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_top_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        
        public delegate void efl_ui_relative_layout_relation_top_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_top_set_api_delegate> efl_ui_relative_layout_relation_top_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_top_set_api_delegate>(Module, "efl_ui_relative_layout_relation_top_set");

        private static void relation_top_set(System.IntPtr obj, System.IntPtr pd, Efl.Object child, Efl.Object target, double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_top_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)ws.Target).SetRelationTop(child, target, relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_top_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, target, relative);
            }
        }

        private static efl_ui_relative_layout_relation_top_set_delegate efl_ui_relative_layout_relation_top_set_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_bottom_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        
        public delegate void efl_ui_relative_layout_relation_bottom_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_bottom_get_api_delegate> efl_ui_relative_layout_relation_bottom_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_bottom_get_api_delegate>(Module, "efl_ui_relative_layout_relation_bottom_get");

        private static void relation_bottom_get(System.IntPtr obj, System.IntPtr pd, Efl.Object child, out Efl.Object target, out double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_bottom_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)ws.Target).GetRelationBottom(child, out target, out relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_bottom_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, out target, out relative);
            }
        }

        private static efl_ui_relative_layout_relation_bottom_get_delegate efl_ui_relative_layout_relation_bottom_get_static_delegate;

        
        private delegate void efl_ui_relative_layout_relation_bottom_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        
        public delegate void efl_ui_relative_layout_relation_bottom_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object target,  double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_bottom_set_api_delegate> efl_ui_relative_layout_relation_bottom_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_bottom_set_api_delegate>(Module, "efl_ui_relative_layout_relation_bottom_set");

        private static void relation_bottom_set(System.IntPtr obj, System.IntPtr pd, Efl.Object child, Efl.Object target, double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_bottom_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)ws.Target).SetRelationBottom(child, target, relative);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_relative_layout_relation_bottom_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, target, relative);
            }
        }

        private static efl_ui_relative_layout_relation_bottom_set_delegate efl_ui_relative_layout_relation_bottom_set_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((RelativeLayout)ws.Target).UpdateLayout();
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiRelativeLayout_ExtensionMethods {
    
    
    
    
}
#pragma warning restore CS1591
#endif
