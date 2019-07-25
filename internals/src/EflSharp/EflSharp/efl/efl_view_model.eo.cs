#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="view_model">The ViewModel object the @.property.get is issued on.</param>
/// <param name="property">The property name the @.property.get is issued on.</param>
[Efl.Eo.BindingEntity]
public delegate Eina.Value EflViewModelPropertyGet(Efl.ViewModel view_model, System.String property);
[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]public delegate Eina.Value EflViewModelPropertyGetInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.ViewModel view_model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String property);
internal class EflViewModelPropertyGetWrapper : IDisposable
{

    private EflViewModelPropertyGetInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflViewModelPropertyGetWrapper (EflViewModelPropertyGetInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflViewModelPropertyGetWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal Eina.Value ManagedCb(Efl.ViewModel view_model,System.String property)
    {
                                                        var _ret_var = _cb(_cb_data, view_model, property);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
    }

    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]    internal static Eina.Value Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.ViewModel view_model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String property)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflViewModelPropertyGet cb = (EflViewModelPropertyGet)handle.Target;
                                                            Eina.Value _ret_var = default(Eina.Value);
        try {
            _ret_var = cb(view_model, property);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                        return _ret_var;
    }
}


/// <param name="view_model">The ViewModel object the @.property.set is issued on.</param>
/// <param name="property">The property name the @.property.set is issued on.</param>
/// <param name="value">The new value to set.</param>
[Efl.Eo.BindingEntity]
public delegate  Eina.Future EflViewModelPropertySet(Efl.ViewModel view_model, System.String property, Eina.Value value);
[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]public delegate  Eina.Future EflViewModelPropertySetInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.ViewModel view_model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshalerOwn))] Eina.Value value);
internal class EflViewModelPropertySetWrapper : IDisposable
{

    private EflViewModelPropertySetInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflViewModelPropertySetWrapper (EflViewModelPropertySetInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflViewModelPropertySetWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal  Eina.Future ManagedCb(Efl.ViewModel view_model,System.String property,Eina.Value value)
    {
                                                                                var _ret_var = _cb(_cb_data, view_model, property, value);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
    }

    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]    internal static  Eina.Future Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.ViewModel view_model, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshalerOwn))] Eina.Value value)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflViewModelPropertySet cb = (EflViewModelPropertySet)handle.Target;
                                                                                     Eina.Future _ret_var = default( Eina.Future);
        try {
            _ret_var = cb(view_model, property, value);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                                        return _ret_var;
    }
}


