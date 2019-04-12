#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>A interface to indicate the end of a focus chain.
/// Focusmanagers are ensuring that if they give focus to something, that they are registered in the upper focus manager. The most upper focus manager does not need to do that, and can implement this interface to indicate that.
/// (Since EFL 1.22)</summary>
[IManagerWindowRootNativeInherit]
public interface IManagerWindowRoot : 
    Efl.Eo.IWrapper, IDisposable
{
}
/// <summary>A interface to indicate the end of a focus chain.
/// Focusmanagers are ensuring that if they give focus to something, that they are registered in the upper focus manager. The most upper focus manager does not need to do that, and can implement this interface to indicate that.
/// (Since EFL 1.22)</summary>
sealed public class IManagerWindowRootConcrete : 

IManagerWindowRoot
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IManagerWindowRootConcrete))
                return Efl.Ui.Focus.IManagerWindowRootNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_manager_window_root_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IManagerWindowRootConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IManagerWindowRootConcrete()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero) {
            Efl.Eo.Globals.efl_unref(handle);
            handle = System.IntPtr.Zero;
        }
    }
    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
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
     void RegisterEventProxies()
    {
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
    }
}
public class IManagerWindowRootNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Focus.IManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IManagerWindowRootConcrete.efl_ui_focus_manager_window_root_interface_get();
    }
}
} } } 
