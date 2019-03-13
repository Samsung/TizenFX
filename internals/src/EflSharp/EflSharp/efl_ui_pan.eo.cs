#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary pan class</summary>
[PanNativeInherit]
public class Pan : Efl.Canvas.Group, Efl.Eo.IWrapper,Efl.Content
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.PanNativeInherit nativeInherit = new Efl.Ui.PanNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Pan))
            return Efl.Ui.PanNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_pan_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Pan(Efl.Object parent= null
         ) :
      base(efl_ui_pan_class_get(), typeof(Pan), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Pan(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Pan(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Pan static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Pan(obj.NativeHandle);
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
   /// <summary>Called when pan content changed</summary>
   public new event EventHandler ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentChangedEvt.</summary>
   public void On_ContentChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentChangedEvt_delegate;
   private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ContentChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ViewportChangedEvtKey = new object();
   /// <summary>Called when pan viewport changed</summary>
   public event EventHandler ViewportChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_VIEWPORT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_ViewportChangedEvt_delegate)) {
               eventHandlers.AddHandler(ViewportChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_VIEWPORT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ViewportChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ViewportChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ViewportChangedEvt.</summary>
   public void On_ViewportChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ViewportChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ViewportChangedEvt_delegate;
   private void on_ViewportChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ViewportChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PositionChangedEvtKey = new object();
   /// <summary>Called when pan position changed</summary>
   public new event EventHandler PositionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_POSITION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_PositionChangedEvt_delegate)) {
               eventHandlers.AddHandler(PositionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_PAN_EVENT_POSITION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_PositionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PositionChangedEvt.</summary>
   public void On_PositionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PositionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PositionChangedEvt_delegate;
   private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PositionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Efl_Content_ContentChangedEvtKey = new object();
   /// <summary>Sent after the content is set or unset using the current content object.</summary>
    event EventHandler<Efl.ContentContentChangedEvt_Args> Efl.Content.ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Efl_Content_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Content_ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_Content_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Content_ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Content_ContentChangedEvt.</summary>
   public void On_Efl_Content_ContentChangedEvt(Efl.ContentContentChangedEvt_Args e)
   {
      EventHandler<Efl.ContentContentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContentContentChangedEvt_Args>)eventHandlers[Efl_Content_ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Content_ContentChangedEvt_delegate;
   private void on_Efl_Content_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContentContentChangedEvt_Args args = new Efl.ContentContentChangedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_Efl_Content_ContentChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
      evt_ViewportChangedEvt_delegate = new Efl.EventCb(on_ViewportChangedEvt_NativeCallback);
      evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
      evt_Efl_Content_ContentChangedEvt_delegate = new Efl.EventCb(on_Efl_Content_ContentChangedEvt_NativeCallback);
   }
   /// <summary>Position</summary>
   /// <returns></returns>
   virtual public Eina.Position2D GetPanPosition() {
       var _ret_var = Efl.Ui.PanNativeInherit.efl_ui_pan_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Position</summary>
   /// <param name="position"></param>
   /// <returns></returns>
   virtual public  void SetPanPosition( Eina.Position2D position) {
       var _in_position = Eina.Position2D_StructConversion.ToInternal(position);
                  Efl.Ui.PanNativeInherit.efl_ui_pan_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_position);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Content size</summary>
   /// <returns></returns>
   virtual public Eina.Size2D GetContentSize() {
       var _ret_var = Efl.Ui.PanNativeInherit.efl_ui_pan_content_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>The minimal position to scroll</summary>
   /// <returns></returns>
   virtual public Eina.Position2D GetPanPositionMin() {
       var _ret_var = Efl.Ui.PanNativeInherit.efl_ui_pan_position_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>The maximal position to scroll</summary>
   /// <returns></returns>
   virtual public Eina.Position2D GetPanPositionMax() {
       var _ret_var = Efl.Ui.PanNativeInherit.efl_ui_pan_position_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
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
   /// <summary>Position</summary>
/// <value></value>
   public Eina.Position2D PanPosition {
      get { return GetPanPosition(); }
      set { SetPanPosition( value); }
   }
   /// <summary>Content size</summary>
/// <value></value>
   public Eina.Size2D ContentSize {
      get { return GetContentSize(); }
   }
   /// <summary>The minimal position to scroll</summary>
/// <value></value>
   public Eina.Position2D PanPositionMin {
      get { return GetPanPositionMin(); }
   }
   /// <summary>The maximal position to scroll</summary>
/// <value></value>
   public Eina.Position2D PanPositionMax {
      get { return GetPanPositionMax(); }
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
/// <value>The object to swallow.</value>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Pan.efl_ui_pan_class_get();
   }
}
public class PanNativeInherit : Efl.Canvas.GroupNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_pan_position_get_static_delegate == null)
      efl_ui_pan_position_get_static_delegate = new efl_ui_pan_position_get_delegate(pan_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_pan_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_get_static_delegate)});
      if (efl_ui_pan_position_set_static_delegate == null)
      efl_ui_pan_position_set_static_delegate = new efl_ui_pan_position_set_delegate(pan_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_pan_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_set_static_delegate)});
      if (efl_ui_pan_content_size_get_static_delegate == null)
      efl_ui_pan_content_size_get_static_delegate = new efl_ui_pan_content_size_get_delegate(content_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_pan_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_content_size_get_static_delegate)});
      if (efl_ui_pan_position_min_get_static_delegate == null)
      efl_ui_pan_position_min_get_static_delegate = new efl_ui_pan_position_min_get_delegate(pan_position_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_pan_position_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_min_get_static_delegate)});
      if (efl_ui_pan_position_max_get_static_delegate == null)
      efl_ui_pan_position_max_get_static_delegate = new efl_ui_pan_position_max_get_delegate(pan_position_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_pan_position_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_max_get_static_delegate)});
      if (efl_content_get_static_delegate == null)
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      if (efl_content_set_static_delegate == null)
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      if (efl_content_unset_static_delegate == null)
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Pan.efl_ui_pan_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Pan.efl_ui_pan_class_get();
   }


    private delegate Eina.Position2D_StructInternal efl_ui_pan_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_ui_pan_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_get_api_delegate> efl_ui_pan_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_get_api_delegate>(_Module, "efl_ui_pan_position_get");
    private static Eina.Position2D_StructInternal pan_position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_pan_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Pan)wrapper).GetPanPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_pan_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_pan_position_get_delegate efl_ui_pan_position_get_static_delegate;


    private delegate  void efl_ui_pan_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal position);


    public delegate  void efl_ui_pan_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal position);
    public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_set_api_delegate> efl_ui_pan_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_set_api_delegate>(_Module, "efl_ui_pan_position_set");
    private static  void pan_position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal position)
   {
      Eina.Log.Debug("function efl_ui_pan_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_position = Eina.Position2D_StructConversion.ToManaged(position);
                     
         try {
            ((Pan)wrapper).SetPanPosition( _in_position);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_pan_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  position);
      }
   }
   private static efl_ui_pan_position_set_delegate efl_ui_pan_position_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_pan_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_ui_pan_content_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_pan_content_size_get_api_delegate> efl_ui_pan_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_content_size_get_api_delegate>(_Module, "efl_ui_pan_content_size_get");
    private static Eina.Size2D_StructInternal content_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_pan_content_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Pan)wrapper).GetContentSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_pan_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_pan_content_size_get_delegate efl_ui_pan_content_size_get_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_ui_pan_position_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_ui_pan_position_min_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_min_get_api_delegate> efl_ui_pan_position_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_min_get_api_delegate>(_Module, "efl_ui_pan_position_min_get");
    private static Eina.Position2D_StructInternal pan_position_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_pan_position_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Pan)wrapper).GetPanPositionMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_pan_position_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_pan_position_min_get_delegate efl_ui_pan_position_min_get_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_ui_pan_position_max_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_ui_pan_position_max_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_max_get_api_delegate> efl_ui_pan_position_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_max_get_api_delegate>(_Module, "efl_ui_pan_position_max_get");
    private static Eina.Position2D_StructInternal pan_position_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_pan_position_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Pan)wrapper).GetPanPositionMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_pan_position_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_pan_position_max_get_delegate efl_ui_pan_position_max_get_static_delegate;


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
            _ret_var = ((Pan)wrapper).GetContent();
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
            _ret_var = ((Pan)wrapper).SetContent( content);
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
            _ret_var = ((Pan)wrapper).UnsetContent();
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
}
} } 
