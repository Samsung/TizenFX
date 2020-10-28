#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>An inlined window.
/// The window is rendered onto an image buffer. No actual window is created, instead the window and all of its contents will be rendered to an image buffer. This allows child windows inside a parent just like any other object.  You can also do other things like apply map effects. This window must have a valid <see cref="Efl.Canvas.Object"/> parent.</summary>
[WinInlinedNativeInherit]
public class WinInlined : Efl.Ui.Win, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (WinInlined))
                return Efl.Ui.WinInlinedNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_win_inlined_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    ///<param name="winName">The window name. See <see cref="Efl.Ui.Win.SetWinName"/></param>
    ///<param name="winType">The type of the window. See <see cref="Efl.Ui.Win.SetWinType"/></param>
    ///<param name="accelPreference">The hardware acceleration preference for this window. See <see cref="Efl.Ui.Win.SetAccelPreference"/></param>
    public WinInlined(Efl.Object parent
            , System.String style = null, System.String winName = null, Efl.Ui.WinType? winType = null, System.String accelPreference = null) :
        base(efl_ui_win_inlined_class_get(), typeof(WinInlined), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        if (Efl.Eo.Globals.ParamHelperCheck(winName))
            SetWinName(Efl.Eo.Globals.GetParamHelper(winName));
        if (Efl.Eo.Globals.ParamHelperCheck(winType))
            SetWinType(Efl.Eo.Globals.GetParamHelper(winType));
        if (Efl.Eo.Globals.ParamHelperCheck(accelPreference))
            SetAccelPreference(Efl.Eo.Globals.GetParamHelper(accelPreference));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected WinInlined(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected WinInlined(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>This property holds the parent object in the parent canvas.</summary>
    /// <returns>An object in the parent canvas.</returns>
    virtual public Efl.Canvas.Object GetInlinedParent() {
         var _ret_var = Efl.Ui.WinInlinedNativeInherit.efl_ui_win_inlined_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the parent object in the parent canvas.</summary>
/// <value>An object in the parent canvas.</value>
    public Efl.Canvas.Object InlinedParent {
        get { return GetInlinedParent(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinInlined.efl_ui_win_inlined_class_get();
    }
}
public class WinInlinedNativeInherit : Efl.Ui.WinNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_win_inlined_parent_get_static_delegate == null)
            efl_ui_win_inlined_parent_get_static_delegate = new efl_ui_win_inlined_parent_get_delegate(inlined_parent_get);
        if (methods.FirstOrDefault(m => m.Name == "GetInlinedParent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_win_inlined_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_inlined_parent_get_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.WinInlined.efl_ui_win_inlined_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WinInlined.efl_ui_win_inlined_class_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_win_inlined_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_ui_win_inlined_parent_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_win_inlined_parent_get_api_delegate> efl_ui_win_inlined_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_inlined_parent_get_api_delegate>(_Module, "efl_ui_win_inlined_parent_get");
     private static Efl.Canvas.Object inlined_parent_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_win_inlined_parent_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
            try {
                _ret_var = ((WinInlined)wrapper).GetInlinedParent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_win_inlined_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_win_inlined_parent_get_delegate efl_ui_win_inlined_parent_get_static_delegate;
}
} } 
