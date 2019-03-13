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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_focus_util_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Util(Efl.Object parent= null
         ) :
      base(efl_ui_focus_util_class_get(), typeof(Util), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Util(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Util(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>Focus helper method</summary>
   /// <param name="focus_elem">Focus element</param>
   /// <returns></returns>
   public static  void Focus( Efl.Ui.Focus.Object focus_elem) {
                         Efl.Ui.Focus.UtilNativeInherit.efl_ui_focus_util_focus_ptr.Value.Delegate( focus_elem);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the highest manager in the redirect property</summary>
   /// <param name="manager"></param>
   /// <returns></returns>
   public static Efl.Ui.Focus.Manager ActiveManager( Efl.Ui.Focus.Manager manager) {
                         var _ret_var = Efl.Ui.Focus.UtilNativeInherit.efl_ui_focus_util_active_manager_ptr.Value.Delegate( manager);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary></summary>
   /// <param name="dir"></param>
   /// <returns></returns>
   public static Efl.Ui.Focus.Direction DirectionComplement( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = Efl.Ui.Focus.UtilNativeInherit.efl_ui_focus_util_direction_complement_ptr.Value.Delegate( dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.Util.efl_ui_focus_util_class_get();
   }
}
public class UtilNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
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


    private delegate  void efl_ui_focus_util_focus_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus_elem);


    public delegate  void efl_ui_focus_util_focus_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus_elem);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_focus_api_delegate> efl_ui_focus_util_focus_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_focus_api_delegate>(_Module, "efl_ui_focus_util_focus");
    private static  void focus(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object focus_elem)
   {
      Eina.Log.Debug("function efl_ui_focus_util_focus was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            Util.Focus( focus_elem);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_util_focus_ptr.Value.Delegate( focus_elem);
      }
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_util_active_manager_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager manager);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Manager efl_ui_focus_util_active_manager_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager manager);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_active_manager_api_delegate> efl_ui_focus_util_active_manager_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_active_manager_api_delegate>(_Module, "efl_ui_focus_util_active_manager");
    private static Efl.Ui.Focus.Manager active_manager(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager manager)
   {
      Eina.Log.Debug("function efl_ui_focus_util_active_manager was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = Util.ActiveManager( manager);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_util_active_manager_ptr.Value.Delegate( manager);
      }
   }


    private delegate Efl.Ui.Focus.Direction efl_ui_focus_util_direction_complement_delegate(  Efl.Ui.Focus.Direction dir);


    public delegate Efl.Ui.Focus.Direction efl_ui_focus_util_direction_complement_api_delegate(  Efl.Ui.Focus.Direction dir);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_util_direction_complement_api_delegate> efl_ui_focus_util_direction_complement_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_util_direction_complement_api_delegate>(_Module, "efl_ui_focus_util_direction_complement");
    private static Efl.Ui.Focus.Direction direction_complement(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_focus_util_direction_complement was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Direction _ret_var = default(Efl.Ui.Focus.Direction);
         try {
            _ret_var = Util.DirectionComplement( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_util_direction_complement_ptr.Value.Delegate( dir);
      }
   }
}
} } } 
