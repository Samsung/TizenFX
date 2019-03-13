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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_calendar_item_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public CalendarItem(Efl.Object parent= null
         ) :
      base(efl_ui_calendar_item_class_get(), typeof(CalendarItem), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public CalendarItem(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected CalendarItem(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>Emitted if the focus state has changed.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> FocusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_FocusChangedEvt_delegate)) {
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

private static object Focus_managerChangedEvtKey = new object();
   /// <summary>Emitted when a new manager is the parent for this object.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args> Focus_managerChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Focus_managerChangedEvt_delegate)) {
               eventHandlers.AddHandler(Focus_managerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Focus_managerChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Focus_managerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Focus_managerChangedEvt.</summary>
   public void On_Focus_managerChangedEvt(Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args>)eventHandlers[Focus_managerChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Focus_managerChangedEvt_delegate;
   private void on_Focus_managerChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args args = new Efl.Ui.Focus.ObjectFocus_managerChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ManagerConcrete(evt.Info);
      try {
         On_Focus_managerChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Focus_parentChangedEvtKey = new object();
   /// <summary>Emitted when a new logical parent should be used.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args> Focus_parentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Focus_parentChangedEvt_delegate)) {
               eventHandlers.AddHandler(Focus_parentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Focus_parentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Focus_parentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Focus_parentChangedEvt.</summary>
   public void On_Focus_parentChangedEvt(Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args>)eventHandlers[Focus_parentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Focus_parentChangedEvt_delegate;
   private void on_Focus_parentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args args = new Efl.Ui.Focus.ObjectFocus_parentChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_Focus_parentChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Child_focusChangedEvtKey = new object();
   /// <summary>Emitted if child_focus has changed.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> Child_focusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Child_focusChangedEvt_delegate)) {
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
   /// <summary>Emitted if focus geometry of this object has changed.
   /// 1.20</summary>
   public event EventHandler Focus_geometryChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Focus_geometryChangedEvt_delegate)) {
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
      evt_Focus_managerChangedEvt_delegate = new Efl.EventCb(on_Focus_managerChangedEvt_NativeCallback);
      evt_Focus_parentChangedEvt_delegate = new Efl.EventCb(on_Focus_parentChangedEvt_NativeCallback);
      evt_Child_focusChangedEvt_delegate = new Efl.EventCb(on_Child_focusChangedEvt_NativeCallback);
      evt_Focus_geometryChangedEvt_delegate = new Efl.EventCb(on_Focus_geometryChangedEvt_NativeCallback);
   }
   /// <summary>Day number</summary>
   /// <returns>Day number</returns>
   virtual public  int GetDayNumber() {
       var _ret_var = Efl.Ui.CalendarItemNativeInherit.efl_ui_calendar_item_day_number_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Day number</summary>
   /// <param name="i">Day number</param>
   /// <returns></returns>
   virtual public  void SetDayNumber(  int i) {
                         Efl.Ui.CalendarItemNativeInherit.efl_ui_calendar_item_day_number_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), i);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
   /// 1.20</summary>
   /// <returns>The geometry to use.
   /// 1.20</returns>
   virtual public Eina.Rect GetFocusGeometry() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Returns whether the widget is currently focused or not.
   /// 1.20</summary>
   /// <returns>The focused state of the object.
   /// 1.20</returns>
   virtual public bool GetFocus() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This is called by the manager and should never be called by anyone else.
   /// The function emits the focus state events, if focus is different to the previous state.
   /// 1.20</summary>
   /// <param name="focus">The focused state of the object.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFocus( bool focus) {
                         Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), focus);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
   /// 1.20</summary>
   /// <returns>The manager object
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Manager GetFocusManager() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Describes which logical parent is used by this object.
   /// 1.20</summary>
   /// <returns>The focus parent.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetFocusParent() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Indicates if a child of this object has focus set to true.
   /// 1.20</summary>
   /// <returns><c>true</c> if a child has focus.
   /// 1.20</returns>
   virtual public bool GetChildFocus() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_child_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Indicates if a child of this object has focus set to true.
   /// 1.20</summary>
   /// <param name="child_focus"><c>true</c> if a child has focus.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetChildFocus( bool child_focus) {
                         Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_child_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), child_focus);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void SetupOrder() {
       Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_setup_order_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This is called when <see cref="Efl.Ui.Focus.Object.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.Object.SetupOrder"/> will not call this function again.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void SetupOrderNonRecursive() {
       Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Virtual function handling focus in/out events on the widget
   /// 1.20</summary>
   /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool UpdateOnFocus() {
       var _ret_var = Efl.Ui.Focus.ObjectNativeInherit.efl_ui_focus_object_on_focus_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Day number</summary>
/// <value>Day number</value>
   public  int DayNumber {
      get { return GetDayNumber(); }
      set { SetDayNumber( value); }
   }
   /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
/// 1.20</summary>
/// <value>The geometry to use.
/// 1.20</value>
   public Eina.Rect FocusGeometry {
      get { return GetFocusGeometry(); }
   }
   /// <summary>Returns whether the widget is currently focused or not.
/// 1.20</summary>
/// <value>The focused state of the object.
/// 1.20</value>
   public bool Focus {
      get { return GetFocus(); }
      set { SetFocus( value); }
   }
   /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
/// 1.20</summary>
/// <value>The manager object
/// 1.20</value>
   public Efl.Ui.Focus.Manager FocusManager {
      get { return GetFocusManager(); }
   }
   /// <summary>Describes which logical parent is used by this object.
/// 1.20</summary>
/// <value>The focus parent.
/// 1.20</value>
   public Efl.Ui.Focus.Object FocusParent {
      get { return GetFocusParent(); }
   }
   /// <summary>Indicates if a child of this object has focus set to true.
/// 1.20</summary>
/// <value><c>true</c> if a child has focus.
/// 1.20</value>
   public bool ChildFocus {
      get { return GetChildFocus(); }
      set { SetChildFocus( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.CalendarItem.efl_ui_calendar_item_class_get();
   }
}
public class CalendarItemNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_calendar_item_day_number_get_static_delegate == null)
      efl_ui_calendar_item_day_number_get_static_delegate = new efl_ui_calendar_item_day_number_get_delegate(day_number_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_item_day_number_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_get_static_delegate)});
      if (efl_ui_calendar_item_day_number_set_static_delegate == null)
      efl_ui_calendar_item_day_number_set_static_delegate = new efl_ui_calendar_item_day_number_set_delegate(day_number_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_item_day_number_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_set_static_delegate)});
      if (efl_ui_focus_object_focus_geometry_get_static_delegate == null)
      efl_ui_focus_object_focus_geometry_get_static_delegate = new efl_ui_focus_object_focus_geometry_get_delegate(focus_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_geometry_get_static_delegate)});
      if (efl_ui_focus_object_focus_get_static_delegate == null)
      efl_ui_focus_object_focus_get_static_delegate = new efl_ui_focus_object_focus_get_delegate(focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_get_static_delegate)});
      if (efl_ui_focus_object_focus_set_static_delegate == null)
      efl_ui_focus_object_focus_set_static_delegate = new efl_ui_focus_object_focus_set_delegate(focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_set_static_delegate)});
      if (efl_ui_focus_object_focus_manager_get_static_delegate == null)
      efl_ui_focus_object_focus_manager_get_static_delegate = new efl_ui_focus_object_focus_manager_get_delegate(focus_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_manager_get_static_delegate)});
      if (efl_ui_focus_object_focus_parent_get_static_delegate == null)
      efl_ui_focus_object_focus_parent_get_static_delegate = new efl_ui_focus_object_focus_parent_get_delegate(focus_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_parent_get_static_delegate)});
      if (efl_ui_focus_object_child_focus_get_static_delegate == null)
      efl_ui_focus_object_child_focus_get_static_delegate = new efl_ui_focus_object_child_focus_get_delegate(child_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_child_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_get_static_delegate)});
      if (efl_ui_focus_object_child_focus_set_static_delegate == null)
      efl_ui_focus_object_child_focus_set_static_delegate = new efl_ui_focus_object_child_focus_set_delegate(child_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_child_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_set_static_delegate)});
      if (efl_ui_focus_object_setup_order_static_delegate == null)
      efl_ui_focus_object_setup_order_static_delegate = new efl_ui_focus_object_setup_order_delegate(setup_order);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_setup_order"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_static_delegate)});
      if (efl_ui_focus_object_setup_order_non_recursive_static_delegate == null)
      efl_ui_focus_object_setup_order_non_recursive_static_delegate = new efl_ui_focus_object_setup_order_non_recursive_delegate(setup_order_non_recursive);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_setup_order_non_recursive"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_non_recursive_static_delegate)});
      if (efl_ui_focus_object_on_focus_update_static_delegate == null)
      efl_ui_focus_object_on_focus_update_static_delegate = new efl_ui_focus_object_on_focus_update_delegate(on_focus_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_on_focus_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_on_focus_update_static_delegate)});
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


    public delegate  int efl_ui_calendar_item_day_number_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_get_api_delegate> efl_ui_calendar_item_day_number_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_get_api_delegate>(_Module, "efl_ui_calendar_item_day_number_get");
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
         return efl_ui_calendar_item_day_number_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_calendar_item_day_number_get_delegate efl_ui_calendar_item_day_number_get_static_delegate;


    private delegate  void efl_ui_calendar_item_day_number_set_delegate(System.IntPtr obj, System.IntPtr pd,    int i);


    public delegate  void efl_ui_calendar_item_day_number_set_api_delegate(System.IntPtr obj,    int i);
    public static Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_set_api_delegate> efl_ui_calendar_item_day_number_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_set_api_delegate>(_Module, "efl_ui_calendar_item_day_number_set");
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
         efl_ui_calendar_item_day_number_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  i);
      }
   }
   private static efl_ui_calendar_item_day_number_set_delegate efl_ui_calendar_item_day_number_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate> efl_ui_focus_object_focus_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate>(_Module, "efl_ui_focus_object_focus_geometry_get");
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
         return efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_focus_geometry_get_delegate efl_ui_focus_object_focus_geometry_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate> efl_ui_focus_object_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate>(_Module, "efl_ui_focus_object_focus_get");
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
         return efl_ui_focus_object_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_focus_get_delegate efl_ui_focus_object_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);


    public delegate  void efl_ui_focus_object_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate> efl_ui_focus_object_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate>(_Module, "efl_ui_focus_object_focus_set");
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
         efl_ui_focus_object_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private static efl_ui_focus_object_focus_set_delegate efl_ui_focus_object_focus_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate> efl_ui_focus_object_focus_manager_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate>(_Module, "efl_ui_focus_object_focus_manager_get");
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
         return efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_focus_manager_get_delegate efl_ui_focus_object_focus_manager_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate> efl_ui_focus_object_focus_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate>(_Module, "efl_ui_focus_object_focus_parent_get");
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
         return efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_focus_parent_get_delegate efl_ui_focus_object_focus_parent_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_child_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_child_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate> efl_ui_focus_object_child_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate>(_Module, "efl_ui_focus_object_child_focus_get");
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
         return efl_ui_focus_object_child_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_child_focus_get_delegate efl_ui_focus_object_child_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);


    public delegate  void efl_ui_focus_object_child_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate> efl_ui_focus_object_child_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate>(_Module, "efl_ui_focus_object_child_focus_set");
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
         efl_ui_focus_object_child_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_focus);
      }
   }
   private static efl_ui_focus_object_child_focus_set_delegate efl_ui_focus_object_child_focus_set_static_delegate;


    private delegate  void efl_ui_focus_object_setup_order_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_object_setup_order_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate> efl_ui_focus_object_setup_order_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate>(_Module, "efl_ui_focus_object_setup_order");
    private static  void setup_order(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_setup_order was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CalendarItem)wrapper).SetupOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_setup_order_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_setup_order_delegate efl_ui_focus_object_setup_order_static_delegate;


    private delegate  void efl_ui_focus_object_setup_order_non_recursive_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_object_setup_order_non_recursive_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate> efl_ui_focus_object_setup_order_non_recursive_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate>(_Module, "efl_ui_focus_object_setup_order_non_recursive");
    private static  void setup_order_non_recursive(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_setup_order_non_recursive was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((CalendarItem)wrapper).SetupOrderNonRecursive();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_setup_order_non_recursive_delegate efl_ui_focus_object_setup_order_non_recursive_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_on_focus_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate> efl_ui_focus_object_on_focus_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate>(_Module, "efl_ui_focus_object_on_focus_update");
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
         return efl_ui_focus_object_on_focus_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_object_on_focus_update_delegate efl_ui_focus_object_on_focus_update_static_delegate;
}
} } 
