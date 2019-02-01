#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Low-level rectangle object.
/// This provides a smart version of the typical &quot;event rectangle&quot;, which allows objects to set this as their parent and route events to a group of objects. Events will not propagate to non-member objects below this object.
/// 
/// Adding members is done just like a normal smart object, using efl_canvas_group_member_add (Eo API) or evas_object_smart_member_add (legacy).
/// 
/// Child objects are not modified in any way, unlike other types of smart objects.
/// 
/// No child objects should be stacked above the event grabber parent while the grabber is visible. A critical error will be raised if this is detected.
/// 1.20</summary>
[EventGrabberNativeInherit]
public class EventGrabber : Efl.Canvas.Group, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.EventGrabberNativeInherit nativeInherit = new Efl.Canvas.EventGrabberNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (EventGrabber))
            return Efl.Canvas.EventGrabberNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(EventGrabber obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_event_grabber_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public EventGrabber(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("EventGrabber", efl_canvas_event_grabber_class_get(), typeof(EventGrabber), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected EventGrabber(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public EventGrabber(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static EventGrabber static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new EventGrabber(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_event_grabber_freeze_when_visible_get(System.IntPtr obj);
   /// <summary>Stops the grabber from updating its internal stacking order while visible
   /// 1.20</summary>
   /// <returns>If <c>true</c>, stop updating
   /// 1.20</returns>
   virtual public bool GetFreezeWhenVisible() {
       var _ret_var = efl_canvas_event_grabber_freeze_when_visible_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_event_grabber_freeze_when_visible_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool set);
   /// <summary>Stops the grabber from updating its internal stacking order while visible
   /// 1.20</summary>
   /// <param name="set">If <c>true</c>, stop updating
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetFreezeWhenVisible( bool set) {
                         efl_canvas_event_grabber_freeze_when_visible_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  set);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Stops the grabber from updating its internal stacking order while visible
/// 1.20</summary>
   public bool FreezeWhenVisible {
      get { return GetFreezeWhenVisible(); }
      set { SetFreezeWhenVisible( value); }
   }
}
public class EventGrabberNativeInherit : Efl.Canvas.GroupNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_event_grabber_freeze_when_visible_get_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_get_delegate(freeze_when_visible_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_event_grabber_freeze_when_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_get_static_delegate)});
      efl_canvas_event_grabber_freeze_when_visible_set_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_set_delegate(freeze_when_visible_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_event_grabber_freeze_when_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_event_grabber_freeze_when_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_event_grabber_freeze_when_visible_get(System.IntPtr obj);
    private static bool freeze_when_visible_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((EventGrabber)wrapper).GetFreezeWhenVisible();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_event_grabber_freeze_when_visible_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_event_grabber_freeze_when_visible_get_delegate efl_canvas_event_grabber_freeze_when_visible_get_static_delegate;


    private delegate  void efl_canvas_event_grabber_freeze_when_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool set);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_event_grabber_freeze_when_visible_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool set);
    private static  void freeze_when_visible_set(System.IntPtr obj, System.IntPtr pd,  bool set)
   {
      Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((EventGrabber)wrapper).SetFreezeWhenVisible( set);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_event_grabber_freeze_when_visible_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  set);
      }
   }
   private efl_canvas_event_grabber_freeze_when_visible_set_delegate efl_canvas_event_grabber_freeze_when_visible_set_static_delegate;
}
} } 
