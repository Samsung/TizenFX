#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="view_model">The ViewModel object the @.property.get is issued on.</param>
/// <param name="property">The property name the @.property.get is issued on.</param>
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
public class ViewModel : Efl.CompositeModel, Efl.Eo.IWrapper
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
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel"/></param>
    /// <param name="childrenBind">Define if we will intercept all childrens object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity. See <see cref="Efl.ViewModel.SetChildrenBind"/></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
    public ViewModel(Efl.Object parent
            , Efl.IModel model, bool? childrenBind = null, uint? index = null) : base(efl_view_model_class_get(), typeof(ViewModel), parent)
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

    /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected ViewModel(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ViewModel(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Get the state of the automatic binding of children object.</summary>
    /// <returns>Do you automatically bind children. Default to true.</returns>
    virtual public bool GetChildrenBind() {
         var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_children_bind_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the state of the automatic binding of children object.</summary>
    /// <param name="enable">Do you automatically bind children. Default to true.</param>
    virtual public void SetChildrenBind(bool enable) {
                                 Efl.ViewModel.NativeMethods.efl_view_model_children_bind_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),enable);
        Eina.Error.RaiseIfUnhandledException();
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
                var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_logic_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),property, GCHandle.ToIntPtr(get_handle), EflViewModelPropertyGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(set_handle), EflViewModelPropertySetWrapper.Cb, Efl.Eo.Globals.free_gchandle, _in_binded);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Delete previously added callbacks that were triggered when someone asked for the specified property name when getting or setting a property.
    /// A get or set should at least be provided for this call to succeed.
    /// 
    /// See <see cref="Efl.ViewModel.AddPropertyLogic"/></summary>
    /// <param name="property">The property to bind on to.</param>
    virtual public Eina.Error DelPropertyLogic(System.String property) {
                                 var _ret_var = Efl.ViewModel.NativeMethods.efl_view_model_property_logic_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),property);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Automatically update the field for the event <see cref="Efl.IModel.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.
    /// The source doesn&apos;t have to be provided at this point by the composited model.</summary>
    /// <param name="source">Property name in the composited model.</param>
    /// <param name="destination">Property name in the <see cref="Efl.ViewModel"/></param>
    virtual public void PropertyBind(System.String source, System.String destination) {
                                                         Efl.ViewModel.NativeMethods.efl_view_model_property_bind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),source, destination);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Stop automatically updating the field for the event <see cref="Efl.IModel.PropertiesChangedEvt"/> to include property that are impacted with change in a property from the composited model.</summary>
    /// <param name="source">Property name in the composited model.</param>
    /// <param name="destination">Property name in the <see cref="Efl.ViewModel"/></param>
    virtual public void PropertyUnbind(System.String source, System.String destination) {
                                                         Efl.ViewModel.NativeMethods.efl_view_model_property_unbind_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),source, destination);
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

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_view_model_children_bind_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_view_model_children_bind_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_view_model_children_bind_get_api_delegate> efl_view_model_children_bind_get_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_children_bind_get_api_delegate>(Module, "efl_view_model_children_bind_get");

        private static bool children_bind_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_view_model_children_bind_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ViewModel)wrapper).GetChildrenBind();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((ViewModel)wrapper).SetChildrenBind(enable);
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

        
        private delegate Eina.Error efl_view_model_property_logic_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property,  IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb,  System.IntPtr binded);

        
        public delegate Eina.Error efl_view_model_property_logic_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property,  IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb,  IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb,  System.IntPtr binded);

        public static Efl.Eo.FunctionWrapper<efl_view_model_property_logic_add_api_delegate> efl_view_model_property_logic_add_ptr = new Efl.Eo.FunctionWrapper<efl_view_model_property_logic_add_api_delegate>(Module, "efl_view_model_property_logic_add");

        private static Eina.Error property_logic_add(System.IntPtr obj, System.IntPtr pd, System.String property, IntPtr get_data, EflViewModelPropertyGetInternal get, EinaFreeCb get_free_cb, IntPtr set_data, EflViewModelPropertySetInternal set, EinaFreeCb set_free_cb, System.IntPtr binded)
        {
            Eina.Log.Debug("function efl_view_model_property_logic_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                var _in_binded = new Eina.Iterator<System.String>(binded, false, false);
                                                    EflViewModelPropertyGetWrapper get_wrapper = new EflViewModelPropertyGetWrapper(get, get_data, get_free_cb);
            EflViewModelPropertySetWrapper set_wrapper = new EflViewModelPropertySetWrapper(set, set_data, set_free_cb);
                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)wrapper).AddPropertyLogic(property, get_wrapper.ManagedCb, set_wrapper.ManagedCb, _in_binded);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((ViewModel)wrapper).DelPropertyLogic(property);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((ViewModel)wrapper).PropertyBind(source, destination);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((ViewModel)wrapper).PropertyUnbind(source, destination);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

