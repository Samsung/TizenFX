#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Class to be used to store object item size for List/Grid View.
/// This model provide &quot;<c>total</c>.width&quot; and &quot;<c>total</c>.height&quot; as an accumulated size of all its children &quot;<c>self</c>.width&quot; and &quot;<c>self</c>.height&quot; <see cref="Efl.IModel.GetProperty"/>. This is currently assuming a vertical list only.
/// 
/// This model will return an error code EAGAIN for &quot;<c>item</c>.width&quot; and &quot;<c>item</c>.height&quot; all the time and the View that use this Model should continue to get this value even after computing all the &quot;<c>self</c>.width&quot; and &quot;<c>self</c>.height&quot; of this object children.</summary>
[ExactModelNativeInherit]
public class ExactModel : Efl.Ui.SizeModel, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ExactModel))
                return Efl.Ui.ExactModelNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_exact_model_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel"/></param>
    ///<param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
    public ExactModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) :
        base(efl_ui_exact_model_class_get(), typeof(ExactModel), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        if (Efl.Eo.Globals.ParamHelperCheck(index))
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ExactModel(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ExactModel(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ExactModel.efl_ui_exact_model_class_get();
    }
}
public class ExactModelNativeInherit : Efl.Ui.SizeModelNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.ExactModel.efl_ui_exact_model_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ExactModel.efl_ui_exact_model_class_get();
    }
}
} } 
