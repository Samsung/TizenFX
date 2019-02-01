#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics size hint interface</summary>
[SizeHintConcreteNativeInherit]
public interface SizeHint : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Defines the aspect ratio to respect when scaling this object.
/// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
/// 
/// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
/// <param name="mode">Mode of interpretation.</param>
/// <param name="sz">Base size to use for aspecting.</param>
/// <returns></returns>
 void GetHintAspect( out Efl.Gfx.SizeHintAspect mode,  out Eina.Size2D sz);
   /// <summary>Defines the aspect ratio to respect when scaling this object.
/// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
/// 
/// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
/// <param name="mode">Mode of interpretation.</param>
/// <param name="sz">Base size to use for aspecting.</param>
/// <returns></returns>
 void SetHintAspect( Efl.Gfx.SizeHintAspect mode,  Eina.Size2D sz);
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
/// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
Eina.Size2D GetHintMax();
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
/// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
/// <returns></returns>
 void SetHintMax( Eina.Size2D sz);
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintMin();
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
/// <param name="sz">Minimum size (hint) in pixels.</param>
/// <returns></returns>
 void SetHintMin( Eina.Size2D sz);
   /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintRestrictedMin();
   /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
/// <param name="sz">Minimum size (hint) in pixels.</param>
/// <returns></returns>
 void SetHintRestrictedMin( Eina.Size2D sz);
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
/// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintCombinedMin();
   /// <summary>Hints for an object&apos;s margin or padding space.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
/// <param name="l">Integer to specify left padding.</param>
/// <param name="r">Integer to specify right padding.</param>
/// <param name="t">Integer to specify top padding.</param>
/// <param name="b">Integer to specify bottom padding.</param>
/// <returns></returns>
 void GetHintMargin( out  int l,  out  int r,  out  int t,  out  int b);
   /// <summary>Hints for an object&apos;s margin or padding space.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
/// <param name="l">Integer to specify left padding.</param>
/// <param name="r">Integer to specify right padding.</param>
/// <param name="t">Integer to specify top padding.</param>
/// <param name="b">Integer to specify bottom padding.</param>
/// <returns></returns>
 void SetHintMargin(  int l,   int r,   int t,   int b);
   /// <summary>Hints for an object&apos;s weight.
/// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
/// 
/// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
/// 
/// Note: Default weight hint values are 0.0, for both axis.</summary>
/// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
/// <param name="y">Non-negative double value to use as vertical weight hint.</param>
/// <returns></returns>
 void GetHintWeight( out double x,  out double y);
   /// <summary>Hints for an object&apos;s weight.
/// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
/// 
/// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
/// 
/// Note: Default weight hint values are 0.0, for both axis.</summary>
/// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
/// <param name="y">Non-negative double value to use as vertical weight hint.</param>
/// <returns></returns>
 void SetHintWeight( double x,  double y);
   /// <summary>Hints for an object&apos;s alignment.
/// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
/// 
/// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default alignment hint values are 0.5, for both axes.</summary>
/// <param name="x">Double, ranging from 0.0 to 1.0.</param>
/// <param name="y">Double, ranging from 0.0 to 1.0.</param>
/// <returns></returns>
 void GetHintAlign( out double x,  out double y);
   /// <summary>Hints for an object&apos;s alignment.
/// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
/// 
/// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default alignment hint values are 0.5, for both axes.</summary>
/// <param name="x">Double, ranging from 0.0 to 1.0.</param>
/// <param name="y">Double, ranging from 0.0 to 1.0.</param>
/// <returns></returns>
 void SetHintAlign( double x,  double y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
/// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
/// 
/// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default fill hint values are true, for both axes.</summary>
/// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
/// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
/// <returns></returns>
 void GetHintFill( out bool x,  out bool y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
/// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
/// 
/// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default fill hint values are true, for both axes.</summary>
/// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
/// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
/// <returns></returns>
 void SetHintFill( bool x,  bool y);
                                                      /// <summary>Object size hints changed.</summary>
   event EventHandler ChangeSizeHintsEvt;
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   Eina.Size2D HintMax {
      get ;
      set ;
   }
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   Eina.Size2D HintMin {
      get ;
      set ;
   }
   /// <summary>Internal hints for an object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Values 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.SizeHint.HintMin"/> instead.</summary>
   Eina.Size2D HintRestrictedMin {
      get ;
      set ;
   }
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
/// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   Eina.Size2D HintCombinedMin {
      get ;
   }
}
/// <summary>Efl graphics size hint interface</summary>
sealed public class SizeHintConcrete : 

