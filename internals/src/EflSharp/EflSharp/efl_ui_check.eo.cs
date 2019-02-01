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
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.CheckNativeInherit nativeInherit = new Efl.Ui.CheckNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Check))
            return Efl.Ui.CheckNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Check obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_check_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Check(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Check", efl_ui_check_class_get(), typeof(Check), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Check(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Check(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Check static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Check(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_check_selected_get(System.IntPtr obj);
   /// <summary>The on/off state of the check object.</summary>
   /// <returns><c>true</c> if the check object is selected, <c>false</c> otherwise</returns>
   virtual public bool GetSelected() {
       var _ret_var = efl_ui_check_selected_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_check_selected_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
   /// <summary>The on/off state of the check object.</summary>
   /// <param name="value"><c>true</c> if the check object is selected, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetSelected( bool value) {
                         efl_ui_check_selected_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The on/off state of the check object.</summary>
   public bool Selected {
      get { return GetSelected(); }
      set { SetSelected( value); }
   }
}
public class CheckNativeInherit : Efl.Ui.NstateNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_check_selected_get_static_delegate = new efl_ui_check_selected_get_delegate(selected_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_check_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_check_selected_get_static_delegate)});
      efl_ui_check_selected_set_static_delegate = new efl_ui_check_selected_set_delegate(selected_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_check_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_check_selected_set_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_check_selected_get(System.IntPtr obj);
    private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_check_selected_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
         return efl_ui_check_selected_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_check_selected_get_delegate efl_ui_check_selected_get_static_delegate;


    private delegate  void efl_ui_check_selected_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_check_selected_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
    private static  void selected_set(System.IntPtr obj, System.IntPtr pd,  bool value)
   {
      Eina.Log.Debug("function efl_ui_check_selected_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Check)wrapper).SetSelected( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_check_selected_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_ui_check_selected_set_delegate efl_ui_check_selected_set_static_delegate;
}
} } 
