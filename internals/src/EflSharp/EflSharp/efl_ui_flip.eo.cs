#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI flip class</summary>
[FlipNativeInherit]
public class Flip : Efl.Ui.Widget, Efl.Eo.IWrapper,Efl.Container,Efl.Pack,Efl.PackLinear
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.FlipNativeInherit nativeInherit = new Efl.Ui.FlipNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Flip))
            return Efl.Ui.FlipNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Flip obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_flip_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Flip(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Flip", efl_ui_flip_class_get(), typeof(Flip), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Flip(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Flip(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Flip static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Flip(obj.NativeHandle);
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
private static object AnimateBeginEvtKey = new object();
   /// <summary>Called when flip animation begins</summary>
   public event EventHandler AnimateBeginEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FLIP_EVENT_ANIMATE_BEGIN";
            if (add_cpp_event_handler(key, this.evt_AnimateBeginEvt_delegate)) {
               eventHandlers.AddHandler(AnimateBeginEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FLIP_EVENT_ANIMATE_BEGIN";
            if (remove_cpp_event_handler(key, this.evt_AnimateBeginEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnimateBeginEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnimateBeginEvt.</summary>
   public void On_AnimateBeginEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AnimateBeginEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnimateBeginEvt_delegate;
   private void on_AnimateBeginEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AnimateBeginEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object AnimateDoneEvtKey = new object();
   /// <summary>Called when flip animation is done</summary>
   public event EventHandler AnimateDoneEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FLIP_EVENT_ANIMATE_DONE";
            if (add_cpp_event_handler(key, this.evt_AnimateDoneEvt_delegate)) {
               eventHandlers.AddHandler(AnimateDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FLIP_EVENT_ANIMATE_DONE";
            if (remove_cpp_event_handler(key, this.evt_AnimateDoneEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnimateDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnimateDoneEvt.</summary>
   public void On_AnimateDoneEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[AnimateDoneEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnimateDoneEvt_delegate;
   private void on_AnimateDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_AnimateDoneEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentAddedEvtKey = new object();
   /// <summary>Sent after a new item was added.</summary>
   public event EventHandler<Efl.ContainerContentAddedEvt_Args> ContentAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (add_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) {
               eventHandlers.AddHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ContentAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentAddedEvt.</summary>
   public void On_ContentAddedEvt(Efl.ContainerContentAddedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentAddedEvt_delegate;
   private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentAddedEvt_Args args = new Efl.ContainerContentAddedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContentRemovedEvtKey = new object();
   /// <summary>Sent after an item was removed, before unref.</summary>
   public event EventHandler<Efl.ContainerContentRemovedEvt_Args> ContentRemovedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (add_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) {
               eventHandlers.AddHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            if (remove_cpp_event_handler(key, this.evt_ContentRemovedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentRemovedEvt.</summary>
   public void On_ContentRemovedEvt(Efl.ContainerContentRemovedEvt_Args e)
   {
      EventHandler<Efl.ContainerContentRemovedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentRemovedEvt_delegate;
   private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContainerContentRemovedEvt_Args args = new Efl.ContainerContentRemovedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentRemovedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LayoutUpdatedEvtKey = new object();
   /// <summary>Sent after the layout was updated.</summary>
   public event EventHandler LayoutUpdatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (add_cpp_event_handler(key, this.evt_LayoutUpdatedEvt_delegate)) {
               eventHandlers.AddHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (remove_cpp_event_handler(key, this.evt_LayoutUpdatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
   public void On_LayoutUpdatedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[LayoutUpdatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LayoutUpdatedEvt_delegate;
   private void on_LayoutUpdatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_LayoutUpdatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_AnimateBeginEvt_delegate = new Efl.EventCb(on_AnimateBeginEvt_NativeCallback);
      evt_AnimateDoneEvt_delegate = new Efl.EventCb(on_AnimateDoneEvt_NativeCallback);
      evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
      evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
      evt_LayoutUpdatedEvt_delegate = new Efl.EventCb(on_LayoutUpdatedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.FlipInteraction efl_ui_flip_interaction_get(System.IntPtr obj);
   /// <summary>Get the interactive flip mode.</summary>
   /// <returns>The interactive flip mode to use.</returns>
   virtual public Efl.Ui.FlipInteraction GetInteraction() {
       var _ret_var = efl_ui_flip_interaction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_flip_interaction_set(System.IntPtr obj,   Efl.Ui.FlipInteraction mode);
   /// <summary>Set the interactive flip mode.
   /// This sets if the flip should be interactive (allow user to click and drag a side of the flip to reveal the back page and cause it to flip). By default a flip is not interactive. You may also need to set which sides of the flip are &quot;active&quot; for flipping and how much space they use (a minimum of a finger size) with <see cref="Efl.Ui.Flip.SetInteractionDirectionEnabled"/> and <see cref="Efl.Ui.Flip.SetInteractionDirectionHitsize"/>.
   /// 
   /// The four available mode of interaction are #ELM_FLIP_INTERACTION_NONE, #ELM_FLIP_INTERACTION_ROTATE, #ELM_FLIP_INTERACTION_CUBE and  #ELM_FLIP_INTERACTION_PAGE.
   /// 
   /// Note: #ELM_FLIP_INTERACTION_ROTATE won&apos;t cause #ELM_FLIP_ROTATE_XZ_CENTER_AXIS or #ELM_FLIP_ROTATE_YZ_CENTER_AXIS to happen, those can only be achieved with <see cref="Efl.Ui.Flip.Go"/>.</summary>
   /// <param name="mode">The interactive flip mode to use.</param>
   /// <returns></returns>
   virtual public  void SetInteraction( Efl.Ui.FlipInteraction mode) {
                         efl_ui_flip_interaction_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_flip_front_visible_get(System.IntPtr obj);
   /// <summary>Get flip front visibility state.</summary>
   /// <returns><c>true</c> if front front is showing, <c>false</c> if the back is showing.</returns>
   virtual public bool GetFrontVisible() {
       var _ret_var = efl_ui_flip_front_visible_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_flip_interaction_direction_hitsize_set(System.IntPtr obj,   Efl.Ui.Dir dir,   double hitsize);
   /// <summary>Set the amount of the flip that is sensitive to interactive flip.
   /// Set the amount of the flip that is sensitive to interactive flip, with 0 representing no area in the flip and 1 representing the entire flip. There is however a consideration to be made in that the area will never be smaller than the finger size set (as set in your Elementary configuration), and dragging must always start from the opposite half of the flip (eg. right half of the flip when dragging to the left).
   /// 
   /// Note: The <c>dir</c> parameter is not actually related to the direction of the drag, it only refers to the area in the flip where interaction can occur (top, bottom, left, right).
   /// 
   /// Negative values of <c>hitsize</c> will disable this hit area.
   /// 
   /// See also <see cref="Efl.Ui.Flip.SetInteraction"/>.</summary>
   /// <param name="dir">The hit area to set.</param>
   /// <param name="hitsize">The amount of that dimension (0.0 to 1.0) to use.</param>
   /// <returns></returns>
   virtual public  void SetInteractionDirectionHitsize( Efl.Ui.Dir dir,  double hitsize) {
                                           efl_ui_flip_interaction_direction_hitsize_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir,  hitsize);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern double efl_ui_flip_interaction_direction_hitsize_get(System.IntPtr obj,   Efl.Ui.Dir dir);
   /// <summary>Get the amount of the flip that is sensitive to interactive flip.</summary>
   /// <param name="dir">The direction to check.</param>
   /// <returns>The size set for that direction.</returns>
   virtual public double GetInteractionDirectionHitsize( Efl.Ui.Dir dir) {
                         var _ret_var = efl_ui_flip_interaction_direction_hitsize_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_flip_interaction_direction_enabled_set(System.IntPtr obj,   Efl.Ui.Dir dir,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Set which directions of the flip respond to interactive flip
   /// By default all directions are disabled, so you may want to enable the desired directions for flipping if you need interactive flipping. You must call this function once for each direction that&apos;s enabled.
   /// 
   /// You can also set the appropriate hit area size by calling <see cref="Efl.Ui.Flip.SetInteractionDirectionHitsize"/>. By default, a minimum hit area will be created on the opposite edge of the flip.</summary>
   /// <param name="dir">The direction to change.</param>
   /// <param name="enabled">If that direction is enabled or not.</param>
   /// <returns></returns>
   virtual public  void SetInteractionDirectionEnabled( Efl.Ui.Dir dir,  bool enabled) {
                                           efl_ui_flip_interaction_direction_enabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir,  enabled);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_flip_interaction_direction_enabled_get(System.IntPtr obj,   Efl.Ui.Dir dir);
   /// <summary>Get the enabled state of that flip direction.</summary>
   /// <param name="dir">The direction to check.</param>
   /// <returns>If that direction is enabled or not.</returns>
   virtual public bool GetInteractionDirectionEnabled( Efl.Ui.Dir dir) {
                         var _ret_var = efl_ui_flip_interaction_direction_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_flip_go(System.IntPtr obj,   Efl.Ui.FlipMode mode);
   /// <summary>Runs the flip animation.
   /// Flips the front and back contents using the <c>mode</c> animation. This effectively hides the currently visible content and shows the hidden one.
   /// 
   /// There a number of possible animations to use for flipping, namely #ELM_FLIP_ROTATE_X_CENTER_AXIS (rotate the currently visible content around a horizontal axis in the middle of its height, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_Y_CENTER_AXIS (rotate the currently visible content around a vertical axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_XZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_YZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its height, the other content is hown as the other side of the flip). #ELM_FLIP_CUBE_LEFT (rotate the currently visible content to the left as if the flip was a cube, the other content is shown as the right face of the cube), #ELM_FLIP_CUBE_RIGHT (rotate the currently visible content to the right as if the flip was a cube, the other content is shown as the left face of the cube), #ELM_FLIP_CUBE_UP (rotate the currently visible content up as if the flip was a cube, the other content is shown as the bottom face of the cube), #ELM_FLIP_CUBE_DOWN (rotate the currently visible content down as if the flip was a cube, the other content is shown as the upper face of the cube), #ELM_FLIP_PAGE_LEFT (move the currently visible content to the left as if the flip was a book, the other content is shown as the page below that), #ELM_FLIP_PAGE_RIGHT (move the currently visible content to the right as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_UP (move the currently visible content up as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_DOWN (move the currently visible content down as if the flip was a book, the other content is shown as the page below that) and #ELM_FLIP_CROSS_FADE (fade out the currently visible content, while fading in the invisible content).</summary>
   /// <param name="mode">The mode type.</param>
   /// <returns></returns>
   virtual public  void Go( Efl.Ui.FlipMode mode) {
                         efl_ui_flip_go((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_flip_go_to(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool front,   Efl.Ui.FlipMode mode);
   /// <summary>Runs the flip animation to front or back.
   /// Flips the front and back contents using the <c>mode</c> animation. This effectively hides the currently visible content and shows he hidden one.
   /// 
   /// There a number of possible animations to use for flipping, namely #ELM_FLIP_ROTATE_X_CENTER_AXIS (rotate the currently visible content around a horizontal axis in the middle of its height, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_Y_CENTER_AXIS (rotate the currently visible content around a vertical axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_XZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_YZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its height, the other content is shown as the other side of the flip). #ELM_FLIP_CUBE_LEFT (rotate the currently visible content to the left as if the flip was a cube, the other content is show as the right face of the cube), #ELM_FLIP_CUBE_RIGHT (rotate the currently visible content to the right as if the flip was a cube, the other content is show as the left face of the cube), #ELM_FLIP_CUBE_UP (rotate the currently visible content up as if the flip was a cube, the other content is shown as the bottom face of the cube), #ELM_FLIP_CUBE_DOWN (rotate the currently visible content down as if the flip was a cube, the other content is shown as the upper face of the cube), #ELM_FLIP_PAGE_LEFT (move the currently visible content to the left as if the flip was a book, the other content is shown as the page below that), #ELM_FLIP_PAGE_RIGHT (move the currently visible content to the right as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_UP (move the currently visible content up as if the flip was a book, the other content is shown as the page below it) and #ELM_FLIP_PAGE_DOWN (move the currently visible content down as if the flip was a book, the other content is shown as the page below that).</summary>
   /// <param name="front">If <c>true</c>, makes front visible, otherwise makes back.</param>
   /// <param name="mode">The mode type.</param>
   /// <returns></returns>
   virtual public  void GoTo( bool front,  Efl.Ui.FlipMode mode) {
                                           efl_ui_flip_go_to((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  front,  mode);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_content_remove(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   /// <summary>Unswallow an object from this container.</summary>
   /// <param name="content">To be removed content</param>
   /// <returns><c>false</c> if <c>content</c> was not a child or can not be removed.</returns>
   virtual public bool ContentRemove( Efl.Gfx.Entity content) {
                         var _ret_var = efl_content_remove((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  System.IntPtr efl_content_iterate(System.IntPtr obj);
   /// <summary>Begin iterating over this object&apos;s contents.</summary>
   /// <returns>Iterator to object content</returns>
   virtual public Eina.Iterator<Efl.Gfx.Entity> ContentIterate() {
       var _ret_var = efl_content_iterate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_content_count(System.IntPtr obj);
   /// <summary>Returns the number of UI elements packed in this container.</summary>
   /// <returns>Number of packed UI elements</returns>
   virtual public  int ContentCount() {
       var _ret_var = efl_content_count((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_pack_align_get(System.IntPtr obj,   out double align_horiz,   out double align_vert);
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   virtual public  void GetPackAlign( out double align_horiz,  out double align_vert) {
                                           efl_pack_align_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out align_horiz,  out align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_pack_align_set(System.IntPtr obj,   double align_horiz,   double align_vert);
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   virtual public  void SetPackAlign( double align_horiz,  double align_vert) {
                                           efl_pack_align_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  align_horiz,  align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_pack_padding_get(System.IntPtr obj,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void GetPackPadding( out double pad_horiz,  out double pad_vert,  out bool scalable) {
                                                             efl_pack_padding_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out pad_horiz,  out pad_vert,  out scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_pack_padding_set(System.IntPtr obj,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetPackPadding( double pad_horiz,  double pad_vert,  bool scalable) {
                                                             efl_pack_padding_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  pad_horiz,  pad_vert,  scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_clear(System.IntPtr obj);
   /// <summary>Removes all packed contents, and unreferences them.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool ClearPack() {
       var _ret_var = efl_pack_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_unpack_all(System.IntPtr obj);
   /// <summary>Removes all packed contents, without unreferencing them.
   /// Use with caution.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool UnpackAll() {
       var _ret_var = efl_pack_unpack_all((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_unpack(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   /// <summary>Removes an existing item from the container, without deleting it.</summary>
   /// <param name="subobj">The unpacked object.</param>
   /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t a child or can&apos;t be removed</returns>
   virtual public bool Unpack( Efl.Gfx.Entity subobj) {
                         var _ret_var = efl_pack_unpack((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   /// <summary>Adds an item to this container.
   /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">An object to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   virtual public bool DoPack( Efl.Gfx.Entity subobj) {
                         var _ret_var = efl_pack((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_begin(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   /// <summary>Prepend an object at the beginning of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, 0).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   virtual public bool PackBegin( Efl.Gfx.Entity subobj) {
                         var _ret_var = efl_pack_begin((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_end(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   /// <summary>Append object at the end of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, -1).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at the end.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   virtual public bool PackEnd( Efl.Gfx.Entity subobj) {
                         var _ret_var = efl_pack_end((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_before(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
   /// <summary>Prepend item before other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack before <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   virtual public bool PackBefore( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = efl_pack_before((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_after(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
   /// <summary>Append item after other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack after <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   virtual public bool PackAfter( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = efl_pack_after((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_pack_at(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);
   /// <summary>Inserts <c>subobj</c> at the specified <c>index</c>.
   /// Valid range: -<c>count</c> to +<c>count</c>. -1 refers to the last element. Out of range indices will trigger an append.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at given index.</param>
   /// <param name="index">A position.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   virtual public bool PackAt( Efl.Gfx.Entity subobj,   int index) {
                                           var _ret_var = efl_pack_at((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj,  index);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_pack_content_get(System.IntPtr obj,    int index);
   /// <summary>Content at a given index in this container.
   /// Index -1 refers to the last item. The valid range is -(count - 1) to (count - 1).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The object contained at the given <c>index</c>.</returns>
   virtual public Efl.Gfx.Entity GetPackContent(  int index) {
                         var _ret_var = efl_pack_content_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  int efl_pack_index_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   /// <summary>Get the index of a child in this container.</summary>
   /// <param name="subobj">An object contained in this pack.</param>
   /// <returns>-1 in case of failure, or the index of this item.</returns>
   virtual public  int GetPackIndex( Efl.Gfx.Entity subobj) {
                         var _ret_var = efl_pack_index_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Entity efl_pack_unpack_at(System.IntPtr obj,    int index);
   /// <summary>Pop out item at specified <c>index</c>.
   /// Equivalent to unpack(content_at(<c>index</c>)).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The child item if it could be removed.</returns>
   virtual public Efl.Gfx.Entity PackUnpackAt(  int index) {
                         var _ret_var = efl_pack_unpack_at((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the interactive flip mode.</summary>
   public Efl.Ui.FlipInteraction Interaction {
      get { return GetInteraction(); }
      set { SetInteraction( value); }
   }
   /// <summary>Get flip front visibility state.</summary>
   public bool FrontVisible {
      get { return GetFrontVisible(); }
   }
}
public class FlipNativeInherit : Efl.Ui.WidgetNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_flip_interaction_get_static_delegate = new efl_ui_flip_interaction_get_delegate(interaction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_get_static_delegate)});
      efl_ui_flip_interaction_set_static_delegate = new efl_ui_flip_interaction_set_delegate(interaction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_set_static_delegate)});
      efl_ui_flip_front_visible_get_static_delegate = new efl_ui_flip_front_visible_get_delegate(front_visible_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_front_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_front_visible_get_static_delegate)});
      efl_ui_flip_interaction_direction_hitsize_set_static_delegate = new efl_ui_flip_interaction_direction_hitsize_set_delegate(interaction_direction_hitsize_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_direction_hitsize_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_hitsize_set_static_delegate)});
      efl_ui_flip_interaction_direction_hitsize_get_static_delegate = new efl_ui_flip_interaction_direction_hitsize_get_delegate(interaction_direction_hitsize_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_direction_hitsize_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_hitsize_get_static_delegate)});
      efl_ui_flip_interaction_direction_enabled_set_static_delegate = new efl_ui_flip_interaction_direction_enabled_set_delegate(interaction_direction_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_direction_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_enabled_set_static_delegate)});
      efl_ui_flip_interaction_direction_enabled_get_static_delegate = new efl_ui_flip_interaction_direction_enabled_get_delegate(interaction_direction_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_interaction_direction_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_enabled_get_static_delegate)});
      efl_ui_flip_go_static_delegate = new efl_ui_flip_go_delegate(go);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_go_static_delegate)});
      efl_ui_flip_go_to_static_delegate = new efl_ui_flip_go_to_delegate(go_to);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_flip_go_to"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_go_to_static_delegate)});
      efl_content_remove_static_delegate = new efl_content_remove_delegate(content_remove);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_content_remove_static_delegate)});
      efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
      efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
      efl_pack_align_get_static_delegate = new efl_pack_align_get_delegate(pack_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_get_static_delegate)});
      efl_pack_align_set_static_delegate = new efl_pack_align_set_delegate(pack_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_set_static_delegate)});
      efl_pack_padding_get_static_delegate = new efl_pack_padding_get_delegate(pack_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_get_static_delegate)});
      efl_pack_padding_set_static_delegate = new efl_pack_padding_set_delegate(pack_padding_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_set_static_delegate)});
      efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate)});
      efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate)});
      efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate)});
      efl_pack_static_delegate = new efl_pack_delegate(pack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate)});
      efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate)});
      efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate)});
      efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate)});
      efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate)});
      efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate)});
      efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate)});
      efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate)});
      efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Flip.efl_ui_flip_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Flip.efl_ui_flip_class_get();
   }


    private delegate Efl.Ui.FlipInteraction efl_ui_flip_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.FlipInteraction efl_ui_flip_interaction_get(System.IntPtr obj);
    private static Efl.Ui.FlipInteraction interaction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.FlipInteraction _ret_var = default(Efl.Ui.FlipInteraction);
         try {
            _ret_var = ((Flip)wrapper).GetInteraction();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_flip_interaction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_flip_interaction_get_delegate efl_ui_flip_interaction_get_static_delegate;


    private delegate  void efl_ui_flip_interaction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.FlipInteraction mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_flip_interaction_set(System.IntPtr obj,   Efl.Ui.FlipInteraction mode);
    private static  void interaction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.FlipInteraction mode)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Flip)wrapper).SetInteraction( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_flip_interaction_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_flip_interaction_set_delegate efl_ui_flip_interaction_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_flip_front_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_flip_front_visible_get(System.IntPtr obj);
    private static bool front_visible_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_flip_front_visible_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).GetFrontVisible();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_flip_front_visible_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_flip_front_visible_get_delegate efl_ui_flip_front_visible_get_static_delegate;


    private delegate  void efl_ui_flip_interaction_direction_hitsize_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir,   double hitsize);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_flip_interaction_direction_hitsize_set(System.IntPtr obj,   Efl.Ui.Dir dir,   double hitsize);
    private static  void interaction_direction_hitsize_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir,  double hitsize)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_direction_hitsize_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Flip)wrapper).SetInteractionDirectionHitsize( dir,  hitsize);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_flip_interaction_direction_hitsize_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir,  hitsize);
      }
   }
   private efl_ui_flip_interaction_direction_hitsize_set_delegate efl_ui_flip_interaction_direction_hitsize_set_static_delegate;


    private delegate double efl_ui_flip_interaction_direction_hitsize_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern double efl_ui_flip_interaction_direction_hitsize_get(System.IntPtr obj,   Efl.Ui.Dir dir);
    private static double interaction_direction_hitsize_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_direction_hitsize_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Flip)wrapper).GetInteractionDirectionHitsize( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_flip_interaction_direction_hitsize_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_flip_interaction_direction_hitsize_get_delegate efl_ui_flip_interaction_direction_hitsize_get_static_delegate;


    private delegate  void efl_ui_flip_interaction_direction_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_flip_interaction_direction_enabled_set(System.IntPtr obj,   Efl.Ui.Dir dir,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void interaction_direction_enabled_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir,  bool enabled)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_direction_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Flip)wrapper).SetInteractionDirectionEnabled( dir,  enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_flip_interaction_direction_enabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir,  enabled);
      }
   }
   private efl_ui_flip_interaction_direction_enabled_set_delegate efl_ui_flip_interaction_direction_enabled_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_flip_interaction_direction_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_flip_interaction_direction_enabled_get(System.IntPtr obj,   Efl.Ui.Dir dir);
    private static bool interaction_direction_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_flip_interaction_direction_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).GetInteractionDirectionEnabled( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_flip_interaction_direction_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_flip_interaction_direction_enabled_get_delegate efl_ui_flip_interaction_direction_enabled_get_static_delegate;


    private delegate  void efl_ui_flip_go_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.FlipMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_flip_go(System.IntPtr obj,   Efl.Ui.FlipMode mode);
    private static  void go(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.FlipMode mode)
   {
      Eina.Log.Debug("function efl_ui_flip_go was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Flip)wrapper).Go( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_flip_go(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_flip_go_delegate efl_ui_flip_go_static_delegate;


    private delegate  void efl_ui_flip_go_to_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool front,   Efl.Ui.FlipMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_flip_go_to(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool front,   Efl.Ui.FlipMode mode);
    private static  void go_to(System.IntPtr obj, System.IntPtr pd,  bool front,  Efl.Ui.FlipMode mode)
   {
      Eina.Log.Debug("function efl_ui_flip_go_to was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Flip)wrapper).GoTo( front,  mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_flip_go_to(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  front,  mode);
      }
   }
   private efl_ui_flip_go_to_delegate efl_ui_flip_go_to_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_content_remove(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    private static bool content_remove(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_remove was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).ContentRemove( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_remove(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private efl_content_remove_delegate efl_content_remove_static_delegate;


    private delegate  System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_content_iterate(System.IntPtr obj);
    private static  System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Gfx.Entity> _ret_var = default(Eina.Iterator<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Flip)wrapper).ContentIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_content_iterate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_iterate_delegate efl_content_iterate_static_delegate;


    private delegate  int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_content_count(System.IntPtr obj);
    private static  int content_count(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_count was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Flip)wrapper).ContentCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_count(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_content_count_delegate efl_content_count_static_delegate;


    private delegate  void efl_pack_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double align_horiz,   out double align_vert);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_align_get(System.IntPtr obj,   out double align_horiz,   out double align_vert);
    private static  void pack_align_get(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           align_horiz = default(double);      align_vert = default(double);                     
         try {
            ((Flip)wrapper).GetPackAlign( out align_horiz,  out align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out align_horiz,  out align_vert);
      }
   }
   private efl_pack_align_get_delegate efl_pack_align_get_static_delegate;


    private delegate  void efl_pack_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double align_horiz,   double align_vert);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_align_set(System.IntPtr obj,   double align_horiz,   double align_vert);
    private static  void pack_align_set(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Flip)wrapper).SetPackAlign( align_horiz,  align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  align_horiz,  align_vert);
      }
   }
   private efl_pack_align_set_delegate efl_pack_align_set_static_delegate;


    private delegate  void efl_pack_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_padding_get(System.IntPtr obj,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
    private static  void pack_padding_get(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert,  out bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 pad_horiz = default(double);      pad_vert = default(double);      scalable = default(bool);                           
         try {
            ((Flip)wrapper).GetPackPadding( out pad_horiz,  out pad_vert,  out scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out pad_horiz,  out pad_vert,  out scalable);
      }
   }
   private efl_pack_padding_get_delegate efl_pack_padding_get_static_delegate;


    private delegate  void efl_pack_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_pack_padding_set(System.IntPtr obj,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
    private static  void pack_padding_set(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert,  bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Flip)wrapper).SetPackPadding( pad_horiz,  pad_vert,  scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pad_horiz,  pad_vert,  scalable);
      }
   }
   private efl_pack_padding_set_delegate efl_pack_padding_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_clear(System.IntPtr obj);
    private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).ClearPack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_pack_clear_delegate efl_pack_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_unpack_all(System.IntPtr obj);
    private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_unpack_all was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).UnpackAll();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_unpack_all(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_unpack(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    private static bool unpack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_unpack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).Unpack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private efl_pack_unpack_delegate efl_pack_unpack_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    private static bool pack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).DoPack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private efl_pack_delegate efl_pack_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_begin(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    private static bool pack_begin(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_begin was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).PackBegin( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_begin(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private efl_pack_begin_delegate efl_pack_begin_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_end(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    private static bool pack_end(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).PackEnd( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_end(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private efl_pack_end_delegate efl_pack_end_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_before(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    private static bool pack_before(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_before was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).PackBefore( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_before(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private efl_pack_before_delegate efl_pack_before_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_after(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    private static bool pack_after(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_after was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).PackAfter( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_after(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private efl_pack_after_delegate efl_pack_after_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_pack_at(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);
    private static bool pack_at(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,   int index)
   {
      Eina.Log.Debug("function efl_pack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Flip)wrapper).PackAt( subobj,  index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_at(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  index);
      }
   }
   private efl_pack_at_delegate efl_pack_at_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,    int index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_pack_content_get(System.IntPtr obj,    int index);
    private static Efl.Gfx.Entity pack_content_get(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Flip)wrapper).GetPackContent( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_content_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private efl_pack_content_get_delegate efl_pack_content_get_static_delegate;


    private delegate  int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_pack_index_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    private static  int pack_index_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     int _ret_var = default( int);
         try {
            _ret_var = ((Flip)wrapper).GetPackIndex( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_index_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private efl_pack_index_get_delegate efl_pack_index_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,    int index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Entity efl_pack_unpack_at(System.IntPtr obj,    int index);
    private static Efl.Gfx.Entity pack_unpack_at(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_unpack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Flip)wrapper).PackUnpackAt( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack_at(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Efl UI flip mode</summary>
public enum FlipMode
{
/// <summary>Rotate Y center axis flip mode</summary>
RotateYCenterAxis = 0,
/// <summary>Rotate X center axis flip mode</summary>
RotateXCenterAxis = 1,
/// <summary>Rotate XZ center axis flip mode</summary>
RotateXzCenterAxis = 2,
/// <summary>Rotate YZ center axis flip mode</summary>
RotateYzCenterAxis = 3,
/// <summary>Cube left flip mode</summary>
CubeLeft = 4,
/// <summary>Cube right flip mode</summary>
CubeRight = 5,
/// <summary>Cube up flip mode</summary>
CubeUp = 6,
/// <summary>Cube down flip mode</summary>
CubeDown = 7,
/// <summary>Page left flip mode</summary>
PageLeft = 8,
/// <summary>Page right flip mode</summary>
PageRight = 9,
/// <summary>Page up flip mode</summary>
PageUp = 10,
/// <summary>Page down flip mode</summary>
PageDown = 11,
/// <summary>Cross fade flip mode</summary>
CrossFade = 12,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Efl UI flip interaction</summary>
public enum FlipInteraction
{
/// <summary>No interaction</summary>
None = 0,
/// <summary>Rotate interaction</summary>
Rotate = 1,
/// <summary>Cube interaction</summary>
Cube = 2,
/// <summary>Page interaction</summary>
Page = 3,
}
} } 