SizeHint
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SizeHintConcrete))
            return Efl.Gfx.SizeHintConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_size_hint_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SizeHintConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SizeHintConcrete()
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
   public static SizeHintConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SizeHintConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object ChangeSizeHintsEvtKey = new object();
   /// <summary>Object size hints changed.</summary>
   public event EventHandler ChangeSizeHintsEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_CHANGE_SIZE_HINTS";
            if (add_cpp_event_handler(key, this.evt_ChangeSizeHintsEvt_delegate)) {
               eventHandlers.AddHandler(ChangeSizeHintsEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_CHANGE_SIZE_HINTS";
            if (remove_cpp_event_handler(key, this.evt_ChangeSizeHintsEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangeSizeHintsEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangeSizeHintsEvt.</summary>
   public void On_ChangeSizeHintsEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChangeSizeHintsEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangeSizeHintsEvt_delegate;
   private void on_ChangeSizeHintsEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangeSizeHintsEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_ChangeSizeHintsEvt_delegate = new Efl.EventCb(on_ChangeSizeHintsEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_aspect_get(System.IntPtr obj,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   public  void GetHintAspect( out Efl.Gfx.SizeHintAspect mode,  out Eina.Size2D sz) {
                         var _out_sz = new Eina.Size2D_StructInternal();
                  efl_gfx_size_hint_aspect_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  out mode,  out _out_sz);
      Eina.Error.RaiseIfUnhandledException();
            sz = Eina.Size2D_StructConversion.ToManaged(_out_sz);
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_aspect_set(System.IntPtr obj,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   public  void SetHintAspect( Efl.Gfx.SizeHintAspect mode,  Eina.Size2D sz) {
             var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                              efl_gfx_size_hint_aspect_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  mode,  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_max_get(System.IntPtr obj);
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
   public Eina.Size2D GetHintMax() {
       var _ret_var = efl_gfx_size_hint_max_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_max_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
   /// <returns></returns>
   public  void SetHintMax( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_max_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_min_get(System.IntPtr obj);
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   public Eina.Size2D GetHintMin() {
       var _ret_var = efl_gfx_size_hint_min_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   public  void SetHintMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_min_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get(System.IntPtr obj);
   /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   public Eina.Size2D GetHintRestrictedMin() {
       var _ret_var = efl_gfx_size_hint_restricted_min_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_restricted_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   public  void SetHintRestrictedMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_restricted_min_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get(System.IntPtr obj);
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
   /// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   public Eina.Size2D GetHintCombinedMin() {
       var _ret_var = efl_gfx_size_hint_combined_min_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_margin_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   public  void GetHintMargin( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               efl_gfx_size_hint_margin_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_margin_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   public  void SetHintMargin(  int l,   int r,   int t,   int b) {
                                                                               efl_gfx_size_hint_margin_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  l,  r,  t,  b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_weight_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   public  void GetHintWeight( out double x,  out double y) {
                                           efl_gfx_size_hint_weight_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_weight_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   public  void SetHintWeight( double x,  double y) {
                                           efl_gfx_size_hint_weight_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_align_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Hints for an object&apos;s alignment.
   /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
   /// 
   /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default alignment hint values are 0.5, for both axes.</summary>
   /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
   /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
   /// <returns></returns>
   public  void GetHintAlign( out double x,  out double y) {
                                           efl_gfx_size_hint_align_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_align_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Hints for an object&apos;s alignment.
   /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
   /// 
   /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default alignment hint values are 0.5, for both axes.</summary>
   /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
   /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
   /// <returns></returns>
   public  void SetHintAlign( double x,  double y) {
                                           efl_gfx_size_hint_align_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_fill_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
   /// 
   /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default fill hint values are true, for both axes.</summary>
   /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
   /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
   /// <returns></returns>
   public  void GetHintFill( out bool x,  out bool y) {
                                           efl_gfx_size_hint_fill_get(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_hint_fill_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
   /// 
   /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default fill hint values are true, for both axes.</summary>
   /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
   /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
   /// <returns></returns>
   public  void SetHintFill( bool x,  bool y) {
                                           efl_gfx_size_hint_fill_set(Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   public Eina.Size2D HintMax {
      get { return GetHintMax(); }
      set { SetHintMax( value); }
   }
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   public Eina.Size2D HintMin {
      get { return GetHintMin(); }
      set { SetHintMin( value); }
   }
   /// <summary>Internal hints for an object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Values 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.SizeHint.HintMin"/> instead.</summary>
   public Eina.Size2D HintRestrictedMin {
      get { return GetHintRestrictedMin(); }
      set { SetHintRestrictedMin( value); }
   }
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
/// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   public Eina.Size2D HintCombinedMin {
      get { return GetHintCombinedMin(); }
   }
}
public class SizeHintConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_size_hint_aspect_get_static_delegate = new efl_gfx_size_hint_aspect_get_delegate(hint_aspect_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_aspect_get_static_delegate)});
      efl_gfx_size_hint_aspect_set_static_delegate = new efl_gfx_size_hint_aspect_set_delegate(hint_aspect_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_aspect_set_static_delegate)});
      efl_gfx_size_hint_max_get_static_delegate = new efl_gfx_size_hint_max_get_delegate(hint_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_max_get_static_delegate)});
      efl_gfx_size_hint_max_set_static_delegate = new efl_gfx_size_hint_max_set_delegate(hint_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_max_set_static_delegate)});
      efl_gfx_size_hint_min_get_static_delegate = new efl_gfx_size_hint_min_get_delegate(hint_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_min_get_static_delegate)});
      efl_gfx_size_hint_min_set_static_delegate = new efl_gfx_size_hint_min_set_delegate(hint_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_min_set_static_delegate)});
      efl_gfx_size_hint_restricted_min_get_static_delegate = new efl_gfx_size_hint_restricted_min_get_delegate(hint_restricted_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_restricted_min_get_static_delegate)});
      efl_gfx_size_hint_restricted_min_set_static_delegate = new efl_gfx_size_hint_restricted_min_set_delegate(hint_restricted_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_restricted_min_set_static_delegate)});
      efl_gfx_size_hint_combined_min_get_static_delegate = new efl_gfx_size_hint_combined_min_get_delegate(hint_combined_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_combined_min_get_static_delegate)});
      efl_gfx_size_hint_margin_get_static_delegate = new efl_gfx_size_hint_margin_get_delegate(hint_margin_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_margin_get_static_delegate)});
      efl_gfx_size_hint_margin_set_static_delegate = new efl_gfx_size_hint_margin_set_delegate(hint_margin_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_margin_set_static_delegate)});
      efl_gfx_size_hint_weight_get_static_delegate = new efl_gfx_size_hint_weight_get_delegate(hint_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_weight_get_static_delegate)});
      efl_gfx_size_hint_weight_set_static_delegate = new efl_gfx_size_hint_weight_set_delegate(hint_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_weight_set_static_delegate)});
      efl_gfx_size_hint_align_get_static_delegate = new efl_gfx_size_hint_align_get_delegate(hint_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_align_get_static_delegate)});
      efl_gfx_size_hint_align_set_static_delegate = new efl_gfx_size_hint_align_set_delegate(hint_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_align_set_static_delegate)});
      efl_gfx_size_hint_fill_get_static_delegate = new efl_gfx_size_hint_fill_get_delegate(hint_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_fill_get_static_delegate)});
      efl_gfx_size_hint_fill_set_static_delegate = new efl_gfx_size_hint_fill_set_delegate(hint_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_fill_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.SizeHintConcrete.efl_gfx_size_hint_interface_get();
   }


    private delegate  void efl_gfx_size_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_aspect_get(System.IntPtr obj,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
    private static  void hint_aspect_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Gfx.SizeHintAspect mode,  out Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_aspect_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           mode = default(Efl.Gfx.SizeHintAspect);      Eina.Size2D _out_sz = default(Eina.Size2D);
                     
         try {
            ((SizeHint)wrapper).GetHintAspect( out mode,  out _out_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            sz = Eina.Size2D_StructConversion.ToInternal(_out_sz);
                        } else {
         efl_gfx_size_hint_aspect_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out mode,  out sz);
      }
   }
   private efl_gfx_size_hint_aspect_get_delegate efl_gfx_size_hint_aspect_get_static_delegate;


    private delegate  void efl_gfx_size_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_aspect_set(System.IntPtr obj,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
    private static  void hint_aspect_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.SizeHintAspect mode,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_aspect_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                                 
         try {
            ((SizeHint)wrapper).SetHintAspect( mode,  _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_aspect_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  sz);
      }
   }
   private efl_gfx_size_hint_aspect_set_delegate efl_gfx_size_hint_aspect_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_max_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_max_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((SizeHint)wrapper).GetHintMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_max_get_delegate efl_gfx_size_hint_max_get_static_delegate;


    private delegate  void efl_gfx_size_hint_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_max_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_max_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((SizeHint)wrapper).SetHintMax( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_max_set_delegate efl_gfx_size_hint_max_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((SizeHint)wrapper).GetHintMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_min_get_delegate efl_gfx_size_hint_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((SizeHint)wrapper).SetHintMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_min_set_delegate efl_gfx_size_hint_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_restricted_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((SizeHint)wrapper).GetHintRestrictedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_restricted_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_restricted_min_get_delegate efl_gfx_size_hint_restricted_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_restricted_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_restricted_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_restricted_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((SizeHint)wrapper).SetHintRestrictedMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_restricted_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_restricted_min_set_delegate efl_gfx_size_hint_restricted_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_combined_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_combined_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((SizeHint)wrapper).GetHintCombinedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_combined_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_combined_min_get_delegate efl_gfx_size_hint_combined_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_margin_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    private static  void hint_margin_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_margin_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((SizeHint)wrapper).GetHintMargin( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_size_hint_margin_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_size_hint_margin_get_delegate efl_gfx_size_hint_margin_get_static_delegate;


    private delegate  void efl_gfx_size_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,    int l,    int r,    int t,    int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_margin_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
    private static  void hint_margin_set(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_margin_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((SizeHint)wrapper).SetHintMargin( l,  r,  t,  b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_size_hint_margin_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
      }
   }
   private efl_gfx_size_hint_margin_set_delegate efl_gfx_size_hint_margin_set_static_delegate;


    private delegate  void efl_gfx_size_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_weight_get(System.IntPtr obj,   out double x,   out double y);
    private static  void hint_weight_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((SizeHint)wrapper).GetHintWeight( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_weight_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_weight_get_delegate efl_gfx_size_hint_weight_get_static_delegate;


    private delegate  void efl_gfx_size_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_weight_set(System.IntPtr obj,   double x,   double y);
    private static  void hint_weight_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((SizeHint)wrapper).SetHintWeight( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_weight_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_weight_set_delegate efl_gfx_size_hint_weight_set_static_delegate;


    private delegate  void efl_gfx_size_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_align_get(System.IntPtr obj,   out double x,   out double y);
    private static  void hint_align_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((SizeHint)wrapper).GetHintAlign( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_align_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_align_get_delegate efl_gfx_size_hint_align_get_static_delegate;


    private delegate  void efl_gfx_size_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_align_set(System.IntPtr obj,   double x,   double y);
    private static  void hint_align_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((SizeHint)wrapper).SetHintAlign( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_align_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_align_set_delegate efl_gfx_size_hint_align_set_static_delegate;


    private delegate  void efl_gfx_size_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_fill_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
    private static  void hint_fill_get(System.IntPtr obj, System.IntPtr pd,  out bool x,  out bool y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(bool);      y = default(bool);                     
         try {
            ((SizeHint)wrapper).GetHintFill( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_fill_get_delegate efl_gfx_size_hint_fill_get_static_delegate;


    private delegate  void efl_gfx_size_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_fill_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
    private static  void hint_fill_set(System.IntPtr obj, System.IntPtr pd,  bool x,  bool y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((SizeHint)wrapper).SetHintFill( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_fill_set_delegate efl_gfx_size_hint_fill_set_static_delegate;
}
} } 
