#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>EFL UI Calendar Item class</summary>
[CalendarItemNativeInherit]
public class CalendarItem : Efl.Object, Efl.Eo.IWrapper,Efl.Ui.Focus.Object
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.CalendarItemNativeInherit nativeInherit = new Efl.Ui.CalendarItemNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (CalendarItem))
            return Efl.Ui.CalendarItemNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(CalendarItem obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_calendar_item_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public CalendarItem(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("CalendarItem", efl_ui_calendar_item_class_get(), typeof(CalendarItem), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected CalendarItem(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public CalendarItem(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static CalendarItem static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new CalendarItem(obj.NativeHandle);
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
private static object FocusChangedEvtKey = new object();
   /// <summary>Emitted if the focus state has changed
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> FocusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) {
               eventHandlers.AddHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusChangedEvt.</summary>
   public void On_FocusChangedEvt(Efl.Ui.Focus.ObjectFocusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args>)eventHandlers[FocusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusChangedEvt_delegate;
   private void on_FocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectFocusChangedEvt_Args args = new Efl.Ui.Focus.ObjectFocusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_FocusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ManagerChangedEvtKey = new object();
   /// <summary>Emitted when a new manager is the parent for this object.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args> ManagerChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_MANAGER_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ManagerChangedEvt_delegate)) {
               eventHandlers.AddHandler(ManagerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_MANAGER_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ManagerChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ManagerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ManagerChangedEvt.</summary>
   public void On_ManagerChangedEvt(Efl.Ui.Focus.ObjectManagerChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args>)eventHandlers[ManagerChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ManagerChangedEvt_delegate;
   private void on_ManagerChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectManagerChangedEvt_Args args = new Efl.Ui.Focus.ObjectManagerChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ManagerConcrete(evt.Info);
      try {
         On_ManagerChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LogicalChangedEvtKey = new object();
   /// <summary>Emitted when a new logical parent should be used.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args> LogicalChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_LOGICAL_CHANGED";
            if (add_cpp_event_handler(key, this.evt_LogicalChangedEvt_delegate)) {
               eventHandlers.AddHandler(LogicalChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_LOGICAL_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_LogicalChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LogicalChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LogicalChangedEvt.</summary>
   public void On_LogicalChangedEvt(Efl.Ui.Focus.ObjectLogicalChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args>)eventHandlers[LogicalChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LogicalChangedEvt_delegate;
   private void on_LogicalChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectLogicalChangedEvt_Args args = new Efl.Ui.Focus.ObjectLogicalChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_LogicalChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Child_focusChangedEvtKey = new object();
   /// <summary>Emitted if child_focus has changed
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> Child_focusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Child_focusChangedEvt_delegate)) {
               eventHandlers.AddHandler(Child_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Child_focusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Child_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Child_focusChangedEvt.</summary>
   public void On_Child_focusChangedEvt(Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args>)eventHandlers[Child_focusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Child_focusChangedEvt_delegate;
   private void on_Child_focusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args args = new Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_Child_focusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Focus_geometryChangedEvtKey = new object();
   /// <summary>Emitted if focus geometry of this object has changed
   /// 1.20</summary>
   public event EventHandler Focus_geometryChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Focus_geometryChangedEvt_delegate)) {
               eventHandlers.AddHandler(Focus_geometryChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Focus_geometryChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Focus_geometryChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Focus_geometryChangedEvt.</summary>
   public void On_Focus_geometryChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Focus_geometryChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Focus_geometryChangedEvt_delegate;
   private void on_Focus_geometryChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Focus_geometryChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_FocusChangedEvt_delegate = new Efl.EventCb(on_FocusChangedEvt_NativeCallback);
      evt_ManagerChangedEvt_delegate = new Efl.EventCb(on_ManagerChangedEvt_NativeCallback);
      evt_LogicalChangedEvt_delegate = new Efl.EventCb(on_LogicalChangedEvt_NativeCallback);
      evt_Child_focusChangedEvt_delegate = new Efl.EventCb(on_Child_focusChangedEvt_NativeCallback);
      evt_Focus_geometryChangedEvt_delegate = new Efl.EventCb(on_Focus_geometryChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_calendar_item_day_number_get(System.IntPtr obj);
   /// <summary>Day number</summary>
   /// <returns>Day number</returns>
   virtual public  int GetDayNumber() {
       var _ret_var = efl_ui_calendar_item_day_number_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_calendar_item_day_number_set(System.IntPtr obj,    int i);
   /// <summary>Day number</summary>
   /// <param name="i">Day number</param>
   /// <returns></returns>
   virtual public  void SetDayNumber(  int i) {
                         efl_ui_calendar_item_day_number_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  i);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get(System.IntPtr obj);
   /// <summary>The geometry used to calculate relationships between other objects.
   /// 1.20</summary>
   /// <returns>The geometry to use.
   /// 1.20</returns>
   virtual public Eina.Rect GetFocusGeometry() {
       var _ret_var = efl_ui_focus_object_focus_geometry_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_object_focus_get(System.IntPtr obj);
   /// <summary>Returns whether the widget is currently focused or not.
   /// 1.20</summary>
   /// <returns>The focused state of the object
   /// 1.20</returns>
   virtual public bool GetFocus() {
       var _ret_var = efl_ui_focus_object_focus_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_object_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   /// <summary>This is called by the manager and should never be called by anyone else.
   /// It can be used by configuring a focus object to adapt to any changes that are required.
   /// 
   /// The function emits the focus state events, if focus is different to the previous state.
   /// 1.20</summary>
   /// <param name="focus">The focused state of the object
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFocus( bool focus) {
                         efl_ui_focus_object_focus_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get(System.IntPtr obj);
   /// <summary>Describes which manager is used to register.
   /// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
   /// 1.20</summary>
   /// <returns>The manager object
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Manager GetFocusManager() {
       var _ret_var = efl_ui_focus_object_focus_manager_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get(System.IntPtr obj);
   /// <summary>Describes which logical parent is used by this object.
   /// 1.20</summary>
   /// <returns>The focus parent.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetFocusParent() {
       var _ret_var = efl_ui_focus_object_focus_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_object_child_focus_get(System.IntPtr obj);
   /// <summary>set if a child of this element has focus or not.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public bool GetChildFocus() {
       var _ret_var = efl_ui_focus_object_child_focus_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_object_child_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
   /// <summary>set if a child of this element has focus or not.
   /// 1.20</summary>
   /// <param name="child_focus"></param>
   /// <returns></returns>
   virtual public  void SetChildFocus( bool child_focus) {
                         efl_ui_focus_object_child_focus_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child_focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_object_prepare_logical(System.IntPtr obj);
   /// <summary>Tells the object that its children will be queried soon by the given manager. The call will be a NOP if there is already a active preprare_logical call on this object
   /// Deleting manager items in this call will result in undefined behaviour and may cause your system to crash.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void PrepareLogical() {
       efl_ui_focus_object_prepare_logical((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_object_prepare_logical_none_recursive(System.IntPtr obj);
   /// <summary>No description supplied.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void PrepareLogicalNoneRecursive() {
       efl_ui_focus_object_prepare_logical_none_recursive((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_object_on_focus_update(System.IntPtr obj);
   /// <summary>Virtual function handling focus in/out events on the widget
   /// 1.20</summary>
   /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool UpdateOnFocus() {
       var _ret_var = efl_ui_focus_object_on_focus_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Day number</summary>
   public  int DayNumber {
      get { return GetDayNumber(); }
      set { SetDayNumber( value); }
   }
   /// <summary>The geometry used to calculate relationships between other objects.
/// 1.20</summary>
   public Eina.Rect FocusGeometry {
      get { return GetFocusGeometry(); }
   }
   /// <summary>Returns whether the widget is currently focused or not.
/// 1.20</summary>
   public bool Focus {
      get { return GetFocus(); }
      set { SetFocus( value); }
   }
   /// <summary>Describes which manager is used to register.
/// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
/// 1.20</summary>
   public Efl.Ui.Focus.Manager FocusManager {
      get { return GetFocusManager(); }
   }
   /// <summary>Describes which logical parent is used by this object.
/// 1.20</summary>
   public Efl.Ui.Focus.Object FocusParent {
      get { return GetFocusParent(); }
   }
   /// <summary>set if a child of this element has focus or not.
/// 1.20</summary>
   public bool ChildFocus {
      get { return GetChildFocus(); }
      set { SetChildFocus( value); }
   }
}
public class CalendarItemNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_calendar_item_day_number_get_static_delegate = new efl_ui_calendar_item_day_number_get_delegate(day_number_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_item_day_number_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_get_static_delegate)});
      efl_ui_calendar_item_day_number_set_static_delegate = new efl_ui_calendar_item_day_number_set_delegate(day_number_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_item_day_number_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_set_static_delegate)});
      efl_ui_focus_object_focus_geometry_get_static_delegate = new efl_ui_focus_object_focus_geometry_get_delegate(focus_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_geometry_get_static_delegate)});
      efl_ui_focus_object_focus_get_static_delegate = new efl_ui_focus_object_focus_get_delegate(focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_get_static_delegate)});
      efl_ui_focus_object_focus_set_static_delegate = new efl_ui_focus_object_focus_set_delegate(focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_set_static_delegate)});
      efl_ui_focus_object_focus_manager_get_static_delegate = new efl_ui_focus_object_focus_manager_get_delegate(focus_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_manager_get_static_delegate)});
      efl_ui_focus_object_focus_parent_get_static_delegate = new efl_ui_focus_object_focus_parent_get_delegate(focus_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_parent_get_static_delegate)});
      efl_ui_focus_object_child_focus_get_static_delegate = new efl_ui_focus_object_child_focus_get_delegate(child_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_child_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_get_static_delegate)});
      efl_ui_focus_object_child_focus_set_static_delegate = new efl_ui_focus_object_child_focus_set_delegate(child_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_child_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_set_static_delegate)});
      efl_ui_focus_object_prepare_logical_static_delegate = new efl_ui_focus_object_prepare_logical_delegate(prepare_logical);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_prepare_logical"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_prepare_logical_static_delegate)});
      efl_ui_focus_object_prepare_logical_none_recursive_static_delegate = new efl_ui_focus_object_prepare_logical_none_recursive_delegate(prepare_logical_none_recursive);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_prepare_logical_none_recursive"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_prepare_logical_none_recursive_static_delegate)});
      efl_ui_focus_object_on_focus_update_static_delegate = new efl_ui_focus_object_on_focus_update_delegate(on_focus_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_on_focus_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_on_focus_update_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.CalendarItem.efl_ui_calendar_item_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.CalendarItem.efl_ui_calendar_item_class_get();
   }


    private delegate  int efl_ui_calendar_item_day_number_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_calendar_item_day_number_get(System.IntPtr obj);
    private static  int day_number_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_calendar_item_day_number_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((CalendarItem)wrapper).GetDayNumber();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_calendar_item_day_number_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_calendar_item_day_number_get_delegate efl_ui_calendar_item_day_number_get_static_delegate;


    private delegate  void efl_ui_calendar_item_day_number_set_delegate(System.IntPtr obj, System.IntPtr pd,    int i);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_calendar_item_day_number_set(System.IntPtr obj,    int i);
    private static  void day_number_set(System.IntPtr obj, System.IntPtr pd,   int i)
   {
      Eina.Log.Debug("function efl_ui_calendar_item_day_number_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CalendarItem)wrapper).SetDayNumber( i);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_calendar_item_day_number_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  i);
      }
   }
   private efl_ui_calendar_item_day_number_set_delegate efl_ui_calendar_item_day_number_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal focus_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((CalendarItem)wrapper).GetFocusGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_focus_object_focus_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_geometry_get_delegate efl_ui_focus_object_focus_geometry_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_focus_get(System.IntPtr obj);
    private static bool focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((CalendarItem)wrapper).GetFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_get_delegate efl_ui_focus_object_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
    private static  void focus_set(System.IntPtr obj, System.IntPtr pd,  bool focus)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CalendarItem)wrapper).SetFocus( focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_object_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private efl_ui_focus_object_focus_set_delegate efl_ui_focus_object_focus_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager focus_manager_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_manager_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((CalendarItem)wrapper).GetFocusManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_manager_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_manager_get_delegate efl_ui_focus_object_focus_manager_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Object focus_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((CalendarItem)wrapper).GetFocusParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_parent_get_delegate efl_ui_focus_object_focus_parent_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_child_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_child_focus_get(System.IntPtr obj);
    private static bool child_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_child_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((CalendarItem)wrapper).GetChildFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_child_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_child_focus_get_delegate efl_ui_focus_object_child_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_child_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
    private static  void child_focus_set(System.IntPtr obj, System.IntPtr pd,  bool child_focus)
   {
      Eina.Log.Debug("function efl_ui_focus_object_child_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((CalendarItem)wrapper).SetChildFocus( child_focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_object_child_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_focus);
      }
   }
   private efl_ui_focus_object_child_focus_set_delegate efl_ui_focus_object_child_focus_set_static_delegate;


    private delegate  void efl_ui_focus_object_prepare_logical_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_prepare_logical(System.IntPtr obj);
    private static  void prepare_logical(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_prepare_logical was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CalendarItem)wrapper).PrepareLogical();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_prepare_logical(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_prepare_logical_delegate efl_ui_focus_object_prepare_logical_static_delegate;


    private delegate  void efl_ui_focus_object_prepare_logical_none_recursive_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_prepare_logical_none_recursive(System.IntPtr obj);
    private static  void prepare_logical_none_recursive(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_prepare_logical_none_recursive was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CalendarItem)wrapper).PrepareLogicalNoneRecursive();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_prepare_logical_none_recursive(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_prepare_logical_none_recursive_delegate efl_ui_focus_object_prepare_logical_none_recursive_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_on_focus_update(System.IntPtr obj);
    private static bool on_focus_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_on_focus_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((CalendarItem)wrapper).UpdateOnFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_on_focus_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_on_focus_update_delegate efl_ui_focus_object_on_focus_update_static_delegate;
}
} } 
