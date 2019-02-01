#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>EFL UI popup class</summary>
[PopupNativeInherit]
public class Popup : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Content
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.PopupNativeInherit nativeInherit = new Efl.Ui.PopupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Popup))
            return Efl.Ui.PopupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Popup obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_popup_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Popup(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Popup", efl_ui_popup_class_get(), typeof(Popup), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Popup(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Popup(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Popup static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Popup(obj.NativeHandle);
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
private static object BackwallClickedEvtKey = new object();
   /// <summary>This is called whenever the user clicks back wall of popup.</summary>
   public event EventHandler BackwallClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
            if (add_cpp_event_handler(key, this.evt_BackwallClickedEvt_delegate)) {
               eventHandlers.AddHandler(BackwallClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
            if (remove_cpp_event_handler(key, this.evt_BackwallClickedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BackwallClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BackwallClickedEvt.</summary>
   public void On_BackwallClickedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[BackwallClickedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BackwallClickedEvt_delegate;
   private void on_BackwallClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_BackwallClickedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object TimeoutEvtKey = new object();
   /// <summary>This is called when popup times out.</summary>
   public event EventHandler TimeoutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
            if (add_cpp_event_handler(key, this.evt_TimeoutEvt_delegate)) {
               eventHandlers.AddHandler(TimeoutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
            if (remove_cpp_event_handler(key, this.evt_TimeoutEvt_delegate)) { 
               eventHandlers.RemoveHandler(TimeoutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event TimeoutEvt.</summary>
   public void On_TimeoutEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[TimeoutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_TimeoutEvt_delegate;
   private void on_TimeoutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_TimeoutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_BackwallClickedEvt_delegate = new Efl.EventCb(on_BackwallClickedEvt_NativeCallback);
      evt_TimeoutEvt_delegate = new Efl.EventCb(on_TimeoutEvt_NativeCallback);
   }
   /// <summary>A backwall behind the popup.</summary>
   public Efl.Ui.PopupPartBackwall Backwall
   {
      get
      {
         Efl.Object obj = efl_part_get(NativeHandle, "backwall");
         return Efl.Ui.PopupPartBackwall.static_cast(obj);
      }
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.PopupAlign efl_ui_popup_align_get(System.IntPtr obj);
   /// <summary>Get the current popup alignment.</summary>
   /// <returns>Alignment type</returns>
   virtual public Efl.Ui.PopupAlign GetAlign() {
       var _ret_var = efl_ui_popup_align_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_popup_align_set(System.IntPtr obj,   Efl.Ui.PopupAlign type);
   /// <summary>Set the popup alignment.</summary>
   /// <param name="type">Alignment type</param>
   /// <returns></returns>
   virtual public  void SetAlign( Efl.Ui.PopupAlign type) {
                         efl_ui_popup_align_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern double efl_ui_popup_timeout_get(System.IntPtr obj);
   /// <summary>Get the currently set timeout seconds.</summary>
   /// <returns>Timeout in seconds</returns>
   virtual public double GetTimeout() {
       var _ret_var = efl_ui_popup_timeout_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_popup_timeout_set(System.IntPtr obj,   double time);
   /// <summary>Set the timeout seconds. After timeout seconds, popup will be deleted automatically.</summary>
   /// <param name="time">Timeout in seconds</param>
   /// <returns></returns>
   virtual public  void SetTimeout( double time) {
                         efl_ui_popup_timeout_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  time);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Size2D_StructInternal efl_ui_popup_size_get(System.IntPtr obj);
   /// <summary>get the current popup size.</summary>
   /// <returns></returns>
   virtual public Eina.Size2D GetPopupSize() {
       var _ret_var = efl_ui_popup_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_popup_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>Set the popup size.</summary>
   /// <param name="size"></param>
   /// <returns></returns>
   virtual public  void SetPopupSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_ui_popup_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_content_get(System.IntPtr obj);
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = efl_content_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_content_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = efl_content_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_content_unset(System.IntPtr obj);
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = efl_content_unset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the current popup alignment.</summary>
   public Efl.Ui.PopupAlign Align {
      get { return GetAlign(); }
      set { SetAlign( value); }
   }
   /// <summary>Get the currently set timeout seconds.</summary>
   public double Timeout {
      get { return GetTimeout(); }
      set { SetTimeout( value); }
   }
   /// <summary>get the current popup size.</summary>
   public Eina.Size2D PopupSize {
      get { return GetPopupSize(); }
      set { SetPopupSize( value); }
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
}
public class PopupNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_popup_align_get_static_delegate = new efl_ui_popup_align_get_delegate(align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_get_static_delegate)});
      efl_ui_popup_align_set_static_delegate = new efl_ui_popup_align_set_delegate(align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_set_static_delegate)});
      efl_ui_popup_timeout_get_static_delegate = new efl_ui_popup_timeout_get_delegate(timeout_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_timeout_get_static_delegate)});
      efl_ui_popup_timeout_set_static_delegate = new efl_ui_popup_timeout_set_delegate(timeout_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_timeout_set_static_delegate)});
      efl_ui_popup_size_get_static_delegate = new efl_ui_popup_size_get_delegate(popup_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_size_get_static_delegate)});
      efl_ui_popup_size_set_static_delegate = new efl_ui_popup_size_set_delegate(popup_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_popup_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_size_set_static_delegate)});
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Popup.efl_ui_popup_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Popup.efl_ui_popup_class_get();
   }


    private delegate Efl.Ui.PopupAlign efl_ui_popup_align_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.PopupAlign efl_ui_popup_align_get(System.IntPtr obj);
    private static Efl.Ui.PopupAlign align_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_popup_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.PopupAlign _ret_var = default(Efl.Ui.PopupAlign);
         try {
            _ret_var = ((Popup)wrapper).GetAlign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_popup_align_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_popup_align_get_delegate efl_ui_popup_align_get_static_delegate;


    private delegate  void efl_ui_popup_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.PopupAlign type);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_popup_align_set(System.IntPtr obj,   Efl.Ui.PopupAlign type);
    private static  void align_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PopupAlign type)
   {
      Eina.Log.Debug("function efl_ui_popup_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Popup)wrapper).SetAlign( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_popup_align_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private efl_ui_popup_align_set_delegate efl_ui_popup_align_set_static_delegate;


    private delegate double efl_ui_popup_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern double efl_ui_popup_timeout_get(System.IntPtr obj);
    private static double timeout_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_popup_timeout_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Popup)wrapper).GetTimeout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_popup_timeout_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_popup_timeout_get_delegate efl_ui_popup_timeout_get_static_delegate;


    private delegate  void efl_ui_popup_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,   double time);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_popup_timeout_set(System.IntPtr obj,   double time);
    private static  void timeout_set(System.IntPtr obj, System.IntPtr pd,  double time)
   {
      Eina.Log.Debug("function efl_ui_popup_timeout_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Popup)wrapper).SetTimeout( time);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_popup_timeout_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  time);
      }
   }
   private efl_ui_popup_timeout_set_delegate efl_ui_popup_timeout_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_popup_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Size2D_StructInternal efl_ui_popup_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal popup_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_popup_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Popup)wrapper).GetPopupSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_popup_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_popup_size_get_delegate efl_ui_popup_size_get_static_delegate;


    private delegate  void efl_ui_popup_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_popup_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    private static  void popup_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_ui_popup_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((Popup)wrapper).SetPopupSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_popup_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_ui_popup_size_set_delegate efl_ui_popup_size_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_content_get(System.IntPtr obj);
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Popup)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_content_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Popup)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private efl_content_set_delegate efl_content_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_content_unset(System.IntPtr obj);
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Popup)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_unset_delegate efl_content_unset_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Popup alignment type</summary>
public enum PopupAlign
{
/// <summary>Popup not aligned</summary>
None = 0,
/// <summary>Popup aligned to center</summary>
Center = 1,
/// <summary>Popup aligned to left</summary>
Left = 2,
/// <summary>Popup aligned to right</summary>
Right = 3,
/// <summary>Popup aligned to top</summary>
Top = 4,
/// <summary>Popup aligned to bottom</summary>
Bottom = 5,
}
} } 
