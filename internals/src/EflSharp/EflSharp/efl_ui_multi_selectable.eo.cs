#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
[MultiSelectableConcreteNativeInherit]
public interface MultiSelectable : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The mode type for children selection.</summary>
/// <returns>Type of selection of children</returns>
Efl.Ui.SelectMode GetSelectMode();
   /// <summary>The mode type for children selection.</summary>
/// <param name="mode">Type of selection of children</param>
/// <returns></returns>
 void SetSelectMode( Efl.Ui.SelectMode mode);
         /// <summary>The mode type for children selection.</summary>
   Efl.Ui.SelectMode SelectMode {
      get ;
      set ;
   }
}
/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
sealed public class MultiSelectableConcrete : 

MultiSelectable
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (MultiSelectableConcrete))
            return Efl.Ui.MultiSelectableConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_multi_selectable_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public MultiSelectableConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~MultiSelectableConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static MultiSelectableConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new MultiSelectableConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Ui.SelectMode efl_ui_select_mode_get(System.IntPtr obj);
   /// <summary>The mode type for children selection.</summary>
   /// <returns>Type of selection of children</returns>
   public Efl.Ui.SelectMode GetSelectMode() {
       var _ret_var = efl_ui_select_mode_get(Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_select_mode_set(System.IntPtr obj,   Efl.Ui.SelectMode mode);
   /// <summary>The mode type for children selection.</summary>
   /// <param name="mode">Type of selection of children</param>
   /// <returns></returns>
   public  void SetSelectMode( Efl.Ui.SelectMode mode) {
                         efl_ui_select_mode_set(Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get(),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The mode type for children selection.</summary>
   public Efl.Ui.SelectMode SelectMode {
      get { return GetSelectMode(); }
      set { SetSelectMode( value); }
   }
}
public class MultiSelectableConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate)});
      efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
   }


    private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Ui.SelectMode efl_ui_select_mode_get(System.IntPtr obj);
    private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_select_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
         try {
            _ret_var = ((MultiSelectable)wrapper).GetSelectMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_select_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;


    private delegate  void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_select_mode_set(System.IntPtr obj,   Efl.Ui.SelectMode mode);
    private static  void select_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode)
   {
      Eina.Log.Debug("function efl_ui_select_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((MultiSelectable)wrapper).SetSelectMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_select_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Type of multi selectable object.</summary>
public enum SelectMode
{
/// <summary>Only single child is selected. if the child is selected, previous selected child will be unselected.</summary>
Single = 0,
/// <summary>Same as single select except, this will be selected in every select calls though child is already been selected.</summary>
SingleAlways = 1,
/// <summary>allow multiple selection of children.</summary>
Multi = 2,
/// <summary>Last value of select mode. child cannot be selected at all.</summary>
None = 3,
}
} } 
