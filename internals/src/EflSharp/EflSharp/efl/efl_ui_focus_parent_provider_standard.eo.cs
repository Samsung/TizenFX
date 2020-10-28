#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>EFL UI Focus Parent Provider Standard Class</summary>
[ParentProviderStandardNativeInherit]
public class ParentProviderStandard : Efl.Object, Efl.Eo.IWrapper,Efl.Ui.Focus.IParentProvider
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ParentProviderStandard))
                return Efl.Ui.Focus.ParentProviderStandardNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_parent_provider_standard_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public ParentProviderStandard(Efl.Object parent= null
            ) :
        base(efl_ui_focus_parent_provider_standard_class_get(), typeof(ParentProviderStandard), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ParentProviderStandard(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ParentProviderStandard(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Called to get the logical parent of widget</summary>
    /// <param name="widget">Object to find parent for</param>
    /// <returns>Parent of parameter object</returns>
    virtual public Efl.Ui.Focus.IObject FindLogicalParent( Efl.Ui.Focus.IObject widget) {
                                 var _ret_var = Efl.Ui.Focus.IParentProviderNativeInherit.efl_ui_focus_parent_provider_find_logical_parent_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), widget);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.ParentProviderStandard.efl_ui_focus_parent_provider_standard_class_get();
    }
}
public class ParentProviderStandardNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_focus_parent_provider_find_logical_parent_static_delegate == null)
            efl_ui_focus_parent_provider_find_logical_parent_static_delegate = new efl_ui_focus_parent_provider_find_logical_parent_delegate(find_logical_parent);
        if (methods.FirstOrDefault(m => m.Name == "FindLogicalParent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_parent_provider_find_logical_parent"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_parent_provider_find_logical_parent_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Focus.ParentProviderStandard.efl_ui_focus_parent_provider_standard_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.ParentProviderStandard.efl_ui_focus_parent_provider_standard_class_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.IObject efl_ui_focus_parent_provider_find_logical_parent_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.IObject widget);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.IObject efl_ui_focus_parent_provider_find_logical_parent_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.IObject widget);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_parent_provider_find_logical_parent_api_delegate> efl_ui_focus_parent_provider_find_logical_parent_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_parent_provider_find_logical_parent_api_delegate>(_Module, "efl_ui_focus_parent_provider_find_logical_parent");
     private static Efl.Ui.Focus.IObject find_logical_parent(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.IObject widget)
    {
        Eina.Log.Debug("function efl_ui_focus_parent_provider_find_logical_parent was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
            try {
                _ret_var = ((ParentProviderStandard)wrapper).FindLogicalParent( widget);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_focus_parent_provider_find_logical_parent_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  widget);
        }
    }
    private static efl_ui_focus_parent_provider_find_logical_parent_delegate efl_ui_focus_parent_provider_find_logical_parent_static_delegate;
}
} } } 
