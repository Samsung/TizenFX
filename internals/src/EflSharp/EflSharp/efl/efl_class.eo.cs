#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Abstract Efl class
/// (Since EFL 1.22)</summary>
[ClassNativeInherit]
public abstract class Class :  Efl.Eo.IWrapper, IDisposable
{
    ///<summary>Pointer to the native class description.</summary>
    public virtual System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Class))
                return Efl.ClassNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    protected bool inherited;
    protected  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] internal static extern System.IntPtr
        efl_class_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Class(Efl.Object parent= null
            ) :
        this(efl_class_class_get(), typeof(Class), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Class(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    [Efl.Eo.PrivateNativeClass]
    private class ClassRealized : Class
    {
        private ClassRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    protected Class(IntPtr base_klass, System.Type managed_type, Efl.Object parent)
    {
        inherited = ((object)this).GetType() != managed_type;
        IntPtr actual_klass = base_klass;
        if (inherited) {
            actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(base_klass, ((object)this).GetType());
        }
        handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
        RegisterEventProxies();
        if (inherited)
        {
            Efl.Eo.Globals.PrivateDataSet(this);
        }
    }
    protected void FinishInstantiation()
    {
        handle = Efl.Eo.Globals.instantiate_end(handle);
        Eina.Error.RaiseIfUnhandledException();
    }
    ///<summary>Destructor.</summary>
    ~Class()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
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
    protected virtual void RegisterEventProxies()
    {
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Class.efl_class_class_get();
    }
}
public class ClassNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Eo);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Class.efl_class_class_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Class.efl_class_class_get();
    }
}
} 
