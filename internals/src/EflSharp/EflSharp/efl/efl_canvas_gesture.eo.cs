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

/// <summary>EFL Gesture abstract class
/// A gesture class defines a method that spcific gesture event and privides information about the gesture&apos;s type, state, and associated pointer information.
/// 
/// For cetain gesture types, additional methods are defined to provide meaningful gesture information to the user.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Gesture.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Gesture : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Gesture))
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
        efl_canvas_gesture_class_get();
    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Gesture(Efl.Object parent= null
            ) : base(efl_canvas_gesture_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Gesture(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Gesture(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class GestureRealized : Gesture
    {
        private GestureRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Gesture"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Gesture(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>This property holds the current state of the gesture.</summary>
    /// <returns>gesture state</returns>
    virtual public Efl.Canvas.GestureState GetState() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the current state of the gesture.</summary>
    /// <param name="state">gesture state</param>
    virtual public void SetState(Efl.Canvas.GestureState state) {
                                 Efl.Canvas.Gesture.NativeMethods.efl_gesture_state_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),state);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
    /// <returns>hotspot co-ordinate</returns>
    virtual public Eina.Position2D GetHotspot() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_hotspot_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
    /// <param name="hotspot">hotspot co-ordinate</param>
    virtual public void SetHotspot(Eina.Position2D hotspot) {
         Eina.Position2D.NativeStruct _in_hotspot = hotspot;
                        Efl.Canvas.Gesture.NativeMethods.efl_gesture_hotspot_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_hotspot);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property holds the timestamp of the current gesture.</summary>
    /// <returns>The timestamp</returns>
    virtual public uint GetTimestamp() {
         var _ret_var = Efl.Canvas.Gesture.NativeMethods.efl_gesture_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the timestamp of the current gesture.</summary>
    /// <param name="timestamp">The timestamp</param>
    virtual public void SetTimestamp(uint timestamp) {
                                 Efl.Canvas.Gesture.NativeMethods.efl_gesture_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),timestamp);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property holds the current state of the gesture.</summary>
    /// <value>gesture state</value>
    public Efl.Canvas.GestureState State {
        get { return GetState(); }
        set { SetState(value); }
    }
    /// <summary>This property holds the hotspot of the current gesture.</summary>
    /// <value>hotspot co-ordinate</value>
    public Eina.Position2D Hotspot {
        get { return GetHotspot(); }
        set { SetHotspot(value); }
    }
    /// <summary>This property holds the timestamp of the current gesture.</summary>
    /// <value>The timestamp</value>
    public uint Timestamp {
        get { return GetTimestamp(); }
        set { SetTimestamp(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Gesture.efl_canvas_gesture_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gesture_state_get_static_delegate == null)
            {
                efl_gesture_state_get_static_delegate = new efl_gesture_state_get_delegate(state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_state_get_static_delegate) });
            }

            if (efl_gesture_state_set_static_delegate == null)
            {
                efl_gesture_state_set_static_delegate = new efl_gesture_state_set_delegate(state_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_state_set_static_delegate) });
            }

            if (efl_gesture_hotspot_get_static_delegate == null)
            {
                efl_gesture_hotspot_get_static_delegate = new efl_gesture_hotspot_get_delegate(hotspot_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHotspot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_hotspot_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_hotspot_get_static_delegate) });
            }

            if (efl_gesture_hotspot_set_static_delegate == null)
            {
                efl_gesture_hotspot_set_static_delegate = new efl_gesture_hotspot_set_delegate(hotspot_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHotspot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_hotspot_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_hotspot_set_static_delegate) });
            }

            if (efl_gesture_timestamp_get_static_delegate == null)
            {
                efl_gesture_timestamp_get_static_delegate = new efl_gesture_timestamp_get_delegate(timestamp_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimestamp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_timestamp_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_timestamp_get_static_delegate) });
            }

            if (efl_gesture_timestamp_set_static_delegate == null)
            {
                efl_gesture_timestamp_set_static_delegate = new efl_gesture_timestamp_set_delegate(timestamp_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimestamp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_timestamp_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_timestamp_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Gesture.efl_canvas_gesture_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Canvas.GestureState efl_gesture_state_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Canvas.GestureState efl_gesture_state_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_state_get_api_delegate> efl_gesture_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_state_get_api_delegate>(Module, "efl_gesture_state_get");

        private static Efl.Canvas.GestureState state_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.GestureState _ret_var = default(Efl.Canvas.GestureState);
                try
                {
                    _ret_var = ((Gesture)ws.Target).GetState();
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
                return efl_gesture_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_state_get_delegate efl_gesture_state_get_static_delegate;

        
        private delegate void efl_gesture_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.GestureState state);

        
        public delegate void efl_gesture_state_set_api_delegate(System.IntPtr obj,  Efl.Canvas.GestureState state);

        public static Efl.Eo.FunctionWrapper<efl_gesture_state_set_api_delegate> efl_gesture_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_state_set_api_delegate>(Module, "efl_gesture_state_set");

        private static void state_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.GestureState state)
        {
            Eina.Log.Debug("function efl_gesture_state_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Gesture)ws.Target).SetState(state);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state);
            }
        }

        private static efl_gesture_state_set_delegate efl_gesture_state_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_gesture_hotspot_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_gesture_hotspot_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_hotspot_get_api_delegate> efl_gesture_hotspot_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_hotspot_get_api_delegate>(Module, "efl_gesture_hotspot_get");

        private static Eina.Position2D.NativeStruct hotspot_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_hotspot_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Gesture)ws.Target).GetHotspot();
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
                return efl_gesture_hotspot_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_hotspot_get_delegate efl_gesture_hotspot_get_static_delegate;

        
        private delegate void efl_gesture_hotspot_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct hotspot);

        
        public delegate void efl_gesture_hotspot_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct hotspot);

        public static Efl.Eo.FunctionWrapper<efl_gesture_hotspot_set_api_delegate> efl_gesture_hotspot_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_hotspot_set_api_delegate>(Module, "efl_gesture_hotspot_set");

        private static void hotspot_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct hotspot)
        {
            Eina.Log.Debug("function efl_gesture_hotspot_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_hotspot = hotspot;
                            
                try
                {
                    ((Gesture)ws.Target).SetHotspot(_in_hotspot);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_hotspot_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hotspot);
            }
        }

        private static efl_gesture_hotspot_set_delegate efl_gesture_hotspot_set_static_delegate;

        
        private delegate uint efl_gesture_timestamp_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_gesture_timestamp_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_timestamp_get_api_delegate> efl_gesture_timestamp_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_timestamp_get_api_delegate>(Module, "efl_gesture_timestamp_get");

        private static uint timestamp_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_timestamp_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Gesture)ws.Target).GetTimestamp();
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
                return efl_gesture_timestamp_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_timestamp_get_delegate efl_gesture_timestamp_get_static_delegate;

        
        private delegate void efl_gesture_timestamp_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint timestamp);

        
        public delegate void efl_gesture_timestamp_set_api_delegate(System.IntPtr obj,  uint timestamp);

        public static Efl.Eo.FunctionWrapper<efl_gesture_timestamp_set_api_delegate> efl_gesture_timestamp_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_timestamp_set_api_delegate>(Module, "efl_gesture_timestamp_set");

        private static void timestamp_set(System.IntPtr obj, System.IntPtr pd, uint timestamp)
        {
            Eina.Log.Debug("function efl_gesture_timestamp_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Gesture)ws.Target).SetTimestamp(timestamp);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_timestamp_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), timestamp);
            }
        }

        private static efl_gesture_timestamp_set_delegate efl_gesture_timestamp_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasGesture_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Canvas.GestureState> State<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Gesture, T>magic = null) where T : Efl.Canvas.Gesture {
        return new Efl.BindableProperty<Efl.Canvas.GestureState>("state", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> Hotspot<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Gesture, T>magic = null) where T : Efl.Canvas.Gesture {
        return new Efl.BindableProperty<Eina.Position2D>("hotspot", fac);
    }

    public static Efl.BindableProperty<uint> Timestamp<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Gesture, T>magic = null) where T : Efl.Canvas.Gesture {
        return new Efl.BindableProperty<uint>("timestamp", fac);
    }

}
#pragma warning restore CS1591
#endif
