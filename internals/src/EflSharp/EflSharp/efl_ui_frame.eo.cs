#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Frame widget
/// The Frame widget allows for collapsing and expanding the content widget by clicking on the frame label. the label and content can be set using text_set and content_set api.</summary>
[FrameNativeInherit]
public class Frame : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Content,Efl.Text,Efl.TextMarkup,Efl.Ui.Clickable
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.FrameNativeInherit nativeInherit = new Efl.Ui.FrameNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Frame))
            return Efl.Ui.FrameNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_frame_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Frame(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_frame_class_get(), typeof(Frame), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Frame(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Frame(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Frame static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Frame(obj.NativeHandle);
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
private static object ContentChangedEvtKey = new object();
   /// <summary>Sent after the content is set or unset using the current content object.</summary>
   public event EventHandler<Efl.ContentContentChangedEvt_Args> ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentChangedEvt.</summary>
   public void On_ContentChangedEvt(Efl.ContentContentChangedEvt_Args e)
   {
      EventHandler<Efl.ContentContentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentChangedEvt_delegate;
   private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContentContentChangedEvt_Args args = new Efl.ContentContentChangedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentChangedEvt(args);
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
      evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
      evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
      evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
      evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
      evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
      evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
      evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
      evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
   }
   /// <summary>Determine the collapse state of a frame Use this to determine the collapse state of a frame.</summary>
   /// <returns><c>true</c> to collapse, <c>false</c> to expand.</returns>
   virtual public bool GetCollapse() {
       var _ret_var = Efl.Ui.FrameNativeInherit.efl_ui_frame_collapse_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Manually collapse a frame without animations Use this to toggle the collapsed state of a frame, bypassing animations.</summary>
   /// <param name="collapse"><c>true</c> to collapse, <c>false</c> to expand.</param>
   /// <returns></returns>
   virtual public  void SetCollapse( bool collapse) {
                         Efl.Ui.FrameNativeInherit.efl_ui_frame_collapse_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), collapse);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Determine autocollapsing of a frame
   /// When this returns <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
   /// <returns>Whether to enable autocollapse.</returns>
   virtual public bool GetAutocollapse() {
       var _ret_var = Efl.Ui.FrameNativeInherit.efl_ui_frame_autocollapse_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Toggle autocollapsing of a frame When <c>enable</c> is <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
   /// <param name="autocollapse">Whether to enable autocollapse.</param>
   /// <returns></returns>
   virtual public  void SetAutocollapse( bool autocollapse) {
                         Efl.Ui.FrameNativeInherit.efl_ui_frame_autocollapse_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), autocollapse);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Manually collapse a frame with animations Use this to toggle the collapsed state of a frame, triggering animations.</summary>
   /// <param name="collapse"><c>true</c> to collapse, <c>false</c> to expand.</param>
   /// <returns></returns>
   virtual public  void CollapseGo( bool collapse) {
                         Efl.Ui.FrameNativeInherit.efl_ui_frame_collapse_go_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), collapse);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = Efl.ContentNativeInherit.efl_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
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
   /// <summary>Markup property
   /// 1.21</summary>
   /// <returns>The markup-text representation set to this text.
   /// 1.21</returns>
   virtual public  System.String GetMarkup() {
       var _ret_var = Efl.TextMarkupNativeInherit.efl_text_markup_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Markup property
   /// 1.21</summary>
   /// <param name="markup">The markup-text representation set to this text.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetMarkup(  System.String markup) {
                         Efl.TextMarkupNativeInherit.efl_text_markup_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), markup);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Determine the collapse state of a frame Use this to determine the collapse state of a frame.</summary>
/// <value><c>true</c> to collapse, <c>false</c> to expand.</value>
   public bool Collapse {
      get { return GetCollapse(); }
      set { SetCollapse( value); }
   }
   /// <summary>Determine autocollapsing of a frame
/// When this returns <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
/// <value>Whether to enable autocollapse.</value>
   public bool Autocollapse {
      get { return GetAutocollapse(); }
      set { SetAutocollapse( value); }
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
/// <value>The object to swallow.</value>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   /// <summary>Markup property
/// 1.21</summary>
/// <value>The markup-text representation set to this text.
/// 1.21</value>
   public  System.String Markup {
      get { return GetMarkup(); }
      set { SetMarkup( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Frame.efl_ui_frame_class_get();
   }
}
public class FrameNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_frame_collapse_get_static_delegate == null)
      efl_ui_frame_collapse_get_static_delegate = new efl_ui_frame_collapse_get_delegate(collapse_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_frame_collapse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_get_static_delegate)});
      if (efl_ui_frame_collapse_set_static_delegate == null)
      efl_ui_frame_collapse_set_static_delegate = new efl_ui_frame_collapse_set_delegate(collapse_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_frame_collapse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_set_static_delegate)});
      if (efl_ui_frame_autocollapse_get_static_delegate == null)
      efl_ui_frame_autocollapse_get_static_delegate = new efl_ui_frame_autocollapse_get_delegate(autocollapse_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_frame_autocollapse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_autocollapse_get_static_delegate)});
      if (efl_ui_frame_autocollapse_set_static_delegate == null)
      efl_ui_frame_autocollapse_set_static_delegate = new efl_ui_frame_autocollapse_set_delegate(autocollapse_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_frame_autocollapse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_autocollapse_set_static_delegate)});
      if (efl_ui_frame_collapse_go_static_delegate == null)
      efl_ui_frame_collapse_go_static_delegate = new efl_ui_frame_collapse_go_delegate(collapse_go);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_frame_collapse_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_go_static_delegate)});
      if (efl_content_get_static_delegate == null)
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      if (efl_content_set_static_delegate == null)
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      if (efl_content_unset_static_delegate == null)
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      if (efl_text_get_static_delegate == null)
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      if (efl_text_set_static_delegate == null)
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      if (efl_text_markup_get_static_delegate == null)
      efl_text_markup_get_static_delegate = new efl_text_markup_get_delegate(markup_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_get_static_delegate)});
      if (efl_text_markup_set_static_delegate == null)
      efl_text_markup_set_static_delegate = new efl_text_markup_set_delegate(markup_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_markup_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Frame.efl_ui_frame_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Frame.efl_ui_frame_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_frame_collapse_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_frame_collapse_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_get_api_delegate> efl_ui_frame_collapse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_get_api_delegate>(_Module, "efl_ui_frame_collapse_get");
    private static bool collapse_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_frame_collapse_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Frame)wrapper).GetCollapse();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_frame_collapse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_frame_collapse_get_delegate efl_ui_frame_collapse_get_static_delegate;


    private delegate  void efl_ui_frame_collapse_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool collapse);


    public delegate  void efl_ui_frame_collapse_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool collapse);
    public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_set_api_delegate> efl_ui_frame_collapse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_set_api_delegate>(_Module, "efl_ui_frame_collapse_set");
    private static  void collapse_set(System.IntPtr obj, System.IntPtr pd,  bool collapse)
   {
      Eina.Log.Debug("function efl_ui_frame_collapse_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Frame)wrapper).SetCollapse( collapse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_frame_collapse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  collapse);
      }
   }
   private static efl_ui_frame_collapse_set_delegate efl_ui_frame_collapse_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_frame_autocollapse_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_frame_autocollapse_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_get_api_delegate> efl_ui_frame_autocollapse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_get_api_delegate>(_Module, "efl_ui_frame_autocollapse_get");
    private static bool autocollapse_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_frame_autocollapse_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Frame)wrapper).GetAutocollapse();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_frame_autocollapse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_frame_autocollapse_get_delegate efl_ui_frame_autocollapse_get_static_delegate;


    private delegate  void efl_ui_frame_autocollapse_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool autocollapse);


    public delegate  void efl_ui_frame_autocollapse_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool autocollapse);
    public static Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_set_api_delegate> efl_ui_frame_autocollapse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_set_api_delegate>(_Module, "efl_ui_frame_autocollapse_set");
    private static  void autocollapse_set(System.IntPtr obj, System.IntPtr pd,  bool autocollapse)
   {
      Eina.Log.Debug("function efl_ui_frame_autocollapse_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Frame)wrapper).SetAutocollapse( autocollapse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_frame_autocollapse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  autocollapse);
      }
   }
   private static efl_ui_frame_autocollapse_set_delegate efl_ui_frame_autocollapse_set_static_delegate;


    private delegate  void efl_ui_frame_collapse_go_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool collapse);


    public delegate  void efl_ui_frame_collapse_go_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool collapse);
    public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_go_api_delegate> efl_ui_frame_collapse_go_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_go_api_delegate>(_Module, "efl_ui_frame_collapse_go");
    private static  void collapse_go(System.IntPtr obj, System.IntPtr pd,  bool collapse)
   {
      Eina.Log.Debug("function efl_ui_frame_collapse_go was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Frame)wrapper).CollapseGo( collapse);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_frame_collapse_go_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  collapse);
      }
   }
   private static efl_ui_frame_collapse_go_delegate efl_ui_frame_collapse_go_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Frame)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Frame)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private static efl_content_set_delegate efl_content_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Frame)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_unset_delegate efl_content_unset_static_delegate;


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
            _ret_var = ((Frame)wrapper).GetText();
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
            ((Frame)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private static efl_text_set_delegate efl_text_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_markup_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate> efl_text_markup_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate>(_Module, "efl_text_markup_get");
    private static  System.String markup_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_markup_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Frame)wrapper).GetMarkup();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_markup_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_markup_get_delegate efl_text_markup_get_static_delegate;


    private delegate  void efl_text_markup_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);


    public delegate  void efl_text_markup_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String markup);
    public static Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate> efl_text_markup_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate>(_Module, "efl_text_markup_set");
    private static  void markup_set(System.IntPtr obj, System.IntPtr pd,   System.String markup)
   {
      Eina.Log.Debug("function efl_text_markup_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Frame)wrapper).SetMarkup( markup);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_markup_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  markup);
      }
   }
   private static efl_text_markup_set_delegate efl_text_markup_set_static_delegate;
}
} } 
