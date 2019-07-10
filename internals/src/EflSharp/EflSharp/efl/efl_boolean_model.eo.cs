#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl boolean model class</summary>
[Efl.BooleanModel.NativeMethods]
public class BooleanModel : Efl.CompositeModel
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(BooleanModel))
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
        efl_boolean_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="BooleanModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel"/></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
    public BooleanModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_boolean_model_class_get(), typeof(BooleanModel), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
        {
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(index))
        {
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="BooleanModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected BooleanModel(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="BooleanModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected BooleanModel(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Add a new named boolean property with a defined default value.</summary>
    virtual public void AddBoolean(System.String name, bool default_value) {
                                                         Efl.BooleanModel.NativeMethods.efl_boolean_model_boolean_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name, default_value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Delete an existing named boolean property</summary>
    virtual public void DelBoolean(System.String name) {
                                 Efl.BooleanModel.NativeMethods.efl_boolean_model_boolean_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get an iterator that will quickly find all the index with the requested value for a specific boolean.</summary>
    /// <returns>The iterator that is valid until any change is made on the model.</returns>
    virtual public Eina.Iterator<ulong> GetBooleanIterator(System.String name, bool request) {
                                                         var _ret_var = Efl.BooleanModel.NativeMethods.efl_boolean_model_boolean_iterator_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),name, request);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.Iterator<ulong>(_ret_var, false, false);
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.BooleanModel.efl_boolean_model_class_get();
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

            if (efl_boolean_model_boolean_add_static_delegate == null)
            {
                efl_boolean_model_boolean_add_static_delegate = new efl_boolean_model_boolean_add_delegate(boolean_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddBoolean") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_boolean_model_boolean_add"), func = Marshal.GetFunctionPointerForDelegate(efl_boolean_model_boolean_add_static_delegate) });
            }

            if (efl_boolean_model_boolean_del_static_delegate == null)
            {
                efl_boolean_model_boolean_del_static_delegate = new efl_boolean_model_boolean_del_delegate(boolean_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelBoolean") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_boolean_model_boolean_del"), func = Marshal.GetFunctionPointerForDelegate(efl_boolean_model_boolean_del_static_delegate) });
            }

            if (efl_boolean_model_boolean_iterator_get_static_delegate == null)
            {
                efl_boolean_model_boolean_iterator_get_static_delegate = new efl_boolean_model_boolean_iterator_get_delegate(boolean_iterator_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBooleanIterator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_boolean_model_boolean_iterator_get"), func = Marshal.GetFunctionPointerForDelegate(efl_boolean_model_boolean_iterator_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.BooleanModel.efl_boolean_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_boolean_model_boolean_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.U1)] bool default_value);

        
        public delegate void efl_boolean_model_boolean_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.U1)] bool default_value);

        public static Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_add_api_delegate> efl_boolean_model_boolean_add_ptr = new Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_add_api_delegate>(Module, "efl_boolean_model_boolean_add");

        private static void boolean_add(System.IntPtr obj, System.IntPtr pd, System.String name, bool default_value)
        {
            Eina.Log.Debug("function efl_boolean_model_boolean_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((BooleanModel)ws.Target).AddBoolean(name, default_value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_boolean_model_boolean_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, default_value);
            }
        }

        private static efl_boolean_model_boolean_add_delegate efl_boolean_model_boolean_add_static_delegate;

        
        private delegate void efl_boolean_model_boolean_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_boolean_model_boolean_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_del_api_delegate> efl_boolean_model_boolean_del_ptr = new Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_del_api_delegate>(Module, "efl_boolean_model_boolean_del");

        private static void boolean_del(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_boolean_model_boolean_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((BooleanModel)ws.Target).DelBoolean(name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_boolean_model_boolean_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_boolean_model_boolean_del_delegate efl_boolean_model_boolean_del_static_delegate;

        
        private delegate System.IntPtr efl_boolean_model_boolean_iterator_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.U1)] bool request);

        
        public delegate System.IntPtr efl_boolean_model_boolean_iterator_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.U1)] bool request);

        public static Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_iterator_get_api_delegate> efl_boolean_model_boolean_iterator_get_ptr = new Efl.Eo.FunctionWrapper<efl_boolean_model_boolean_iterator_get_api_delegate>(Module, "efl_boolean_model_boolean_iterator_get");

        private static System.IntPtr boolean_iterator_get(System.IntPtr obj, System.IntPtr pd, System.String name, bool request)
        {
            Eina.Log.Debug("function efl_boolean_model_boolean_iterator_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Iterator<ulong> _ret_var = default(Eina.Iterator<ulong>);
                try
                {
                    _ret_var = ((BooleanModel)ws.Target).GetBooleanIterator(name, request);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var.Handle;

            }
            else
            {
                return efl_boolean_model_boolean_iterator_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, request);
            }
        }

        private static efl_boolean_model_boolean_iterator_get_delegate efl_boolean_model_boolean_iterator_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

