#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Layout Factory class</summary>
[LayoutFactoryNativeInherit]
public class LayoutFactory : Efl.Ui.CachingFactory, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LayoutFactory))
                return Efl.Ui.LayoutFactoryNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_layout_factory_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="itemClass">Define the class of the item returned by this factory. See <see cref="Efl.Ui.WidgetFactory.SetItemClass"/></param>
    public LayoutFactory(Efl.Object parent
            , Type itemClass = null) :
        base(efl_ui_layout_factory_class_get(), typeof(LayoutFactory), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(itemClass))
            SetItemClass(Efl.Eo.Globals.GetParamHelper(itemClass));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LayoutFactory(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LayoutFactory(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>No description supplied.</summary>
    /// <param name="klass">The class of the group.</param>
    /// <param name="group">The group.</param>
    /// <param name="style">The style to used.</param>
    /// <returns></returns>
    virtual public void ThemeConfig( System.String klass,  System.String group,  System.String style) {
                                                                                 Efl.Ui.LayoutFactoryNativeInherit.efl_ui_layout_factory_theme_config_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), klass,  group,  style);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutFactory.efl_ui_layout_factory_class_get();
    }
}
public class LayoutFactoryNativeInherit : Efl.Ui.CachingFactoryNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_layout_factory_theme_config_static_delegate == null)
            efl_ui_layout_factory_theme_config_static_delegate = new efl_ui_layout_factory_theme_config_delegate(theme_config);
        if (methods.FirstOrDefault(m => m.Name == "ThemeConfig") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_layout_factory_theme_config"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_factory_theme_config_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.LayoutFactory.efl_ui_layout_factory_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutFactory.efl_ui_layout_factory_class_get();
    }


     private delegate void efl_ui_layout_factory_theme_config_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String klass,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String group,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String style);


     public delegate void efl_ui_layout_factory_theme_config_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String klass,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String group,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String style);
     public static Efl.Eo.FunctionWrapper<efl_ui_layout_factory_theme_config_api_delegate> efl_ui_layout_factory_theme_config_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_factory_theme_config_api_delegate>(_Module, "efl_ui_layout_factory_theme_config");
     private static void theme_config(System.IntPtr obj, System.IntPtr pd,  System.String klass,  System.String group,  System.String style)
    {
        Eina.Log.Debug("function efl_ui_layout_factory_theme_config was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((LayoutFactory)wrapper).ThemeConfig( klass,  group,  style);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_layout_factory_theme_config_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass,  group,  style);
        }
    }
    private static efl_ui_layout_factory_theme_config_delegate efl_ui_layout_factory_theme_config_static_delegate;
}
} } 