namespace Efl {

/// <summary>Efl model providing helpers for custom properties used when linking a model to a view and you need to generate/adapt values for display.
/// There is two ways to use this class, you can either inherit from it and have a custom constructor for example. Or you can just instantiate it and manually define your property on it via callbacks.</summary>
[Efl.ViewModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class ViewModel : Efl.CompositeModel
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ViewModel))
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
        efl_view_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="childrenBind">Define if we will intercept all childrens object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity. See <see cref="Efl.ViewModel.SetChildrenBind" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public ViewModel(Efl.Object parent
            , Efl.IModel model, bool? childrenBind = null, uint? index = null) : base(efl_view_model_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
        {
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(childrenBind))
        {
            SetChildrenBind(Efl.Eo.Globals.GetParamHelper(childrenBind));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(index))
        {
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ViewModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ViewModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ViewModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Get the state of the automatic binding of children object.</summary>
    /// <returns>Do you automatically bind children. Default to true.</returns>
    virtual public bool GetChildrenBind() {
         var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_children_bind_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the state of the automatic binding of children object.</summary>
    /// <param name="enable">Do you automatically bind children. Default to true.</param>
    virtual public void SetChildrenBind(bool enable) {
                                 Efl.ViewModel.NativeMethods.efl_view_model_children_bind_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Adds a synthetic string property, generated from a <c>definition</c> string and other properties in the model.
    /// The <c>definition</c> string, similar to how <c>printf</c> works, contains ${} placeholders that are replaced by the actual value of the property inside the placeholder tags when the synthetic property is retrieved. For example, a numeric property <c>length</c> might be strange to use as a label, since it will only display a number. However, a synthetic string can be generated with the definition &quot;Length ${length}.&quot; which renders more nicely and does not require any more code by the user of the property.
    /// 
    /// <c>not_ready</c> and <c>on_error</c> strings can be given to be used when the data is not ready or there is some error, respectively. These strings do accept placeholder tags.
    /// 
    /// See <see cref="Efl.ViewModel.DelPropertyString"/></summary>
    /// <param name="name">The name for the new synthetic property.</param>
    /// <param name="definition">The definition string for the new synthetic property.</param>
    /// <param name="not_ready">The text to be used if any of the properties used in <c>definition</c> is not ready yet. If set to <c>null</c>, no check against EAGAIN will be done.</param>
    /// <param name="on_error">The text to be used if any of the properties used in <c>definition</c> is in error. It takes precedence over <c>not_ready</c>. If set to <c>null</c>, no error checks are performed.</param>
    virtual public Eina.Error AddPropertyString(System.String name, System.String definition, System.String not_ready, System.String on_error) {
                                                                                                         var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_string_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, definition, not_ready, on_error);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Delete a synthetic property previously defined by <see cref="Efl.ViewModel.AddPropertyString"/>.
    /// See <see cref="Efl.ViewModel.AddPropertyString"/></summary>
    /// <param name="name">The name of the synthetic property to delete.</param>
    virtual public Eina.Error DelPropertyString(System.String name) {
                                 var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_string_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add callbacks that will be triggered when someone ask for the specified property name when getting or setting a property.
    /// A get or set should at least be provided for this call to succeed.
    /// 
    /// See <see cref="Efl.ViewModel.DelPropertyLogic"/></summary>
    /// <param name="property">The property to bind on to.</param>
    /// <param name="get">Define the get callback called when the <see cref="Efl.IModel.GetProperty"/> is called with the above property name.</param>
    /// <param name="set">Define the set callback called when the <see cref="Efl.IModel.GetProperty"/> is called with the above property name.</param>
    /// <param name="binded">Iterator of property name to bind with this defined property see <see cref="Efl.ViewModel.PropertyBind"/>.</param>
    virtual public Eina.Error AddPropertyLogic(System.String property, EflViewModelPropertyGet get, EflViewModelPropertySet set, Eina.Iterator<System.String> binded) {
                                 var _in_binded = binded.Handle;
                                                GCHandle get_handle = GCHandle.Alloc(get);
        GCHandle set_handle = GCHandle.Alloc(set);
                var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_logic_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),property, GCHandle.ToIntPtr(get_handle), EflViewModelPropertyGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(set_handle), EflViewModelPropertySetWrapper.Cb, Efl.Eo.Globals.free_gchandle, _in_binded);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Delete previously added callbacks that were triggered when someone asked for the specified property name when getting or setting a property.
    /// A get or set should at least be provided for this call to succeed.
    /// 
    /// See <see cref="Efl.ViewModel.AddPropertyLogic"/></summary>
    /// <param name="property">The property to bind on to.</param>
    virtual public Eina.Error DelPropertyLogic(System.String property) {
                                 var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_logic_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),property);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Automatically update the field for the event <see cref="Efl.IModel.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.
    /// The source doesn&apos;t have to be provided at this point by the composited model.</summary>
    /// <param name="source">Property name in the composited model.</param>
    /// <param name="destination">Property name in the <see cref="Efl.ViewModel"/></param>
    virtual public void PropertyBind(System.String source, System.String destination) {
                                                         Efl.ViewModel.NativeMethods.efl_view_model_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),source, destination);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Stop automatically updating the field for the event <see cref="Efl.IModel.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.</summary>
    /// <param name="source">Property name in the composited model.</param>
    /// <param name="destination">Property name in the <see cref="Efl.ViewModel"/></param>
    virtual public void PropertyUnbind(System.String source, System.String destination) {
                                                         Efl.ViewModel.NativeMethods.efl_view_model_property_unbind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),source, destination);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Define if we will intercept all childrens object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity.
    /// This can only be applied at construction time.</summary>
    /// <value>Do you automatically bind children. Default to true.</value>
    public bool ChildrenBind {
        get { return GetChildrenBind(); }
        set { SetChildrenBind(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ViewModel.efl_view_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.CompositeModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_view_model_children_bind_get_static_delegate == null)
            {
                efl_view_model_children_bind_get_static_delegate = new efl_view_model_children_bind_get_delegate(children_bind_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetChildrenBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_children_bind_get"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_children_bind_get_static_delegate) });
            }

            if (efl_view_model_children_bind_set_static_delegate == null)
            {
                efl_view_model_children_bind_set_static_delegate = new efl_view_model_children_bind_set_delegate(children_bind_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetChildrenBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_children_bind_set"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_children_bind_set_static_delegate) });
            }

            if (efl_view_model_property_string_add_static_delegate == null)
            {
                efl_view_model_property_string_add_static_delegate = new efl_view_model_property_string_add_delegate(property_string_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddPropertyString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_string_add"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_string_add_static_delegate) });
            }

            if (efl_view_model_property_string_del_static_delegate == null)
            {
                efl_view_model_property_string_del_static_delegate = new efl_view_model_property_string_del_delegate(property_string_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelPropertyString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_string_del"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_string_del_static_delegate) });
            }

            if (efl_view_model_property_logic_add_static_delegate == null)
            {
                efl_view_model_property_logic_add_static_delegate = new efl_view_model_property_logic_add_delegate(property_logic_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddPropertyLogic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_logic_add"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_logic_add_static_delegate) });
            }

            if (efl_view_model_property_logic_del_static_delegate == null)
            {
                efl_view_model_property_logic_del_static_delegate = new efl_view_model_property_logic_del_delegate(property_logic_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelPropertyLogic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_logic_del"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_logic_del_static_delegate) });
            }

            if (efl_view_model_property_bind_static_delegate == null)
            {
                efl_view_model_property_bind_static_delegate = new efl_view_model_property_bind_delegate(property_bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "PropertyBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_bind_static_delegate) });
            }

            if (efl_view_model_property_unbind_static_delegate == null)
            {
                efl_view_model_property_unbind_static_delegate = new efl_view_model_property_unbind_delegate(property_unbind);
            }

            if (methods.FirstOrDefault(m => m.Name == "PropertyUnbind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_view_model_property_unbind"), func = Marshal.GetFunctionPointerForDelegate(efl_view_model_property_unbind_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.ViewModel.efl_view_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_view_model_children_bind_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_view_model_children_bind_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_view_model_children_bind_get_api_delegate> efl_view_model_children_bind_get_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_children_bind_get_api_delegate>(Module, "efl_view_model_children_bind_get");

        private static bool children_bind_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_view_model_children_bind_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ViewModel)ws.Target).GetChildrenBind();
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
                return efl_view_model_children_bind_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_view_model_children_bind_get_delegate efl_view_model_children_bind_get_static_delegate;

        
        private delegate void efl_view_model_children_bind_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_view_model_children_bind_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_view_model_children_bind_set_api_delegate> efl_view_model_children_bind_set_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_children_bind_set_api_delegate>(Module, "efl_view_model_children_bind_set");

        private static void children_bind_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_view_model_children_bind_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ViewModel)ws.Target).SetChildrenBind(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_view_model_children_bind_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_view_model_children_bind_set_delegate efl_view_model_children_bind_set_static_delegate;

        
        private delegate Eina.Error efl_view_model_property_string_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String definition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String not_ready, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String on_error);

        
        public delegate Eina.Error efl_view_model_property_string_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String definition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String not_ready, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String on_error);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_string_add_api_delegate> efl_view_model_property_string_add_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_string_add_api_delegate>(Module, "efl_view_model_property_string_add");

        private static Eina.Error property_string_add(System.IntPtr obj, System.IntPtr pd, System.String name, System.String definition, System.String not_ready, System.String on_error)
        {
            Eina.Log.Debug("function efl_view_model_property_string_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)ws.Target).AddPropertyString(name, definition, not_ready, on_error);
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
                return efl_view_model_property_string_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, definition, not_ready, on_error);
            }
        }

        private static efl_view_model_property_string_add_delegate efl_view_model_property_string_add_static_delegate;

        
        private delegate Eina.Error efl_view_model_property_string_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate Eina.Error efl_view_model_property_string_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_string_del_api_delegate> efl_view_model_property_string_del_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_string_del_api_delegate>(Module, "efl_view_model_property_string_del");

        private static Eina.Error property_string_del(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_view_model_property_string_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)ws.Target).DelPropertyString(name);
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
                return efl_view_model_property_string_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_view_model_property_string_del_delegate efl_view_model_property_string_del_static_delegate;

        
        private delegate Eina.Error efl_view_model_property_logic_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property,  IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb,  System.IntPtr binded);

        
        public delegate Eina.Error efl_view_model_property_logic_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property,  IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb,  System.IntPtr binded);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_logic_add_api_delegate> efl_view_model_property_logic_add_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_logic_add_api_delegate>(Module, "efl_view_model_property_logic_add");

        private static Eina.Error property_logic_add(System.IntPtr obj, System.IntPtr pd, System.String property, IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb, IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb, System.IntPtr binded)
        {
            Eina.Log.Debug("function efl_view_model_property_logic_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                var _in_binded = new Eina.Iterator<System.String>(binded, false);
                                                    EflViewModelPropertyGetWrapper get_wrapper = new EflViewModelPropertyGetWrapper(get, get_data, get_free_cb);
            EflViewModelPropertySetWrapper set_wrapper = new EflViewModelPropertySetWrapper(set, set_data, set_free_cb);
                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)ws.Target).AddPropertyLogic(property, get_wrapper.ManagedCb, set_wrapper.ManagedCb, _in_binded);
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
                return efl_view_model_property_logic_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), property, get_data, get, get_free_cb, set_data, set, set_free_cb, binded);
            }
        }

        private static efl_view_model_property_logic_add_delegate efl_view_model_property_logic_add_static_delegate;

        
        private delegate Eina.Error efl_view_model_property_logic_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        
        public delegate Eina.Error efl_view_model_property_logic_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_logic_del_api_delegate> efl_view_model_property_logic_del_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_logic_del_api_delegate>(Module, "efl_view_model_property_logic_del");

        private static Eina.Error property_logic_del(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            Eina.Log.Debug("function efl_view_model_property_logic_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)ws.Target).DelPropertyLogic(property);
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
                return efl_view_model_property_logic_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), property);
            }
        }

        private static efl_view_model_property_logic_del_delegate efl_view_model_property_logic_del_static_delegate;

        
        private delegate void efl_view_model_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String destination);

        
        public delegate void efl_view_model_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String destination);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_bind_api_delegate> efl_view_model_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_bind_api_delegate>(Module, "efl_view_model_property_bind");

        private static void property_bind(System.IntPtr obj, System.IntPtr pd, System.String source, System.String destination)
        {
            Eina.Log.Debug("function efl_view_model_property_bind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ViewModel)ws.Target).PropertyBind(source, destination);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_view_model_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), source, destination);
            }
        }

        private static efl_view_model_property_bind_delegate efl_view_model_property_bind_static_delegate;

        
        private delegate void efl_view_model_property_unbind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String destination);

        
        public delegate void efl_view_model_property_unbind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String destination);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_unbind_api_delegate> efl_view_model_property_unbind_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_unbind_api_delegate>(Module, "efl_view_model_property_unbind");

        private static void property_unbind(System.IntPtr obj, System.IntPtr pd, System.String source, System.String destination)
        {
            Eina.Log.Debug("function efl_view_model_property_unbind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ViewModel)ws.Target).PropertyUnbind(source, destination);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_view_model_property_unbind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), source, destination);
            }
        }

        private static efl_view_model_property_unbind_delegate efl_view_model_property_unbind_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

