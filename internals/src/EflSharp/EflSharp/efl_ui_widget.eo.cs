#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
/// <param name="obj">Canvas object</param>
/// <param name="region">Showed region</param>
/// <returns></returns>
public delegate  void ScrollableOnShowRegion( Efl.Canvas.Object obj,  Eina.Rect region);
public delegate  void ScrollableOnShowRegionInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object obj,   Eina.Rect_StructInternal region);
internal class ScrollableOnShowRegionWrapper
{

   private ScrollableOnShowRegionInternal _cb;
   private IntPtr _cb_data;
   private EinaFreeCb _cb_free_cb;

   internal ScrollableOnShowRegionWrapper (ScrollableOnShowRegionInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
   {
      this._cb = _cb;
      this._cb_data = _cb_data;
      this._cb_free_cb = _cb_free_cb;
   }

   ~ScrollableOnShowRegionWrapper()
   {
      if (this._cb_free_cb != null)
         this._cb_free_cb(this._cb_data);
   }

   internal  void ManagedCb( Efl.Canvas.Object obj, Eina.Rect region)
   {
            var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                              _cb(_cb_data,  obj,  _in_region);
      Eina.Error.RaiseIfUnhandledException();
                                 }

      internal static  void Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object obj,   Eina.Rect_StructInternal region)
   {
      GCHandle handle = GCHandle.FromIntPtr(cb_data);
      ScrollableOnShowRegion cb = (ScrollableOnShowRegion)handle.Target;
            var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                                 
      try {
         cb( obj,  _in_region);
      } catch (Exception e) {
         Eina.Log.Warning($"Callback error: {e.ToString()}");
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
                                 }
}
} } 
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Widget.MovedEvt"/>.</summary>
public class WidgetMovedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Object arg { get; set; }
}
/// <summary>Efl UI widget abstract class</summary>
[WidgetNativeInherit]
public class Widget : Efl.Canvas.Group, Efl.Eo.IWrapper,Efl.Part,Efl.Access.Action,Efl.Access.Component,Efl.Access.Object,Efl.Access.Widget.Action,Efl.Ui.Cursor,Efl.Ui.Dnd,Efl.Ui.L10n,Efl.Ui.Selection,Efl.Ui.Focus.Object
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.WidgetNativeInherit nativeInherit = new Efl.Ui.WidgetNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Widget))
            return Efl.Ui.WidgetNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Widget obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_widget_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Widget(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Widget", efl_ui_widget_class_get(), typeof(Widget), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Widget(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Widget(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Widget static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Widget(obj.NativeHandle);
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
private static object MovedEvtKey = new object();
   /// <summary>Called when widget moved</summary>
   public event EventHandler<Efl.Ui.WidgetMovedEvt_Args> MovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_MOVED";
            if (add_cpp_event_handler(key, this.evt_MovedEvt_delegate)) {
               eventHandlers.AddHandler(MovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_MOVED";
            if (remove_cpp_event_handler(key, this.evt_MovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MovedEvt.</summary>
   public void On_MovedEvt(Efl.Ui.WidgetMovedEvt_Args e)
   {
      EventHandler<Efl.Ui.WidgetMovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.WidgetMovedEvt_Args>)eventHandlers[MovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MovedEvt_delegate;
   private void on_MovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.WidgetMovedEvt_Args args = new Efl.Ui.WidgetMovedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_MovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LanguageChangedEvtKey = new object();
   /// <summary>Called when widget language changed</summary>
   public event EventHandler LanguageChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_LANGUAGE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_LanguageChangedEvt_delegate)) {
               eventHandlers.AddHandler(LanguageChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_LANGUAGE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_LanguageChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LanguageChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LanguageChangedEvt.</summary>
   public void On_LanguageChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[LanguageChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LanguageChangedEvt_delegate;
   private void on_LanguageChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_LanguageChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessChangedEvtKey = new object();
   /// <summary>Called when accessibility changed</summary>
   public event EventHandler AccessChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ACCESS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_AccessChangedEvt_delegate)) {
               eventHandlers.AddHandler(AccessChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ACCESS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_AccessChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessChangedEvt.</summary>
   public void On_AccessChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AccessChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessChangedEvt_delegate;
   private void on_AccessChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AccessChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AtspiHighlightedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler AtspiHighlightedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
            if (add_cpp_event_handler(key, this.evt_AtspiHighlightedEvt_delegate)) {
               eventHandlers.AddHandler(AtspiHighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
            if (remove_cpp_event_handler(key, this.evt_AtspiHighlightedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AtspiHighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AtspiHighlightedEvt.</summary>
   public void On_AtspiHighlightedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AtspiHighlightedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AtspiHighlightedEvt_delegate;
   private void on_AtspiHighlightedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AtspiHighlightedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AtspiUnhighlightedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler AtspiUnhighlightedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
            if (add_cpp_event_handler(key, this.evt_AtspiUnhighlightedEvt_delegate)) {
               eventHandlers.AddHandler(AtspiUnhighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
            if (remove_cpp_event_handler(key, this.evt_AtspiUnhighlightedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AtspiUnhighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AtspiUnhighlightedEvt.</summary>
   public void On_AtspiUnhighlightedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AtspiUnhighlightedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AtspiUnhighlightedEvt_delegate;
   private void on_AtspiUnhighlightedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AtspiUnhighlightedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PropertyChangedEvtKey = new object();
   /// <summary>Called when property has changed</summary>
   public event EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> PropertyChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (add_cpp_event_handler(key, this.evt_PropertyChangedEvt_delegate)) {
               eventHandlers.AddHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PropertyChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PropertyChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PropertyChangedEvt.</summary>
   public void On_PropertyChangedEvt(Efl.Access.ObjectPropertyChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectPropertyChangedEvt_Args>)eventHandlers[PropertyChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PropertyChangedEvt_delegate;
   private void on_PropertyChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectPropertyChangedEvt_Args args = new Efl.Access.ObjectPropertyChangedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_PropertyChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChildrenChangedEvtKey = new object();
   /// <summary>Called when children have changed</summary>
   public event EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> ChildrenChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChildrenChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChildrenChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChildrenChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChildrenChangedEvt.</summary>
   public void On_ChildrenChangedEvt(Efl.Access.ObjectChildrenChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectChildrenChangedEvt_Args>)eventHandlers[ChildrenChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChildrenChangedEvt_delegate;
   private void on_ChildrenChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectChildrenChangedEvt_Args args = new Efl.Access.ObjectChildrenChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChildrenChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object StateChangedEvtKey = new object();
   /// <summary>Called when state has changed</summary>
   public event EventHandler<Efl.Access.ObjectStateChangedEvt_Args> StateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_StateChangedEvt_delegate)) {
               eventHandlers.AddHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_StateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(StateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StateChangedEvt.</summary>
   public void On_StateChangedEvt(Efl.Access.ObjectStateChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectStateChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectStateChangedEvt_Args>)eventHandlers[StateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StateChangedEvt_delegate;
   private void on_StateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectStateChangedEvt_Args args = new Efl.Access.ObjectStateChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_StateChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BoundsChangedEvtKey = new object();
   /// <summary>Called when boundaries have changed</summary>
   public event EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> BoundsChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_BoundsChangedEvt_delegate)) {
               eventHandlers.AddHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_BoundsChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BoundsChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BoundsChangedEvt.</summary>
   public void On_BoundsChangedEvt(Efl.Access.ObjectBoundsChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectBoundsChangedEvt_Args>)eventHandlers[BoundsChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BoundsChangedEvt_delegate;
   private void on_BoundsChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectBoundsChangedEvt_Args args = new Efl.Access.ObjectBoundsChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_BoundsChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object VisibleDataChangedEvtKey = new object();
   /// <summary>Called when visibility has changed</summary>
   public event EventHandler VisibleDataChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (add_cpp_event_handler(key, this.evt_VisibleDataChangedEvt_delegate)) {
               eventHandlers.AddHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_VisibleDataChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(VisibleDataChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event VisibleDataChangedEvt.</summary>
   public void On_VisibleDataChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[VisibleDataChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_VisibleDataChangedEvt_delegate;
   private void on_VisibleDataChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_VisibleDataChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ActiveDescendantChangedEvtKey = new object();
   /// <summary>Called when active state of descendant has changed</summary>
   public event EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ActiveDescendantChangedEvt_delegate)) {
               eventHandlers.AddHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ActiveDescendantChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ActiveDescendantChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ActiveDescendantChangedEvt.</summary>
   public void On_ActiveDescendantChangedEvt(Efl.Access.ObjectActiveDescendantChangedEvt_Args e)
   {
      EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.ObjectActiveDescendantChangedEvt_Args>)eventHandlers[ActiveDescendantChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ActiveDescendantChangedEvt_delegate;
   private void on_ActiveDescendantChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.ObjectActiveDescendantChangedEvt_Args args = new Efl.Access.ObjectActiveDescendantChangedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_ActiveDescendantChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AddedEvtKey = new object();
   /// <summary>Called when item is added</summary>
   public event EventHandler AddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (add_cpp_event_handler(key, this.evt_AddedEvt_delegate)) {
               eventHandlers.AddHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_AddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AddedEvt.</summary>
   public void On_AddedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AddedEvt_delegate;
   private void on_AddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RemovedEvtKey = new object();
   /// <summary>Called when item is removed</summary>
   public event EventHandler RemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (add_cpp_event_handler(key, this.evt_RemovedEvt_delegate)) {
               eventHandlers.AddHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_RemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RemovedEvt.</summary>
   public void On_RemovedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RemovedEvt_delegate;
   private void on_RemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MoveOutedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler MoveOutedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (add_cpp_event_handler(key, this.evt_MoveOutedEvt_delegate)) {
               eventHandlers.AddHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
            if (remove_cpp_event_handler(key, this.evt_MoveOutedEvt_delegate)) { 
               eventHandlers.RemoveHandler(MoveOutedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MoveOutedEvt.</summary>
   public void On_MoveOutedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MoveOutedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MoveOutedEvt_delegate;
   private void on_MoveOutedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MoveOutedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ReadingStateChangedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler ReadingStateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ReadingStateChangedEvt_delegate)) {
               eventHandlers.AddHandler(ReadingStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ReadingStateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ReadingStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ReadingStateChangedEvt.</summary>
   public void On_ReadingStateChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ReadingStateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ReadingStateChangedEvt_delegate;
   private void on_ReadingStateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ReadingStateChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragAcceptEvtKey = new object();
   /// <summary>accept drag data</summary>
   public event EventHandler<Efl.Ui.DndDragAcceptEvt_Args> DragAcceptEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
            if (add_cpp_event_handler(key, this.evt_DragAcceptEvt_delegate)) {
               eventHandlers.AddHandler(DragAcceptEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
            if (remove_cpp_event_handler(key, this.evt_DragAcceptEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragAcceptEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragAcceptEvt.</summary>
   public void On_DragAcceptEvt(Efl.Ui.DndDragAcceptEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragAcceptEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragAcceptEvt_Args>)eventHandlers[DragAcceptEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragAcceptEvt_delegate;
   private void on_DragAcceptEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragAcceptEvt_Args args = new Efl.Ui.DndDragAcceptEvt_Args();
      args.arg = (bool)Marshal.PtrToStructure(evt.Info, typeof(bool));
      try {
         On_DragAcceptEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragDoneEvtKey = new object();
   /// <summary>drag is done (mouse up)</summary>
   public event EventHandler DragDoneEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
            if (add_cpp_event_handler(key, this.evt_DragDoneEvt_delegate)) {
               eventHandlers.AddHandler(DragDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
            if (remove_cpp_event_handler(key, this.evt_DragDoneEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragDoneEvt.</summary>
   public void On_DragDoneEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragDoneEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragDoneEvt_delegate;
   private void on_DragDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragDoneEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragEnterEvtKey = new object();
   /// <summary>called when the drag object enters this object</summary>
   public event EventHandler DragEnterEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
            if (add_cpp_event_handler(key, this.evt_DragEnterEvt_delegate)) {
               eventHandlers.AddHandler(DragEnterEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
            if (remove_cpp_event_handler(key, this.evt_DragEnterEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragEnterEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragEnterEvt.</summary>
   public void On_DragEnterEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragEnterEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragEnterEvt_delegate;
   private void on_DragEnterEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragEnterEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragLeaveEvtKey = new object();
   /// <summary>called when the drag object leaves this object</summary>
   public event EventHandler DragLeaveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
            if (add_cpp_event_handler(key, this.evt_DragLeaveEvt_delegate)) {
               eventHandlers.AddHandler(DragLeaveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
            if (remove_cpp_event_handler(key, this.evt_DragLeaveEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragLeaveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragLeaveEvt.</summary>
   public void On_DragLeaveEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragLeaveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragLeaveEvt_delegate;
   private void on_DragLeaveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragLeaveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragPosEvtKey = new object();
   /// <summary>called when the drag object changes drag position</summary>
   public event EventHandler<Efl.Ui.DndDragPosEvt_Args> DragPosEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_POS";
            if (add_cpp_event_handler(key, this.evt_DragPosEvt_delegate)) {
               eventHandlers.AddHandler(DragPosEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_POS";
            if (remove_cpp_event_handler(key, this.evt_DragPosEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragPosEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragPosEvt.</summary>
   public void On_DragPosEvt(Efl.Ui.DndDragPosEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragPosEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragPosEvt_Args>)eventHandlers[DragPosEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragPosEvt_delegate;
   private void on_DragPosEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragPosEvt_Args args = new Efl.Ui.DndDragPosEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_DragPosEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragDropEvtKey = new object();
   /// <summary>called when the drag object dropped on this object</summary>
   public event EventHandler<Efl.Ui.DndDragDropEvt_Args> DragDropEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
            if (add_cpp_event_handler(key, this.evt_DragDropEvt_delegate)) {
               eventHandlers.AddHandler(DragDropEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
            if (remove_cpp_event_handler(key, this.evt_DragDropEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragDropEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragDropEvt.</summary>
   public void On_DragDropEvt(Efl.Ui.DndDragDropEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragDropEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragDropEvt_Args>)eventHandlers[DragDropEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragDropEvt_delegate;
   private void on_DragDropEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragDropEvt_Args args = new Efl.Ui.DndDragDropEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_DragDropEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionChangedEvtKey = new object();
   /// <summary>Called when display server&apos;s selection has changed</summary>
   public event EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args> SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SELECTION_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SELECTION_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionChangedEvt.</summary>
   public void On_SelectionChangedEvt(Efl.Ui.SelectionSelectionChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args>)eventHandlers[SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionChangedEvt_delegate;
   private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.SelectionSelectionChangedEvt_Args args = new Efl.Ui.SelectionSelectionChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
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
      evt_MovedEvt_delegate = new Efl.EventCb(on_MovedEvt_NativeCallback);
      evt_LanguageChangedEvt_delegate = new Efl.EventCb(on_LanguageChangedEvt_NativeCallback);
      evt_AccessChangedEvt_delegate = new Efl.EventCb(on_AccessChangedEvt_NativeCallback);
      evt_AtspiHighlightedEvt_delegate = new Efl.EventCb(on_AtspiHighlightedEvt_NativeCallback);
      evt_AtspiUnhighlightedEvt_delegate = new Efl.EventCb(on_AtspiUnhighlightedEvt_NativeCallback);
      evt_PropertyChangedEvt_delegate = new Efl.EventCb(on_PropertyChangedEvt_NativeCallback);
      evt_ChildrenChangedEvt_delegate = new Efl.EventCb(on_ChildrenChangedEvt_NativeCallback);
      evt_StateChangedEvt_delegate = new Efl.EventCb(on_StateChangedEvt_NativeCallback);
      evt_BoundsChangedEvt_delegate = new Efl.EventCb(on_BoundsChangedEvt_NativeCallback);
      evt_VisibleDataChangedEvt_delegate = new Efl.EventCb(on_VisibleDataChangedEvt_NativeCallback);
      evt_ActiveDescendantChangedEvt_delegate = new Efl.EventCb(on_ActiveDescendantChangedEvt_NativeCallback);
      evt_AddedEvt_delegate = new Efl.EventCb(on_AddedEvt_NativeCallback);
      evt_RemovedEvt_delegate = new Efl.EventCb(on_RemovedEvt_NativeCallback);
      evt_MoveOutedEvt_delegate = new Efl.EventCb(on_MoveOutedEvt_NativeCallback);
      evt_ReadingStateChangedEvt_delegate = new Efl.EventCb(on_ReadingStateChangedEvt_NativeCallback);
      evt_DragAcceptEvt_delegate = new Efl.EventCb(on_DragAcceptEvt_NativeCallback);
      evt_DragDoneEvt_delegate = new Efl.EventCb(on_DragDoneEvt_NativeCallback);
      evt_DragEnterEvt_delegate = new Efl.EventCb(on_DragEnterEvt_NativeCallback);
      evt_DragLeaveEvt_delegate = new Efl.EventCb(on_DragLeaveEvt_NativeCallback);
      evt_DragPosEvt_delegate = new Efl.EventCb(on_DragPosEvt_NativeCallback);
      evt_DragDropEvt_delegate = new Efl.EventCb(on_DragDropEvt_NativeCallback);
      evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
      evt_FocusChangedEvt_delegate = new Efl.EventCb(on_FocusChangedEvt_NativeCallback);
      evt_ManagerChangedEvt_delegate = new Efl.EventCb(on_ManagerChangedEvt_NativeCallback);
      evt_LogicalChangedEvt_delegate = new Efl.EventCb(on_LogicalChangedEvt_NativeCallback);
      evt_Child_focusChangedEvt_delegate = new Efl.EventCb(on_Child_focusChangedEvt_NativeCallback);
      evt_Focus_geometryChangedEvt_delegate = new Efl.EventCb(on_Focus_geometryChangedEvt_NativeCallback);
   }
   /// <summary></summary>
   public Efl.Ui.WidgetPartBg Background
   {
      get
      {
         Efl.Object obj = efl_part_get(NativeHandle, "background");
         return Efl.Ui.WidgetPartBg.static_cast(obj);
      }
   }
   /// <summary></summary>
   public Efl.Ui.WidgetPartShadow Shadow
   {
      get
      {
         Efl.Object obj = efl_part_get(NativeHandle, "shadow");
         return Efl.Ui.WidgetPartShadow.static_cast(obj);
      }
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_resize_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sobj);
   /// <summary>Sets the new resize object for this widget.</summary>
   /// <param name="sobj">A canvas object (often a <see cref="Efl.Canvas.Layout"/> object).</param>
   /// <returns></returns>
   virtual public  void SetResizeObject( Efl.Canvas.Object sobj) {
                         efl_ui_widget_resize_object_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sobj);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_disabled_get(System.IntPtr obj);
   /// <summary>Returns whether the widget is disabled.
   /// This will return <c>true</c> if any widget in the parent hierarchy is disabled. Re-enabling that parent may in turn change the disabled state of this widget.</summary>
   /// <returns><c>true</c> if the widget is disabled.</returns>
   virtual public bool GetDisabled() {
       var _ret_var = efl_ui_widget_disabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_disabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
   /// <summary>Enables or disables this widget.
   /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.</summary>
   /// <param name="disabled"><c>true</c> if the widget is disabled.</param>
   /// <returns></returns>
   virtual public  void SetDisabled( bool disabled) {
                         efl_ui_widget_disabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  disabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_widget_style_get(System.IntPtr obj);
   /// <summary>Returns the current style of a widget.</summary>
   /// <returns>Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</returns>
   virtual public  System.String GetStyle() {
       var _ret_var = efl_ui_widget_style_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.ThemeApplyResult efl_ui_widget_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   /// <summary>Can only be called during construction, before finalize.</summary>
   /// <param name="style">Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</param>
   /// <returns>Whether the style was successfully applied or not, see the values of <see cref="Efl.Ui.ThemeApplyResult"/> for more information.</returns>
   virtual public Efl.Ui.ThemeApplyResult SetStyle(  System.String style) {
                         var _ret_var = efl_ui_widget_style_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_allow_get(System.IntPtr obj);
   /// <summary>The ability for a widget to be focused.
   /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
   /// 
   /// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
   /// 
   /// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).</summary>
   /// <returns>Whether the object is focusable.</returns>
   virtual public bool GetFocusAllow() {
       var _ret_var = efl_ui_widget_focus_allow_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_allow_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_focus);
   /// <summary>The ability for a widget to be focused.
   /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
   /// 
   /// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
   /// 
   /// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).</summary>
   /// <param name="can_focus">Whether the object is focusable.</param>
   /// <returns></returns>
   virtual public  void SetFocusAllow( bool can_focus) {
                         efl_ui_widget_focus_allow_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  can_focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Widget efl_ui_widget_parent_get(System.IntPtr obj);
   /// <summary>The internal parent of this widget.
   /// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
   /// 
   /// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>.</summary>
   /// <returns>Widget parent object</returns>
   virtual public Efl.Ui.Widget GetWidgetParent() {
       var _ret_var = efl_ui_widget_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget parent);
   /// <summary>The internal parent of this widget.
   /// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
   /// 
   /// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>.</summary>
   /// <param name="parent">Widget parent object</param>
   /// <returns></returns>
   virtual public  void SetWidgetParent( Efl.Ui.Widget parent) {
                         efl_ui_widget_parent_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  parent);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Widget efl_ui_widget_top_get(System.IntPtr obj);
   /// <summary>Root widget in the widget hierarchy.
   /// This returns the top widget, in terms of widget hierarchy. This is usually a window (<see cref="Efl.Ui.Win"/>). This function walks the list of <see cref="Efl.Ui.Widget.WidgetParent"/>.
   /// 
   /// If this widget has no parent (in terms of widget hierarchy) this will return <c>null</c>.
   /// 
   /// Note: This may not be a display manager window in case of nested canvases. If a &quot;real&quot; window is required, then you might want to verify that the returned object is a <see cref="Efl.Ui.WinInlined"/>, and then get <see cref="Efl.Ui.WinInlined.GetInlinedParent"/> to find an object in the master window.
   /// 
   /// See also <see cref="Efl.Ui.Widget.WidgetParent"/>.</summary>
   /// <returns>Top widget, usually a window.</returns>
   virtual public Efl.Ui.Widget GetWidgetTop() {
       var _ret_var = efl_ui_widget_top_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_widget_access_info_get(System.IntPtr obj);
   /// <summary>Accessibility information.
   /// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.</summary>
   /// <returns>Accessibility text description.</returns>
   virtual public  System.String GetAccessInfo() {
       var _ret_var = efl_ui_widget_access_info_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_access_info_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String txt);
   /// <summary>Accessibility information.
   /// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.</summary>
   /// <param name="txt">Accessibility text description.</param>
   /// <returns></returns>
   virtual public  void SetAccessInfo(  System.String txt) {
                         efl_ui_widget_access_info_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  txt);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.WidgetOrientationMode efl_ui_widget_orientation_mode_get(System.IntPtr obj);
   /// <summary>Whether the widget&apos;s automatic orientation is enabled or not.
   /// Orientation mode is used for widgets to change their style or send signals based on the canvas rotation (i.e. the window orientation). If the orientation mode is enabled, the widget will emit signals such as &quot;elm,state,orient,N&quot; where <c>N</c> is one of 0, 90, 180, 270, depending on the window orientation. Such signals may be handled by the theme in order to provide a different look for the widget based on the canvas orientation.
   /// 
   /// By default orientation mode is enabled.
   /// 
   /// See also <see cref="Efl.Ui.Widget.UpdateOnOrientation"/>.</summary>
   /// <returns>How window orientation should affect this widget.</returns>
   virtual public Efl.Ui.WidgetOrientationMode GetOrientationMode() {
       var _ret_var = efl_ui_widget_orientation_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_orientation_mode_set(System.IntPtr obj,   Efl.Ui.WidgetOrientationMode mode);
   /// <summary>Whether the widget&apos;s automatic orientation is enabled or not.
   /// Orientation mode is used for widgets to change their style or send signals based on the canvas rotation (i.e. the window orientation). If the orientation mode is enabled, the widget will emit signals such as &quot;elm,state,orient,N&quot; where <c>N</c> is one of 0, 90, 180, 270, depending on the window orientation. Such signals may be handled by the theme in order to provide a different look for the widget based on the canvas orientation.
   /// 
   /// By default orientation mode is enabled.
   /// 
   /// See also <see cref="Efl.Ui.Widget.UpdateOnOrientation"/>.</summary>
   /// <param name="mode">How window orientation should affect this widget.</param>
   /// <returns></returns>
   virtual public  void SetOrientationMode( Efl.Ui.WidgetOrientationMode mode) {
                         efl_ui_widget_orientation_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_on_show_region_hook_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.ScrollableOnShowRegionInternal func, EinaFreeCb func_free_cb);
   /// <summary>Hook function called when the <see cref="Efl.Ui.Widget.GetShowRegion"/> is changed.
   /// See also <see cref="Efl.Ui.Widget.GetShowRegion"/>.</summary>
   /// <param name="func">Region hook function</param>
   /// <returns></returns>
   virtual public  void SetOnShowRegionHook( Efl.Ui.ScrollableOnShowRegion func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      efl_ui_widget_on_show_region_hook_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), GCHandle.ToIntPtr(func_handle), Efl.Ui.ScrollableOnShowRegionWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Rect_StructInternal efl_ui_widget_show_region_get(System.IntPtr obj);
   /// <summary>Returns the current region to show.</summary>
   /// <returns>The region to show.</returns>
   virtual public Eina.Rect GetShowRegion() {
       var _ret_var = efl_ui_widget_show_region_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_show_region_set(System.IntPtr obj,   Eina.Rect_StructInternal region,  [MarshalAs(UnmanagedType.U1)]  bool force);
   /// <summary>Request parent scrollers to pan around so that this region of the widget becomes visible.
   /// If <c>force</c> is <c>true</c> this will trigger scroller changes and the <see cref="Efl.Ui.Widget.SetOnShowRegionHook"/> to be called even if the region is unchanged.</summary>
   /// <param name="region">The region to show.</param>
   /// <param name="force">Set to <c>true</c> to force show even if unchanged.</param>
   /// <returns></returns>
   virtual public  void SetShowRegion( Eina.Rect region,  bool force) {
       var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                                    efl_ui_widget_show_region_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_region,  force);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Rect_StructInternal efl_ui_widget_interest_region_get(System.IntPtr obj);
   /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
   /// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
   /// 
   /// Note: The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.
   /// 
   /// See also <see cref="Efl.Ui.Widget.InterestRegionMode"/></summary>
   /// <returns>The relative region to show. If width or height is &lt;= 0 it will be ignored, and no action will be taken.</returns>
   virtual public Eina.Rect GetInterestRegion() {
       var _ret_var = efl_ui_widget_interest_region_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.InterestRegionMode efl_ui_widget_interest_region_mode_get(System.IntPtr obj);
   /// <summary>Defines how <see cref="Efl.Ui.Widget.GetShowRegion"/> should be calculated.
   /// It is up to the implementation of <see cref="Efl.Ui.Widget.GetShowRegion"/> to take this value into account (or ignore it).</summary>
   /// <returns>Whether to show a specific item or the widget as a whole.</returns>
   virtual public Efl.Ui.InterestRegionMode GetInterestRegionMode() {
       var _ret_var = efl_ui_widget_interest_region_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_interest_region_mode_set(System.IntPtr obj,   Efl.Ui.InterestRegionMode mode);
   /// <summary>Defines how <see cref="Efl.Ui.Widget.GetShowRegion"/> should be calculated.
   /// It is up to the implementation of <see cref="Efl.Ui.Widget.GetShowRegion"/> to take this value into account (or ignore it).</summary>
   /// <param name="mode">Whether to show a specific item or the widget as a whole.</param>
   /// <returns></returns>
   virtual public  void SetInterestRegionMode( Efl.Ui.InterestRegionMode mode) {
                         efl_ui_widget_interest_region_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Rect_StructInternal efl_ui_widget_focus_highlight_geometry_get(System.IntPtr obj);
   /// <summary>This is a read-only property.</summary>
   /// <returns>The rectangle area.</returns>
   virtual public Eina.Rect GetFocusHighlightGeometry() {
       var _ret_var = efl_ui_widget_focus_highlight_geometry_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_highlight_enabled_get(System.IntPtr obj);
   /// <summary>Get the enabled value of the focus highlight for this window.</summary>
   /// <returns>The enabled value for the highlight.</returns>
   virtual public bool GetFocusHighlightEnabled() {
       var _ret_var = efl_ui_widget_focus_highlight_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_highlight_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Set the enabled status for the focus highlight in a window.
   /// This function will enable or disable the focus highlight, regardless of the global setting for it.</summary>
   /// <param name="enabled">The enabled value for the highlight.</param>
   /// <returns></returns>
   virtual public  void SetFocusHighlightEnabled( bool enabled) {
                         efl_ui_widget_focus_highlight_enabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_widget_focus_highlight_style_get(System.IntPtr obj);
   /// <summary>Control the widget focus highlight style.
   /// If <c>style</c> is <c>null</c>, the default will be used.
   /// 
   /// As of EFL 1.21 focus highlight properties apply to a single window, not a single widget. As a consequence, calls to this function may be forwarded to the parent window. Future versions of EFL may implement widget-specific focus highlight properties.
   /// 
   /// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightAnimate"/>.</summary>
   /// <returns>The name of the focus highlight style.</returns>
   virtual public  System.String GetFocusHighlightStyle() {
       var _ret_var = efl_ui_widget_focus_highlight_style_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_highlight_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   /// <summary>Control the widget focus highlight style.
   /// If <c>style</c> is <c>null</c>, the default will be used.
   /// 
   /// As of EFL 1.21 focus highlight properties apply to a single window, not a single widget. As a consequence, calls to this function may be forwarded to the parent window. Future versions of EFL may implement widget-specific focus highlight properties.
   /// 
   /// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightAnimate"/>.</summary>
   /// <param name="style">The name of the focus highlight style.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
   virtual public bool SetFocusHighlightStyle(  System.String style) {
                         var _ret_var = efl_ui_widget_focus_highlight_style_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_highlight_animate_get(System.IntPtr obj);
   /// <summary>Get the animate value of the focus highlight for this window.</summary>
   /// <returns>The enabled value for the highlight animation.</returns>
   virtual public bool GetFocusHighlightAnimate() {
       var _ret_var = efl_ui_widget_focus_highlight_animate_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_highlight_animate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool animate);
   /// <summary>Set the animate status for the focus highlight for this window.
   /// This function will enable or disable the animation of focus highlight.</summary>
   /// <param name="animate">The enabled value for the highlight animation.</param>
   /// <returns></returns>
   virtual public  void SetFocusHighlightAnimate( bool animate) {
                         efl_ui_widget_focus_highlight_animate_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  animate);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  uint efl_ui_widget_focus_order_get(System.IntPtr obj);
   /// <summary>Focus order property</summary>
   /// <returns>FIXME</returns>
   virtual public  uint GetFocusOrder() {
       var _ret_var = efl_ui_widget_focus_order_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_widget_focus_custom_chain_get(System.IntPtr obj);
   /// <summary>A custom chain of objects to pass focus.
   /// Note: On focus cycle, only will be evaluated children of this container.</summary>
   /// <returns>Chain of objects</returns>
   virtual public Eina.List<Efl.Canvas.Object> GetFocusCustomChain() {
       var _ret_var = efl_ui_widget_focus_custom_chain_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Canvas.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_custom_chain_set(System.IntPtr obj,    System.IntPtr objs);
   /// <summary>This function overwrites any previous custom focus chain within the list of objects. The previous list will be deleted and this list will be managed by elementary. After it is set, don&apos;t modify it.</summary>
   /// <param name="objs">Chain of objects to pass focus</param>
   /// <returns></returns>
   virtual public  void SetFocusCustomChain( Eina.List<Efl.Canvas.Object> objs) {
       var _in_objs = objs.Handle;
                  efl_ui_widget_focus_custom_chain_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_objs);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_widget_focused_object_get(System.IntPtr obj);
   /// <summary>Current focused object in object tree.</summary>
   /// <returns>Current focused or <c>null</c>, if there is no focused object.</returns>
   virtual public Efl.Canvas.Object GetFocusedObject() {
       var _ret_var = efl_ui_widget_focused_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.Focus.MovePolicy efl_ui_widget_focus_move_policy_get(System.IntPtr obj);
   /// <summary>The widget&apos;s focus move policy.</summary>
   /// <returns>Focus move policy</returns>
   virtual public Efl.Ui.Focus.MovePolicy GetFocusMovePolicy() {
       var _ret_var = efl_ui_widget_focus_move_policy_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_move_policy_set(System.IntPtr obj,   Efl.Ui.Focus.MovePolicy policy);
   /// <summary>The widget&apos;s focus move policy.</summary>
   /// <param name="policy">Focus move policy</param>
   /// <returns></returns>
   virtual public  void SetFocusMovePolicy( Efl.Ui.Focus.MovePolicy policy) {
                         efl_ui_widget_focus_move_policy_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  policy);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_move_policy_automatic_get(System.IntPtr obj);
   /// <summary>Control the widget&apos;s focus_move_policy mode setting.
   /// 1.18</summary>
   /// <returns><c>true</c> to follow system focus move policy change, <c>false</c> otherwise</returns>
   virtual public bool GetFocusMovePolicyAutomatic() {
       var _ret_var = efl_ui_widget_focus_move_policy_automatic_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_move_policy_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   /// <summary>Control the widget&apos;s focus_move_policy mode setting.
   /// 1.18</summary>
   /// <param name="automatic"><c>true</c> to follow system focus move policy change, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetFocusMovePolicyAutomatic( bool automatic) {
                         efl_ui_widget_focus_move_policy_automatic_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  automatic);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] protected static extern Elm.Widget.Item efl_ui_widget_focused_item_get(System.IntPtr obj);
   /// <summary>Get the focused widget item.</summary>
   /// <returns>Focused item</returns>
   virtual public Elm.Widget.Item GetFocusedItem() {
       var _ret_var = efl_ui_widget_focused_item_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_event(System.IntPtr obj,   ref Efl.Event_StructInternal eo_event, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object source);
   /// <summary>Virtual function handling input events on the widget.
   /// This method should return <c>true</c> if the event has been processed. Only key down, key up and pointer wheel events will be propagated through this function.
   /// 
   /// It is common for the event to be also marked as processed as in <see cref="Efl.Input.Event.Processed"/>, if this operation was successful. This makes sure other widgets will not also process this input event.</summary>
   /// <param name="eo_event">EO event struct with an Efl.Input.Event as info.</param>
   /// <param name="source">Source object where the event originated. Often same as this.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool WidgetEvent( ref Efl.Event eo_event,  Efl.Canvas.Object source) {
       var _in_eo_event = Efl.Event_StructConversion.ToInternal(eo_event);
                                    var _ret_var = efl_ui_widget_event((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_eo_event,  source);
      Eina.Error.RaiseIfUnhandledException();
                  eo_event = Efl.Event_StructConversion.ToManaged(_in_eo_event);
            return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_on_access_activate(System.IntPtr obj,   Efl.Ui.Activate act);
   /// <summary>Hook function called when widget is activated through accessibility.
   /// This meant to be overridden by subclasses to support accessibility. This is an unstable API.</summary>
   /// <param name="act">Type of activation.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool OnAccessActivate( Efl.Ui.Activate act) {
                         var _ret_var = efl_ui_widget_on_access_activate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  act);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_on_access_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Hook function called when accessibility is changed on the widget.
   /// This meant to be overridden by subclasses to support accessibility. This is an unstable API.</summary>
   /// <param name="enable"><c>true</c> if accessibility is enabled.</param>
   /// <returns></returns>
   virtual public  void UpdateOnAccess( bool enable) {
                         efl_ui_widget_on_access_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_screen_reader(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_screen_reader);
   /// <summary>&apos;Virtual&apos; function on the widget being set screen reader.</summary>
   /// <param name="is_screen_reader"></param>
   /// <returns></returns>
   virtual public  void ScreenReader( bool is_screen_reader) {
                         efl_ui_widget_screen_reader((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  is_screen_reader);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_atspi(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_atspi);
   /// <summary>&apos;Virtual&apos; function on the widget being set atspi.</summary>
   /// <param name="is_atspi"></param>
   /// <returns></returns>
   virtual public  void Atspi( bool is_atspi) {
                         efl_ui_widget_atspi((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  is_atspi);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_sub_object_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   /// <summary>Virtual function handling sub objects being added.
   /// Sub objects can be any canvas object, not necessarily widgets.
   /// 
   /// See also <see cref="Efl.Ui.Widget.WidgetParent"/>.</summary>
   /// <param name="sub_obj">Sub object to be added. Not necessarily a widget itself.</param>
   /// <returns>Indicates if the operation succeeded.</returns>
   virtual public bool AddWidgetSubObject( Efl.Canvas.Object sub_obj) {
                         var _ret_var = efl_ui_widget_sub_object_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_sub_object_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   /// <summary>Virtual function handling sub objects being removed.
   /// Sub objects can be any canvas object, not necessarily widgets.
   /// 
   /// See also <see cref="Efl.Ui.Widget.WidgetParent"/>.</summary>
   /// <param name="sub_obj">Sub object to be removed. Should be a child of this widget.</param>
   /// <returns>Indicates if the operation succeeded.</returns>
   virtual public bool DelWidgetSubObject( Efl.Canvas.Object sub_obj) {
                         var _ret_var = efl_ui_widget_sub_object_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sub_obj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_on_orientation_update(System.IntPtr obj,    int rotation);
   /// <summary>Virtual function handling canvas orientation changes.
   /// This method will be called recursively from the top widget (the window) to all the children objects whenever the window rotation is changed. The given <c>rotation</c> will be one of 0, 90, 180, 270 or the special value -1 if <see cref="Efl.Ui.Widget.OrientationMode"/> is <c>disabled</c>.
   /// 
   /// If <see cref="Efl.Ui.Widget.OrientationMode"/> is <c>default</c>, the widget implementation will emit the signal &quot;elm,state,orient,<c>R</c>&quot; will be emitted (where <c>R</c> is the rotation angle in degrees).
   /// 
   /// Note: This function may be called even if the orientation has not actually changed, like when a widget needs to be reconfigured.
   /// 
   /// See also <see cref="Efl.Ui.Widget.OrientationMode"/>.</summary>
   /// <param name="rotation">Orientation in degrees: 0, 90, 180, 270 or -1 if <see cref="Efl.Ui.Widget.OrientationMode"/> is <c>disabled</c>.</param>
   /// <returns></returns>
   virtual public  void UpdateOnOrientation(  int rotation) {
                         efl_ui_widget_on_orientation_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  rotation);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_on_disabled_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
   /// <summary>Virtual function called when the widget becomes disabled.
   /// This may be triggered even if this widget is not disabled, as the parent widget could be disabled and propagate its state.</summary>
   /// <param name="disabled">The new value of <see cref="Efl.Ui.Widget.Disabled"/>.</param>
   /// <returns>Indicates if the operation succeeded.</returns>
   virtual public bool UpdateOnDisabled( bool disabled) {
                         var _ret_var = efl_ui_widget_on_disabled_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  disabled);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.ThemeApplyResult efl_ui_widget_theme_apply(System.IntPtr obj);
   /// <summary>Virtual function called when the widget needs to re-apply its theme.
   /// This may be called when the object is first created, or whenever the widget is modified in any way that may require a reload of the theme. This may include but is not limited to scale, theme, or mirrored mode changes.
   /// 
   /// Note: even widgets not based on layouts may override this method to handle widget updates (scale, mirrored mode, etc...).</summary>
   /// <returns>Indicates success, and if the current theme or default theme was used.</returns>
   virtual public Efl.Ui.ThemeApplyResult ThemeApply() {
       var _ret_var = efl_ui_widget_theme_apply((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_scroll_hold_push(System.IntPtr obj);
   /// <summary>Push scroll hold</summary>
   /// <returns></returns>
   virtual public  void PushScrollHold() {
       efl_ui_widget_scroll_hold_push((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_scroll_hold_pop(System.IntPtr obj);
   /// <summary>Pop scroller hold</summary>
   /// <returns></returns>
   virtual public  void PopScrollHold() {
       efl_ui_widget_scroll_hold_pop((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_scroll_freeze_push(System.IntPtr obj);
   /// <summary>Push scroller freeze</summary>
   /// <returns></returns>
   virtual public  void PushScrollFreeze() {
       efl_ui_widget_scroll_freeze_push((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_scroll_freeze_pop(System.IntPtr obj);
   /// <summary>Pop scroller freeze</summary>
   /// <returns></returns>
   virtual public  void PopScrollFreeze() {
       efl_ui_widget_scroll_freeze_pop((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_widget_part_access_object_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
   /// <summary>Get the access object of given part of the widget.
   /// 1.18</summary>
   /// <param name="part">The object&apos;s part name to get access object</param>
   /// <returns></returns>
   virtual public Efl.Canvas.Object GetPartAccessObject(  System.String part) {
                         var _ret_var = efl_ui_widget_part_access_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  part);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_widget_newest_focus_order_get(System.IntPtr obj,   out  uint newest_focus_order,  [MarshalAs(UnmanagedType.U1)]  bool can_focus_only);
   /// <summary>Get newest focus in order</summary>
   /// <param name="newest_focus_order">Newest focus order</param>
   /// <param name="can_focus_only"><c>true</c> only us widgets which can focus, <c>false</c> otherweise</param>
   /// <returns>Handle to focused widget</returns>
   virtual public Efl.Canvas.Object GetNewestFocusOrder( out  uint newest_focus_order,  bool can_focus_only) {
                                           var _ret_var = efl_ui_widget_newest_focus_order_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out newest_focus_order,  can_focus_only);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_next_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object next,   Efl.Ui.Focus.Direction dir);
   /// <summary>Set the next object with specific focus direction.
   /// 1.8</summary>
   /// <param name="next">Focus next object</param>
   /// <param name="dir">Focus direction</param>
   /// <returns></returns>
   virtual public  void SetFocusNextObject( Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir) {
                                           efl_ui_widget_focus_next_object_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  next,  dir);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_ui_widget_focus_next_object_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
   /// <summary>Get the next object with specific focus direction.
   /// 1.8</summary>
   /// <param name="dir">Focus direction</param>
   /// <returns>Focus next object</returns>
   virtual public Efl.Canvas.Object GetFocusNextObject( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = efl_ui_widget_focus_next_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_next_item_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item next_item,   Efl.Ui.Focus.Direction dir);
   /// <summary>Set the next object item with specific focus direction.
   /// 1.16</summary>
   /// <param name="next_item">Focus next object item</param>
   /// <param name="dir">Focus direction</param>
   /// <returns></returns>
   virtual public  void SetFocusNextItem( Elm.Widget.Item next_item,  Efl.Ui.Focus.Direction dir) {
                                           efl_ui_widget_focus_next_item_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  next_item,  dir);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] protected static extern Elm.Widget.Item efl_ui_widget_focus_next_item_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
   /// <summary>Get the next object item with specific focus direction.
   /// 1.16</summary>
   /// <param name="dir">Focus direction</param>
   /// <returns>Focus next object item</returns>
   virtual public Elm.Widget.Item GetFocusNextItem( Efl.Ui.Focus.Direction dir) {
                         var _ret_var = efl_ui_widget_focus_next_item_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_tree_unfocusable_handle(System.IntPtr obj);
   /// <summary>Handle focus tree unfocusable</summary>
   /// <returns></returns>
   virtual public  void FocusTreeUnfocusableHandle() {
       efl_ui_widget_focus_tree_unfocusable_handle((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_custom_chain_prepend(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
   /// <summary>Prepend object to custom focus chain.
   /// Note: If @&quot;relative_child&quot; equal to <c>null</c> or not in custom chain, the object will be added in begin.
   /// 
   /// Note: On focus cycle, only will be evaluated children of this container.</summary>
   /// <param name="child">The child to be added in custom chain.</param>
   /// <param name="relative_child">The relative object to position the child.</param>
   /// <returns></returns>
   virtual public  void FocusCustomChainPrepend( Efl.Canvas.Object child,  Efl.Canvas.Object relative_child) {
                                           efl_ui_widget_focus_custom_chain_prepend((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child,  relative_child);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_cycle(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
   /// <summary>Give focus to next object with specific focus direction in object tree.</summary>
   /// <param name="dir">Direction to move the focus.</param>
   /// <returns></returns>
   virtual public  void FocusCycle( Efl.Ui.Focus.Direction dir) {
                         efl_ui_widget_focus_cycle((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_direction(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   /// <summary>&apos;Virtual&apos; function handling passing focus to sub-objects given a direction, in degrees.</summary>
   /// <param name="kw_base">Base object</param>
   /// <param name="degree">Degree</param>
   /// <param name="direction">Direction</param>
   /// <param name="direction_item">Direction item</param>
   /// <param name="weight">Weight</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool FocusDirection( Efl.Canvas.Object kw_base,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight) {
                                                                                                 var _ret_var = efl_ui_widget_focus_direction((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_base,  degree,  out direction,  out direction_item,  out weight);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_next_manager_is(System.IntPtr obj);
   /// <summary>&apos;Virtual&apos; function which checks if handling of passing focus to sub-objects is supported by widget.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool IsFocusNextManager() {
       var _ret_var = efl_ui_widget_focus_next_manager_is((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_list_direction_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,    System.IntPtr items,    System.IntPtr list_data_get,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   /// <summary>Get focus list direction</summary>
   /// <param name="kw_base">Base object</param>
   /// <param name="items">Item list</param>
   /// <param name="list_data_get">Data get function</param>
   /// <param name="degree">Degree</param>
   /// <param name="direction">Direction</param>
   /// <param name="direction_item">Direction item</param>
   /// <param name="weight">Weight</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool GetFocusListDirection( Efl.Canvas.Object kw_base,  Eina.List<Efl.Object> items,   System.IntPtr list_data_get,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight) {
             var _in_items = items.Handle;
                                                                                                                        var _ret_var = efl_ui_widget_focus_list_direction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_base,  _in_items,  list_data_get,  degree,  out direction,  out direction_item,  out weight);
      Eina.Error.RaiseIfUnhandledException();
                                                                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focused_object_clear(System.IntPtr obj);
   /// <summary>Clear focused object</summary>
   /// <returns></returns>
   virtual public  void ClearFocusedObject() {
       efl_ui_widget_focused_object_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_direction_go(System.IntPtr obj,   double degree);
   /// <summary>Go in focus direction</summary>
   /// <param name="degree">Degree</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool FocusDirectionGo( double degree) {
                         var _ret_var = efl_ui_widget_focus_direction_go((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  degree);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_next_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   /// <summary>Get next focus item</summary>
   /// <param name="dir">Focus direction</param>
   /// <param name="next">Next object</param>
   /// <param name="next_item">Next item</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool GetFocusNext( Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item) {
                                                             var _ret_var = efl_ui_widget_focus_next_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir,  out next,  out next_item);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_restore(System.IntPtr obj);
   /// <summary>Restore the focus state of the sub-tree.
   /// This API will restore the focus state of the sub-tree to the latest state. If a sub-tree is unfocused and wants to get back to the latest focus state, this API will be helpful.</summary>
   /// <returns></returns>
   virtual public  void FocusRestore() {
       efl_ui_widget_focus_restore((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_custom_chain_unset(System.IntPtr obj);
   /// <summary>Unset a custom focus chain on a given Elementary widget.
   /// Any focus chain previously set is removed entirely after this call.</summary>
   /// <returns></returns>
   virtual public  void UnsetFocusCustomChain() {
       efl_ui_widget_focus_custom_chain_unset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_steal(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item item);
   /// <summary>Steal focus</summary>
   /// <param name="item">Widget to steal focus from</param>
   /// <returns></returns>
   virtual public  void FocusSteal( Elm.Widget.Item item) {
                         efl_ui_widget_focus_steal((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  item);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_hide_handle(System.IntPtr obj);
   /// <summary>Handle hide focus</summary>
   /// <returns></returns>
   virtual public  void FocusHideHandle() {
       efl_ui_widget_focus_hide_handle((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_next(System.IntPtr obj,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   /// <summary>&apos;Virtual&apos; function handling passing focus to sub-objects.</summary>
   /// <param name="dir">Focus direction</param>
   /// <param name="next">Next object</param>
   /// <param name="next_item">Next item</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool FocusNext( Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item) {
                                                             var _ret_var = efl_ui_widget_focus_next((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir,  out next,  out next_item);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_list_next_get(System.IntPtr obj,    System.IntPtr items,    System.IntPtr list_data_get,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   /// <summary>Get next item in focus list</summary>
   /// <param name="items">Item list</param>
   /// <param name="list_data_get">Function type</param>
   /// <param name="dir">Focus direction</param>
   /// <param name="next">Next object</param>
   /// <param name="next_item">Next item</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool GetFocusListNext( Eina.List<Efl.Object> items,   System.IntPtr list_data_get,  Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item) {
       var _in_items = items.Handle;
                                                                                          var _ret_var = efl_ui_widget_focus_list_next_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_items,  list_data_get,  dir,  out next,  out next_item);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_mouse_up_handle(System.IntPtr obj);
   /// <summary>Handle focus mouse up</summary>
   /// <returns></returns>
   virtual public  void FocusMouseUpHandle() {
       efl_ui_widget_focus_mouse_up_handle((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_direction_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   /// <summary>Get focus direction</summary>
   /// <param name="kw_base">Base</param>
   /// <param name="degree">Degree</param>
   /// <param name="direction">Direction</param>
   /// <param name="direction_item">Direction item</param>
   /// <param name="weight">Weight</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool GetFocusDirection( Efl.Canvas.Object kw_base,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight) {
                                                                                                 var _ret_var = efl_ui_widget_focus_direction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_base,  degree,  out direction,  out direction_item,  out weight);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_disabled_handle(System.IntPtr obj);
   /// <summary>Handle disable widget focus</summary>
   /// <returns></returns>
   virtual public  void FocusDisabledHandle() {
       efl_ui_widget_focus_disabled_handle((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_custom_chain_append(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
   /// <summary>Append object to custom focus chain.
   /// Note: If @&quot;relative_child&quot; equal to <c>null</c> or not in custom chain, the object will be added in end.
   /// 
   /// Note: On focus cycle, only will be evaluated children of this container.</summary>
   /// <param name="child">The child to be added in custom chain.</param>
   /// <param name="relative_child">The relative object to position the child.</param>
   /// <returns></returns>
   virtual public  void AppendFocusCustomChain( Efl.Canvas.Object child,  Efl.Canvas.Object relative_child) {
                                           efl_ui_widget_focus_custom_chain_append((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child,  relative_child);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_widget_focus_reconfigure(System.IntPtr obj);
   /// <summary>No description supplied.
   /// 1.18</summary>
   /// <returns></returns>
   virtual public  void FocusReconfigure() {
       efl_ui_widget_focus_reconfigure((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_direction_manager_is(System.IntPtr obj);
   /// <summary>Virtual function which checks if this widget can handle passing focus to sub-object, in a given direction.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool IsFocusDirectionManager() {
       var _ret_var = efl_ui_widget_focus_direction_manager_is((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_widget_focus_state_apply(System.IntPtr obj,   Efl.Ui.WidgetFocusState_StructInternal current_state,   ref Efl.Ui.WidgetFocusState_StructInternal configured_state, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget redirect);
   /// <summary>Register focus with the given configuration.
   /// The implementation can feel free to change the logical flag as it wants, but other than that it should strictly keep the configuration.
   /// 
   /// The implementation in elm.widget updates the current state into what is passed as configured state, respecting manager changes, registeration and unregistration based on if it should be registered or unregistered.
   /// 
   /// A manager field that is <c>null</c> means that the widget should not or was not registered.</summary>
   /// <param name="current_state">The focus manager to register with.</param>
   /// <param name="configured_state">The evaluated Focus state that should be used.</param>
   /// <param name="redirect">A redirect that will be set by the elm.widget implementation.</param>
   /// <returns>Returns whether the widget is registered or not.</returns>
   virtual public bool FocusStateApply( Efl.Ui.WidgetFocusState current_state,  ref Efl.Ui.WidgetFocusState configured_state,  Efl.Ui.Widget redirect) {
       var _in_current_state = Efl.Ui.WidgetFocusState_StructConversion.ToInternal(current_state);
                        var _out_configured_state = new Efl.Ui.WidgetFocusState_StructInternal();
                              var _ret_var = efl_ui_widget_focus_state_apply((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_current_state,  ref _out_configured_state,  redirect);
      Eina.Error.RaiseIfUnhandledException();
            configured_state = Efl.Ui.WidgetFocusState_StructConversion.ToManaged(_out_configured_state);
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_part_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Get a proxy object referring to a part of an object.</summary>
   /// <param name="name">The part name.</param>
   /// <returns>A (proxy) object, valid for a single call.</returns>
   virtual public Efl.Object GetPart(  System.String name) {
                         var _ret_var = efl_part_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_action_name_get(System.IntPtr obj,    int id);
   /// <summary>Gets action name for given id</summary>
   /// <param name="id">ID to get action name for</param>
   /// <returns>Action name</returns>
   virtual public  System.String GetActionName(  int id) {
                         var _ret_var = efl_access_action_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_action_localized_name_get(System.IntPtr obj,    int id);
   /// <summary>Gets localized action name for given id</summary>
   /// <param name="id">ID to get localized name for</param>
   /// <returns>Localized name</returns>
   virtual public  System.String GetActionLocalizedName(  int id) {
                         var _ret_var = efl_access_action_localized_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_access_action_actions_get(System.IntPtr obj);
   /// <summary>Get list of available widget actions</summary>
   /// <returns>Contains statically allocated strings.</returns>
   virtual public Eina.List<Efl.Access.ActionData> GetActions() {
       var _ret_var = efl_access_action_actions_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_action_do(System.IntPtr obj,    int id);
   /// <summary>Performs action on given widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
   virtual public bool ActionDo(  int id) {
                         var _ret_var = efl_access_action_do((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] protected static extern  System.String efl_access_action_keybinding_get(System.IntPtr obj,    int id);
   /// <summary>Gets configured keybinding for specific action and widget.</summary>
   /// <param name="id">ID for widget</param>
   /// <returns>Should be freed by the user.</returns>
   virtual public  System.String GetActionKeybinding(  int id) {
                         var _ret_var = efl_access_action_keybinding_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_access_component_z_order_get(System.IntPtr obj);
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
   /// <returns>Z order of component</returns>
   virtual public  int GetZOrder() {
       var _ret_var = efl_access_component_z_order_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Rect_StructInternal efl_access_component_extents_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <returns>The geometry.</returns>
   virtual public Eina.Rect GetExtents( bool screen_coords) {
                         var _ret_var = efl_access_component_extents_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  screen_coords);
      Eina.Error.RaiseIfUnhandledException();
                  return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_extents_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
   /// <summary>Geometry of accessible widget.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">The geometry.</param>
   /// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
   virtual public bool SetExtents( bool screen_coords,  Eina.Rect rect) {
             var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                              var _ret_var = efl_access_component_extents_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  screen_coords,  _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_component_screen_position_get(System.IntPtr obj,   out  int x,   out  int y);
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns></returns>
   virtual public  void GetScreenPosition( out  int x,  out  int y) {
                                           efl_access_component_screen_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_screen_position_set(System.IntPtr obj,    int x,    int y);
   /// <summary>Position of accessible widget.</summary>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
   virtual public bool SetScreenPosition(  int x,   int y) {
                                           var _ret_var = efl_access_component_screen_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_component_socket_offset_get(System.IntPtr obj,   out  int x,   out  int y);
   /// <summary>Gets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   virtual public  void GetSocketOffset( out  int x,  out  int y) {
                                           efl_access_component_socket_offset_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_component_socket_offset_set(System.IntPtr obj,    int x,    int y);
   /// <summary>Sets position of socket offset.</summary>
   /// <param name="x"></param>
   /// <param name="y"></param>
   /// <returns></returns>
   virtual public  void SetSocketOffset(  int x,   int y) {
                                           efl_access_component_socket_offset_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_contains(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   /// <summary>Contains accessible widget</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
   virtual public bool Contains( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = efl_access_component_contains((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_focus_grab(System.IntPtr obj);
   /// <summary>Focuses accessible widget.</summary>
   /// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
   virtual public bool GrabFocus() {
       var _ret_var = efl_access_component_focus_grab((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_access_component_accessible_at_point_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   /// <summary>Gets top component object occupying space at given coordinates.</summary>
   /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns>Top component object at given coordinate</returns>
   virtual public Efl.Object GetAccessibleAtPoint( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = efl_access_component_accessible_at_point_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_highlight_grab(System.IntPtr obj);
   /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   virtual public bool GrabHighlight() {
       var _ret_var = efl_access_component_highlight_grab((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_component_highlight_clear(System.IntPtr obj);
   /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
   /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns></returns>
   virtual public bool ClearHighlight() {
       var _ret_var = efl_access_component_highlight_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_object_localized_role_name_get(System.IntPtr obj);
   /// <summary>Gets an localized string describing accessible object role name.</summary>
   /// <returns>Localized accessible object role name</returns>
   virtual public  System.String GetLocalizedRoleName() {
       var _ret_var = efl_access_object_localized_role_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_object_i18n_name_get(System.IntPtr obj);
   /// <summary>Accessible name of the object.</summary>
   /// <returns>Accessible name</returns>
   virtual public  System.String GetI18nName() {
       var _ret_var = efl_access_object_i18n_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_i18n_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);
   /// <summary>Accessible name of the object.</summary>
   /// <param name="i18n_name">Accessible name</param>
   /// <returns></returns>
   virtual public  void SetI18nName(  System.String i18n_name) {
                         efl_access_object_i18n_name_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  i18n_name);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_name_cb_set(System.IntPtr obj,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);
   /// <summary>Sets name information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="name_cb">reading information callback</param>
   /// <param name="data"></param>
   /// <returns></returns>
   virtual public  void SetNameCb( Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data) {
                                           efl_access_object_name_cb_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.RelationSet efl_access_object_relation_set_get(System.IntPtr obj);
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
   /// <returns>Accessible relation set</returns>
   virtual public Efl.Access.RelationSet GetRelationSet() {
       var _ret_var = efl_access_object_relation_set_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.Role efl_access_object_role_get(System.IntPtr obj);
   /// <summary>The role of the object in accessibility domain.</summary>
   /// <returns>Accessible role</returns>
   virtual public Efl.Access.Role GetRole() {
       var _ret_var = efl_access_object_role_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_role_set(System.IntPtr obj,   Efl.Access.Role role);
   /// <summary>Sets the role of the object in accessibility domain.</summary>
   /// <param name="role">Accessible role</param>
   /// <returns></returns>
   virtual public  void SetRole( Efl.Access.Role role) {
                         efl_access_object_role_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  role);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Access.Object efl_access_object_access_parent_get(System.IntPtr obj);
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <returns>Accessible parent</returns>
   virtual public Efl.Access.Object GetAccessParent() {
       var _ret_var = efl_access_object_access_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_access_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);
   /// <summary>Gets object&apos;s accessible parent.</summary>
   /// <param name="parent">Accessible parent</param>
   /// <returns></returns>
   virtual public  void SetAccessParent( Efl.Access.Object parent) {
                         efl_access_object_access_parent_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  parent);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_description_cb_set(System.IntPtr obj,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);
   /// <summary>Sets contextual information callback about widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="description_cb">The function called to provide the accessible description.</param>
   /// <param name="data">The data passed to @c description_cb.</param>
   /// <returns></returns>
   virtual public  void SetDescriptionCb( Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data) {
                                           efl_access_object_description_cb_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  description_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_gesture_cb_set(System.IntPtr obj,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);
   /// <summary>Sets gesture callback to give widget.
   /// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
   /// 
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="gesture_cb"></param>
   /// <param name="data"></param>
   /// <returns></returns>
   virtual public  void SetGestureCb( Efl.Access.GestureCb gesture_cb,   System.IntPtr data) {
                                           efl_access_object_gesture_cb_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  gesture_cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_access_object_access_children_get(System.IntPtr obj);
   /// <summary>Gets object&apos;s accessible children.</summary>
   /// <returns>List of widget&apos;s children</returns>
   virtual public Eina.List<Efl.Access.Object> GetAccessChildren() {
       var _ret_var = efl_access_object_access_children_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Object>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_object_role_name_get(System.IntPtr obj);
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
   /// <returns>Accessible role name</returns>
   virtual public  System.String GetRoleName() {
       var _ret_var = efl_access_object_role_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_access_object_attributes_get(System.IntPtr obj);
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
   /// <returns>List of object attributes, Must be freed by the user</returns>
   virtual public Eina.List<Efl.Access.Attribute> GetAttributes() {
       var _ret_var = efl_access_object_attributes_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.Attribute>(_ret_var, true, true);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get(System.IntPtr obj);
   /// <summary>Gets reading information types of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>Reading information types</returns>
   virtual public Efl.Access.ReadingInfoTypeMask GetReadingInfoType() {
       var _ret_var = efl_access_object_reading_info_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_reading_info_type_set(System.IntPtr obj,   Efl.Access.ReadingInfoTypeMask reading_info);
   /// <summary>Sets reading information of an accessible object.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="reading_info">Reading information types</param>
   /// <returns></returns>
   virtual public  void SetReadingInfoType( Efl.Access.ReadingInfoTypeMask reading_info) {
                         efl_access_object_reading_info_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  reading_info);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_access_object_index_in_parent_get(System.IntPtr obj);
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
   /// <returns>Index in children list</returns>
   virtual public  int GetIndexInParent() {
       var _ret_var = efl_access_object_index_in_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_object_description_get(System.IntPtr obj);
   /// <summary>Gets contextual information about object.</summary>
   /// <returns>Accessible contextual information</returns>
   virtual public  System.String GetDescription() {
       var _ret_var = efl_access_object_description_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_description_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);
   /// <summary>Sets widget contextual information.</summary>
   /// <param name="description">Accessible contextual information</param>
   /// <returns></returns>
   virtual public  void SetDescription(  System.String description) {
                         efl_access_object_description_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  description);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.StateSet efl_access_object_state_set_get(System.IntPtr obj);
   /// <summary>Gets set describing object accessible states.</summary>
   /// <returns>Accessible state set</returns>
   virtual public Efl.Access.StateSet GetStateSet() {
       var _ret_var = efl_access_object_state_set_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_object_can_highlight_get(System.IntPtr obj);
   /// <summary>Gets highlightable of given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <returns>If @c true, the object is highlightable.</returns>
   virtual public bool GetCanHighlight() {
       var _ret_var = efl_access_object_can_highlight_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_can_highlight_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);
   /// <summary>Sets highlightable to given widget.
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="can_highlight">If @c true, the object is highlightable.</param>
   /// <returns></returns>
   virtual public  void SetCanHighlight( bool can_highlight) {
                         efl_access_object_can_highlight_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  can_highlight);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_access_object_translation_domain_get(System.IntPtr obj);
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibily &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <returns>Translation domain</returns>
   virtual public  System.String GetTranslationDomain() {
       var _ret_var = efl_access_object_translation_domain_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_translation_domain_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
   /// Translation domain should be set if the application wants to support i18n for accessibily &quot;name&quot; and &quot;description&quot; properties.
   /// 
   /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
   /// 
   /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   /// <param name="domain">Translation domain</param>
   /// <returns></returns>
   virtual public  void SetTranslationDomain(  System.String domain) {
                         efl_access_object_translation_domain_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  domain);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_access_object_access_root_get(System.IntPtr obj);
   /// <summary>Get root object of accessible object hierarchy</summary>
   /// <returns>Root object</returns>
   public static Efl.Object GetAccessRoot() {
       var _ret_var = efl_access_object_access_root_get(Efl.Access.ObjectConcrete.efl_access_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_object_gesture_do(System.IntPtr obj,   Efl.Access.GestureInfo_StructInternal gesture_info);
   /// <summary>Handles gesture on given widget.</summary>
   /// <param name="gesture_info"></param>
   /// <returns></returns>
   virtual public bool GestureDo( Efl.Access.GestureInfo gesture_info) {
       var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToInternal(gesture_info);
                  var _ret_var = efl_access_object_gesture_do((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_gesture_info);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_attribute_append(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
   /// <summary>Add key-value pair identifying object extra attribute
   /// @if WEARABLE @since_tizen 3.0 @endif</summary>
   /// <param name="key">The string key to give extra information</param>
   /// <param name="value">The string value to give extra information</param>
   /// <returns></returns>
   virtual public  void AppendAttribute(  System.String key,   System.String value) {
                                           efl_access_object_attribute_append((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key,  value);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_attributes_clear(System.IntPtr obj);
   /// <summary>Removes all attributes in accessible object.</summary>
   /// <returns></returns>
   virtual public  void ClearAttributes() {
       efl_access_object_attributes_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.Event.Handler efl_access_object_event_handler_add(System.IntPtr obj,   Efl.EventCb cb,    System.IntPtr data);
   /// <summary>Register accessibility event listener</summary>
   /// <param name="cb">Callback</param>
   /// <param name="data">Data</param>
   /// <returns>Event handler</returns>
   public static Efl.Access.Event.Handler AddEventHandler( Efl.EventCb cb,   System.IntPtr data) {
                                           var _ret_var = efl_access_object_event_handler_add(Efl.Access.ObjectConcrete.efl_access_object_mixin_get(),  cb,  data);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_event_handler_del(System.IntPtr obj,   Efl.Access.Event.Handler handler);
   /// <summary>Deregister accessibility event listener</summary>
   /// <param name="handler">Event handler</param>
   /// <returns></returns>
   public static  void DelEventHandler( Efl.Access.Event.Handler handler) {
                         efl_access_object_event_handler_del(Efl.Access.ObjectConcrete.efl_access_object_mixin_get(),  handler);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_event_emit(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object accessible,    System.IntPtr kw_event,    System.IntPtr event_info);
   /// <summary>Emit event</summary>
   /// <param name="accessible">Accessibility object.</param>
   /// <param name="kw_event">Accessibility event type.</param>
   /// <param name="event_info">Accessibility event details.</param>
   /// <returns></returns>
   public static  void EmitEvent( Efl.Access.Object accessible,  Efl.EventDescription kw_event,   System.IntPtr event_info) {
             var _in_kw_event = Eina.PrimitiveConversion.ManagedToPointerAlloc(kw_event);
                                                efl_access_object_event_emit(Efl.Access.ObjectConcrete.efl_access_object_mixin_get(),  accessible,  _in_kw_event,  event_info);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_object_relationship_append(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
   /// <summary>Defines the relationship between two accessible objects.
   /// Adds a unique relationship between source object and relation_object of a given type.
   /// 
   /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
   /// 
   /// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_FLOWS_FROM from object B to object A.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to relate to</param>
   /// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
   virtual public bool AppendRelationship( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           var _ret_var = efl_access_object_relationship_append((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_relationship_remove(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
   /// <summary>Removes the relationship between two accessible objects.
   /// If relation_object is NULL function removes all relations of the given type.</summary>
   /// <param name="type">Relation type</param>
   /// <param name="relation_object">Object to remove relation from</param>
   /// <returns></returns>
   virtual public  void RelationshipRemove( Efl.Access.RelationType type,  Efl.Access.Object relation_object) {
                                           efl_access_object_relationship_remove((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  relation_object);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_relationships_clear(System.IntPtr obj);
   /// <summary>Removes all relationships in accessible object.</summary>
   /// <returns></returns>
   virtual public  void ClearRelationships() {
       efl_access_object_relationships_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_access_object_state_notify(System.IntPtr obj,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);
   /// <summary>Notifies accessibility clients about current state of the accessible object.
   /// Function limits information broadcast to clients to types specified by state_types_mask parameter.
   /// 
   /// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
   /// <param name="state_types_mask"></param>
   /// <param name="recursive"></param>
   /// <returns></returns>
   virtual public  void StateNotify( Efl.Access.StateSet state_types_mask,  bool recursive) {
                                           efl_access_object_state_notify((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  state_types_mask,  recursive);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Access.ActionData efl_access_widget_action_elm_actions_get(System.IntPtr obj);
   /// <summary>Elementary actions</summary>
   /// <returns>NULL-terminated array of Efl.Access.Action_Data.</returns>
   virtual public Efl.Access.ActionData GetElmActions() {
       var _ret_var = efl_access_widget_action_elm_actions_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_cursor_get(System.IntPtr obj);
   /// <summary>Returns the current cursor name.</summary>
   /// <returns>The cursor name, defined either by the display system or the theme.</returns>
   virtual public  System.String GetCursor() {
       var _ret_var = efl_ui_cursor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
   /// <summary>Sets or unsets the current cursor.
   /// If <c>cursor</c> is <c>null</c> this function will reset the cursor to the default one.</summary>
   /// <param name="cursor">The cursor name, defined either by the display system or the theme.</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursor(  System.String cursor) {
                         var _ret_var = efl_ui_cursor_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cursor);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_cursor_style_get(System.IntPtr obj);
   /// <summary>Returns the current cursor style name.</summary>
   /// <returns>A specific style to use, eg. default, transparent, ....</returns>
   virtual public  System.String GetCursorStyle() {
       var _ret_var = efl_ui_cursor_style_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   /// <summary>Sets a style for the current cursor. Call after <see cref="Efl.Ui.Cursor.SetCursor"/>.</summary>
   /// <param name="style">A specific style to use, eg. default, transparent, ....</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursorStyle(  System.String style) {
                         var _ret_var = efl_ui_cursor_style_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_theme_search_enabled_get(System.IntPtr obj);
   /// <summary>Returns the current state of theme cursors search.</summary>
   /// <returns>Whether to use theme cursors.</returns>
   virtual public bool GetCursorThemeSearchEnabled() {
       var _ret_var = efl_ui_cursor_theme_search_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_theme_search_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   /// <summary>Enables or disables theme cursors.</summary>
   /// <param name="allow">Whether to use theme cursors.</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursorThemeSearchEnabled( bool allow) {
                         var _ret_var = efl_ui_cursor_theme_search_enabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  allow);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_dnd_drag_start(System.IntPtr obj,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,    uint seat);
   /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
   /// <param name="format">The data format</param>
   /// <param name="data">The drag data</param>
   /// <param name="action">Action when data is transferred</param>
   /// <param name="icon_func">Function pointer to create icon</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void DragStart( Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  Efl.Dnd.DragIconCreate icon_func,   uint seat) {
                                                                                     GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
            efl_ui_dnd_drag_start((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  format,  data,  action, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_dnd_drag_action_set(System.IntPtr obj,   Efl.Ui.SelectionAction action,    uint seat);
   /// <summary>Set the action for the drag</summary>
   /// <param name="action">Drag action</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void SetDragAction( Efl.Ui.SelectionAction action,   uint seat) {
                                           efl_ui_dnd_drag_action_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  action,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_dnd_drag_cancel(System.IntPtr obj,    uint seat);
   /// <summary>Cancel the on-going drag</summary>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void DragCancel(  uint seat) {
                         efl_ui_dnd_drag_cancel((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_dnd_drop_target_add(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
   /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
   /// <param name="format">Accepted data format</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void AddDropTarget( Efl.Ui.SelectionFormat format,   uint seat) {
                                           efl_ui_dnd_drop_target_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  format,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_dnd_drop_target_del(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
   /// <summary>Delete the dropable status from object</summary>
   /// <param name="format">Accepted data format</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void DelDropTarget( Efl.Ui.SelectionFormat format,   uint seat) {
                                           efl_ui_dnd_drop_target_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  format,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_l10n_text_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String domain);
   /// <summary>A unique string to be translated.
   /// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
   /// 
   /// Setting this property will enable translation for this object or part.</summary>
   /// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
   /// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.Text.GetText"/>.</returns>
   virtual public  System.String GetL10nText( out  System.String domain) {
                         var _ret_var = efl_ui_l10n_text_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out domain);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_l10n_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
   /// <summary>Sets the new untranslated string and domain for this object.</summary>
   /// <param name="label">A unique (untranslated) string.</param>
   /// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
   /// <returns></returns>
   virtual public  void SetL10nText(  System.String label,   System.String domain) {
                                           efl_ui_l10n_text_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  label,  domain);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_l10n_translation_update(System.IntPtr obj);
   /// <summary>Requests this object to update its text strings for the current locale.
   /// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
   /// 
   /// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.L10n.UpdateTranslation"/> to children objects.</summary>
   /// <returns></returns>
   virtual public  void UpdateTranslation() {
       efl_ui_l10n_translation_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_ui_selection_set(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
   /// <summary>Set the selection data to the object</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="format">Selection Format</param>
   /// <param name="data"></param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns>Future for tracking when the selection is lost</returns>
   virtual public  Eina.Future SetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,   uint seat) {
                                                                               var _ret_var = efl_ui_selection_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  format,  data,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_selection_get(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
   /// <summary>Get the data from the object that has selection</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="format">Selection Format</param>
   /// <param name="data_func">Data ready function pointer</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void GetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,   uint seat) {
                                                                   GCHandle data_func_handle = GCHandle.Alloc(data_func);
            efl_ui_selection_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_selection_clear(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
   /// <summary>Clear the selection data from the object</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   virtual public  void ClearSelection( Efl.Ui.SelectionType type,   uint seat) {
                                           efl_ui_selection_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_selection_has_owner(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
   /// <summary>Determine whether the selection data has owner</summary>
   /// <param name="type">Selection type</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
   virtual public bool HasOwner( Efl.Ui.SelectionType type,   uint seat) {
                                           var _ret_var = efl_ui_selection_has_owner((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
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
   public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data,  uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = SetSelection(  type,  format,  data,  seat);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>This is the internal canvas object managed by a widget.
/// This property is protected as it is meant for widget implementations only, to set and access the internal canvas object. Do use this function unless you&apos;re implementing a widget.</summary>
   public Efl.Canvas.Object ResizeObject {
      set { SetResizeObject( value); }
   }
   /// <summary>Whether the widget is enabled (accepts and reacts to user inputs).
/// Each widget may handle the disabled state differently, but overall disabled widgets shall not respond to any input events. This is <c>false</c> by default, meaning the widget is enabled.</summary>
   public bool Disabled {
      get { return GetDisabled(); }
      set { SetDisabled( value); }
   }
   /// <summary>The widget style to use.
/// Styles define different look and feel for widgets, and may provide different parts for layout-based widgets. Styles vary from widget to widget and may be defined by other themes by means of extensions and overlays.
/// 
/// The style can only be set before <see cref="Efl.Object.FinalizeAdd"/>, which means at construction time of the object (inside <c>efl_add</c> in C).</summary>
   public  System.String Style {
      get { return GetStyle(); }
      set { SetStyle( value); }
   }
   /// <summary>The ability for a widget to be focused.
/// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
/// 
/// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
/// 
/// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).</summary>
   public bool FocusAllow {
      get { return GetFocusAllow(); }
      set { SetFocusAllow( value); }
   }
   /// <summary>The internal parent of this widget.
/// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
/// 
/// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>.</summary>
   public Efl.Ui.Widget WidgetParent {
      get { return GetWidgetParent(); }
      set { SetWidgetParent( value); }
   }
   /// <summary>Root widget in the widget hierarchy.
/// This returns the top widget, in terms of widget hierarchy. This is usually a window (<see cref="Efl.Ui.Win"/>). This function walks the list of <see cref="Efl.Ui.Widget.WidgetParent"/>.
/// 
/// If this widget has no parent (in terms of widget hierarchy) this will return <c>null</c>.
/// 
/// Note: This may not be a display manager window in case of nested canvases. If a &quot;real&quot; window is required, then you might want to verify that the returned object is a <see cref="Efl.Ui.WinInlined"/>, and then get <see cref="Efl.Ui.WinInlined.GetInlinedParent"/> to find an object in the master window.
/// 
/// See also <see cref="Efl.Ui.Widget.WidgetParent"/>.</summary>
   public Efl.Ui.Widget WidgetTop {
      get { return GetWidgetTop(); }
   }
   /// <summary>Accessibility information.
/// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.</summary>
   public  System.String AccessInfo {
      get { return GetAccessInfo(); }
      set { SetAccessInfo( value); }
   }
   /// <summary>Whether the widget&apos;s automatic orientation is enabled or not.
/// Orientation mode is used for widgets to change their style or send signals based on the canvas rotation (i.e. the window orientation). If the orientation mode is enabled, the widget will emit signals such as &quot;elm,state,orient,N&quot; where <c>N</c> is one of 0, 90, 180, 270, depending on the window orientation. Such signals may be handled by the theme in order to provide a different look for the widget based on the canvas orientation.
/// 
/// By default orientation mode is enabled.
/// 
/// See also <see cref="Efl.Ui.Widget.UpdateOnOrientation"/>.</summary>
   public Efl.Ui.WidgetOrientationMode OrientationMode {
      get { return GetOrientationMode(); }
      set { SetOrientationMode( value); }
   }
   /// <summary>Hook function called when the <see cref="Efl.Ui.Widget.GetShowRegion"/> is changed.
/// See also <see cref="Efl.Ui.Widget.GetShowRegion"/>.</summary>
   public Efl.Ui.ScrollableOnShowRegion OnShowRegionHook {
      set { SetOnShowRegionHook( value); }
   }
   /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
/// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
/// 
/// Note: The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.
/// 
/// See also <see cref="Efl.Ui.Widget.InterestRegionMode"/></summary>
   public Eina.Rect InterestRegion {
      get { return GetInterestRegion(); }
   }
   /// <summary>Defines how <see cref="Efl.Ui.Widget.GetShowRegion"/> should be calculated.
/// It is up to the implementation of <see cref="Efl.Ui.Widget.GetShowRegion"/> to take this value into account (or ignore it).</summary>
   public Efl.Ui.InterestRegionMode InterestRegionMode {
      get { return GetInterestRegionMode(); }
      set { SetInterestRegionMode( value); }
   }
   /// <summary>The rectangle region to be highlighted on focus.
/// This is a rectangle region where the focus highlight should be displayed.</summary>
   public Eina.Rect FocusHighlightGeometry {
      get { return GetFocusHighlightGeometry(); }
   }
   /// <summary>Whether focus highlight is enabled or not.
/// As of EFL 1.21 focus highlight properties apply to a single window, not a single widget. As a consequence, calls to this function may be forwarded to the parent window. Future versions of EFL may implement widget-specific focus highlight properties.
/// 
/// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightStyle"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightAnimate"/>.</summary>
   public bool FocusHighlightEnabled {
      get { return GetFocusHighlightEnabled(); }
      set { SetFocusHighlightEnabled( value); }
   }
   /// <summary>Control the widget focus highlight style.
/// If <c>style</c> is <c>null</c>, the default will be used.
/// 
/// As of EFL 1.21 focus highlight properties apply to a single window, not a single widget. As a consequence, calls to this function may be forwarded to the parent window. Future versions of EFL may implement widget-specific focus highlight properties.
/// 
/// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightAnimate"/>.</summary>
   public  System.String FocusHighlightStyle {
      get { return GetFocusHighlightStyle(); }
      set { SetFocusHighlightStyle( value); }
   }
   /// <summary>Whether focus highlight should animate or not.
/// As of EFL 1.21 focus highlight properties apply to a single window, not a single widget. As a consequence, calls to this function may be forwarded to the parent window. Future versions of EFL may implement widget-specific focus highlight properties.
/// 
/// See also <see cref="Efl.Ui.Widget.GetWidgetTop"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightStyle"/>. See also <see cref="Efl.Ui.Widget.FocusHighlightEnabled"/>.</summary>
   public bool FocusHighlightAnimate {
      get { return GetFocusHighlightAnimate(); }
      set { SetFocusHighlightAnimate( value); }
   }
   /// <summary>Focus order property</summary>
   public  uint FocusOrder {
      get { return GetFocusOrder(); }
   }
   /// <summary>A custom chain of objects to pass focus.
/// Note: On focus cycle, only will be evaluated children of this container.</summary>
   public Eina.List<Efl.Canvas.Object> FocusCustomChain {
      get { return GetFocusCustomChain(); }
      set { SetFocusCustomChain( value); }
   }
   /// <summary>Current focused object in object tree.</summary>
   public Efl.Canvas.Object FocusedObject {
      get { return GetFocusedObject(); }
   }
   /// <summary>The widget&apos;s focus move policy.</summary>
   public Efl.Ui.Focus.MovePolicy FocusMovePolicy {
      get { return GetFocusMovePolicy(); }
      set { SetFocusMovePolicy( value); }
   }
   /// <summary>Control the widget&apos;s focus_move_policy mode setting.
/// 1.18</summary>
   public bool FocusMovePolicyAutomatic {
      get { return GetFocusMovePolicyAutomatic(); }
      set { SetFocusMovePolicyAutomatic( value); }
   }
   /// <summary>Get the focused widget item.</summary>
   public Elm.Widget.Item FocusedItem {
      get { return GetFocusedItem(); }
   }
   /// <summary>Get list of available widget actions</summary>
   public Eina.List<Efl.Access.ActionData> Actions {
      get { return GetActions(); }
   }
   /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
   public  int ZOrder {
      get { return GetZOrder(); }
   }
   /// <summary>Gets an localized string describing accessible object role name.</summary>
   public  System.String LocalizedRoleName {
      get { return GetLocalizedRoleName(); }
   }
   /// <summary>Accessible name of the object.</summary>
   public  System.String I18nName {
      get { return GetI18nName(); }
      set { SetI18nName( value); }
   }
   /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
   public Efl.Access.RelationSet RelationSet {
      get { return GetRelationSet(); }
   }
   /// <summary>The role of the object in accessibility domain.</summary>
   public Efl.Access.Role Role {
      get { return GetRole(); }
      set { SetRole( value); }
   }
   /// <summary>Gets object&apos;s accessible parent.</summary>
   public Efl.Access.Object AccessParent {
      get { return GetAccessParent(); }
      set { SetAccessParent( value); }
   }
   /// <summary>Gets object&apos;s accessible children.</summary>
   public Eina.List<Efl.Access.Object> AccessChildren {
      get { return GetAccessChildren(); }
   }
   /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
   public  System.String RoleName {
      get { return GetRoleName(); }
   }
   /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
   public Eina.List<Efl.Access.Attribute> Attributes {
      get { return GetAttributes(); }
   }
   /// <summary>Gets reading information types of an accessible object.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
   public Efl.Access.ReadingInfoTypeMask ReadingInfoType {
      get { return GetReadingInfoType(); }
      set { SetReadingInfoType( value); }
   }
   /// <summary>Gets index of the child in parent&apos;s children list.</summary>
   public  int IndexInParent {
      get { return GetIndexInParent(); }
   }
   /// <summary>Gets contextual information about object.</summary>
   public  System.String Description {
      get { return GetDescription(); }
      set { SetDescription( value); }
   }
   /// <summary>Gets set describing object accessible states.</summary>
   public Efl.Access.StateSet StateSet {
      get { return GetStateSet(); }
   }
   /// <summary>Gets highlightable of given widget.
/// @if WEARABLE @since_tizen 3.0 @endif</summary>
   public bool CanHighlight {
      get { return GetCanHighlight(); }
      set { SetCanHighlight( value); }
   }
   /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
/// Translation domain should be set if the application wants to support i18n for accessibily &quot;name&quot; and &quot;description&quot; properties.
/// 
/// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
/// 
/// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
   public  System.String TranslationDomain {
      get { return GetTranslationDomain(); }
      set { SetTranslationDomain( value); }
   }
   /// <summary>Get root object of accessible object hierarchy</summary>
   public static Efl.Object AccessRoot {
      get { return GetAccessRoot(); }
   }
   /// <summary>Elementary actions</summary>
   public Efl.Access.ActionData ElmActions {
      get { return GetElmActions(); }
   }
   /// <summary>The cursor to be shown when mouse is over the object
/// This is the cursor that will be displayed when mouse is over the object. The object can have only one cursor set to it so if <see cref="Efl.Ui.Cursor.SetCursor"/> is called twice for an object, the previous set will be unset.
/// 
/// If using X cursors, a definition of all the valid cursor names is listed on Elementary_Cursors.h. If an invalid name is set the default cursor will be used.</summary>
   public  System.String Cursor {
      get { return GetCursor(); }
      set { SetCursor( value); }
   }
   /// <summary>A different style for the cursor.
/// This only makes sense if theme cursors are used. The cursor should be set with <see cref="Efl.Ui.Cursor.SetCursor"/> first before setting its style with this property.</summary>
   public  System.String CursorStyle {
      get { return GetCursorStyle(); }
      set { SetCursorStyle( value); }
   }
   /// <summary>Whether the cursor may be looked in the theme or not.
/// If <c>false</c>, the cursor may only come from the render engine, i.e. from the display manager.</summary>
   public bool CursorThemeSearchEnabled {
      get { return GetCursorThemeSearchEnabled(); }
      set { SetCursorThemeSearchEnabled( value); }
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
public class WidgetNativeInherit : Efl.Canvas.GroupNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_widget_resize_object_set_static_delegate = new efl_ui_widget_resize_object_set_delegate(resize_object_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_resize_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_resize_object_set_static_delegate)});
      efl_ui_widget_disabled_get_static_delegate = new efl_ui_widget_disabled_get_delegate(disabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_get_static_delegate)});
      efl_ui_widget_disabled_set_static_delegate = new efl_ui_widget_disabled_set_delegate(disabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_set_static_delegate)});
      efl_ui_widget_style_get_static_delegate = new efl_ui_widget_style_get_delegate(style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_get_static_delegate)});
      efl_ui_widget_style_set_static_delegate = new efl_ui_widget_style_set_delegate(style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_set_static_delegate)});
      efl_ui_widget_focus_allow_get_static_delegate = new efl_ui_widget_focus_allow_get_delegate(focus_allow_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_get_static_delegate)});
      efl_ui_widget_focus_allow_set_static_delegate = new efl_ui_widget_focus_allow_set_delegate(focus_allow_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_set_static_delegate)});
      efl_ui_widget_parent_get_static_delegate = new efl_ui_widget_parent_get_delegate(widget_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_get_static_delegate)});
      efl_ui_widget_parent_set_static_delegate = new efl_ui_widget_parent_set_delegate(widget_parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_set_static_delegate)});
      efl_ui_widget_top_get_static_delegate = new efl_ui_widget_top_get_delegate(widget_top_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_top_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_top_get_static_delegate)});
      efl_ui_widget_access_info_get_static_delegate = new efl_ui_widget_access_info_get_delegate(access_info_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_access_info_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_access_info_get_static_delegate)});
      efl_ui_widget_access_info_set_static_delegate = new efl_ui_widget_access_info_set_delegate(access_info_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_access_info_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_access_info_set_static_delegate)});
      efl_ui_widget_orientation_mode_get_static_delegate = new efl_ui_widget_orientation_mode_get_delegate(orientation_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_orientation_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_orientation_mode_get_static_delegate)});
      efl_ui_widget_orientation_mode_set_static_delegate = new efl_ui_widget_orientation_mode_set_delegate(orientation_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_orientation_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_orientation_mode_set_static_delegate)});
      efl_ui_widget_on_show_region_hook_set_static_delegate = new efl_ui_widget_on_show_region_hook_set_delegate(on_show_region_hook_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_on_show_region_hook_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_show_region_hook_set_static_delegate)});
      efl_ui_widget_show_region_get_static_delegate = new efl_ui_widget_show_region_get_delegate(show_region_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_show_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_show_region_get_static_delegate)});
      efl_ui_widget_show_region_set_static_delegate = new efl_ui_widget_show_region_set_delegate(show_region_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_show_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_show_region_set_static_delegate)});
      efl_ui_widget_interest_region_get_static_delegate = new efl_ui_widget_interest_region_get_delegate(interest_region_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_interest_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_interest_region_get_static_delegate)});
      efl_ui_widget_interest_region_mode_get_static_delegate = new efl_ui_widget_interest_region_mode_get_delegate(interest_region_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_interest_region_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_interest_region_mode_get_static_delegate)});
      efl_ui_widget_interest_region_mode_set_static_delegate = new efl_ui_widget_interest_region_mode_set_delegate(interest_region_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_interest_region_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_interest_region_mode_set_static_delegate)});
      efl_ui_widget_focus_highlight_geometry_get_static_delegate = new efl_ui_widget_focus_highlight_geometry_get_delegate(focus_highlight_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_geometry_get_static_delegate)});
      efl_ui_widget_focus_highlight_enabled_get_static_delegate = new efl_ui_widget_focus_highlight_enabled_get_delegate(focus_highlight_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_enabled_get_static_delegate)});
      efl_ui_widget_focus_highlight_enabled_set_static_delegate = new efl_ui_widget_focus_highlight_enabled_set_delegate(focus_highlight_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_enabled_set_static_delegate)});
      efl_ui_widget_focus_highlight_style_get_static_delegate = new efl_ui_widget_focus_highlight_style_get_delegate(focus_highlight_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_style_get_static_delegate)});
      efl_ui_widget_focus_highlight_style_set_static_delegate = new efl_ui_widget_focus_highlight_style_set_delegate(focus_highlight_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_style_set_static_delegate)});
      efl_ui_widget_focus_highlight_animate_get_static_delegate = new efl_ui_widget_focus_highlight_animate_get_delegate(focus_highlight_animate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_animate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_animate_get_static_delegate)});
      efl_ui_widget_focus_highlight_animate_set_static_delegate = new efl_ui_widget_focus_highlight_animate_set_delegate(focus_highlight_animate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_highlight_animate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_animate_set_static_delegate)});
      efl_ui_widget_focus_order_get_static_delegate = new efl_ui_widget_focus_order_get_delegate(focus_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_order_get_static_delegate)});
      efl_ui_widget_focus_custom_chain_get_static_delegate = new efl_ui_widget_focus_custom_chain_get_delegate(focus_custom_chain_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_custom_chain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_get_static_delegate)});
      efl_ui_widget_focus_custom_chain_set_static_delegate = new efl_ui_widget_focus_custom_chain_set_delegate(focus_custom_chain_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_custom_chain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_set_static_delegate)});
      efl_ui_widget_focused_object_get_static_delegate = new efl_ui_widget_focused_object_get_delegate(focused_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focused_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_object_get_static_delegate)});
      efl_ui_widget_focus_move_policy_get_static_delegate = new efl_ui_widget_focus_move_policy_get_delegate(focus_move_policy_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_move_policy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_get_static_delegate)});
      efl_ui_widget_focus_move_policy_set_static_delegate = new efl_ui_widget_focus_move_policy_set_delegate(focus_move_policy_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_move_policy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_set_static_delegate)});
      efl_ui_widget_focus_move_policy_automatic_get_static_delegate = new efl_ui_widget_focus_move_policy_automatic_get_delegate(focus_move_policy_automatic_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_move_policy_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_automatic_get_static_delegate)});
      efl_ui_widget_focus_move_policy_automatic_set_static_delegate = new efl_ui_widget_focus_move_policy_automatic_set_delegate(focus_move_policy_automatic_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_move_policy_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_automatic_set_static_delegate)});
      efl_ui_widget_focused_item_get_static_delegate = new efl_ui_widget_focused_item_get_delegate(focused_item_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focused_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_item_get_static_delegate)});
      efl_ui_widget_event_static_delegate = new efl_ui_widget_event_delegate(widget_event);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_event"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_event_static_delegate)});
      efl_ui_widget_on_access_activate_static_delegate = new efl_ui_widget_on_access_activate_delegate(on_access_activate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_on_access_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_access_activate_static_delegate)});
      efl_ui_widget_on_access_update_static_delegate = new efl_ui_widget_on_access_update_delegate(on_access_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_on_access_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_access_update_static_delegate)});
      efl_ui_widget_screen_reader_static_delegate = new efl_ui_widget_screen_reader_delegate(screen_reader);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_screen_reader"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_screen_reader_static_delegate)});
      efl_ui_widget_atspi_static_delegate = new efl_ui_widget_atspi_delegate(atspi);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_atspi"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_atspi_static_delegate)});
      efl_ui_widget_sub_object_add_static_delegate = new efl_ui_widget_sub_object_add_delegate(widget_sub_object_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_sub_object_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_add_static_delegate)});
      efl_ui_widget_sub_object_del_static_delegate = new efl_ui_widget_sub_object_del_delegate(widget_sub_object_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_sub_object_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_del_static_delegate)});
      efl_ui_widget_on_orientation_update_static_delegate = new efl_ui_widget_on_orientation_update_delegate(on_orientation_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_on_orientation_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_orientation_update_static_delegate)});
      efl_ui_widget_on_disabled_update_static_delegate = new efl_ui_widget_on_disabled_update_delegate(on_disabled_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_on_disabled_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_disabled_update_static_delegate)});
      efl_ui_widget_theme_apply_static_delegate = new efl_ui_widget_theme_apply_delegate(theme_apply);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_theme_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_theme_apply_static_delegate)});
      efl_ui_widget_scroll_hold_push_static_delegate = new efl_ui_widget_scroll_hold_push_delegate(scroll_hold_push);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_scroll_hold_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_hold_push_static_delegate)});
      efl_ui_widget_scroll_hold_pop_static_delegate = new efl_ui_widget_scroll_hold_pop_delegate(scroll_hold_pop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_scroll_hold_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_hold_pop_static_delegate)});
      efl_ui_widget_scroll_freeze_push_static_delegate = new efl_ui_widget_scroll_freeze_push_delegate(scroll_freeze_push);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_scroll_freeze_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_freeze_push_static_delegate)});
      efl_ui_widget_scroll_freeze_pop_static_delegate = new efl_ui_widget_scroll_freeze_pop_delegate(scroll_freeze_pop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_scroll_freeze_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_freeze_pop_static_delegate)});
      efl_ui_widget_part_access_object_get_static_delegate = new efl_ui_widget_part_access_object_get_delegate(part_access_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_part_access_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_part_access_object_get_static_delegate)});
      efl_ui_widget_newest_focus_order_get_static_delegate = new efl_ui_widget_newest_focus_order_get_delegate(newest_focus_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_newest_focus_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_newest_focus_order_get_static_delegate)});
      efl_ui_widget_focus_next_object_set_static_delegate = new efl_ui_widget_focus_next_object_set_delegate(focus_next_object_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_set_static_delegate)});
      efl_ui_widget_focus_next_object_get_static_delegate = new efl_ui_widget_focus_next_object_get_delegate(focus_next_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_get_static_delegate)});
      efl_ui_widget_focus_next_item_set_static_delegate = new efl_ui_widget_focus_next_item_set_delegate(focus_next_item_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_item_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_item_set_static_delegate)});
      efl_ui_widget_focus_next_item_get_static_delegate = new efl_ui_widget_focus_next_item_get_delegate(focus_next_item_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_item_get_static_delegate)});
      efl_ui_widget_focus_tree_unfocusable_handle_static_delegate = new efl_ui_widget_focus_tree_unfocusable_handle_delegate(focus_tree_unfocusable_handle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_tree_unfocusable_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_tree_unfocusable_handle_static_delegate)});
      efl_ui_widget_focus_custom_chain_prepend_static_delegate = new efl_ui_widget_focus_custom_chain_prepend_delegate(focus_custom_chain_prepend);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_custom_chain_prepend"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_prepend_static_delegate)});
      efl_ui_widget_focus_cycle_static_delegate = new efl_ui_widget_focus_cycle_delegate(focus_cycle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_cycle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_cycle_static_delegate)});
      efl_ui_widget_focus_direction_static_delegate = new efl_ui_widget_focus_direction_delegate(focus_direction);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_direction"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_static_delegate)});
      efl_ui_widget_focus_next_manager_is_static_delegate = new efl_ui_widget_focus_next_manager_is_delegate(focus_next_manager_is);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_manager_is"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_manager_is_static_delegate)});
      efl_ui_widget_focus_list_direction_get_static_delegate = new efl_ui_widget_focus_list_direction_get_delegate(focus_list_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_list_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_list_direction_get_static_delegate)});
      efl_ui_widget_focused_object_clear_static_delegate = new efl_ui_widget_focused_object_clear_delegate(focused_object_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focused_object_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_object_clear_static_delegate)});
      efl_ui_widget_focus_direction_go_static_delegate = new efl_ui_widget_focus_direction_go_delegate(focus_direction_go);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_direction_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_go_static_delegate)});
      efl_ui_widget_focus_next_get_static_delegate = new efl_ui_widget_focus_next_get_delegate(focus_next_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_get_static_delegate)});
      efl_ui_widget_focus_restore_static_delegate = new efl_ui_widget_focus_restore_delegate(focus_restore);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_restore"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_restore_static_delegate)});
      efl_ui_widget_focus_custom_chain_unset_static_delegate = new efl_ui_widget_focus_custom_chain_unset_delegate(focus_custom_chain_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_custom_chain_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_unset_static_delegate)});
      efl_ui_widget_focus_steal_static_delegate = new efl_ui_widget_focus_steal_delegate(focus_steal);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_steal"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_steal_static_delegate)});
      efl_ui_widget_focus_hide_handle_static_delegate = new efl_ui_widget_focus_hide_handle_delegate(focus_hide_handle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_hide_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_hide_handle_static_delegate)});
      efl_ui_widget_focus_next_static_delegate = new efl_ui_widget_focus_next_delegate(focus_next);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_next"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_static_delegate)});
      efl_ui_widget_focus_list_next_get_static_delegate = new efl_ui_widget_focus_list_next_get_delegate(focus_list_next_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_list_next_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_list_next_get_static_delegate)});
      efl_ui_widget_focus_mouse_up_handle_static_delegate = new efl_ui_widget_focus_mouse_up_handle_delegate(focus_mouse_up_handle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_mouse_up_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_mouse_up_handle_static_delegate)});
      efl_ui_widget_focus_direction_get_static_delegate = new efl_ui_widget_focus_direction_get_delegate(focus_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_get_static_delegate)});
      efl_ui_widget_focus_disabled_handle_static_delegate = new efl_ui_widget_focus_disabled_handle_delegate(focus_disabled_handle);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_disabled_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_disabled_handle_static_delegate)});
      efl_ui_widget_focus_custom_chain_append_static_delegate = new efl_ui_widget_focus_custom_chain_append_delegate(focus_custom_chain_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_custom_chain_append"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_append_static_delegate)});
      efl_ui_widget_focus_reconfigure_static_delegate = new efl_ui_widget_focus_reconfigure_delegate(focus_reconfigure);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_reconfigure"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_reconfigure_static_delegate)});
      efl_ui_widget_focus_direction_manager_is_static_delegate = new efl_ui_widget_focus_direction_manager_is_delegate(focus_direction_manager_is);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_direction_manager_is"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_manager_is_static_delegate)});
      efl_ui_widget_focus_state_apply_static_delegate = new efl_ui_widget_focus_state_apply_delegate(focus_state_apply);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_state_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_state_apply_static_delegate)});
      efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate)});
      efl_access_action_name_get_static_delegate = new efl_access_action_name_get_delegate(action_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_name_get_static_delegate)});
      efl_access_action_localized_name_get_static_delegate = new efl_access_action_localized_name_get_delegate(action_localized_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_localized_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_localized_name_get_static_delegate)});
      efl_access_action_actions_get_static_delegate = new efl_access_action_actions_get_delegate(actions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_actions_get_static_delegate)});
      efl_access_action_do_static_delegate = new efl_access_action_do_delegate(action_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_do_static_delegate)});
      efl_access_action_keybinding_get_static_delegate = new efl_access_action_keybinding_get_delegate(action_keybinding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_action_keybinding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_keybinding_get_static_delegate)});
      efl_access_component_z_order_get_static_delegate = new efl_access_component_z_order_get_delegate(z_order_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_z_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_z_order_get_static_delegate)});
      efl_access_component_extents_get_static_delegate = new efl_access_component_extents_get_delegate(extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_get_static_delegate)});
      efl_access_component_extents_set_static_delegate = new efl_access_component_extents_set_delegate(extents_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_extents_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_set_static_delegate)});
      efl_access_component_screen_position_get_static_delegate = new efl_access_component_screen_position_get_delegate(screen_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_screen_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_get_static_delegate)});
      efl_access_component_screen_position_set_static_delegate = new efl_access_component_screen_position_set_delegate(screen_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_screen_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_set_static_delegate)});
      efl_access_component_socket_offset_get_static_delegate = new efl_access_component_socket_offset_get_delegate(socket_offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_socket_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_get_static_delegate)});
      efl_access_component_socket_offset_set_static_delegate = new efl_access_component_socket_offset_set_delegate(socket_offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_socket_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_set_static_delegate)});
      efl_access_component_contains_static_delegate = new efl_access_component_contains_delegate(contains);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_contains"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_contains_static_delegate)});
      efl_access_component_focus_grab_static_delegate = new efl_access_component_focus_grab_delegate(focus_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_focus_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_focus_grab_static_delegate)});
      efl_access_component_accessible_at_point_get_static_delegate = new efl_access_component_accessible_at_point_get_delegate(accessible_at_point_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_accessible_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_accessible_at_point_get_static_delegate)});
      efl_access_component_highlight_grab_static_delegate = new efl_access_component_highlight_grab_delegate(highlight_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_highlight_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_grab_static_delegate)});
      efl_access_component_highlight_clear_static_delegate = new efl_access_component_highlight_clear_delegate(highlight_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_component_highlight_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_clear_static_delegate)});
      efl_access_object_localized_role_name_get_static_delegate = new efl_access_object_localized_role_name_get_delegate(localized_role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_localized_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_localized_role_name_get_static_delegate)});
      efl_access_object_i18n_name_get_static_delegate = new efl_access_object_i18n_name_get_delegate(i18n_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_i18n_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_get_static_delegate)});
      efl_access_object_i18n_name_set_static_delegate = new efl_access_object_i18n_name_set_delegate(i18n_name_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_i18n_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_set_static_delegate)});
      efl_access_object_name_cb_set_static_delegate = new efl_access_object_name_cb_set_delegate(name_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_name_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_name_cb_set_static_delegate)});
      efl_access_object_relation_set_get_static_delegate = new efl_access_object_relation_set_get_delegate(relation_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_relation_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relation_set_get_static_delegate)});
      efl_access_object_role_get_static_delegate = new efl_access_object_role_get_delegate(role_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_get_static_delegate)});
      efl_access_object_role_set_static_delegate = new efl_access_object_role_set_delegate(role_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_set_static_delegate)});
      efl_access_object_access_parent_get_static_delegate = new efl_access_object_access_parent_get_delegate(access_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_access_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_get_static_delegate)});
      efl_access_object_access_parent_set_static_delegate = new efl_access_object_access_parent_set_delegate(access_parent_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_access_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_set_static_delegate)});
      efl_access_object_description_cb_set_static_delegate = new efl_access_object_description_cb_set_delegate(description_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_description_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_cb_set_static_delegate)});
      efl_access_object_gesture_cb_set_static_delegate = new efl_access_object_gesture_cb_set_delegate(gesture_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_gesture_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_cb_set_static_delegate)});
      efl_access_object_access_children_get_static_delegate = new efl_access_object_access_children_get_delegate(access_children_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_access_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_children_get_static_delegate)});
      efl_access_object_role_name_get_static_delegate = new efl_access_object_role_name_get_delegate(role_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_name_get_static_delegate)});
      efl_access_object_attributes_get_static_delegate = new efl_access_object_attributes_get_delegate(attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_get_static_delegate)});
      efl_access_object_reading_info_type_get_static_delegate = new efl_access_object_reading_info_type_get_delegate(reading_info_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_reading_info_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_get_static_delegate)});
      efl_access_object_reading_info_type_set_static_delegate = new efl_access_object_reading_info_type_set_delegate(reading_info_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_reading_info_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_set_static_delegate)});
      efl_access_object_index_in_parent_get_static_delegate = new efl_access_object_index_in_parent_get_delegate(index_in_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_index_in_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_index_in_parent_get_static_delegate)});
      efl_access_object_description_get_static_delegate = new efl_access_object_description_get_delegate(description_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_get_static_delegate)});
      efl_access_object_description_set_static_delegate = new efl_access_object_description_set_delegate(description_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_description_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_set_static_delegate)});
      efl_access_object_state_set_get_static_delegate = new efl_access_object_state_set_get_delegate(state_set_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_state_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_set_get_static_delegate)});
      efl_access_object_can_highlight_get_static_delegate = new efl_access_object_can_highlight_get_delegate(can_highlight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_can_highlight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_get_static_delegate)});
      efl_access_object_can_highlight_set_static_delegate = new efl_access_object_can_highlight_set_delegate(can_highlight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_can_highlight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_set_static_delegate)});
      efl_access_object_translation_domain_get_static_delegate = new efl_access_object_translation_domain_get_delegate(translation_domain_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_translation_domain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_get_static_delegate)});
      efl_access_object_translation_domain_set_static_delegate = new efl_access_object_translation_domain_set_delegate(translation_domain_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_translation_domain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_set_static_delegate)});
      efl_access_object_gesture_do_static_delegate = new efl_access_object_gesture_do_delegate(gesture_do);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_gesture_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_do_static_delegate)});
      efl_access_object_attribute_append_static_delegate = new efl_access_object_attribute_append_delegate(attribute_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_attribute_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_append_static_delegate)});
      efl_access_object_attributes_clear_static_delegate = new efl_access_object_attributes_clear_delegate(attributes_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_attributes_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_clear_static_delegate)});
      efl_access_object_relationship_append_static_delegate = new efl_access_object_relationship_append_delegate(relationship_append);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_relationship_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_append_static_delegate)});
      efl_access_object_relationship_remove_static_delegate = new efl_access_object_relationship_remove_delegate(relationship_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_relationship_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_remove_static_delegate)});
      efl_access_object_relationships_clear_static_delegate = new efl_access_object_relationships_clear_delegate(relationships_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_relationships_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationships_clear_static_delegate)});
      efl_access_object_state_notify_static_delegate = new efl_access_object_state_notify_delegate(state_notify);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_object_state_notify"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_notify_static_delegate)});
      efl_access_widget_action_elm_actions_get_static_delegate = new efl_access_widget_action_elm_actions_get_delegate(elm_actions_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_widget_action_elm_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_widget_action_elm_actions_get_static_delegate)});
      efl_ui_cursor_get_static_delegate = new efl_ui_cursor_get_delegate(cursor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_get_static_delegate)});
      efl_ui_cursor_set_static_delegate = new efl_ui_cursor_set_delegate(cursor_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_set_static_delegate)});
      efl_ui_cursor_style_get_static_delegate = new efl_ui_cursor_style_get_delegate(cursor_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_style_get_static_delegate)});
      efl_ui_cursor_style_set_static_delegate = new efl_ui_cursor_style_set_delegate(cursor_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_style_set_static_delegate)});
      efl_ui_cursor_theme_search_enabled_get_static_delegate = new efl_ui_cursor_theme_search_enabled_get_delegate(cursor_theme_search_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_theme_search_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_theme_search_enabled_get_static_delegate)});
      efl_ui_cursor_theme_search_enabled_set_static_delegate = new efl_ui_cursor_theme_search_enabled_set_delegate(cursor_theme_search_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_theme_search_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_theme_search_enabled_set_static_delegate)});
      efl_ui_dnd_drag_start_static_delegate = new efl_ui_dnd_drag_start_delegate(drag_start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_drag_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_start_static_delegate)});
      efl_ui_dnd_drag_action_set_static_delegate = new efl_ui_dnd_drag_action_set_delegate(drag_action_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_drag_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_action_set_static_delegate)});
      efl_ui_dnd_drag_cancel_static_delegate = new efl_ui_dnd_drag_cancel_delegate(drag_cancel);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_drag_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_cancel_static_delegate)});
      efl_ui_dnd_drop_target_add_static_delegate = new efl_ui_dnd_drop_target_add_delegate(drop_target_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_drop_target_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_add_static_delegate)});
      efl_ui_dnd_drop_target_del_static_delegate = new efl_ui_dnd_drop_target_del_delegate(drop_target_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_dnd_drop_target_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_del_static_delegate)});
      efl_ui_l10n_text_get_static_delegate = new efl_ui_l10n_text_get_delegate(l10n_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_l10n_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_get_static_delegate)});
      efl_ui_l10n_text_set_static_delegate = new efl_ui_l10n_text_set_delegate(l10n_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_l10n_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_set_static_delegate)});
      efl_ui_l10n_translation_update_static_delegate = new efl_ui_l10n_translation_update_delegate(translation_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_l10n_translation_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_translation_update_static_delegate)});
      efl_ui_selection_set_static_delegate = new efl_ui_selection_set_delegate(selection_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_set_static_delegate)});
      efl_ui_selection_get_static_delegate = new efl_ui_selection_get_delegate(selection_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_get_static_delegate)});
      efl_ui_selection_clear_static_delegate = new efl_ui_selection_clear_delegate(selection_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_clear_static_delegate)});
      efl_ui_selection_has_owner_static_delegate = new efl_ui_selection_has_owner_delegate(has_owner);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_has_owner_static_delegate)});
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
      return Efl.Ui.Widget.efl_ui_widget_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Widget.efl_ui_widget_class_get();
   }


    private delegate  void efl_ui_widget_resize_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_resize_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sobj);
    private static  void resize_object_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sobj)
   {
      Eina.Log.Debug("function efl_ui_widget_resize_object_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetResizeObject( sobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_resize_object_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sobj);
      }
   }
   private efl_ui_widget_resize_object_set_delegate efl_ui_widget_resize_object_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_disabled_get(System.IntPtr obj);
    private static bool disabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_disabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetDisabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_disabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_disabled_get_delegate efl_ui_widget_disabled_get_static_delegate;


    private delegate  void efl_ui_widget_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_disabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
    private static  void disabled_set(System.IntPtr obj, System.IntPtr pd,  bool disabled)
   {
      Eina.Log.Debug("function efl_ui_widget_disabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetDisabled( disabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_disabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disabled);
      }
   }
   private efl_ui_widget_disabled_set_delegate efl_ui_widget_disabled_set_static_delegate;


    private delegate  System.IntPtr efl_ui_widget_style_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_widget_style_get(System.IntPtr obj);
    private static  System.IntPtr style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_widget_style_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_style_get_delegate efl_ui_widget_style_get_static_delegate;


    private delegate Efl.Ui.ThemeApplyResult efl_ui_widget_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.ThemeApplyResult efl_ui_widget_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    private static Efl.Ui.ThemeApplyResult style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function efl_ui_widget_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.ThemeApplyResult _ret_var = default(Efl.Ui.ThemeApplyResult);
         try {
            _ret_var = ((Widget)wrapper).SetStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_style_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_ui_widget_style_set_delegate efl_ui_widget_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_allow_get(System.IntPtr obj);
    private static bool focus_allow_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_allow_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusAllow();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_allow_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_allow_get_delegate efl_ui_widget_focus_allow_get_static_delegate;


    private delegate  void efl_ui_widget_focus_allow_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_allow_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_focus);
    private static  void focus_allow_set(System.IntPtr obj, System.IntPtr pd,  bool can_focus)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_allow_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetFocusAllow( can_focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_allow_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_focus);
      }
   }
   private efl_ui_widget_focus_allow_set_delegate efl_ui_widget_focus_allow_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Widget efl_ui_widget_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Widget efl_ui_widget_parent_get(System.IntPtr obj);
    private static Efl.Ui.Widget widget_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Widget _ret_var = default(Efl.Ui.Widget);
         try {
            _ret_var = ((Widget)wrapper).GetWidgetParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_parent_get_delegate efl_ui_widget_parent_get_static_delegate;


    private delegate  void efl_ui_widget_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget parent);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget parent);
    private static  void widget_parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Widget parent)
   {
      Eina.Log.Debug("function efl_ui_widget_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetWidgetParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_parent_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private efl_ui_widget_parent_set_delegate efl_ui_widget_parent_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Widget efl_ui_widget_top_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Widget efl_ui_widget_top_get(System.IntPtr obj);
    private static Efl.Ui.Widget widget_top_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_top_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Widget _ret_var = default(Efl.Ui.Widget);
         try {
            _ret_var = ((Widget)wrapper).GetWidgetTop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_top_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_top_get_delegate efl_ui_widget_top_get_static_delegate;


    private delegate  System.IntPtr efl_ui_widget_access_info_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_widget_access_info_get(System.IntPtr obj);
    private static  System.IntPtr access_info_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_access_info_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetAccessInfo();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_widget_access_info_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_access_info_get_delegate efl_ui_widget_access_info_get_static_delegate;


    private delegate  void efl_ui_widget_access_info_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String txt);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_access_info_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String txt);
    private static  void access_info_set(System.IntPtr obj, System.IntPtr pd,   System.String txt)
   {
      Eina.Log.Debug("function efl_ui_widget_access_info_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetAccessInfo( txt);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_access_info_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  txt);
      }
   }
   private efl_ui_widget_access_info_set_delegate efl_ui_widget_access_info_set_static_delegate;


    private delegate Efl.Ui.WidgetOrientationMode efl_ui_widget_orientation_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.WidgetOrientationMode efl_ui_widget_orientation_mode_get(System.IntPtr obj);
    private static Efl.Ui.WidgetOrientationMode orientation_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_orientation_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.WidgetOrientationMode _ret_var = default(Efl.Ui.WidgetOrientationMode);
         try {
            _ret_var = ((Widget)wrapper).GetOrientationMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_orientation_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_orientation_mode_get_delegate efl_ui_widget_orientation_mode_get_static_delegate;


    private delegate  void efl_ui_widget_orientation_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.WidgetOrientationMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_orientation_mode_set(System.IntPtr obj,   Efl.Ui.WidgetOrientationMode mode);
    private static  void orientation_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WidgetOrientationMode mode)
   {
      Eina.Log.Debug("function efl_ui_widget_orientation_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetOrientationMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_orientation_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_widget_orientation_mode_set_delegate efl_ui_widget_orientation_mode_set_static_delegate;


    private delegate  void efl_ui_widget_on_show_region_hook_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.ScrollableOnShowRegionInternal func, EinaFreeCb func_free_cb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_on_show_region_hook_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.ScrollableOnShowRegionInternal func, EinaFreeCb func_free_cb);
    private static  void on_show_region_hook_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.ScrollableOnShowRegionInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_ui_widget_on_show_region_hook_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              Efl.Ui.ScrollableOnShowRegionWrapper func_wrapper = new Efl.Ui.ScrollableOnShowRegionWrapper(func, func_data, func_free_cb);
         
         try {
            ((Widget)wrapper).SetOnShowRegionHook( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_on_show_region_hook_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private efl_ui_widget_on_show_region_hook_set_delegate efl_ui_widget_on_show_region_hook_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_widget_show_region_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_widget_show_region_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal show_region_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_show_region_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Widget)wrapper).GetShowRegion();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_widget_show_region_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_show_region_get_delegate efl_ui_widget_show_region_get_static_delegate;


    private delegate  void efl_ui_widget_show_region_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal region,  [MarshalAs(UnmanagedType.U1)]  bool force);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_show_region_set(System.IntPtr obj,   Eina.Rect_StructInternal region,  [MarshalAs(UnmanagedType.U1)]  bool force);
    private static  void show_region_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal region,  bool force)
   {
      Eina.Log.Debug("function efl_ui_widget_show_region_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                                       
         try {
            ((Widget)wrapper).SetShowRegion( _in_region,  force);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_widget_show_region_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  region,  force);
      }
   }
   private efl_ui_widget_show_region_set_delegate efl_ui_widget_show_region_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_widget_interest_region_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_widget_interest_region_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal interest_region_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_interest_region_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Widget)wrapper).GetInterestRegion();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_widget_interest_region_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_interest_region_get_delegate efl_ui_widget_interest_region_get_static_delegate;


    private delegate Efl.Ui.InterestRegionMode efl_ui_widget_interest_region_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.InterestRegionMode efl_ui_widget_interest_region_mode_get(System.IntPtr obj);
    private static Efl.Ui.InterestRegionMode interest_region_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_interest_region_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.InterestRegionMode _ret_var = default(Efl.Ui.InterestRegionMode);
         try {
            _ret_var = ((Widget)wrapper).GetInterestRegionMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_interest_region_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_interest_region_mode_get_delegate efl_ui_widget_interest_region_mode_get_static_delegate;


    private delegate  void efl_ui_widget_interest_region_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.InterestRegionMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_interest_region_mode_set(System.IntPtr obj,   Efl.Ui.InterestRegionMode mode);
    private static  void interest_region_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.InterestRegionMode mode)
   {
      Eina.Log.Debug("function efl_ui_widget_interest_region_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetInterestRegionMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_interest_region_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_widget_interest_region_mode_set_delegate efl_ui_widget_interest_region_mode_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_widget_focus_highlight_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_widget_focus_highlight_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal focus_highlight_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Widget)wrapper).GetFocusHighlightGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_widget_focus_highlight_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_highlight_geometry_get_delegate efl_ui_widget_focus_highlight_geometry_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_highlight_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_highlight_enabled_get(System.IntPtr obj);
    private static bool focus_highlight_enabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusHighlightEnabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_highlight_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_highlight_enabled_get_delegate efl_ui_widget_focus_highlight_enabled_get_static_delegate;


    private delegate  void efl_ui_widget_focus_highlight_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_highlight_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void focus_highlight_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetFocusHighlightEnabled( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_highlight_enabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private efl_ui_widget_focus_highlight_enabled_set_delegate efl_ui_widget_focus_highlight_enabled_set_static_delegate;


    private delegate  System.IntPtr efl_ui_widget_focus_highlight_style_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_widget_focus_highlight_style_get(System.IntPtr obj);
    private static  System.IntPtr focus_highlight_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetFocusHighlightStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_widget_focus_highlight_style_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_highlight_style_get_delegate efl_ui_widget_focus_highlight_style_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_highlight_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_highlight_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    private static bool focus_highlight_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetFocusHighlightStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_highlight_style_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_ui_widget_focus_highlight_style_set_delegate efl_ui_widget_focus_highlight_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_highlight_animate_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_highlight_animate_get(System.IntPtr obj);
    private static bool focus_highlight_animate_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_animate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusHighlightAnimate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_highlight_animate_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_highlight_animate_get_delegate efl_ui_widget_focus_highlight_animate_get_static_delegate;


    private delegate  void efl_ui_widget_focus_highlight_animate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool animate);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_highlight_animate_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool animate);
    private static  void focus_highlight_animate_set(System.IntPtr obj, System.IntPtr pd,  bool animate)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_highlight_animate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetFocusHighlightAnimate( animate);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_highlight_animate_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  animate);
      }
   }
   private efl_ui_widget_focus_highlight_animate_set_delegate efl_ui_widget_focus_highlight_animate_set_static_delegate;


    private delegate  uint efl_ui_widget_focus_order_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  uint efl_ui_widget_focus_order_get(System.IntPtr obj);
    private static  uint focus_order_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Widget)wrapper).GetFocusOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_order_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_order_get_delegate efl_ui_widget_focus_order_get_static_delegate;


    private delegate  System.IntPtr efl_ui_widget_focus_custom_chain_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_widget_focus_custom_chain_get(System.IntPtr obj);
    private static  System.IntPtr focus_custom_chain_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Canvas.Object> _ret_var = default(Eina.List<Efl.Canvas.Object>);
         try {
            _ret_var = ((Widget)wrapper).GetFocusCustomChain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_widget_focus_custom_chain_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_custom_chain_get_delegate efl_ui_widget_focus_custom_chain_get_static_delegate;


    private delegate  void efl_ui_widget_focus_custom_chain_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr objs);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_custom_chain_set(System.IntPtr obj,    System.IntPtr objs);
    private static  void focus_custom_chain_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr objs)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_objs = new Eina.List<Efl.Canvas.Object>(objs, false, false);
                     
         try {
            ((Widget)wrapper).SetFocusCustomChain( _in_objs);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_custom_chain_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  objs);
      }
   }
   private efl_ui_widget_focus_custom_chain_set_delegate efl_ui_widget_focus_custom_chain_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_widget_focused_object_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_widget_focused_object_get(System.IntPtr obj);
    private static Efl.Canvas.Object focused_object_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focused_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Widget)wrapper).GetFocusedObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focused_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focused_object_get_delegate efl_ui_widget_focused_object_get_static_delegate;


    private delegate Efl.Ui.Focus.MovePolicy efl_ui_widget_focus_move_policy_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.Focus.MovePolicy efl_ui_widget_focus_move_policy_get(System.IntPtr obj);
    private static Efl.Ui.Focus.MovePolicy focus_move_policy_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_move_policy_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.MovePolicy _ret_var = default(Efl.Ui.Focus.MovePolicy);
         try {
            _ret_var = ((Widget)wrapper).GetFocusMovePolicy();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_move_policy_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_move_policy_get_delegate efl_ui_widget_focus_move_policy_get_static_delegate;


    private delegate  void efl_ui_widget_focus_move_policy_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.MovePolicy policy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_move_policy_set(System.IntPtr obj,   Efl.Ui.Focus.MovePolicy policy);
    private static  void focus_move_policy_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.MovePolicy policy)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_move_policy_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetFocusMovePolicy( policy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_move_policy_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  policy);
      }
   }
   private efl_ui_widget_focus_move_policy_set_delegate efl_ui_widget_focus_move_policy_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_move_policy_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_move_policy_automatic_get(System.IntPtr obj);
    private static bool focus_move_policy_automatic_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_move_policy_automatic_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusMovePolicyAutomatic();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_move_policy_automatic_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_move_policy_automatic_get_delegate efl_ui_widget_focus_move_policy_automatic_get_static_delegate;


    private delegate  void efl_ui_widget_focus_move_policy_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_move_policy_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
    private static  void focus_move_policy_automatic_set(System.IntPtr obj, System.IntPtr pd,  bool automatic)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_move_policy_automatic_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetFocusMovePolicyAutomatic( automatic);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_move_policy_automatic_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  automatic);
      }
   }
   private efl_ui_widget_focus_move_policy_automatic_set_delegate efl_ui_widget_focus_move_policy_automatic_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private delegate Elm.Widget.Item efl_ui_widget_focused_item_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private static extern Elm.Widget.Item efl_ui_widget_focused_item_get(System.IntPtr obj);
    private static Elm.Widget.Item focused_item_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focused_item_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Widget.Item _ret_var = default(Elm.Widget.Item);
         try {
            _ret_var = ((Widget)wrapper).GetFocusedItem();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focused_item_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focused_item_get_delegate efl_ui_widget_focused_item_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_event_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Event_StructInternal eo_event, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object source);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_event(System.IntPtr obj,   ref Efl.Event_StructInternal eo_event, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object source);
    private static bool widget_event(System.IntPtr obj, System.IntPtr pd,  ref Efl.Event_StructInternal eo_event,  Efl.Canvas.Object source)
   {
      Eina.Log.Debug("function efl_ui_widget_event was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_eo_event = Efl.Event_StructConversion.ToManaged(eo_event);
                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).WidgetEvent( ref _in_eo_event,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  eo_event = Efl.Event_StructConversion.ToInternal(_in_eo_event);
            return _ret_var;
      } else {
         return efl_ui_widget_event(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref eo_event,  source);
      }
   }
   private efl_ui_widget_event_delegate efl_ui_widget_event_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_on_access_activate_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Activate act);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_on_access_activate(System.IntPtr obj,   Efl.Ui.Activate act);
    private static bool on_access_activate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Activate act)
   {
      Eina.Log.Debug("function efl_ui_widget_on_access_activate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).OnAccessActivate( act);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_on_access_activate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  act);
      }
   }
   private efl_ui_widget_on_access_activate_delegate efl_ui_widget_on_access_activate_static_delegate;


    private delegate  void efl_ui_widget_on_access_update_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_on_access_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    private static  void on_access_update(System.IntPtr obj, System.IntPtr pd,  bool enable)
   {
      Eina.Log.Debug("function efl_ui_widget_on_access_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).UpdateOnAccess( enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_on_access_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
      }
   }
   private efl_ui_widget_on_access_update_delegate efl_ui_widget_on_access_update_static_delegate;


    private delegate  void efl_ui_widget_screen_reader_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_screen_reader);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_screen_reader(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_screen_reader);
    private static  void screen_reader(System.IntPtr obj, System.IntPtr pd,  bool is_screen_reader)
   {
      Eina.Log.Debug("function efl_ui_widget_screen_reader was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).ScreenReader( is_screen_reader);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_screen_reader(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_screen_reader);
      }
   }
   private efl_ui_widget_screen_reader_delegate efl_ui_widget_screen_reader_static_delegate;


    private delegate  void efl_ui_widget_atspi_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_atspi);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_atspi(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_atspi);
    private static  void atspi(System.IntPtr obj, System.IntPtr pd,  bool is_atspi)
   {
      Eina.Log.Debug("function efl_ui_widget_atspi was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).Atspi( is_atspi);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_atspi(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_atspi);
      }
   }
   private efl_ui_widget_atspi_delegate efl_ui_widget_atspi_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_sub_object_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_sub_object_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    private static bool widget_sub_object_add(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_ui_widget_sub_object_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).AddWidgetSubObject( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_sub_object_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private efl_ui_widget_sub_object_add_delegate efl_ui_widget_sub_object_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_sub_object_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_sub_object_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object sub_obj);
    private static bool widget_sub_object_del(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object sub_obj)
   {
      Eina.Log.Debug("function efl_ui_widget_sub_object_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).DelWidgetSubObject( sub_obj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_sub_object_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sub_obj);
      }
   }
   private efl_ui_widget_sub_object_del_delegate efl_ui_widget_sub_object_del_static_delegate;


    private delegate  void efl_ui_widget_on_orientation_update_delegate(System.IntPtr obj, System.IntPtr pd,    int rotation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_on_orientation_update(System.IntPtr obj,    int rotation);
    private static  void on_orientation_update(System.IntPtr obj, System.IntPtr pd,   int rotation)
   {
      Eina.Log.Debug("function efl_ui_widget_on_orientation_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).UpdateOnOrientation( rotation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_on_orientation_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rotation);
      }
   }
   private efl_ui_widget_on_orientation_update_delegate efl_ui_widget_on_orientation_update_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_on_disabled_update_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_on_disabled_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
    private static bool on_disabled_update(System.IntPtr obj, System.IntPtr pd,  bool disabled)
   {
      Eina.Log.Debug("function efl_ui_widget_on_disabled_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).UpdateOnDisabled( disabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_on_disabled_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disabled);
      }
   }
   private efl_ui_widget_on_disabled_update_delegate efl_ui_widget_on_disabled_update_static_delegate;


    private delegate Efl.Ui.ThemeApplyResult efl_ui_widget_theme_apply_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.ThemeApplyResult efl_ui_widget_theme_apply(System.IntPtr obj);
    private static Efl.Ui.ThemeApplyResult theme_apply(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_theme_apply was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.ThemeApplyResult _ret_var = default(Efl.Ui.ThemeApplyResult);
         try {
            _ret_var = ((Widget)wrapper).ThemeApply();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_theme_apply(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_theme_apply_delegate efl_ui_widget_theme_apply_static_delegate;


    private delegate  void efl_ui_widget_scroll_hold_push_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_scroll_hold_push(System.IntPtr obj);
    private static  void scroll_hold_push(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_scroll_hold_push was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).PushScrollHold();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_scroll_hold_push(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_scroll_hold_push_delegate efl_ui_widget_scroll_hold_push_static_delegate;


    private delegate  void efl_ui_widget_scroll_hold_pop_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_scroll_hold_pop(System.IntPtr obj);
    private static  void scroll_hold_pop(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_scroll_hold_pop was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).PopScrollHold();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_scroll_hold_pop(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_scroll_hold_pop_delegate efl_ui_widget_scroll_hold_pop_static_delegate;


    private delegate  void efl_ui_widget_scroll_freeze_push_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_scroll_freeze_push(System.IntPtr obj);
    private static  void scroll_freeze_push(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_scroll_freeze_push was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).PushScrollFreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_scroll_freeze_push(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_scroll_freeze_push_delegate efl_ui_widget_scroll_freeze_push_static_delegate;


    private delegate  void efl_ui_widget_scroll_freeze_pop_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_scroll_freeze_pop(System.IntPtr obj);
    private static  void scroll_freeze_pop(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_scroll_freeze_pop was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).PopScrollFreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_scroll_freeze_pop(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_scroll_freeze_pop_delegate efl_ui_widget_scroll_freeze_pop_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_widget_part_access_object_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_widget_part_access_object_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String part);
    private static Efl.Canvas.Object part_access_object_get(System.IntPtr obj, System.IntPtr pd,   System.String part)
   {
      Eina.Log.Debug("function efl_ui_widget_part_access_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Widget)wrapper).GetPartAccessObject( part);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_part_access_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
      }
   }
   private efl_ui_widget_part_access_object_get_delegate efl_ui_widget_part_access_object_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_widget_newest_focus_order_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  uint newest_focus_order,  [MarshalAs(UnmanagedType.U1)]  bool can_focus_only);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_widget_newest_focus_order_get(System.IntPtr obj,   out  uint newest_focus_order,  [MarshalAs(UnmanagedType.U1)]  bool can_focus_only);
    private static Efl.Canvas.Object newest_focus_order_get(System.IntPtr obj, System.IntPtr pd,  out  uint newest_focus_order,  bool can_focus_only)
   {
      Eina.Log.Debug("function efl_ui_widget_newest_focus_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           newest_focus_order = default( uint);                           Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Widget)wrapper).GetNewestFocusOrder( out newest_focus_order,  can_focus_only);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_widget_newest_focus_order_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out newest_focus_order,  can_focus_only);
      }
   }
   private efl_ui_widget_newest_focus_order_get_delegate efl_ui_widget_newest_focus_order_get_static_delegate;


    private delegate  void efl_ui_widget_focus_next_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object next,   Efl.Ui.Focus.Direction dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_next_object_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object next,   Efl.Ui.Focus.Direction dir);
    private static  void focus_next_object_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_object_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetFocusNextObject( next,  dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_widget_focus_next_object_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  next,  dir);
      }
   }
   private efl_ui_widget_focus_next_object_set_delegate efl_ui_widget_focus_next_object_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_widget_focus_next_object_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_ui_widget_focus_next_object_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
    private static Efl.Canvas.Object focus_next_object_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Widget)wrapper).GetFocusNextObject( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_next_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_widget_focus_next_object_get_delegate efl_ui_widget_focus_next_object_get_static_delegate;


    private delegate  void efl_ui_widget_focus_next_item_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item next_item,   Efl.Ui.Focus.Direction dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_next_item_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item next_item,   Efl.Ui.Focus.Direction dir);
    private static  void focus_next_item_set(System.IntPtr obj, System.IntPtr pd,  Elm.Widget.Item next_item,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_item_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetFocusNextItem( next_item,  dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_widget_focus_next_item_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  next_item,  dir);
      }
   }
   private efl_ui_widget_focus_next_item_set_delegate efl_ui_widget_focus_next_item_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private delegate Elm.Widget.Item efl_ui_widget_focus_next_item_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))] private static extern Elm.Widget.Item efl_ui_widget_focus_next_item_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
    private static Elm.Widget.Item focus_next_item_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_item_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Elm.Widget.Item _ret_var = default(Elm.Widget.Item);
         try {
            _ret_var = ((Widget)wrapper).GetFocusNextItem( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_next_item_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_widget_focus_next_item_get_delegate efl_ui_widget_focus_next_item_get_static_delegate;


    private delegate  void efl_ui_widget_focus_tree_unfocusable_handle_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_tree_unfocusable_handle(System.IntPtr obj);
    private static  void focus_tree_unfocusable_handle(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_tree_unfocusable_handle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusTreeUnfocusableHandle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_tree_unfocusable_handle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_tree_unfocusable_handle_delegate efl_ui_widget_focus_tree_unfocusable_handle_static_delegate;


    private delegate  void efl_ui_widget_focus_custom_chain_prepend_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_custom_chain_prepend(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
    private static  void focus_custom_chain_prepend(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object child,  Efl.Canvas.Object relative_child)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_prepend was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).FocusCustomChainPrepend( child,  relative_child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_widget_focus_custom_chain_prepend(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child,  relative_child);
      }
   }
   private efl_ui_widget_focus_custom_chain_prepend_delegate efl_ui_widget_focus_custom_chain_prepend_static_delegate;


    private delegate  void efl_ui_widget_focus_cycle_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_cycle(System.IntPtr obj,   Efl.Ui.Focus.Direction dir);
    private static  void focus_cycle(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_cycle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).FocusCycle( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_cycle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_widget_focus_cycle_delegate efl_ui_widget_focus_cycle_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_direction_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_direction(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
    private static bool focus_direction(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object kw_base,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_direction was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                         direction = default(Efl.Canvas.Object);      direction_item = default(Elm.Widget.Item);      weight = default(double);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).FocusDirection( kw_base,  degree,  out direction,  out direction_item,  out weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_ui_widget_focus_direction(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_base,  degree,  out direction,  out direction_item,  out weight);
      }
   }
   private efl_ui_widget_focus_direction_delegate efl_ui_widget_focus_direction_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_next_manager_is_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_next_manager_is(System.IntPtr obj);
    private static bool focus_next_manager_is(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_manager_is was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).IsFocusNextManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_next_manager_is(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_next_manager_is_delegate efl_ui_widget_focus_next_manager_is_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_list_direction_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,    System.IntPtr items,    System.IntPtr list_data_get,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_list_direction_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,    System.IntPtr items,    System.IntPtr list_data_get,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
    private static bool focus_list_direction_get(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object kw_base,   System.IntPtr items,   System.IntPtr list_data_get,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_list_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_items = new Eina.List<Efl.Object>(items, false, false);
                                                            direction = default(Efl.Canvas.Object);      direction_item = default(Elm.Widget.Item);      weight = default(double);                                                   bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusListDirection( kw_base,  _in_items,  list_data_get,  degree,  out direction,  out direction_item,  out weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                          return _ret_var;
      } else {
         return efl_ui_widget_focus_list_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_base,  items,  list_data_get,  degree,  out direction,  out direction_item,  out weight);
      }
   }
   private efl_ui_widget_focus_list_direction_get_delegate efl_ui_widget_focus_list_direction_get_static_delegate;


    private delegate  void efl_ui_widget_focused_object_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focused_object_clear(System.IntPtr obj);
    private static  void focused_object_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focused_object_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).ClearFocusedObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focused_object_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focused_object_clear_delegate efl_ui_widget_focused_object_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_direction_go_delegate(System.IntPtr obj, System.IntPtr pd,   double degree);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_direction_go(System.IntPtr obj,   double degree);
    private static bool focus_direction_go(System.IntPtr obj, System.IntPtr pd,  double degree)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_direction_go was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).FocusDirectionGo( degree);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_direction_go(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degree);
      }
   }
   private efl_ui_widget_focus_direction_go_delegate efl_ui_widget_focus_direction_go_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_next_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_next_get(System.IntPtr obj,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
    private static bool focus_next_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       next = default(Efl.Canvas.Object);      next_item = default(Elm.Widget.Item);                           bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusNext( dir,  out next,  out next_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_widget_focus_next_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir,  out next,  out next_item);
      }
   }
   private efl_ui_widget_focus_next_get_delegate efl_ui_widget_focus_next_get_static_delegate;


    private delegate  void efl_ui_widget_focus_restore_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_restore(System.IntPtr obj);
    private static  void focus_restore(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_restore was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusRestore();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_restore(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_restore_delegate efl_ui_widget_focus_restore_static_delegate;


    private delegate  void efl_ui_widget_focus_custom_chain_unset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_custom_chain_unset(System.IntPtr obj);
    private static  void focus_custom_chain_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).UnsetFocusCustomChain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_custom_chain_unset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_custom_chain_unset_delegate efl_ui_widget_focus_custom_chain_unset_static_delegate;


    private delegate  void efl_ui_widget_focus_steal_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_steal(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  Elm.Widget.Item item);
    private static  void focus_steal(System.IntPtr obj, System.IntPtr pd,  Elm.Widget.Item item)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_steal was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).FocusSteal( item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_widget_focus_steal(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item);
      }
   }
   private efl_ui_widget_focus_steal_delegate efl_ui_widget_focus_steal_static_delegate;


    private delegate  void efl_ui_widget_focus_hide_handle_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_hide_handle(System.IntPtr obj);
    private static  void focus_hide_handle(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_hide_handle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusHideHandle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_hide_handle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_hide_handle_delegate efl_ui_widget_focus_hide_handle_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_next_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_next(System.IntPtr obj,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
    private static bool focus_next(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_next was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       next = default(Efl.Canvas.Object);      next_item = default(Elm.Widget.Item);                           bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).FocusNext( dir,  out next,  out next_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_widget_focus_next(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir,  out next,  out next_item);
      }
   }
   private efl_ui_widget_focus_next_delegate efl_ui_widget_focus_next_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_list_next_get_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr items,    System.IntPtr list_data_get,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_list_next_get(System.IntPtr obj,    System.IntPtr items,    System.IntPtr list_data_get,   Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item next_item);
    private static bool focus_list_next_get(System.IntPtr obj, System.IntPtr pd,   System.IntPtr items,   System.IntPtr list_data_get,  Efl.Ui.Focus.Direction dir,  out Efl.Canvas.Object next,  out Elm.Widget.Item next_item)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_list_next_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_items = new Eina.List<Efl.Object>(items, false, false);
                                                next = default(Efl.Canvas.Object);      next_item = default(Elm.Widget.Item);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusListNext( _in_items,  list_data_get,  dir,  out next,  out next_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_ui_widget_focus_list_next_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  items,  list_data_get,  dir,  out next,  out next_item);
      }
   }
   private efl_ui_widget_focus_list_next_get_delegate efl_ui_widget_focus_list_next_get_static_delegate;


    private delegate  void efl_ui_widget_focus_mouse_up_handle_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_mouse_up_handle(System.IntPtr obj);
    private static  void focus_mouse_up_handle(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_mouse_up_handle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusMouseUpHandle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_mouse_up_handle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_mouse_up_handle_delegate efl_ui_widget_focus_mouse_up_handle_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_direction_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_direction_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_base,   double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Elm.Widget.Item, Efl.Eo.NonOwnTag>))]  out Elm.Widget.Item direction_item,   out double weight);
    private static bool focus_direction_get(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object kw_base,  double degree,  out Efl.Canvas.Object direction,  out Elm.Widget.Item direction_item,  out double weight)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                         direction = default(Efl.Canvas.Object);      direction_item = default(Elm.Widget.Item);      weight = default(double);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetFocusDirection( kw_base,  degree,  out direction,  out direction_item,  out weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_ui_widget_focus_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_base,  degree,  out direction,  out direction_item,  out weight);
      }
   }
   private efl_ui_widget_focus_direction_get_delegate efl_ui_widget_focus_direction_get_static_delegate;


    private delegate  void efl_ui_widget_focus_disabled_handle_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_disabled_handle(System.IntPtr obj);
    private static  void focus_disabled_handle(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_disabled_handle was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusDisabledHandle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_disabled_handle(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_disabled_handle_delegate efl_ui_widget_focus_disabled_handle_static_delegate;


    private delegate  void efl_ui_widget_focus_custom_chain_append_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_custom_chain_append(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object relative_child);
    private static  void focus_custom_chain_append(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object child,  Efl.Canvas.Object relative_child)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).AppendFocusCustomChain( child,  relative_child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_widget_focus_custom_chain_append(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child,  relative_child);
      }
   }
   private efl_ui_widget_focus_custom_chain_append_delegate efl_ui_widget_focus_custom_chain_append_static_delegate;


    private delegate  void efl_ui_widget_focus_reconfigure_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_widget_focus_reconfigure(System.IntPtr obj);
    private static  void focus_reconfigure(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_reconfigure was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).FocusReconfigure();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_widget_focus_reconfigure(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_reconfigure_delegate efl_ui_widget_focus_reconfigure_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_direction_manager_is_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_direction_manager_is(System.IntPtr obj);
    private static bool focus_direction_manager_is(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_direction_manager_is was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).IsFocusDirectionManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_widget_focus_direction_manager_is(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_widget_focus_direction_manager_is_delegate efl_ui_widget_focus_direction_manager_is_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_widget_focus_state_apply_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.WidgetFocusState_StructInternal current_state,   ref Efl.Ui.WidgetFocusState_StructInternal configured_state, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget redirect);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_widget_focus_state_apply(System.IntPtr obj,   Efl.Ui.WidgetFocusState_StructInternal current_state,   ref Efl.Ui.WidgetFocusState_StructInternal configured_state, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Widget, Efl.Eo.NonOwnTag>))]  Efl.Ui.Widget redirect);
    private static bool focus_state_apply(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WidgetFocusState_StructInternal current_state,  ref Efl.Ui.WidgetFocusState_StructInternal configured_state,  Efl.Ui.Widget redirect)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_state_apply was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_current_state = Efl.Ui.WidgetFocusState_StructConversion.ToManaged(current_state);
                        Efl.Ui.WidgetFocusState _out_configured_state = default(Efl.Ui.WidgetFocusState);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).FocusStateApply( _in_current_state,  ref _out_configured_state,  redirect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            configured_state = Efl.Ui.WidgetFocusState_StructConversion.ToInternal(_out_configured_state);
                              return _ret_var;
      } else {
         return efl_ui_widget_focus_state_apply(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  current_state,  ref configured_state,  redirect);
      }
   }
   private efl_ui_widget_focus_state_apply_delegate efl_ui_widget_focus_state_apply_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_part_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_part_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Widget)wrapper).GetPart( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_part_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_part_get_delegate efl_part_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_name_get(System.IntPtr obj,    int id);
    private static  System.IntPtr action_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetActionName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_action_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_name_get_delegate efl_access_action_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_localized_name_get(System.IntPtr obj,    int id);
    private static  System.IntPtr action_localized_name_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_localized_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetActionLocalizedName( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_action_localized_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_localized_name_get_delegate efl_access_action_localized_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_action_actions_get(System.IntPtr obj);
    private static  System.IntPtr actions_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_action_actions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.ActionData> _ret_var = default(Eina.List<Efl.Access.ActionData>);
         try {
            _ret_var = ((Widget)wrapper).GetActions();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_access_action_actions_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_action_actions_get_delegate efl_access_action_actions_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_action_do(System.IntPtr obj,    int id);
    private static bool action_do(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).ActionDo( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_do(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_do_delegate efl_access_action_do_static_delegate;


    private delegate  System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.String efl_access_action_keybinding_get(System.IntPtr obj,    int id);
    private static  System.String action_keybinding_get(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_access_action_keybinding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetActionKeybinding( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_action_keybinding_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_access_action_keybinding_get_delegate efl_access_action_keybinding_get_static_delegate;


    private delegate  int efl_access_component_z_order_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_access_component_z_order_get(System.IntPtr obj);
    private static  int z_order_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_z_order_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Widget)wrapper).GetZOrder();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_z_order_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_z_order_get_delegate efl_access_component_z_order_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_access_component_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_access_component_extents_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords);
    private static Eina.Rect_StructInternal extents_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords)
   {
      Eina.Log.Debug("function efl_access_component_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Widget)wrapper).GetExtents( screen_coords);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_access_component_extents_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords);
      }
   }
   private efl_access_component_extents_get_delegate efl_access_component_extents_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_extents_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_extents_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect);
    private static bool extents_set(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,  Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_component_extents_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetExtents( screen_coords,  _in_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_extents_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  rect);
      }
   }
   private efl_access_component_extents_set_delegate efl_access_component_extents_set_static_delegate;


    private delegate  void efl_access_component_screen_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_screen_position_get(System.IntPtr obj,   out  int x,   out  int y);
    private static  void screen_position_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((Widget)wrapper).GetScreenPosition( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_screen_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_access_component_screen_position_get_delegate efl_access_component_screen_position_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_screen_position_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_screen_position_set(System.IntPtr obj,    int x,    int y);
    private static bool screen_position_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_screen_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetScreenPosition( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_component_screen_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_access_component_screen_position_set_delegate efl_access_component_screen_position_set_static_delegate;


    private delegate  void efl_access_component_socket_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int x,   out  int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_socket_offset_get(System.IntPtr obj,   out  int x,   out  int y);
    private static  void socket_offset_get(System.IntPtr obj, System.IntPtr pd,  out  int x,  out  int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default( int);      y = default( int);                     
         try {
            ((Widget)wrapper).GetSocketOffset( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_access_component_socket_offset_get_delegate efl_access_component_socket_offset_get_static_delegate;


    private delegate  void efl_access_component_socket_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_component_socket_offset_set(System.IntPtr obj,    int x,    int y);
    private static  void socket_offset_set(System.IntPtr obj, System.IntPtr pd,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_socket_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetSocketOffset( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_component_socket_offset_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_access_component_socket_offset_set_delegate efl_access_component_socket_offset_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_contains_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_contains(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    private static bool contains(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_contains was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).Contains( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_contains(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private efl_access_component_contains_delegate efl_access_component_contains_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_focus_grab_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_focus_grab(System.IntPtr obj);
    private static bool focus_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_focus_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GrabFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_focus_grab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_focus_grab_delegate efl_access_component_focus_grab_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_component_accessible_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_component_accessible_at_point_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    private static Efl.Object accessible_at_point_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_component_accessible_at_point_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Widget)wrapper).GetAccessibleAtPoint( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_component_accessible_at_point_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private efl_access_component_accessible_at_point_get_delegate efl_access_component_accessible_at_point_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_grab_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_grab(System.IntPtr obj);
    private static bool highlight_grab(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GrabHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_grab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_highlight_grab_delegate efl_access_component_highlight_grab_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_component_highlight_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_component_highlight_clear(System.IntPtr obj);
    private static bool highlight_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_component_highlight_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).ClearHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_component_highlight_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_component_highlight_clear_delegate efl_access_component_highlight_clear_static_delegate;


    private delegate  System.IntPtr efl_access_object_localized_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_localized_role_name_get(System.IntPtr obj);
    private static  System.IntPtr localized_role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_localized_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetLocalizedRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_object_localized_role_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_localized_role_name_get_delegate efl_access_object_localized_role_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_i18n_name_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_i18n_name_get(System.IntPtr obj);
    private static  System.IntPtr i18n_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetI18nName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_object_i18n_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_i18n_name_get_delegate efl_access_object_i18n_name_get_static_delegate;


    private delegate  void efl_access_object_i18n_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_i18n_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String i18n_name);
    private static  void i18n_name_set(System.IntPtr obj, System.IntPtr pd,   System.String i18n_name)
   {
      Eina.Log.Debug("function efl_access_object_i18n_name_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetI18nName( i18n_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_i18n_name_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  i18n_name);
      }
   }
   private efl_access_object_i18n_name_set_delegate efl_access_object_i18n_name_set_static_delegate;


    private delegate  void efl_access_object_name_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_name_cb_set(System.IntPtr obj,   Efl.Access.ReadingInfoCb name_cb,    System.IntPtr data);
    private static  void name_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb name_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_name_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetNameCb( name_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_name_cb_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name_cb,  data);
      }
   }
   private efl_access_object_name_cb_set_delegate efl_access_object_name_cb_set_static_delegate;


    private delegate Efl.Access.RelationSet efl_access_object_relation_set_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Access.RelationSet efl_access_object_relation_set_get(System.IntPtr obj);
    private static Efl.Access.RelationSet relation_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relation_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.RelationSet _ret_var = default(Efl.Access.RelationSet);
         try {
            _ret_var = ((Widget)wrapper).GetRelationSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_relation_set_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_relation_set_get_delegate efl_access_object_relation_set_get_static_delegate;


    private delegate Efl.Access.Role efl_access_object_role_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Access.Role efl_access_object_role_get(System.IntPtr obj);
    private static Efl.Access.Role role_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Role _ret_var = default(Efl.Access.Role);
         try {
            _ret_var = ((Widget)wrapper).GetRole();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_role_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_role_get_delegate efl_access_object_role_get_static_delegate;


    private delegate  void efl_access_object_role_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.Role role);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_role_set(System.IntPtr obj,   Efl.Access.Role role);
    private static  void role_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Role role)
   {
      Eina.Log.Debug("function efl_access_object_role_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetRole( role);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_role_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  role);
      }
   }
   private efl_access_object_role_set_delegate efl_access_object_role_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Access.Object efl_access_object_access_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Access.Object efl_access_object_access_parent_get(System.IntPtr obj);
    private static Efl.Access.Object access_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.Object _ret_var = default(Efl.Access.Object);
         try {
            _ret_var = ((Widget)wrapper).GetAccessParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_access_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_access_parent_get_delegate efl_access_object_access_parent_get_static_delegate;


    private delegate  void efl_access_object_access_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_access_parent_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object parent);
    private static  void access_parent_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Object parent)
   {
      Eina.Log.Debug("function efl_access_object_access_parent_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetAccessParent( parent);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_access_parent_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  parent);
      }
   }
   private efl_access_object_access_parent_set_delegate efl_access_object_access_parent_set_static_delegate;


    private delegate  void efl_access_object_description_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_description_cb_set(System.IntPtr obj,   Efl.Access.ReadingInfoCb description_cb,    System.IntPtr data);
    private static  void description_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb description_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_description_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetDescriptionCb( description_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_description_cb_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description_cb,  data);
      }
   }
   private efl_access_object_description_cb_set_delegate efl_access_object_description_cb_set_static_delegate;


    private delegate  void efl_access_object_gesture_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_gesture_cb_set(System.IntPtr obj,   Efl.Access.GestureCb gesture_cb,    System.IntPtr data);
    private static  void gesture_cb_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureCb gesture_cb,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_access_object_gesture_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetGestureCb( gesture_cb,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_gesture_cb_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_cb,  data);
      }
   }
   private efl_access_object_gesture_cb_set_delegate efl_access_object_gesture_cb_set_static_delegate;


    private delegate  System.IntPtr efl_access_object_access_children_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_access_children_get(System.IntPtr obj);
    private static  System.IntPtr access_children_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_access_children_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Object> _ret_var = default(Eina.List<Efl.Access.Object>);
         try {
            _ret_var = ((Widget)wrapper).GetAccessChildren();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_access_object_access_children_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_access_children_get_delegate efl_access_object_access_children_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_role_name_get(System.IntPtr obj);
    private static  System.IntPtr role_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_role_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetRoleName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_object_role_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_role_name_get_delegate efl_access_object_role_name_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_attributes_get(System.IntPtr obj);
    private static  System.IntPtr attributes_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.Attribute> _ret_var = default(Eina.List<Efl.Access.Attribute>);
         try {
            _ret_var = ((Widget)wrapper).GetAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_object_attributes_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_attributes_get_delegate efl_access_object_attributes_get_static_delegate;


    private delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get(System.IntPtr obj);
    private static Efl.Access.ReadingInfoTypeMask reading_info_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.ReadingInfoTypeMask _ret_var = default(Efl.Access.ReadingInfoTypeMask);
         try {
            _ret_var = ((Widget)wrapper).GetReadingInfoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_reading_info_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_reading_info_type_get_delegate efl_access_object_reading_info_type_get_static_delegate;


    private delegate  void efl_access_object_reading_info_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.ReadingInfoTypeMask reading_info);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_reading_info_type_set(System.IntPtr obj,   Efl.Access.ReadingInfoTypeMask reading_info);
    private static  void reading_info_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoTypeMask reading_info)
   {
      Eina.Log.Debug("function efl_access_object_reading_info_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetReadingInfoType( reading_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_reading_info_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  reading_info);
      }
   }
   private efl_access_object_reading_info_type_set_delegate efl_access_object_reading_info_type_set_static_delegate;


    private delegate  int efl_access_object_index_in_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_access_object_index_in_parent_get(System.IntPtr obj);
    private static  int index_in_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_index_in_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Widget)wrapper).GetIndexInParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_index_in_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_index_in_parent_get_delegate efl_access_object_index_in_parent_get_static_delegate;


    private delegate  System.IntPtr efl_access_object_description_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_description_get(System.IntPtr obj);
    private static  System.IntPtr description_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_description_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetDescription();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_object_description_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_description_get_delegate efl_access_object_description_get_static_delegate;


    private delegate  void efl_access_object_description_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_description_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String description);
    private static  void description_set(System.IntPtr obj, System.IntPtr pd,   System.String description)
   {
      Eina.Log.Debug("function efl_access_object_description_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetDescription( description);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_description_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  description);
      }
   }
   private efl_access_object_description_set_delegate efl_access_object_description_set_static_delegate;


    private delegate Efl.Access.StateSet efl_access_object_state_set_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Access.StateSet efl_access_object_state_set_get(System.IntPtr obj);
    private static Efl.Access.StateSet state_set_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_state_set_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.StateSet _ret_var = default(Efl.Access.StateSet);
         try {
            _ret_var = ((Widget)wrapper).GetStateSet();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_state_set_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_state_set_get_delegate efl_access_object_state_set_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_can_highlight_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_object_can_highlight_get(System.IntPtr obj);
    private static bool can_highlight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetCanHighlight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_object_can_highlight_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_can_highlight_get_delegate efl_access_object_can_highlight_get_static_delegate;


    private delegate  void efl_access_object_can_highlight_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_can_highlight_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool can_highlight);
    private static  void can_highlight_set(System.IntPtr obj, System.IntPtr pd,  bool can_highlight)
   {
      Eina.Log.Debug("function efl_access_object_can_highlight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetCanHighlight( can_highlight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_can_highlight_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  can_highlight);
      }
   }
   private efl_access_object_can_highlight_set_delegate efl_access_object_can_highlight_set_static_delegate;


    private delegate  System.IntPtr efl_access_object_translation_domain_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_access_object_translation_domain_get(System.IntPtr obj);
    private static  System.IntPtr translation_domain_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetTranslationDomain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_access_object_translation_domain_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_translation_domain_get_delegate efl_access_object_translation_domain_get_static_delegate;


    private delegate  void efl_access_object_translation_domain_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_translation_domain_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
    private static  void translation_domain_set(System.IntPtr obj, System.IntPtr pd,   System.String domain)
   {
      Eina.Log.Debug("function efl_access_object_translation_domain_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).SetTranslationDomain( domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_access_object_translation_domain_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  domain);
      }
   }
   private efl_access_object_translation_domain_set_delegate efl_access_object_translation_domain_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_gesture_do_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.GestureInfo_StructInternal gesture_info);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_object_gesture_do(System.IntPtr obj,   Efl.Access.GestureInfo_StructInternal gesture_info);
    private static bool gesture_do(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureInfo_StructInternal gesture_info)
   {
      Eina.Log.Debug("function efl_access_object_gesture_do was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_gesture_info = Efl.Access.GestureInfo_StructConversion.ToManaged(gesture_info);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GestureDo( _in_gesture_info);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_object_gesture_do(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture_info);
      }
   }
   private efl_access_object_gesture_do_delegate efl_access_object_gesture_do_static_delegate;


    private delegate  void efl_access_object_attribute_append_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_attribute_append(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value);
    private static  void attribute_append(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.String value)
   {
      Eina.Log.Debug("function efl_access_object_attribute_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).AppendAttribute( key,  value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_attribute_append(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  value);
      }
   }
   private efl_access_object_attribute_append_delegate efl_access_object_attribute_append_static_delegate;


    private delegate  void efl_access_object_attributes_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_attributes_clear(System.IntPtr obj);
    private static  void attributes_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_attributes_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).ClearAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_attributes_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_attributes_clear_delegate efl_access_object_attributes_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_object_relationship_append_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_object_relationship_append(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    private static bool relationship_append(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_append was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).AppendRelationship( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_object_relationship_append(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private efl_access_object_relationship_append_delegate efl_access_object_relationship_append_static_delegate;


    private delegate  void efl_access_object_relationship_remove_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_relationship_remove(System.IntPtr obj,   Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Access.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Access.Object relation_object);
    private static  void relationship_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type,  Efl.Access.Object relation_object)
   {
      Eina.Log.Debug("function efl_access_object_relationship_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).RelationshipRemove( type,  relation_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_relationship_remove(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  relation_object);
      }
   }
   private efl_access_object_relationship_remove_delegate efl_access_object_relationship_remove_static_delegate;


    private delegate  void efl_access_object_relationships_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_relationships_clear(System.IntPtr obj);
    private static  void relationships_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_object_relationships_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).ClearRelationships();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_access_object_relationships_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_object_relationships_clear_delegate efl_access_object_relationships_clear_static_delegate;


    private delegate  void efl_access_object_state_notify_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_access_object_state_notify(System.IntPtr obj,   Efl.Access.StateSet state_types_mask,  [MarshalAs(UnmanagedType.U1)]  bool recursive);
    private static  void state_notify(System.IntPtr obj, System.IntPtr pd,  Efl.Access.StateSet state_types_mask,  bool recursive)
   {
      Eina.Log.Debug("function efl_access_object_state_notify was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).StateNotify( state_types_mask,  recursive);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_access_object_state_notify(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  state_types_mask,  recursive);
      }
   }
   private efl_access_object_state_notify_delegate efl_access_object_state_notify_static_delegate;


    private delegate Efl.Access.ActionData efl_access_widget_action_elm_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Access.ActionData efl_access_widget_action_elm_actions_get(System.IntPtr obj);
    private static Efl.Access.ActionData elm_actions_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_widget_action_elm_actions_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Access.ActionData _ret_var = default(Efl.Access.ActionData);
         try {
            _ret_var = ((Widget)wrapper).GetElmActions();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_widget_action_elm_actions_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_widget_action_elm_actions_get_delegate efl_access_widget_action_elm_actions_get_static_delegate;


    private delegate  System.IntPtr efl_ui_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_cursor_get(System.IntPtr obj);
    private static  System.IntPtr cursor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_cursor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_get_delegate efl_ui_cursor_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
    private static bool cursor_set(System.IntPtr obj, System.IntPtr pd,   System.String cursor)
   {
      Eina.Log.Debug("function efl_ui_cursor_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetCursor( cursor);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cursor);
      }
   }
   private efl_ui_cursor_set_delegate efl_ui_cursor_set_static_delegate;


    private delegate  System.IntPtr efl_ui_cursor_style_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_cursor_style_get(System.IntPtr obj);
    private static  System.IntPtr cursor_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetCursorStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_cursor_style_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_style_get_delegate efl_ui_cursor_style_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    private static bool cursor_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function efl_ui_cursor_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetCursorStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_style_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_ui_cursor_style_set_delegate efl_ui_cursor_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_theme_search_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_theme_search_enabled_get(System.IntPtr obj);
    private static bool cursor_theme_search_enabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_theme_search_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).GetCursorThemeSearchEnabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_cursor_theme_search_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_theme_search_enabled_get_delegate efl_ui_cursor_theme_search_enabled_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_theme_search_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_theme_search_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
    private static bool cursor_theme_search_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool allow)
   {
      Eina.Log.Debug("function efl_ui_cursor_theme_search_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).SetCursorThemeSearchEnabled( allow);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_theme_search_enabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allow);
      }
   }
   private efl_ui_cursor_theme_search_enabled_set_delegate efl_ui_cursor_theme_search_enabled_set_static_delegate;


    private delegate  void efl_ui_dnd_drag_start_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_drag_start(System.IntPtr obj,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,    uint seat);
    private static  void drag_start(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
               
         try {
            ((Widget)wrapper).DragStart( format,  data,  action,  icon_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_dnd_drag_start(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  data,  action, icon_func_data, icon_func, icon_func_free_cb,  seat);
      }
   }
   private efl_ui_dnd_drag_start_delegate efl_ui_dnd_drag_start_static_delegate;


    private delegate  void efl_ui_dnd_drag_action_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionAction action,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_drag_action_set(System.IntPtr obj,   Efl.Ui.SelectionAction action,    uint seat);
    private static  void drag_action_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionAction action,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_action_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetDragAction( action,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drag_action_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  action,  seat);
      }
   }
   private efl_ui_dnd_drag_action_set_delegate efl_ui_dnd_drag_action_set_static_delegate;


    private delegate  void efl_ui_dnd_drag_cancel_delegate(System.IntPtr obj, System.IntPtr pd,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_drag_cancel(System.IntPtr obj,    uint seat);
    private static  void drag_cancel(System.IntPtr obj, System.IntPtr pd,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_cancel was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Widget)wrapper).DragCancel( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_dnd_drag_cancel(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_ui_dnd_drag_cancel_delegate efl_ui_dnd_drag_cancel_static_delegate;


    private delegate  void efl_ui_dnd_drop_target_add_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_drop_target_add(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
    private static  void drop_target_add(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drop_target_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).AddDropTarget( format,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drop_target_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  seat);
      }
   }
   private efl_ui_dnd_drop_target_add_delegate efl_ui_dnd_drop_target_add_static_delegate;


    private delegate  void efl_ui_dnd_drop_target_del_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_dnd_drop_target_del(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
    private static  void drop_target_del(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drop_target_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).DelDropTarget( format,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drop_target_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  seat);
      }
   }
   private efl_ui_dnd_drop_target_del_delegate efl_ui_dnd_drop_target_del_static_delegate;


    private delegate  System.IntPtr efl_ui_l10n_text_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr domain);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_l10n_text_get(System.IntPtr obj,   out  System.IntPtr domain);
    private static  System.IntPtr l10n_text_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr domain)
   {
      Eina.Log.Debug("function efl_ui_l10n_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                      System.String _out_domain = default( System.String);
                System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Widget)wrapper).GetL10nText( out _out_domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      domain= Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _out_domain);
            return Efl.Eo.Globals.cached_string_to_intptr(((Widget)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_l10n_text_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out domain);
      }
   }
   private efl_ui_l10n_text_get_delegate efl_ui_l10n_text_get_static_delegate;


    private delegate  void efl_ui_l10n_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_l10n_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
    private static  void l10n_text_set(System.IntPtr obj, System.IntPtr pd,   System.String label,   System.String domain)
   {
      Eina.Log.Debug("function efl_ui_l10n_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).SetL10nText( label,  domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_l10n_text_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  label,  domain);
      }
   }
   private efl_ui_l10n_text_set_delegate efl_ui_l10n_text_set_static_delegate;


    private delegate  void efl_ui_l10n_translation_update_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_l10n_translation_update(System.IntPtr obj);
    private static  void translation_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_l10n_translation_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Widget)wrapper).UpdateTranslation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_l10n_translation_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_l10n_translation_update_delegate efl_ui_l10n_translation_update_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_selection_set(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
    private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                           Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((Widget)wrapper).SetSelection( type,  format,  data,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_ui_selection_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format,  data,  seat);
      }
   }
   private efl_ui_selection_set_delegate efl_ui_selection_set_static_delegate;


    private delegate  void efl_ui_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_selection_get(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
    private static  void selection_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                              Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
               
         try {
            ((Widget)wrapper).GetSelection( type,  format,  data_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_ui_selection_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format, data_func_data, data_func, data_func_free_cb,  seat);
      }
   }
   private efl_ui_selection_get_delegate efl_ui_selection_get_static_delegate;


    private delegate  void efl_ui_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_selection_clear(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
    private static  void selection_clear(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Widget)wrapper).ClearSelection( type,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_selection_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
      }
   }
   private efl_ui_selection_clear_delegate efl_ui_selection_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_selection_has_owner(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
    private static bool has_owner(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_has_owner was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Widget)wrapper).HasOwner( type,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_selection_has_owner(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
      }
   }
   private efl_ui_selection_has_owner_delegate efl_ui_selection_has_owner_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal focus_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Widget)wrapper).GetFocusGeometry();
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
            _ret_var = ((Widget)wrapper).GetFocus();
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
            ((Widget)wrapper).SetFocus( focus);
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
            _ret_var = ((Widget)wrapper).GetFocusManager();
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
            _ret_var = ((Widget)wrapper).GetFocusParent();
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
            _ret_var = ((Widget)wrapper).GetChildFocus();
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
            ((Widget)wrapper).SetChildFocus( child_focus);
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
            ((Widget)wrapper).PrepareLogical();
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
            ((Widget)wrapper).PrepareLogicalNoneRecursive();
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
            _ret_var = ((Widget)wrapper).UpdateOnFocus();
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
namespace Efl { namespace Ui { 
/// <summary>All relevant fields needed for the current state of focus registeration</summary>
[StructLayout(LayoutKind.Sequential)]
public struct WidgetFocusState
{
   /// <summary>The manager where the widget is registered in</summary>
   public Efl.Ui.Focus.Manager Manager;
   /// <summary>The parent the widget is using as logical parent</summary>
   public Efl.Ui.Focus.Object Parent;
   /// <summary><c>true</c> if this is registered as logical currently</summary>
   public bool Logical;
   ///<summary>Constructor for WidgetFocusState.</summary>
   public WidgetFocusState(
      Efl.Ui.Focus.Manager Manager=default(Efl.Ui.Focus.Manager),
      Efl.Ui.Focus.Object Parent=default(Efl.Ui.Focus.Object),
      bool Logical=default(bool)   )
   {
      this.Manager = Manager;
      this.Parent = Parent;
      this.Logical = Logical;
   }
public static implicit operator WidgetFocusState(IntPtr ptr)
   {
      var tmp = (WidgetFocusState_StructInternal)Marshal.PtrToStructure(ptr, typeof(WidgetFocusState_StructInternal));
      return WidgetFocusState_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct WidgetFocusState.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct WidgetFocusState_StructInternal
{
///<summary>Internal wrapper for field Manager</summary>
public System.IntPtr Manager;
///<summary>Internal wrapper for field Parent</summary>
public System.IntPtr Parent;
    [MarshalAs(UnmanagedType.U1)]
   public bool Logical;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator WidgetFocusState(WidgetFocusState_StructInternal struct_)
   {
      return WidgetFocusState_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator WidgetFocusState_StructInternal(WidgetFocusState struct_)
   {
      return WidgetFocusState_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct WidgetFocusState</summary>
public static class WidgetFocusState_StructConversion
{
   internal static WidgetFocusState_StructInternal ToInternal(WidgetFocusState _external_struct)
   {
      var _internal_struct = new WidgetFocusState_StructInternal();

      _internal_struct.Manager = _external_struct.Manager.NativeHandle;
      _internal_struct.Parent = _external_struct.Parent.NativeHandle;
      _internal_struct.Logical = _external_struct.Logical;

      return _internal_struct;
   }

   internal static WidgetFocusState ToManaged(WidgetFocusState_StructInternal _internal_struct)
   {
      var _external_struct = new WidgetFocusState();


      _external_struct.Manager = (Efl.Ui.Focus.ManagerConcrete) System.Activator.CreateInstance(typeof(Efl.Ui.Focus.ManagerConcrete), new System.Object[] {_internal_struct.Manager});
      Efl.Eo.Globals.efl_ref(_internal_struct.Manager);


      _external_struct.Parent = (Efl.Ui.Focus.ObjectConcrete) System.Activator.CreateInstance(typeof(Efl.Ui.Focus.ObjectConcrete), new System.Object[] {_internal_struct.Parent});
      Efl.Eo.Globals.efl_ref(_internal_struct.Parent);

      _external_struct.Logical = _internal_struct.Logical;

      return _external_struct;
   }

}
} } 
