#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Class used to create data models from Eina containers.
/// Each container supplied represents a series of property values, each item being the property value for a child object.
/// 
/// The data in the given containers are copied and stored internally.
/// 
/// Several containers can be supplied and the number of allocated children is based on the container of the largest size.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ContainerModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class ContainerModel : Efl.CompositeModel
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ContainerModel))
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
        efl_container_model_class_get();
    /// <summary>Initializes a new instance of the <see cref="ContainerModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public ContainerModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_container_model_class_get(), parent)
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

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ContainerModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ContainerModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ContainerModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ContainerModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ContainerModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Gets the type of the given property.</summary>
    /// <param name="name">Property name</param>
    /// <returns>Property type</returns>
    public virtual Eina.ValueType GetChildPropertyValueType(System.String name) {
                                 var _ret_var = Efl.ContainerModel.NativeMethods.efl_container_model_child_property_value_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds the given property to child objects and supply the values.
    /// Each item will represent the value of the given property in the respective child within the data model.
    /// 
    /// New children objects are allocated as necessary.
    /// 
    /// Value type is required for compatibility with the <see cref="Efl.IModel"/> API.</summary>
    /// <param name="name">Property name</param>
    /// <param name="type">Property type</param>
    /// <param name="values">Values to be added</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool AddChildProperty(System.String name, Eina.ValueType type, Eina.Iterator<System.IntPtr> values) {
                         var _in_values = values.Handle;
values.Own = false;
                                                        var _ret_var = Efl.ContainerModel.NativeMethods.efl_container_model_child_property_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, type, _in_values);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ContainerModel.efl_container_model_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.CompositeModel.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_container_model_child_property_value_type_get_static_delegate == null)
            {
                efl_container_model_child_property_value_type_get_static_delegate = new efl_container_model_child_property_value_type_get_delegate(child_property_value_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetChildPropertyValueType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_container_model_child_property_value_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_container_model_child_property_value_type_get_static_delegate) });
            }

            if (efl_container_model_child_property_add_static_delegate == null)
            {
                efl_container_model_child_property_add_static_delegate = new efl_container_model_child_property_add_delegate(child_property_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddChildProperty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_container_model_child_property_add"), func = Marshal.GetFunctionPointerForDelegate(efl_container_model_child_property_add_static_delegate) });
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
            return Efl.ContainerModel.efl_container_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueTypeMarshaler))]
        private delegate Eina.ValueTypeBox efl_container_model_child_property_value_type_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueTypeMarshaler))]
        public delegate Eina.ValueTypeBox efl_container_model_child_property_value_type_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_container_model_child_property_value_type_get_api_delegate> efl_container_model_child_property_value_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_container_model_child_property_value_type_get_api_delegate>(Module, "efl_container_model_child_property_value_type_get");

        private static Eina.ValueTypeBox child_property_value_type_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_container_model_child_property_value_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.ValueType _ret_var = default(Eina.ValueType);
                try
                {
                    _ret_var = ((ContainerModel)ws.Target).GetChildPropertyValueType(name);
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
                return efl_container_model_child_property_value_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_container_model_child_property_value_type_get_delegate efl_container_model_child_property_value_type_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_container_model_child_property_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueTypeMarshaler))] Eina.ValueTypeBox type,  System.IntPtr values);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_container_model_child_property_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueTypeMarshaler))] Eina.ValueTypeBox type,  System.IntPtr values);

        public static Efl.Eo.FunctionWrapper<efl_container_model_child_property_add_api_delegate> efl_container_model_child_property_add_ptr = new Efl.Eo.FunctionWrapper<efl_container_model_child_property_add_api_delegate>(Module, "efl_container_model_child_property_add");

        private static bool child_property_add(System.IntPtr obj, System.IntPtr pd, System.String name, Eina.ValueTypeBox type, System.IntPtr values)
        {
            Eina.Log.Debug("function efl_container_model_child_property_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        var _in_values = new Eina.Iterator<System.IntPtr>(values, true);
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ContainerModel)ws.Target).AddChildProperty(name, type, _in_values);
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
                return efl_container_model_child_property_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, type, values);
            }
        }

        private static efl_container_model_child_property_add_delegate efl_container_model_child_property_add_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflContainerModel_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
