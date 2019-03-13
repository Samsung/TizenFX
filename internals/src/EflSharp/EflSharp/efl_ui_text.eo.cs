#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ChangedUserEvt"/>.</summary>
public class TextChangedUserEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.TextChangeInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ValidateEvt"/>.</summary>
public class TextValidateEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.ValidateContent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorDownEvt"/>.</summary>
public class TextAnchorDownEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorHoverOpenedEvt"/>.</summary>
public class TextAnchorHoverOpenedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.EntryAnchorHoverInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorInEvt"/>.</summary>
public class TextAnchorInEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorOutEvt"/>.</summary>
public class TextAnchorOutEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorUpEvt"/>.</summary>
public class TextAnchorUpEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>Efl UI text class</summary>
[TextNativeInherit]
public class Text : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.File,Efl.Text,Efl.TextFont,Efl.TextFormat,Efl.TextInteractive,Efl.TextStyle,Efl.Access.Text,Efl.Access.Editable.Text,Efl.Ui.Clickable,Efl.Ui.Selectable
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.TextNativeInherit nativeInherit = new Efl.Ui.TextNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Text))
            return Efl.Ui.TextNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_text_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Text(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_text_class_get(), typeof(Text), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Text(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Text(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Text static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Text(obj.NativeHandle);
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
private static object ChangedEvtKey = new object();
   /// <summary>Called when entry changes</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangedEvt.</summary>
   public void On_ChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangedEvt_delegate;
   private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChangedUserEvtKey = new object();
   /// <summary>The text object has changed due to user interaction</summary>
   public event EventHandler<Efl.Ui.TextChangedUserEvt_Args> ChangedUserEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CHANGED_USER";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ChangedUserEvt_delegate)) {
               eventHandlers.AddHandler(ChangedUserEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CHANGED_USER";
            if (remove_cpp_event_handler(key, this.evt_ChangedUserEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangedUserEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangedUserEvt.</summary>
   public void On_ChangedUserEvt(Efl.Ui.TextChangedUserEvt_Args e)
   {
      EventHandler<Efl.Ui.TextChangedUserEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextChangedUserEvt_Args>)eventHandlers[ChangedUserEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangedUserEvt_delegate;
   private void on_ChangedUserEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextChangedUserEvt_Args args = new Efl.Ui.TextChangedUserEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ChangedUserEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ValidateEvtKey = new object();
   /// <summary>Called when validating</summary>
   public event EventHandler<Efl.Ui.TextValidateEvt_Args> ValidateEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_VALIDATE";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ValidateEvt_delegate)) {
               eventHandlers.AddHandler(ValidateEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_VALIDATE";
            if (remove_cpp_event_handler(key, this.evt_ValidateEvt_delegate)) { 
               eventHandlers.RemoveHandler(ValidateEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ValidateEvt.</summary>
   public void On_ValidateEvt(Efl.Ui.TextValidateEvt_Args e)
   {
      EventHandler<Efl.Ui.TextValidateEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextValidateEvt_Args>)eventHandlers[ValidateEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ValidateEvt_delegate;
   private void on_ValidateEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextValidateEvt_Args args = new Efl.Ui.TextValidateEvt_Args();
      args.arg = default(Elm.ValidateContent);
      try {
         On_ValidateEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContextOpenEvtKey = new object();
   /// <summary>Called when context menu was opened</summary>
   public event EventHandler ContextOpenEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CONTEXT_OPEN";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ContextOpenEvt_delegate)) {
               eventHandlers.AddHandler(ContextOpenEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CONTEXT_OPEN";
            if (remove_cpp_event_handler(key, this.evt_ContextOpenEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContextOpenEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContextOpenEvt.</summary>
   public void On_ContextOpenEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ContextOpenEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContextOpenEvt_delegate;
   private void on_ContextOpenEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ContextOpenEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PreeditChangedEvtKey = new object();
   /// <summary>Called when entry preedit changed</summary>
   public event EventHandler PreeditChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_PREEDIT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_PreeditChangedEvt_delegate)) {
               eventHandlers.AddHandler(PreeditChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_PREEDIT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PreeditChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PreeditChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PreeditChangedEvt.</summary>
   public void On_PreeditChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PreeditChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PreeditChangedEvt_delegate;
   private void on_PreeditChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PreeditChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PressEvtKey = new object();
   /// <summary>Called when entry pressed</summary>
   public event EventHandler PressEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_PRESS";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_PressEvt_delegate)) {
               eventHandlers.AddHandler(PressEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_PRESS";
            if (remove_cpp_event_handler(key, this.evt_PressEvt_delegate)) { 
               eventHandlers.RemoveHandler(PressEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PressEvt.</summary>
   public void On_PressEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PressEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PressEvt_delegate;
   private void on_PressEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PressEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RedoRequestEvtKey = new object();
   /// <summary>Called when redo is requested</summary>
   public event EventHandler RedoRequestEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_REDO_REQUEST";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_RedoRequestEvt_delegate)) {
               eventHandlers.AddHandler(RedoRequestEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_REDO_REQUEST";
            if (remove_cpp_event_handler(key, this.evt_RedoRequestEvt_delegate)) { 
               eventHandlers.RemoveHandler(RedoRequestEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RedoRequestEvt.</summary>
   public void On_RedoRequestEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RedoRequestEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RedoRequestEvt_delegate;
   private void on_RedoRequestEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RedoRequestEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UndoRequestEvtKey = new object();
   /// <summary>Called when undo is requested</summary>
   public event EventHandler UndoRequestEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_UNDO_REQUEST";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_UndoRequestEvt_delegate)) {
               eventHandlers.AddHandler(UndoRequestEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_UNDO_REQUEST";
            if (remove_cpp_event_handler(key, this.evt_UndoRequestEvt_delegate)) { 
               eventHandlers.RemoveHandler(UndoRequestEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UndoRequestEvt.</summary>
   public void On_UndoRequestEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[UndoRequestEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UndoRequestEvt_delegate;
   private void on_UndoRequestEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_UndoRequestEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AbortedEvtKey = new object();
   /// <summary>Called when entry is aborted</summary>
   public event EventHandler AbortedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ABORTED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AbortedEvt_delegate)) {
               eventHandlers.AddHandler(AbortedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ABORTED";
            if (remove_cpp_event_handler(key, this.evt_AbortedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AbortedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AbortedEvt.</summary>
   public void On_AbortedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AbortedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AbortedEvt_delegate;
   private void on_AbortedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AbortedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnchorDownEvtKey = new object();
   /// <summary>Called on anchor down</summary>
   public event EventHandler<Efl.Ui.TextAnchorDownEvt_Args> AnchorDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_DOWN";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AnchorDownEvt_delegate)) {
               eventHandlers.AddHandler(AnchorDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_DOWN";
            if (remove_cpp_event_handler(key, this.evt_AnchorDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnchorDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnchorDownEvt.</summary>
   public void On_AnchorDownEvt(Efl.Ui.TextAnchorDownEvt_Args e)
   {
      EventHandler<Efl.Ui.TextAnchorDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextAnchorDownEvt_Args>)eventHandlers[AnchorDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnchorDownEvt_delegate;
   private void on_AnchorDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextAnchorDownEvt_Args args = new Efl.Ui.TextAnchorDownEvt_Args();
      args.arg = default(Elm.EntryAnchorInfo);
      try {
         On_AnchorDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnchorHoverOpenedEvtKey = new object();
   /// <summary>Called when hover opened</summary>
   public event EventHandler<Efl.Ui.TextAnchorHoverOpenedEvt_Args> AnchorHoverOpenedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_HOVER_OPENED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AnchorHoverOpenedEvt_delegate)) {
               eventHandlers.AddHandler(AnchorHoverOpenedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_HOVER_OPENED";
            if (remove_cpp_event_handler(key, this.evt_AnchorHoverOpenedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnchorHoverOpenedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnchorHoverOpenedEvt.</summary>
   public void On_AnchorHoverOpenedEvt(Efl.Ui.TextAnchorHoverOpenedEvt_Args e)
   {
      EventHandler<Efl.Ui.TextAnchorHoverOpenedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextAnchorHoverOpenedEvt_Args>)eventHandlers[AnchorHoverOpenedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnchorHoverOpenedEvt_delegate;
   private void on_AnchorHoverOpenedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextAnchorHoverOpenedEvt_Args args = new Efl.Ui.TextAnchorHoverOpenedEvt_Args();
      args.arg = default(Elm.EntryAnchorHoverInfo);
      try {
         On_AnchorHoverOpenedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnchorInEvtKey = new object();
   /// <summary>Called on anchor in</summary>
   public event EventHandler<Efl.Ui.TextAnchorInEvt_Args> AnchorInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_IN";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AnchorInEvt_delegate)) {
               eventHandlers.AddHandler(AnchorInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_IN";
            if (remove_cpp_event_handler(key, this.evt_AnchorInEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnchorInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnchorInEvt.</summary>
   public void On_AnchorInEvt(Efl.Ui.TextAnchorInEvt_Args e)
   {
      EventHandler<Efl.Ui.TextAnchorInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextAnchorInEvt_Args>)eventHandlers[AnchorInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnchorInEvt_delegate;
   private void on_AnchorInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextAnchorInEvt_Args args = new Efl.Ui.TextAnchorInEvt_Args();
      args.arg = default(Elm.EntryAnchorInfo);
      try {
         On_AnchorInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnchorOutEvtKey = new object();
   /// <summary>Called on anchor out</summary>
   public event EventHandler<Efl.Ui.TextAnchorOutEvt_Args> AnchorOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_OUT";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AnchorOutEvt_delegate)) {
               eventHandlers.AddHandler(AnchorOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_OUT";
            if (remove_cpp_event_handler(key, this.evt_AnchorOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnchorOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnchorOutEvt.</summary>
   public void On_AnchorOutEvt(Efl.Ui.TextAnchorOutEvt_Args e)
   {
      EventHandler<Efl.Ui.TextAnchorOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextAnchorOutEvt_Args>)eventHandlers[AnchorOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnchorOutEvt_delegate;
   private void on_AnchorOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextAnchorOutEvt_Args args = new Efl.Ui.TextAnchorOutEvt_Args();
      args.arg = default(Elm.EntryAnchorInfo);
      try {
         On_AnchorOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnchorUpEvtKey = new object();
   /// <summary>called on anchor up</summary>
   public event EventHandler<Efl.Ui.TextAnchorUpEvt_Args> AnchorUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_UP";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AnchorUpEvt_delegate)) {
               eventHandlers.AddHandler(AnchorUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_ANCHOR_UP";
            if (remove_cpp_event_handler(key, this.evt_AnchorUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnchorUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnchorUpEvt.</summary>
   public void On_AnchorUpEvt(Efl.Ui.TextAnchorUpEvt_Args e)
   {
      EventHandler<Efl.Ui.TextAnchorUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TextAnchorUpEvt_Args>)eventHandlers[AnchorUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnchorUpEvt_delegate;
   private void on_AnchorUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TextAnchorUpEvt_Args args = new Efl.Ui.TextAnchorUpEvt_Args();
      args.arg = default(Elm.EntryAnchorInfo);
      try {
         On_AnchorUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object CursorChangedManualEvtKey = new object();
   /// <summary>Called on manual cursor change</summary>
   public event EventHandler CursorChangedManualEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CURSOR_CHANGED_MANUAL";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_CursorChangedManualEvt_delegate)) {
               eventHandlers.AddHandler(CursorChangedManualEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TEXT_EVENT_CURSOR_CHANGED_MANUAL";
            if (remove_cpp_event_handler(key, this.evt_CursorChangedManualEvt_delegate)) { 
               eventHandlers.RemoveHandler(CursorChangedManualEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event CursorChangedManualEvt.</summary>
   public void On_CursorChangedManualEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[CursorChangedManualEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_CursorChangedManualEvt_delegate;
   private void on_CursorChangedManualEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_CursorChangedManualEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Efl_TextInteractive_SelectionChangedEvtKey = new object();
   /// <summary>The selection on the object has changed. Query using <see cref="Efl.TextInteractive.GetSelectionCursors"/></summary>
    event EventHandler Efl.TextInteractive.SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_TEXT_INTERACTIVE_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Efl_TextInteractive_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_TextInteractive_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_TEXT_INTERACTIVE_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_TextInteractive_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_TextInteractive_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_TextInteractive_SelectionChangedEvt.</summary>
   public void On_Efl_TextInteractive_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Efl_TextInteractive_SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_TextInteractive_SelectionChangedEvt_delegate;
   private void on_Efl_TextInteractive_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Efl_TextInteractive_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextCaretMovedEvtKey = new object();
   /// <summary>Caret moved</summary>
   public event EventHandler AccessTextCaretMovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextCaretMovedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextCaretMovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextCaretMovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextCaretMovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextCaretMovedEvt.</summary>
   public void On_AccessTextCaretMovedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AccessTextCaretMovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextCaretMovedEvt_delegate;
   private void on_AccessTextCaretMovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AccessTextCaretMovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextInsertedEvtKey = new object();
   /// <summary>Text was inserted</summary>
   public event EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args> AccessTextInsertedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextInsertedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextInsertedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextInsertedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextInsertedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextInsertedEvt.</summary>
   public void On_AccessTextInsertedEvt(Efl.Access.TextAccessTextInsertedEvt_Args e)
   {
      EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.TextAccessTextInsertedEvt_Args>)eventHandlers[AccessTextInsertedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextInsertedEvt_delegate;
   private void on_AccessTextInsertedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.TextAccessTextInsertedEvt_Args args = new Efl.Access.TextAccessTextInsertedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AccessTextInsertedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextRemovedEvtKey = new object();
   /// <summary>Text was removed</summary>
   public event EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args> AccessTextRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextRemovedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextRemovedEvt.</summary>
   public void On_AccessTextRemovedEvt(Efl.Access.TextAccessTextRemovedEvt_Args e)
   {
      EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Access.TextAccessTextRemovedEvt_Args>)eventHandlers[AccessTextRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextRemovedEvt_delegate;
   private void on_AccessTextRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Access.TextAccessTextRemovedEvt_Args args = new Efl.Access.TextAccessTextRemovedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AccessTextRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AccessTextSelectionChangedEvtKey = new object();
   /// <summary>Text selection has changed</summary>
   public event EventHandler AccessTextSelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_AccessTextSelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(AccessTextSelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_AccessTextSelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(AccessTextSelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AccessTextSelectionChangedEvt.</summary>
   public void On_AccessTextSelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AccessTextSelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AccessTextSelectionChangedEvt_delegate;
   private void on_AccessTextSelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AccessTextSelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedEvtKey = new object();
   /// <summary>Called when object is clicked</summary>
   public event EventHandler ClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedEvt_delegate)) {
               eventHandlers.AddHandler(ClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED";
            if (remove_cpp_event_handler(key, this.evt_ClickedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedEvt.</summary>
   public void On_ClickedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedEvt_delegate;
   private void on_ClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedDoubleEvtKey = new object();
   /// <summary>Called when object receives a double click</summary>
   public event EventHandler ClickedDoubleEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedDoubleEvt_delegate)) {
               eventHandlers.AddHandler(ClickedDoubleEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
            if (remove_cpp_event_handler(key, this.evt_ClickedDoubleEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedDoubleEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedDoubleEvt.</summary>
   public void On_ClickedDoubleEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedDoubleEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedDoubleEvt_delegate;
   private void on_ClickedDoubleEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedDoubleEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedTripleEvtKey = new object();
   /// <summary>Called when object receives a triple click</summary>
   public event EventHandler ClickedTripleEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedTripleEvt_delegate)) {
               eventHandlers.AddHandler(ClickedTripleEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
            if (remove_cpp_event_handler(key, this.evt_ClickedTripleEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedTripleEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedTripleEvt.</summary>
   public void On_ClickedTripleEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedTripleEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedTripleEvt_delegate;
   private void on_ClickedTripleEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedTripleEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedRightEvtKey = new object();
   /// <summary>Called when object receives a right click</summary>
   public event EventHandler<Efl.Ui.ClickableClickedRightEvt_Args> ClickedRightEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedRightEvt_delegate)) {
               eventHandlers.AddHandler(ClickedRightEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
            if (remove_cpp_event_handler(key, this.evt_ClickedRightEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedRightEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedRightEvt.</summary>
   public void On_ClickedRightEvt(Efl.Ui.ClickableClickedRightEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableClickedRightEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableClickedRightEvt_Args>)eventHandlers[ClickedRightEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedRightEvt_delegate;
   private void on_ClickedRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableClickedRightEvt_Args args = new Efl.Ui.ClickableClickedRightEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_ClickedRightEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PressedEvtKey = new object();
   /// <summary>Called when the object is pressed</summary>
   public event EventHandler<Efl.Ui.ClickablePressedEvt_Args> PressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_PRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_PressedEvt_delegate)) {
               eventHandlers.AddHandler(PressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_PRESSED";
            if (remove_cpp_event_handler(key, this.evt_PressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PressedEvt.</summary>
   public void On_PressedEvt(Efl.Ui.ClickablePressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickablePressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickablePressedEvt_Args>)eventHandlers[PressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PressedEvt_delegate;
   private void on_PressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickablePressedEvt_Args args = new Efl.Ui.ClickablePressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_PressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnpressedEvtKey = new object();
   /// <summary>Called when the object is no longer pressed</summary>
   public event EventHandler<Efl.Ui.ClickableUnpressedEvt_Args> UnpressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNPRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_UnpressedEvt_delegate)) {
               eventHandlers.AddHandler(UnpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNPRESSED";
            if (remove_cpp_event_handler(key, this.evt_UnpressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnpressedEvt.</summary>
   public void On_UnpressedEvt(Efl.Ui.ClickableUnpressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableUnpressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableUnpressedEvt_Args>)eventHandlers[UnpressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnpressedEvt_delegate;
   private void on_UnpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableUnpressedEvt_Args args = new Efl.Ui.ClickableUnpressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_UnpressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LongpressedEvtKey = new object();
   /// <summary>Called when the object receives a long press</summary>
   public event EventHandler<Efl.Ui.ClickableLongpressedEvt_Args> LongpressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_LONGPRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_LongpressedEvt_delegate)) {
               eventHandlers.AddHandler(LongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_LONGPRESSED";
            if (remove_cpp_event_handler(key, this.evt_LongpressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LongpressedEvt.</summary>
   public void On_LongpressedEvt(Efl.Ui.ClickableLongpressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableLongpressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableLongpressedEvt_Args>)eventHandlers[LongpressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LongpressedEvt_delegate;
   private void on_LongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableLongpressedEvt_Args args = new Efl.Ui.ClickableLongpressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_LongpressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RepeatedEvtKey = new object();
   /// <summary>Called when the object receives repeated presses/clicks</summary>
   public event EventHandler RepeatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_REPEATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_RepeatedEvt_delegate)) {
               eventHandlers.AddHandler(RepeatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_REPEATED";
            if (remove_cpp_event_handler(key, this.evt_RepeatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RepeatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RepeatedEvt.</summary>
   public void On_RepeatedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RepeatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RepeatedEvt_delegate;
   private void on_RepeatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RepeatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectedEvtKey = new object();
   /// <summary>Called when selected</summary>
   public event EventHandler SelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectedEvt_delegate)) {
               eventHandlers.AddHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTED";
            if (remove_cpp_event_handler(key, this.evt_SelectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectedEvt.</summary>
   public void On_SelectedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectedEvt_delegate;
   private void on_SelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnselectedEvtKey = new object();
   /// <summary>Called when no longer selected</summary>
   public event EventHandler UnselectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNSELECTED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_UnselectedEvt_delegate)) {
               eventHandlers.AddHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNSELECTED";
            if (remove_cpp_event_handler(key, this.evt_UnselectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnselectedEvt.</summary>
   public void On_UnselectedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[UnselectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnselectedEvt_delegate;
   private void on_UnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_UnselectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionPasteEvtKey = new object();
   /// <summary>Called when selection is pasted</summary>
   public event EventHandler SelectionPasteEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_PASTE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionPasteEvt_delegate)) {
               eventHandlers.AddHandler(SelectionPasteEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_PASTE";
            if (remove_cpp_event_handler(key, this.evt_SelectionPasteEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionPasteEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionPasteEvt.</summary>
   public void On_SelectionPasteEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionPasteEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionPasteEvt_delegate;
   private void on_SelectionPasteEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionPasteEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionCopyEvtKey = new object();
   /// <summary>Called when selection is copied</summary>
   public event EventHandler SelectionCopyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_COPY";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionCopyEvt_delegate)) {
               eventHandlers.AddHandler(SelectionCopyEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_COPY";
            if (remove_cpp_event_handler(key, this.evt_SelectionCopyEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionCopyEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionCopyEvt.</summary>
   public void On_SelectionCopyEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionCopyEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionCopyEvt_delegate;
   private void on_SelectionCopyEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionCopyEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionCutEvtKey = new object();
   /// <summary>Called when selection is cut</summary>
   public event EventHandler SelectionCutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CUT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionCutEvt_delegate)) {
               eventHandlers.AddHandler(SelectionCutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CUT";
            if (remove_cpp_event_handler(key, this.evt_SelectionCutEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionCutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionCutEvt.</summary>
   public void On_SelectionCutEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionCutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionCutEvt_delegate;
   private void on_SelectionCutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionCutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionStartEvtKey = new object();
   /// <summary>Called at selection start</summary>
   public event EventHandler SelectionStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_START";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionStartEvt_delegate)) {
               eventHandlers.AddHandler(SelectionStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_START";
            if (remove_cpp_event_handler(key, this.evt_SelectionStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionStartEvt.</summary>
   public void On_SelectionStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionStartEvt_delegate;
   private void on_SelectionStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Efl_Ui_Selectable_SelectionChangedEvtKey = new object();
   /// <summary>Called when selection is changed</summary>
    event EventHandler Efl.Ui.Selectable.SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Ui_Selectable_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Ui_Selectable_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Ui_Selectable_SelectionChangedEvt.</summary>
   public void On_Efl_Ui_Selectable_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Efl_Ui_Selectable_SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate;
   private void on_Efl_Ui_Selectable_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Efl_Ui_Selectable_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionClearedEvtKey = new object();
   /// <summary>Called when selection is cleared</summary>
   public event EventHandler SelectionClearedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionClearedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionClearedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
            if (remove_cpp_event_handler(key, this.evt_SelectionClearedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionClearedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionClearedEvt.</summary>
   public void On_SelectionClearedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionClearedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionClearedEvt_delegate;
   private void on_SelectionClearedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionClearedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
      evt_ChangedUserEvt_delegate = new Efl.EventCb(on_ChangedUserEvt_NativeCallback);
      evt_ValidateEvt_delegate = new Efl.EventCb(on_ValidateEvt_NativeCallback);
      evt_ContextOpenEvt_delegate = new Efl.EventCb(on_ContextOpenEvt_NativeCallback);
      evt_PreeditChangedEvt_delegate = new Efl.EventCb(on_PreeditChangedEvt_NativeCallback);
      evt_PressEvt_delegate = new Efl.EventCb(on_PressEvt_NativeCallback);
      evt_RedoRequestEvt_delegate = new Efl.EventCb(on_RedoRequestEvt_NativeCallback);
      evt_UndoRequestEvt_delegate = new Efl.EventCb(on_UndoRequestEvt_NativeCallback);
      evt_AbortedEvt_delegate = new Efl.EventCb(on_AbortedEvt_NativeCallback);
      evt_AnchorDownEvt_delegate = new Efl.EventCb(on_AnchorDownEvt_NativeCallback);
      evt_AnchorHoverOpenedEvt_delegate = new Efl.EventCb(on_AnchorHoverOpenedEvt_NativeCallback);
      evt_AnchorInEvt_delegate = new Efl.EventCb(on_AnchorInEvt_NativeCallback);
      evt_AnchorOutEvt_delegate = new Efl.EventCb(on_AnchorOutEvt_NativeCallback);
      evt_AnchorUpEvt_delegate = new Efl.EventCb(on_AnchorUpEvt_NativeCallback);
      evt_CursorChangedManualEvt_delegate = new Efl.EventCb(on_CursorChangedManualEvt_NativeCallback);
      evt_Efl_TextInteractive_SelectionChangedEvt_delegate = new Efl.EventCb(on_Efl_TextInteractive_SelectionChangedEvt_NativeCallback);
      evt_AccessTextCaretMovedEvt_delegate = new Efl.EventCb(on_AccessTextCaretMovedEvt_NativeCallback);
      evt_AccessTextInsertedEvt_delegate = new Efl.EventCb(on_AccessTextInsertedEvt_NativeCallback);
      evt_AccessTextRemovedEvt_delegate = new Efl.EventCb(on_AccessTextRemovedEvt_NativeCallback);
      evt_AccessTextSelectionChangedEvt_delegate = new Efl.EventCb(on_AccessTextSelectionChangedEvt_NativeCallback);
      evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
      evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
      evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
      evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
      evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
      evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
      evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
      evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
      evt_SelectedEvt_delegate = new Efl.EventCb(on_SelectedEvt_NativeCallback);
      evt_UnselectedEvt_delegate = new Efl.EventCb(on_UnselectedEvt_NativeCallback);
      evt_SelectionPasteEvt_delegate = new Efl.EventCb(on_SelectionPasteEvt_NativeCallback);
      evt_SelectionCopyEvt_delegate = new Efl.EventCb(on_SelectionCopyEvt_NativeCallback);
      evt_SelectionCutEvt_delegate = new Efl.EventCb(on_SelectionCutEvt_NativeCallback);
      evt_SelectionStartEvt_delegate = new Efl.EventCb(on_SelectionStartEvt_NativeCallback);
      evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate = new Efl.EventCb(on_Efl_Ui_Selectable_SelectionChangedEvt_NativeCallback);
      evt_SelectionClearedEvt_delegate = new Efl.EventCb(on_SelectionClearedEvt_NativeCallback);
   }
   /// <summary>Get the scrollable state of the entry
   /// Normally the entry is not scrollable. This gets the scrollable state of the entry.</summary>
   /// <returns><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</returns>
   virtual public bool GetScrollable() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_scrollable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Enable or disable scrolling in entry
   /// Normally the entry is not scrollable unless you enable it with this call.</summary>
   /// <param name="scroll"><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetScrollable( bool scroll) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_scrollable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scroll);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the attribute to show the input panel in case of only an user&apos;s explicit Mouse Up event.
   /// 1.9</summary>
   /// <returns>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</returns>
   virtual public bool GetInputPanelShowOnDemand() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_show_on_demand_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the attribute to show the input panel in case of only a user&apos;s explicit Mouse Up event. It doesn&apos;t request to show the input panel even though it has focus.
   /// 1.9</summary>
   /// <param name="ondemand">If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</param>
   /// <returns></returns>
   virtual public  void SetInputPanelShowOnDemand( bool ondemand) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_show_on_demand_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ondemand);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This returns whether the entry&apos;s contextual (longpress) menu is disabled.</summary>
   /// <returns>If <c>true</c>, the menu is disabled.</returns>
   virtual public bool GetContextMenuDisabled() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_context_menu_disabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This disables the entry&apos;s contextual (longpress) menu.</summary>
   /// <param name="disabled">If <c>true</c>, the menu is disabled.</param>
   /// <returns></returns>
   virtual public  void SetContextMenuDisabled( bool disabled) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_context_menu_disabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), disabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Getting elm_entry text paste/drop mode.
   /// Normally the entry allows both text and images to be pasted. This gets the copy &amp; paste mode of the entry.</summary>
   /// <returns>Format for copy &amp; paste.</returns>
   virtual public Efl.Ui.SelectionFormat GetCnpMode() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_cnp_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control pasting of text and images for the widget.
   /// Normally the entry allows both text and images to be pasted. By setting cnp_mode to be #ELM_CNP_MODE_NO_IMAGE this prevents images from being copied or pasted. By setting cnp_mode to be #ELM_CNP_MODE_PLAINTEXT this remove all tags in text .
   /// 
   /// Note: This only changes the behaviour of text.</summary>
   /// <param name="format">Format for copy &amp; paste.</param>
   /// <returns></returns>
   virtual public  void SetCnpMode( Efl.Ui.SelectionFormat format) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_cnp_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), format);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the language mode of the input panel.</summary>
   /// <returns>Language to be set to the input panel.</returns>
   virtual public Elm.Input.Panel.Lang GetInputPanelLanguage() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_language_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the language mode of the input panel.
   /// This API can be used if you want to show the alphabet keyboard mode.</summary>
   /// <param name="lang">Language to be set to the input panel.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelLanguage( Elm.Input.Panel.Lang lang) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_language_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), lang);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This returns whether the entry&apos;s selection handlers are disabled.</summary>
   /// <returns>If <c>true</c>, the selection handlers are disabled.</returns>
   virtual public bool GetSelectionHandlerDisabled() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_selection_handler_disabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This disables the entry&apos;s selection handlers.</summary>
   /// <param name="disabled">If <c>true</c>, the selection handlers are disabled.</param>
   /// <returns></returns>
   virtual public  void SetSelectionHandlerDisabled( bool disabled) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_selection_handler_disabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), disabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the input panel layout variation of the entry
   /// 1.8</summary>
   /// <returns>Layout variation type.</returns>
   virtual public  int GetInputPanelLayoutVariation() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_layout_variation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the input panel layout variation of the entry
   /// 1.8</summary>
   /// <param name="variation">Layout variation type.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelLayoutVariation(  int variation) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_layout_variation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), variation);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the autocapitalization type on the immodule.</summary>
   /// <returns>The type of autocapitalization.</returns>
   virtual public Elm.Autocapital.Type GetAutocapitalType() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_autocapital_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the autocapitalization type on the immodule.</summary>
   /// <param name="autocapital_type">The type of autocapitalization.</param>
   /// <returns></returns>
   virtual public  void SetAutocapitalType( Elm.Autocapital.Type autocapital_type) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_autocapital_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), autocapital_type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get whether the entry is set to password mode.</summary>
   /// <returns>If true, password mode is enabled.</returns>
   virtual public bool GetPasswordMode() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_password_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the entry to password mode.
   /// In password mode entries are implicitly single line and the display of any text inside them is replaced with asterisks (*).</summary>
   /// <param name="password">If true, password mode is enabled.</param>
   /// <returns></returns>
   virtual public  void SetPasswordMode( bool password) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_password_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), password);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get whether the return key on the input panel should be disabled or not.</summary>
   /// <returns>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</returns>
   virtual public bool GetInputPanelReturnKeyDisabled() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_return_key_disabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the return key on the input panel to be disabled.</summary>
   /// <param name="disabled">The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelReturnKeyDisabled( bool disabled) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_return_key_disabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), disabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get whether the entry allows predictive text.</summary>
   /// <returns>Whether the entry should allow predictive text.</returns>
   virtual public bool GetPredictionAllow() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_prediction_allow_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set whether the entry should allow predictive text.</summary>
   /// <param name="prediction">Whether the entry should allow predictive text.</param>
   /// <returns></returns>
   virtual public  void SetPredictionAllow( bool prediction) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_prediction_allow_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), prediction);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the value of input hint.</summary>
   /// <returns>Input hint.</returns>
   virtual public Elm.Input.Hints GetInputHint() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_hint_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the input hint which allows input methods to fine-tune their behavior.</summary>
   /// <param name="hints">Input hint.</param>
   /// <returns></returns>
   virtual public  void SetInputHint( Elm.Input.Hints hints) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_hint_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hints);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the input panel layout of the entry.</summary>
   /// <returns>Layout type.</returns>
   virtual public Elm.Input.Panel.Layout GetInputPanelLayout() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_layout_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the input panel layout of the entry.</summary>
   /// <param name="layout">Layout type.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelLayout( Elm.Input.Panel.Layout layout) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_layout_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), layout);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the &quot;return&quot; key type.</summary>
   /// <returns>The type of &quot;return&quot; key on the input panel.</returns>
   virtual public Elm.Input.Panel.ReturnKey.Type GetInputPanelReturnKeyType() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_return_key_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the &quot;return&quot; key type. This type is used to set string or icon on the &quot;return&quot; key of the input panel.
   /// An input panel displays the string or icon associated with this type.</summary>
   /// <param name="return_key_type">The type of &quot;return&quot; key on the input panel.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelReturnKeyType( Elm.Input.Panel.ReturnKey.Type return_key_type) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_return_key_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), return_key_type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the attribute to show the input panel automatically.</summary>
   /// <returns>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</returns>
   virtual public bool GetInputPanelEnabled() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the attribute to show the input panel automatically.</summary>
   /// <param name="enabled">If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelEnabled( bool enabled) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set whether the return key on the input panel is disabled automatically when entry has no text.
   /// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
   /// <param name="enabled">If <c>enabled</c> is <c>true</c>, the return key is automatically disabled when the entry has no text.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelReturnKeyAutoenabled( bool enabled) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_return_key_autoenabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
   /// <returns>Factory to create items</returns>
   virtual public Efl.Canvas.TextFactory GetItemFactory() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_item_factory_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
   /// <param name="item_factory">Factory to create items</param>
   /// <returns></returns>
   virtual public  void SetItemFactory( Efl.Canvas.TextFactory item_factory) {
                         Efl.Ui.TextNativeInherit.efl_ui_text_item_factory_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), item_factory);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Show the input panel (virtual keyboard) based on the input panel property of entry such as layout, autocapital types and so on.
   /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>).</summary>
   /// <returns></returns>
   virtual public  void ShowInputPanel() {
       Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_show_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This executes a &quot;copy&quot; action on the selected text in the entry.</summary>
   /// <returns></returns>
   virtual public  void SelectionCopy() {
       Efl.Ui.TextNativeInherit.efl_ui_text_selection_copy_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This clears and frees the items in a entry&apos;s contextual (longpress) menu.
   /// See also <see cref="Efl.Ui.Text.AddContextMenuItem"/>.</summary>
   /// <returns></returns>
   virtual public  void ClearContextMenu() {
       Efl.Ui.TextNativeInherit.efl_ui_text_context_menu_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Set the input panel-specific data to deliver to the input panel.
   /// This API is used by applications to deliver specific data to the input panel. The data format MUST be negotiated by both application and the input panel. The size and format of data are defined by the input panel.</summary>
   /// <param name="data">The specific data to be set to the input panel.</param>
   /// <param name="len">The length of data, in bytes, to send to the input panel.</param>
   /// <returns></returns>
   virtual public  void SetInputPanelImdata(  System.IntPtr data,   int len) {
                                           Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_imdata_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), data,  len);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the specific data of the current input panel.</summary>
   /// <param name="data">The specific data to be obtained from the input panel.</param>
   /// <param name="len">The length of data.</param>
   /// <returns></returns>
   virtual public  void GetInputPanelImdata( ref  System.IntPtr data,  out  int len) {
                                           Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_imdata_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref data,  out len);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>This executes a &quot;paste&quot; action in the entry.</summary>
   /// <returns></returns>
   virtual public  void SelectionPaste() {
       Efl.Ui.TextNativeInherit.efl_ui_text_selection_paste_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Hide the input panel (virtual keyboard).
   /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>)</summary>
   /// <returns></returns>
   virtual public  void HideInputPanel() {
       Efl.Ui.TextNativeInherit.efl_ui_text_input_panel_hide_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This ends a selection within the entry as though the user had just released the mouse button while making a selection.</summary>
   /// <returns></returns>
   virtual public  void CursorSelectionEnd() {
       Efl.Ui.TextNativeInherit.efl_ui_text_cursor_selection_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This executes a &quot;cut&quot; action on the selected text in the entry.</summary>
   /// <returns></returns>
   virtual public  void SelectionCut() {
       Efl.Ui.TextNativeInherit.efl_ui_text_selection_cut_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This adds an item to the entry&apos;s contextual menu.
   /// A longpress on an entry will make the contextual menu show up unless this has been disabled with <see cref="Efl.Ui.Text.SetContextMenuDisabled"/>. By default this menu provides a few options like enabling selection mode, which is useful on embedded devices that need to be explicit about it. When a selection exists it also shows the copy and cut actions.
   /// 
   /// With this function, developers can add other options to this menu to perform any action they deem necessary.</summary>
   /// <param name="label">The item&apos;s text label.</param>
   /// <param name="icon_file">The item&apos;s icon file.</param>
   /// <param name="icon_type">The item&apos;s icon type.</param>
   /// <param name="func">The callback to execute when the item is clicked.</param>
   /// <param name="data">The data to associate with the item for related functions.</param>
   /// <returns></returns>
   virtual public  void AddContextMenuItem(  System.String label,   System.String icon_file,  Elm.Icon.Type icon_type,  EvasSmartCb func,   System.IntPtr data) {
                                                                                                 Efl.Ui.TextNativeInherit.efl_ui_text_context_menu_item_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), label,  icon_file,  icon_type,  func,  data);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Creates and returns a new cursor for the text.</summary>
   /// <returns>Text cursor</returns>
   virtual public Efl.TextCursorCursor NewCursor() {
       var _ret_var = Efl.Ui.TextNativeInherit.efl_ui_text_cursor_new_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
   /// <returns>The handle to an Eina_File that will be used</returns>
   virtual public Eina.File GetMmap() {
       var _ret_var = Efl.FileNativeInherit.efl_file_mmap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an Eina_File).
   /// If mmap is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="f">The handle to an Eina_File that will be used</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetMmap( Eina.File f) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_mmap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), f);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The file path.</returns>
   virtual public  System.String GetFile() {
       var _ret_var = Efl.FileNativeInherit.efl_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the file path from where an object will fetch the data.
   /// If file is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="file">The file path.</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetFile(  System.String file) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), file);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
   /// 
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</returns>
   virtual public  System.String GetKey() {
       var _ret_var = Efl.FileNativeInherit.efl_file_key_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.</summary>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns></returns>
   virtual public  void SetKey(  System.String key) {
                         Efl.FileNativeInherit.efl_file_key_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the load state of the object.</summary>
   /// <returns>True if the object is loaded, otherwise false.</returns>
   virtual public bool GetLoaded() {
       var _ret_var = Efl.FileNativeInherit.efl_file_loaded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.File.File"/> (or <see cref="Efl.File.Mmap"/>) and <see cref="Efl.File.Key"/> properties.
   /// In the case where <see cref="Efl.File.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.File.SetMmap"/> on the object using the opened file handle.
   /// 
   /// Calling <see cref="Efl.File.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error Load() {
       var _ret_var = Efl.FileNativeInherit.efl_file_load_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to unload file data from the object.
   /// In the case where <see cref="Efl.File.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
   /// 
   /// Calling <see cref="Efl.File.Unload"/> on an object which is not currently loaded will have no effect.</summary>
   /// <returns></returns>
   virtual public  void Unload() {
       Efl.FileNativeInherit.efl_file_unload_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   virtual public  System.String GetText() {
       var _ret_var = Efl.TextNativeInherit.efl_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   virtual public  void SetText(  System.String text) {
                         Efl.TextNativeInherit.efl_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieve the font family and size in use on a given text object.
   /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetFont( out  System.String font,  out Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set the font family, filename and size for a given text object.
   /// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>, <see cref="Efl.TextFont.GetFontSource"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFont(  System.String font,  Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), font,  size);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
   /// See <see cref="Efl.TextFont.GetFont"/> for more details.
   /// 1.20</summary>
   /// <returns>The font file&apos;s path.
   /// 1.20</returns>
   virtual public  System.String GetFontSource() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_source_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the font (source) file to be used on a given text object.
   /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font_source">The font file&apos;s path.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontSource(  System.String font_source) {
                         Efl.TextFontNativeInherit.efl_text_font_source_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), font_source);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <returns>Font name fallbacks
   /// 1.20</returns>
   virtual public  System.String GetFontFallbacks() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_fallbacks_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <param name="font_fallbacks">Font name fallbacks
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontFallbacks(  System.String font_fallbacks) {
                         Efl.TextFontNativeInherit.efl_text_font_fallbacks_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), font_fallbacks);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font weight
   /// 1.20</returns>
   virtual public Efl.TextFontWeight GetFontWeight() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_weight_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <param name="font_weight">Font weight
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontWeight( Efl.TextFontWeight font_weight) {
                         Efl.TextFontNativeInherit.efl_text_font_weight_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), font_weight);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font slant
   /// 1.20</returns>
   virtual public Efl.TextFontSlant GetFontSlant() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_slant_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <param name="style">Font slant
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontSlant( Efl.TextFontSlant style) {
                         Efl.TextFontNativeInherit.efl_text_font_slant_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font width
   /// 1.20</returns>
   virtual public Efl.TextFontWidth GetFontWidth() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_width_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <param name="width">Font width
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontWidth( Efl.TextFontWidth width) {
                         Efl.TextFontNativeInherit.efl_text_font_width_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), width);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <returns>Language
   /// 1.20</returns>
   virtual public  System.String GetFontLang() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_lang_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <param name="lang">Language
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontLang(  System.String lang) {
                         Efl.TextFontNativeInherit.efl_text_font_lang_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), lang);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <returns>Scalable
   /// 1.20</returns>
   virtual public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <param name="scalable">Scalable
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFontBitmapScalable( Efl.TextFontBitmapScalable scalable) {
                         Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scalable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <returns>Ellipsis value
   /// 1.20</returns>
   virtual public double GetEllipsis() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_ellipsis_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <param name="value">Ellipsis value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetEllipsis( double value) {
                         Efl.TextFormatNativeInherit.efl_text_ellipsis_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <returns>Wrap mode
   /// 1.20</returns>
   virtual public Efl.TextFormatWrap GetWrap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_wrap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <param name="wrap">Wrap mode
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetWrap( Efl.TextFormatWrap wrap) {
                         Efl.TextFormatNativeInherit.efl_text_wrap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), wrap);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetMultiline() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_multiline_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMultiline( bool enabled) {
                         Efl.TextFormatNativeInherit.efl_text_multiline_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Alignment type
   /// 1.20</returns>
   virtual public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_halign_auto_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Alignment type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetHalignAutoType( Efl.TextFormatHorizontalAlignmentAutoType value) {
                         Efl.TextFormatNativeInherit.efl_text_halign_auto_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Horizontal alignment value
   /// 1.20</returns>
   virtual public double GetHalign() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_halign_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Horizontal alignment value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetHalign( double value) {
                         Efl.TextFormatNativeInherit.efl_text_halign_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <returns>Vertical alignment value
   /// 1.20</returns>
   virtual public double GetValign() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_valign_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <param name="value">Vertical alignment value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetValign( double value) {
                         Efl.TextFormatNativeInherit.efl_text_valign_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <returns>Line gap value
   /// 1.20</returns>
   virtual public double GetLinegap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_linegap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <param name="value">Line gap value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetLinegap( double value) {
                         Efl.TextFormatNativeInherit.efl_text_linegap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <returns>Relative line gap value
   /// 1.20</returns>
   virtual public double GetLinerelgap() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_linerelgap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <param name="value">Relative line gap value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetLinerelgap( double value) {
                         Efl.TextFormatNativeInherit.efl_text_linerelgap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <returns>Tapstops value
   /// 1.20</returns>
   virtual public  int GetTabstops() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_tabstops_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <param name="value">Tapstops value
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetTabstops(  int value) {
                         Efl.TextFormatNativeInherit.efl_text_tabstops_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), value);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</returns>
   virtual public bool GetPassword() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_password_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetPassword( bool enabled) {
                         Efl.TextFormatNativeInherit.efl_text_password_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <returns>Replacement character
   /// 1.20</returns>
   virtual public  System.String GetReplacementChar() {
       var _ret_var = Efl.TextFormatNativeInherit.efl_text_replacement_char_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <param name="repch">Replacement character
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetReplacementChar(  System.String repch) {
                         Efl.TextFormatNativeInherit.efl_text_replacement_char_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), repch);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether or not selection is allowed on this object</summary>
   /// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
   virtual public bool GetSelectionAllowed() {
       var _ret_var = Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_allowed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether or not selection is allowed on this object</summary>
   /// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetSelectionAllowed( bool allowed) {
                         Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_allowed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), allowed);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The cursors used for selection handling.
   /// If the cursors are equal there&apos;s no selection.
   /// 
   /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
   /// <param name="start">The start of the selection</param>
   /// <param name="end">The end of the selection</param>
   /// <returns></returns>
   virtual public  void GetSelectionCursors( out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end) {
                                           Efl.TextInteractiveNativeInherit.efl_text_interactive_selection_cursors_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out start,  out end);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Whether the entry is editable.
   /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
   /// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
   virtual public bool GetEditable() {
       var _ret_var = Efl.TextInteractiveNativeInherit.efl_text_interactive_editable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Whether the entry is editable.
   /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
   /// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
   /// <returns></returns>
   virtual public  void SetEditable( bool editable) {
                         Efl.TextInteractiveNativeInherit.efl_text_interactive_editable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), editable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Clears the selection.</summary>
   /// <returns></returns>
   virtual public  void SelectNone() {
       Efl.TextInteractiveNativeInherit.efl_text_interactive_select_none_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Color of text, excluding style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetNormalColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_normal_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of text, excluding style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetNormalColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_normal_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <returns>Backing type
   /// 1.20</returns>
   virtual public Efl.TextStyleBackingType GetBackingType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_backing_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Enable or disable backing type
   /// 1.20</summary>
   /// <param name="type">Backing type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetBackingType( Efl.TextStyleBackingType type) {
                         Efl.TextStyleNativeInherit.efl_text_backing_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Backing color
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetBackingColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_backing_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Backing color
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetBackingColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_backing_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <returns>Underline type
   /// 1.20</returns>
   virtual public Efl.TextStyleUnderlineType GetUnderlineType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets an underline style on the text
   /// 1.20</summary>
   /// <param name="type">Underline type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineType( Efl.TextStyleUnderlineType type) {
                         Efl.TextStyleNativeInherit.efl_text_underline_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of normal underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of normal underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <returns>Height
   /// 1.20</returns>
   virtual public double GetUnderlineHeight() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_height_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Height of underline style
   /// 1.20</summary>
   /// <param name="height">Height
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineHeight( double height) {
                         Efl.TextStyleNativeInherit.efl_text_underline_height_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), height);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of dashed underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderlineDashedColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_dashed_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of dashed underline style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline_dashed_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <returns>Width
   /// 1.20</returns>
   virtual public  int GetUnderlineDashedWidth() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_dashed_width_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Width of dashed underline style
   /// 1.20</summary>
   /// <param name="width">Width
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedWidth(  int width) {
                         Efl.TextStyleNativeInherit.efl_text_underline_dashed_width_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), width);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <returns>Gap
   /// 1.20</returns>
   virtual public  int GetUnderlineDashedGap() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_underline_dashed_gap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gap of dashed underline style
   /// 1.20</summary>
   /// <param name="gap">Gap
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderlineDashedGap(  int gap) {
                         Efl.TextStyleNativeInherit.efl_text_underline_dashed_gap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), gap);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of underline2 style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetUnderline2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline2_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of underline2 style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetUnderline2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_underline2_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <returns>Strikethrough type
   /// 1.20</returns>
   virtual public Efl.TextStyleStrikethroughType GetStrikethroughType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_strikethrough_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of strikethrough style
   /// 1.20</summary>
   /// <param name="type">Strikethrough type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetStrikethroughType( Efl.TextStyleStrikethroughType type) {
                         Efl.TextStyleNativeInherit.efl_text_strikethrough_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of strikethrough_style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetStrikethroughColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_strikethrough_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of strikethrough_style
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetStrikethroughColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_strikethrough_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <returns>Effect type
   /// 1.20</returns>
   virtual public Efl.TextStyleEffectType GetEffectType() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_effect_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of effect used for the displayed text
   /// 1.20</summary>
   /// <param name="type">Effect type
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetEffectType( Efl.TextStyleEffectType type) {
                         Efl.TextStyleNativeInherit.efl_text_effect_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of outline effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetOutlineColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_outline_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of outline effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetOutlineColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_outline_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <returns>Shadow direction
   /// 1.20</returns>
   virtual public Efl.TextStyleShadowDirection GetShadowDirection() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_shadow_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Direction of shadow effect
   /// 1.20</summary>
   /// <param name="type">Shadow direction
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetShadowDirection( Efl.TextStyleShadowDirection type) {
                         Efl.TextStyleNativeInherit.efl_text_shadow_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Color of shadow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetShadowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_shadow_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of shadow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetShadowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_shadow_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetGlowColor( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Color of glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGlowColor(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Second color of the glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetGlow2Color( out  byte r,  out  byte g,  out  byte b,  out  byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow2_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Second color of the glow effect
   /// 1.20</summary>
   /// <param name="r">Red component
   /// 1.20</param>
   /// <param name="g">Green component
   /// 1.20</param>
   /// <param name="b">Blue component
   /// 1.20</param>
   /// <param name="a">Alpha component
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGlow2Color(  byte r,   byte g,   byte b,   byte a) {
                                                                               Efl.TextStyleNativeInherit.efl_text_glow2_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <returns>Filter code
   /// 1.20</returns>
   virtual public  System.String GetGfxFilter() {
       var _ret_var = Efl.TextStyleNativeInherit.efl_text_gfx_filter_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Program that applies a special filter
   /// See <see cref="Efl.Gfx.Filter"/>.
   /// 1.20</summary>
   /// <param name="code">Filter code
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetGfxFilter(  System.String code) {
                         Efl.TextStyleNativeInherit.efl_text_gfx_filter_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), code);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
   /// <param name="offset">Position in text.</param>
   /// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicates that string includes invalid UTF8 chars.</returns>
   virtual public Eina.Unicode GetCharacter(  int offset) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), offset);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
   /// <param name="granularity">Text granularity</param>
   /// <param name="start_offset">Offset indicating start of string according to given granularity.  -1 in case of error.</param>
   /// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
   /// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
   virtual public  System.String GetString( Efl.Access.TextGranularity granularity,   int start_offset,   int end_offset) {
             var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                          var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), granularity,  _in_start_offset,  _in_end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Gets text of accessible widget.</summary>
   /// <param name="start_offset">Position in text.</param>
   /// <param name="end_offset">End offset of text.</param>
   /// <returns>UTF-8 encoded text.</returns>
   virtual public  System.String GetAccessText(  int start_offset,   int end_offset) {
                                           var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets offset position of caret (cursor)</summary>
   /// <returns>Offset</returns>
   virtual public  int GetCaretOffset() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_caret_offset_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Caret offset property</summary>
   /// <param name="offset">Offset</param>
   /// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
   virtual public bool SetCaretOffset(  int offset) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_caret_offset_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), offset);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Indicate if a text attribute with a given name is set</summary>
   /// <param name="name">Text attribute name</param>
   /// <param name="start_offset">Position in text from which given attribute is set.</param>
   /// <param name="end_offset">Position in text to which given attribute is set.</param>
   /// <param name="value">Value of text attribute. Should be free()</param>
   /// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
   virtual public bool GetAttribute(  System.String name,   int start_offset,   int end_offset,  out  System.String value) {
             var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                            var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_attribute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  _in_start_offset,  _in_end_offset,  out value);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }
   /// <summary>Gets list of all text attributes.</summary>
   /// <param name="start_offset">Start offset</param>
   /// <param name="end_offset">End offset</param>
   /// <returns>List of text attributes</returns>
   virtual public Eina.List<Efl.Access.TextAttribute> GetTextAttributes(  int start_offset,   int end_offset) {
       var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                              var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_attributes_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_start_offset,  _in_end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
   /// <summary>Default attributes</summary>
   /// <returns>List of default attributes</returns>
   virtual public Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_default_attributes_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
   /// <summary>Character extents</summary>
   /// <param name="offset">Offset</param>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">Extents rectangle</param>
   /// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
   virtual public bool GetCharacterExtents(  int offset,  bool screen_coords,  out Eina.Rect rect) {
                                     var _out_rect = new Eina.Rect_StructInternal();
                        var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_extents_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), offset,  screen_coords,  out _out_rect);
      Eina.Error.RaiseIfUnhandledException();
                  rect = Eina.Rect_StructConversion.ToManaged(_out_rect);
                        return _ret_var;
 }
   /// <summary>Character count</summary>
   /// <returns>Character count</returns>
   virtual public  int GetCharacterCount() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_character_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Offset at given point</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <returns>Offset</returns>
   virtual public  int GetOffsetAtPoint( bool screen_coords,   int x,   int y) {
                                                             var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_offset_at_point_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Bounded ranges</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="rect">Bounding box</param>
   /// <param name="xclip">xclip</param>
   /// <param name="yclip">yclip</param>
   /// <returns>List of ranges</returns>
   virtual public Eina.List<Efl.Access.TextRange> GetBoundedRanges( bool screen_coords,  Eina.Rect rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip) {
             var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                                                  var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_bounded_ranges_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  _in_rect,  xclip,  yclip);
      Eina.Error.RaiseIfUnhandledException();
                                                      return new Eina.List<Efl.Access.TextRange>(_ret_var, true, true);
 }
   /// <summary>Range extents</summary>
   /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
   /// <param name="start_offset">Start offset</param>
   /// <param name="end_offset">End offset</param>
   /// <param name="rect">Range rectangle</param>
   /// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
   virtual public bool GetRangeExtents( bool screen_coords,   int start_offset,   int end_offset,  out Eina.Rect rect) {
                                                 var _out_rect = new Eina.Rect_StructInternal();
                              var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_range_extents_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), screen_coords,  start_offset,  end_offset,  out _out_rect);
      Eina.Error.RaiseIfUnhandledException();
                        rect = Eina.Rect_StructConversion.ToManaged(_out_rect);
                              return _ret_var;
 }
   /// <summary>Selection count property</summary>
   /// <returns>Selection counter</returns>
   virtual public  int GetSelectionsCount() {
       var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selections_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Selection property</summary>
   /// <param name="selection_number">Selection number for identification</param>
   /// <param name="start_offset">Selection start offset</param>
   /// <param name="end_offset">Selection end offset</param>
   /// <returns></returns>
   virtual public  void GetAccessSelection(  int selection_number,  out  int start_offset,  out  int end_offset) {
                                                             Efl.Access.TextNativeInherit.efl_access_text_access_selection_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), selection_number,  out start_offset,  out end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Selection property</summary>
   /// <param name="selection_number">Selection number for identification</param>
   /// <param name="start_offset">Selection start offset</param>
   /// <param name="end_offset">Selection end offset</param>
   /// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
   virtual public bool SetAccessSelection(  int selection_number,   int start_offset,   int end_offset) {
                                                             var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_access_selection_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), selection_number,  start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Add selection</summary>
   /// <param name="start_offset">Start selection from this offset</param>
   /// <param name="end_offset">End selection at this offset</param>
   /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
   virtual public bool AddSelection(  int start_offset,   int end_offset) {
                                           var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selection_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), start_offset,  end_offset);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Remove selection</summary>
   /// <param name="selection_number">Selection number to be removed</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   virtual public bool SelectionRemove(  int selection_number) {
                         var _ret_var = Efl.Access.TextNativeInherit.efl_access_text_selection_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), selection_number);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Editable content property</summary>
   /// <param name="kw_string">Content</param>
   /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
   virtual public bool SetTextContent(  System.String kw_string) {
                         var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_string);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Insert text at given position</summary>
   /// <param name="kw_string">String to be inserted</param>
   /// <param name="position">Position to insert string</param>
   /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
   virtual public bool Insert(  System.String kw_string,   int position) {
                                           var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_insert_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_string,  position);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Copy text between start and end parameter</summary>
   /// <param name="start">Start position to copy</param>
   /// <param name="end">End position to copy</param>
   /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
   virtual public bool Copy(  int start,   int end) {
                                           var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_copy_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Cut text between start and end parameter</summary>
   /// <param name="start">Start position to cut</param>
   /// <param name="end">End position to cut</param>
   /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
   virtual public bool Cut(  int start,   int end) {
                                           var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_cut_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Delete text between start and end parameter</summary>
   /// <param name="start">Start position to delete</param>
   /// <param name="end">End position to delete</param>
   /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
   virtual public bool Delete(  int start,   int end) {
                                           var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_delete_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), start,  end);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Paste text at given position</summary>
   /// <param name="position">Position to insert text</param>
   /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
   virtual public bool Paste(  int position) {
                         var _ret_var = Efl.Access.Editable.TextNativeInherit.efl_access_editable_text_paste_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), position);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the scrollable state of the entry
/// Normally the entry is not scrollable. This gets the scrollable state of the entry.</summary>
/// <value><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</value>
   public bool Scrollable {
      get { return GetScrollable(); }
      set { SetScrollable( value); }
   }
   /// <summary>Get the attribute to show the input panel in case of only an user&apos;s explicit Mouse Up event.
/// 1.9</summary>
/// <value>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</value>
   public bool InputPanelShowOnDemand {
      get { return GetInputPanelShowOnDemand(); }
      set { SetInputPanelShowOnDemand( value); }
   }
   /// <summary>This returns whether the entry&apos;s contextual (longpress) menu is disabled.</summary>
/// <value>If <c>true</c>, the menu is disabled.</value>
   public bool ContextMenuDisabled {
      get { return GetContextMenuDisabled(); }
      set { SetContextMenuDisabled( value); }
   }
   /// <summary>Getting elm_entry text paste/drop mode.
/// Normally the entry allows both text and images to be pasted. This gets the copy &amp; paste mode of the entry.</summary>
/// <value>Format for copy &amp; paste.</value>
   public Efl.Ui.SelectionFormat CnpMode {
      get { return GetCnpMode(); }
      set { SetCnpMode( value); }
   }
   /// <summary>Get the language mode of the input panel.</summary>
/// <value>Language to be set to the input panel.</value>
   public Elm.Input.Panel.Lang InputPanelLanguage {
      get { return GetInputPanelLanguage(); }
      set { SetInputPanelLanguage( value); }
   }
   /// <summary>This returns whether the entry&apos;s selection handlers are disabled.</summary>
/// <value>If <c>true</c>, the selection handlers are disabled.</value>
   public bool SelectionHandlerDisabled {
      get { return GetSelectionHandlerDisabled(); }
      set { SetSelectionHandlerDisabled( value); }
   }
   /// <summary>Get the input panel layout variation of the entry
/// 1.8</summary>
/// <value>Layout variation type.</value>
   public  int InputPanelLayoutVariation {
      get { return GetInputPanelLayoutVariation(); }
      set { SetInputPanelLayoutVariation( value); }
   }
   /// <summary>Get the autocapitalization type on the immodule.</summary>
/// <value>The type of autocapitalization.</value>
   public Elm.Autocapital.Type AutocapitalType {
      get { return GetAutocapitalType(); }
      set { SetAutocapitalType( value); }
   }
   /// <summary>Get whether the entry is set to password mode.</summary>
/// <value>If true, password mode is enabled.</value>
   public bool PasswordMode {
      get { return GetPasswordMode(); }
      set { SetPasswordMode( value); }
   }
   /// <summary>Get whether the return key on the input panel should be disabled or not.</summary>
/// <value>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</value>
   public bool InputPanelReturnKeyDisabled {
      get { return GetInputPanelReturnKeyDisabled(); }
      set { SetInputPanelReturnKeyDisabled( value); }
   }
   /// <summary>Get whether the entry allows predictive text.</summary>
/// <value>Whether the entry should allow predictive text.</value>
   public bool PredictionAllow {
      get { return GetPredictionAllow(); }
      set { SetPredictionAllow( value); }
   }
   /// <summary>Gets the value of input hint.</summary>
/// <value>Input hint.</value>
   public Elm.Input.Hints InputHint {
      get { return GetInputHint(); }
      set { SetInputHint( value); }
   }
   /// <summary>Get the input panel layout of the entry.</summary>
/// <value>Layout type.</value>
   public Elm.Input.Panel.Layout InputPanelLayout {
      get { return GetInputPanelLayout(); }
      set { SetInputPanelLayout( value); }
   }
   /// <summary>Get the &quot;return&quot; key type.</summary>
/// <value>The type of &quot;return&quot; key on the input panel.</value>
   public Elm.Input.Panel.ReturnKey.Type InputPanelReturnKeyType {
      get { return GetInputPanelReturnKeyType(); }
      set { SetInputPanelReturnKeyType( value); }
   }
   /// <summary>Get the attribute to show the input panel automatically.</summary>
/// <value>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</value>
   public bool InputPanelEnabled {
      get { return GetInputPanelEnabled(); }
      set { SetInputPanelEnabled( value); }
   }
   /// <summary>Set whether the return key on the input panel is disabled automatically when entry has no text.
/// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
/// <value>If <c>enabled</c> is <c>true</c>, the return key is automatically disabled when the entry has no text.</value>
   public bool InputPanelReturnKeyAutoenabled {
      set { SetInputPanelReturnKeyAutoenabled( value); }
   }
   /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
/// <value>Factory to create items</value>
   public Efl.Canvas.TextFactory ItemFactory {
      get { return GetItemFactory(); }
      set { SetItemFactory( value); }
   }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
/// <value>The handle to an Eina_File that will be used</value>
   public Eina.File Mmap {
      get { return GetMmap(); }
      set { SetMmap( value); }
   }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The file path.</value>
   public  System.String File {
      get { return GetFile(); }
      set { SetFile( value); }
   }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
/// 
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</value>
   public  System.String Key {
      get { return GetKey(); }
      set { SetKey( value); }
   }
   /// <summary>Get the load state of the object.</summary>
/// <value>True if the object is loaded, otherwise false.</value>
   public bool Loaded {
      get { return GetLoaded(); }
   }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
/// <value>The font file&apos;s path.
/// 1.20</value>
   public  System.String FontSource {
      get { return GetFontSource(); }
      set { SetFontSource( value); }
   }
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <value>Font name fallbacks
/// 1.20</value>
   public  System.String FontFallbacks {
      get { return GetFontFallbacks(); }
      set { SetFontFallbacks( value); }
   }
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <value>Font weight
/// 1.20</value>
   public Efl.TextFontWeight FontWeight {
      get { return GetFontWeight(); }
      set { SetFontWeight( value); }
   }
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <value>Font slant
/// 1.20</value>
   public Efl.TextFontSlant FontSlant {
      get { return GetFontSlant(); }
      set { SetFontSlant( value); }
   }
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <value>Font width
/// 1.20</value>
   public Efl.TextFontWidth FontWidth {
      get { return GetFontWidth(); }
      set { SetFontWidth( value); }
   }
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <value>Language
/// 1.20</value>
   public  System.String FontLang {
      get { return GetFontLang(); }
      set { SetFontLang( value); }
   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <value>Scalable
/// 1.20</value>
   public Efl.TextFontBitmapScalable FontBitmapScalable {
      get { return GetFontBitmapScalable(); }
      set { SetFontBitmapScalable( value); }
   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
/// <value>Ellipsis value
/// 1.20</value>
   public double Ellipsis {
      get { return GetEllipsis(); }
      set { SetEllipsis( value); }
   }
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
/// <value>Wrap mode
/// 1.20</value>
   public Efl.TextFormatWrap Wrap {
      get { return GetWrap(); }
      set { SetWrap( value); }
   }
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
/// <value><c>true</c> if multiline is enabled, <c>false</c> otherwise
/// 1.20</value>
   public bool Multiline {
      get { return GetMultiline(); }
      set { SetMultiline( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <value>Alignment type
/// 1.20</value>
   public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
      get { return GetHalignAutoType(); }
      set { SetHalignAutoType( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <value>Horizontal alignment value
/// 1.20</value>
   public double Halign {
      get { return GetHalign(); }
      set { SetHalign( value); }
   }
   /// <summary>Vertical alignment of text
/// 1.20</summary>
/// <value>Vertical alignment value
/// 1.20</value>
   public double Valign {
      get { return GetValign(); }
      set { SetValign( value); }
   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
/// <value>Line gap value
/// 1.20</value>
   public double Linegap {
      get { return GetLinegap(); }
      set { SetLinegap( value); }
   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
/// <value>Relative line gap value
/// 1.20</value>
   public double Linerelgap {
      get { return GetLinerelgap(); }
      set { SetLinerelgap( value); }
   }
   /// <summary>Tabstops value
/// 1.20</summary>
/// <value>Tapstops value
/// 1.20</value>
   public  int Tabstops {
      get { return GetTabstops(); }
      set { SetTabstops( value); }
   }
   /// <summary>Whether text is a password
/// 1.20</summary>
/// <value><c>true</c> if the text is a password, <c>false</c> otherwise
/// 1.20</value>
   public bool Password {
      get { return GetPassword(); }
      set { SetPassword( value); }
   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
/// <value>Replacement character
/// 1.20</value>
   public  System.String ReplacementChar {
      get { return GetReplacementChar(); }
      set { SetReplacementChar( value); }
   }
   /// <summary>Whether or not selection is allowed on this object</summary>
/// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
   public bool SelectionAllowed {
      get { return GetSelectionAllowed(); }
      set { SetSelectionAllowed( value); }
   }
   /// <summary>Whether the entry is editable.
/// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
/// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
   public bool Editable {
      get { return GetEditable(); }
      set { SetEditable( value); }
   }
   /// <summary>Enable or disable backing type
/// 1.20</summary>
/// <value>Backing type
/// 1.20</value>
   public Efl.TextStyleBackingType BackingType {
      get { return GetBackingType(); }
      set { SetBackingType( value); }
   }
   /// <summary>Sets an underline style on the text
/// 1.20</summary>
/// <value>Underline type
/// 1.20</value>
   public Efl.TextStyleUnderlineType UnderlineType {
      get { return GetUnderlineType(); }
      set { SetUnderlineType( value); }
   }
   /// <summary>Height of underline style
/// 1.20</summary>
/// <value>Height
/// 1.20</value>
   public double UnderlineHeight {
      get { return GetUnderlineHeight(); }
      set { SetUnderlineHeight( value); }
   }
   /// <summary>Width of dashed underline style
/// 1.20</summary>
/// <value>Width
/// 1.20</value>
   public  int UnderlineDashedWidth {
      get { return GetUnderlineDashedWidth(); }
      set { SetUnderlineDashedWidth( value); }
   }
   /// <summary>Gap of dashed underline style
/// 1.20</summary>
/// <value>Gap
/// 1.20</value>
   public  int UnderlineDashedGap {
      get { return GetUnderlineDashedGap(); }
      set { SetUnderlineDashedGap( value); }
   }
   /// <summary>Type of strikethrough style
/// 1.20</summary>
/// <value>Strikethrough type
/// 1.20</value>
   public Efl.TextStyleStrikethroughType StrikethroughType {
      get { return GetStrikethroughType(); }
      set { SetStrikethroughType( value); }
   }
   /// <summary>Type of effect used for the displayed text
/// 1.20</summary>
/// <value>Effect type
/// 1.20</value>
   public Efl.TextStyleEffectType EffectType {
      get { return GetEffectType(); }
      set { SetEffectType( value); }
   }
   /// <summary>Direction of shadow effect
/// 1.20</summary>
/// <value>Shadow direction
/// 1.20</value>
   public Efl.TextStyleShadowDirection ShadowDirection {
      get { return GetShadowDirection(); }
      set { SetShadowDirection( value); }
   }
   /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.Filter"/>.
/// 1.20</summary>
/// <value>Filter code
/// 1.20</value>
   public  System.String GfxFilter {
      get { return GetGfxFilter(); }
      set { SetGfxFilter( value); }
   }
   /// <summary>Caret offset property</summary>
/// <value>Offset</value>
   public  int CaretOffset {
      get { return GetCaretOffset(); }
      set { SetCaretOffset( value); }
   }
   /// <summary>Default attributes</summary>
/// <value>List of default attributes</value>
   public Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
      get { return GetDefaultAttributes(); }
   }
   /// <summary>Character count</summary>
/// <value>Character count</value>
   public  int CharacterCount {
      get { return GetCharacterCount(); }
   }
   /// <summary>Selection count property</summary>
/// <value>Selection counter</value>
   public  int SelectionsCount {
      get { return GetSelectionsCount(); }
   }
   /// <summary>Editable content property</summary>
/// <value>Content</value>
   public  System.String TextContent {
      set { SetTextContent( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Text.efl_ui_text_class_get();
   }
}
public class TextNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_text_scrollable_get_static_delegate == null)
      efl_ui_text_scrollable_get_static_delegate = new efl_ui_text_scrollable_get_delegate(scrollable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_scrollable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_scrollable_get_static_delegate)});
      if (efl_ui_text_scrollable_set_static_delegate == null)
      efl_ui_text_scrollable_set_static_delegate = new efl_ui_text_scrollable_set_delegate(scrollable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_scrollable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_scrollable_set_static_delegate)});
      if (efl_ui_text_input_panel_show_on_demand_get_static_delegate == null)
      efl_ui_text_input_panel_show_on_demand_get_static_delegate = new efl_ui_text_input_panel_show_on_demand_get_delegate(input_panel_show_on_demand_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_show_on_demand_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_on_demand_get_static_delegate)});
      if (efl_ui_text_input_panel_show_on_demand_set_static_delegate == null)
      efl_ui_text_input_panel_show_on_demand_set_static_delegate = new efl_ui_text_input_panel_show_on_demand_set_delegate(input_panel_show_on_demand_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_show_on_demand_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_on_demand_set_static_delegate)});
      if (efl_ui_text_context_menu_disabled_get_static_delegate == null)
      efl_ui_text_context_menu_disabled_get_static_delegate = new efl_ui_text_context_menu_disabled_get_delegate(context_menu_disabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_context_menu_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_disabled_get_static_delegate)});
      if (efl_ui_text_context_menu_disabled_set_static_delegate == null)
      efl_ui_text_context_menu_disabled_set_static_delegate = new efl_ui_text_context_menu_disabled_set_delegate(context_menu_disabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_context_menu_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_disabled_set_static_delegate)});
      if (efl_ui_text_cnp_mode_get_static_delegate == null)
      efl_ui_text_cnp_mode_get_static_delegate = new efl_ui_text_cnp_mode_get_delegate(cnp_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_cnp_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cnp_mode_get_static_delegate)});
      if (efl_ui_text_cnp_mode_set_static_delegate == null)
      efl_ui_text_cnp_mode_set_static_delegate = new efl_ui_text_cnp_mode_set_delegate(cnp_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_cnp_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cnp_mode_set_static_delegate)});
      if (efl_ui_text_input_panel_language_get_static_delegate == null)
      efl_ui_text_input_panel_language_get_static_delegate = new efl_ui_text_input_panel_language_get_delegate(input_panel_language_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_language_get_static_delegate)});
      if (efl_ui_text_input_panel_language_set_static_delegate == null)
      efl_ui_text_input_panel_language_set_static_delegate = new efl_ui_text_input_panel_language_set_delegate(input_panel_language_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_language_set_static_delegate)});
      if (efl_ui_text_selection_handler_disabled_get_static_delegate == null)
      efl_ui_text_selection_handler_disabled_get_static_delegate = new efl_ui_text_selection_handler_disabled_get_delegate(selection_handler_disabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_selection_handler_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_handler_disabled_get_static_delegate)});
      if (efl_ui_text_selection_handler_disabled_set_static_delegate == null)
      efl_ui_text_selection_handler_disabled_set_static_delegate = new efl_ui_text_selection_handler_disabled_set_delegate(selection_handler_disabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_selection_handler_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_handler_disabled_set_static_delegate)});
      if (efl_ui_text_input_panel_layout_variation_get_static_delegate == null)
      efl_ui_text_input_panel_layout_variation_get_static_delegate = new efl_ui_text_input_panel_layout_variation_get_delegate(input_panel_layout_variation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_layout_variation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_variation_get_static_delegate)});
      if (efl_ui_text_input_panel_layout_variation_set_static_delegate == null)
      efl_ui_text_input_panel_layout_variation_set_static_delegate = new efl_ui_text_input_panel_layout_variation_set_delegate(input_panel_layout_variation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_layout_variation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_variation_set_static_delegate)});
      if (efl_ui_text_autocapital_type_get_static_delegate == null)
      efl_ui_text_autocapital_type_get_static_delegate = new efl_ui_text_autocapital_type_get_delegate(autocapital_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_autocapital_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_autocapital_type_get_static_delegate)});
      if (efl_ui_text_autocapital_type_set_static_delegate == null)
      efl_ui_text_autocapital_type_set_static_delegate = new efl_ui_text_autocapital_type_set_delegate(autocapital_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_autocapital_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_autocapital_type_set_static_delegate)});
      if (efl_ui_text_password_mode_get_static_delegate == null)
      efl_ui_text_password_mode_get_static_delegate = new efl_ui_text_password_mode_get_delegate(password_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_password_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_password_mode_get_static_delegate)});
      if (efl_ui_text_password_mode_set_static_delegate == null)
      efl_ui_text_password_mode_set_static_delegate = new efl_ui_text_password_mode_set_delegate(password_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_password_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_password_mode_set_static_delegate)});
      if (efl_ui_text_input_panel_return_key_disabled_get_static_delegate == null)
      efl_ui_text_input_panel_return_key_disabled_get_static_delegate = new efl_ui_text_input_panel_return_key_disabled_get_delegate(input_panel_return_key_disabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_return_key_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_disabled_get_static_delegate)});
      if (efl_ui_text_input_panel_return_key_disabled_set_static_delegate == null)
      efl_ui_text_input_panel_return_key_disabled_set_static_delegate = new efl_ui_text_input_panel_return_key_disabled_set_delegate(input_panel_return_key_disabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_return_key_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_disabled_set_static_delegate)});
      if (efl_ui_text_prediction_allow_get_static_delegate == null)
      efl_ui_text_prediction_allow_get_static_delegate = new efl_ui_text_prediction_allow_get_delegate(prediction_allow_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_prediction_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_prediction_allow_get_static_delegate)});
      if (efl_ui_text_prediction_allow_set_static_delegate == null)
      efl_ui_text_prediction_allow_set_static_delegate = new efl_ui_text_prediction_allow_set_delegate(prediction_allow_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_prediction_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_prediction_allow_set_static_delegate)});
      if (efl_ui_text_input_hint_get_static_delegate == null)
      efl_ui_text_input_hint_get_static_delegate = new efl_ui_text_input_hint_get_delegate(input_hint_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_hint_get_static_delegate)});
      if (efl_ui_text_input_hint_set_static_delegate == null)
      efl_ui_text_input_hint_set_static_delegate = new efl_ui_text_input_hint_set_delegate(input_hint_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_hint_set_static_delegate)});
      if (efl_ui_text_input_panel_layout_get_static_delegate == null)
      efl_ui_text_input_panel_layout_get_static_delegate = new efl_ui_text_input_panel_layout_get_delegate(input_panel_layout_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_layout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_get_static_delegate)});
      if (efl_ui_text_input_panel_layout_set_static_delegate == null)
      efl_ui_text_input_panel_layout_set_static_delegate = new efl_ui_text_input_panel_layout_set_delegate(input_panel_layout_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_layout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_set_static_delegate)});
      if (efl_ui_text_input_panel_return_key_type_get_static_delegate == null)
      efl_ui_text_input_panel_return_key_type_get_static_delegate = new efl_ui_text_input_panel_return_key_type_get_delegate(input_panel_return_key_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_return_key_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_type_get_static_delegate)});
      if (efl_ui_text_input_panel_return_key_type_set_static_delegate == null)
      efl_ui_text_input_panel_return_key_type_set_static_delegate = new efl_ui_text_input_panel_return_key_type_set_delegate(input_panel_return_key_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_return_key_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_type_set_static_delegate)});
      if (efl_ui_text_input_panel_enabled_get_static_delegate == null)
      efl_ui_text_input_panel_enabled_get_static_delegate = new efl_ui_text_input_panel_enabled_get_delegate(input_panel_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_enabled_get_static_delegate)});
      if (efl_ui_text_input_panel_enabled_set_static_delegate == null)
      efl_ui_text_input_panel_enabled_set_static_delegate = new efl_ui_text_input_panel_enabled_set_delegate(input_panel_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_enabled_set_static_delegate)});
      if (efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate == null)
      efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate = new efl_ui_text_input_panel_return_key_autoenabled_set_delegate(input_panel_return_key_autoenabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_return_key_autoenabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate)});
      if (efl_ui_text_item_factory_get_static_delegate == null)
      efl_ui_text_item_factory_get_static_delegate = new efl_ui_text_item_factory_get_delegate(item_factory_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_item_factory_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_item_factory_get_static_delegate)});
      if (efl_ui_text_item_factory_set_static_delegate == null)
      efl_ui_text_item_factory_set_static_delegate = new efl_ui_text_item_factory_set_delegate(item_factory_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_item_factory_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_item_factory_set_static_delegate)});
      if (efl_ui_text_input_panel_show_static_delegate == null)
      efl_ui_text_input_panel_show_static_delegate = new efl_ui_text_input_panel_show_delegate(input_panel_show);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_show"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_static_delegate)});
      if (efl_ui_text_selection_copy_static_delegate == null)
      efl_ui_text_selection_copy_static_delegate = new efl_ui_text_selection_copy_delegate(selection_copy);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_selection_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_copy_static_delegate)});
      if (efl_ui_text_context_menu_clear_static_delegate == null)
      efl_ui_text_context_menu_clear_static_delegate = new efl_ui_text_context_menu_clear_delegate(context_menu_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_context_menu_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_clear_static_delegate)});
      if (efl_ui_text_input_panel_imdata_set_static_delegate == null)
      efl_ui_text_input_panel_imdata_set_static_delegate = new efl_ui_text_input_panel_imdata_set_delegate(input_panel_imdata_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_imdata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_imdata_set_static_delegate)});
      if (efl_ui_text_input_panel_imdata_get_static_delegate == null)
      efl_ui_text_input_panel_imdata_get_static_delegate = new efl_ui_text_input_panel_imdata_get_delegate(input_panel_imdata_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_imdata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_imdata_get_static_delegate)});
      if (efl_ui_text_selection_paste_static_delegate == null)
      efl_ui_text_selection_paste_static_delegate = new efl_ui_text_selection_paste_delegate(selection_paste);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_selection_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_paste_static_delegate)});
      if (efl_ui_text_input_panel_hide_static_delegate == null)
      efl_ui_text_input_panel_hide_static_delegate = new efl_ui_text_input_panel_hide_delegate(input_panel_hide);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_input_panel_hide"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_hide_static_delegate)});
      if (efl_ui_text_cursor_selection_end_static_delegate == null)
      efl_ui_text_cursor_selection_end_static_delegate = new efl_ui_text_cursor_selection_end_delegate(cursor_selection_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_cursor_selection_end"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cursor_selection_end_static_delegate)});
      if (efl_ui_text_selection_cut_static_delegate == null)
      efl_ui_text_selection_cut_static_delegate = new efl_ui_text_selection_cut_delegate(selection_cut);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_selection_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_cut_static_delegate)});
      if (efl_ui_text_context_menu_item_add_static_delegate == null)
      efl_ui_text_context_menu_item_add_static_delegate = new efl_ui_text_context_menu_item_add_delegate(context_menu_item_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_context_menu_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_item_add_static_delegate)});
      if (efl_ui_text_cursor_new_static_delegate == null)
      efl_ui_text_cursor_new_static_delegate = new efl_ui_text_cursor_new_delegate(cursor_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cursor_new_static_delegate)});
      if (efl_file_mmap_get_static_delegate == null)
      efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate)});
      if (efl_file_mmap_set_static_delegate == null)
      efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate)});
      if (efl_file_get_static_delegate == null)
      efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate)});
      if (efl_file_set_static_delegate == null)
      efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate)});
      if (efl_file_key_get_static_delegate == null)
      efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate)});
      if (efl_file_key_set_static_delegate == null)
      efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate)});
      if (efl_file_loaded_get_static_delegate == null)
      efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate)});
      if (efl_file_load_static_delegate == null)
      efl_file_load_static_delegate = new efl_file_load_delegate(load);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate)});
      if (efl_file_unload_static_delegate == null)
      efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate)});
      if (efl_text_get_static_delegate == null)
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      if (efl_text_set_static_delegate == null)
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      if (efl_text_font_get_static_delegate == null)
      efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate)});
      if (efl_text_font_set_static_delegate == null)
      efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate)});
      if (efl_text_font_source_get_static_delegate == null)
      efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate)});
      if (efl_text_font_source_set_static_delegate == null)
      efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate)});
      if (efl_text_font_fallbacks_get_static_delegate == null)
      efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate)});
      if (efl_text_font_fallbacks_set_static_delegate == null)
      efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate)});
      if (efl_text_font_weight_get_static_delegate == null)
      efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate)});
      if (efl_text_font_weight_set_static_delegate == null)
      efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate)});
      if (efl_text_font_slant_get_static_delegate == null)
      efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate)});
      if (efl_text_font_slant_set_static_delegate == null)
      efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate)});
      if (efl_text_font_width_get_static_delegate == null)
      efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate)});
      if (efl_text_font_width_set_static_delegate == null)
      efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate)});
      if (efl_text_font_lang_get_static_delegate == null)
      efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate)});
      if (efl_text_font_lang_set_static_delegate == null)
      efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate)});
      if (efl_text_font_bitmap_scalable_get_static_delegate == null)
      efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate)});
      if (efl_text_font_bitmap_scalable_set_static_delegate == null)
      efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate)});
      if (efl_text_ellipsis_get_static_delegate == null)
      efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate)});
      if (efl_text_ellipsis_set_static_delegate == null)
      efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate)});
      if (efl_text_wrap_get_static_delegate == null)
      efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate)});
      if (efl_text_wrap_set_static_delegate == null)
      efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate)});
      if (efl_text_multiline_get_static_delegate == null)
      efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate)});
      if (efl_text_multiline_set_static_delegate == null)
      efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate)});
      if (efl_text_halign_auto_type_get_static_delegate == null)
      efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate)});
      if (efl_text_halign_auto_type_set_static_delegate == null)
      efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate)});
      if (efl_text_halign_get_static_delegate == null)
      efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate)});
      if (efl_text_halign_set_static_delegate == null)
      efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate)});
      if (efl_text_valign_get_static_delegate == null)
      efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate)});
      if (efl_text_valign_set_static_delegate == null)
      efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate)});
      if (efl_text_linegap_get_static_delegate == null)
      efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate)});
      if (efl_text_linegap_set_static_delegate == null)
      efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate)});
      if (efl_text_linerelgap_get_static_delegate == null)
      efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate)});
      if (efl_text_linerelgap_set_static_delegate == null)
      efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate)});
      if (efl_text_tabstops_get_static_delegate == null)
      efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate)});
      if (efl_text_tabstops_set_static_delegate == null)
      efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate)});
      if (efl_text_password_get_static_delegate == null)
      efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate)});
      if (efl_text_password_set_static_delegate == null)
      efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate)});
      if (efl_text_replacement_char_get_static_delegate == null)
      efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate)});
      if (efl_text_replacement_char_set_static_delegate == null)
      efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate)});
      if (efl_text_interactive_selection_allowed_get_static_delegate == null)
      efl_text_interactive_selection_allowed_get_static_delegate = new efl_text_interactive_selection_allowed_get_delegate(selection_allowed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_allowed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_get_static_delegate)});
      if (efl_text_interactive_selection_allowed_set_static_delegate == null)
      efl_text_interactive_selection_allowed_set_static_delegate = new efl_text_interactive_selection_allowed_set_delegate(selection_allowed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_allowed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_set_static_delegate)});
      if (efl_text_interactive_selection_cursors_get_static_delegate == null)
      efl_text_interactive_selection_cursors_get_static_delegate = new efl_text_interactive_selection_cursors_get_delegate(selection_cursors_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_selection_cursors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_get_static_delegate)});
      if (efl_text_interactive_editable_get_static_delegate == null)
      efl_text_interactive_editable_get_static_delegate = new efl_text_interactive_editable_get_delegate(editable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_get_static_delegate)});
      if (efl_text_interactive_editable_set_static_delegate == null)
      efl_text_interactive_editable_set_static_delegate = new efl_text_interactive_editable_set_delegate(editable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_set_static_delegate)});
      if (efl_text_interactive_select_none_static_delegate == null)
      efl_text_interactive_select_none_static_delegate = new efl_text_interactive_select_none_delegate(select_none);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_interactive_select_none"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_select_none_static_delegate)});
      if (efl_text_normal_color_get_static_delegate == null)
      efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate)});
      if (efl_text_normal_color_set_static_delegate == null)
      efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate)});
      if (efl_text_backing_type_get_static_delegate == null)
      efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate)});
      if (efl_text_backing_type_set_static_delegate == null)
      efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate)});
      if (efl_text_backing_color_get_static_delegate == null)
      efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate)});
      if (efl_text_backing_color_set_static_delegate == null)
      efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate)});
      if (efl_text_underline_type_get_static_delegate == null)
      efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate)});
      if (efl_text_underline_type_set_static_delegate == null)
      efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate)});
      if (efl_text_underline_color_get_static_delegate == null)
      efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate)});
      if (efl_text_underline_color_set_static_delegate == null)
      efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate)});
      if (efl_text_underline_height_get_static_delegate == null)
      efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate)});
      if (efl_text_underline_height_set_static_delegate == null)
      efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate)});
      if (efl_text_underline_dashed_color_get_static_delegate == null)
      efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate)});
      if (efl_text_underline_dashed_color_set_static_delegate == null)
      efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate)});
      if (efl_text_underline_dashed_width_get_static_delegate == null)
      efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate)});
      if (efl_text_underline_dashed_width_set_static_delegate == null)
      efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate)});
      if (efl_text_underline_dashed_gap_get_static_delegate == null)
      efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate)});
      if (efl_text_underline_dashed_gap_set_static_delegate == null)
      efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate)});
      if (efl_text_underline2_color_get_static_delegate == null)
      efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate)});
      if (efl_text_underline2_color_set_static_delegate == null)
      efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate)});
      if (efl_text_strikethrough_type_get_static_delegate == null)
      efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate)});
      if (efl_text_strikethrough_type_set_static_delegate == null)
      efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate)});
      if (efl_text_strikethrough_color_get_static_delegate == null)
      efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate)});
      if (efl_text_strikethrough_color_set_static_delegate == null)
      efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate)});
      if (efl_text_effect_type_get_static_delegate == null)
      efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate)});
      if (efl_text_effect_type_set_static_delegate == null)
      efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate)});
      if (efl_text_outline_color_get_static_delegate == null)
      efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate)});
      if (efl_text_outline_color_set_static_delegate == null)
      efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate)});
      if (efl_text_shadow_direction_get_static_delegate == null)
      efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate)});
      if (efl_text_shadow_direction_set_static_delegate == null)
      efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate)});
      if (efl_text_shadow_color_get_static_delegate == null)
      efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate)});
      if (efl_text_shadow_color_set_static_delegate == null)
      efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate)});
      if (efl_text_glow_color_get_static_delegate == null)
      efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate)});
      if (efl_text_glow_color_set_static_delegate == null)
      efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate)});
      if (efl_text_glow2_color_get_static_delegate == null)
      efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate)});
      if (efl_text_glow2_color_set_static_delegate == null)
      efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate)});
      if (efl_text_gfx_filter_get_static_delegate == null)
      efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate)});
      if (efl_text_gfx_filter_set_static_delegate == null)
      efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate)});
      if (efl_access_text_character_get_static_delegate == null)
      efl_access_text_character_get_static_delegate = new efl_access_text_character_get_delegate(character_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_get_static_delegate)});
      if (efl_access_text_string_get_static_delegate == null)
      efl_access_text_string_get_static_delegate = new efl_access_text_string_get_delegate(string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_string_get_static_delegate)});
      if (efl_access_text_get_static_delegate == null)
      efl_access_text_get_static_delegate = new efl_access_text_get_delegate(access_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_get_static_delegate)});
      if (efl_access_text_caret_offset_get_static_delegate == null)
      efl_access_text_caret_offset_get_static_delegate = new efl_access_text_caret_offset_get_delegate(caret_offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_caret_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_get_static_delegate)});
      if (efl_access_text_caret_offset_set_static_delegate == null)
      efl_access_text_caret_offset_set_static_delegate = new efl_access_text_caret_offset_set_delegate(caret_offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_caret_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_set_static_delegate)});
      if (efl_access_text_attribute_get_static_delegate == null)
      efl_access_text_attribute_get_static_delegate = new efl_access_text_attribute_get_delegate(attribute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_attribute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attribute_get_static_delegate)});
      if (efl_access_text_attributes_get_static_delegate == null)
      efl_access_text_attributes_get_static_delegate = new efl_access_text_attributes_get_delegate(text_attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attributes_get_static_delegate)});
      if (efl_access_text_default_attributes_get_static_delegate == null)
      efl_access_text_default_attributes_get_static_delegate = new efl_access_text_default_attributes_get_delegate(default_attributes_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_default_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_default_attributes_get_static_delegate)});
      if (efl_access_text_character_extents_get_static_delegate == null)
      efl_access_text_character_extents_get_static_delegate = new efl_access_text_character_extents_get_delegate(character_extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_extents_get_static_delegate)});
      if (efl_access_text_character_count_get_static_delegate == null)
      efl_access_text_character_count_get_static_delegate = new efl_access_text_character_count_get_delegate(character_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_character_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_count_get_static_delegate)});
      if (efl_access_text_offset_at_point_get_static_delegate == null)
      efl_access_text_offset_at_point_get_static_delegate = new efl_access_text_offset_at_point_get_delegate(offset_at_point_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_offset_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_offset_at_point_get_static_delegate)});
      if (efl_access_text_bounded_ranges_get_static_delegate == null)
      efl_access_text_bounded_ranges_get_static_delegate = new efl_access_text_bounded_ranges_get_delegate(bounded_ranges_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_bounded_ranges_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_bounded_ranges_get_static_delegate)});
      if (efl_access_text_range_extents_get_static_delegate == null)
      efl_access_text_range_extents_get_static_delegate = new efl_access_text_range_extents_get_delegate(range_extents_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_range_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_range_extents_get_static_delegate)});
      if (efl_access_text_selections_count_get_static_delegate == null)
      efl_access_text_selections_count_get_static_delegate = new efl_access_text_selections_count_get_delegate(selections_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selections_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selections_count_get_static_delegate)});
      if (efl_access_text_access_selection_get_static_delegate == null)
      efl_access_text_access_selection_get_static_delegate = new efl_access_text_access_selection_get_delegate(access_selection_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_access_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_get_static_delegate)});
      if (efl_access_text_access_selection_set_static_delegate == null)
      efl_access_text_access_selection_set_static_delegate = new efl_access_text_access_selection_set_delegate(access_selection_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_access_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_set_static_delegate)});
      if (efl_access_text_selection_add_static_delegate == null)
      efl_access_text_selection_add_static_delegate = new efl_access_text_selection_add_delegate(selection_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selection_add"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_add_static_delegate)});
      if (efl_access_text_selection_remove_static_delegate == null)
      efl_access_text_selection_remove_static_delegate = new efl_access_text_selection_remove_delegate(selection_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_text_selection_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_remove_static_delegate)});
      if (efl_access_editable_text_content_set_static_delegate == null)
      efl_access_editable_text_content_set_static_delegate = new efl_access_editable_text_content_set_delegate(text_content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_content_set_static_delegate)});
      if (efl_access_editable_text_insert_static_delegate == null)
      efl_access_editable_text_insert_static_delegate = new efl_access_editable_text_insert_delegate(insert);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_insert_static_delegate)});
      if (efl_access_editable_text_copy_static_delegate == null)
      efl_access_editable_text_copy_static_delegate = new efl_access_editable_text_copy_delegate(copy);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_copy_static_delegate)});
      if (efl_access_editable_text_cut_static_delegate == null)
      efl_access_editable_text_cut_static_delegate = new efl_access_editable_text_cut_delegate(cut);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_cut_static_delegate)});
      if (efl_access_editable_text_delete_static_delegate == null)
      efl_access_editable_text_delete_static_delegate = new efl_access_editable_text_delete_delegate(kw_delete);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_delete_static_delegate)});
      if (efl_access_editable_text_paste_static_delegate == null)
      efl_access_editable_text_paste_static_delegate = new efl_access_editable_text_paste_delegate(paste);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_access_editable_text_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_paste_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Text.efl_ui_text_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Text.efl_ui_text_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_scrollable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_scrollable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_get_api_delegate> efl_ui_text_scrollable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_get_api_delegate>(_Module, "efl_ui_text_scrollable_get");
    private static bool scrollable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_scrollable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetScrollable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_scrollable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_scrollable_get_delegate efl_ui_text_scrollable_get_static_delegate;


    private delegate  void efl_ui_text_scrollable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool scroll);


    public delegate  void efl_ui_text_scrollable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool scroll);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_set_api_delegate> efl_ui_text_scrollable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_set_api_delegate>(_Module, "efl_ui_text_scrollable_set");
    private static  void scrollable_set(System.IntPtr obj, System.IntPtr pd,  bool scroll)
   {
      Eina.Log.Debug("function efl_ui_text_scrollable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetScrollable( scroll);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_scrollable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scroll);
      }
   }
   private static efl_ui_text_scrollable_set_delegate efl_ui_text_scrollable_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_input_panel_show_on_demand_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_input_panel_show_on_demand_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_get_api_delegate> efl_ui_text_input_panel_show_on_demand_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_get_api_delegate>(_Module, "efl_ui_text_input_panel_show_on_demand_get");
    private static bool input_panel_show_on_demand_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_show_on_demand_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelShowOnDemand();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_show_on_demand_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_show_on_demand_get_delegate efl_ui_text_input_panel_show_on_demand_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_show_on_demand_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool ondemand);


    public delegate  void efl_ui_text_input_panel_show_on_demand_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool ondemand);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_set_api_delegate> efl_ui_text_input_panel_show_on_demand_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_set_api_delegate>(_Module, "efl_ui_text_input_panel_show_on_demand_set");
    private static  void input_panel_show_on_demand_set(System.IntPtr obj, System.IntPtr pd,  bool ondemand)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_show_on_demand_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelShowOnDemand( ondemand);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_show_on_demand_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ondemand);
      }
   }
   private static efl_ui_text_input_panel_show_on_demand_set_delegate efl_ui_text_input_panel_show_on_demand_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_context_menu_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_context_menu_disabled_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_get_api_delegate> efl_ui_text_context_menu_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_get_api_delegate>(_Module, "efl_ui_text_context_menu_disabled_get");
    private static bool context_menu_disabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_context_menu_disabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetContextMenuDisabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_context_menu_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_context_menu_disabled_get_delegate efl_ui_text_context_menu_disabled_get_static_delegate;


    private delegate  void efl_ui_text_context_menu_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disabled);


    public delegate  void efl_ui_text_context_menu_disabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_set_api_delegate> efl_ui_text_context_menu_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_set_api_delegate>(_Module, "efl_ui_text_context_menu_disabled_set");
    private static  void context_menu_disabled_set(System.IntPtr obj, System.IntPtr pd,  bool disabled)
   {
      Eina.Log.Debug("function efl_ui_text_context_menu_disabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetContextMenuDisabled( disabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_context_menu_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disabled);
      }
   }
   private static efl_ui_text_context_menu_disabled_set_delegate efl_ui_text_context_menu_disabled_set_static_delegate;


    private delegate Efl.Ui.SelectionFormat efl_ui_text_cnp_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.SelectionFormat efl_ui_text_cnp_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_get_api_delegate> efl_ui_text_cnp_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_get_api_delegate>(_Module, "efl_ui_text_cnp_mode_get");
    private static Efl.Ui.SelectionFormat cnp_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_cnp_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.SelectionFormat _ret_var = default(Efl.Ui.SelectionFormat);
         try {
            _ret_var = ((Text)wrapper).GetCnpMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_cnp_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_cnp_mode_get_delegate efl_ui_text_cnp_mode_get_static_delegate;


    private delegate  void efl_ui_text_cnp_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format);


    public delegate  void efl_ui_text_cnp_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionFormat format);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_set_api_delegate> efl_ui_text_cnp_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_set_api_delegate>(_Module, "efl_ui_text_cnp_mode_set");
    private static  void cnp_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format)
   {
      Eina.Log.Debug("function efl_ui_text_cnp_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetCnpMode( format);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_cnp_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format);
      }
   }
   private static efl_ui_text_cnp_mode_set_delegate efl_ui_text_cnp_mode_set_static_delegate;


    private delegate Elm.Input.Panel.Lang efl_ui_text_input_panel_language_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Elm.Input.Panel.Lang efl_ui_text_input_panel_language_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_get_api_delegate> efl_ui_text_input_panel_language_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_get_api_delegate>(_Module, "efl_ui_text_input_panel_language_get");
    private static Elm.Input.Panel.Lang input_panel_language_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_language_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Input.Panel.Lang _ret_var = default(Elm.Input.Panel.Lang);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelLanguage();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_language_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_language_get_delegate efl_ui_text_input_panel_language_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_language_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Input.Panel.Lang lang);


    public delegate  void efl_ui_text_input_panel_language_set_api_delegate(System.IntPtr obj,   Elm.Input.Panel.Lang lang);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_set_api_delegate> efl_ui_text_input_panel_language_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_set_api_delegate>(_Module, "efl_ui_text_input_panel_language_set");
    private static  void input_panel_language_set(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.Lang lang)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_language_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelLanguage( lang);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_language_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lang);
      }
   }
   private static efl_ui_text_input_panel_language_set_delegate efl_ui_text_input_panel_language_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_selection_handler_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_selection_handler_disabled_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_get_api_delegate> efl_ui_text_selection_handler_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_get_api_delegate>(_Module, "efl_ui_text_selection_handler_disabled_get");
    private static bool selection_handler_disabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_selection_handler_disabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetSelectionHandlerDisabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_selection_handler_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_selection_handler_disabled_get_delegate efl_ui_text_selection_handler_disabled_get_static_delegate;


    private delegate  void efl_ui_text_selection_handler_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disabled);


    public delegate  void efl_ui_text_selection_handler_disabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_set_api_delegate> efl_ui_text_selection_handler_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_set_api_delegate>(_Module, "efl_ui_text_selection_handler_disabled_set");
    private static  void selection_handler_disabled_set(System.IntPtr obj, System.IntPtr pd,  bool disabled)
   {
      Eina.Log.Debug("function efl_ui_text_selection_handler_disabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetSelectionHandlerDisabled( disabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_selection_handler_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disabled);
      }
   }
   private static efl_ui_text_selection_handler_disabled_set_delegate efl_ui_text_selection_handler_disabled_set_static_delegate;


    private delegate  int efl_ui_text_input_panel_layout_variation_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_ui_text_input_panel_layout_variation_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_get_api_delegate> efl_ui_text_input_panel_layout_variation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_get_api_delegate>(_Module, "efl_ui_text_input_panel_layout_variation_get");
    private static  int input_panel_layout_variation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_layout_variation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelLayoutVariation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_layout_variation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_layout_variation_get_delegate efl_ui_text_input_panel_layout_variation_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_layout_variation_set_delegate(System.IntPtr obj, System.IntPtr pd,    int variation);


    public delegate  void efl_ui_text_input_panel_layout_variation_set_api_delegate(System.IntPtr obj,    int variation);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_set_api_delegate> efl_ui_text_input_panel_layout_variation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_set_api_delegate>(_Module, "efl_ui_text_input_panel_layout_variation_set");
    private static  void input_panel_layout_variation_set(System.IntPtr obj, System.IntPtr pd,   int variation)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_layout_variation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelLayoutVariation( variation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_layout_variation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  variation);
      }
   }
   private static efl_ui_text_input_panel_layout_variation_set_delegate efl_ui_text_input_panel_layout_variation_set_static_delegate;


    private delegate Elm.Autocapital.Type efl_ui_text_autocapital_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Elm.Autocapital.Type efl_ui_text_autocapital_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_get_api_delegate> efl_ui_text_autocapital_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_get_api_delegate>(_Module, "efl_ui_text_autocapital_type_get");
    private static Elm.Autocapital.Type autocapital_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_autocapital_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Autocapital.Type _ret_var = default(Elm.Autocapital.Type);
         try {
            _ret_var = ((Text)wrapper).GetAutocapitalType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_autocapital_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_autocapital_type_get_delegate efl_ui_text_autocapital_type_get_static_delegate;


    private delegate  void efl_ui_text_autocapital_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Autocapital.Type autocapital_type);


    public delegate  void efl_ui_text_autocapital_type_set_api_delegate(System.IntPtr obj,   Elm.Autocapital.Type autocapital_type);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_set_api_delegate> efl_ui_text_autocapital_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_set_api_delegate>(_Module, "efl_ui_text_autocapital_type_set");
    private static  void autocapital_type_set(System.IntPtr obj, System.IntPtr pd,  Elm.Autocapital.Type autocapital_type)
   {
      Eina.Log.Debug("function efl_ui_text_autocapital_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetAutocapitalType( autocapital_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_autocapital_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  autocapital_type);
      }
   }
   private static efl_ui_text_autocapital_type_set_delegate efl_ui_text_autocapital_type_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_password_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_password_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_get_api_delegate> efl_ui_text_password_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_get_api_delegate>(_Module, "efl_ui_text_password_mode_get");
    private static bool password_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_password_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetPasswordMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_password_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_password_mode_get_delegate efl_ui_text_password_mode_get_static_delegate;


    private delegate  void efl_ui_text_password_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool password);


    public delegate  void efl_ui_text_password_mode_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool password);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_set_api_delegate> efl_ui_text_password_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_set_api_delegate>(_Module, "efl_ui_text_password_mode_set");
    private static  void password_mode_set(System.IntPtr obj, System.IntPtr pd,  bool password)
   {
      Eina.Log.Debug("function efl_ui_text_password_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetPasswordMode( password);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_password_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  password);
      }
   }
   private static efl_ui_text_password_mode_set_delegate efl_ui_text_password_mode_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_input_panel_return_key_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_input_panel_return_key_disabled_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_get_api_delegate> efl_ui_text_input_panel_return_key_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_get_api_delegate>(_Module, "efl_ui_text_input_panel_return_key_disabled_get");
    private static bool input_panel_return_key_disabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_return_key_disabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelReturnKeyDisabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_return_key_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_return_key_disabled_get_delegate efl_ui_text_input_panel_return_key_disabled_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_return_key_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool disabled);


    public delegate  void efl_ui_text_input_panel_return_key_disabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool disabled);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_set_api_delegate> efl_ui_text_input_panel_return_key_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_set_api_delegate>(_Module, "efl_ui_text_input_panel_return_key_disabled_set");
    private static  void input_panel_return_key_disabled_set(System.IntPtr obj, System.IntPtr pd,  bool disabled)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_return_key_disabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelReturnKeyDisabled( disabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_return_key_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  disabled);
      }
   }
   private static efl_ui_text_input_panel_return_key_disabled_set_delegate efl_ui_text_input_panel_return_key_disabled_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_prediction_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_prediction_allow_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_get_api_delegate> efl_ui_text_prediction_allow_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_get_api_delegate>(_Module, "efl_ui_text_prediction_allow_get");
    private static bool prediction_allow_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_prediction_allow_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetPredictionAllow();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_prediction_allow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_prediction_allow_get_delegate efl_ui_text_prediction_allow_get_static_delegate;


    private delegate  void efl_ui_text_prediction_allow_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool prediction);


    public delegate  void efl_ui_text_prediction_allow_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool prediction);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_set_api_delegate> efl_ui_text_prediction_allow_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_set_api_delegate>(_Module, "efl_ui_text_prediction_allow_set");
    private static  void prediction_allow_set(System.IntPtr obj, System.IntPtr pd,  bool prediction)
   {
      Eina.Log.Debug("function efl_ui_text_prediction_allow_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetPredictionAllow( prediction);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_prediction_allow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  prediction);
      }
   }
   private static efl_ui_text_prediction_allow_set_delegate efl_ui_text_prediction_allow_set_static_delegate;


    private delegate Elm.Input.Hints efl_ui_text_input_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Elm.Input.Hints efl_ui_text_input_hint_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_get_api_delegate> efl_ui_text_input_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_get_api_delegate>(_Module, "efl_ui_text_input_hint_get");
    private static Elm.Input.Hints input_hint_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_hint_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Input.Hints _ret_var = default(Elm.Input.Hints);
         try {
            _ret_var = ((Text)wrapper).GetInputHint();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_hint_get_delegate efl_ui_text_input_hint_get_static_delegate;


    private delegate  void efl_ui_text_input_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Input.Hints hints);


    public delegate  void efl_ui_text_input_hint_set_api_delegate(System.IntPtr obj,   Elm.Input.Hints hints);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_set_api_delegate> efl_ui_text_input_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_set_api_delegate>(_Module, "efl_ui_text_input_hint_set");
    private static  void input_hint_set(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Hints hints)
   {
      Eina.Log.Debug("function efl_ui_text_input_hint_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputHint( hints);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hints);
      }
   }
   private static efl_ui_text_input_hint_set_delegate efl_ui_text_input_hint_set_static_delegate;


    private delegate Elm.Input.Panel.Layout efl_ui_text_input_panel_layout_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Elm.Input.Panel.Layout efl_ui_text_input_panel_layout_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_get_api_delegate> efl_ui_text_input_panel_layout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_get_api_delegate>(_Module, "efl_ui_text_input_panel_layout_get");
    private static Elm.Input.Panel.Layout input_panel_layout_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_layout_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Input.Panel.Layout _ret_var = default(Elm.Input.Panel.Layout);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelLayout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_layout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_layout_get_delegate efl_ui_text_input_panel_layout_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_layout_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Input.Panel.Layout layout);


    public delegate  void efl_ui_text_input_panel_layout_set_api_delegate(System.IntPtr obj,   Elm.Input.Panel.Layout layout);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_set_api_delegate> efl_ui_text_input_panel_layout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_set_api_delegate>(_Module, "efl_ui_text_input_panel_layout_set");
    private static  void input_panel_layout_set(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.Layout layout)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_layout_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelLayout( layout);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_layout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  layout);
      }
   }
   private static efl_ui_text_input_panel_layout_set_delegate efl_ui_text_input_panel_layout_set_static_delegate;


    private delegate Elm.Input.Panel.ReturnKey.Type efl_ui_text_input_panel_return_key_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Elm.Input.Panel.ReturnKey.Type efl_ui_text_input_panel_return_key_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_get_api_delegate> efl_ui_text_input_panel_return_key_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_get_api_delegate>(_Module, "efl_ui_text_input_panel_return_key_type_get");
    private static Elm.Input.Panel.ReturnKey.Type input_panel_return_key_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_return_key_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Input.Panel.ReturnKey.Type _ret_var = default(Elm.Input.Panel.ReturnKey.Type);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelReturnKeyType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_return_key_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_return_key_type_get_delegate efl_ui_text_input_panel_return_key_type_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_return_key_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Input.Panel.ReturnKey.Type return_key_type);


    public delegate  void efl_ui_text_input_panel_return_key_type_set_api_delegate(System.IntPtr obj,   Elm.Input.Panel.ReturnKey.Type return_key_type);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_set_api_delegate> efl_ui_text_input_panel_return_key_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_set_api_delegate>(_Module, "efl_ui_text_input_panel_return_key_type_set");
    private static  void input_panel_return_key_type_set(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.ReturnKey.Type return_key_type)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_return_key_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelReturnKeyType( return_key_type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_return_key_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  return_key_type);
      }
   }
   private static efl_ui_text_input_panel_return_key_type_set_delegate efl_ui_text_input_panel_return_key_type_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_input_panel_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_text_input_panel_enabled_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_get_api_delegate> efl_ui_text_input_panel_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_get_api_delegate>(_Module, "efl_ui_text_input_panel_enabled_get");
    private static bool input_panel_enabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetInputPanelEnabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_input_panel_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_enabled_get_delegate efl_ui_text_input_panel_enabled_get_static_delegate;


    private delegate  void efl_ui_text_input_panel_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_ui_text_input_panel_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_set_api_delegate> efl_ui_text_input_panel_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_set_api_delegate>(_Module, "efl_ui_text_input_panel_enabled_set");
    private static  void input_panel_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelEnabled( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_ui_text_input_panel_enabled_set_delegate efl_ui_text_input_panel_enabled_set_static_delegate;


    private delegate  void efl_ui_text_input_panel_return_key_autoenabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate> efl_ui_text_input_panel_return_key_autoenabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate>(_Module, "efl_ui_text_input_panel_return_key_autoenabled_set");
    private static  void input_panel_return_key_autoenabled_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_return_key_autoenabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetInputPanelReturnKeyAutoenabled( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_input_panel_return_key_autoenabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_ui_text_input_panel_return_key_autoenabled_set_delegate efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.TextFactoryConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.TextFactory efl_ui_text_item_factory_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.TextFactoryConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.TextFactory efl_ui_text_item_factory_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_get_api_delegate> efl_ui_text_item_factory_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_get_api_delegate>(_Module, "efl_ui_text_item_factory_get");
    private static Efl.Canvas.TextFactory item_factory_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_item_factory_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.TextFactory _ret_var = default(Efl.Canvas.TextFactory);
         try {
            _ret_var = ((Text)wrapper).GetItemFactory();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_item_factory_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_item_factory_get_delegate efl_ui_text_item_factory_get_static_delegate;


    private delegate  void efl_ui_text_item_factory_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.TextFactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Canvas.TextFactory item_factory);


    public delegate  void efl_ui_text_item_factory_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.TextFactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Canvas.TextFactory item_factory);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_set_api_delegate> efl_ui_text_item_factory_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_set_api_delegate>(_Module, "efl_ui_text_item_factory_set");
    private static  void item_factory_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.TextFactory item_factory)
   {
      Eina.Log.Debug("function efl_ui_text_item_factory_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetItemFactory( item_factory);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_text_item_factory_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item_factory);
      }
   }
   private static efl_ui_text_item_factory_set_delegate efl_ui_text_item_factory_set_static_delegate;


    private delegate  void efl_ui_text_input_panel_show_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_input_panel_show_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_api_delegate> efl_ui_text_input_panel_show_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_api_delegate>(_Module, "efl_ui_text_input_panel_show");
    private static  void input_panel_show(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_show was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).ShowInputPanel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_input_panel_show_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_show_delegate efl_ui_text_input_panel_show_static_delegate;


    private delegate  void efl_ui_text_selection_copy_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_selection_copy_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_copy_api_delegate> efl_ui_text_selection_copy_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_copy_api_delegate>(_Module, "efl_ui_text_selection_copy");
    private static  void selection_copy(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_selection_copy was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).SelectionCopy();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_selection_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_selection_copy_delegate efl_ui_text_selection_copy_static_delegate;


    private delegate  void efl_ui_text_context_menu_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_context_menu_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_clear_api_delegate> efl_ui_text_context_menu_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_clear_api_delegate>(_Module, "efl_ui_text_context_menu_clear");
    private static  void context_menu_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_context_menu_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).ClearContextMenu();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_context_menu_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_context_menu_clear_delegate efl_ui_text_context_menu_clear_static_delegate;


    private delegate  void efl_ui_text_input_panel_imdata_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr data,    int len);


    public delegate  void efl_ui_text_input_panel_imdata_set_api_delegate(System.IntPtr obj,    System.IntPtr data,    int len);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_set_api_delegate> efl_ui_text_input_panel_imdata_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_set_api_delegate>(_Module, "efl_ui_text_input_panel_imdata_set");
    private static  void input_panel_imdata_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr data,   int len)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_imdata_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Text)wrapper).SetInputPanelImdata( data,  len);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_text_input_panel_imdata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  data,  len);
      }
   }
   private static efl_ui_text_input_panel_imdata_set_delegate efl_ui_text_input_panel_imdata_set_static_delegate;


    private delegate  void efl_ui_text_input_panel_imdata_get_delegate(System.IntPtr obj, System.IntPtr pd,   ref  System.IntPtr data,   out  int len);


    public delegate  void efl_ui_text_input_panel_imdata_get_api_delegate(System.IntPtr obj,   ref  System.IntPtr data,   out  int len);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_get_api_delegate> efl_ui_text_input_panel_imdata_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_get_api_delegate>(_Module, "efl_ui_text_input_panel_imdata_get");
    private static  void input_panel_imdata_get(System.IntPtr obj, System.IntPtr pd,  ref  System.IntPtr data,  out  int len)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_imdata_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 len = default( int);                     
         try {
            ((Text)wrapper).GetInputPanelImdata( ref data,  out len);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_text_input_panel_imdata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref data,  out len);
      }
   }
   private static efl_ui_text_input_panel_imdata_get_delegate efl_ui_text_input_panel_imdata_get_static_delegate;


    private delegate  void efl_ui_text_selection_paste_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_selection_paste_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_paste_api_delegate> efl_ui_text_selection_paste_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_paste_api_delegate>(_Module, "efl_ui_text_selection_paste");
    private static  void selection_paste(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_selection_paste was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).SelectionPaste();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_selection_paste_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_selection_paste_delegate efl_ui_text_selection_paste_static_delegate;


    private delegate  void efl_ui_text_input_panel_hide_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_input_panel_hide_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_hide_api_delegate> efl_ui_text_input_panel_hide_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_hide_api_delegate>(_Module, "efl_ui_text_input_panel_hide");
    private static  void input_panel_hide(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_input_panel_hide was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).HideInputPanel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_input_panel_hide_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_input_panel_hide_delegate efl_ui_text_input_panel_hide_static_delegate;


    private delegate  void efl_ui_text_cursor_selection_end_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_cursor_selection_end_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_cursor_selection_end_api_delegate> efl_ui_text_cursor_selection_end_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cursor_selection_end_api_delegate>(_Module, "efl_ui_text_cursor_selection_end");
    private static  void cursor_selection_end(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_cursor_selection_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).CursorSelectionEnd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_cursor_selection_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_cursor_selection_end_delegate efl_ui_text_cursor_selection_end_static_delegate;


    private delegate  void efl_ui_text_selection_cut_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_text_selection_cut_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_cut_api_delegate> efl_ui_text_selection_cut_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_cut_api_delegate>(_Module, "efl_ui_text_selection_cut");
    private static  void selection_cut(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_selection_cut was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).SelectionCut();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_text_selection_cut_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_selection_cut_delegate efl_ui_text_selection_cut_static_delegate;


    private delegate  void efl_ui_text_context_menu_item_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String icon_file,   Elm.Icon.Type icon_type,   EvasSmartCb func,    System.IntPtr data);


    public delegate  void efl_ui_text_context_menu_item_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String icon_file,   Elm.Icon.Type icon_type,   EvasSmartCb func,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_item_add_api_delegate> efl_ui_text_context_menu_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_item_add_api_delegate>(_Module, "efl_ui_text_context_menu_item_add");
    private static  void context_menu_item_add(System.IntPtr obj, System.IntPtr pd,   System.String label,   System.String icon_file,  Elm.Icon.Type icon_type,  EvasSmartCb func,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_ui_text_context_menu_item_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Text)wrapper).AddContextMenuItem( label,  icon_file,  icon_type,  func,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_text_context_menu_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  label,  icon_file,  icon_type,  func,  data);
      }
   }
   private static efl_ui_text_context_menu_item_add_delegate efl_ui_text_context_menu_item_add_static_delegate;


    private delegate Efl.TextCursorCursor efl_ui_text_cursor_new_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextCursorCursor efl_ui_text_cursor_new_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_text_cursor_new_api_delegate> efl_ui_text_cursor_new_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cursor_new_api_delegate>(_Module, "efl_ui_text_cursor_new");
    private static Efl.TextCursorCursor cursor_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_text_cursor_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
         try {
            _ret_var = ((Text)wrapper).NewCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_text_cursor_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_text_cursor_new_delegate efl_ui_text_cursor_new_static_delegate;


    private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(_Module, "efl_file_mmap_get");
    private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_mmap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.File _ret_var = default(Eina.File);
         try {
            _ret_var = ((Text)wrapper).GetMmap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;


    private delegate  Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.File f);


    public delegate  Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,   Eina.File f);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(_Module, "efl_file_mmap_set");
    private static  Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd,  Eina.File f)
   {
      Eina.Log.Debug("function efl_file_mmap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Text)wrapper).SetMmap( f);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
      }
   }
   private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(_Module, "efl_file_get");
    private static  System.String file_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetFile();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_get_delegate efl_file_get_static_delegate;


    private delegate  Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);


    public delegate  Eina.Error efl_file_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);
    public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(_Module, "efl_file_set");
    private static  Eina.Error file_set(System.IntPtr obj, System.IntPtr pd,   System.String file)
   {
      Eina.Log.Debug("function efl_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Text)wrapper).SetFile( file);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file);
      }
   }
   private static efl_file_set_delegate efl_file_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_key_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(_Module, "efl_file_key_get");
    private static  System.String key_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_key_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetKey();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_key_get_delegate efl_file_key_get_static_delegate;


    private delegate  void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);


    public delegate  void efl_file_key_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(_Module, "efl_file_key_set");
    private static  void key_set(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_file_key_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetKey( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_file_key_set_delegate efl_file_key_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(_Module, "efl_file_loaded_get");
    private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_loaded_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetLoaded();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;


    private delegate  Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  Eina.Error efl_file_load_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(_Module, "efl_file_load");
    private static  Eina.Error load(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_load was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((Text)wrapper).Load();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_load_delegate efl_file_load_static_delegate;


    private delegate  void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_file_unload_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(_Module, "efl_file_unload");
    private static  void unload(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_unload was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).Unload();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_unload_delegate efl_file_unload_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(_Module, "efl_text_get");
    private static  System.String text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_get_delegate efl_text_get_static_delegate;


    private delegate  void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);


    public delegate  void efl_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(_Module, "efl_text_set");
    private static  void text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function efl_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static efl_text_set_delegate efl_text_set_static_delegate;


    private delegate  void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);


    public delegate  void efl_text_font_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate> efl_text_font_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate>(_Module, "efl_text_font_get");
    private static  void font_get(System.IntPtr obj, System.IntPtr pd,  out  System.String font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                     
         try {
            ((Text)wrapper).GetFont( out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      font = _out_font;
                              } else {
         efl_text_font_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out font,  out size);
      }
   }
   private static efl_text_font_get_delegate efl_text_font_get_static_delegate;


    private delegate  void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);


    public delegate  void efl_text_font_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate> efl_text_font_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate>(_Module, "efl_text_font_set");
    private static  void font_set(System.IntPtr obj, System.IntPtr pd,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Text)wrapper).SetFont( font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_font_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font,  size);
      }
   }
   private static efl_text_font_set_delegate efl_text_font_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate>(_Module, "efl_text_font_source_get");
    private static  System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetFontSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;


    private delegate  void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);


    public delegate  void efl_text_font_source_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate>(_Module, "efl_text_font_source_set");
    private static  void font_source_set(System.IntPtr obj, System.IntPtr pd,   System.String font_source)
   {
      Eina.Log.Debug("function efl_text_font_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontSource( font_source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_source);
      }
   }
   private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(_Module, "efl_text_font_fallbacks_get");
    private static  System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetFontFallbacks();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_fallbacks_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;


    private delegate  void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);


    public delegate  void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(_Module, "efl_text_font_fallbacks_set");
    private static  void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd,   System.String font_fallbacks)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontFallbacks( font_fallbacks);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_fallbacks_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_fallbacks);
      }
   }
   private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;


    private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate>(_Module, "efl_text_font_weight_get");
    private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
         try {
            _ret_var = ((Text)wrapper).GetFontWeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;


    private delegate  void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWeight font_weight);


    public delegate  void efl_text_font_weight_set_api_delegate(System.IntPtr obj,   Efl.TextFontWeight font_weight);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate>(_Module, "efl_text_font_weight_set");
    private static  void font_weight_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight)
   {
      Eina.Log.Debug("function efl_text_font_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontWeight( font_weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_weight);
      }
   }
   private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;


    private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate>(_Module, "efl_text_font_slant_get");
    private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_slant_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
         try {
            _ret_var = ((Text)wrapper).GetFontSlant();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_slant_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;


    private delegate  void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontSlant style);


    public delegate  void efl_text_font_slant_set_api_delegate(System.IntPtr obj,   Efl.TextFontSlant style);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate>(_Module, "efl_text_font_slant_set");
    private static  void font_slant_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style)
   {
      Eina.Log.Debug("function efl_text_font_slant_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontSlant( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_slant_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;


    private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate>(_Module, "efl_text_font_width_get");
    private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
         try {
            _ret_var = ((Text)wrapper).GetFontWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;


    private delegate  void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWidth width);


    public delegate  void efl_text_font_width_set_api_delegate(System.IntPtr obj,   Efl.TextFontWidth width);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate>(_Module, "efl_text_font_width_set");
    private static  void font_width_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width)
   {
      Eina.Log.Debug("function efl_text_font_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate>(_Module, "efl_text_font_lang_get");
    private static  System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_lang_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetFontLang();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_lang_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;


    private delegate  void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);


    public delegate  void efl_text_font_lang_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate>(_Module, "efl_text_font_lang_set");
    private static  void font_lang_set(System.IntPtr obj, System.IntPtr pd,   System.String lang)
   {
      Eina.Log.Debug("function efl_text_font_lang_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontLang( lang);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_lang_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lang);
      }
   }
   private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;


    private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(_Module, "efl_text_font_bitmap_scalable_get");
    private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
         try {
            _ret_var = ((Text)wrapper).GetFontBitmapScalable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;


    private delegate  void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontBitmapScalable scalable);


    public delegate  void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,   Efl.TextFontBitmapScalable scalable);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(_Module, "efl_text_font_bitmap_scalable_set");
    private static  void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetFontBitmapScalable( scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scalable);
      }
   }
   private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;


    private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_ellipsis_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate> efl_text_ellipsis_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate>(_Module, "efl_text_ellipsis_get");
    private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_ellipsis_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetEllipsis();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_ellipsis_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;


    private delegate  void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_ellipsis_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate> efl_text_ellipsis_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate>(_Module, "efl_text_ellipsis_set");
    private static  void ellipsis_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_ellipsis_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetEllipsis( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_ellipsis_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;


    private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFormatWrap efl_text_wrap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate> efl_text_wrap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate>(_Module, "efl_text_wrap_get");
    private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_wrap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
         try {
            _ret_var = ((Text)wrapper).GetWrap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_wrap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;


    private delegate  void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatWrap wrap);


    public delegate  void efl_text_wrap_set_api_delegate(System.IntPtr obj,   Efl.TextFormatWrap wrap);
    public static Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate> efl_text_wrap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate>(_Module, "efl_text_wrap_set");
    private static  void wrap_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap)
   {
      Eina.Log.Debug("function efl_text_wrap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetWrap( wrap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_wrap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  wrap);
      }
   }
   private static efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_multiline_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate> efl_text_multiline_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate>(_Module, "efl_text_multiline_get");
    private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_multiline_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetMultiline();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_multiline_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;


    private delegate  void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_text_multiline_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate> efl_text_multiline_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate>(_Module, "efl_text_multiline_set");
    private static  void multiline_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_multiline_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetMultiline( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_multiline_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;


    private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate> efl_text_halign_auto_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate>(_Module, "efl_text_halign_auto_type_get");
    private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
         try {
            _ret_var = ((Text)wrapper).GetHalignAutoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_auto_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;


    private delegate  void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatHorizontalAlignmentAutoType value);


    public delegate  void efl_text_halign_auto_type_set_api_delegate(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate> efl_text_halign_auto_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate>(_Module, "efl_text_halign_auto_type_set");
    private static  void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetHalignAutoType( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_auto_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;


    private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_halign_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate> efl_text_halign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate>(_Module, "efl_text_halign_get");
    private static double halign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetHalign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_halign_get_delegate efl_text_halign_get_static_delegate;


    private delegate  void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_halign_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate> efl_text_halign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate>(_Module, "efl_text_halign_set");
    private static  void halign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_halign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetHalign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_halign_set_delegate efl_text_halign_set_static_delegate;


    private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_valign_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate> efl_text_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate>(_Module, "efl_text_valign_get");
    private static double valign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetValign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_valign_get_delegate efl_text_valign_get_static_delegate;


    private delegate  void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_valign_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate> efl_text_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate>(_Module, "efl_text_valign_set");
    private static  void valign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetValign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_valign_set_delegate efl_text_valign_set_static_delegate;


    private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_linegap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate> efl_text_linegap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate>(_Module, "efl_text_linegap_get");
    private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linegap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetLinegap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linegap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;


    private delegate  void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_linegap_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate> efl_text_linegap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate>(_Module, "efl_text_linegap_set");
    private static  void linegap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linegap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetLinegap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linegap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;


    private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_linerelgap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate> efl_text_linerelgap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate>(_Module, "efl_text_linerelgap_get");
    private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linerelgap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetLinerelgap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linerelgap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;


    private delegate  void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);


    public delegate  void efl_text_linerelgap_set_api_delegate(System.IntPtr obj,   double value);
    public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate> efl_text_linerelgap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate>(_Module, "efl_text_linerelgap_set");
    private static  void linerelgap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linerelgap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetLinerelgap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linerelgap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;


    private delegate  int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_tabstops_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate> efl_text_tabstops_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate>(_Module, "efl_text_tabstops_get");
    private static  int tabstops_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_tabstops_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetTabstops();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_tabstops_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;


    private delegate  void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,    int value);


    public delegate  void efl_text_tabstops_set_api_delegate(System.IntPtr obj,    int value);
    public static Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate> efl_text_tabstops_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate>(_Module, "efl_text_tabstops_set");
    private static  void tabstops_set(System.IntPtr obj, System.IntPtr pd,   int value)
   {
      Eina.Log.Debug("function efl_text_tabstops_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetTabstops( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_tabstops_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private static efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_password_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate> efl_text_password_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate>(_Module, "efl_text_password_get");
    private static bool password_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_password_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetPassword();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_password_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_password_get_delegate efl_text_password_get_static_delegate;


    private delegate  void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);


    public delegate  void efl_text_password_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    public static Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate> efl_text_password_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate>(_Module, "efl_text_password_set");
    private static  void password_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_password_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetPassword( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_password_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private static efl_text_password_set_delegate efl_text_password_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_replacement_char_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate> efl_text_replacement_char_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate>(_Module, "efl_text_replacement_char_get");
    private static  System.String replacement_char_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_replacement_char_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetReplacementChar();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_replacement_char_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;


    private delegate  void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);


    public delegate  void efl_text_replacement_char_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
    public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate> efl_text_replacement_char_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate>(_Module, "efl_text_replacement_char_set");
    private static  void replacement_char_set(System.IntPtr obj, System.IntPtr pd,   System.String repch)
   {
      Eina.Log.Debug("function efl_text_replacement_char_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetReplacementChar( repch);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_replacement_char_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repch);
      }
   }
   private static efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_interactive_selection_allowed_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_interactive_selection_allowed_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate> efl_text_interactive_selection_allowed_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate>(_Module, "efl_text_interactive_selection_allowed_get");
    private static bool selection_allowed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_allowed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetSelectionAllowed();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_selection_allowed_get_delegate efl_text_interactive_selection_allowed_get_static_delegate;


    private delegate  void efl_text_interactive_selection_allowed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allowed);


    public delegate  void efl_text_interactive_selection_allowed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allowed);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate> efl_text_interactive_selection_allowed_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate>(_Module, "efl_text_interactive_selection_allowed_set");
    private static  void selection_allowed_set(System.IntPtr obj, System.IntPtr pd,  bool allowed)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_allowed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetSelectionAllowed( allowed);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allowed);
      }
   }
   private static efl_text_interactive_selection_allowed_set_delegate efl_text_interactive_selection_allowed_set_static_delegate;


    private delegate  void efl_text_interactive_selection_cursors_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.TextCursorCursor start,   out Efl.TextCursorCursor end);


    public delegate  void efl_text_interactive_selection_cursors_get_api_delegate(System.IntPtr obj,   out Efl.TextCursorCursor start,   out Efl.TextCursorCursor end);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate> efl_text_interactive_selection_cursors_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate>(_Module, "efl_text_interactive_selection_cursors_get");
    private static  void selection_cursors_get(System.IntPtr obj, System.IntPtr pd,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end)
   {
      Eina.Log.Debug("function efl_text_interactive_selection_cursors_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           start = default(Efl.TextCursorCursor);      end = default(Efl.TextCursorCursor);                     
         try {
            ((Text)wrapper).GetSelectionCursors( out start,  out end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out start,  out end);
      }
   }
   private static efl_text_interactive_selection_cursors_get_delegate efl_text_interactive_selection_cursors_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_interactive_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_text_interactive_editable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate> efl_text_interactive_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate>(_Module, "efl_text_interactive_editable_get");
    private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_editable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetEditable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_interactive_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_editable_get_delegate efl_text_interactive_editable_get_static_delegate;


    private delegate  void efl_text_interactive_editable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool editable);


    public delegate  void efl_text_interactive_editable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate> efl_text_interactive_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate>(_Module, "efl_text_interactive_editable_set");
    private static  void editable_set(System.IntPtr obj, System.IntPtr pd,  bool editable)
   {
      Eina.Log.Debug("function efl_text_interactive_editable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetEditable( editable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_interactive_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  editable);
      }
   }
   private static efl_text_interactive_editable_set_delegate efl_text_interactive_editable_set_static_delegate;


    private delegate  void efl_text_interactive_select_none_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_text_interactive_select_none_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate> efl_text_interactive_select_none_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate>(_Module, "efl_text_interactive_select_none");
    private static  void select_none(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_interactive_select_none was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Text)wrapper).SelectNone();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_text_interactive_select_none_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_interactive_select_none_delegate efl_text_interactive_select_none_static_delegate;


    private delegate  void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_normal_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate> efl_text_normal_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate>(_Module, "efl_text_normal_color_get");
    private static  void normal_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetNormalColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;


    private delegate  void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_normal_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate> efl_text_normal_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate>(_Module, "efl_text_normal_color_set");
    private static  void normal_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_normal_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetNormalColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_normal_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;


    private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleBackingType efl_text_backing_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate> efl_text_backing_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate>(_Module, "efl_text_backing_type_get");
    private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_backing_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
         try {
            _ret_var = ((Text)wrapper).GetBackingType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_backing_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;


    private delegate  void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleBackingType type);


    public delegate  void efl_text_backing_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleBackingType type);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate> efl_text_backing_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate>(_Module, "efl_text_backing_type_set");
    private static  void backing_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type)
   {
      Eina.Log.Debug("function efl_text_backing_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetBackingType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_backing_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;


    private delegate  void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_backing_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate> efl_text_backing_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate>(_Module, "efl_text_backing_color_get");
    private static  void backing_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetBackingColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;


    private delegate  void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_backing_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate> efl_text_backing_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate>(_Module, "efl_text_backing_color_set");
    private static  void backing_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_backing_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetBackingColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_backing_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;


    private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate>(_Module, "efl_text_underline_type_get");
    private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
         try {
            _ret_var = ((Text)wrapper).GetUnderlineType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;


    private delegate  void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleUnderlineType type);


    public delegate  void efl_text_underline_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleUnderlineType type);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate>(_Module, "efl_text_underline_type_set");
    private static  void underline_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type)
   {
      Eina.Log.Debug("function efl_text_underline_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetUnderlineType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;


    private delegate  void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate>(_Module, "efl_text_underline_color_get");
    private static  void underline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetUnderlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;


    private delegate  void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate>(_Module, "efl_text_underline_color_set");
    private static  void underline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetUnderlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;


    private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate>(_Module, "efl_text_underline_height_get");
    private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_height_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Text)wrapper).GetUnderlineHeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_height_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;


    private delegate  void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,   double height);


    public delegate  void efl_text_underline_height_set_api_delegate(System.IntPtr obj,   double height);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate>(_Module, "efl_text_underline_height_set");
    private static  void underline_height_set(System.IntPtr obj, System.IntPtr pd,  double height)
   {
      Eina.Log.Debug("function efl_text_underline_height_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetUnderlineHeight( height);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_height_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  height);
      }
   }
   private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;


    private delegate  void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(_Module, "efl_text_underline_dashed_color_get");
    private static  void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetUnderlineDashedColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;


    private delegate  void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(_Module, "efl_text_underline_dashed_color_set");
    private static  void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetUnderlineDashedColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline_dashed_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;


    private delegate  int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(_Module, "efl_text_underline_dashed_width_get");
    private static  int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetUnderlineDashedWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;


    private delegate  void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,    int width);


    public delegate  void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,    int width);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(_Module, "efl_text_underline_dashed_width_set");
    private static  void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd,   int width)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetUnderlineDashedWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;


    private delegate  int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(_Module, "efl_text_underline_dashed_gap_get");
    private static  int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetUnderlineDashedGap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;


    private delegate  void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,    int gap);


    public delegate  void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,    int gap);
    public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(_Module, "efl_text_underline_dashed_gap_set");
    private static  void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd,   int gap)
   {
      Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetUnderlineDashedGap( gap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_underline_dashed_gap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gap);
      }
   }
   private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;


    private delegate  void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_underline2_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate> efl_text_underline2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate>(_Module, "efl_text_underline2_color_get");
    private static  void underline2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetUnderline2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;


    private delegate  void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_underline2_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate> efl_text_underline2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate>(_Module, "efl_text_underline2_color_set");
    private static  void underline2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_underline2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetUnderline2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_underline2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;


    private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(_Module, "efl_text_strikethrough_type_get");
    private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
         try {
            _ret_var = ((Text)wrapper).GetStrikethroughType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_strikethrough_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;


    private delegate  void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleStrikethroughType type);


    public delegate  void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleStrikethroughType type);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(_Module, "efl_text_strikethrough_type_set");
    private static  void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type)
   {
      Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetStrikethroughType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_strikethrough_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;


    private delegate  void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(_Module, "efl_text_strikethrough_color_get");
    private static  void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetStrikethroughColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;


    private delegate  void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(_Module, "efl_text_strikethrough_color_set");
    private static  void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetStrikethroughColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_strikethrough_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;


    private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate>(_Module, "efl_text_effect_type_get");
    private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_effect_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
         try {
            _ret_var = ((Text)wrapper).GetEffectType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_effect_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;


    private delegate  void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleEffectType type);


    public delegate  void efl_text_effect_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleEffectType type);
    public static Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate>(_Module, "efl_text_effect_type_set");
    private static  void effect_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type)
   {
      Eina.Log.Debug("function efl_text_effect_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetEffectType( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_effect_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;


    private delegate  void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_outline_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate>(_Module, "efl_text_outline_color_get");
    private static  void outline_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetOutlineColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;


    private delegate  void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_outline_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate>(_Module, "efl_text_outline_color_set");
    private static  void outline_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_outline_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetOutlineColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_outline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;


    private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(_Module, "efl_text_shadow_direction_get");
    private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
         try {
            _ret_var = ((Text)wrapper).GetShadowDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_shadow_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;


    private delegate  void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleShadowDirection type);


    public delegate  void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,   Efl.TextStyleShadowDirection type);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(_Module, "efl_text_shadow_direction_set");
    private static  void shadow_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type)
   {
      Eina.Log.Debug("function efl_text_shadow_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetShadowDirection( type);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_shadow_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
      }
   }
   private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;


    private delegate  void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(_Module, "efl_text_shadow_color_get");
    private static  void shadow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetShadowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;


    private delegate  void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(_Module, "efl_text_shadow_color_set");
    private static  void shadow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_shadow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetShadowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_shadow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;


    private delegate  void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_glow_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate>(_Module, "efl_text_glow_color_get");
    private static  void glow_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetGlowColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;


    private delegate  void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_glow_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate>(_Module, "efl_text_glow_color_set");
    private static  void glow_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetGlowColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;


    private delegate  void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  byte r,   out  byte g,   out  byte b,   out  byte a);


    public delegate  void efl_text_glow2_color_get_api_delegate(System.IntPtr obj,   out  byte r,   out  byte g,   out  byte b,   out  byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate> efl_text_glow2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate>(_Module, "efl_text_glow2_color_get");
    private static  void glow2_color_get(System.IntPtr obj, System.IntPtr pd,  out  byte r,  out  byte g,  out  byte b,  out  byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( byte);      g = default( byte);      b = default( byte);      a = default( byte);                                 
         try {
            ((Text)wrapper).GetGlow2Color( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;


    private delegate  void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    byte r,    byte g,    byte b,    byte a);


    public delegate  void efl_text_glow2_color_set_api_delegate(System.IntPtr obj,    byte r,    byte g,    byte b,    byte a);
    public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate> efl_text_glow2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate>(_Module, "efl_text_glow2_color_set");
    private static  void glow2_color_set(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a)
   {
      Eina.Log.Debug("function efl_text_glow2_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Text)wrapper).SetGlow2Color( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_text_glow2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(_Module, "efl_text_gfx_filter_get");
    private static  System.String gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetGfxFilter();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_gfx_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;


    private delegate  void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);


    public delegate  void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code);
    public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(_Module, "efl_text_gfx_filter_set");
    private static  void gfx_filter_set(System.IntPtr obj, System.IntPtr pd,   System.String code)
   {
      Eina.Log.Debug("function efl_text_gfx_filter_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Text)wrapper).SetGfxFilter( code);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_gfx_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code);
      }
   }
   private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;


    private delegate Eina.Unicode efl_access_text_character_get_delegate(System.IntPtr obj, System.IntPtr pd,    int offset);


    public delegate Eina.Unicode efl_access_text_character_get_api_delegate(System.IntPtr obj,    int offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate> efl_access_text_character_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate>(_Module, "efl_access_text_character_get");
    private static Eina.Unicode character_get(System.IntPtr obj, System.IntPtr pd,   int offset)
   {
      Eina.Log.Debug("function efl_access_text_character_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
         try {
            _ret_var = ((Text)wrapper).GetCharacter( offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_character_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset);
      }
   }
   private static efl_access_text_character_get_delegate efl_access_text_character_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_access_text_string_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Access.TextGranularity granularity,    System.IntPtr start_offset,    System.IntPtr end_offset);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_access_text_string_get_api_delegate(System.IntPtr obj,   Efl.Access.TextGranularity granularity,    System.IntPtr start_offset,    System.IntPtr end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate> efl_access_text_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate>(_Module, "efl_access_text_string_get");
    private static  System.String string_get(System.IntPtr obj, System.IntPtr pd,  Efl.Access.TextGranularity granularity,   System.IntPtr start_offset,   System.IntPtr end_offset)
   {
      Eina.Log.Debug("function efl_access_text_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                                              System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetString( granularity,  _in_start_offset,  _in_end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  granularity,  start_offset,  end_offset);
      }
   }
   private static efl_access_text_string_get_delegate efl_access_text_string_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] private delegate  System.String efl_access_text_get_delegate(System.IntPtr obj, System.IntPtr pd,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] public delegate  System.String efl_access_text_get_api_delegate(System.IntPtr obj,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate> efl_access_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate>(_Module, "efl_access_text_get");
    private static  System.String access_text_get(System.IntPtr obj, System.IntPtr pd,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Text)wrapper).GetAccessText( start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_get_delegate efl_access_text_get_static_delegate;


    private delegate  int efl_access_text_caret_offset_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_caret_offset_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate> efl_access_text_caret_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate>(_Module, "efl_access_text_caret_offset_get");
    private static  int caret_offset_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_caret_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetCaretOffset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_caret_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_caret_offset_get_delegate efl_access_text_caret_offset_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_caret_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,    int offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_caret_offset_set_api_delegate(System.IntPtr obj,    int offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate> efl_access_text_caret_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate>(_Module, "efl_access_text_caret_offset_set");
    private static bool caret_offset_set(System.IntPtr obj, System.IntPtr pd,   int offset)
   {
      Eina.Log.Debug("function efl_access_text_caret_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetCaretOffset( offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_caret_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset);
      }
   }
   private static efl_access_text_caret_offset_set_delegate efl_access_text_caret_offset_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_attribute_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,    System.IntPtr start_offset,    System.IntPtr end_offset,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  out  System.String value);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_attribute_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,    System.IntPtr start_offset,    System.IntPtr end_offset,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]  out  System.String value);
    public static Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate> efl_access_text_attribute_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate>(_Module, "efl_access_text_attribute_get");
    private static bool attribute_get(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.IntPtr start_offset,   System.IntPtr end_offset,  out  System.String value)
   {
      Eina.Log.Debug("function efl_access_text_attribute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                              value = default( System.String);                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetAttribute( name,  _in_start_offset,  _in_end_offset,  out value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_access_text_attribute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  start_offset,  end_offset,  out value);
      }
   }
   private static efl_access_text_attribute_get_delegate efl_access_text_attribute_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr start_offset,    System.IntPtr end_offset);


    public delegate  System.IntPtr efl_access_text_attributes_get_api_delegate(System.IntPtr obj,    System.IntPtr start_offset,    System.IntPtr end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate> efl_access_text_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate>(_Module, "efl_access_text_attributes_get");
    private static  System.IntPtr text_attributes_get(System.IntPtr obj, System.IntPtr pd,   System.IntPtr start_offset,   System.IntPtr end_offset)
   {
      Eina.Log.Debug("function efl_access_text_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged< int>(start_offset);
      var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged< int>(end_offset);
                                 Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
         try {
            _ret_var = ((Text)wrapper).GetTextAttributes( _in_start_offset,  _in_end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_attributes_get_delegate efl_access_text_attributes_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_default_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_access_text_default_attributes_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate> efl_access_text_default_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate>(_Module, "efl_access_text_default_attributes_get");
    private static  System.IntPtr default_attributes_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_default_attributes_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
         try {
            _ret_var = ((Text)wrapper).GetDefaultAttributes();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_default_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_default_attributes_get_delegate efl_access_text_default_attributes_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_character_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,    int offset,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   out Eina.Rect_StructInternal rect);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_character_extents_get_api_delegate(System.IntPtr obj,    int offset,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   out Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate> efl_access_text_character_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate>(_Module, "efl_access_text_character_extents_get");
    private static bool character_extents_get(System.IntPtr obj, System.IntPtr pd,   int offset,  bool screen_coords,  out Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_text_character_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             Eina.Rect _out_rect = default(Eina.Rect);
                           bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetCharacterExtents( offset,  screen_coords,  out _out_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  rect = Eina.Rect_StructConversion.ToInternal(_out_rect);
                        return _ret_var;
      } else {
         return efl_access_text_character_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  offset,  screen_coords,  out rect);
      }
   }
   private static efl_access_text_character_extents_get_delegate efl_access_text_character_extents_get_static_delegate;


    private delegate  int efl_access_text_character_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_character_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate> efl_access_text_character_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate>(_Module, "efl_access_text_character_count_get");
    private static  int character_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_character_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetCharacterCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_character_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_character_count_get_delegate efl_access_text_character_count_get_static_delegate;


    private delegate  int efl_access_text_offset_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);


    public delegate  int efl_access_text_offset_at_point_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int x,    int y);
    public static Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate> efl_access_text_offset_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate>(_Module, "efl_access_text_offset_at_point_get");
    private static  int offset_at_point_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int x,   int y)
   {
      Eina.Log.Debug("function efl_access_text_offset_at_point_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                         int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetOffsetAtPoint( screen_coords,  x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_offset_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  x,  y);
      }
   }
   private static efl_access_text_offset_at_point_get_delegate efl_access_text_offset_at_point_get_static_delegate;


    private delegate  System.IntPtr efl_access_text_bounded_ranges_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect,   Efl.Access.TextClipType xclip,   Efl.Access.TextClipType yclip);


    public delegate  System.IntPtr efl_access_text_bounded_ranges_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,   Eina.Rect_StructInternal rect,   Efl.Access.TextClipType xclip,   Efl.Access.TextClipType yclip);
    public static Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate> efl_access_text_bounded_ranges_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate>(_Module, "efl_access_text_bounded_ranges_get");
    private static  System.IntPtr bounded_ranges_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,  Eina.Rect_StructInternal rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip)
   {
      Eina.Log.Debug("function efl_access_text_bounded_ranges_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                                                     Eina.List<Efl.Access.TextRange> _ret_var = default(Eina.List<Efl.Access.TextRange>);
         try {
            _ret_var = ((Text)wrapper).GetBoundedRanges( screen_coords,  _in_rect,  xclip,  yclip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;
      } else {
         return efl_access_text_bounded_ranges_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  rect,  xclip,  yclip);
      }
   }
   private static efl_access_text_bounded_ranges_get_delegate efl_access_text_bounded_ranges_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_range_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int start_offset,    int end_offset,   out Eina.Rect_StructInternal rect);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_range_extents_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool screen_coords,    int start_offset,    int end_offset,   out Eina.Rect_StructInternal rect);
    public static Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate> efl_access_text_range_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate>(_Module, "efl_access_text_range_extents_get");
    private static bool range_extents_get(System.IntPtr obj, System.IntPtr pd,  bool screen_coords,   int start_offset,   int end_offset,  out Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_access_text_range_extents_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                         Eina.Rect _out_rect = default(Eina.Rect);
                                 bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).GetRangeExtents( screen_coords,  start_offset,  end_offset,  out _out_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        rect = Eina.Rect_StructConversion.ToInternal(_out_rect);
                              return _ret_var;
      } else {
         return efl_access_text_range_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  screen_coords,  start_offset,  end_offset,  out rect);
      }
   }
   private static efl_access_text_range_extents_get_delegate efl_access_text_range_extents_get_static_delegate;


    private delegate  int efl_access_text_selections_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_access_text_selections_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate> efl_access_text_selections_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate>(_Module, "efl_access_text_selections_count_get");
    private static  int selections_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_text_selections_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Text)wrapper).GetSelectionsCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_text_selections_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_access_text_selections_count_get_delegate efl_access_text_selections_count_get_static_delegate;


    private delegate  void efl_access_text_access_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number,   out  int start_offset,   out  int end_offset);


    public delegate  void efl_access_text_access_selection_get_api_delegate(System.IntPtr obj,    int selection_number,   out  int start_offset,   out  int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate> efl_access_text_access_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate>(_Module, "efl_access_text_access_selection_get");
    private static  void access_selection_get(System.IntPtr obj, System.IntPtr pd,   int selection_number,  out  int start_offset,  out  int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_access_selection_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       start_offset = default( int);      end_offset = default( int);                           
         try {
            ((Text)wrapper).GetAccessSelection( selection_number,  out start_offset,  out end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_access_text_access_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number,  out start_offset,  out end_offset);
      }
   }
   private static efl_access_text_access_selection_get_delegate efl_access_text_access_selection_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_access_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_access_selection_set_api_delegate(System.IntPtr obj,    int selection_number,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate> efl_access_text_access_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate>(_Module, "efl_access_text_access_selection_set");
    private static bool access_selection_set(System.IntPtr obj, System.IntPtr pd,   int selection_number,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_access_selection_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetAccessSelection( selection_number,  start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_access_text_access_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number,  start_offset,  end_offset);
      }
   }
   private static efl_access_text_access_selection_set_delegate efl_access_text_access_selection_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_selection_add_delegate(System.IntPtr obj, System.IntPtr pd,    int start_offset,    int end_offset);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_selection_add_api_delegate(System.IntPtr obj,    int start_offset,    int end_offset);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate> efl_access_text_selection_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate>(_Module, "efl_access_text_selection_add");
    private static bool selection_add(System.IntPtr obj, System.IntPtr pd,   int start_offset,   int end_offset)
   {
      Eina.Log.Debug("function efl_access_text_selection_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).AddSelection( start_offset,  end_offset);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_text_selection_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_offset,  end_offset);
      }
   }
   private static efl_access_text_selection_add_delegate efl_access_text_selection_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_text_selection_remove_delegate(System.IntPtr obj, System.IntPtr pd,    int selection_number);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_text_selection_remove_api_delegate(System.IntPtr obj,    int selection_number);
    public static Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate> efl_access_text_selection_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate>(_Module, "efl_access_text_selection_remove");
    private static bool selection_remove(System.IntPtr obj, System.IntPtr pd,   int selection_number)
   {
      Eina.Log.Debug("function efl_access_text_selection_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SelectionRemove( selection_number);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_text_selection_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selection_number);
      }
   }
   private static efl_access_text_selection_remove_delegate efl_access_text_selection_remove_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_content_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate> efl_access_editable_text_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate>(_Module, "efl_access_editable_text_content_set");
    private static bool text_content_set(System.IntPtr obj, System.IntPtr pd,   System.String kw_string)
   {
      Eina.Log.Debug("function efl_access_editable_text_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).SetTextContent( kw_string);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_editable_text_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_string);
      }
   }
   private static efl_access_editable_text_content_set_delegate efl_access_editable_text_content_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_insert_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string,    int position);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_insert_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String kw_string,    int position);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate> efl_access_editable_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate>(_Module, "efl_access_editable_text_insert");
    private static bool insert(System.IntPtr obj, System.IntPtr pd,   System.String kw_string,   int position)
   {
      Eina.Log.Debug("function efl_access_editable_text_insert was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Insert( kw_string,  position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_string,  position);
      }
   }
   private static efl_access_editable_text_insert_delegate efl_access_editable_text_insert_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_copy_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_copy_api_delegate(System.IntPtr obj,    int start,    int end);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate> efl_access_editable_text_copy_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate>(_Module, "efl_access_editable_text_copy");
    private static bool copy(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_copy was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Copy( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private static efl_access_editable_text_copy_delegate efl_access_editable_text_copy_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_cut_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_cut_api_delegate(System.IntPtr obj,    int start,    int end);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate> efl_access_editable_text_cut_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate>(_Module, "efl_access_editable_text_cut");
    private static bool cut(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_cut was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Cut( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_cut_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private static efl_access_editable_text_cut_delegate efl_access_editable_text_cut_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_delete_delegate(System.IntPtr obj, System.IntPtr pd,    int start,    int end);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_delete_api_delegate(System.IntPtr obj,    int start,    int end);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate> efl_access_editable_text_delete_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate>(_Module, "efl_access_editable_text_delete");
    private static bool kw_delete(System.IntPtr obj, System.IntPtr pd,   int start,   int end)
   {
      Eina.Log.Debug("function efl_access_editable_text_delete was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Delete( start,  end);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_access_editable_text_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start,  end);
      }
   }
   private static efl_access_editable_text_delete_delegate efl_access_editable_text_delete_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_editable_text_paste_delegate(System.IntPtr obj, System.IntPtr pd,    int position);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_access_editable_text_paste_api_delegate(System.IntPtr obj,    int position);
    public static Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate> efl_access_editable_text_paste_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate>(_Module, "efl_access_editable_text_paste");
    private static bool paste(System.IntPtr obj, System.IntPtr pd,   int position)
   {
      Eina.Log.Debug("function efl_access_editable_text_paste was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Text)wrapper).Paste( position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_editable_text_paste_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
      }
   }
   private static efl_access_editable_text_paste_delegate efl_access_editable_text_paste_static_delegate;
}
} } 
