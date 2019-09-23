#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Low-level rectangle object.
/// This provides a smart version of the typical &quot;event rectangle&quot;, which allows objects to set this as their parent and route events to a group of objects. Events will not propagate to non-member objects below this object.
/// 
/// Adding members is done just like a normal smart object, using efl_canvas_group_member_add (Eo API) or evas_object_smart_member_add (legacy).
/// 
/// Child objects are not modified in any way, unlike other types of smart objects.
/// 
/// No child objects should be stacked above the event grabber parent while the grabber is visible. A critical error will be raised if this is detected.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.EventGrabber.NativeMethods]
[Efl.Eo.BindingEntity]
public class EventGrabber : Efl.Canvas.Group
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(EventGrabber))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_event_grabber_class_get();
    /// <summary>Initializes a new instance of the <see cref="EventGrabber"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public EventGrabber(Efl.Object parent= null
            ) : base(efl_canvas_event_grabber_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected EventGrabber(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventGrabber"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected EventGrabber(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventGrabber"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected EventGrabber(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
    /// <returns>If <c>true</c>, stop updating</returns>
    public virtual bool GetFreezeWhenVisible() {
         var _ret_var = Efl.Canvas.EventGrabber.NativeMethods.efl_canvas_event_grabber_freeze_when_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
    /// <param name="set">If <c>true</c>, stop updating</param>
    public virtual void SetFreezeWhenVisible(bool set) {
                                 Efl.Canvas.EventGrabber.NativeMethods.efl_canvas_event_grabber_freeze_when_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
    /// <value>If <c>true</c>, stop updating</value>
    public bool FreezeWhenVisible {
        get { return GetFreezeWhenVisible(); }
        set { SetFreezeWhenVisible(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Group.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_event_grabber_freeze_when_visible_get_static_delegate == null)
            {
                efl_canvas_event_grabber_freeze_when_visible_get_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_get_delegate(freeze_when_visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFreezeWhenVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_event_grabber_freeze_when_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_get_static_delegate) });
            }

            if (efl_canvas_event_grabber_freeze_when_visible_set_static_delegate == null)
            {
                efl_canvas_event_grabber_freeze_when_visible_set_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_set_delegate(freeze_when_visible_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFreezeWhenVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_event_grabber_freeze_when_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_event_grabber_freeze_when_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_event_grabber_freeze_when_visible_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_get_api_delegate> efl_canvas_event_grabber_freeze_when_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_get_api_delegate>(Module, "efl_canvas_event_grabber_freeze_when_visible_get");

        private static bool freeze_when_visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((EventGrabber)ws.Target).GetFreezeWhenVisible();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_canvas_event_grabber_freeze_when_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_event_grabber_freeze_when_visible_get_delegate efl_canvas_event_grabber_freeze_when_visible_get_static_delegate;

        
        private delegate void efl_canvas_event_grabber_freeze_when_visible_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool set);

        
        public delegate void efl_canvas_event_grabber_freeze_when_visible_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool set);

        public static Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_set_api_delegate> efl_canvas_event_grabber_freeze_when_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_set_api_delegate>(Module, "efl_canvas_event_grabber_freeze_when_visible_set");

        private static void freeze_when_visible_set(System.IntPtr obj, System.IntPtr pd, bool set)
        {
            Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((EventGrabber)ws.Target).SetFreezeWhenVisible(set);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_event_grabber_freeze_when_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), set);
            }
        }

        private static efl_canvas_event_grabber_freeze_when_visible_set_delegate efl_canvas_event_grabber_freeze_when_visible_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasEventGrabber_ExtensionMethods {
    public static Efl.BindableProperty<bool> FreezeWhenVisible<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.EventGrabber, T>magic = null) where T : Efl.Canvas.EventGrabber {
        return new Efl.BindableProperty<bool>("freeze_when_visible", fac);
    }

}
#pragma warning restore CS1591
#endif
