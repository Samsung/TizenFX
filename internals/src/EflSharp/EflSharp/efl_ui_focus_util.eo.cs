#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>EFL UI Focus Util class</summary>
[UtilNativeInherit]
public class Util : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.Focus.UtilNativeInherit nativeInherit = new Efl.Ui.Focus.UtilNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Util))
            return Efl.Ui.Focus.UtilNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Util obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_focus_util_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Util(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Util", efl_ui_focus_util_class_get(), typeof(Util), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Util(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Util(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Util static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Util(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_util_focus(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus_elem);
   /// <summary>Focus helper method</summary>
   /// <param name="focus_elem">Focus element</param>
   /// <returns></returns>
   public static  void Focus( Efl.Ui.Focus.Object focus_elem) {
                         efl_ui_focus_util_focus(Efl.Ui.Focus.Util.efl_ui_focus_util_class_get(),  focus_elem);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_focus_util_active_manager(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager manager);
   /// <summary>Get the highest manager in the redirect property</summary>
   /// <param name="manager"></param>
   /// <returns></returns>
   public static Efl.Ui.Focus.Manager ActiveManager( Efl.Ui.Focus.Manager manager) {
                         var _ret_var = efl_ui_focus_util_active_manager(Efl.Ui.Focus.Util.efl_ui_focus_util_class_get(),  manager);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.Focus.Direction efl_ui_focus_util_direction_complement(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
   /// <summary></summary>
   /// <param name="dir"></param>
   /// <returns></returns>
   public static Efl.Ui.Focus.Direction DirectionComplement( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = efl_ui_focus_util_direction_complement(Efl.Ui.Focus.Util.efl_ui_focus_util_class_get(),  dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
}
public class UtilNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Focus.Util.efl_ui_focus_util_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.Util.efl_ui_focus_util_class_get();
   }
}
} } } 
