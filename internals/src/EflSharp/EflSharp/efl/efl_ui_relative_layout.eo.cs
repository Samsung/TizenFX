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
[Efl.Ui.RelativeLayout.NativeMethods]
public class RelativeLayout : Efl.Ui.Widget, Efl.Eo.IWrapper,Efl.IPackLayout
{
    ///<summary>Pointer to the native class description.</summary>
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
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public RelativeLayout(Efl.Object parent
            , System.String style = null) : base(efl_ui_relative_layout_class_get(), typeof(RelativeLayout), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="RelativeLayout"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected RelativeLayout(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="RelativeLayout"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected RelativeLayout(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
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

    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvt
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

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
    public void OnLayoutUpdatedEvt(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    virtual public void GetRelationLeft(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_left_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the left side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    virtual public void SetRelationLeft(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_left_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the right side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    virtual public void GetRelationRight(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_right_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the right side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between left and right of the target, ranging from 0.0 to 1.0.</param>
    virtual public void SetRelationRight(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_right_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the top side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    virtual public void GetRelationTop(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_top_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the top side edge of the child relative to the target. By default, target is parent and relative is 0.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    virtual public void SetRelationTop(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_top_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the bottom side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    virtual public void GetRelationBottom(Efl.Object child, out Efl.Object target, out double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_bottom_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, out target, out relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Specifies the bottom side edge of the child relative to the target. By default, target is parent and relative is 1.0.</summary>
    /// <param name="child">The child to specify relation.</param>
    /// <param name="target">The relative target.</param>
    /// <param name="relative">The ratio between top and bottom of the target, ranging from 0.0 to 1.0.</param>
    virtual public void SetRelationBottom(Efl.Object child, Efl.Object target, double relative) {
                                                                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_relation_bottom_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child, target, relative);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Remove all relations of the child.</summary>
    /// <param name="child">The child to unregister</param>
    virtual public void Unregister(Efl.Object child) {
                                 Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_unregister_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Remove all relations from the registered children.</summary>
    virtual public void UnregisterAll() {
         Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_unregister_all_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Begin iterating over this object&apos;s children.</summary>
    /// <returns>Iterator to object children.</returns>
    virtual public Eina.Iterator<Efl.Object> ChildrenIterate() {
         var _ret_var = Efl.Ui.RelativeLayout.NativeMethods.efl_ui_relative_layout_children_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Object>(_ret_var, true, false);
 }
    /// <summary>Requests EFL to call the <see cref="Efl.IPackLayout.UpdateLayout"/> method on this object.
    /// This <see cref="Efl.IPackLayout.UpdateLayout"/> may be called asynchronously.</summary>
    virtual public void LayoutRequest() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overriden to implement custom layout behaviors.</summary>
    virtual public void UpdateLayout() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (efl_ui_relative_layout_unregister_static_delegate == null)
            {
                efl_ui_relative_layout_unregister_static_delegate = new efl_ui_relative_layout_unregister_delegate(unregister);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unregister") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_unregister_static_delegate) });
            }

            if (efl_ui_relative_layout_unregister_all_static_delegate == null)
            {
                efl_ui_relative_layout_unregister_all_static_delegate = new efl_ui_relative_layout_unregister_all_delegate(unregister_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnregisterAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_unregister_all"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_unregister_all_static_delegate) });
            }

            if (efl_ui_relative_layout_children_iterate_static_delegate == null)
            {
                efl_ui_relative_layout_children_iterate_static_delegate = new efl_ui_relative_layout_children_iterate_delegate(children_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "ChildrenIterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_relative_layout_children_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_relative_layout_children_iterate_static_delegate) });
            }

            if (efl_pack_layout_request_static_delegate == null)
            {
                efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
            }

            if (methods.FirstOrDefault(m => m.Name == "LayoutRequest") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.RelativeLayout.efl_ui_relative_layout_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_ui_relative_layout_relation_left_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        
        public delegate void efl_ui_relative_layout_relation_left_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Object target,  out double relative);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_get_api_delegate> efl_ui_relative_layout_relation_left_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_relation_left_get_api_delegate>(Module, "efl_ui_relative_layout_relation_left_get");

        private static void relation_left_get(System.IntPtr obj, System.IntPtr pd, Efl.Object child, out Efl.Object target, out double relative)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_relation_left_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)wrapper).GetRelationLeft(child, out target, out relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)wrapper).SetRelationLeft(child, target, relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)wrapper).GetRelationRight(child, out target, out relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)wrapper).SetRelationRight(child, target, relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)wrapper).GetRelationTop(child, out target, out relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)wrapper).SetRelationTop(child, target, relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        target = default(Efl.Object);        relative = default(double);                                    
                try
                {
                    ((RelativeLayout)wrapper).GetRelationBottom(child, out target, out relative);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((RelativeLayout)wrapper).SetRelationBottom(child, target, relative);
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

        
        private delegate void efl_ui_relative_layout_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child);

        
        public delegate void efl_ui_relative_layout_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object child);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_unregister_api_delegate> efl_ui_relative_layout_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_unregister_api_delegate>(Module, "efl_ui_relative_layout_unregister");

        private static void unregister(System.IntPtr obj, System.IntPtr pd, Efl.Object child)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_unregister was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((RelativeLayout)wrapper).Unregister(child);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_relative_layout_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child);
            }
        }

        private static efl_ui_relative_layout_unregister_delegate efl_ui_relative_layout_unregister_static_delegate;

        
        private delegate void efl_ui_relative_layout_unregister_all_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_relative_layout_unregister_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_unregister_all_api_delegate> efl_ui_relative_layout_unregister_all_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_unregister_all_api_delegate>(Module, "efl_ui_relative_layout_unregister_all");

        private static void unregister_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_unregister_all was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((RelativeLayout)wrapper).UnregisterAll();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_relative_layout_unregister_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_relative_layout_unregister_all_delegate efl_ui_relative_layout_unregister_all_static_delegate;

        
        private delegate System.IntPtr efl_ui_relative_layout_children_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_relative_layout_children_iterate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_relative_layout_children_iterate_api_delegate> efl_ui_relative_layout_children_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_ui_relative_layout_children_iterate_api_delegate>(Module, "efl_ui_relative_layout_children_iterate");

        private static System.IntPtr children_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_relative_layout_children_iterate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Iterator<Efl.Object> _ret_var = default(Eina.Iterator<Efl.Object>);
                try
                {
                    _ret_var = ((RelativeLayout)wrapper).ChildrenIterate();
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
                return efl_ui_relative_layout_children_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_relative_layout_children_iterate_delegate efl_ui_relative_layout_children_iterate_static_delegate;

        
        private delegate void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_request_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate>(Module, "efl_pack_layout_request");

        private static void layout_request(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_request was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((RelativeLayout)wrapper).LayoutRequest();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_request_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((RelativeLayout)wrapper).UpdateLayout();
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

