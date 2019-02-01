#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>EFL UI Scroll Alert Popup class</summary>
[ScrollAlertPopupNativeInherit]
public class ScrollAlertPopup : Efl.Ui.AlertPopup, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ScrollAlertPopupNativeInherit nativeInherit = new Efl.Ui.ScrollAlertPopupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ScrollAlertPopup))
            return Efl.Ui.ScrollAlertPopupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ScrollAlertPopup obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_scroll_alert_popup_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ScrollAlertPopup(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ScrollAlertPopup", efl_ui_scroll_alert_popup_class_get(), typeof(ScrollAlertPopup), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ScrollAlertPopup(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ScrollAlertPopup(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ScrollAlertPopup static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ScrollAlertPopup(obj.NativeHandle);
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
    protected static extern Eina.Size2D_StructInternal efl_ui_scroll_alert_popup_expandable_get(System.IntPtr obj);
   /// <summary>Get the expandable max size of popup.
   /// If the given max_size is -1, then popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
   /// <returns>A 2D max size in pixel units.</returns>
   virtual public Eina.Size2D GetExpandable() {
       var _ret_var = efl_ui_scroll_alert_popup_expandable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_scroll_alert_popup_expandable_set(System.IntPtr obj,   Eina.Size2D_StructInternal max_size);
   /// <summary>Set the expandable max size of popup.
   /// If the given max_size is -1, then a popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
   /// <param name="max_size">A 2D max size in pixel units.</param>
   /// <returns></returns>
   virtual public  void SetExpandable( Eina.Size2D max_size) {
       var _in_max_size = Eina.Size2D_StructConversion.ToInternal(max_size);
                  efl_ui_scroll_alert_popup_expandable_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_max_size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the expandable max size of popup.
/// If the given max_size is -1, then popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
   public Eina.Size2D Expandable {
      get { return GetExpandable(); }
      set { SetExpandable( value); }
   }
}
public class ScrollAlertPopupNativeInherit : Efl.Ui.AlertPopupNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_scroll_alert_popup_expandable_get_static_delegate = new efl_ui_scroll_alert_popup_expandable_get_delegate(expandable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scroll_alert_popup_expandable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scroll_alert_popup_expandable_get_static_delegate)});
      efl_ui_scroll_alert_popup_expandable_set_static_delegate = new efl_ui_scroll_alert_popup_expandable_set_delegate(expandable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scroll_alert_popup_expandable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scroll_alert_popup_expandable_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ScrollAlertPopup.efl_ui_scroll_alert_popup_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ScrollAlertPopup.efl_ui_scroll_alert_popup_class_get();
   }


    private delegate Eina.Size2D_StructInternal efl_ui_scroll_alert_popup_expandable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Size2D_StructInternal efl_ui_scroll_alert_popup_expandable_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal expandable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scroll_alert_popup_expandable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ScrollAlertPopup)wrapper).GetExpandable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scroll_alert_popup_expandable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scroll_alert_popup_expandable_get_delegate efl_ui_scroll_alert_popup_expandable_get_static_delegate;


    private delegate  void efl_ui_scroll_alert_popup_expandable_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal max_size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_scroll_alert_popup_expandable_set(System.IntPtr obj,   Eina.Size2D_StructInternal max_size);
    private static  void expandable_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal max_size)
   {
      Eina.Log.Debug("function efl_ui_scroll_alert_popup_expandable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_max_size = Eina.Size2D_StructConversion.ToManaged(max_size);
                     
         try {
            ((ScrollAlertPopup)wrapper).SetExpandable( _in_max_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scroll_alert_popup_expandable_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  max_size);
      }
   }
   private efl_ui_scroll_alert_popup_expandable_set_delegate efl_ui_scroll_alert_popup_expandable_set_static_delegate;
}
} } 
