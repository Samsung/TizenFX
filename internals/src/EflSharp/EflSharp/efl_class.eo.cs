#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Abstract Efl class</summary>
[ClassNativeInherit]
public class Class :  Efl.Eo.IWrapper, IDisposable
{
   public static System.IntPtr klass = System.IntPtr.Zero;
   public static Efl.ClassNativeInherit nativeInherit = new Efl.ClassNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public virtual System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Class))
            return Efl.ClassNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private static readonly object klassAllocLock = new object();
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
   public Class(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   protected Class(IntPtr base_klass, System.Type managed_type, Efl.Object parent)
   {
      inherited = ((object)this).GetType() != managed_type;
      IntPtr actual_klass = base_klass;
      if (inherited) {
         actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(base_klass, ((object)this).GetType());
      }
      handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
      register_event_proxies();
   }
   protected void FinishInstantiation()
   {
      if (inherited) {
         Efl.Eo.Globals.data_set(this);
      }
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
   ///<summary>Casts obj into an instance of this type.</summary>
   public static Class static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Class(obj.NativeHandle);
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
   protected virtual void register_event_proxies()
   {
   }
   private static  IntPtr GetEflClassStatic()
   {
      return Efl.Class.efl_class_class_get();
   }
}
public class ClassNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Eo);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
