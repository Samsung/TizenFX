#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary radio class</summary>
[RadioNativeInherit]
public class Radio : Efl.Ui.Check, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.RadioNativeInherit nativeInherit = new Efl.Ui.RadioNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Radio))
            return Efl.Ui.RadioNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Radio obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_radio_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Radio(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Radio", efl_ui_radio_class_get(), typeof(Radio), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Radio(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Radio(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Radio static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Radio(obj.NativeHandle);
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
    protected static extern  int efl_ui_radio_state_value_get(System.IntPtr obj);
   /// <summary>Get the integer value that this radio object represents.
   /// This gets the value of the radio.</summary>
   /// <returns>The value to use if this radio object is selected.</returns>
   virtual public  int GetStateValue() {
       var _ret_var = efl_ui_radio_state_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_radio_state_value_set(System.IntPtr obj,    int value);
   /// <summary>Set the integer value that this radio object represents.
   /// This sets the value of the radio.</summary>
   /// <param name="value">The value to use if this radio object is selected.</param>
   /// <returns></returns>
   virtual public  void SetStateValue(  int value) {
                         efl_ui_radio_state_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_radio_value_pointer_set(System.IntPtr obj,    System.IntPtr valuep);
   /// <summary>Set a convenience pointer to an integer, which changes when radio group value changes.
   /// This sets a pointer to an integer that in addition to the radio object state will also be modified directly. To stop setting the object pointed to, simply use NULL as the valuep argument. If valuep is not NULL then when called, the radio object state will also be modified to reflect the value of the integer valuep points to, just like calling elm_radio_value_set().</summary>
   /// <param name="valuep">Pointer to the integer to modify</param>
   /// <returns></returns>
   virtual public  void SetValuePointer(  int valuep) {
       var _in_valuep = Eina.PrimitiveConversion.ManagedToPointerAlloc(valuep);
                  efl_ui_radio_value_pointer_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_valuep);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_radio_selected_object_get(System.IntPtr obj);
   /// <summary>Get the selected radio object.</summary>
   /// <returns>The selected radio object</returns>
   virtual public Efl.Canvas.Object GetSelectedObject() {
       var _ret_var = efl_ui_radio_selected_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_radio_group_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Radio, Efl.Eo.NonOwnTag>))]  Efl.Ui.Radio group);
   /// <summary>Add this radio to a group of other radio objects
   /// Radio objects work in groups. Each member should have a different integer value assigned. In order to have them work as a group, they need to know about each other. This adds the given radio object to the group of which the group object indicated is a member.</summary>
   /// <param name="group">Any radio object whose group the obj is to join.</param>
   /// <returns></returns>
   virtual public  void AddGroup( Efl.Ui.Radio group) {
                         efl_ui_radio_group_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  group);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the integer value that this radio object represents.
/// This gets the value of the radio.</summary>
   public  int StateValue {
      get { return GetStateValue(); }
      set { SetStateValue( value); }
   }
   /// <summary>Set a convenience pointer to an integer, which changes when radio group value changes.
/// This sets a pointer to an integer that in addition to the radio object state will also be modified directly. To stop setting the object pointed to, simply use NULL as the valuep argument. If valuep is not NULL then when called, the radio object state will also be modified to reflect the value of the integer valuep points to, just like calling elm_radio_value_set().</summary>
   public  int ValuePointer {
      set { SetValuePointer( value); }
   }
   /// <summary>Get the selected radio object.</summary>
   public Efl.Canvas.Object SelectedObject {
      get { return GetSelectedObject(); }
   }
}
public class RadioNativeInherit : Efl.Ui.CheckNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_radio_state_value_get_static_delegate = new efl_ui_radio_state_value_get_delegate(state_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_radio_state_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_get_static_delegate)});
      efl_ui_radio_state_value_set_static_delegate = new efl_ui_radio_state_value_set_delegate(state_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_radio_state_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_set_static_delegate)});
      efl_ui_radio_value_pointer_set_static_delegate = new efl_ui_radio_value_pointer_set_delegate(value_pointer_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_radio_value_pointer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_value_pointer_set_static_delegate)});
      efl_ui_radio_selected_object_get_static_delegate = new efl_ui_radio_selected_object_get_delegate(selected_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_radio_selected_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_selected_object_get_static_delegate)});
      efl_ui_radio_group_add_static_delegate = new efl_ui_radio_group_add_delegate(group_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_radio_group_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_add_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Radio.efl_ui_radio_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Radio.efl_ui_radio_class_get();
   }


    private delegate  int efl_ui_radio_state_value_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_radio_state_value_get(System.IntPtr obj);
    private static  int state_value_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_radio_state_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Radio)wrapper).GetStateValue();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_radio_state_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_radio_state_value_get_delegate efl_ui_radio_state_value_get_static_delegate;


    private delegate  void efl_ui_radio_state_value_set_delegate(System.IntPtr obj, System.IntPtr pd,    int value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_radio_state_value_set(System.IntPtr obj,    int value);
    private static  void state_value_set(System.IntPtr obj, System.IntPtr pd,   int value)
   {
      Eina.Log.Debug("function efl_ui_radio_state_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Radio)wrapper).SetStateValue( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_radio_state_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_ui_radio_state_value_set_delegate efl_ui_radio_state_value_set_static_delegate;


    private delegate  void efl_ui_radio_value_pointer_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr valuep);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_radio_value_pointer_set(System.IntPtr obj,    System.IntPtr valuep);
    private static  void value_pointer_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr valuep)
   {
      Eina.Log.Debug("function efl_ui_radio_value_pointer_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_valuep = Eina.PrimitiveConversion.PointerToManaged< int>(valuep);
                     
         try {
            ((Radio)wrapper).SetValuePointer( _in_valuep);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_radio_value_pointer_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  valuep);
      }
   }
   private efl_ui_radio_value_pointer_set_delegate efl_ui_radio_value_pointer_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_radio_selected_object_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_radio_selected_object_get(System.IntPtr obj);
    private static Efl.Canvas.Object selected_object_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_radio_selected_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Radio)wrapper).GetSelectedObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_radio_selected_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_radio_selected_object_get_delegate efl_ui_radio_selected_object_get_static_delegate;


    private delegate  void efl_ui_radio_group_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Radio, Efl.Eo.NonOwnTag>))]  Efl.Ui.Radio group);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_radio_group_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Radio, Efl.Eo.NonOwnTag>))]  Efl.Ui.Radio group);
    private static  void group_add(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Radio group)
   {
      Eina.Log.Debug("function efl_ui_radio_group_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Radio)wrapper).AddGroup( group);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_radio_group_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  group);
      }
   }
   private efl_ui_radio_group_add_delegate efl_ui_radio_group_add_static_delegate;
}
} } 
