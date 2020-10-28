#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Check widget
/// The check widget allows for toggling a value between true and false. Check objects are a lot like radio objects in layout and functionality, except they do not work as a group, but independently, and only toggle the value of a boolean between false and true.</summary>
[CheckNativeInherit]
public class Check : Efl.Ui.Nstate, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Check))
                return Efl.Ui.CheckNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_check_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Check(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_check_class_get(), typeof(Check), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Check(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Check(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>The on/off state of the check object.</summary>
    /// <returns><c>true</c> if the check object is selected, <c>false</c> otherwise</returns>
    virtual public bool GetSelected() {
         var _ret_var = Efl.Ui.CheckNativeInherit.efl_ui_check_selected_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The on/off state of the check object.</summary>
    /// <param name="value"><c>true</c> if the check object is selected, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetSelected( bool value) {
                                 Efl.Ui.CheckNativeInherit.efl_ui_check_selected_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The on/off state of the check object.</summary>
/// <value><c>true</c> if the check object is selected, <c>false</c> otherwise</value>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Check.efl_ui_check_class_get();
    }
}
public class CheckNativeInherit : Efl.Ui.NstateNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_check_selected_get_static_delegate == null)
            efl_ui_check_selected_get_static_delegate = new efl_ui_check_selected_get_delegate(selected_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSelected") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_check_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_check_selected_get_static_delegate)});
        if (efl_ui_check_selected_set_static_delegate == null)
            efl_ui_check_selected_set_static_delegate = new efl_ui_check_selected_set_delegate(selected_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSelected") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_check_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_check_selected_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Check.efl_ui_check_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Check.efl_ui_check_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_check_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_check_selected_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_check_selected_get_api_delegate> efl_ui_check_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_check_selected_get_api_delegate>(_Module, "efl_ui_check_selected_get");
     private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_check_selected_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Check)wrapper).GetSelected();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_check_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_check_selected_get_delegate efl_ui_check_selected_get_static_delegate;


     private delegate void efl_ui_check_selected_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool value);


     public delegate void efl_ui_check_selected_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
     public static Efl.Eo.FunctionWrapper<efl_ui_check_selected_set_api_delegate> efl_ui_check_selected_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_check_selected_set_api_delegate>(_Module, "efl_ui_check_selected_set");
     private static void selected_set(System.IntPtr obj, System.IntPtr pd,  bool value)
    {
        Eina.Log.Debug("function efl_ui_check_selected_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Check)wrapper).SetSelected( value);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_check_selected_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
        }
    }
    private static efl_ui_check_selected_set_delegate efl_ui_check_selected_set_static_delegate;
}
} } 
