#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Used internally for futures on the loop</summary>
[LoopMessageFutureNativeInherit]
public class LoopMessageFuture : Efl.LoopMessage, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LoopMessageFuture))
                return Efl.LoopMessageFutureNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_message_future_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public LoopMessageFuture(Efl.Object parent= null
            ) :
        base(efl_loop_message_future_class_get(), typeof(LoopMessageFuture), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LoopMessageFuture(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LoopMessageFuture(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <returns>No description supplied.</returns>
    virtual public System.IntPtr GetData() {
         var _ret_var = Efl.LoopMessageFutureNativeInherit.efl_loop_message_future_data_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>No description supplied.</summary>
    /// <param name="data">No description supplied.</param>
    /// <returns></returns>
    virtual public void SetData( System.IntPtr data) {
                                 Efl.LoopMessageFutureNativeInherit.efl_loop_message_future_data_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>No description supplied.</summary>
/// <value>No description supplied.</value>
    public System.IntPtr Data {
        get { return GetData(); }
        set { SetData( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageFuture.efl_loop_message_future_class_get();
    }
}
public class LoopMessageFutureNativeInherit : Efl.LoopMessageNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_loop_message_future_data_get_static_delegate == null)
            efl_loop_message_future_data_get_static_delegate = new efl_loop_message_future_data_get_delegate(data_get);
        if (methods.FirstOrDefault(m => m.Name == "GetData") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_future_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_data_get_static_delegate)});
        if (efl_loop_message_future_data_set_static_delegate == null)
            efl_loop_message_future_data_set_static_delegate = new efl_loop_message_future_data_set_delegate(data_set);
        if (methods.FirstOrDefault(m => m.Name == "SetData") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_future_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_data_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.LoopMessageFuture.efl_loop_message_future_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageFuture.efl_loop_message_future_class_get();
    }


     private delegate System.IntPtr efl_loop_message_future_data_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_loop_message_future_data_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_message_future_data_get_api_delegate> efl_loop_message_future_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_future_data_get_api_delegate>(_Module, "efl_loop_message_future_data_get");
     private static System.IntPtr data_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_message_future_data_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.IntPtr _ret_var = default(System.IntPtr);
            try {
                _ret_var = ((LoopMessageFuture)wrapper).GetData();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_message_future_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_message_future_data_get_delegate efl_loop_message_future_data_get_static_delegate;


     private delegate void efl_loop_message_future_data_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr data);


     public delegate void efl_loop_message_future_data_set_api_delegate(System.IntPtr obj,   System.IntPtr data);
     public static Efl.Eo.FunctionWrapper<efl_loop_message_future_data_set_api_delegate> efl_loop_message_future_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_future_data_set_api_delegate>(_Module, "efl_loop_message_future_data_set");
     private static void data_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data)
    {
        Eina.Log.Debug("function efl_loop_message_future_data_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LoopMessageFuture)wrapper).SetData( data);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_message_future_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  data);
        }
    }
    private static efl_loop_message_future_data_set_delegate efl_loop_message_future_data_set_static_delegate;
}
} 
